//
//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.
//
//  Email:  yetiicb@hotmail.com
//
//  Copyright (C) 2002-2003 Idael Cardoso. 
//

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb;

namespace OPMedia.Runtime.ProTONE.Rendering.Cdda
{
  public class CDBufferFiller
  {
    byte[] BufferArray;
    int WritePosition = 0;

    public CDBufferFiller(byte[] aBuffer)
    {
      BufferArray = aBuffer;
    }
    public void OnCdDataRead(object sender, DataReadEventArgs ea)
    {
      Buffer.BlockCopy(ea.Data, 0, BufferArray, WritePosition, (int)ea.DataSize);
      WritePosition += (int)ea.DataSize;
    }

  }

  public class CDDrive : IDisposable
  {
      // Fields
      protected const int CB_AUDIO = 0x930;
      protected const int CB_CDDASECTOR = 0x940;
      protected const int CB_CDROMSECTOR = 0x800;
      protected const int CB_QSUBCHANNEL = 0x10;
      private IntPtr cdHandle;
      private char m_Drive = '\0';
      private DeviceChangeNotificationWindow NotWnd = null;
      protected const int NSECTORS = 13;
      private Win32Functions.CDROM_TOC Toc = null;
      private bool TocValid = false;
      protected const int UNDERSAMPLING = 1;

      // Events
      public event EventHandler CDInserted;

      public event EventHandler CDRemoved;

      // Methods
      public CDDrive()
      {
          this.Toc = new Win32Functions.CDROM_TOC();
          this.cdHandle = IntPtr.Zero;
      }

      private int cddb_sum(int n)
      {
          int num = 0;
          while (n > 0)
          {
              num += n % 10;
              n /= 10;
          }
          return num;
      }

