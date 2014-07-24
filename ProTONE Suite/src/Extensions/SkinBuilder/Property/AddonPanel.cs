using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Prop;
using OPMedia.UI;
using SkinBuilder.Themes;
using OPMedia.Core.Logging;
using SkinBuilder.Navigation;

namespace SkinBuilder.Property
{
    public partial class AddonPanel : PropBaseCtl
    {
        ThemeFile _themeFile = null;
        string _editedThemeName = null;
        string _editedThemeElementName = null;

        public AddonPanel()
        {
            InitializeComponent();
        }

        public override List<string> HandledFileTypes
        { get { return new List<string>(new string[] { "node" }); } }

        public override bool CanHandleFolders
        { get { return false; } }

        public override int  MaximumHandledItems
        { get { return 1; } }

        public override void SaveProperties()
        {
        }

        bool _raiseEvents = true;
        
        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            _themeFile = null;
            _editedThemeName = null;
            _editedThemeElementName = null;

            txtNodeName.ReadOnly = false;
            List<object> args = additionalData as List<object>;

            this.SuspendLayoutEx();
            pnlContent.SuspendLayoutEx();
            pnlThemeProperties.SuspendLayoutEx();

            try
            {
                _raiseEvents = false;

                lblIsDefault.Visible = chkIsDefault.Visible = false;

                pnlThemeProperties.Controls.Clear();
                pnlThemeProperties.RowStyles.Clear();

                if (args != null && args.Count > 0)
                {
                    _themeFile = args[0] as ThemeFile;
                    if (_themeFile != null)
                    {
                        KeyValuePair<string, Theme>? themePair = null;
                        KeyValuePair<string, string>? themeElementPair = null;

                        if (args.Count > 1 && args[1] is KeyValuePair<string, Theme>)
                        {
                            themePair = (KeyValuePair<string, Theme>)args[1];
                            _editedThemeName = themePair.Value.Key;
                        }

                        if (args.Count > 2 && args[2] is KeyValuePair<string, string>)
                        {
                            themeElementPair = (KeyValuePair<string, string>)args[2];
                            _editedThemeElementName = themeElementPair.Value.Key;
                        }

                        if (themeElementPair.HasValue)
                            DisplayThemeElementProperties(themeElementPair.Value);
                        else if (themePair.HasValue)
                            DisplayThemeProperties(themePair.Value);
                        else
                            DisplayThemeFileProperties();
                    }
                }
            }
            finally
            {
                pnlThemeProperties.ResumeLayoutEx();
                pnlContent.ResumeLayoutEx();
                this.ResumeLayoutEx();
                base.Modified = false;

                _raiseEvents = true;
            }
        }

        private void DisplayThemeFileProperties()
        {
            lblNodeName.Text = "Theme file path (read-only):";
            txtNodeName.Text = _themeFile.FileName;
            txtNodeName.ReadOnly = true;
        }

        private void DisplayThemeProperties(KeyValuePair<string, Theme> themePair)
        {
            lblNodeName.Text = "Theme name:";
            txtNodeName.Text = themePair.Key;

            lblIsDefault.Visible = chkIsDefault.Visible = true;
            chkIsDefault.Checked = themePair.Value.IsDefault;
        }

        private void DisplayThemeElementProperties(KeyValuePair<string, string> themeElementPair)
        {
            lblNodeName.Text = "Theme element name:";
            txtNodeName.Text = themeElementPair.Key;

            if (themeElementPair.Key.ToLowerInvariant().Contains("color"))
                AddChooserItem(themeElementPair.Key, themeElementPair.Value, typeof(SBColorChooser));
            else
            {
                int x = 0;
                bool isNumeric = int.TryParse(themeElementPair.Value, out x);

                AddChooserItem(themeElementPair.Key, themeElementPair.Value, 
                    isNumeric ? typeof(IntegerChooser) : typeof(StringChooser));
            }
        }

        
        public void AddChooserItem(string name, string value, Type type, bool enabled = true)
        {
            RowStyle rs = new RowStyle(SizeType.AutoSize, 30);
            int row = pnlThemeProperties.RowStyles.Add(rs);

            Control c = Activator.CreateInstance(type) as Control;
            if (c != null && c is IPropertyChooser)
            {
                c.Enabled = enabled;
                c.Dock = DockStyle.Fill;
                (c as IPropertyChooser).PropertyValue = value;
                (c as IPropertyChooser).PropertyChanged += new EventHandler(OnPropertyChanged);
                pnlThemeProperties.Controls.Add(c, 0, row);
            }
        }

