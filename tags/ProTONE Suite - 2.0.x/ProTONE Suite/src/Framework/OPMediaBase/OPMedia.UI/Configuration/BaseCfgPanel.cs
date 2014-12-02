using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using OPMedia.UI.Themes;


namespace OPMedia.UI.Configuration
{
    public class BaseCfgPanel : OPMBaseControl
    {
        public virtual Image Image
        {
            get
            {
                return null;
            }
        }

        public virtual string GetHelpTopic()
        {
            return this.Name;
        }

        public event EventHandler ModifiedActive = null;

        private bool _modified = false;
        public bool Modified
        {
            get
            {
                return _modified;
            }

            set
            {
                _modified = value;
                if (value && ModifiedActive != null)
                {
                    ModifiedActive(this, EventArgs.Empty);
                }
            }
        }
        
        public string Title { get; protected set; }

        public BaseCfgPanel()
        {
            this.HandleCreated += new EventHandler(BaseCfgPanel_HandleCreated);
        }

        void BaseCfgPanel_HandleCreated(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);
        }

        public void Save()
        {
            if (Modified)
            {
                SaveInternal();
            }
        }

        public void Discard()
        {
            if (Modified)
            {
                DiscardInternal();
            }
        }

        protected virtual void SaveInternal()
        {
        }

        protected virtual void DiscardInternal()
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseCfgPanel
            // 
            this.Name = "BaseCfgPanel";
            this.ResumeLayout(false);

        }
    }
}
