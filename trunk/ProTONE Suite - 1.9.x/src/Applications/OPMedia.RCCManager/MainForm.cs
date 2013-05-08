using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using OPMedia.RCCManager.Properties;
using OPMedia.Core.Logging;
using OPMedia.UI;
using OPMedia.Core;
using System.ServiceProcess;
using OPMedia.Runtime.ServiceHelpers;
using OPMedia.ServiceHelper.RCCService;
using System.Reflection;
using System.IO;
using OPMedia.Core.TranslationSupport;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime;
using OPMedia.Runtime.Shortcuts;
using OPMedia.ServiceHelper.RCCService.InputPins;
using OPMedia.ServiceHelper.RCCService.OutputPins;
using OPMedia.UI.Dialogs;
using OPMedia.UI.Controls;
using System.Linq;
using OPMedia.UI.Controls.Dialogs;


namespace OPMedia.RCCManager
{
    public partial class MainForm : MainFrame
    {
        enum TreeImages : int
        {
            Nothing = 0,
            Remote,
            RemoteDisabled,
            Button,
            ButtonDisabled,
            Pin,
            PinDisabled,
            Buttons,
            ButtonsDisabled
        }

        bool _modified = false;
        private RCCServiceConfig _config = null;
        ThemedMessageBoxTarget _messageTarget = new ThemedMessageBoxTarget();

        ImageList ilTree = null;

        public MainForm() : base("TXT_APP_NAME")
        {
            InitializeComponent();

            ilTree = new ImageList();
            ilTree.TransparentColor = Color.White;
            ilTree.ColorDepth = ColorDepth.Depth32Bit;
            //ilTree.ImageSize = new System.Drawing.Size(16, 16);
            ilTree.Images.Add(Resources.Nothing);
            ilTree.Images.Add(Resources.Remote);
            ilTree.Images.Add(Resources.RemoteDisabled);
            ilTree.Images.Add(Resources.Button);
            ilTree.Images.Add(Resources.ButtonDisabled);
            ilTree.Images.Add(Resources.Pin);
            ilTree.Images.Add(Resources.PinDisabled);
            ilTree.Images.Add(Resources.Buttons);
            ilTree.Images.Add(Resources.ButtonsDisabled);
            tvRemotes.ImageList = ilTree;

            btnAddRemote.Image = Resources.Add;
            btnModifyRemote.Image = Resources.Modify;
            btnDeleteRemote.Image = Resources.Delete;
            btnApplyConfig.Image = Resources.Save;
            

            ttMain.SetSimpleToolTip(this.btnApplyConfig, Translator.Translate("TXT_APPLYTIP"), Resources.Save);

            btnApplyConfig.Enabled = false;

            if (!this.DesignMode)
            {
                this.Load += new EventHandler(MainForm_Load);
                this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            }

            Translator.TranslateToolStrip(cmsTree, DesignMode);
            Translator.TranslateToolStrip(msMain, DesignMode);

            msMain.BackColor = ThemeManager.BackColor;
        }

        protected override void OnThemeUpdatedInternal()
        {
            msMain.BackColor = ThemeManager.BackColor;
        }

        void ApplicationNotifier_ApplicationMessageBoxMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBoxIcon msgIcon = MessageBoxIcon.None;
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    msgIcon = MessageBoxIcon.Information;
                    break;
                case MessageBoxIcon.Warning:
                    msgIcon = MessageBoxIcon.Warning;
                    break;
                case MessageBoxIcon.Error:
                    msgIcon = MessageBoxIcon.Error;
                    break;
                case MessageBoxIcon.None:
                default:
                    msgIcon = MessageBoxIcon.None;
                    break;
            }

