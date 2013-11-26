using System.Windows.Forms;
namespace OPMedia.UI.Configuration
{
    partial class ConnectedFilesConfigCtl
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
            this.chkUseLinkedFiles = new OPMedia.UI.Controls.OPMCheckBox();
            this.lvConnFiles = new OPMedia.UI.Controls.OPMListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPFT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCFT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new OPMedia.UI.Controls.OPMFlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // chkUseLinkedFiles
            // 
            this.chkUseLinkedFiles.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkUseLinkedFiles, 2);
            this.chkUseLinkedFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseLinkedFiles.Location = new System.Drawing.Point(3, 3);
            this.chkUseLinkedFiles.Name = "chkUseLinkedFiles";
            this.chkUseLinkedFiles.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkUseLinkedFiles.Size = new System.Drawing.Size(131, 17);
            this.chkUseLinkedFiles.TabIndex = 9;
            this.chkUseLinkedFiles.Text = "TXT_USE_LINKEDFILES";
            // 
            // lvConnFiles
            // 
            this.lvConnFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colPFT,
            this.colCFT});
            this.lvConnFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnFiles.Location = new System.Drawing.Point(0, 23);
            this.lvConnFiles.Margin = new System.Windows.Forms.Padding(0);
            this.lvConnFiles.MultiSelect = false;
            this.lvConnFiles.Name = "lvConnFiles";
            this.lvConnFiles.OverrideBackColor = System.Drawing.Color.Empty;
            this.lvConnFiles.Size = new System.Drawing.Size(380, 307);
            this.lvConnFiles.TabIndex = 10;
            this.lvConnFiles.UseCompatibleStateImageBehavior = false;
            this.lvConnFiles.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "";
            this.colID.Width = 1;
            // 
            // colPFT
            // 
            this.colPFT.Text = "TXT_PARENTFILETYPES";
            // 
            // colCFT
            // 
            this.colCFT.Text = "TXT_CHILDFILETYPES";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkUseLinkedFiles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvConnFiles, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 330);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AccessibleName = "flowLayoutPanel2";
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnAdd);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(380, 23);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.OverrideBackColor = System.Drawing.Color.Empty;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(20, 307);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 2);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(16, 16);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 5;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ConnectedFilesConfigCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectedFilesConfigCtl";
            this.Size = new System.Drawing.Size(400, 330);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.OPMCheckBox chkUseLinkedFiles;
        private Controls.OPMListView lvConnFiles;
        private ColumnHeader colID;
        private ColumnHeader colPFT;
        private ColumnHeader colCFT;
        private TableLayoutPanel tableLayoutPanel1;
        private Controls.OPMFlowLayoutPanel flowLayoutPanel2;
        private PictureBox btnAdd;
    }
}
