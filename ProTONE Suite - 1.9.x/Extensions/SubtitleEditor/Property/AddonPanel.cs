using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Prop;
using OPMedia.UI.ProTONE.SubtitleDownload;
using OPMedia.UI.Controls;
using OPMedia.Runtime.ProTONE.SubtitleDownload;
using SubtitleEditor.extension.DataLayer;
using OPMedia.Core.ApplicationSettings;
using System.IO;

namespace SubtitleEditor.Property
{
    public partial class AddonPanel : PropBaseCtl
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox rtbContents;
        private OPMTimePicker tpStartTime;
        private OPMTimePicker tpEndTime;
        private OPMTimePicker tpDuration;
        private TableLayoutPanel tableLayoutPanel1;
    
        public AddonPanel()
        {
            InitializeComponent();
        }

        public override List<string> HandledFileTypes
        { get { return SubtitleDownloader.AllowedSubtitleExtensions; } }

        public override bool CanHandleFolders
        { get { return false; } }

        public override int MaximumHandledItems
        { get { return 1; } }

        SubtitleElement _elem = null;

        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            _elem = additionalData as SubtitleElement;
            if (_elem != null)
            {
                tpStartTime.Value = _elem.StartTime;
                tpEndTime.Value = _elem.EndTime;
                tpDuration.Value = (_elem.EndTime.Subtract(_elem.StartTime));

                string rtf = _elem.RtfDisplay;
                try
                {
                    rtbContents.Rtf = rtf;
                }
                catch
                {
                    rtbContents.Text = rtf;
                }

            }
        }

        public override void SaveProperties()
        {
            if (_elem != null)
            {
                _elem.RtfDisplay = rtbContents.Rtf;
            }
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbContents = new System.Windows.Forms.RichTextBox();
            this.tpStartTime = new OPMedia.UI.Controls.OPMTimePicker();
            this.tpEndTime = new OPMedia.UI.Controls.OPMTimePicker();
            this.tpDuration = new OPMedia.UI.Controls.OPMTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.rtbContents, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tpStartTime, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tpEndTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tpDuration, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 331);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_START_TIME";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TXT_END_TIME";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "TXT_DURATION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "TXT_CONTENTS";
            // 
            // rtbContents
            // 
            this.rtbContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.rtbContents, 2);
            this.rtbContents.DetectUrls = false;
            this.rtbContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContents.Location = new System.Drawing.Point(96, 150);
            this.rtbContents.Name = "rtbContents";
            this.rtbContents.ShortcutsEnabled = false;
            this.rtbContents.Size = new System.Drawing.Size(228, 113);
            this.rtbContents.TabIndex = 7;
            this.rtbContents.Text = "";
            this.rtbContents.TextChanged += new System.EventHandler(this.rtbContents_TextChanged);
            // 
            // tpStartTime
            // 
            this.tpStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpStartTime.Hours = 0;
            this.tpStartTime.Location = new System.Drawing.Point(97, 4);
            this.tpStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.tpStartTime.MaximumSize = new System.Drawing.Size(85, 21);
            this.tpStartTime.Milliseconds = 0;
            this.tpStartTime.MinimumSize = new System.Drawing.Size(85, 21);
            this.tpStartTime.Minutes = 0;
            this.tpStartTime.Name = "tpStartTime";
            this.tpStartTime.Seconds = 0;
            this.tpStartTime.Size = new System.Drawing.Size(85, 21);
            this.tpStartTime.TabIndex = 8;
            this.tpStartTime.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // tpEndTime
            // 
            this.tpEndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpEndTime.Hours = 0;
            this.tpEndTime.Location = new System.Drawing.Point(97, 53);
            this.tpEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.tpEndTime.MaximumSize = new System.Drawing.Size(85, 21);
            this.tpEndTime.Milliseconds = 0;
            this.tpEndTime.MinimumSize = new System.Drawing.Size(85, 21);
            this.tpEndTime.Minutes = 0;
            this.tpEndTime.Name = "tpEndTime";
            this.tpEndTime.Seconds = 0;
            this.tpEndTime.Size = new System.Drawing.Size(85, 21);
            this.tpEndTime.TabIndex = 9;
            this.tpEndTime.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // tpDuration
            // 
            this.tpDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpDuration.Hours = 0;
            this.tpDuration.Location = new System.Drawing.Point(97, 102);
            this.tpDuration.Margin = new System.Windows.Forms.Padding(4);
            this.tpDuration.MaximumSize = new System.Drawing.Size(85, 21);
            this.tpDuration.Milliseconds = 0;
            this.tpDuration.MinimumSize = new System.Drawing.Size(85, 21);
            this.tpDuration.Minutes = 0;
            this.tpDuration.Name = "tpDuration";
            this.tpDuration.Seconds = 0;
            this.tpDuration.Size = new System.Drawing.Size(85, 21);
            this.tpDuration.TabIndex = 10;
            this.tpDuration.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // AddonPanel
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(327, 331);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        void rtbContents_TextChanged(object sender, EventArgs e)
        {
            this.Modified = true;
        }
    }
}