            MessageDisplay.Show(message, title, msgIcon);
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified)
            {
                DialogResult res = MessageDisplay.QueryWithCancel(Translator.Translate("TXT_SAVE_BEFORE_EXIT"),
                    Translator.Translate("TXT_APPLY_CFG"), MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    _config.WriteXml(_cfgPath);
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        protected override bool AllowCloseOnEnterOrEscape()
        {
            return false;
        }

        string _cfgPath = PathUtils.CurrentDir;
        void MainForm_Load(object sender, EventArgs e)
        {
            tsmiAbout.Text = Translator.Translate("TXT_ABOUT",
              Translator.Translate("TXT_APP_NAME"));
            tsmiAbout.ToolTipText = string.Empty;
            tsmiAbout.AutoToolTip = false;

            tvRemotes.Font = ThemeManager.LargeFont;
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            string asmPath = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(asmPath);
            _cfgPath = Path.Combine(folder, "RCCService.Config");

            _config = new RCCServiceConfig();
            _config.ReadXml(_cfgPath);

            _config.AcceptChanges();

            

            DisplayRemotes(false);
        }

        private void tmrUpdateUi_Tick(object sender, EventArgs e)
        {
            try
            {
                ServiceController sc = new ServiceController(Constants.RCCServiceShortName);
                btnApplyConfig.Enabled = true;
            }
            catch
            {
                btnApplyConfig.Enabled = false;
            }
        }

        private void DisplayRemotes()
        {
            DisplayRemotes(true);
        }

        private void DisplayRemotes(bool modified)
        {
            _modified = modified;

            string selectedNodeText = string.Empty;

            string indicator = _modified ? " [*]" : string.Empty;
            SetTitle(Translator.Translate("TXT_APP_NAME") + indicator);

            tvRemotes.SuspendLayout();

            try
            {
                List<TreeNode> treeNodes = new List<TreeNode>();

                Font remoteFont = ThemeManager.LargeFont;
                Font buttonFont = ThemeManager.SmallFont;

                foreach (RCCServiceConfig.RemoteControlRow remoteRow in _config.RemoteControl)
                {
                    TreeNode remoteNode = new TreeNode(Translator.Translate("TXT_DEVICENAME", remoteRow.RemoteName));
                    remoteNode.Tag = remoteRow;
                    remoteNode.NodeFont = remoteFont;
                    remoteNode.ImageIndex = remoteRow.Enabled ? (int)TreeImages.Remote : (int)TreeImages.RemoteDisabled;
                    remoteNode.SelectedImageIndex = remoteRow.Enabled ? (int)TreeImages.Remote : (int)TreeImages.RemoteDisabled;

                    TreeNode inputNode = new TreeNode(Translator.Translate("TXT_INPUTPIN", remoteRow.InputPinName,
                        string.IsNullOrEmpty(remoteRow.InputPinCfgData) ? string.Empty : "[ " + remoteRow.InputPinCfgData  + " ]"));

                    inputNode.Tag = remoteRow;
                    inputNode.NodeFont = buttonFont;
                    inputNode.ImageIndex = remoteRow.Enabled ? (int)TreeImages.Pin : (int)TreeImages.PinDisabled;
                    inputNode.SelectedImageIndex = remoteRow.Enabled ? (int)TreeImages.Pin : (int)TreeImages.PinDisabled;
                    remoteNode.Nodes.Add(inputNode);

                    TreeNode outputNode = new TreeNode(Translator.Translate("TXT_OUTPUTPIN", remoteRow.OutputPinName,
                        string.IsNullOrEmpty(remoteRow.OutputPinCfgData) ? string.Empty : "[ " + remoteRow.OutputPinCfgData + " ]"));

                    outputNode.Tag = remoteRow;
                    outputNode.NodeFont = buttonFont;
                    outputNode.ImageIndex = remoteRow.Enabled ? (int)TreeImages.Pin : (int)TreeImages.PinDisabled;
                    outputNode.SelectedImageIndex = remoteRow.Enabled ? (int)TreeImages.Pin : (int)TreeImages.PinDisabled;
                    remoteNode.Nodes.Add(outputNode);

                    var buttonRows = from btn in _config.RemoteButtons
                                        where btn.RemoteName == remoteRow.RemoteName
                                        select btn;

                    if (buttonRows != null && buttonRows.Count() > 0)
                    {
                        TreeNode buttonsNode = new TreeNode(Translator.Translate("TXT_BUTTONS"));
                        buttonsNode.Tag = remoteRow;
                        buttonsNode.NodeFont = buttonFont;
                        buttonsNode.ImageIndex = remoteRow.Enabled ? (int)TreeImages.Buttons : (int)TreeImages.ButtonsDisabled;
                        buttonsNode.SelectedImageIndex = remoteRow.Enabled ? (int)TreeImages.Buttons : (int)TreeImages.ButtonsDisabled;
                        remoteNode.Nodes.Add(buttonsNode);

                        foreach (RCCServiceConfig.RemoteButtonsRow buttonRow in buttonRows)
                        {
                            TreeNode buttonNode = new TreeNode(Translator.Translate("TXT_BUTTONNAME_FULL", buttonRow.ButtonName, 
                                buttonRow.InputData,
                                remoteRow.OutputPinName == (typeof(ProTONEOutputPin)).Name ?
                                CommandMapper.GetCommandDescription(buttonRow.OutputData) :
                                buttonRow.OutputData));

                            buttonNode.NodeFont = buttonFont;
                            buttonNode.ImageIndex = (remoteRow.Enabled && buttonRow.Enabled) ? (int)TreeImages.Button : (int)TreeImages.ButtonDisabled;
                            buttonNode.SelectedImageIndex = (remoteRow.Enabled && buttonRow.Enabled) ? (int)TreeImages.Button : (int)TreeImages.ButtonDisabled;
                            buttonNode.Tag = buttonRow;
                            buttonsNode.Nodes.Add(buttonNode);
                        }
                    }
                    else if (remoteRow.InputPinName == typeof(RemotingInputPin).Name &&
                        remoteRow.OutputPinName == typeof(ProTONEOutputPin).Name)
                    {
                        TreeNode buttonsNode = new TreeNode(Translator.Translate("TXT_NOBUTTONSREQUIRED"));
                        buttonsNode.ImageIndex = remoteRow.Enabled ? (int)TreeImages.Buttons : (int)TreeImages.ButtonsDisabled;
                        buttonsNode.SelectedImageIndex = remoteRow.Enabled ? (int)TreeImages.Buttons : (int)TreeImages.ButtonsDisabled;
                        buttonsNode.Tag = remoteRow;
                        buttonsNode.NodeFont = buttonFont;
                        remoteNode.Nodes.Add(buttonsNode);
                    }
                    else
                    {
                        TreeNode buttonsNode = new TreeNode(Translator.Translate("TXT_NO_BUTTONS_YET"));
                        buttonsNode.ImageIndex = remoteRow.Enabled ? (int)TreeImages.Buttons : (int)TreeImages.ButtonsDisabled;
                        buttonsNode.SelectedImageIndex = remoteRow.Enabled ? (int)TreeImages.Buttons : (int)TreeImages.ButtonsDisabled;
                        buttonsNode.Tag = remoteRow;
                        buttonsNode.NodeFont = buttonFont;
                        remoteNode.Nodes.Add(buttonsNode);
                    }

                    treeNodes.Add(remoteNode);
                }

                if (tvRemotes.SelectedNode != null)
                {
                    selectedNodeText = tvRemotes.SelectedNode.Text;
                }

                tvRemotes.Nodes.Clear();
                tvRemotes.Nodes.AddRange(treeNodes.ToArray());
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
            finally
            {
                tvRemotes.ExpandAll();
                ConstructTooltips();

                if (!string.IsNullOrEmpty(selectedNodeText))
                {
                    TreeNode node = tvRemotes.FindNode(selectedNodeText, false);
                    if (node != null)
                    {
                        tvRemotes.SelectedNode = node;
                    }
                }

                tvRemotes.ResumeLayout();
            }
        }

        private void btnAddRemote_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true; 
                
                TreeNode node = tvRemotes.SelectedNode;

                if (node != null && (node.ImageIndex == 4 || node.Tag is RCCServiceConfig.RemoteButtonsRow))
                {
                    try
                    {
                        while (true)
                        {
                            ButtonConfigForm dlg = new ButtonConfigForm();
                            dlg.Config = _config;
                            dlg.RemoteControl = (node.Tag is RCCServiceConfig.RemoteButtonsRow) ?
                                _config.RemoteControl.FindByRemoteName((node.Tag as RCCServiceConfig.RemoteButtonsRow).RemoteName) :
                                node.Tag as RCCServiceConfig.RemoteControlRow;

                            DialogResult res = dlg.ShowDialog(this);
                            if (res == DialogResult.OK || res == DialogResult.Retry)
                            {
                                _config.RemoteButtons.AddRemoteButtonsRow(dlg.Button);
                                _config.RemoteButtons.AcceptChanges();
                                DisplayRemotes();
                            }

                            if (res != DialogResult.Retry)
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorDispatcher.DispatchError(ex);
                    }
                }
                else
                {
                    RemoteControlConfigForm dlg = new RemoteControlConfigForm();
                    dlg.Config = _config;

                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        _config.RemoteControl.AddRemoteControlRow(dlg.RemoteControl);
                        _config.RemoteControl.AcceptChanges();
                        DisplayRemotes();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            UseWaitCursor = false;
            BringToFront();
        }

        private void btnModifyRemote_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true; 

                TreeNode node = tvRemotes.SelectedNode;
                if (node != null)
                {
                    if (node.Tag is RCCServiceConfig.RemoteControlRow)
                    {
                        RemoteControlConfigForm dlg = new RemoteControlConfigForm();
                        dlg.Config = _config;
                        dlg.RemoteControl = node.Tag as RCCServiceConfig.RemoteControlRow;

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            dlg.RemoteControl.AcceptChanges();
                            DisplayRemotes();
                        }
                    }
                    else if (node.Tag is RCCServiceConfig.RemoteButtonsRow)
                    {
                        ButtonConfigForm dlg = new ButtonConfigForm();
                        dlg.Button = node.Tag as RCCServiceConfig.RemoteButtonsRow;
                        dlg.Config = _config;
                        dlg.RemoteControl = _config.RemoteControl.FindByRemoteName(dlg.Button.RemoteName);

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            dlg.Button.AcceptChanges();
                            DisplayRemotes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

            UseWaitCursor = false;
            BringToFront();
        }

        private void btnDeleteRemote_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = tvRemotes.SelectedNode;
                if (node != null)
                {
                    if (node.Tag is RCCServiceConfig.RemoteControlRow &&
                    MessageDisplay.Query(Translator.Translate("TXT_CONFIRMDELETEREMOTE"),
                        Translator.Translate("TXT_CONFIRM"), MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _config.RemoteControl.RemoveRemoteControlRow(node.Tag as RCCServiceConfig.RemoteControlRow);
                        _config.RemoteControl.AcceptChanges();
                        DisplayRemotes();
                    }
                    else if (node.Tag is RCCServiceConfig.RemoteButtonsRow &&
                    MessageDisplay.Query(Translator.Translate("TXT_CONFIRMDELETEBUTTON"),
                        Translator.Translate("TXT_CONFIRM"), MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _config.RemoteButtons.RemoveRemoteButtonsRow(node.Tag as RCCServiceConfig.RemoteButtonsRow);
                        _config.RemoteButtons.AcceptChanges();
                        DisplayRemotes();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }

        }

        private void btnApplyConfig_Click(object sender, EventArgs e)
        {
            _config.WriteXml(_cfgPath);
            ReadFromFile();
        }

        private void tvRemotes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnModifyRemote.Enabled = tvRemotes.SelectedNode != null;
            btnDeleteRemote.Enabled = tvRemotes.SelectedNode != null;
            ConstructTooltips();
            
        }

        private void ConstructTooltips()
        {
            if (tvRemotes.SelectedNode != null)
            {
                if (tvRemotes.SelectedNode.Tag is RCCServiceConfig.RemoteButtonsRow)
                {
                    this.ttMain.SetSimpleToolTip(this.btnAddRemote, Translator.Translate("TXT_ADD_BUTTON"), Resources.Add);
                    this.ttMain.SetSimpleToolTip(this.btnDeleteRemote, Translator.Translate("TXT_DEL_BUTTON"), Resources.Delete);
                    this.ttMain.SetSimpleToolTip(this.btnModifyRemote, Translator.Translate("TXT_MOD_BUTTON"), Resources.Modify);
                }
                else
                {
                    if (tvRemotes.SelectedNode.ImageIndex == -2)
                    {
                        this.ttMain.SetSimpleToolTip(this.btnAddRemote, Translator.Translate("TXT_ADD_BUTTON"), Resources.Add);
                    }
                    else
                    {
                        this.ttMain.SetSimpleToolTip(this.btnAddRemote, Translator.Translate("TXT_ADD_DEVICE"), Resources.Add);
                    }

                    this.ttMain.SetSimpleToolTip(this.btnDeleteRemote, Translator.Translate("TXT_DEL_DEVICE"), Resources.Delete);
                    this.ttMain.SetSimpleToolTip(this.btnModifyRemote, Translator.Translate("TXT_MOD_DEVICE"), Resources.Modify);
                }
            }
            else
            {
                this.ttMain.SetSimpleToolTip(this.btnAddRemote, Translator.Translate("TXT_ADD_DEVICE"), Resources.Add);
            }
        }


        private void OnMenuAdd(object sender, EventArgs e)
        {
            btnAddRemote_Click(sender, e);
        }

        private void OnMenuChange(object sender, EventArgs e)
        {
            btnModifyRemote_Click(sender, e);
        }

        private void OnMenuDelete(object sender, EventArgs e)
        {
            btnDeleteRemote_Click(sender, e);
        }

        private void OnMenuEnable(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = tvRemotes.SelectedNode;
                if (node != null)
                {
                    if (node.Tag is RCCServiceConfig.RemoteControlRow)
                    {
                        bool enabled = (node.Tag as RCCServiceConfig.RemoteControlRow).Enabled;
                        (node.Tag as RCCServiceConfig.RemoteControlRow).Enabled = !enabled;
                        (node.Tag as RCCServiceConfig.RemoteControlRow).AcceptChanges();
                        DisplayRemotes();
                    }
                    else if (node.Tag is RCCServiceConfig.RemoteButtonsRow)
                    {
                        bool enabled = (node.Tag as RCCServiceConfig.RemoteButtonsRow).Enabled;
                        (node.Tag as RCCServiceConfig.RemoteButtonsRow).Enabled = !enabled;
                        (node.Tag as RCCServiceConfig.RemoteButtonsRow).AcceptChanges();
                        DisplayRemotes();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private void cmsTree_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                TreeNode node = tvRemotes.SelectedNode;
                if (node != null)
                {
                    if (node.Tag is RCCServiceConfig.RemoteControlRow)
                    {
                        bool enabled = (node.Tag as RCCServiceConfig.RemoteControlRow).Enabled;
                        tsmiEnable.Text = Translator.Translate(enabled ? "TXT_DISABLE" : "TXT_ENABLE");
                    }
                    else if (node.Tag is RCCServiceConfig.RemoteButtonsRow)
                    {
                        bool enabled = (node.Tag as RCCServiceConfig.RemoteButtonsRow).Enabled;
                        tsmiEnable.Text = Translator.Translate(enabled ? "TXT_DISABLE" : "TXT_ENABLE");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private void msEdit_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = tvRemotes.SelectedNode;
                if (node != null)
                {
                    if (node.Tag is RCCServiceConfig.RemoteControlRow)
                    {
                        bool enabled = (node.Tag as RCCServiceConfig.RemoteControlRow).Enabled;
                        tsmiMainEnable.Text = Translator.Translate(enabled ? "TXT_DISABLE" : "TXT_ENABLE");
                    }
                    else if (node.Tag is RCCServiceConfig.RemoteButtonsRow)
                    {
                        bool enabled = (node.Tag as RCCServiceConfig.RemoteButtonsRow).Enabled;
                        tsmiMainEnable.Text = Translator.Translate(enabled ? "TXT_DISABLE" : "TXT_ENABLE");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private void tvRemotes_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        tvRemotes.SelectedNode = e.Node;
                        // show the menu a little to the right, to ease up navigation
                        e.Location.Offset(30, 0);
                        cmsTree.Show(e.Location);
                        break;
                    default:
                        // ignore
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorDispatcher.DispatchError(ex);
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void tsmiImportMerge_Click(object sender, EventArgs e)
        {
            OPMOpenFileDialog dlg = CommonDialogHelper.NewOPMOpenFileDialog();
            dlg.InitialDirectory = Path.Combine(Environment.CurrentDirectory, "Templates\\RemoteControl");
            dlg.Filter = Translator.Translate("TXT_CONFIG_FILES_FILTER");
            dlg.Title = Translator.Translate("TXT_IMPORT_PARTIAL");

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RCCServiceConfig config = new RCCServiceConfig();
                config.ReadXml(dlg.FileName);
                config.AcceptChanges();

                _config.Merge(config);

                DisplayRemotes(true);
            }
        }

        private void tsmiImportReplace_Click(object sender, EventArgs e)
        {
            OPMOpenFileDialog dlg = CommonDialogHelper.NewOPMOpenFileDialog();
            dlg.InitialDirectory = Path.Combine(Environment.CurrentDirectory, "Templates\\RemoteControl");
            dlg.Filter = Translator.Translate("TXT_CONFIG_FILES_FILTER");
            dlg.Title = Translator.Translate("TXT_IMPORT_FULL");

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _config = new RCCServiceConfig();
                _config.ReadXml(dlg.FileName);
                _config.AcceptChanges();

                DisplayRemotes(true);
            }
        }

        private void tsmiExportPartial_Click(object sender, EventArgs e)
        {
            OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
            dlg.Filter = Translator.Translate("TXT_CONFIG_FILES_FILTER");
            dlg.DefaultExt = "config";
            dlg.Title = Translator.Translate("TXT_EXPORT_PARTIAL");

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // TODO: partial export
            }
        }

        private void tsmiExportFull_Click(object sender, EventArgs e)
        {
            OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
            dlg.Filter = Translator.Translate("TXT_CONFIG_FILES_FILTER");
            dlg.DefaultExt = "config";
            dlg.Title = Translator.Translate("TXT_EXPORT_FULL");

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _config.WriteXml(dlg.FileName);
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageDisplay.ShowAboutBox();
        }

        private void tXTAPPHELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShortcutMapper.DispatchCommand(OPMShortcut.CmdOpenHelp);
        }

        private void tXTSHOWLOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogFileConsoleDialog.ShowLogConsole();
        }

        private void tvRemotes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            btnModifyRemote_Click(sender, e);
        }

        

    }
}