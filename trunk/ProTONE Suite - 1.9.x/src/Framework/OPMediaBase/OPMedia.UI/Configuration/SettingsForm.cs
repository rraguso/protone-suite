using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.Runtime.ServiceHelpers;
using OPMedia.Runtime;
using OPMedia.UI.Configuration;
using OPMedia.UI.HelpSupport;
using OPMedia.UI.Properties;

namespace OPMedia.UI
{
    public partial class SettingsForm : ToolForm
    {
        public static bool NetworkConfig = false;

        protected static bool _restart = false;

        protected BaseCfgPanel selectedPanel = null;

        protected List<BaseCfgPanel> cfgPanels =
            new List<BaseCfgPanel>();


        public new static DialogResult Show()
        {
            SettingsForm _instance = new SettingsForm();
            return _instance.ShowDialog();
        }

        public static void RequestRestart()
        {
            _restart = true;
        }

        protected SettingsForm(string titleToOpen) : this()
        {
            if (!string.IsNullOrEmpty(titleToOpen))
            {
                for (int i = 0; i < tsOptionList.Items.Count; i++)
                {
                    if (cfgPanels[i].Title == titleToOpen)
                    {
                        ToolStripItemClickedEventArgs args =
                            new ToolStripItemClickedEventArgs(tsOptionList.Items[i]);
                        OnItemClicked(this, args);

                        break;
                    }
                }
            }
        }

        public SettingsForm() : base("TXT_CONFIGUREAPP")
        {
            InitializeComponent();
            this.AllowResize = false;
            this.InheritAppIcon = false;
            this.Icon = Resources.settings.ToIcon();
            this.FormClosing += new FormClosingEventHandler(SettingsForm_FormClosing);
            this.HandleDestroyed += new EventHandler(SettingsForm_HandleDestroyed);
            this.Load += new EventHandler(SettingsForm_Load);
            tsOptionList.ItemClicked +=
                new ToolStripItemClickedEventHandler(OnItemClicked);

        }

        void SettingsForm_Load(object sender, EventArgs e)
        {
            tsOptionList.Items.Clear();

            bool logFullyDisabled = SuiteConfiguration.LogFullyDisabled;

            AddPanel(typeof(GeneralSettingsPanel));
            AddAditionalPanels();
            AddPanel(typeof(NetworkSettingsPanel), RequiresNetworkConfig());
            AddPanel(typeof(LoggingSettingsPanel), !logFullyDisabled);
            
            RemoveUnneededPanels();

            ToolStripItemClickedEventArgs args =
                new ToolStripItemClickedEventArgs(tsOptionList.Items[0]);

            OnItemClicked(this, args);
        }

        public virtual void RemoveUnneededPanels()
        {
        }

        public virtual void AddAditionalPanels()
        {
        }

        public virtual bool RequiresNetworkConfig()
        {
            return NetworkConfig;
        }

        protected override bool AllowCloseOnEnterOrEscape()
        {
            return true;
        }

        void SettingsForm_HandleDestroyed(object sender, EventArgs e)
        {
            if (_restart)
            {
                LoggedApplication.Restart();
            }
        }

        bool _closedOnce = false;
        void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!_closedOnce)
                {
                    foreach (BaseCfgPanel panel in cfgPanels)
                    {
                        if (DialogResult == DialogResult.OK)
                        {
                            panel.Save();
                        }
                        else
                        {
                            panel.Discard();
                        }
                    }

                    _closedOnce = true;
                    return;
                }
            }
            catch(SettingsSaveException ex)
            {
                ErrorDispatcher.DispatchError(ex.Message, "Caution");
            }

            e.Cancel = true;
        }

        protected void RemovePanel(Type panelType)
        {
            List<OPMToolStripButton> panelsToRemove = new List<OPMToolStripButton>();

            foreach (OPMToolStripButton btn in tsOptionList.Items)
            {
                if (btn.Tag.GetType() == panelType)
                {
                    panelsToRemove.Add(btn);
                }
            }

            foreach (OPMToolStripButton btn in panelsToRemove)
            {
                tsOptionList.Items.Remove(btn);
            }
        }

        protected void KeepPanels(List<Type> panelsToKeep)
        {
            List<OPMToolStripButton> panelsToRemove = new List<OPMToolStripButton>();

            foreach (OPMToolStripButton btn in tsOptionList.Items)
            {
                if (!panelsToKeep.Contains(btn.Tag.GetType()))
                {
                    panelsToRemove.Add(btn);
                }
            }

            foreach (OPMToolStripButton btn in panelsToRemove)
            {
                tsOptionList.Items.Remove(btn);
            }
        }

        protected void AddPanel(Type panelType)
        {
            AddPanel(panelType, true);
        }

        protected void AddPanel(Type panelType, bool condition)
        {
            AddPanel(panelType, condition, false);
        }

        protected void AddPanel(Type panelType, bool condition, bool alignRight)
        {
            if (condition)
            {
                BaseCfgPanel panel = null;

                try
                {
                    panel = Activator.CreateInstance(panelType) as BaseCfgPanel;
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }

                if (panel != null)
                {
                    AddPanel(panel, condition, alignRight);
                }
            }
        }

        protected void AddPanel(BaseCfgPanel panel, bool condition)
        {
            AddPanel(panel, condition, false);
        }

        protected void AddPanel(BaseCfgPanel panel, bool condition, bool alignRight)
        {
            if (condition)
            {
                if (panel != null)
                {
                    string title = Translator.Translate(panel.Title);
                    if (!tsOptionList.Items.ContainsKey(title))
                    {
                        OPMToolStripButton btn = new OPMToolStripButton(title);
                        btn.Name = title;
                        btn.Image = panel.Image;
                        btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                        btn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.SizeToFit;
                        btn.ImageTransparentColor = System.Drawing.Color.Magenta;
                        btn.AutoSize = true;
                        btn.Tag = panel;
                        btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;

                        if (alignRight)
                        {
                            btn.Alignment = ToolStripItemAlignment.Right;
                        }

                        tsOptionList.Items.Add(btn);

                        cfgPanels.Add(panel);
                        panel.Visible = false;
                        panel.Dock = DockStyle.Fill;
                        pnlOptions.Controls.Add(panel);
                    }
                }
            }
        }

        private void ShowPanel(BaseCfgPanel panel)
        {
            if (selectedPanel != panel)
            {
                selectedPanel = panel;

                foreach (Control ctl in pnlOptions.Controls)
                {
                    ctl.Visible = false;
                }

                if (panel != null)
                {
                    panel.Visible = true;

                    lblPanelTitle.Text = Translator.Translate(panel.Title).Replace("\r\n", " ");
                    pbPanelImage.Image = panel.Image;
                }
            }
        }

        void OnItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OPMToolStripButton btn = e.ClickedItem as OPMToolStripButton;
            if (btn != null)
            {
                foreach (ToolStripItem tsi in tsOptionList.Items)
                {
                    OPMToolStripButton button = tsi as OPMToolStripButton;
                    if (button != null)
                    {
                        button.Checked = (button == btn);
                    }
                }
                
                ShowPanel(btn.Tag as BaseCfgPanel);
            }
        }

        private void pbPanelImage_Click(object sender, EventArgs e)
        {

        }

        private void layoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public override void FireHelpRequest()
        {
            if (selectedPanel != null)
                HelpTarget.HelpRequest(this.Name, selectedPanel.GetHelpTopic());
            else
                base.FireHelpRequest();
        }
       
    }

    public class SettingsSaveException : Exception
    {
        public SettingsSaveException(string msg)
            : base(msg)
        {
        }
    }
}