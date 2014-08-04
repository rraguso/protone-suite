using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPMedia.UI.Themes;
using System.Security;
using System.Drawing.Design;
using System.Security.Permissions;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using OPMedia.UI.Generic;
using OPMedia.UI.Controls;
using OPMedia.Core.TranslationSupport;

using System.IO;
using TagLib;
using OPMedia.Core;
using OPMedia.UI.ProTONE.Properties;
using System.Drawing.Imaging;
using OPMedia.UI.Controls.Dialogs;

namespace OPMedia.UI.ProTONE.Dialogs
{
    public partial class ID3ArtworkDlg : ThemeForm
    {
        ID3ArtworkInfo _id3ArtworkInfo = null;
        ToolTip _tip = new ToolTip();

        OPMComboBox _cmbImageType = null;
        MultilineEditTextBox _txtDescription = null;

        ImageList _ilDummy = null;

        public ID3ArtworkInfo ID3ArtworkInfo
        {
            get
            {
                return _id3ArtworkInfo;
            }

            set
            {
                _id3ArtworkInfo = value;
            }
        }

        public ID3ArtworkDlg(ID3ArtworkInfo id3ArtworkInfo)
            : base("TXT_EDITID3ARTWORK")
        {
            _id3ArtworkInfo = id3ArtworkInfo.Clone();
            InitializeComponent();

            pbAdd.Text = pbDelete.Text = string.Empty;
            pbAdd.Image = OPMedia.UI.Properties.Resources.Add;
            pbDelete.Image = OPMedia.UI.Properties.Resources.Del;

            btnBrowse.Image = Resources.btnLoadPlaylist;
            btnSave.Image = Resources.btnSavePlaylist;

            _tip.SetToolTip(pbAdd, Translator.Translate("TXT_ADD"));
            _tip.SetToolTip(pbDelete, Translator.Translate("TXT_DELETE"));

            lblSep.OverrideBackColor = ThemeManager.GradientNormalColor1;

            _ilDummy = new ImageList();
            _ilDummy.ImageSize = new System.Drawing.Size(50, 50);

            lvPictures.StateImageList = _ilDummy;

            _cmbImageType = new OPMComboBox();
            _cmbImageType.Items.Clear();
            _cmbImageType.Height = 50;
            foreach (object obj in Enum.GetValues(typeof(PictureType)))
            {
                _cmbImageType.Items.Add(obj.ToString());
            }

            _txtDescription = new MultilineEditTextBox();

            lvPictures.RegisterEditControl(_cmbImageType);
            lvPictures.RegisterEditControl(_txtDescription);

            this.Load += new EventHandler(ID3ArtworkDlg_Load);
        }

        void ID3ArtworkDlg_Load(object sender, EventArgs e)
        {
            lvPictures_Resize(sender, e);
            LoadPictures();
            
            pbPicture.Image = pbPicture.ErrorImage;
            pbPicture.SizeMode = PictureBoxSizeMode.CenterImage;

            pbDelete.Visible = false;

            if (lvPictures.Items.Count > 0)
            {
                lvPictures.SelectedItems.Clear();
                lvPictures.Items[0].Selected = true;
            }
        }

        private void LoadPictures()
        {
            lblItem.Text = _id3ArtworkInfo.FileName;

            lvPictures.Items.Clear();

            foreach(PictureInfo pi in _id3ArtworkInfo.ArtworkImages)
            {
                ListViewItem lvi = new ListViewItem();

                OPMListViewSubItem subItem = new OPMListViewSubItem(_cmbImageType, lvi, pi.PictureType.ToString());
                subItem.ReadOnly = false;
                lvi.SubItems.Add(subItem);

                subItem = new OPMListViewSubItem(_txtDescription, lvi, pi.Description);
                subItem.ReadOnly = false;
                lvi.SubItems.Add(subItem);

                lvi.SubItems[colImage.Index].Tag = new ExtendedSubItemDetail(pi.Picture, "");

                lvi.Tag = pi;

                lvPictures.Items.Add(lvi);
            }
        }

