using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Preview;
using OPMedia.UI.ProTONE.SubtitleDownload;
using OPMedia.UI.Controls;
using OPMedia.Runtime.ProTONE.SubtitleDownload;
using OPMedia.Runtime.ProTONE.Rendering;
using OPMedia.Runtime.ProTONE.ExtendedInfo;
using SubtitleEditor.extension.DataLayer;
using OPMedia.Runtime.ProTONE.FfdShowApi;
using OPMedia.Core.GlobalEvents;
using OPMedia.Runtime.Shortcuts;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using System.Threading;
using SubtitleEditor.Rendering;
using OPMedia.Core;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;

namespace SubtitleEditor.Preview
{
    public partial class AddonPanel : PreviewBaseCtl
    {
        private OPMedia.UI.ProTONE.Controls.MediaPlayer.RenderingZone renderingZone1;
        private OPMTableLayoutPanel opmTableLayoutPanel1;
        private OPMedia.UI.ProTONE.Controls.MediaPlayer.RenderingPanel renderingPanel1;

        Subtitle _sub = null;
            
        public AddonPanel()
        {
            InitializeComponent();

            renderingPanel1.VolumeChanged += new ValueChangedEventHandler(renderingPanel1_VolumeChanged);
            renderingPanel1.PositionChanged += new ValueChangedEventHandler(renderingPanel1_PositionChanged);

            if (!DesignMode)
            {
                MediaRendererInstance.Instance.MediaRendererClock += new MediaRendererEventHandler(OnMediaRendererHeartbeat);
            }
        }

        public override List<string> HandledFileTypes
        {
            get
            {
                return SubtitleDownloader.AllowedSubtitleExtensions;
            }
        }

        protected override void DoBeginPreview(string item, object additionalData)
        {
            MediaRendererInstance.Instance.RenderPanel = renderingZone1;
            _sub = additionalData as Subtitle;
            if (_sub != null)
            {
                MediaRendererInstance.Instance.SetRenderFile(_sub.VideoFileInfo.Path);
                MediaRendererInstance.Instance.StartRenderer();
                MediaRendererInstance.Instance.PauseRenderer();
            }
        }

        protected override void DoEndPreview()
        {
            MediaRendererInstance.Instance.StopRenderer();
            _sub = null;
        }

        public override void Reload(object target)
        {
            SubtitleElement elem = target as SubtitleElement;
            if (elem != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach(string line in elem.Lines)
                {
                    sb.AppendLine(line);
                }

                double seekTime = elem.StartTime.TotalSeconds / MediaRendererInstance.Instance.DurationScaleFactor;

                MediaRendererInstance.Instance.ResumeRenderer(seekTime);
                MediaRendererInstance.Instance.DisplayOsdMessage(sb.ToString());
                Thread.Sleep(500);
                MediaRendererInstance.Instance.PauseRenderer();
            }
        }

        public void OnMediaRendererHeartbeat()
        {
            renderingPanel1.TotalSeconds = MediaRendererInstance.Instance.MediaLength;
            renderingPanel1.ElapsedSeconds = MediaRendererInstance.Instance.MediaPosition;
            renderingPanel1.ProjectedVolume = MediaRendererInstance.Instance.AudioVolume;
        }

        //[EventSink(RenderEventNames.FilterStateChanged)]
        //public void OnFilterStateChanged(FilterState oldState, string oldMedia, 
        //    FilterState newState, string newMedia)
        //{
        //}

        [EventSink(EventNames.ExecuteShortcut)]
        public void OnExecuteShortcut(OPMShortcutEventArgs args)
        {
            switch (args.cmd)
            {
                case OPMShortcut.CmdPlay:
                case OPMShortcut.CmdPause:
                case OPMShortcut.CmdStop:
                    break;

                default:
                    return;
            }

            switch (args.cmd)
            {
                case OPMShortcut.CmdPlay:
                    MediaRendererInstance.Instance.StartRenderer();
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdPause:
                    {
                        switch (MediaRendererInstance.Instance.FilterState)
                        {
                            case FilterState.Running:
                                MediaRendererInstance.Instance.PauseRenderer();
                                break;

                            case FilterState.Paused:
                                MediaRendererInstance.Instance.ResumeRenderer(MediaRendererInstance.Instance.MediaPosition);
                                break;
                        }
                    }
                    args.Handled = true;
                    break;

                case OPMShortcut.CmdStop:
                    MediaRendererInstance.Instance.StopRenderer();
                    args.Handled = true;
                    break;
            }
        }

        void renderingPanel1_PositionChanged(double val)
        {
            MediaRendererInstance.Instance.ResumeRenderer(val);
        }

        void renderingPanel1_VolumeChanged(double val)
        {
            MediaRendererInstance.Instance.AudioVolume = (int)val;
        }


        #region Auto-generated code
        private void InitializeComponent()
        {
            this.renderingPanel1 = new OPMedia.UI.ProTONE.Controls.MediaPlayer.RenderingPanel();
            this.renderingZone1 = new OPMedia.UI.ProTONE.Controls.MediaPlayer.RenderingZone();
            this.opmTableLayoutPanel1 = new OPMedia.UI.Controls.OPMTableLayoutPanel();
            this.opmTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderingPanel1
            // 
            this.renderingPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.renderingPanel1.BaseColor = System.Drawing.Color.Empty;
            this.renderingPanel1.BorderWidth = 0;
            this.renderingPanel1.CompactView = true;
            this.renderingPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderingPanel1.ElapsedSeconds = 0D;
            this.renderingPanel1.FontSize = OPMedia.UI.Themes.FontSizes.Large;
            this.renderingPanel1.HasBorder = true;
            this.renderingPanel1.Highlight = false;
            this.renderingPanel1.Location = new System.Drawing.Point(5, 250);
            this.renderingPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.renderingPanel1.Name = "renderingPanel1";
            this.renderingPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.renderingPanel1.ProjectedVolume = 5000;
            this.renderingPanel1.Size = new System.Drawing.Size(363, 78);
            this.renderingPanel1.TabIndex = 1;
            this.renderingPanel1.TimeScaleEnabled = true;
            this.renderingPanel1.TotalSeconds = 0D;
            this.renderingPanel1.VolumeScaleEnabled = true;
            // 
            // renderingZone1
            // 
            this.renderingZone1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderingZone1.FontSize = OPMedia.UI.Themes.FontSizes.Normal;
            this.renderingZone1.Location = new System.Drawing.Point(8, 8);
            this.renderingZone1.Name = "renderingZone1";
            this.renderingZone1.OverrideBackColor = System.Drawing.Color.Empty;
            this.renderingZone1.Size = new System.Drawing.Size(357, 239);
            this.renderingZone1.TabIndex = 0;
            // 
            // opmTableLayoutPanel1
            // 
            this.opmTableLayoutPanel1.ColumnCount = 1;
            this.opmTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.Controls.Add(this.renderingPanel1, 0, 1);
            this.opmTableLayoutPanel1.Controls.Add(this.renderingZone1, 0, 0);
            this.opmTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opmTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.opmTableLayoutPanel1.Name = "opmTableLayoutPanel1";
            this.opmTableLayoutPanel1.OverrideBackColor = System.Drawing.Color.Empty;
            this.opmTableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.opmTableLayoutPanel1.RowCount = 2;
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.opmTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.opmTableLayoutPanel1.Size = new System.Drawing.Size(373, 333);
            this.opmTableLayoutPanel1.TabIndex = 0;
            // 
            // AddonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.opmTableLayoutPanel1);
            this.Name = "AddonPanel";
            this.Size = new System.Drawing.Size(373, 333);
            this.opmTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

    }
}
