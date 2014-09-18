
using OPMedia.UI.Controls;
namespace OPMedia.Addons.Builtin.TaggedFileProp
{
    partial class AddonPanel
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
            this.pgProperties = new OPMPropertyGrid();
            this.btnSave = new OPMButton();
            this.btnUndo = new OPMButton();
            this.btnLaunchWizard = new OPMButton();
            this.SuspendLayout();
            // 
            // pgProperties
            // 
            this.pgProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgProperties.HelpVisible = false;
            this.pgProperties.Location = new System.Drawing.Point(5, 5);
            this.pgProperties.Margin = new System.Windows.Forms.Padding(5);
            this.pgProperties.Name = "pgProperties";
            this.pgProperties.Size = new System.Drawing.Size(293, 271);
            this.pgProperties.TabIndex = 0;
            this.pgProperties.ToolbarVisible = false;
            this.pgProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgProperties_PropertyValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(5, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "TXT_APPLY";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndo.Location = new System.Drawing.Point(86, 284);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(72, 24);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.Text = "TXT_UNDO";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnLaunchWizard
            // 
            this.btnLaunchWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLaunchWizard.Location = new System.Drawing.Point(167, 284);
            this.btnLaunchWizard.Name = "btnLaunchWizard";
            this.btnLaunchWizard.Size = new System.Drawing.Size(131, 24);
            this.btnLaunchWizard.TabIndex = 3;
            this.btnLaunchWizard.Text = "TXT_LAUNCH_WIZARD";
            this.btnLaunchWizard.Click += new System.EventHandler(this.btnLaunchWizard_Click);
            // 
            // AddonPanel
            // 
            this.Controls.Add(this.btnLaunchWizard);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pgProperties);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(303, 317);
            this.ResumeLayout(false);

        }

        #endregion

        private OPMPropertyGrid pgProperties;
        private OPMButton btnSave;
        private OPMButton btnUndo;
        private OPMButton btnLaunchWizard;

    }
}
