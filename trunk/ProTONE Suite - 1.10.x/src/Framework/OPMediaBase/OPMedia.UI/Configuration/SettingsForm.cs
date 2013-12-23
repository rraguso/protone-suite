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

        public new static DialogResult Show()
        {
            SettingsForm _instance = new SettingsForm();
            return _instance.ShowDialog();
        }

        public static void RequestRestart()
        {
            _restart = true;
        }

        protected SettingsForm(string titleToOpen)
            : this()
        {
            if (!string.IsNullOrEmpty(titleToOpen))
            {
                foreach (TabPage tp in tabOptions.TabPages)
                {
                    if (tp.Text == titleToOpen)
                    {
                        ShowPanel(tp.Controls[0] as BaseCfgPanel);
                        break;
                    }
                }

            }
        }

        public SettingsForm() : base("TXT_CONFIGUREAPP")
        {
            InitializeComponent();

            tabOptions.ImageList = new ImageList();
            tabOptions.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            tabOptions.ImageList.ImageSize = new Size(32, 32);
            tabOptions.ImageList.TransparentColor = Color.Magenta;

            //this.AllowResize = true;
            this.InheritAppIcon = false;
            this.Icon = Resources.settings.ToIcon();
            this.FormClosing += new FormClosingEventHandler(SettingsForm_FormClosing);
            this.HandleDestroyed += new EventHandler(SettingsForm_HandleDestroyed);
            this.Load += new EventHandler(SettingsForm_Load);
        }

        void SettingsForm_Load(object sender, EventArgs e)
        {
            tabOptions.TabPages.Clear();

            bool logFullyDisabled = SuiteConfiguration.LogFullyDisabled;

            AddPanel(typeof(GeneralSettingsPanel));
            AddAditionalPanels();
            AddPanel(typeof(NetworkSettingsPanel), RequiresNetworkConfig());
            AddPanel(typeof(LoggingSettingsPanel), !logFullyDisabled);
            
            RemoveUnneededPanels();
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
                    foreach (TabPage tp in tabOptions.TabPages)
                    {
                        BaseCfgPanel panel = tp.Controls[0] as BaseCfgPanel;
                        if (panel != null)
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
            List<TabPage> pagesToRemove = new List<TabPage>();

            foreach (TabPage tp in tabOptions.TabPages)
            {
                Control ctl = tp.Controls[0];
                if (ctl.GetType() == panelType)
                {
                    pagesToRemove.Add(tp);
                }
            }

            foreach (TabPage tp in pagesToRemove)
            {
                tabOptions.TabPages.Remove(tp);
            }
        }

        protected void KeepPanels(List<Type> panelsToKeep)
        {
            List<TabPage> pagesToRemove = new List<TabPage>();

            foreach (TabPage tp in tabOptions.TabPages)
            {
                Control ctl = tp.Controls[0];
                if (!panelsToKeep.Contains(ctl.GetType()))
                {
                    pagesToRemove.Add(tp);
                }
            }

            foreach (TabPage tp in pagesToRemove)
            {
                tabOptions.TabPages.Remove(tp);
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
                    if (!tabOptions.TabPages.ContainsKey(title))
                    {
                        panel.Dock = DockStyle.Fill;
                        OPMTabPage tp = new OPMTabPage(title, panel);
                        tp.ImageIndex = tabOptions.ImageList.Images.Count;
                        tabOptions.ImageList.Images.Add(panel.Image);

                        tabOptions.TabPages.Add(tp);
                    }
                }
            }
        }

        private void ShowPanel(BaseCfgPanel panel)
        {
            if (selectedPanel != panel)
            {
                foreach (TabPage tp in tabOptions.TabPages)
                {
                    BaseCfgPanel crtPanel = tp.Controls[0] as BaseCfgPanel;
                    if (panel == crtPanel)
                    {
                        tabOptions.SelectedTab = tp;
                        break;
                    }
                }
            }
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