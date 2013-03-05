using OPMedia.UI.Controls;
using System.Windows.Forms;

namespace OPMedia.UI.ProTONE.Configuration
{
    partial class SchedulerSettingsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wsScheduledEvtDays = new OPMedia.UI.Controls.WeekdaySelector();
            this.grpPlaylistEvt = new OPMedia.UI.Controls.OPMCustomPanel();
            this.opmLayoutPanel3 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.cmbPlaylistEvtHandler = new OPMedia.UI.Controls.OPMComboBox();
            this.psiPlaylistEvtData = new OPMedia.UI.Controls.ProgramStartupInfoCtl();
            this.chkEnablePlaylistEvt = new OPMedia.UI.Controls.OPMCheckBox();
            this.grpScheduledEvt = new OPMedia.UI.Controls.OPMCustomPanel();
            this.opmLayoutPanel4 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.psiScheduledEvtData = new OPMedia.UI.Controls.ProgramStartupInfoCtl();
            this.cmbScheduledEvtHandler = new OPMedia.UI.Controls.OPMComboBox();
            this.label3 = new OPMedia.UI.Controls.OPMLabel();
            this.label2 = new OPMedia.UI.Controls.OPMLabel();
            this.dtpScheduledEvtTime = new OPMedia.UI.Controls.OPMDateTimePicker();
            this.label4 = new OPMedia.UI.Controls.OPMLabel();
            this.chkEnableScheduledEvt = new OPMedia.UI.Controls.OPMCheckBox();
            this.label5 = new OPMedia.UI.Controls.OPMLabel();
            this.nudSchedulerWaitTimerProceed = new OPMedia.UI.Controls.OPMNumericUpDown();
            this.opmLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lblSep1 = new OPMedia.UI.Controls.OPMLabel();
            this.opmTableLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.lblSep2 = new OPMedia.UI.Controls.OPMLabel();
            this.lblSep3 = new OPMedia.UI.Controls.OPMLabel();
            this.opmLayoutPanel2 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.grpPlaylistEvt.SuspendLayout();
            this.opmLayoutPanel3.SuspendLayout();
            this.grpScheduledEvt.SuspendLayout();
            this.opmLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchedulerWaitTimerProceed)).BeginInit();
            this.opmLayoutPanel1.SuspendLayout();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.opmTableLayoutPanel2.SuspendLayout();
            this.opmLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wsScheduledEvtDays
            // 
            this.wsScheduledEvtDays.AutoSize = true;
            this.wsScheduledEvtDays.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wsScheduledEvtDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wsScheduledEvtDays.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.wsScheduledEvtDays.Location = new System.Drawing.Point(8, 36);
            this.wsScheduledEvtDays.MaximumSize = new System.Drawing.Size(4270, 50);
            this.wsScheduledEvtDays.MinimumSize = new System.Drawing.Size(400, 45);
            this.wsScheduledEvtDays.Name = "wsScheduledEvtDays";
            this.wsScheduledEvtDays.OverrideBackColor = System.Drawing.Color.Empty;
            this.wsScheduledEvtDays.Size = new System.Drawing.Size(400, 46);
            this.wsScheduledEvtDays.TabIndex = 3;
            // 
            // grpPlaylistEvt
            // 
            this.grpPlaylistEvt.AutoSize = true;
            this.grpPlaylistEvt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpPlaylistEvt.BaseColor = System.Drawing.Color.Empty;
            this.grpPlaylistEvt.BorderWidth = 0;
            this.grpPlaylistEvt.Controls.Add(this.opmLayoutPanel3);
            this.grpPlaylistEvt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlaylistEvt.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.grpPlaylistEvt.HasBorder = true;
            this.grpPlaylistEvt.Highlight = false;
            this.grpPlaylistEvt.Location = new System.Drawing.Point(0, 20);
            this.grpPlaylistEvt.Margin = new System.Windows.Forms.Padding(0);
            this.grpPlaylistEvt.Name = "grpPlaylistEvt";
            this.grpPlaylistEvt.OverrideBackColor = System.Drawing.Color.Empty;
            this.grpPlaylistEvt.Size = new System.Drawing.Size(535, 71);
            this.grpPlaylistEvt.TabIndex = 1;
            this.grpPlaylistEvt.TabStop = false;
            // 
            // opmLayoutPanel3
            // 
            this.opmLayoutPanel3.AutoSize = true;
            this.opmLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmLayoutPanel3.ColumnCount = 4;
            this.opmLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel3.Controls.Add(this.label1, 1, 1);
            this.opmLayoutPanel3.Controls.Add(this.cmbPlaylistEvtHandler, 2, 1);
            this.opmLayoutPanel3.Controls.Add(this.psiPlaylistEvtData, 1, 2);
            this.opmLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.opmLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.opmLayoutPanel3.Name = "opmLayoutPanel3";
            this.opmLayoutPanel3.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel3.RowCount = 4;
            this.opmLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel3.Size = new System.Drawing.Size(535, 71);
            this.opmLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(351, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_PLAYLISTEVT_DESC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPlaylistEvtHandler
            // 
            this.cmbPlaylistEvtHandler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPlaylistEvtHandler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbPlaylistEvtHandler.FormattingEnabled = true;
            this.cmbPlaylistEvtHandler.Location = new System.Drawing.Point(356, 5);
            this.cmbPlaylistEvtHandler.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPlaylistEvtHandler.Name = "cmbPlaylistEvtHandler";
            this.cmbPlaylistEvtHandler.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbPlaylistEvtHandler.Size = new System.Drawing.Size(174, 23);
            this.cmbPlaylistEvtHandler.TabIndex = 1;
            // 
            // psiPlaylistEvtData
            // 
            this.psiPlaylistEvtData.AutoSize = true;
            this.psiPlaylistEvtData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmLayoutPanel3.SetColumnSpan(this.psiPlaylistEvtData, 2);
            this.psiPlaylistEvtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.psiPlaylistEvtData.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.psiPlaylistEvtData.Location = new System.Drawing.Point(8, 37);
            this.psiPlaylistEvtData.Name = "psiPlaylistEvtData";
            this.psiPlaylistEvtData.OverrideBackColor = System.Drawing.Color.Empty;
            this.psiPlaylistEvtData.Size = new System.Drawing.Size(519, 26);
            this.psiPlaylistEvtData.TabIndex = 2;
            // 
            // chkEnablePlaylistEvt
            // 
            this.chkEnablePlaylistEvt.AutoSize = true;
            this.chkEnablePlaylistEvt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnablePlaylistEvt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnablePlaylistEvt.Location = new System.Drawing.Point(3, 3);
            this.chkEnablePlaylistEvt.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.chkEnablePlaylistEvt.Name = "chkEnablePlaylistEvt";
            this.chkEnablePlaylistEvt.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkEnablePlaylistEvt.Size = new System.Drawing.Size(148, 17);
            this.chkEnablePlaylistEvt.TabIndex = 0;
            this.chkEnablePlaylistEvt.Text = "TXT_ENABLE_PLAYLISTEVT";
            // 
            // grpScheduledEvt
            // 
            this.grpScheduledEvt.AutoSize = true;
            this.grpScheduledEvt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpScheduledEvt.BaseColor = System.Drawing.Color.Empty;
            this.grpScheduledEvt.BorderWidth = 0;
            this.grpScheduledEvt.Controls.Add(this.opmLayoutPanel4);
            this.grpScheduledEvt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpScheduledEvt.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.grpScheduledEvt.HasBorder = true;
            this.grpScheduledEvt.Highlight = false;
            this.grpScheduledEvt.Location = new System.Drawing.Point(0, 111);
            this.grpScheduledEvt.Margin = new System.Windows.Forms.Padding(0);
            this.grpScheduledEvt.Name = "grpScheduledEvt";
            this.grpScheduledEvt.OverrideBackColor = System.Drawing.Color.Empty;
            this.grpScheduledEvt.Size = new System.Drawing.Size(535, 145);
            this.grpScheduledEvt.TabIndex = 3;
            this.grpScheduledEvt.TabStop = false;
            // 
            // opmLayoutPanel4
            // 
            this.opmLayoutPanel4.AutoSize = true;
            this.opmLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmLayoutPanel4.ColumnCount = 5;
            this.opmLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel4.Controls.Add(this.psiScheduledEvtData, 1, 4);
            this.opmLayoutPanel4.Controls.Add(this.cmbScheduledEvtHandler, 3, 3);
            this.opmLayoutPanel4.Controls.Add(this.label3, 1, 1);
            this.opmLayoutPanel4.Controls.Add(this.label2, 1, 3);
            this.opmLayoutPanel4.Controls.Add(this.dtpScheduledEvtTime, 2, 1);
            this.opmLayoutPanel4.Controls.Add(this.wsScheduledEvtDays, 1, 2);
            this.opmLayoutPanel4.Controls.Add(this.label4, 3, 1);
            this.opmLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.opmLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel4.Name = "opmLayoutPanel4";
            this.opmLayoutPanel4.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel4.RowCount = 6;
            this.opmLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.opmLayoutPanel4.Size = new System.Drawing.Size(535, 145);
            this.opmLayoutPanel4.TabIndex = 0;
            // 
            // psiScheduledEvtData
            // 
            this.psiScheduledEvtData.AutoSize = true;
            this.psiScheduledEvtData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmLayoutPanel4.SetColumnSpan(this.psiScheduledEvtData, 3);
            this.psiScheduledEvtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.psiScheduledEvtData.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.psiScheduledEvtData.Location = new System.Drawing.Point(8, 111);
            this.psiScheduledEvtData.Name = "psiScheduledEvtData";
            this.psiScheduledEvtData.OverrideBackColor = System.Drawing.Color.Empty;
            this.psiScheduledEvtData.Size = new System.Drawing.Size(519, 26);
            this.psiScheduledEvtData.TabIndex = 6;
            // 
            // cmbScheduledEvtHandler
            // 
            this.cmbScheduledEvtHandler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbScheduledEvtHandler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbScheduledEvtHandler.FormattingEnabled = true;
            this.cmbScheduledEvtHandler.Location = new System.Drawing.Point(350, 85);
            this.cmbScheduledEvtHandler.Margin = new System.Windows.Forms.Padding(0);
            this.cmbScheduledEvtHandler.Name = "cmbScheduledEvtHandler";
            this.cmbScheduledEvtHandler.OverrideForeColor = System.Drawing.Color.Empty;
            this.cmbScheduledEvtHandler.Size = new System.Drawing.Size(180, 23);
            this.cmbScheduledEvtHandler.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(8, 5);
            this.label3.Name = "label3";
            this.label3.OverrideBackColor = System.Drawing.Color.Empty;
            this.label3.OverrideForeColor = System.Drawing.Color.Empty;
            this.label3.Size = new System.Drawing.Size(249, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "TXT_SCHEDULEDEVT_TIME";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.opmLayoutPanel4.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.OverrideBackColor = System.Drawing.Color.Empty;
            this.label2.OverrideForeColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(339, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "TXT_SCHEDULEDEVT_DESC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpScheduledEvtTime
            // 
            this.dtpScheduledEvtTime.CustomFormat = "HH:mm:ss";
            this.dtpScheduledEvtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduledEvtTime.Location = new System.Drawing.Point(263, 8);
            this.dtpScheduledEvtTime.Name = "dtpScheduledEvtTime";
            this.dtpScheduledEvtTime.ShowUpDown = true;
            this.dtpScheduledEvtTime.Size = new System.Drawing.Size(84, 22);
            this.dtpScheduledEvtTime.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(353, 5);
            this.label4.Name = "label4";
            this.label4.OverrideBackColor = System.Drawing.Color.Empty;
            this.label4.OverrideForeColor = System.Drawing.Color.Empty;
            this.label4.Size = new System.Drawing.Size(174, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "TXT_ONDAYS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnableScheduledEvt
            // 
            this.chkEnableScheduledEvt.AutoSize = true;
            this.chkEnableScheduledEvt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnableScheduledEvt.Location = new System.Drawing.Point(3, 3);
            this.chkEnableScheduledEvt.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.chkEnableScheduledEvt.Name = "chkEnableScheduledEvt";
            this.chkEnableScheduledEvt.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkEnableScheduledEvt.Size = new System.Drawing.Size(168, 17);
            this.chkEnableScheduledEvt.TabIndex = 0;
            this.chkEnableScheduledEvt.Text = "TXT_ENABLE_SCHEDULEDEVT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.OverrideBackColor = System.Drawing.Color.Empty;
            this.label5.OverrideForeColor = System.Drawing.Color.Empty;
            this.label5.Size = new System.Drawing.Size(483, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "TXT_SCHEDULERWAITTIMERPROCEED";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudSchedulerWaitTimerProceed
            // 
            this.nudSchedulerWaitTimerProceed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudSchedulerWaitTimerProceed.Location = new System.Drawing.Point(489, 0);
            this.nudSchedulerWaitTimerProceed.Margin = new System.Windows.Forms.Padding(0);
            this.nudSchedulerWaitTimerProceed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSchedulerWaitTimerProceed.Name = "nudSchedulerWaitTimerProceed";
            this.nudSchedulerWaitTimerProceed.ReadOnly = true;
            this.nudSchedulerWaitTimerProceed.Size = new System.Drawing.Size(46, 22);
            this.nudSchedulerWaitTimerProceed.TabIndex = 1;
            this.nudSchedulerWaitTimerProceed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSchedulerWaitTimerProceed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSchedulerWaitTimerProceed.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // opmLayoutPanel1
            // 
            this.opmLayoutPanel1.ColumnCount = 1;
            this.opmLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.Controls.Add(this.opmTableLayoutPanel1, 0, 0);
            this.opmLayoutPanel1.Controls.Add(this.grpPlaylistEvt, 0, 1);
            this.opmLayoutPanel1.Controls.Add(this.opmTableLayoutPanel2, 0, 2);
            this.opmLayoutPanel1.Controls.Add(this.grpScheduledEvt, 0, 3);
            this.opmLayoutPanel1.Controls.Add(this.lblSep3, 0, 4);
            this.opmLayoutPanel1.Controls.Add(this.opmLayoutPanel2, 0, 5);
            this.opmLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmLayoutPanel1.Name = "opmLayoutPanel1";
            this.opmLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel1.RowCount = 7;
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel1.Size = new System.Drawing.Size(535, 354);
            this.opmLayoutPanel1.TabIndex = 6;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.AutoSize = true;
            this.opmTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel1.ColumnCount = 2;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.chkEnablePlaylistEvt, 0, 0);
            this.opmTableLayoutPanel1.Controls.Add(this.lblSep1, 1, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.RowCount = 1;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(535, 20);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // lblSep1
            // 
            this.lblSep1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSep1.Location = new System.Drawing.Point(151, 12);
            this.lblSep1.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblSep1.Name = "lblSep1";
            this.lblSep1.OverrideBackColor = System.Drawing.Color.White;
            this.lblSep1.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblSep1.Size = new System.Drawing.Size(384, 1);
            this.lblSep1.TabIndex = 1;
            this.lblSep1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmTableLayoutPanel2
            // 
            this.opmTableLayoutPanel2.AutoSize = true;
            this.opmTableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmTableLayoutPanel2.ColumnCount = 2;
            this.opmTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel2.Controls.Add(this.lblSep2, 1, 0);
            this.opmTableLayoutPanel2.Controls.Add(this.chkEnableScheduledEvt, 0, 0);
            this.opmTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel2.Location = new System.Drawing.Point(0, 91);
            this.opmTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.opmTableLayoutPanel2.Name = "opmTableLayoutPanel2";
            this.opmTableLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel2.RowCount = 1;
            this.opmTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel2.Size = new System.Drawing.Size(535, 20);
            this.opmTableLayoutPanel2.TabIndex = 2;
            // 
            // lblSep2
            // 
            this.lblSep2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSep2.Location = new System.Drawing.Point(171, 12);
            this.lblSep2.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblSep2.Name = "lblSep2";
            this.lblSep2.OverrideBackColor = System.Drawing.Color.White;
            this.lblSep2.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblSep2.Size = new System.Drawing.Size(364, 1);
            this.lblSep2.TabIndex = 1;
            this.lblSep2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSep3
            // 
            this.lblSep3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSep3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSep3.Location = new System.Drawing.Point(0, 266);
            this.lblSep3.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSep3.Name = "lblSep3";
            this.lblSep3.OverrideBackColor = System.Drawing.Color.White;
            this.lblSep3.OverrideForeColor = System.Drawing.Color.Empty;
            this.lblSep3.Size = new System.Drawing.Size(535, 1);
            this.lblSep3.TabIndex = 4;
            this.lblSep3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opmLayoutPanel2
            // 
            this.opmLayoutPanel2.AutoSize = true;
            this.opmLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.opmLayoutPanel2.ColumnCount = 2;
            this.opmLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.opmLayoutPanel2.Controls.Add(this.nudSchedulerWaitTimerProceed, 1, 0);
            this.opmLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.opmLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmLayoutPanel2.Location = new System.Drawing.Point(0, 276);
            this.opmLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.opmLayoutPanel2.Name = "opmLayoutPanel2";
            this.opmLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmLayoutPanel2.RowCount = 1;
            this.opmLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.opmLayoutPanel2.Size = new System.Drawing.Size(535, 22);
            this.opmLayoutPanel2.TabIndex = 5;
            // 
            // SchedulerSettingsPanel
            // 
            this.Controls.Add(this.opmLayoutPanel1);
            this.Name = "SchedulerSettingsPanel";
            this.Size = new System.Drawing.Size(535, 354);
            this.grpPlaylistEvt.ResumeLayout(false);
            this.grpPlaylistEvt.PerformLayout();
            this.opmLayoutPanel3.ResumeLayout(false);
            this.opmLayoutPanel3.PerformLayout();
            this.grpScheduledEvt.ResumeLayout(false);
            this.grpScheduledEvt.PerformLayout();
            this.opmLayoutPanel4.ResumeLayout(false);
            this.opmLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchedulerWaitTimerProceed)).EndInit();
            this.opmLayoutPanel1.ResumeLayout(false);
            this.opmLayoutPanel1.PerformLayout();
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.opmTableLayoutPanel1.PerformLayout();
            this.opmTableLayoutPanel2.ResumeLayout(false);
            this.opmTableLayoutPanel2.PerformLayout();
            this.opmLayoutPanel2.ResumeLayout(false);
            this.opmLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WeekdaySelector wsScheduledEvtDays;
        private OPMCustomPanel grpPlaylistEvt;
        private OPMCheckBox chkEnablePlaylistEvt;
        private OPMLabel label1;
        private OPMComboBox cmbPlaylistEvtHandler;
        private OPMCustomPanel grpScheduledEvt;
        private ProgramStartupInfoCtl psiScheduledEvtData;
        private OPMComboBox cmbScheduledEvtHandler;
        private OPMLabel label2;
        private OPMLabel label3;
        private OPMLabel label4;
        private OPMDateTimePicker dtpScheduledEvtTime;
        private OPMCheckBox chkEnableScheduledEvt;
        private OPMLabel label5;
        private OPMNumericUpDown nudSchedulerWaitTimerProceed;
        private ProgramStartupInfoCtl psiPlaylistEvtData;
        private OPMTableLayoutPanel opmLayoutPanel1;
        private OPMTableLayoutPanel opmLayoutPanel2;
        private OPMTableLayoutPanel opmLayoutPanel3;
        private OPMTableLayoutPanel opmLayoutPanel4;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMLabel lblSep1;
        private OPMTableLayoutPanel opmTableLayoutPanel2;
        private OPMLabel lblSep2;
        private OPMLabel lblSep3;
    }
}
