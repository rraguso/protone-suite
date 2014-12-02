using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using OPMedia.UI.Themes;
using OPMedia.Core.Logging;

namespace OPMedia.UI.Controls
{
    public partial class OPMFontChooserCtl : OPMBaseControl
    {
        public event EventHandler FontChanged = null;

        public string Description 
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        private Font _selFont = ThemeManager.NormalFont;
        public Font SelectedFont 
        {
            get { return _selFont; }
            set { _selFont = value; }
        }

        public OPMFontChooserCtl()
        {
            InitializeComponent();

            for (int i = 0; i < 0x10; i++)
            {
                FontStyle fs = (FontStyle)i;
                cmbFontStyle.AddUniqueItem(fs);
            }

            for (int i = 1; i <= 100; i++)
                cmbFontSize.AddUniqueItem(i);

            foreach (FontCharSet fcs in Enum.GetValues(typeof(FontCharSet)))
                cmbCharset.AddUniqueItem(fcs);

            cmbCharset.Sorted = true;

            this.Load += new EventHandler(OnLoad);
        }

        void OnLoad(object sender, EventArgs e)
        {
            SelectItems();
            lblSampleText.Font = _selFont;
        }

        public void SubscribeEvents()
        {
            cmbFontFamily.SelectedIndexChanged += new EventHandler(OnFontFamilyChanged);
            cmbFontStyle.SelectedIndexChanged += new EventHandler(OnFontStyleChanged);
            cmbFontSize.SelectedIndexChanged += new EventHandler(OnFontSizeChanged);
            cmbCharset.SelectedIndexChanged += new EventHandler(OnCharsetChanged);
        }

        public void UnsubscribeEvents()
        {
            cmbFontFamily.SelectedIndexChanged -= new EventHandler(OnFontFamilyChanged);
            cmbFontStyle.SelectedIndexChanged -= new EventHandler(OnFontStyleChanged);
            cmbFontSize.SelectedIndexChanged -= new EventHandler(OnFontSizeChanged);
            cmbCharset.SelectedIndexChanged -= new EventHandler(OnCharsetChanged);
        }

        private void SelectItems()
        {
            try
            {
                UnsubscribeEvents();

                cmbFontFamily.SelectedItem = _selFont.FontFamily;
                cmbFontStyle.SelectedItem = _selFont.Style;
                cmbFontSize.SelectedItem = (int)_selFont.SizeInPoints;
                cmbCharset.SelectedItem = (FontCharSet)_selFont.GdiCharSet;

            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                SubscribeEvents();
            }
        }

        void OnFontFamilyChanged(object sender, EventArgs e)
        {
            RebuildSelectedFont();
        }

        void OnCharsetChanged(object sender, EventArgs e)
        {
            RebuildSelectedFont();
        }

        void OnFontSizeChanged(object sender, EventArgs e)
        {
            RebuildSelectedFont();
        }

        void OnFontStyleChanged(object sender, EventArgs e)
        {
            RebuildSelectedFont();
        }

        private void RebuildSelectedFont()
        {
            try
            {
                FontFamily ff = cmbFontFamily.SelectedItem as FontFamily;
                float emSize = (float)(int)cmbFontSize.SelectedItem;
                FontStyle fs = (FontStyle)cmbFontStyle.SelectedItem;
                byte charSet = (byte)cmbCharset.SelectedItem;

                Font f = new Font(ff, emSize, fs, GraphicsUnit.Point, charSet);

                _selFont = f;

                lblSampleText.Font = _selFont;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }

    public enum FontCharSet : byte
    {
        ANSI = 0,
        ARABIC = 178,
        BALTIC = 186,
        CHINESE_SIMPLIFIED_GB2312 = 134,
        CHINESE_TRADITIONAL_BIG5 = 136,
        DEFAULT = 1,
        EAST_EUROPE = 238,
        GREEK = 161,
        HEBREW = 177,
        KOREAN_HANGUL = 129,
        KOREAN_JOHAB = 130,
        MAC = 77,
        OEM = 255,
        RUSSIAN = 204,
        SHIFTJIS = 128,
        SYMBOL = 2,
        THAI = 222,
        TURKISH = 162,
        VIETNAMESE = 163,
    }
}