        private void lvPictures_SelectionChanged(object sender, EventArgs e)
        {
            pbPicture.Image = pbPicture.ErrorImage;
            pbPicture.SizeMode = PictureBoxSizeMode.CenterImage;

            PictureInfo pi = null;

            if (lvPictures.SelectedItems.Count > 0)
            {
                pi = lvPictures.SelectedItems[0].Tag as PictureInfo;
                if (pi != null)
                {
                    pbPicture.Image = pi.Picture;
                    pbPicture.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            pbDelete.Visible = (pi != null);
        }

        private void pbPicture_DoubleClick(object sender, EventArgs e)
        {
            if (lvPictures.SelectedItems.Count > 0)
            {
                PictureInfo pi = lvPictures.SelectedItems[0].Tag as PictureInfo;
                if (pi != null)
                {
                    OPMOpenFileDialog dlg = CommonDialogHelper.NewOPMOpenFileDialog();
                    dlg.Filter = "All image files|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.tif;*.tiff;*.png;*.ico;||";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Image img = null;
                        try
                        {
                            img = Image.FromFile(dlg.FileName);
                        }
                        catch
                        {
                            img = null;
                        }

                        if (img != null)
                        {
                            pi.Picture = new Bitmap(ImageProvider.ScaleImage(img, new Size(200, 150), false));
                            pi.MimeType = "image/" + PathUtils.GetExtension(dlg.FileName);

                            pbPicture.Image = pi.Picture;
                            pbPicture.SizeMode = PictureBoxSizeMode.Zoom;

                            lvPictures.SelectedItems[0].SubItems[colImage.Index].Tag = new ExtendedSubItemDetail(pi.Picture, "");
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lvPictures.SelectedItems.Count > 0)
            {
                PictureInfo pi = lvPictures.SelectedItems[0].Tag as PictureInfo;
                if (pi != null)
                {
                    OPMSaveFileDialog dlg = CommonDialogHelper.NewOPMSaveFileDialog();
                    dlg.Filter = "All image files|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.tif;*.tiff;*.png;*.ico;||";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ImageFormat imgFormat = ImageFormat.Bmp;
                        switch(PathUtils.GetExtension(dlg.FileName).ToLowerInvariant())
                        {
                            case "jpg":
                            case "jpeg":
                            case "jpe":
                                imgFormat = ImageFormat.Jpeg;
                                break;

                            case "gif":
                                imgFormat = ImageFormat.Gif;
                                break;

                            case "tif":
                            case "tiff":
                                imgFormat = ImageFormat.Tiff;
                                break;

                            case "png":
                                imgFormat = ImageFormat.Png;
                                break;

                            case "ico":
                                imgFormat = ImageFormat.Icon;
                                break;

                            case "bmp":
                            default:
                                imgFormat = ImageFormat.Bmp;
                                break;
                        }

                        pi.Picture.Save(dlg.FileName, imgFormat);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PictureInfo pi = new PictureInfo(new Bitmap(pbPicture.ErrorImage), PictureType.Other, string.Empty, "image/bmp");
            _id3ArtworkInfo.ArtworkImages.Add(pi);
            LoadPictures();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvPictures.SelectedItems.Count > 0)
            {
                PictureInfo pi = lvPictures.SelectedItems[0].Tag as PictureInfo;
                if (pi != null)
                {
                    _id3ArtworkInfo.ArtworkImages.Remove(pi);
                    LoadPictures();
                }
            }
        }

        
        private void lvPictures_SubItemEdited(object sender, ListViewSubItemEventArgs args)
        {
            if (lvPictures.SelectedItems.Count > 0)
            {
                PictureInfo pi = lvPictures.SelectedItems[0].Tag as PictureInfo;
                if (pi != null)
                {
                    string val = args.SubItem.Text;

                    if (args.SubItemIndex == colDescription.Index)
                    {
                        pi.Description = val;
                    }
                    else if (args.SubItemIndex == colImageType.Index)
                    {
                        if (!string.IsNullOrEmpty(val))
                        {
                            pi.PictureType = (PictureType)Enum.Parse(typeof(PictureType), val);
                        }
                    }
                }
            }
        }

        private void lvPictures_Resize(object sender, EventArgs e)
        {
            colImage.Width = 55;
            colImageType.Width = 80;
            colDescription.Width = lvPictures.Width - SystemInformation.VerticalScrollBarWidth - 140;
        }

        

    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class ID3ArtworkPropertyBrowser : UITypeEditor
    {
        public ID3ArtworkPropertyBrowser()
            : base()
        {
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (value is ID3ArtworkInfo)
            {
                ID3ArtworkDlg dlg = new ID3ArtworkDlg(value as ID3ArtworkInfo);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    value = dlg.ID3ArtworkInfo;
                }
            }

            return value;
        }
    }
}
