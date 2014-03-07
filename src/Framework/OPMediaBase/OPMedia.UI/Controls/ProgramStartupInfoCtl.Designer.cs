
using System;
using OPMedia.UI.Controls;
namespace OPMedia.UI.Controls
{
    partial class ProgramStartupInfoCtl
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
            this.label1 = new OPMedia.UI.Controls.OPMLabel();
            this.lblInfo = new OPMedia.UI.Controls.OPMLinkLabel();
            this.flowLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.OverrideBackColor = System.Drawing.Color.Empty;
            this.label1.OverrideForeColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT_PROGRAM_DEF";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(0, 13);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(124, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.TabStop = true;
            this.lblInfo.Text = "TXT_DEFINE_PROGRAM";
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_LinkClicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.lblInfo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.flowLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.flowLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.flowLayoutPanel1.Size = new System.Drawing.Size(124, 26);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // ProgramStartupInfoCtl
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ProgramStartupInfoCtl";
            this.Size = new System.Drawing.Size(124, 26);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMLabel label1;
        private OPMLinkLabel lblInfo;
        private OPMTableLayoutPanel flowLayoutPanel1;
    }
}
