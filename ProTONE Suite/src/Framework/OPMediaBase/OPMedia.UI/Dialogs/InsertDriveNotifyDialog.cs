using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using System.IO;
using OPMedia.Core;
using OPMedia.UI.Themes;
using System.Diagnostics;

namespace OPMedia.UI.Dialogs
{
    public partial class InsertDriveNotifyDialog : ToolForm
    {
        string _reqLabel, _reqLabelEx;
        DriveType _reqDriveType;
        string _actualDriveLetter;
        string _desc;

        public string ActualDriveLetter
        {
            get
            {
                return _actualDriveLetter;
            }
        }

        public InsertDriveNotifyDialog(string reqLabel, string desc, string reqLabelEx, DriveType reqDriveType) :
            base("TXT_INSERT_DISK")
        {
            _reqLabel = reqLabel;
            _reqLabelEx = reqLabelEx;
            _reqDriveType = reqDriveType;
            _desc = desc;

            InitializeComponent();

            this.Load += new EventHandler(DriveNotifyForm_Load);
        }

        void DriveNotifyForm_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                try
                {
                    if (di.DriveType == _reqDriveType)
                    {
                        if (di.VolumeLabel == _reqLabel &&
                            Kernel32.GetVolumeSerialNumber(di.RootDirectory.FullName) == _reqLabelEx &&
                            di.IsReady)
                        {
                            _actualDriveLetter = di.RootDirectory.FullName;
                            DialogResult = DialogResult.OK;
                            Close();
                            return;
                        }

                        break;
                    }
                }
                catch
                {
                }
            }

            string driveType = _reqDriveType.ToString().ToUpperInvariant().Replace("REMOVABLE", "Floppy / USB / ZIP");

            lblNotifyText.Text = Translator.Translate("TXT_INSERT_MEDIA",
                _reqLabel, _desc, driveType);
        }

        private void tmrRescan_Tick(object sender, EventArgs e)
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                try
                {
                    if (di.DriveType == _reqDriveType &&
                        di.VolumeLabel == _reqLabel &&
                        Kernel32.GetVolumeSerialNumber(di.RootDirectory.FullName) == _reqLabelEx &&
                        di.IsReady)
                    {
                        _actualDriveLetter = di.RootDirectory.FullName;
                        DialogResult = DialogResult.OK;
                        Close();
                        break;
                    }
                }
                catch
                {
                }
            }

        }
    }
}