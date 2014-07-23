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

namespace SkinBuilder.Property
{
    public partial class AddonPanel : PropBaseCtl
    {
        ThemeFile _themeFile = null;
        string _themeName = string.Empty;

        public AddonPanel()
        {
            InitializeComponent();
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                return new List<string>(new string[] { "thm" });
            }
        }

        public override bool CanHandleFolders
        {
            get
            {
                return false;
            }
        }

        public override int  MaximumHandledItems
        {
	        get 
	        { 
		         return 1;
	        }
        }

        public override void SaveProperties()
        {
            if (_themeFile != null && _themeFile.Themes != null && _themeFile.Themes.Count > 0)
            {
                if (!string.IsNullOrEmpty(_themeName) && _themeFile.Themes.ContainsKey(_themeName))
                {
                    Theme theme = _themeFile.Themes[_themeName];
                    if (theme != null)
                    {
                        foreach (Control c in pnlThemeProperties.Controls)
                        {
                            IPropertyChooser pc = c as IPropertyChooser;
                            if (pc != null)
                            {
                                if (pc.PropertyName == "Name")
                                {
                                    //theme.ThemeName = pc.PropertyName;
                                }
                                else if (pc.PropertyName == "IsDefault")
                                {
                                    bool val = false;
                                    if (bool.TryParse(pc.PropertyValue, out val) == false)
                                        val = false;
                                    theme.IsDefault = val;
                                }
                                else
                                {
                                    if (theme.ThemeElements.ContainsKey(pc.PropertyName))
                                    {
                                        theme.ThemeElements[pc.PropertyName] = pc.PropertyValue;
                                    }
                                    else
                                    {
                                        theme.ThemeElements.Add(pc.PropertyName, pc.PropertyValue);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        public override void ShowProperties(List<string> strItems, object additionalData)
        {
            _themeName = string.Empty;
            _themeFile = additionalData as ThemeFile;

            try
            {
                pnlScrollable.Visible = false;
                pnlScrollable.SuspendLayoutEx();
                pnlThemeProperties.SuspendLayoutEx();

                pnlThemeProperties.Controls.Clear();
                pnlThemeProperties.RowStyles.Clear();

                if (pnlThemeProperties.Controls.Count > 0)
                {
                    foreach (Control c in pnlThemeProperties.Controls)
                    {
                        if (c is IPropertyChooser)
                        {
                            (c as IPropertyChooser).PropertyChanged -= new PropertyChangedHandler(OnPropertyChanged);
                        }
                    }
                }

                if (_themeFile != null && _themeFile.Themes != null && _themeFile.Themes.Count > 0)
                {
                    if (strItems != null && strItems.Count > 0 && !string.IsNullOrEmpty(strItems[0]))
                    {
                        _themeName = strItems[0].Replace(".thm", string.Empty);
                    }

                    if (!string.IsNullOrEmpty(_themeName) && _themeFile.Themes.ContainsKey(_themeName))
                    {
                        Theme theme = _themeFile.Themes[_themeName];

                        AddChooserItem("Name", _themeName, typeof(StringChooser), false);
                        AddChooserItem("IsDefault", theme.IsDefault.ToString(), typeof(BooleanChooser));

                        var nonColorElements = from kvp in theme.ThemeElements
                                               where kvp.Key.ToLowerInvariant().Contains("color") == false
                                               select kvp;

                        foreach (var x in nonColorElements)
                            AddChooserItem(x.Key, x.Value, typeof(IntegerChooser));

                        var colorElements = from kvp in theme.ThemeElements
                                               where kvp.Key.ToLowerInvariant().Contains("color")
                                               select kvp;

                        foreach (var x in colorElements)
                            AddChooserItem(x.Key, x.Value, typeof(DropDownColorChooser));
                    }
                }

                if (pnlThemeProperties.Controls.Count > 0)
                {
                    foreach (Control c in pnlThemeProperties.Controls)
                    {
                        if (c is IPropertyChooser)
                        {
                            (c as IPropertyChooser).PropertyChanged += new PropertyChangedHandler(OnPropertyChanged);
                        }
                    }
                }
            }
            finally
            {
                pnlThemeProperties.ResumeLayoutEx();
                pnlScrollable.ResumeLayoutEx();
                pnlScrollable.Visible = true;
                base.Modified = false;
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
                (c as IPropertyChooser).PropertyName = name;
                (c as IPropertyChooser).PropertyValue = value;
                pnlThemeProperties.Controls.Add(c, 0, row);
            }
        }

        void OnPropertyChanged(IPropertyChooser sender, string oldName, string newName)
        {
            base.Modified = true;
        }
    }

    public delegate void PropertyChangedHandler(IPropertyChooser sender, string oldName, string newName);

    public interface IPropertyChooser
    {
        string PropertyName { get; set; }
        string PropertyValue { get; set; }
        event PropertyChangedHandler PropertyChanged;
    }
}
