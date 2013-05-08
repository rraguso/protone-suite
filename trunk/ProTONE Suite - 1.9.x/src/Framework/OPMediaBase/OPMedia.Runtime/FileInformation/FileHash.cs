using System.IO;
using System;
using System.Text;

namespace OPMedia.Runtime.FileInformation
{
    public class FileHash
    {
        public static byte[] ComputeHash(string filename)
        {
            using (Stream stream = File.OpenRead(filename))
            {
                return ComputeHash(stream);
            }
        }

        public static byte[] ComputeHash(Stream input)
        {
            long length = input.Length;
            ulong num = (ulong)length;
            long num3 = 0L;
            byte[] buffer = new byte[8];
            
            input.Position = 0L;
            
            while ((num3 < 0x2000L) && (input.Read(buffer, 0, 8) > 0))
            {
                num3 += 1L;
                num += BitConverter.ToUInt64(buffer, 0);
            }
            
            input.Position = Math.Max((long)0L, (long)(length - 0x10000L));
            num3 = 0L;
            
            while ((num3 < 0x2000L) && (input.Read(buffer, 0, 8) > 0))
            {
                num3 += 1L;
                num += BitConverter.ToUInt64(buffer, 0);
            }
            
            byte[] bytes = BitConverter.GetBytes(num);
            Array.Reverse(bytes);
            return bytes;
        }

        public static string ToHexadecimal(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

    }
}
