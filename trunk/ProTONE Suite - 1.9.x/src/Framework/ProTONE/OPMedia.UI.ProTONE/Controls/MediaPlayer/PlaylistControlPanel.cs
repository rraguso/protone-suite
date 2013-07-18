using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Controls;
using OPMedia.Core.Logging;
using OPMedia.Runtime.Shortcuts;
using OPMedia.UI.Themes;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Core;

using OPMedia.Runtime.ProTONE;

using OPMedia.UI.Generic;
using OPMedia.Core.GlobalEvents;
using OPMedia.UI.ProTONE.Properties;

namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public enum PlaylistButtonType
    {
        MoveDown,
        MoveUp,
        Delete,
        Clear,
        LoadPlaylist,
        SavePlaylist,
    }

    public enum PlaylistButtonState
    {
        Hidden,
        Disabled,
        Enabled
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PlaylistButtonData
    {
        public PlaylistButtonType buttonType;
        public PlaylistButtonState buttonState;
        public OPMShortcut buttonCommand;
        public string buttonTooltip;
        public Image buttonImage;
    }

    public partial class PlaylistControlPanel : OPMBaseControl
    {
        OPMToolTip _tip = new OPMToolTip();

        public new Color OverrideBackColor
        {
            get { return base.OverrideBackColor; }
            set
            {
                base.OverrideBackColor = value;
                pnlButtons.OverrideBackColor = value;
            }
        }

        public void SetButtonsData(PlaylistButtonData[] buttonDataArray, bool stateOnly)
        {
            this.SuspendLayout();
            foreach (PlaylistButtonData buttonData in buttonDataArray)
            {
                string buttonName = string.Format("btn{0}", buttonData.buttonType);
                OPMButton button = pnlButtons.Controls[buttonName] as OPMButton;
                if (button != null)
                {
                    button.Text = string.Empty;
                    button.Visible = (buttonData.buttonState != PlaylistButtonState.Hidden);
                    button.Enabled = (buttonData.buttonState != PlaylistButtonState.Disabled);

                    if (!stateOnly)
                    {
                        Size sz = new Size(button.Width - 7, button.Height - 7);
                        button.Image = ImageProvider.ScaleImage(buttonData.buttonImage, sz, true);
                        button.Tag = buttonData;

                        _tip.SetSimpleToolTip(button, buttonData.buttonTooltip, buttonData.buttonImage);
                    }
                }
            }
            this.ResumeLayout();
        }

        Timer tmrUpdateUi = new Timer();

        public PlaylistControlPanel()
            : base()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                SetDefaultButtonsData();
            }
        }

        [EventSink(EventNames.PerformTranslation)]
        public void OnPerformTranslation()
        {
            SetDefaultButtonsData();
        }

        [EventSink(EventNames.KeymapChanged)]
        public void OnKeymapChanged()
        {
            SetDefaultButtonsData();
        }

        public void SetDefaultButtonsData()
        {
            PlaylistButtonData[] buttonDataArray =
                new PlaylistButtonData[Enum.GetValues(typeof(PlaylistButtonType)).Length];

            foreach (PlaylistButtonType type in Enum.GetValues(typeof(PlaylistButtonType)))
            {
                string cmdName = string.Format("Cmd{0}", type.ToString());
                OPMShortcut cmd = (OPMShortcut)Enum.Parse(typeof(OPMShortcut), cmdName);

                buttonDataArray[(int)type].buttonCommand = cmd;
                buttonDataArray[(int)type].buttonState = PlaylistButtonState.Enabled;
                buttonDataArray[(int)type].buttonType = type;

                KeysConverter kc = new KeysConverter(); 
                buttonDataArray[(int)type].buttonTooltip =
                    Translator.Translate(
                    string.Format("TXT_BTN{0}", type.ToString().ToUpperInvariant()),
                    ShortcutMapper.GetShortcutString(cmd));

                buttonDataArray[(int)type].buttonImage = Resources.ResourceManager.GetImage(string.Format("btn{0}", type));
            }

            SetButtonsData(buttonDataArray, false);
        }

        private void OnButtonPressed(object sender, EventArgs e)
        {
            OPMButton button = sender as OPMButton;
            if (button != null)
            {
                try
                {
                    PlaylistButtonData data = (PlaylistButtonData)button.Tag;
                    ShortcutMapper.DispatchCommand(data.buttonCommand);
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }
            }
        }

        private void HandleMouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }
    }
}
