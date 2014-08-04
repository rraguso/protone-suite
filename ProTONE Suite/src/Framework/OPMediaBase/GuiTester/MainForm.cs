using System;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.Runtime.FileInformation;
using System.Collections.Generic;
using OPMedia.Runtime.ProTONE.FileInformation;

namespace GuiTester
{
    public partial class MainForm : MainFrame
    {
        public MainForm() : base("OPMedia GUI Playground Application")
        {
            InitializeComponent();

            this.Load += new EventHandler(MainForm_Load);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
