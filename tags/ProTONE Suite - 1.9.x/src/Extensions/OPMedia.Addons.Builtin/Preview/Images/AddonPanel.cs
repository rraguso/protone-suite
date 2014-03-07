using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Preview;

namespace OPMedia.Addons.Builtin.Images
{
    public partial class AddonPanel : PreviewBaseCtl
    {
        public override string GetHelpTopic()
        {
            return "ImagesPreviewPanel";
        }

        public AddonPanel()
            : base()
        {
            InitializeComponent();
        }

        public override bool SupportAutoPreview
        {
            get
            {
                // Preview images automatically
                return true;
            }
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                // Image file types.
                List<string> fileTypes = new List<string>();
                fileTypes.Add("bmp");
                fileTypes.Add("jpg");
                fileTypes.Add("jpeg");
                fileTypes.Add("jpe");
                fileTypes.Add("jfif");
                fileTypes.Add("gif");
                fileTypes.Add("tif");
                fileTypes.Add("tiff");
                fileTypes.Add("png");
                fileTypes.Add("ico");
                return fileTypes;
            }
        }

        protected override void DoBeginPreview(string item, object additionalData)
        {
            this.Controls.Clear();
            try
            {
                PictureBox pb = new PictureBox();
                Image image = Image.FromFile(item);

                if (image.Size.Height < pb.Size.Height &&
                    image.Size.Width < pb.Size.Width)
                {
                    pb.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }

                pb.Dock = DockStyle.Fill;
                pb.Image = image;
                this.Controls.Add(pb);
            }
            catch
            {
            }
        }

        protected override void DoEndPreview()
        {
            this.Controls.Clear();
        }
    }
}
