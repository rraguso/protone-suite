using OPMedia.UI.Controls;
using System.Drawing;

namespace OPMedia.UI.Dialogs
{
    partial class LogFileConsoleDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvLogLines = new OPMedia.UI.Controls.OPMListView();
            this.hdrEntryType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrTimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrTID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsMain = new OPMedia.UI.Controls.OPMToolStrip();
            this.lblLogFileName = new System.Windows.Forms.ToolStripLabel();
            this.cmbLogFileNames = new System.Windows.Forms.ToolStripComboBox();
            this.lblLogLineCount = new System.Windows.Forms.ToolStripLabel();
            this.cmbLogLineCount = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new OPMedia.UI.Controls.OPMToolStripSeparator();
            this.tsbClearLog = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbFreezeWindow = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbTraces = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbInfo = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbWarnings = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbErrors = new OPMedia.UI.Controls.OPMToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiSaveWindow = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.tsmiSaveLogFile = new OPMedia.UI.Controls.OPMToolStripMenuItem();
            this.chkKeepOnTop = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            this.pnlContent.Controls.Add(this.chkKeepOnTop);
            // 
            // lvLogLines
            // 
            this.lvLogLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLogLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvLogLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrEntryType,
            this.hdrTimeStamp,
            this.hdrPID,
            this.hdrTID,
            this.hdrModule,
            this.hdrText});
            this.lvLogLines.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lvLogLines.Location = new System.Drawing.Point(0, 39);
            this.lvLogLines.Margin = new System.Windows.Forms.Padding(0);
            this.lvLogLines.MultiSelect = false;
            this.lvLogLines.Name = "lvLogLines";
            this.lvLogLines.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvLogLines.ShowItemToolTips = true;
            this.lvLogLines.Size = new System.Drawing.Size(811, 397);
            this.lvLogLines.TabIndex = 0;
            this.lvLogLines.UseCompatibleStateImageBehavior = false;
            this.lvLogLines.View = System.Windows.Forms.View.Details;
            this.lvLogLines.Resize += new System.EventHandler(this.lvLogLines_Resize);
            // 
            // hdrEntryType
            // 
            this.hdrEntryType.Text = "-";
            this.hdrEntryType.Width = 22;
            // 
            // hdrTimeStamp
            // 
            this.hdrTimeStamp.Text = "TXT_TIMESTAMP";
            this.hdrTimeStamp.Width = 139;
            // 
            // hdrPID
            // 
            this.hdrPID.Text = "PID";
            this.hdrPID.Width = 45;
            // 
            // hdrTID
            // 
            this.hdrTID.Text = "TID";
            this.hdrTID.Width = 29;
            // 
            // hdrModule
            // 
            this.hdrModule.Text = "TXT_MODULENAME";
            this.hdrModule.Width = 143;
            // 
            // hdrText
            // 
            this.hdrText.Text = "TXT_LOGMESSAGE";
            // 
            // tsMain
            // 
            this.tsMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsMain.AutoSize = false;
            this.tsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(216)))), ((int)(((byte)(235)))));
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLogFileName,
            this.cmbLogFileNames,
            this.lblLogLineCount,
            this.cmbLogLineCount,
            this.toolStripSeparator1,
            this.tsbClearLog,
            this.tsbFreezeWindow,
            this.tsbTraces,
            this.tsbInfo,
            this.tsbWarnings,
            this.tsbErrors,
            this.tsbSave});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.ShowBorder = true;
            this.tsMain.Size = new System.Drawing.Size(811, 39);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            this.tsMain.VerticalGradient = true;
            // 
            // lblLogFileName
            // 
            this.lblLogFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblLogFileName.Name = "lblLogFileName";
            this.lblLogFileName.Size = new System.Drawing.Size(103, 36);
            this.lblLogFileName.Text = "TXT_LOGFILENAME";
            // 
            // cmbLogFileNames
            // 
            this.cmbLogFileNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogFileNames.Name = "cmbLogFileNames";
            this.cmbLogFileNames.Size = new System.Drawing.Size(220, 39);
            this.cmbLogFileNames.SelectedIndexChanged += new System.EventHandler(this.cmbLogFileNames_SelectedIndexChanged);
            // 
            // lblLogLineCount
            // 
            this.lblLogLineCount.BackColor = System.Drawing.Color.Transparent;
            this.lblLogLineCount.Name = "lblLogLineCount";
            this.lblLogLineCount.Size = new System.Drawing.Size(112, 36);
            this.lblLogLineCount.Text = "TXT_LOGLINECOUNT";
            // 
            // cmbLogLineCount
            // 
            this.cmbLogLineCount.AutoSize = false;
            this.cmbLogLineCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogLineCount.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "150",
            "200",
            "> 200"});
            this.cmbLogLineCount.Name = "cmbLogLineCount";
            this.cmbLogLineCount.Size = new System.Drawing.Size(60, 24);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbClearLog
            // 
            this.tsbClearLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearLog.Image = global::OPMedia.UI.Properties.Resources.Delete;
            this.tsbClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearLog.Name = "tsbClearLog";
            this.tsbClearLog.Size = new System.Drawing.Size(23, 36);
            this.tsbClearLog.Text = "TXT_CLEARLOG";
            this.tsbClearLog.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbClearLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClearLog.Click += new System.EventHandler(this.OnDeleteLogFile);
            // 
            // tsbFreezeWindow
            // 
            this.tsbFreezeWindow.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFreezeWindow.CheckOnClick = true;
            this.tsbFreezeWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFreezeWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFreezeWindow.Name = "tsbFreezeWindow";
            this.tsbFreezeWindow.Size = new System.Drawing.Size(23, 36);
            this.tsbFreezeWindow.Text = "TXT_FREEZEWINDOW";
            this.tsbFreezeWindow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbFreezeWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbTraces
            // 
            this.tsbTraces.CheckOnClick = true;
            this.tsbTraces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTraces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTraces.Name = "tsbTraces";
            this.tsbTraces.Size = new System.Drawing.Size(23, 36);
            // 
            // tsbInfo
            // 
            this.tsbInfo.CheckOnClick = true;
            this.tsbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInfo.Name = "tsbInfo";
            this.tsbInfo.Size = new System.Drawing.Size(23, 36);
            // 
            // tsbWarnings
            // 
            this.tsbWarnings.CheckOnClick = true;
            this.tsbWarnings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWarnings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWarnings.Name = "tsbWarnings";
            this.tsbWarnings.Size = new System.Drawing.Size(23, 36);
            // 
            // tsbErrors
            // 
            this.tsbErrors.CheckOnClick = true;
            this.tsbErrors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbErrors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbErrors.Name = "tsbErrors";
            this.tsbErrors.Size = new System.Drawing.Size(23, 36);
            // 
            // tsbSave
            // 
            this.tsbSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveWindow,
            this.tsmiSaveLogFile});
            this.tsbSave.Image = global::OPMedia.UI.Properties.Resources.Save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(29, 36);
            this.tsbSave.Text = "Save log file or window";
            // 
            // tsmiSaveWindow
            // 
            this.tsmiSaveWindow.Name = "tsmiSaveWindow";
            this.tsmiSaveWindow.Size = new System.Drawing.Size(141, 22);
            this.tsmiSaveWindow.Text = "Save Window";
            this.tsmiSaveWindow.Click += new System.EventHandler(this.OnSaveWindow);
            // 
            // tsmiSaveLogFile
            // 
            this.tsmiSaveLogFile.Name = "tsmiSaveLogFile";
            this.tsmiSaveLogFile.Size = new System.Drawing.Size(141, 22);
            this.tsmiSaveLogFile.Text = "Save Log File";
            this.tsmiSaveLogFile.Click += new System.EventHandler(this.OnSaveLogFile);
            // 
            // chkKeepOnTop
            // 
            this.chkKeepOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKeepOnTop.AutoSize = true;
            this.chkKeepOnTop.Location = new System.Drawing.Point(3, 444);
            this.chkKeepOnTop.Name = "chkKeepOnTop";
            this.chkKeepOnTop.Size = new System.Drawing.Size(92, 17);
            this.chkKeepOnTop.TabIndex = 2;
            this.chkKeepOnTop.Text = "Always on top";
            this.chkKeepOnTop.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tsMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvLogLines, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(811, 436);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LogFileConsoleDialog
            // 
            this.ClientSize = new System.Drawing.Size(821, 464);
            this.Name = "LogFileConsoleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMListView lvLogLines;
        private System.Windows.Forms.ColumnHeader hdrTimeStamp;
        private System.Windows.Forms.ColumnHeader hdrPID;
        private System.Windows.Forms.ColumnHeader hdrTID;
        private System.Windows.Forms.ColumnHeader hdrModule;
        private System.Windows.Forms.ColumnHeader hdrText;
        private System.Windows.Forms.ColumnHeader hdrEntryType;
        private OPMToolStrip tsMain;
        private OPMToolStripButton tsbClearLog;
        private OPMToolStripButton tsbFreezeWindow;
        private System.Windows.Forms.ToolStripLabel lblLogFileName;
        private System.Windows.Forms.ToolStripComboBox cmbLogFileNames;
        private System.Windows.Forms.ToolStripLabel lblLogLineCount;
        private System.Windows.Forms.ToolStripComboBox cmbLogLineCount;
        private OPMToolStripSeparator toolStripSeparator1;
        private OPMToolStripButton tsbTraces;
        private OPMToolStripButton tsbInfo;
        private OPMToolStripButton tsbWarnings;
        private OPMToolStripButton tsbErrors;
        private System.Windows.Forms.ToolStripDropDownButton tsbSave;
        private OPMToolStripMenuItem tsmiSaveWindow;
        private OPMToolStripMenuItem tsmiSaveLogFile;
        private System.Windows.Forms.CheckBox chkKeepOnTop;
        private OPMTableLayoutPanel tableLayoutPanel1;
    }
}