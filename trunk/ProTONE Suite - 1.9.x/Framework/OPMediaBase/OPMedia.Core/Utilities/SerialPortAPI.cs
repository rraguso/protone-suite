using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using Microsoft.Win32;

namespace OPMedia.Core
{
    public static class SerialPortAPI
    {
        public static bool FillSerialPortSettings(ref SerialPort serialPort)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OPMedia Research\Serial Ports\" + serialPort.PortName);
            if (key != null)
            {
                try
                {
                    serialPort.BaudRate = (int)key.GetValue("BaudRate", 9600);
                    serialPort.DataBits = (int)key.GetValue("DataBits", 8);
                    serialPort.DtrEnable = ((int)key.GetValue("DtrEnable", 0) != 0);
                    serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake),
                        (string)key.GetValue("Handshake", "None"));
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity),
                        (string)key.GetValue("Parity", "None"));
                    serialPort.ReadTimeout = (int)key.GetValue("ReadTimeout", 500);
                    serialPort.RtsEnable = ((int)key.GetValue("RtsEnable", 0) != 0);
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits),
                        (string)key.GetValue("StopBits", "One"));
                    serialPort.WriteTimeout = (int)key.GetValue("WriteTimeout", 500);

                    serialPort.ReceivedBytesThreshold = (int)key.GetValue("ReceivedBytesThreshold", 1);

                    return true;
                }
                catch
                {
                }
            }

            return false;
        }

        public static void SavePortSettings(SerialPort serialPort)
        {
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey( @"SOFTWARE\OPMedia Research\Serial Ports\" + serialPort.PortName))
            {
                if (key != null)
                {
                    key.SetValue("BaudRate", serialPort.BaudRate);
                    key.SetValue("DataBits", serialPort.DataBits);
                    key.SetValue("DtrEnable", serialPort.DtrEnable ? 1 : 0);
                    key.SetValue("Handshake", serialPort.Handshake.ToString());
                    key.SetValue("Parity", serialPort.Parity.ToString());
                    key.SetValue("ReadTimeout", serialPort.ReadTimeout);
                    key.SetValue("RtsEnable", serialPort.RtsEnable ? 1 : 0);
                    key.SetValue("StopBits", serialPort.StopBits.ToString());
                    key.SetValue("WriteTimeout", serialPort.WriteTimeout);
                    key.SetValue("ReceivedBytesThreshold", serialPort.ReceivedBytesThreshold);
                }
            }
        }
    }
}
