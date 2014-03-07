using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OPMedia.Runtime.Logging
{
    public enum LogLineFields
    {
        SessionID = 0,
        Timestamp,
        EntryType,
        PID,
        TID,
        AppName,
        ModuleName,
        LogText,

        FieldCount,
    }

    class LogFileReader
    {
        internal static List<string> ReadLogFileLines(SeverityLevels filter, string logFile, int lineCount, bool lastRows)
        {
            List<string> lines = new List<string>();

            if (!string.IsNullOrEmpty(logFile))
            {
                using (FileStream fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    long size = fs.Length;
                    if (size > 1024 * 1024)
                    {
                        // Jump to last rows in log file
                        fs.Seek(-1024 * 1024, SeekOrigin.End);
                    }

                    using (StreamReader sr = new StreamReader(fs))
                    {
                        bool discardSublines = false;

                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (line != null)
                            {
                                // Analyze line
                                if (!line.StartsWith("~~") && !discardSublines)
                                {
                                    lines.Add(line);
                                }
                                else
                                {
                                    string[] fields = line.Split(new char[] { '|', '~' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (fields.Length >= (int)LogLineFields.FieldCount)
                                    {
                                        string field = fields[(int)LogLineFields.EntryType];
                                        SeverityLevels entryType = (SeverityLevels)Enum.Parse(typeof(SeverityLevels), field);

                                        if ((filter & entryType) == entryType)
                                        {
                                            lines.Add(line);
                                            discardSublines = false;
                                        }
                                        else
                                        {
                                            discardSublines = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (lineCount < 1)
                {
                    return lines;
                }
                else
                {
                    lineCount = Math.Min(lineCount, lines.Count);

                    if (lastRows)
                    {
                        return lines.GetRange(lines.Count - lineCount, lineCount);
                    }
                    else
                    {
                        return lines.GetRange(0, lineCount);
                    }
                }
            }

            return lines;
        }
    }
}
