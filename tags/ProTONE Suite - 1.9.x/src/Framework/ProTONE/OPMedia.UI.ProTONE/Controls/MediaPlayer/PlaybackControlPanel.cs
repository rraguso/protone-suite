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
using System.Resources;

using OPMedia.UI.Themes;
using OPMedia.Core;

using OPMedia.Runtime.Shortcuts;

using OPMedia.UI.Generic;
using OPMedia.Core.GlobalEvents;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime.ProTONE;

using LocalEventNames = OPMedia.UI.ProTONE.GlobalEvents.EventNames;
using OPMedia.UI.ProTONE.Properties;


namespace OPMedia.UI.ProTONE.Controls.MediaPlayer
{
    public enum PlaybackButtonType
    {
        Play,
        Pause,
        Stop,
        Prev,
        Next,
        Load,
        OpenDisk,
        FullScreen,

        LoopPlay,
        PlaylistEnd,
        ToggleShuffle,

        OpenSettings,
    }

    public enum PlaybackButtonState
    {
        Hidden,
        Disabled,
        Enabled
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PlaybackButtonData
    {
        public PlaybackButtonType buttonType;
        public PlaybackButtonState buttonState;
        public OPMShortcut buttonCommand;
        public string buttonTooltip;
        public Image buttonImage;
    }

    public partial class PlaybackControlPanel : OPMBaseControl
    {
        OPMToolTip _tip = new OPMToolTip();

        public void SetButtonsData(PlaybackButtonData[] buttonDataArray, bool stateOnly)
        {
            foreach (PlaybackButtonData buttonData in buttonDataArray)
            {
                string buttonName = string.Format("btn{0}", buttonData.buttonType);
                OPMButton button = pnlButtons.Controls[buttonName] as OPMButton;
                if (button != null)
                {
                    button.Image = null;
                    button.Text = string.Empty;
                    button.Enabled = (buttonData.buttonState == PlaybackButtonState.Enabled);
                    button.Visible = (buttonData.buttonState != PlaybackButtonState.Hidden);
                    button.Tag = buttonData;

                    if (!stateOnly)
                    {
                        button.Image = buttonData.buttonImage;
                        button.Tag = buttonData;

                        _tip.SetSimpleToolTip(button, buttonData.buttonTooltip, buttonData.buttonImage);
                    }
                }
            }
        }

        public void SetDefaultButtonsData()
        {
            PlaybackButtonData[] buttonDataArray =
                new PlaybackButtonData[Enum.GetValues(typeof(PlaybackButtonType)).Length];

            foreach (PlaybackButtonType type in Enum.GetValues(typeof(PlaybackButtonType)))
            {
                string cmdName = string.Format("Cmd{0}",  type.ToString());
                OPMShortcut cmd = (OPMShortcut)Enum.Parse(typeof(OPMShortcut), cmdName);
                KeysConverter kc = new KeysConverter();

                buttonDataArray[(int)type].buttonCommand = cmd;
                buttonDataArray[(int)type].buttonState = PlaybackButtonState.Enabled;
                buttonDataArray[(int)type].buttonType = type;

                buttonDataArray[(int)type].buttonTooltip =
                    Translator.Translate(
                    string.Format("TXT_BTN{0}", type.ToString().ToUpperInvariant()),
                    ShortcutMapper.GetShortcutString(cmd));

                buttonDataArray[(int)type].buttonImage = Resources.ResourceManager.GetImage(string.Format("btn{0}", type));
            }

            SetButtonsData(buttonDataArray, false);
        }

        public PlaybackControlPanel()
            : base()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                SetDefaultButtonsData();
            }

            this.HandleCreated += new EventHandler(PlaybackControlPanel_HandleCreated);
        }

        void PlaybackControlPanel_HandleCreated(object sender, EventArgs e)
        {
            UpdateStateButtons();
        }

        [EventSink(EventNames.ThemeUpdated)]
        [EventSink(LocalEventNames.UpdateStateButtons)]
        public void UpdateStateButtons()
        {
            btnLoopPlay.OverrideBackColor = AppSettings.LoopPlay ? ThemeManager.CheckedMenuColor : Color.Empty;
            btnPlaylistEnd.OverrideBackColor = SystemScheduler.PlaylistEventEnabled ? ThemeManager.CheckedMenuColor : Color.Empty;
            btnToggleShuffle.OverrideBackColor = AppSettings.ShufflePlaylist ? ThemeManager.CheckedMenuColor : Color.Empty;
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

        private void OnButtonPressed(object sender, EventArgs e)
        {
            OPMButton button = sender as OPMButton;
            if (button != null)
            {
                try
                {
                    PlaybackButtonData data = (PlaybackButtonData)button.Tag;
                    ShortcutMapper.DispatchCommand(data.buttonCommand);
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.DispatchError(ex);
                }
                finally
                {
                    UpdateStateButtons();
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            pnlButtons.Focus();
        }
    }
}
