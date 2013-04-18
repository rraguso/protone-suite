using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Collections.Specialized;
using System.IO;
using System.ComponentModel;
using System.Threading;
using OPMedia.Core.Logging;
using OPMedia.Core.TranslationSupport;

namespace OPMedia.ServiceHelper.RCCService.InputPins
{
    public enum DcbFlagsPos
    {
        fBinary           = 0,
        fParity           = 1,
        fOutxCtsFlow      = 2,
        fOutxDsrFlow      = 3,
        fDtrControl       = 4,
        fDsrSensitivity   = 6,
        fTXContinueOnXoff = 7,
        fOutX             = 8,
        fInX              = 9,
        fErrorChar        = 10,
        fNull             = 11,
        fRtsControl       = 12,
        fAbortOnError     = 14,
        fDummy2           = 15,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct DCB
    {
        public uint DCBlength;
        public uint BaudRate;
        public uint Flags;
        public ushort wReserved;
        public ushort XonLim;
        public ushort XoffLim;
        public byte ByteSize;
        public byte Parity;
        public byte StopBits;
        public byte XonChar;
        public byte XoffChar;
        public byte ErrorChar;
        public byte EofChar;
        public byte EvtChar;
        public ushort wReserved1;

        internal void SetDcbFlag(DcbFlagsPos whichFlag, int setting)
        {
            uint num;
            setting = setting << (int)whichFlag;
            if ((whichFlag == DcbFlagsPos.fDtrControl) || (whichFlag == DcbFlagsPos.fRtsControl))
            {
                num = 3;
            }
            else if (whichFlag == DcbFlagsPos.fDummy2)
            {
                num = 0x1ffff;
            }
            else
            {
                num = 1;
            }
            this.Flags &= ~(num << (int)whichFlag);
            this.Flags |= (uint)setting;
        }

        internal int GetDcbFlag(DcbFlagsPos whichFlag)
        {
            uint num;
            if ((whichFlag == DcbFlagsPos.fDtrControl) || (whichFlag == DcbFlagsPos.fRtsControl))
            {
                num = 3;
            }
            else if (whichFlag == DcbFlagsPos.fDummy2)
            {
                num = 0x1ffff;
            }
            else
            {
                num = 1;
            }
            uint num2 = this.Flags & (num << (int)whichFlag);
            return (int)(num2 >> (int)whichFlag);
        }
    }

    public delegate void DriverCallbackDelegate(Int64 counter);
    public delegate void SignalOutputCallbackDelegate(Int64 counter, double erfc);

    public enum DeviceErrorCodes
    {
	    ErrSuccess = 0,
	    ErrPortOpen = -1,
	    ErrSetGetCommState = -2,
	    ErrCreateEvents = -3,
	    ErrCreateRecvThread = -4,
	    ErrSignalStop = -5,
	    ErrStopThreadForced = -6,
    }

