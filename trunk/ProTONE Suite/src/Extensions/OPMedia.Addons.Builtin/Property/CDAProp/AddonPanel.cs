using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OPMedia.Core;
using OPMedia.Core.Logging;
using OPMedia.Runtime.ProTONE.FileInformation;
using OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard;
using OPMedia.Runtime.Addons.AddonsBase.Prop;
using OPMedia.UI.Wizards;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Core.Configuration;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.ProTONE.GlobalEvents;
using OPMedia.UI.Controls;
using OPMedia.Addons.Builtin.Properties;
using OPMedia.Addons.Builtin.Configuration;

namespace OPMedia.Addons.Builtin.CDAProp
{
    public partial class AddonPanel : PropBaseCtl
    {


        List<object> lii = null;
        List<string> strItems = null;

        private Timer _reloadTimer = null;

        public override string GetHelpTopic()
        {
            return "CDAPropertyPanel";
        }

        public AddonPanel()
            : base()
        {
            InitializeComponent();
            this.HandleCreated += new EventHandler(AddonPanel_HandleCreated);
        }

        void AddonPanel_HandleCreated(object sender, EventArgs e)
        {
            Translator.TranslateControl(this, DesignMode);
        }

        public override bool CanHandleFolders
        {
            get
            {
                return false;
            }
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                return new List<string>(new string[] { "cda" });
            }
        }

        public override int MaximumHandledItems
        {
            get
            {
                return -1;
            }
        }

        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            this.strItems = strItems;
            DoShowProperties();
        }

        public override void SaveProperties()
        {
        }

        private void pgProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            base.Modified = true;
        }

        private void DoShowProperties()
        {
            if (_reloadTimer == null)
            {
                _reloadTimer = new Timer();
                _reloadTimer.Interval = (int)(BuiltinAddonConfig.FEPreviewTimer * 1000);
                _reloadTimer.Tick += new EventHandler(_reloadTimer_Tick);
            }

            _reloadTimer.Stop();
            _reloadTimer.Start();

            InternalShowProperties(false);
        }

        void _reloadTimer_Tick(object sender, EventArgs e)
        {
            _reloadTimer.Stop(); 
            InternalShowProperties(true);
        }

        private void InternalShowProperties(bool deepLoad)
        {
            PerformTranslation();

            lii = new List<object>();
            foreach (string item in strItems)
            {
                CDAFileInfo ii = new CDAFileInfo(item, deepLoad && (strItems.Count == 1));
                if (ii.IsValid)
                {
                    lii.Add(ii);
                }
            }

            FileAttributesBrowser.ProcessObjectAttributes(lii);

            pgProperties.SelectedObjects = lii.ToArray();
            base.Modified = false;
        }

        private bool DoSaveProperties()
        {
            return false;
        }

        private void PerformTranslation()
        {
        }
    }
}
