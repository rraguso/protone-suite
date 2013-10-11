using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell.Interop;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SqlCeCustomTool
{
    public static class Constants
    {
        public const string ToolGuid = "5694E2C2-A333-4C37-B09C-96663E948ED9";
        public const string ToolName = "GenerateDbmlFromSdf";
        public const string ToolDesc = "Generates DBML from SQL CE Compact (SDF) files";

        public const string SdkRegKey = @"SOFTWARE\Microsoft\Microsoft SDKs\Windows\v7.0A\WinSDK-NetFx40Tools";
    }

    [Guid(Constants.ToolGuid)]
    [ComVisible(true)]
    public class GenerateDbmlFromSdf : IVsSingleFileGenerator
    {
        #region Registration 
                                                            
        internal static Guid CSharpCategoryGuid = new Guid("FAE04EC1-301F-11D3-BF4B-00C04F79EFBC");
        private const string VisualStudioVersion = "10.0";

        [ComRegisterFunction]
        public static void RegisterServer(string s)
        {
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(GetKeyName(CSharpCategoryGuid, Constants.ToolName)))
            {
                key.SetValue("", Constants.ToolDesc);
                key.SetValue("CLSID", "{" + Constants.ToolGuid + "}");
                key.SetValue("GeneratesDesignTimeSource", 1);
            }
        }

        [ComUnregisterFunction]
        public static void UnRegisterServer(string s)
        {
            Registry.LocalMachine.DeleteSubKey(GetKeyName(CSharpCategoryGuid, Constants.ToolName), false);
        }

        internal static string GetKeyName(Guid categoryGuid, string toolName)
        {
            return
              String.Format("SOFTWARE\\Microsoft\\VisualStudio\\" + VisualStudioVersion +
                "\\Generators\\{{{0}}}\\{1}\\", categoryGuid, toolName);
        }

        #endregion

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".sdf";
            return pbstrDefaultExtension.Length;
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, 
            IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            string output = string.Empty;
            bool isError = false;

            try
            {
                if (string.IsNullOrEmpty(wszInputFilePath))
                    throw new Exception("Input file was not specified.");

                if (!File.Exists(wszInputFilePath))
                    throw new Exception("Input file was not found.");


                string sdkFolder = string.Empty;
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(Constants.SdkRegKey))
                {
                    sdkFolder = key.GetValue("InstallationFolder", "") as string;
                }

                if (string.IsNullOrEmpty(sdkFolder))
                    throw new Exception("Could not locate Windows SDK 7.0A install folder.");

                string sdfPath = wszInputFilePath;
                string dbmlPath = Path.ChangeExtension(wszInputFilePath, "dbml");
                string sqlMetalExe = string.Format("{0}\\SqlMetal.exe", sdkFolder);

                if (!File.Exists(sqlMetalExe))
                    throw new Exception("SQLMETAL.EXE was not found.");

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = sqlMetalExe;
                psi.Arguments = string.Format("/dbml:\"{0}\" \"{1}\"", dbmlPath, sdfPath);
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = psi;
                p.Start();

                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                isError = (p.ExitCode != 0);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            if (isError)
            {
                MessageBox.Show(output, "GenerateDbmlFromSdf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                output += "\n\nTool executed successfully !"; 
                MessageBox.Show(output, "GenerateDbmlFromSdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pcbOutput = 0;
            return 0;
        }

        
    }
}