        string _lastText = string.Empty;

        void OnPropertyChanged(object sender, EventArgs e)
        {
            if (_raiseEvents)
            {
                try
                {
                    if (_themeFile != null)
                    {
                        if (string.IsNullOrEmpty(txtNodeName.Text))
                        {
                            txtNodeName.Text = _lastText;
                            return;
                        }

                        _lastText = txtNodeName.Text;

                        if (sender == txtNodeName)
                        {
                            // Node name changed
                            // This can happen only for a theme node or a theme element node.

                            if (!string.IsNullOrEmpty(_editedThemeElementName) &&
                                !string.IsNullOrEmpty(_editedThemeName))
                            {
                                // We changed the name of a theme element node
                                string value = _themeFile.Themes[_editedThemeName].ThemeElements[_editedThemeElementName];
                                _themeFile.Themes[_editedThemeName].ThemeElements.Remove(_editedThemeElementName);
                                _themeFile.Themes[_editedThemeName].ThemeElements.Add(txtNodeName.Text, value);

                                NavigationReloadArguments args = new NavigationReloadArguments();
                                args.OldThemeElementName = _editedThemeElementName;
                                args.NewThemeElementName = txtNodeName.Text;
                                args.OldThemeName = args.NewThemeName = _editedThemeName;

                                _editedThemeElementName = txtNodeName.Text;
                                RaiseNavigationAction(OPMedia.Runtime.Addons.NavActionType.ActionReloadNavigation, null, args);
                            }
                            else if (!string.IsNullOrEmpty(_editedThemeName))
                            {
                                // We changed the name of a theme node
                                Theme theme = _themeFile.Themes[_editedThemeName];
                                theme.ThemeName = txtNodeName.Text;

                                _themeFile.Themes.Remove(_editedThemeName);
                                _themeFile.Themes.Add(txtNodeName.Text, theme);

                                NavigationReloadArguments args = new NavigationReloadArguments();
                                args.OldThemeName = _editedThemeName;
                                args.NewThemeName = txtNodeName.Text;

                                _editedThemeName = txtNodeName.Text;
                                RaiseNavigationAction(OPMedia.Runtime.Addons.NavActionType.ActionReloadNavigation, null, args);
                            }
                        }
                        else if (sender is IPropertyChooser)
                        {
                            // Node value changed. 
                            // This can happen only for a theme element node.

                            string value = (sender as IPropertyChooser).PropertyValue;

                            if (!string.IsNullOrEmpty(_editedThemeElementName) &&
                                !string.IsNullOrEmpty(_editedThemeName))
                            {
                                // We changed the value of a theme element node
                                _themeFile.Themes[_editedThemeName].ThemeElements[_editedThemeElementName] = value;

                                NavigationReloadArguments args = new NavigationReloadArguments();
                                args.NewThemeElementName = args.OldThemeElementName = _editedThemeElementName;
                                args.NewThemeName = args.OldThemeName = _editedThemeName;

                                RaiseNavigationAction(OPMedia.Runtime.Addons.NavActionType.ActionReloadNavigation, null, args);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }

                base.Modified = false;
            }
        }

        private void chkIsDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (_raiseEvents && _themeFile != null)
            {
                _themeFile.SetDefaultTheme(_editedThemeName);
                base.Modified = false;

                // Just update the dirty flag ;)
                RaiseNavigationAction(OPMedia.Runtime.Addons.NavActionType.ActionReloadNavigation, null, null);
            }
        }
    }

    public interface IPropertyChooser
    {
        string PropertyValue { get; set; }
        event EventHandler PropertyChanged;
    }
}
