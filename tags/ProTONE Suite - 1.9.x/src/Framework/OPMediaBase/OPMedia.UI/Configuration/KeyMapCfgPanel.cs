using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;
using OPMedia.UI.Configuration;
using OPMedia.UI.Properties;
using OPMedia.Core;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.Controls;

namespace OPMedia.UI.Configuration
{
    public partial class KeyMapCfgPanel : BaseCfgPanel
    {
        public override Image Image
        {
            get
            {
                return Resources.Keyboard;
            }
        }

        LinkLabel _llEditKeys = null;

        public KeyMapCfgPanel()
            : base()
        {
            this.Title = "TXT_KEYMAP";
            InitializeComponent();

            this.HandleCreated += new EventHandler(KeyMapCfgPanel_Load);

            ThemeManager.SetFont(lvShortcuts, FontSizes.Small);

            _llEditKeys = new LinkLabel();
            _llEditKeys.Enabled = true;

            lvShortcuts.SubItemEditing += new OPMListView.EditableListViewEventHandler(lvShortcuts_SubItemEditing);
            lvShortcuts.Resize += new EventHandler(lvShortcuts_Resize);
        }

        void lvShortcuts_Resize(object sender, EventArgs e)
        {
            hdrCmdName.Width = 90;
            hdrCmdDesc.Width = 170;
            hdrAltkey.Width = hdrKey.Width =
                (lvShortcuts.Width - SystemInformation.VerticalScrollBarWidth - 90 - 175) / 2;
        }

        void lvShortcuts_SubItemEditing(object sender, ListViewSubItemEventArgs args)
        {
            if (args != null && args.Item != null && !args.Handled)
            {
                OPMShortcut cmd = (OPMShortcut)args.Item.Tag;
                if (ShortcutMapper.IsConfigurableShortcut(cmd))
                {
                    if (args.SubItemIndex == hdrKey.Index)
                    {
                        EditCommand(cmd, true);
                    }
                    else if (args.SubItemIndex == hdrAltkey.Index)
                    {
                        EditCommand(cmd, false);
                    }
                }
            }
        }

        void KeyMapCfgPanel_Load(object sender, EventArgs e)
        {
            DisplayKeys();
        }

        [EventSink(EventNames.KeymapChanged)]
        public void DisplayKeys()
        {
            try
            {
                User32.LockWindowUpdate(this.Handle);

                this.SuspendLayout();

                lvShortcuts.Items.Clear();

                List<OPMShortcut> shortcuts = new List<OPMShortcut>();
                for (OPMShortcut cmd = ShortcutMapper.CmdFirst; cmd < ShortcutMapper.CmdLast; cmd++)
                {
                    shortcuts.Add(cmd);
                }

                shortcuts.Sort(ShortcutsSorter);

                StringBuilder sb = new StringBuilder();

                foreach(OPMShortcut cmd in shortcuts)
                {
                    string cmdName = cmd.ToString();
                    string desc = Translator.Translate("TXT_" + cmdName.ToUpperInvariant());
                    KeysConverter kc = new KeysConverter();
                    string key = kc.ConvertToInvariantString(ShortcutMapper.KeyCommands[(int)cmd].KeyData);
                    string altKey = kc.ConvertToInvariantString(ShortcutMapper.AltKeyCommands[(int)cmd].KeyData);

                    ListViewItem item = new ListViewItem(cmdName.Replace("Cmd", string.Empty));

                    OPMListViewSubItem subItemDesc = new OPMListViewSubItem(item, desc);
                    OPMListViewSubItem subItemKey = null;
                    OPMListViewSubItem subItemAltKey = null;

                    if (ShortcutMapper.IsConfigurableShortcut(cmd))
                    {
                        subItemKey = new OPMListViewSubItem(_llEditKeys, item, key);
                        subItemAltKey = new OPMListViewSubItem(_llEditKeys, item, altKey);
                    }
                    else
                    {
                        subItemKey = new OPMListViewSubItem(item, key);
                        subItemAltKey = new OPMListViewSubItem(item, altKey);
                    }

                    item.SubItems.Add(subItemDesc);
                    item.SubItems.Add(subItemKey);
                    item.SubItems.Add(subItemAltKey);


                    item.Tag = cmd;
                    lvShortcuts.Items.Add(item);

                    sb.AppendLine("<tr>");

                    sb.AppendLine("<td>");
                    sb.AppendLine(item.Text);
                    sb.AppendLine("</td>");

                    sb.AppendLine("<td>");
                    sb.AppendLine(subItemDesc.Text);
                    sb.AppendLine("</td>");

                    sb.AppendLine("<td>");
                    sb.AppendLine(subItemKey.Text);
                    sb.AppendLine("</td>");

                    sb.AppendLine("<td>");
                    sb.AppendLine(subItemAltKey.Text);
                    sb.AppendLine("</td>");

                    sb.AppendLine("<td>");
                    sb.AppendLine("Yes");
                    sb.AppendLine("</td>");

                    sb.AppendLine("</tr>");
                }

                this.ResumeLayout();
            }
            finally
            {
                User32.LockWindowUpdate(IntPtr.Zero);
            }
        }

        private int ShortcutsSorter(OPMShortcut cmd1, OPMShortcut cmd2)
        {
            bool cfg1 = ShortcutMapper.IsConfigurableShortcut(cmd1);
            bool cfg2 = ShortcutMapper.IsConfigurableShortcut(cmd2);

            if (cfg1 != cfg2)
            {
                return cfg1.CompareTo(cfg2);
            }
            else
            {
                return cmd1.CompareTo(cmd2);
            }
        }

        private DialogResult EditCommand(OPMShortcut cmd, bool primary)
        {
            try
            {
                ShortcutMapper.EnableShortcutDispatch = false;
                return new KeyCommandEditor(cmd, primary).ShowDialog();
            }
            catch
            {
                return DialogResult.Cancel;
            }
            finally
            {
                ShortcutMapper.EnableShortcutDispatch = true;
            }
        }

        private void UpdateKey(OPMShortcut cmd)
        {
            KeysConverter kc = new KeysConverter();
            string key = kc.ConvertToInvariantString(ShortcutMapper.KeyCommands[(int)cmd].KeyData);
            string altKey = kc.ConvertToInvariantString(ShortcutMapper.AltKeyCommands[(int)cmd].KeyData);

            for (int i = 0; i < lvShortcuts.Items.Count; i++)
            {
                ListViewItem row = lvShortcuts.Items[i];
                if ((OPMShortcut)(row.Tag) == cmd)
                {
                    row.SubItems[hdrKey.Index].Text = key;
                    row.SubItems[hdrAltkey.Index].Text = altKey;
                }
            }
        }

        private void OnRestoreDefaults(object sender, EventArgs e)
        {
            if (MessageDisplay.Query("TXT_CONFIRM_RESTORE", "TXT_RESTOREDEFAULTS", 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ShortcutMapper.RestoreDefaults(true);
                DisplayKeys();
            }
        }
    }
}
