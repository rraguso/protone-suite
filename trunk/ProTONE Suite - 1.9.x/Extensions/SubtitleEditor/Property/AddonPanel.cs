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

using OPMedia.UI.Themes;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Generic;
using OPMedia.Core;
using OPMedia.Core.GlobalEvents;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using SubtitleEditor.Rendering;

namespace SubtitleEditor.Property
{
    public class AddonPanel : PropBaseCtl
    {
        private OPMLabel label1;
        private OPMLabel label2;
        private OPMLabel label3;
        private OPMLabel label4;
        private RichTextBox rtbContents;
        private OPMTimePicker tpStartTime;
        private OPMTimePicker tpEndTime;
        private OPMTimePicker tpDuration;
        private OPMLabel label5;
        private OPMTextBox tbContents;
        private OPMToolStrip opmToolStrip1;
        private OPMToolStripButton btnBold;
        private OPMToolStripButton btnItalic;
        private OPMToolStripButton btnUnderlined;
        private OPMToolStripButton btnColor;
        private OPMToolStripButton btnStrikethrough;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private OPMButton btnUndo;
        private OPMButton btnSave;
        private OPMButton btnStartNow;
        private OPMButton btnEndNow;
        private ToolTip toolTip1;
        private IContainer components;
        private OPMTableLayoutPanel tableLayoutPanel1;

        public AddonPanel()
        {
            InitializeComponent();
            btnColor.Image = OPMedia.UI.Properties.Resources.Colors.ToBitmap();

            rtbContents.Font = AppSettings.SubFont;
            rtbContents.BackColor = Color.Black;
            rtbContents.ForeColor = AppSettings.SubColor;

            btnStartNow.Image = btnEndNow.Image = ImageProvider.ScaleImage(OPMedia.Core.Properties.Resources.Clock.ToBitmap(),
                new Size(16, 16), true);

            btnStartNow.Enabled = btnEndNow.Enabled = false;

            if (!DesignMode)
            {
                MediaRendererInstance.Instance.MediaRendererClock += new MediaRendererEventHandler(OnMediaRendererClock);
            }
        }

        public void OnMediaRendererClock()
        {
            btnStartNow.Enabled = btnEndNow.Enabled =
                (MediaRenderer.DefaultInstance.MediaState == MediaState.Paused ||
                    MediaRenderer.DefaultInstance.MediaState == MediaState.Playing);
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
            Translator.TranslateControl(this, DesignMode);

            try
            {
                tbContents.TextChanged -= new EventHandler(OnContentsChanged);
                tpStartTime.OnValueChanged -= new EventHandler(OnStartTimeChanged);
                tpEndTime.OnValueChanged -= new EventHandler(OnEndTimeChanged);
                tpDuration.OnValueChanged -= new EventHandler(OnDurationChanged);

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

                    tbContents.Lines = _elem.Lines.ToArray();
                }
            }
            finally
            {
                tbContents.TextChanged += new EventHandler(OnContentsChanged);
                tpStartTime.OnValueChanged += new EventHandler(OnStartTimeChanged);
                tpEndTime.OnValueChanged += new EventHandler(OnEndTimeChanged);
                tpDuration.OnValueChanged += new EventHandler(OnDurationChanged);

                base.Modified = false;
            }
        }

        #region Event handlers

        void OnStartTimeChanged(object sender, EventArgs e)
        {
            tpDuration.Value = tpEndTime.Value.Subtract(tpStartTime.Value);
            OnPropertyChanged(sender, e);
        }

        void OnEndTimeChanged(object sender, EventArgs e)
        {
            tpDuration.Value = tpEndTime.Value.Subtract(tpStartTime.Value);
            OnPropertyChanged(sender, e);
        }

        void OnDurationChanged(object sender, EventArgs e)
        {
            tpEndTime.Value = tpStartTime.Value.Add(tpDuration.Value);
            OnPropertyChanged(sender, e);
        }

        void OnContentsChanged(object sender, EventArgs e)
        {
            string rtf = SubtitleBase.GenerateRtf(tbContents.Text);
            try
            {
                rtbContents.Rtf = rtf;
            }
            catch
            {
                rtbContents.Text = rtf;
            }
            
            OnPropertyChanged(sender, e);
        }

        void OnPropertyChanged(object sender, EventArgs e)
        {
            base.Modified = true;
        }

        #endregion

        public override void SaveProperties()
        {
            if (_elem != null)
            {
                _elem.Lines = new List<string>(tbContents.Lines);
            }
        }

