using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Wizards;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core;
using OPMedia.Runtime;
using OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard.Controls;
using OPMedia.Core.Utilities;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    public partial class WizTagStep2Ctl : WizardBaseCtl
    {
        private int selectedPanel = -1;

        private List<EditPanelBase> panels =
            new List<EditPanelBase>();


        public WizTagStep2Ctl()
        {
            InitializeComponent();

            AddPanel(new MultiRenamePanel());
            AddPanel(new TagEditorPanel());
            AddPanel(new FSTagEditorPanel());

            cmbEditType.SelectedIndex = 0;

            cmbWordCasing.Items.Add(Translator.Translate("TXT_" + WordCasing.KeepCase.ToString().ToUpperInvariant()));
            cmbWordCasing.Items.Add(Translator.Translate("TXT_" + WordCasing.SentenceCase.ToString().ToUpperInvariant()));
            cmbWordCasing.Items.Add(Translator.Translate("TXT_" + WordCasing.CapitalizeWords.ToString().ToUpperInvariant()));
        }

        protected override void OnPageEnter_Finishing()
        {
            BkgTask = panels[selectedPanel].GetTask();
        }

        protected override void OnPageEnter_MovingBack()
        {
            Display();
        }

        protected override void OnPageEnter_MovingNext()
        {
            Display();
        }

        private void Display()
        {
            cmbWordCasing.SelectedIndex = (int)(BkgTask as Task).WordCasing;
            ShowPanel(selectedPanel);


        }

        private void AddPanel(EditPanelBase panel)
        {
            cmbEditType.Items.Add(Translator.Translate(panel.Title));
            panels.Add(panel);
            panel.Visible = false;
            panel.Dock = DockStyle.Fill;
            pnlEdit.Controls.Add(panel);
        }

        private void ShowPanel(int index)
        {
            foreach (Control ctl in pnlEdit.Controls)
            {
                ctl.Visible = false;
            }

            EditPanelBase panel = panels[index];
            if (panel != null)
            {
                Translator.TranslateControl(panel, false);
                panel.Visible = true;
                panel.SetTask(BkgTask as Task);
            }

            selectedPanel = index;
        }

        private void cmbEditType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedPanel >= 0)
            {
                BkgTask = panels[selectedPanel].GetTask();
            }

            ShowPanel(cmbEditType.SelectedIndex);
        }

        private void cmbWordCasing_SelectedIndexChanged(object sender, EventArgs e)
        {
            (BkgTask as Task).WordCasing = (WordCasing)cmbWordCasing.SelectedIndex;
        }

        private void lblPreview_LinkClicked(object sender, EventArgs e)
        {
            new PreviewForm(BkgTask as Task).ShowDialog();
        }
    }
}
