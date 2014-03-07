
using OPMedia.UI.Controls;
namespace OPMedia.UI.Controls
{
    partial class WeekdaySelector
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
            this.chkMon = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkWed = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkFri = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkSun = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkTue = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkThu = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkSat = new OPMedia.UI.Controls.OPMCheckBox();
            this.chkAll = new OPMedia.UI.Controls.OPMCheckBox();
            this.pnlCheckboxes = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.pnlCheckboxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMon
            // 
            this.chkMon.AutoSize = true;
            this.chkMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMon.Location = new System.Drawing.Point(0, 3);
            this.chkMon.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.chkMon.Name = "chkMon";
            this.chkMon.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkMon.Size = new System.Drawing.Size(109, 17);
            this.chkMon.TabIndex = 0;
            this.chkMon.Tag = "Monday";
            this.chkMon.Text = "TXT_MONDAY";
            this.chkMon.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            // 
            // chkWed
            // 
            this.chkWed.AutoSize = true;
            this.chkWed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkWed.Location = new System.Drawing.Point(226, 3);
            this.chkWed.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.chkWed.Name = "chkWed";
            this.chkWed.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkWed.Size = new System.Drawing.Size(109, 17);
            this.chkWed.TabIndex = 2;
            this.chkWed.Tag = "Wednesday";
            this.chkWed.Text = "TXT_WEDNESDAY";
            this.chkWed.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            // 
            // chkFri
            // 
            this.chkFri.AutoSize = true;
            this.chkFri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFri.Location = new System.Drawing.Point(0, 26);
            this.chkFri.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.chkFri.Name = "chkFri";
            this.chkFri.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkFri.Size = new System.Drawing.Size(109, 17);
            this.chkFri.TabIndex = 4;
            this.chkFri.Tag = "Friday";
            this.chkFri.Text = "TXT_FRIDAY";
            this.chkFri.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            // 
            // chkSun
            // 
            this.chkSun.AutoSize = true;
            this.chkSun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSun.Location = new System.Drawing.Point(226, 26);
            this.chkSun.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.chkSun.Name = "chkSun";
            this.chkSun.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkSun.Size = new System.Drawing.Size(109, 17);
            this.chkSun.TabIndex = 6;
            this.chkSun.Tag = "Sunday";
            this.chkSun.Text = "TXT_SUNDAY";
            this.chkSun.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            // 
            // chkTue
            // 
            this.chkTue.AutoSize = true;
            this.chkTue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTue.Location = new System.Drawing.Point(113, 3);
            this.chkTue.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.chkTue.Name = "chkTue";
            this.chkTue.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkTue.Size = new System.Drawing.Size(109, 17);
            this.chkTue.TabIndex = 1;
            this.chkTue.Tag = "Tuesday";
            this.chkTue.Text = "TXT_TUESDAY";
            this.chkTue.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            // 
            // chkThu
            // 
            this.chkThu.AutoSize = true;
            this.chkThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkThu.Location = new System.Drawing.Point(339, 3);
            this.chkThu.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.chkThu.Name = "chkThu";
            this.chkThu.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkThu.Size = new System.Drawing.Size(109, 17);
            this.chkThu.TabIndex = 3;
            this.chkThu.Tag = "Thursday";
            this.chkThu.Text = "TXT_THURSDAY";
            this.chkThu.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            // 
            // chkSat
            // 
            this.chkSat.AutoSize = true;
            this.chkSat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSat.Location = new System.Drawing.Point(113, 26);
            this.chkSat.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.chkSat.Name = "chkSat";
            this.chkSat.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkSat.Size = new System.Drawing.Size(109, 17);
            this.chkSat.TabIndex = 5;
            this.chkSat.Tag = "Saturday";
            this.chkSat.Text = "TXT_SATURDAY";
            this.chkSat.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAll.Location = new System.Drawing.Point(339, 26);
            this.chkAll.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.OverrideForeColor = System.Drawing.Color.Empty;
            this.chkAll.Size = new System.Drawing.Size(109, 17);
            this.chkAll.TabIndex = 7;
            this.chkAll.Tag = "";
            this.chkAll.Text = "TXT_EVERYDAY";
            this.chkAll.CheckedChanged += new System.EventHandler(this.OnDayChecked);
            // 
            // pnlCheckboxes
            // 
            this.pnlCheckboxes.AutoSize = true;
            this.pnlCheckboxes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlCheckboxes.ColumnCount = 4;
            this.pnlCheckboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCheckboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCheckboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCheckboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCheckboxes.Controls.Add(this.chkAll, 3, 1);
            this.pnlCheckboxes.Controls.Add(this.chkSun, 2, 1);
            this.pnlCheckboxes.Controls.Add(this.chkSat, 1, 1);
            this.pnlCheckboxes.Controls.Add(this.chkFri, 0, 1);
            this.pnlCheckboxes.Controls.Add(this.chkThu, 3, 0);
            this.pnlCheckboxes.Controls.Add(this.chkWed, 2, 0);
            this.pnlCheckboxes.Controls.Add(this.chkTue, 1, 0);
            this.pnlCheckboxes.Controls.Add(this.chkMon, 0, 0);
            this.pnlCheckboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckboxes.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckboxes.Name = "pnlCheckboxes";
            this.pnlCheckboxes.OverrideBackColor = System.Drawing.Color.Empty;
            this.pnlCheckboxes.RowCount = 2;
            this.pnlCheckboxes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlCheckboxes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlCheckboxes.Size = new System.Drawing.Size(452, 46);
            this.pnlCheckboxes.TabIndex = 0;
            // 
            // WeekdaySelector
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlCheckboxes);
            this.MinimumSize = new System.Drawing.Size(400, 45);
            this.Name = "WeekdaySelector";
            this.Size = new System.Drawing.Size(452, 46);
            this.pnlCheckboxes.ResumeLayout(false);
            this.pnlCheckboxes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OPMCheckBox chkMon;
        private OPMCheckBox chkWed;
        private OPMCheckBox chkFri;
        private OPMCheckBox chkSun;
        private OPMCheckBox chkTue;
        private OPMCheckBox chkThu;
        private OPMCheckBox chkSat;
        private OPMCheckBox chkAll;
        private OPMTableLayoutPanel pnlCheckboxes;
    }
}