    public sealed class SerialRemoteDeviceDriver : IDisposable
    {
        [DllImport("IRSerDev.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int PortInit(string lpszPortName, DCB initDcb);

        [DllImport("IRSerDev.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int PortClose();

        [DllImport("IRSerDev.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void RegisterCallback(IntPtr callbackFunc);

        #region Detection parameters / properties


        public const char Delimiter = ';';

        public override string ToString()
        {
            return Translator.TranslateTaggedString(
                string.Format("TXT_INTERCODEWORDSGAP {0}\nTXT_MINCODEWORDLENGTH {1}\nTXT_MAXCODEWORDLENGTH {2}\nTXT_MINCODEWORDOCCURENCES {3}",
                InterCodeWordsGap, MinCodeWordLength, MaxCodeWordLength, MinCodeWordOccurences)
                );
        }

        SerialPort _port = null;

        public event SignalOutputCallbackDelegate SignalOutput = null;

        private DriverCallbackDelegate callback = null;

        bool _running = false;

        [Browsable(false)]
        public bool Running
        {
            get
            {
                return _running;
            }
        }

        
        private long _MinCodeWordLength = 10;
        private long _MaxCodeWordLength = 20;
        private long _InterCodeWordsGap = 10000;
        private int  _MinCodeWordOccurences = 8;

        [Browsable(true)]
        [DefaultValue((long)10)]
        [TranslatableDisplayName("TXT_MINCODEWORDLENGTH")]
        public long MinCodeWordLength
        { get { return _MinCodeWordLength; } set { _MinCodeWordLength = value; } }

        [Browsable(true)]
        [DefaultValue((long)20)]
        [TranslatableDisplayName("TXT_MAXCODEWORDLENGTH")]
        public long MaxCodeWordLength
        { get { return _MaxCodeWordLength; } set { _MaxCodeWordLength = value; } }

        [Browsable(true)]
        [DefaultValue((long)10000)]
        [TranslatableDisplayName("TXT_INTERCODEWORDSGAP")]
        public long InterCodeWordsGap
        { get { return _InterCodeWordsGap; } set { _InterCodeWordsGap = value; } }

        [Browsable(true)]
        [DefaultValue(8)]
        [TranslatableDisplayName("TXT_MINCODEWORDOCCURENCES")]
        public int MinCodeWordOccurences
        { get { return _MinCodeWordOccurences; } set { _MinCodeWordOccurences = value; } }

        private bool _trainMode = false;

        [Browsable(false)]
        public bool TrainMode
        { get { return _trainMode; } set { _trainMode = value; } }

        #endregion


        List<long> _rawCodes = null;

        public SerialRemoteDeviceDriver Clone()
        {
            SerialRemoteDeviceDriver retVal = new SerialRemoteDeviceDriver();
            retVal.InterCodeWordsGap = this.InterCodeWordsGap;
            retVal.MaxCodeWordLength = this.MaxCodeWordLength;
            retVal.MinCodeWordLength = this.MinCodeWordLength;
            retVal.MinCodeWordOccurences = this.MinCodeWordOccurences;

            return retVal;
        }
                
        public SerialRemoteDeviceDriver()
        {
        }

        public void Start(SerialPort port)
        {
            if (callback == null)
            {
                callback = new DriverCallbackDelegate(DriverCallback);
                IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate(callback);
                RegisterCallback(callbackPtr);
            }

            if (_running)
            {
                Stop();
            }

            if (!_running)
            {
                _port = port;

                DCB dcb = new DCB();
                dcb.BaudRate = (uint)_port.BaudRate;
                dcb.ByteSize = (byte)_port.DataBits;
                dcb.DCBlength = (uint)Marshal.SizeOf(dcb);
                dcb.Parity = (byte)_port.Parity;

                switch (_port.StopBits)
                {
                    case StopBits.One:
                        dcb.StopBits = 0;
                        break;

                    case StopBits.Two:
                        dcb.StopBits = 2;
                        break;

                    case StopBits.OnePointFive:
                        dcb.StopBits = 1;
                        break;
                }

                dcb.SetDcbFlag(DcbFlagsPos.fDtrControl, _port.DtrEnable ? 1 : 0);
                dcb.SetDcbFlag(DcbFlagsPos.fRtsControl, _port.RtsEnable ? 1 : 0);

                int errCode = PortInit(_port.PortName, dcb);
                ThrowExceptionForErrCode(errCode);

                _running = true;
            }
        }

        public void Stop()
        {
            if (_running)
            {
                int errCode = PortClose();
                ThrowExceptionForErrCode(errCode);

                _running = false;
            }
        }

        public void Dispose()
        {
            Stop();
        }

        private void ThrowExceptionForErrCode(int errCode)
        {
            switch (errCode)
            {
                case (int)DeviceErrorCodes.ErrSuccess:
                    break;

                case (int)DeviceErrorCodes.ErrPortOpen:
                    throw new IOException("Failed to open port: " + _port.PortName);

                case (int)DeviceErrorCodes.ErrSetGetCommState:
                    throw new IOException("Failed to set/get state of port: " + _port.PortName);

                case (int)DeviceErrorCodes.ErrCreateEvents:
                    throw new IOException("Failed to create event monitor on port: " + _port.PortName);

                case (int)DeviceErrorCodes.ErrCreateRecvThread:
                    throw new IOException("Failed to create monitor thread on port: " + _port.PortName);

                case (int)DeviceErrorCodes.ErrSignalStop:
                    throw new IOException("Failed to destroy event monitor on port: " + _port.PortName);

                case (int)DeviceErrorCodes.ErrStopThreadForced:
                    throw new IOException("Failed to forcibly stop monitor thread on port: " + _port.PortName);

                default:
                    throw new IOException("Unspecified error on port: " + _port.PortName,
                        new Win32Exception());
            }
        }

        private void DriverCallback(Int64 counter)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(AnalyzePortState), counter);
        }

        private void AnalyzePortState(object state)
        {
            try
            {
                long diff = (long)state;

                if (diff >= InterCodeWordsGap && _rawCodes != null)
                {
                    List<long> rawCodesClone = new List<long>();
                    rawCodesClone.AddRange(_rawCodes);
                    _rawCodes = null;

                    AnalyzeRawCodes(rawCodesClone);
                }
                else
                {
                    if (_rawCodes == null)
                    {
                        _rawCodes = new List<long>();
                    }

                    _rawCodes.Add(diff);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);

                _rawCodes = null;
                RaiseSignalOutput(long.MaxValue, 1.0f /* max erfc */);
            }
        }

        private void AnalyzeRawCodes(List<long> rawCodes)
        {
            string str = string.Empty;
            foreach (int rc in rawCodes)
            {
                str += rc.ToString() + " ";
            }

            if (rawCodes == null || rawCodes.Count < 3)
            {
                Logger.LogTrace("SerialRemoteDeviceDriver.AnalyzeRawCodes: rawCodes = {0} => discarded", str);

                RaiseSignalOutput(long.MaxValue, 1.0f /* max erfc */);
                return; // Discard line
            }

            long rawLineCode = 0;
            string line = string.Empty;

            for (int i = 0; i < rawCodes.Count; i++)
            {
                long rawCode = rawCodes[i];

                long scaledCode = ROUND((double)rawCode / 100);

                if (scaledCode > MaxCodeWordLength)
                    scaledCode = 2;
                else if (scaledCode < MinCodeWordLength)
                    scaledCode = 0;
                else
                    scaledCode = 1;

                rawLineCode += (scaledCode << i);
            }

            Logger.LogTrace("SerialRemoteDeviceDriver.AnalyzeRawCodes: rawCodes = {0} => rawLineCode={1:x}", str, rawLineCode);

            AnalizeRawLine(rawLineCode);
        }

        public static long ROUND(double value)
        {
            double floorValue = Math.Floor(value);
            double remaint = value - floorValue;
            double roundedValue = (2 * remaint >= 1) ? floorValue + 1 : floorValue;
            return (long)roundedValue;
        }

        Dictionary<long, int> codeLines = new Dictionary<long, int>();
        int totalCodeLines = 0;
        long _prevCode = 0;

        private void AnalizeRawLine(long rawLineCode)
        {
            double erfc = double.Epsilon;

            totalCodeLines++;

            if (_trainMode)
            {
                if (codeLines.ContainsKey(rawLineCode))
                {
                    int val = codeLines[rawLineCode];
                    codeLines[rawLineCode] = val + 1;
                }
                else
                {
                    codeLines.Add(rawLineCode, 1);
                }

                if (totalCodeLines >= 2 * MinCodeWordOccurences)
                {
                    AnalyzeOccurences();
                    codeLines = new Dictionary<long, int>();
                    totalCodeLines = 0;
                }
            }
            else
            {
                if (rawLineCode == _prevCode)
                {
                    if (totalCodeLines >= MinCodeWordOccurences)
                    {
                        _prevCode = 0;
                        RaiseSignalOutput(rawLineCode, erfc);
                    }
                }
                else
                {
                    _prevCode = rawLineCode;
                    totalCodeLines = 1;
                }
            }
        }

        string outputText = string.Empty;
        private void AnalyzeOccurences()
        {
            int min = 0;
            long occurence = 0;

            foreach (KeyValuePair<long, int> kvp in codeLines)
            {
                if (kvp.Value > min)
                {
                    occurence = kvp.Key;
                    min = kvp.Value;
                }
            }

            if (occurence == 0)
            {
                min = 0;
            }

            if (min >= MinCodeWordOccurences)
            {
                double erfc = Math.Max(double.Epsilon, 1 - (double)min / (2 * (double)MinCodeWordOccurences));
                RaiseSignalOutput(occurence, erfc);
            }
            else
            {
                RaiseSignalOutput(long.MaxValue, 1 /* max erfc */);
            }
        }

        private void RaiseSignalOutput(long code, double erfc)
        {
            Logger.LogTrace("code={0:x}, erfc={1}", code, erfc);

            if (SignalOutput != null)
            {
                SignalOutput(code, erfc);
            }
        }

    }


}
