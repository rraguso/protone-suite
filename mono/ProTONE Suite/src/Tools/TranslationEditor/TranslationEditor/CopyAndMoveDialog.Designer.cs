namespace TranslationEditor
{
    partial class CopyAndMoveDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSourceTranslation = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clbTags = new System.Windows.Forms.CheckedListBox();
            this.lbDestTranslation = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbOperation = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSourceTranslation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.clbTags, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbDestTranslation, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmbOperation, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 797);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 3);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 534);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(840, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "[STEP 3] Select the destination assembly:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(840, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "[STEP 1] Select the source assembly:";
            // 
            // lbSourceTranslation
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbSourceTranslation, 3);
            this.lbSourceTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSourceTranslation.FormattingEnabled = true;
            this.lbSourceTranslation.Location = new System.Drawing.Point(3, 19);
            this.lbSourceTranslation.Name = "lbSourceTranslation";
            this.lbSourceTranslation.Size = new System.Drawing.Size(834, 160);
            this.lbSourceTranslation.TabIndex = 5;
            this.lbSourceTranslation.SelectedIndexChanged += new System.EventHandler(this.lbSourceTranslation_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(840, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "[STEP 2] Select the tags to be copied or moved:";
            // 
            // clbTags
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.clbTags, 3);
            this.clbTags.ColumnWidth = 80;
            this.clbTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbTags.FormattingEnabled = true;
            this.clbTags.Location = new System.Drawing.Point(3, 201);
            this.clbTags.MultiColumn = true;
            this.clbTags.Name = "clbTags";
            this.clbTags.Size = new System.Drawing.Size(834, 327);
            this.clbTags.TabIndex = 7;
            this.clbTags.Resize += new System.EventHandler(this.clbTags_Resize);
            // 
            // lbDestTranslation
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbDestTranslation, 3);
            this.lbDestTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDestTranslation.FormattingEnabled = true;
            this.lbDestTranslation.Location = new System.Drawing.Point(3, 550);
            this.lbDestTranslation.Name = "lbDestTranslation";
            this.lbDestTranslation.Size = new System.Drawing.Size(834, 160);
            this.lbDestTranslation.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 3);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(0, 716);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(840, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "[STEP 4] Select the operation type:";
            // 
            // cmbOperation
            // 
            this.cmbOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOperation.FormattingEnabled = true;
            this.cmbOperation.Items.AddRange(new object[] {
            "MOVE",
            "COPY",
            "DELETE"});
            this.cmbOperation.Location = new System.Drawing.Point(3, 732);
            this.cmbOperation.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.cmbOperation.Name = "cmbOperation";
            this.cmbOperation.Size = new System.Drawing.Size(666, 21);
            this.cmbOperation.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(674, 732);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5, 3, 2, 0);
            this.btnOK.MinimumSize = new System.Drawing.Size(80, 25);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Start !";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(758, 732);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(80, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CopyAndMoveDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(840, 797);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CopyAndMoveDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multiple Copy And Move Wizard";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbSourceTranslation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbTags;
        private System.Windows.Forms.ListBox lbDestTranslation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbOperation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}