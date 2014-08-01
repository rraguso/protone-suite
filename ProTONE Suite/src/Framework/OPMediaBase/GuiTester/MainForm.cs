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
            //NativeFileInfo nfi1 = new NativeFileInfo("d:\\UA5200_Numbers.bak", false);
            NativeFileInfo nfi2 = new ID3FileInfo("d:\\Atb - Sunburn.mp3", true);

            peDisplay.DisplayProperties(new List<object> { nfi2 });
        }
    }
}