      public void Close()
      {
          this.UnLockCD();
          if (this.NotWnd != null)
          {
              this.NotWnd.DestroyHandle();
              this.NotWnd = null;
          }
          if ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0))
          {
              Win32Functions.CloseHandle(this.cdHandle);
          }
          this.cdHandle = IntPtr.Zero;
          this.m_Drive = '\0';
          this.TocValid = false;
      }

      public void Dispose()
      {
          this.Close();
          GC.SuppressFinalize(this);
      }

      public bool EjectCD()
      {
          this.TocValid = false;
          if ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0))
          {
              uint lpBytesReturned = 0;
              return (Win32Functions.DeviceIoControl(this.cdHandle, 0x2d4808, IntPtr.Zero, 0, IntPtr.Zero, 0, ref lpBytesReturned, IntPtr.Zero) != 0);
          }
          return false;
      }

      ~CDDrive()
      {
          this.Dispose();
      }

      public string GetCDDBQuery()
      {
          int numTracks = this.GetNumTracks();
          if (numTracks == -1)
          {
              throw new Exception("Unable to retrieve the number of tracks, Cannot calculate DiskID.");
          }
          string str = numTracks.ToString();
          int num3 = 0;
          int num4 = 0;
          double num5 = 0.0;
          int num6 = 0;
          int track = 0;
          while (track < numTracks)
          {
              num5 = (((this.Toc.TrackData[track].Address_1 * 60) + this.Toc.TrackData[track].Address_2) * 0x4b) + this.Toc.TrackData[track].Address_3;
              num4 += this.cddb_sum((this.Toc.TrackData[track].Address_1 * 60) + this.Toc.TrackData[track].Address_2);
              num6 += this.GetSeconds(track);
              str = str + "+" + string.Format("{0}", num5);
              track++;
          }
          int num7 = (this.Toc.TrackData[track].Address_1 * 60) + this.Toc.TrackData[track].Address_2;
          str = str + "+" + num7;
          Win32Functions.TRACK_DATA track_data = this.Toc.TrackData[numTracks];
          Win32Functions.TRACK_DATA track_data2 = this.Toc.TrackData[0];
          num3 = ((track_data.Address_1 * 60) + track_data.Address_2) - ((track_data2.Address_1 * 60) + track_data2.Address_2);
          ulong num8 = (ulong)((((num4 % 0xff) << 0x18) | (num3 << 8)) | numTracks);
          return (string.Format("{0:x8}", num8) + "+" + str);
      }

      public static char[] GetCDDriveLetters()
      {
          string str = "";
          for (char ch = 'C'; ch <= 'Z'; ch = (char)(ch + '\x0001'))
          {
              if (Win32Functions.GetDriveType(ch + ":") == Win32Functions.DriveTypes.DRIVE_CDROM)
              {
                  str = str + ch;
              }
          }
          return str.ToCharArray();
      }

      protected int GetEndSector(int track)
      {
          if ((this.TocValid && (track >= this.Toc.FirstTrack)) && (track <= this.Toc.LastTrack))
          {
              Win32Functions.TRACK_DATA track_data = this.Toc.TrackData[track];
              return (((((track_data.Address_1 * 60) * 0x4b) + (track_data.Address_2 * 0x4b)) + track_data.Address_3) - 0x97);
          }
          return -1;
      }

      protected int GetEndSector2(int track)
      {
          if ((this.TocValid && (track >= this.Toc.FirstTrack)) && (track <= this.Toc.LastTrack))
          {
              Win32Functions.TRACK_DATA track_data = this.Toc.TrackData[track];
              return ((((track_data.Address_1 * 60) * 0x4b) + (track_data.Address_2 * 0x4b)) - 0x97);
          }
          return -1;
      }

      public int GetNumAudioTracks()
      {
          if (this.TocValid)
          {
              int num = 0;
              for (int i = this.Toc.FirstTrack - 1; i < this.Toc.LastTrack; i++)
              {
                  Win32Functions.TRACK_DATA track_data = this.Toc.TrackData[i];
                  if (track_data.Control == 0)
                  {
                      num++;
                  }
              }
              return num;
          }
          return -1;
      }

      public int GetNumTracks()
      {
          if (this.TocValid)
          {
              return ((this.Toc.LastTrack - this.Toc.FirstTrack) + 1);
          }
          return -1;
      }

      public int GetSeconds(int track)
      {
          if ((this.TocValid && (track >= this.Toc.FirstTrack)) && (track <= this.Toc.LastTrack))
          {
              int num = (this.GetStartSector(track) + 150) / 0x4b;
              int num2 = (this.GetEndSector(track) + 150) / 0x4b;
              return (num2 - num);
          }
          return -1;
      }

      protected int GetStartSector(int track)
      {
          if ((this.TocValid && (track >= this.Toc.FirstTrack)) && (track <= this.Toc.LastTrack))
          {
              Win32Functions.TRACK_DATA track_data = this.Toc.TrackData[track - 1];
              return (((((track_data.Address_1 * 60) * 0x4b) + (track_data.Address_2 * 0x4b)) + track_data.Address_3) - 150);
          }
          return -1;
      }

      public bool IsAudioTrack(int track)
      {
          if ((this.TocValid && (track >= this.Toc.FirstTrack)) && (track <= this.Toc.LastTrack))
          {
              Win32Functions.TRACK_DATA track_data = this.Toc.TrackData[track - 1];
              return ((track_data.Control & 4) == 0);
          }
          return false;
      }

      public bool IsCDReady()
      {
          if ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0))
          {
              uint lpBytesReturned = 0;
              if (Win32Functions.DeviceIoControl(this.cdHandle, 0x2d4800, IntPtr.Zero, 0, IntPtr.Zero, 0, ref lpBytesReturned, IntPtr.Zero) != 0)
              {
                  return true;
              }
              this.TocValid = false;
              return false;
          }
          this.TocValid = false;
          return false;
      }

      public bool LoadCD()
      {
          this.TocValid = false;
          if ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0))
          {
              uint lpBytesReturned = 0;
              return (Win32Functions.DeviceIoControl(this.cdHandle, 0x2d480c, IntPtr.Zero, 0, IntPtr.Zero, 0, ref lpBytesReturned, IntPtr.Zero) != 0);
          }
          return false;
      }

      public bool LockCD()
      {
          if ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0))
          {
              uint bytesReturned = 0;
              Win32Functions.PREVENT_MEDIA_REMOVAL inMediaRemoval = new Win32Functions.PREVENT_MEDIA_REMOVAL
              {
                  PreventMediaRemoval = 1
              };
              return (Win32Functions.DeviceIoControl(this.cdHandle, 0x2d4804, inMediaRemoval, (uint)Marshal.SizeOf(inMediaRemoval), IntPtr.Zero, 0, ref bytesReturned, IntPtr.Zero) != 0);
          }
          return false;
      }

      private void NotWnd_DeviceChange(object sender, DeviceChangeEventArgs ea)
      {
          if (ea.Drive == this.m_Drive)
          {
              switch (ea.ChangeType)
              {
                  case DeviceChangeEventType.DeviceInserted:
                      this.OnCDInserted();
                      break;

                  case DeviceChangeEventType.DeviceRemoved:
                      this.TocValid = false;
                      this.OnCDRemoved();
                      break;
              }
          }
      }

      private void OnCDInserted()
      {
          if (this.CDInserted != null)
          {
              this.CDInserted(this, EventArgs.Empty);
          }
      }

      private void OnCDRemoved()
      {
          if (this.CDRemoved != null)
          {
              this.CDRemoved(this, EventArgs.Empty);
          }
      }

      public bool Open(char Drive)
      {
          this.Close();
          if (Win32Functions.GetDriveType(Drive + @":\") == Win32Functions.DriveTypes.DRIVE_CDROM)
          {
              this.cdHandle = Win32Functions.CreateFile(@"\\.\" + Drive + ':', 0x80000000, 1, IntPtr.Zero, 3, 0, IntPtr.Zero);
              if ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0))
              {
                  this.m_Drive = Drive;
                  this.NotWnd = new DeviceChangeNotificationWindow();
                  this.NotWnd.DeviceChange += new DeviceChangeEventHandler(this.NotWnd_DeviceChange);
                  return true;
              }
              return true;
          }
          return false;
      }

      protected bool ReadSector(int sector, byte[] Buffer, int NumSectors)
      {
          if ((this.TocValid && ((sector + NumSectors) <= this.GetEndSector(this.Toc.LastTrack))) && (Buffer.Length >= (0x930 * NumSectors)))
          {
              Win32Functions.RAW_READ_INFO rri = new Win32Functions.RAW_READ_INFO
              {
                  TrackMode = Win32Functions.TRACK_MODE_TYPE.CDDA,
                  SectorCount = (uint)NumSectors,
                  DiskOffset = (long)(sector * 0x800)
              };
              uint bytesReturned = 0;
              return (Win32Functions.DeviceIoControl(this.cdHandle, 0x2403e, rri, (uint)Marshal.SizeOf(rri), Buffer, (uint)(NumSectors * 0x930), ref bytesReturned, IntPtr.Zero) != 0);
          }
          return false;
      }

      protected bool ReadTOC()
      {
          if ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0))
          {
              uint bytesReturned = 0;
              this.TocValid = Win32Functions.DeviceIoControl(this.cdHandle, 0x24000, IntPtr.Zero, 0, this.Toc, (uint)Marshal.SizeOf(this.Toc), ref bytesReturned, IntPtr.Zero) != 0;
          }
          else
          {
              this.TocValid = false;
          }
          return this.TocValid;
      }

      public int ReadTrack(int track, CdDataReadEventHandler DataReadEvent, CdReadProgressEventHandler ProgressEvent)
      {
          return this.ReadTrack(track, DataReadEvent, 0, 0, ProgressEvent);
      }

      public int ReadTrack(int track, byte[] Data, ref uint DataSize, CdReadProgressEventHandler ProgressEvent)
      {
          return this.ReadTrack(track, Data, ref DataSize, 0, 0, ProgressEvent);
      }

      public int ReadTrack(int track, CdDataReadEventHandler DataReadEvent, uint StartSecond, uint Seconds2Read, CdReadProgressEventHandler ProgressEvent)
      {
          if (((this.TocValid && (track >= this.Toc.FirstTrack)) && (track <= this.Toc.LastTrack)) && (DataReadEvent != null))
          {
              ReadProgressEventArgs args;
              int startSector = this.GetStartSector(track);
              int endSector = this.GetEndSector(track);
              if ((startSector += ((int)(StartSecond * 0x4b))) >= endSector)
              {
                  startSector -= (int)(StartSecond * 0x4b);
              }
              if ((Seconds2Read > 0) && ((startSector + ((int)(Seconds2Read * 0x4b))) < endSector))
              {
                  endSector = startSector + ((int)(Seconds2Read * 0x4b));
              }
              uint num3 = (uint)((endSector - startSector) * 0x930);
              uint bytesread = 0;
              byte[] buffer = new byte[0x7770];
              bool flag = true;
              bool flag2 = true;
              if (ProgressEvent != null)
              {
                  args = new ReadProgressEventArgs(num3, 0);
                  ProgressEvent(this, args);
                  flag = !args.CancelRead;
              }
              for (int i = startSector; ((i < endSector) && flag) && flag2; i += 13)
              {
                  int numSectors = ((i + 13) < endSector) ? 13 : (endSector - i);
                  flag2 = this.ReadSector(i, buffer, numSectors);
                  if (flag2)
                  {
                      DataReadEventArgs ea = new DataReadEventArgs(buffer, (uint)(0x930 * numSectors));
                      DataReadEvent(this, ea);
                      bytesread += (uint)(0x930 * numSectors);
                      if (ProgressEvent != null)
                      {
                          args = new ReadProgressEventArgs(num3, bytesread);
                          ProgressEvent(this, args);
                          flag = !args.CancelRead;
                      }
                  }
              }
              if (flag2)
              {
                  return (int)bytesread;
              }
              return -1;
          }
          return -1;
      }

      public int ReadTrack(int track, byte[] Data, ref uint DataSize, uint StartSecond, uint Seconds2Read, CdReadProgressEventHandler ProgressEvent)
      {
          if ((this.TocValid && (track >= this.Toc.FirstTrack)) && (track <= this.Toc.LastTrack))
          {
              int startSector = this.GetStartSector(track);
              int endSector = this.GetEndSector(track);
              if ((startSector += ((int)(StartSecond * 0x4b))) >= endSector)
              {
                  startSector -= (int)(StartSecond * 0x4b);
              }
              if ((Seconds2Read > 0) && ((startSector + ((int)(Seconds2Read * 0x4b))) < endSector))
              {
                  endSector = startSector + ((int)(Seconds2Read * 0x4b));
              }
              DataSize = (uint)((endSector - startSector) * 0x930);
              if (Data != null)
              {
                  if (Data.Length >= ((int)DataSize))
                  {
                      CDBufferFiller filler = new CDBufferFiller(Data);
                      return this.ReadTrack(track, new CdDataReadEventHandler(filler.OnCdDataRead), StartSecond, Seconds2Read, ProgressEvent);
                  }
                  return 0;
              }
              return 0;
          }
          return -1;
      }

      public bool Refresh()
      {
          return (this.IsCDReady() && this.ReadTOC());
      }

      public uint TrackSize(int track)
      {
          uint dataSize = 0;
          this.ReadTrack(track, null, ref dataSize, null);
          return dataSize;
      }

      public bool UnLockCD()
      {
          if ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0))
          {
              uint bytesReturned = 0;
              Win32Functions.PREVENT_MEDIA_REMOVAL inMediaRemoval = new Win32Functions.PREVENT_MEDIA_REMOVAL
              {
                  PreventMediaRemoval = 0
              };
              return (Win32Functions.DeviceIoControl(this.cdHandle, 0x2d4804, inMediaRemoval, (uint)Marshal.SizeOf(inMediaRemoval), IntPtr.Zero, 0, ref bytesReturned, IntPtr.Zero) != 0);
          }
          return false;
      }

      // Properties
      public IntPtr CDHandle
      {
          get
          {
              return this.cdHandle;
          }
      }

      public char Drive
      {
          get
          {
              return this.m_Drive;
          }
      }

      public bool IsOpened
      {
          get
          {
              return ((((int)this.cdHandle) != -1) && (((int)this.cdHandle) != 0));
          }
      }

      public string GetCDDBDiskID()
      {
          int numTracks = GetNumTracks();
          if (numTracks == -1)
              throw new Exception("Unable to retrieve the number of tracks, Cannot calculate DiskID.");

          string postfix = numTracks.ToString();

          int i, t = 0, n = 0;

          double ofs = 0;

          int secs = 0;

          /* For backward compatibility this algorithm must not change */
          i = 0;

          while (i < numTracks)
          {
              Console.WriteLine("Track {0}: {1}:{2}", i, GetSeconds(i) / 60, GetSeconds(i) % 60);

              ofs = (((Toc.TrackData[i].Address_1 * 60) + Toc.TrackData[i].Address_2) * 75) + Toc.TrackData[i].Address_3;
              n = n + cddb_sum((Toc.TrackData[i].Address_1 * 60) + Toc.TrackData[i].Address_2);
              secs += GetSeconds(i);
              postfix += " " + string.Format("{0}", ofs);

              i++;
          }


          int numSecs = Toc.TrackData[i].Address_1 * 60 + Toc.TrackData[i].Address_2;

          Console.WriteLine("n = {0}, numSecs = {1}, secs = {2}", n, numSecs, secs);

          postfix += " " + numSecs;
          Win32Functions.TRACK_DATA last = Toc.TrackData[numTracks];
          Win32Functions.TRACK_DATA first = Toc.TrackData[0];

          t = ((last.Address_1 * 60) + last.Address_2) -
              ((first.Address_1 * 60) + first.Address_2);

          ulong lDiscId = (((uint)n % 0xff) << 24 | (uint)t << 8 | (uint)numTracks);

          string sDiscId = String.Format("{0:x8}", lDiscId);

          return sDiscId;
      }

      public bool ReadCDText(out TrackCollection cdTracks)
      {
          cdTracks = null;

          Version version = Environment.OSVersion.Version;
          if (((Environment.OSVersion.Platform != PlatformID.Win32NT) || (version.Major < 5)) || ((version.Major == 5) && (version.Minor < 1)))
              return false;

          Win32Functions.CDROM_READ_TOC_EX structure = new Win32Functions.CDROM_READ_TOC_EX
          {
              Format = Win32Functions.CDROM_READ_TOC_EX_FORMAT.CDTEXT
          };
          int cb = Marshal.SizeOf(structure);
          IntPtr ptr = Marshal.AllocHGlobal(cb);
          Marshal.StructureToPtr(structure, ptr, true);

          Win32Functions.CDROM_TOC_CD_TEXT_DATA cdrom_toc_cd_text_data = new Win32Functions.CDROM_TOC_CD_TEXT_DATA
          {
            Length = (ushort)Marshal.SizeOf(typeof(Win32Functions.CDROM_TOC_CD_TEXT_DATA))
          };

          IntPtr ptr2 = Marshal.AllocHGlobal(cdrom_toc_cd_text_data.Length);
          Marshal.StructureToPtr(cdrom_toc_cd_text_data, ptr2, true);
          uint bytesReturned = 0;
          bool flag = Win32Functions.DeviceIoControl(this.CDHandle, Win32Functions.IOCTL_CDROM_READ_TOC_EX, ptr, (uint)cb, ptr2, cdrom_toc_cd_text_data.Length, ref bytesReturned, IntPtr.Zero) != 0;
          if (flag)
          {
              Marshal.PtrToStructure(ptr2, cdrom_toc_cd_text_data);
              cdTracks = this.BuildCDTracks(cdrom_toc_cd_text_data);
          }

          Marshal.FreeHGlobal(ptr2);
          Marshal.FreeHGlobal(ptr);
          return flag;
      }

      private TrackCollection BuildCDTracks(Win32Functions.CDROM_TOC_CD_TEXT_DATA Data)
      {
          TrackCollection tracks = new TrackCollection();

          List<string> titles = new List<string>();
          List<string> artists = new List<string>();
          List<string> genres = new List<string>();

          string item = string.Empty;

          try
          {
              Console.WriteLine("++++");
              for (int i = 0; i < Data.Descriptors.MaxIndex; i++)
              {
                  Console.WriteLine("");
                  foreach (char c in Data.Descriptors[i].Text)
                  {
                      if (c != '\0')
                          Console.Write(c);
                      else
                          Console.Write(".");

                  }
              }
              Console.WriteLine("++++");

              for (int i = 0; i < Data.Descriptors.MaxIndex; i++)
              {
                  Win32Functions.CDROM_TOC_CD_TEXT_DATA_BLOCK cdrom_toc_cd_text_data_block = Data.Descriptors[i];
                  foreach (char ch in cdrom_toc_cd_text_data_block.Text)
                  {
                      if (ch != '\0')
                      {
                          item = item + ch;
                      }
                      else
                      {
                          switch (cdrom_toc_cd_text_data_block.PackType)
                          {
                              case Win32Functions.CDROM_CD_TEXT_PACK.ALBUM_NAME:
                                  titles.Add(item);
                                  item = string.Empty;
                                  break;

                              case Win32Functions.CDROM_CD_TEXT_PACK.GENRE:
                                  genres.Add(item);
                                  item = string.Empty;
                                  break;

                              case Win32Functions.CDROM_CD_TEXT_PACK.PERFORMER:
                                  artists.Add(item);
                                  item = string.Empty;
                                  break;

                              default:
                                  item = string.Empty;
                                  break;
                          }
                      }
                  }
              }

          }
          catch (IndexOutOfRangeException)
          {
          }
          finally
          {
              
          }

          int max = titles.Count;
          if (artists.Count != 0 && max > artists.Count)
              max = artists.Count;
          if (genres.Count != 0 && max > genres.Count)
              max = genres.Count;
              
          for(int i = 1; i < max; i++)
          {
              try
              {
                  Track track = new Track(titles[i]);
                  tracks.Add(track);
              }
              catch { }
          }

          return tracks;
      }

 


 

  }
}


