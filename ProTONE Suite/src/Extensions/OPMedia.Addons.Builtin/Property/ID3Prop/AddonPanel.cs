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
using OPMedia.Addons.Builtin.ID3Prop.ID3Wizard;
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
using OPMedia.Runtime.FileInformation;
using OPMedia.Addons.Builtin.Configuration;

namespace OPMedia.Addons.Builtin.ID3Prop
{
    public partial class AddonPanel : PropBaseCtl
    {


        List<object> lii = null;
        List<string> strItems = null;

        private Timer _reloadTimer = null;

        public override string GetHelpTopic()
        {
            return "ID3PropertyPanel";
        }

        public AddonPanel()
            : base()
        {
            InitializeComponent();
            this.HandleCreated += new EventHandler(AddonPanel_HandleCreated);
        }

        [EventSink(OPMedia.Core.EventNames.ExecuteShortcut)]
        public void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            if (args.Handled)
                return;

            switch (args.cmd)
            {
                case OPMShortcut.CmdGenericApply:
                    if (btnSave.Enabled) btnSave_Click(null, null);
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdGenericUndo:
                    if (btnUndo.Enabled) btnUndo_Click(null, null);
                    args.Handled = true;
                    break;
            }
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
                return new List<string>(new string[] { "mp1", "mp2", "mp3" });
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
            if (DoSaveProperties())
            {
                base.Modified = false;
                CheckButtonsState();
            }
        }

        private void pgProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            base.Modified = true;
            CheckButtonsState();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            DoShowProperties();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProperties();
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
                ID3FileInfo ii = new ID3FileInfo(item, deepLoad && (strItems.Count == 1));
                if (ii.IsValid)
                {
                    lii.Add(ii);
                }
            }

            FileAttributesBrowser.ProcessObjectAttributes(lii);

            pgProperties.SelectedObjects = lii.ToArray();
            base.Modified = false;

            CheckButtonsState();
        }

        private bool DoSaveProperties()
        {
            foreach(ID3FileInfo ii in pgProperties.SelectedObjects)
            {
                try
                {
                    ii.Save();
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }
            }
            return true;
        }

        private void CheckButtonsState()
        {
            btnSave.Enabled = base.Modified;
            btnUndo.Enabled = base.Modified;
            btnLaunchWizard.Visible =  (pgProperties.SelectedObjects.Length > 0);
        }

        private void btnLaunchWizard_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.Files = strItems;
            ID3WizardMain.Execute(FindForm(), task);
        }

        private void PerformTranslation()
        {
            btnLaunchWizard.Text = Translator.Translate("TXT_LAUNCH_WIZARD");
            btnSave.Text = Translator.Translate("TXT_APPLY");
            btnUndo.Text = Translator.Translate("TXT_UNDO");
        }
    }

    public static class ID3WizardMain
    {
        public static DialogResult Execute(Form parentForm, BackgroundTask initTask)
        {
            Type[] pages = new Type[]
                {
                    typeof(WizId3Step1Ctl),
                    typeof(WizId3Step2Ctl)
                };

            return WizardHostForm.CreateWizard("TXT_ID3WIZARD", pages, true, initTask, Resources.ID316.ToIcon());
        }

        public static DialogResult Execute(Form parentForm)
        {
            return Execute(parentForm, null);
        }
    }
}
