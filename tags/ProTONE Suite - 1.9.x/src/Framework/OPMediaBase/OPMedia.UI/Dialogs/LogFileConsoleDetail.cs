using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;

namespace OPMedia.UI.Dialogs
{
    public partial class LogFileConsoleDetail : ThemeForm
    {
        public LogFileConsoleDetail(string details) : 
            base("TXT_ERROR")
        {
            base.IsToolWindow = true;
            InitializeComponent();
            txtDetails.Text = details;
        }
    }
}
