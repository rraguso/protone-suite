using System.Windows.Forms;
namespace TranslationEditor
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnBrowseFiles = new System.Windows.Forms.Button();
            this.lblSearchPath = new System.Windows.Forms.Label();
            this.pbSearchProgress = new System.Windows.Forms.ProgressBar();
            this.lbTranslationFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lvTranslations = new System.Windows.Forms.ListView();
            this.hdrStringName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrBaseText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrTranslatedText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.chkReadOnly = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBaseText = new System.Windows.Forms.RichTextBox();
            this.lblTranslatedText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.cmsOptions.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseFiles
            // 
            this.btnBrowseFiles.AutoSize = true;
            this.btnBrowseFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseFiles.Location = new System.Drawing.Point(3, 3);
            this.btnBrowseFiles.Name = "btnBrowseFiles";
            this.btnBrowseFiles.Size = new System.Drawing.Size(161, 23);
            this.btnBrowseFiles.TabIndex = 1;
            this.btnBrowseFiles.Text = "Search Translation.resx files ...";
            this.btnBrowseFiles.UseVisualStyleBackColor = true;
            this.btnBrowseFiles.Click += new System.EventHandler(this.btnBrowseFiles_Click);
            // 
            // lblSearchPath
            // 
            this.lblSearchPath.AutoSize = true;
            this.lblSearchPath.Location = new System.Drawing.Point(187, 18);
            this.lblSearchPath.Name = "lblSearchPath";
            this.lblSearchPath.Size = new System.Drawing.Size(0, 13);
            this.lblSearchPath.TabIndex = 2;
            // 
            // pbSearchProgress
            // 
            this.pbSearchProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSearchProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.pbSearchProgress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSearchProgress.Location = new System.Drawing.Point(3, 32);
            this.pbSearchProgress.Maximum = 10000;
            this.pbSearchProgress.Name = "pbSearchProgress";
            this.pbSearchProgress.Size = new System.Drawing.Size(610, 10);
            this.pbSearchProgress.TabIndex = 3;
            // 
            // lbTranslationFiles
            // 
            this.lbTranslationFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTranslationFiles.FormattingEnabled = true;
            this.lbTranslationFiles.Location = new System.Drawing.Point(3, 48);
            this.lbTranslationFiles.Name = "lbTranslationFiles";
            this.lbTranslationFiles.Size = new System.Drawing.Size(610, 95);
            this.lbTranslationFiles.TabIndex = 4;
            this.lbTranslationFiles.SelectedIndexChanged += new System.EventHandler(this.lbTranslationFiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Translation strings:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(537, 0);
            this.cmbLanguage.Margin = new System.Windows.Forms.Padding(0);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(79, 21);
            this.cmbLanguage.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(428, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Translation language:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pbSearchProgress, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbTranslationFiles, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lvTranslations, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(616, 582);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // lvTranslations
            // 
            this.lvTranslations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTranslations.BackColor = System.Drawing.Color.Gainsboro;
            this.lvTranslations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvTranslations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrStringName,
            this.hdrBaseText,
            this.hdrTranslatedText});
            this.lvTranslations.ContextMenuStrip = this.cmsOptions;
            this.lvTranslations.ForeColor = System.Drawing.Color.Maroon;
            this.lvTranslations.FullRowSelect = true;
            this.lvTranslations.GridLines = true;
            this.lvTranslations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTranslations.HideSelection = false;
            this.lvTranslations.Location = new System.Drawing.Point(3, 170);
            this.lvTranslations.Name = "lvTranslations";
            this.lvTranslations.ShowItemToolTips = true;
            this.lvTranslations.Size = new System.Drawing.Size(610, 302);
            this.lvTranslations.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTranslations.TabIndex = 0;
            this.lvTranslations.UseCompatibleStateImageBehavior = false;
            this.lvTranslations.View = System.Windows.Forms.View.Details;
            this.lvTranslations.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvTranslations_ItemSelectionChanged);
            this.lvTranslations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvTranslations_KeyDown);
            this.lvTranslations.Resize += new System.EventHandler(this.lvTranslations_Resize);
            // 
            // hdrStringName
            // 
            this.hdrStringName.Text = "String Name";
            // 
            // hdrBaseText
            // 
            this.hdrBaseText.Text = "Base Text (EN)";
            // 
            // hdrTranslatedText
            // 
            this.hdrTranslatedText.Text = "Translated Text";
            // 
            // cmsOptions
            // 
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewEntry,
            this.mnuDeleteEntry,
            this.toolStripSeparator1,
            this.mnuRenameEntry});
            this.cmsOptions.Name = "cmsOptions";
            this.cmsOptions.Size = new System.Drawing.Size(188, 76);
            // 
            // mnuNewEntry
            // 
            this.mnuNewEntry.Name = "mnuNewEntry";
            this.mnuNewEntry.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNewEntry.Size = new System.Drawing.Size(187, 22);
            this.mnuNewEntry.Text = "New entry";
            this.mnuNewEntry.Click += new System.EventHandler(this.OnNewEntry);
            // 
            // mnuDeleteEntry
            // 
            this.mnuDeleteEntry.Name = "mnuDeleteEntry";
            this.mnuDeleteEntry.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.mnuDeleteEntry.Size = new System.Drawing.Size(187, 22);
            this.mnuDeleteEntry.Text = "Delete entry";
            this.mnuDeleteEntry.Click += new System.EventHandler(this.OnDeleteEntry);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // mnuRenameEntry
            // 
            this.mnuRenameEntry.Name = "mnuRenameEntry";
            this.mnuRenameEntry.ShortcutKeyDisplayString = "F2";
            this.mnuRenameEntry.Size = new System.Drawing.Size(187, 22);
            this.mnuRenameEntry.Text = "Edit entry";
            this.mnuRenameEntry.Click += new System.EventHandler(this.OnEditEntry);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbLanguage, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 146);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(616, 21);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.btnBrowseFiles, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkReadOnly, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(616, 29);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.AutoSize = true;
            this.chkReadOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkReadOnly.Location = new System.Drawing.Point(537, 3);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Size = new System.Drawing.Size(76, 23);
            this.chkReadOnly.TabIndex = 0;
            this.chkReadOnly.Text = "Read-Only";
            this.chkReadOnly.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblBaseText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTranslatedText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 478);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 101);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // lblBaseText
            // 
            this.lblBaseText.AutoSize = true;
            this.lblBaseText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBaseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaseText.Location = new System.Drawing.Point(2, 13);
            this.lblBaseText.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblBaseText.Name = "lblBaseText";
            this.lblBaseText.ReadOnly = true;
            this.lblBaseText.Size = new System.Drawing.Size(303, 88);
            this.lblBaseText.TabIndex = 2;
            this.lblBaseText.Text = "label3";
            // 
            // lblTranslatedText
            // 
            this.lblTranslatedText.AutoSize = true;
            this.lblTranslatedText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTranslatedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTranslatedText.Location = new System.Drawing.Point(307, 13);
            this.lblTranslatedText.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblTranslatedText.Name = "lblTranslatedText";
            this.lblTranslatedText.ReadOnly = true;
            this.lblTranslatedText.Size = new System.Drawing.Size(303, 88);
            this.lblTranslatedText.TabIndex = 3;
            this.lblTranslatedText.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Base text (EN):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(305, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Translated text:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 582);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.lblSearchPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Translation editor";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.cmsOptions.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lvTranslations;
        private System.Windows.Forms.ColumnHeader hdrBaseText;
        private System.Windows.Forms.ColumnHeader hdrTranslatedText;
        private System.Windows.Forms.Button btnBrowseFiles;
        private System.Windows.Forms.Label lblSearchPath;
        private System.Windows.Forms.ProgressBar pbSearchProgress;
        private System.Windows.Forms.ListBox lbTranslationFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader hdrStringName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuNewEntry;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameEntry;
        private TableLayoutPanel tableLayoutPanel4;
        private CheckBox chkReadOnly;
        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox lblBaseText;
        private RichTextBox lblTranslatedText;
        private Label label3;
        private Label label4;
    }
}