        #region Auto-generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddonPanel));
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.tbContents = new OPMedia.UI.Controls.OPMTextBox();
            this.opmToolStrip1 = new OPMedia.UI.Controls.OPMToolStrip();
            this.btnBold = new OPMedia.UI.Controls.OPMToolStripButton();
            this.btnItalic = new OPMedia.UI.Controls.OPMToolStripButton();
            this.btnUnderlined = new OPMedia.UI.Controls.OPMToolStripButton();
            this.btnStrikethrough = new OPMedia.UI.Controls.OPMToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbContents = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new OPMedia.UI.Controls.OPMButton();
            this.btnUndo = new OPMedia.UI.Controls.OPMButton();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.label3 = new OPMedia.UI.Controls.OPMLabel();
            this.tpStartTime = new OPMedia.UI.Controls.OPMTimePicker();
            this.tpEndTime = new OPMedia.UI.Controls.OPMTimePicker();
            this.tpDuration = new OPMedia.UI.Controls.OPMTimePicker();
            this.label4 = new OPMedia.UI.Controls.OPMLabel();
            this.label5 = new OPMedia.UI.Controls.OPMLabel();
            this.btnStartNow = new OPMedia.UI.Controls.OPMButton();
            this.btnEndNow = new OPMedia.UI.Controls.OPMButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnColor = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.opmToolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbContents, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.opmToolStrip1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStartNow, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 8);
            this.tableLayoutPanel1.Controls.Add(this.tpStartTime, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tpEndTime, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.tpDuration, 6, 9);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnEndNow, 4, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 390);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbContents
            // 
            this.tbContents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.tbContents, 8);
            this.tbContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContents.Location = new System.Drawing.Point(3, 48);
            this.tbContents.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tbContents.Multiline = true;
            this.tbContents.Name = "tbContents";
            this.tbContents.OverrideForeColor = System.Drawing.Color.Empty;
            this.tbContents.Size = new System.Drawing.Size(359, 120);
            this.tbContents.TabIndex = 3;
            // 
            // opmToolStrip1
            // 
            this.opmToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(216)))), ((int)(((byte)(235)))));
            this.tableLayoutPanel1.SetColumnSpan(this.opmToolStrip1, 8);
            this.opmToolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.opmToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBold,
            this.btnItalic,
            this.btnUnderlined,
            this.btnStrikethrough,
            this.btnColor});
            this.opmToolStrip1.Location = new System.Drawing.Point(3, 23);
            this.opmToolStrip1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opmToolStrip1.Name = "opmToolStrip1";
            this.opmToolStrip1.ShowBorder = true;
            this.opmToolStrip1.Size = new System.Drawing.Size(359, 25);
            this.opmToolStrip1.TabIndex = 2;
            this.opmToolStrip1.Text = "opmToolStrip1";
            this.opmToolStrip1.VerticalGradient = true;
            // 
            // btnBold
            // 
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBold.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 22);
            this.btnBold.Text = "B";
            // 
            // btnItalic
            // 
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnItalic.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 22);
            this.btnItalic.Text = "I";
            // 
            // btnUnderlined
            // 
            this.btnUnderlined.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUnderlined.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Underline);
            this.btnUnderlined.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderlined.Name = "btnUnderlined";
            this.btnUnderlined.Size = new System.Drawing.Size(23, 22);
            this.btnUnderlined.Text = "U";
            // 
            // btnStrikethrough
            // 
            this.btnStrikethrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStrikethrough.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Strikeout);
            this.btnStrikethrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStrikethrough.Name = "btnStrikethrough";
            this.btnStrikethrough.Size = new System.Drawing.Size(23, 22);
            this.btnStrikethrough.Text = "S";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 8);
            this.panel1.Controls.Add(this.rtbContents);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 110);
            this.panel1.TabIndex = 14;
            // 
            // rtbContents
            // 
            this.rtbContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContents.DetectUrls = false;
            this.rtbContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContents.Location = new System.Drawing.Point(0, 0);
            this.rtbContents.Name = "rtbContents";
            this.rtbContents.ReadOnly = true;
            this.rtbContents.ShortcutsEnabled = false;
            this.rtbContents.Size = new System.Drawing.Size(357, 108);
            this.rtbContents.TabIndex = 0;
            this.rtbContents.Text = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 8);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnUndo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 356);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(362, 24);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnSave.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(72, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "TXT_APPLY";
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(84, 0);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnUndo.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnUndo.Size = new System.Drawing.Size(72, 24);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "TXT_UNDO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 304);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TXT_START_TIME";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(129, 304);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "TXT_END_TIME";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(255, 304);
            this.label3.Name = "label3";
            this.label3.OverrideBackColor = System.Drawing.Color.Empty;
            this.label3.OverrideForeColor = System.Drawing.Color.Empty;
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "TXT_DURATION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpStartTime
            // 
            this.tpStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpStartTime.Hours = 0;
            this.tpStartTime.Location = new System.Drawing.Point(4, 321);
            this.tpStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.tpStartTime.MaximumSize = new System.Drawing.Size(85, 21);
            this.tpStartTime.Milliseconds = 0;
            this.tpStartTime.MinimumSize = new System.Drawing.Size(85, 21);
            this.tpStartTime.Minutes = 0;
            this.tpStartTime.Name = "tpStartTime";
            this.tpStartTime.Seconds = 0;
            this.tpStartTime.Size = new System.Drawing.Size(85, 21);
            this.tpStartTime.TabIndex = 6;
            this.tpStartTime.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // tpEndTime
            // 
            this.tpEndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpEndTime.Hours = 0;
            this.tpEndTime.Location = new System.Drawing.Point(130, 321);
            this.tpEndTime.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.tpEndTime.MaximumSize = new System.Drawing.Size(85, 21);
            this.tpEndTime.Milliseconds = 0;
            this.tpEndTime.MinimumSize = new System.Drawing.Size(85, 21);
            this.tpEndTime.Minutes = 0;
            this.tpEndTime.Name = "tpEndTime";
            this.tpEndTime.Seconds = 0;
            this.tpEndTime.Size = new System.Drawing.Size(85, 21);
            this.tpEndTime.TabIndex = 8;
            this.tpEndTime.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // tpDuration
            // 
            this.tpDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpDuration.Hours = 0;
            this.tpDuration.Location = new System.Drawing.Point(256, 321);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 4);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.OverrideBackColor = System.Drawing.Color.Empty;
            this.label4.OverrideForeColor = System.Drawing.Color.Empty;
            this.label4.Size = new System.Drawing.Size(209, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "TXT_EDIT_CONTENTS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 4);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Location = new System.Drawing.Point(3, 178);
            this.label5.Name = "label5";
            this.label5.OverrideBackColor = System.Drawing.Color.Empty;
            this.label5.OverrideForeColor = System.Drawing.Color.Empty;
            this.label5.Size = new System.Drawing.Size(209, 10);
            this.label5.TabIndex = 4;
            this.label5.Text = "TXT_CONTENTS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStartNow
            // 
            this.btnStartNow.AutoSize = true;
            this.btnStartNow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartNow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartNow.Location = new System.Drawing.Point(90, 321);
            this.btnStartNow.Margin = new System.Windows.Forms.Padding(1, 4, 0, 0);
            this.btnStartNow.MaximumSize = new System.Drawing.Size(21, 21);
            this.btnStartNow.MinimumSize = new System.Drawing.Size(21, 21);
            this.btnStartNow.Name = "btnStartNow";
            this.btnStartNow.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnStartNow.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnStartNow.Size = new System.Drawing.Size(21, 21);
            this.btnStartNow.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnStartNow, "Use current playback time as start time");
            // 
            // btnEndNow
            // 
            this.btnEndNow.AutoSize = true;
            this.btnEndNow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEndNow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEndNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndNow.Location = new System.Drawing.Point(216, 321);
            this.btnEndNow.Margin = new System.Windows.Forms.Padding(1, 4, 0, 0);
            this.btnEndNow.MaximumSize = new System.Drawing.Size(21, 21);
            this.btnEndNow.MinimumSize = new System.Drawing.Size(21, 21);
            this.btnEndNow.Name = "btnEndNow";
            this.btnEndNow.OverrideBackColor = System.Drawing.Color.Empty;
            this.btnEndNow.OverrideForeColor = System.Drawing.Color.Empty;
            this.btnEndNow.Size = new System.Drawing.Size(21, 21);
            this.btnEndNow.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnEndNow, "Use current playback time as end time");
            // 
            // btnColor
            // 
            this.btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColor.Image = ((System.Drawing.Image)(resources.GetObject("btnColor.Image")));
            this.btnColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(23, 22);
            this.btnColor.Text = " ";
            // 
            // AddonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(340, 400);
            this.Name = "AddonPanel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(375, 400);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.opmToolStrip1.ResumeLayout(false);
            this.opmToolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
