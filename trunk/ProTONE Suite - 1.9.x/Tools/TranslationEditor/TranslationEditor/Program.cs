using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TranslationEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string Text = "<html><body>##</body></html>";

            string[] lines = File.ReadAllLines(@"c:\octavianp.txt");
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                try
                {
                    string dir = Path.GetDirectoryName(line);
                    string file = Path.GetFileNameWithoutExtension(line);
                    Directory.CreateDirectory(dir);

                    string text = Text.Replace("##", file);

                    File.WriteAllText(line, text);
                }
                catch{}
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
