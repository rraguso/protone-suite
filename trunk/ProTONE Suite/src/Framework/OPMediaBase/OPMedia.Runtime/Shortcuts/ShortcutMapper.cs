using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using OPMedia.Core.Logging;
using OPMedia.Core;
using OPMedia.Core.TranslationSupport;
using System.ComponentModel;


namespace OPMedia.Runtime.Shortcuts
{
    public class OPMShortcutEventArgs : HandledEventArgs
    {
        public OPMShortcut cmd;

        public override string ToString()
        {
            return string.Format("[Cmd={0}, Handled={1}]", cmd, base.Handled);
        }

        public OPMShortcutEventArgs(OPMShortcut cmd)
        {
            this.cmd = cmd;
        }
    }

    public class ShortcutMapper
    {
        static string fileName = string.Empty;

        static List<KeyEventArgs> keyCommands = new List<KeyEventArgs>();
        static List<KeyEventArgs> altKeyCommands = new List<KeyEventArgs>();

        static bool enableShortcutDispatch = true;
        public static bool EnableShortcutDispatch
        { get { return enableShortcutDispatch; } set { enableShortcutDispatch = value; } }

        public static List<KeyEventArgs> KeyCommands
        { get { return keyCommands; } }

        public static List<KeyEventArgs> AltKeyCommands
        { get { return altKeyCommands; } }

        private static bool _isPlayer = false;
        public static bool IsPlayer
        {
            get { return _isPlayer; }
            set { _isPlayer = value; }
        }

        public static OPMShortcut CmdFirst
        {
            get { return (IsPlayer) ? OPMShortcut.CmdPlayPause : OPMShortcut.CmdOpenHelp; }
        }

        public static OPMShortcut CmdLast
        {
            get { return (IsPlayer) ? OPMShortcut.CmdGenericOpen : OPMShortcut.CmdOutOfRange; }
        }

        public static bool IsConfigurableShortcut(OPMShortcut cmd)
        {
            switch (cmd)
            {
                case OPMShortcut.CmdGenericApply:
                case OPMShortcut.CmdGenericNew:
                case OPMShortcut.CmdGenericOpen:
                case OPMShortcut.CmdGenericSave:
                case OPMShortcut.CmdGenericUndo:
                case OPMShortcut.CmdOpenHelp:
                case OPMShortcut.CmdShowLogConsole:
                case OPMShortcut.CmdDumpDebugStats:

                case OPMShortcut.CmdSwitchWindows:

                case OPMShortcut.CmdGenericCopy:
                case OPMShortcut.CmdGenericCut:
                case OPMShortcut.CmdGenericPaste:

                case OPMShortcut.CmdGenericRefresh:
                case OPMShortcut.CmdGenericDelete:
                case OPMShortcut.CmdGenericRename:
                case OPMShortcut.CmdGenericSearch:
                    return false;

                default:
                    return true;
            }
        }

        public static bool IsHiddenShortcut(OPMShortcut cmd)
        {
            switch (cmd)
            {
                case OPMShortcut.CmdDumpDebugStats:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsConfigurableShortcutKey(Keys key)
        {
            OPMShortcut cmd = MapCommand(key);
            return IsConfigurableShortcut(cmd);
        }

        public static bool IsHiddenShortcutKey(Keys key)
        {
            OPMShortcut cmd = MapCommand(key);
            return IsHiddenShortcut(cmd);
        }

        public static void Load()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (FileStream isoStream = new FileStream(fileName, FileMode.Open))
                    {
                        LoadInternal(isoStream);
                    }
                }
            }
            catch
            {
            }
        }

        public static void Save()
        {
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    SaveInternal(stream);
                }
            }
            catch
            {
            }
        }

        public static void DispatchKey(Keys key)
        {
            OPMShortcut cmd = MapCommand(key);
            if (cmd >= CmdFirst && cmd < CmdLast)
            {
                DispatchCommand(cmd);
            }
        }

        public static void DispatchCommand(OPMShortcut cmd)
        {
            if (enableShortcutDispatch)
            {
                EventDispatch.DispatchEvent(EventNames.ExecuteShortcut, 
                    new OPMShortcutEventArgs(cmd));
            }
        }

        public static OPMShortcut MapCommand(Keys key)
        {
            if (key == Keys.Space)
                return OPMShortcut.CmdPlayPause;

            KeysConverter kc = new KeysConverter();
            string pressedKeys = kc.ConvertToInvariantString(key);

            for (OPMShortcut cmd = CmdFirst; cmd < CmdLast; cmd++)
            {
                string actionKeys = 
                    kc.ConvertToInvariantString(keyCommands[(int)cmd].KeyData);
                string altActionKeys = 
                    kc.ConvertToInvariantString(altKeyCommands[(int)cmd].KeyData);

                if (pressedKeys == actionKeys || pressedKeys == altActionKeys)
                    return cmd;
            }

            return OPMShortcut.CmdOutOfRange;
        }

        public static string GetShortcutString(OPMShortcut cmd)
        {
            if (cmd >= OPMShortcut.CmdPlayPause && cmd < OPMShortcut.CmdOutOfRange)
            {
                KeysConverter kc = new KeysConverter();
                
                string actionKeys =
                   kc.ConvertToInvariantString(keyCommands[(int)cmd].KeyData);
                string altActionKeys =
                    kc.ConvertToInvariantString(altKeyCommands[(int)cmd].KeyData);

                if (actionKeys == altActionKeys)
                    return actionKeys;
                else
                    return actionKeys + " " + Translator.Translate("TXT_OR") + " " + altActionKeys;

            }

            return string.Empty;
        }

        public static void Init()
        {
            fileName =
                Path.Combine(ApplicationInfo.SettingsFolder, ApplicationInfo.ApplicationName) + ".keymap";

            RestoreDefaults(false);
            Load();

            _intialized = true;
        }

        static bool _intialized = false;
        static ShortcutMapper()
        {
            if (!_intialized)
            {
                Init();
            }
        }

        private static void LoadInternal(Stream s)
        {
            using (StreamReader sr = new StreamReader(s))
            {
                KeysConverter kc = new KeysConverter();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] fields = line.Split(";".ToCharArray());
                    if (fields.Length >= 2)
                    {
                        OPMShortcut cmd = (OPMShortcut)Enum.Parse(typeof(OPMShortcut), fields[0]);
                        keyCommands[(int)cmd] = new KeyEventArgs((Keys)kc.ConvertFromInvariantString(fields[1]));

                        if (fields.Length >= 3)
                        {
                            altKeyCommands[(int)cmd] = new KeyEventArgs((Keys)kc.ConvertFromInvariantString(fields[2]));
                        }
                        else
                        {
                            altKeyCommands[(int)cmd] = new KeyEventArgs(keyCommands[(int)cmd].KeyData);
                        }
                    }
                }
            }
        }

        private static void SaveInternal(Stream s)
        {
            using (StreamWriter sw = new StreamWriter(s))
            {
                KeysConverter kc = new KeysConverter();

                for (OPMShortcut cmd = CmdFirst; cmd < CmdLast; cmd++)
                {
                    sw.WriteLine("{0};{1};{2}",
                        cmd, 
                        kc.ConvertToInvariantString(keyCommands[(int)cmd].KeyData), 
                        kc.ConvertToInvariantString(altKeyCommands[(int)cmd].KeyData));
                }
            }
        }

        public static void RestoreDefaults(bool save)
        {
            KeyEventArgs[] actionKeys1 = new KeyEventArgs[]
                {
                    // Playback control
                    new KeyEventArgs(Keys.Z),
                    new KeyEventArgs(Keys.X),
                    new KeyEventArgs(Keys.C),
                    new KeyEventArgs(Keys.V),
                    new KeyEventArgs(Keys.B),
                    new KeyEventArgs(Keys.Control | Keys.D),
                    new KeyEventArgs(Keys.Control | Keys.U),
                    
                    // Full screen
                    new KeyEventArgs(Keys.Alt | Keys.Enter),
                    
                    // Media seek control
                    new KeyEventArgs(Keys.Right),
                    new KeyEventArgs(Keys.Left),
                    
                    // Volume control
                    new KeyEventArgs(Keys.Add),
                    new KeyEventArgs(Keys.Subtract),
                    
                    // Playlist control
                    new KeyEventArgs(Keys.Alt | Keys.Up),
                    new KeyEventArgs(Keys.Alt | Keys.Down),
                    new KeyEventArgs(Keys.Delete),
                    new KeyEventArgs(Keys.Control | Keys.Delete),
                    new KeyEventArgs(Keys.Control | Keys.N),
                    new KeyEventArgs(Keys.Control | Keys.S),
                    new KeyEventArgs(Keys.Control | Keys.L),
                    new KeyEventArgs(Keys.Control | Keys.E),
                    new KeyEventArgs(Keys.Control | Keys.H),
                    new KeyEventArgs(Keys.Control | Keys.J),

                    // Player configuration
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.V),
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.A),
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.T),
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.S),
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.R),

                     // Subtitles
                    new KeyEventArgs(Keys.Control | Keys.T),

                    // Common commands (player-non player)
                    new KeyEventArgs(Keys.F1),
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.C),
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.K),
                    new KeyEventArgs(Keys.F12),
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.F12),

                    // Commands not related to player
                    new KeyEventArgs(Keys.Control | Keys.O),
                    new KeyEventArgs(Keys.Control | Keys.N),
                    new KeyEventArgs(Keys.Control | Keys.S),
                    new KeyEventArgs(Keys.Control | Keys.Z),
                    new KeyEventArgs(Keys.Control | Keys.W),

                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.Tab),


                    new KeyEventArgs(Keys.Control | Keys.C),//CmdGenericCopy, 
                    new KeyEventArgs(Keys.Control | Keys.X),//CmdGenericCut,
                    new KeyEventArgs(Keys.Control | Keys.V),//CmdGenricPaste,
                    new KeyEventArgs(Keys.F5),//CmdGenericRefresh,
                    new KeyEventArgs(Keys.Delete),//CmdGenericDelete,
                    new KeyEventArgs(Keys.F2),//CmdGenericRename,
                    new KeyEventArgs(Keys.Control | Keys.F),//CmdGenericSearch,
                    new KeyEventArgs(Keys.Back),//CmdNavigateUp,
                    new KeyEventArgs(Keys.Control | Keys.Left),//CmdNavigateLeft,
                    new KeyEventArgs(Keys.Control | Keys.Right),//CmdNavigateRight,
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.D),//CmdChangeDisk,
                    new KeyEventArgs(Keys.Control | Keys.M),//CmdFavManager,
                    new KeyEventArgs(Keys.Control | Keys.D3),//CmdTaggingWizard,
                    new KeyEventArgs(Keys.Control | Keys.G),//CmdCatalogWizard,
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.M),//CmdCatalogMerge,
                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.A),//CmdCdRipperWizard,

                    new KeyEventArgs(Keys.Control | Keys.Alt | Keys.F2),//CmdEditPath,
                };

            KeyEventArgs[] actionKeys2 = new KeyEventArgs[]
            {
                // Playback control
                new KeyEventArgs(Keys.MediaPlayPause),
                new KeyEventArgs(Keys.MediaStop),
                new KeyEventArgs(Keys.MediaPreviousTrack),
                new KeyEventArgs(Keys.MediaNextTrack),
                new KeyEventArgs(Keys.SelectMedia),
                new KeyEventArgs(Keys.Control | Keys.D),
                new KeyEventArgs(Keys.Control | Keys.U),
                
                // Full screen
                new KeyEventArgs(Keys.Control | Keys.F),
                
                // Media seek control
                new KeyEventArgs(Keys.OemPeriod),
                new KeyEventArgs(Keys.Oemcomma),
                
                // Volume control
                new KeyEventArgs(Keys.VolumeUp),
                new KeyEventArgs(Keys.VolumeDown),
                
                // Playlist control
                new KeyEventArgs(Keys.Alt | Keys.Up),
                new KeyEventArgs(Keys.Alt | Keys.Down),
                new KeyEventArgs(Keys.Delete),
                new KeyEventArgs(Keys.Control | Keys.Delete),
                new KeyEventArgs(Keys.Control | Keys.SelectMedia),
                new KeyEventArgs(Keys.Control | Keys.S),
                new KeyEventArgs(Keys.Control | Keys.L),
                new KeyEventArgs(Keys.Control | Keys.E),
                new KeyEventArgs(Keys.Control | Keys.H),
                new KeyEventArgs(Keys.Control | Keys.J),


                // Player configuration
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.V),
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.A),
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.T),
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.S),
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.R),

                // Subtitles
                new KeyEventArgs(Keys.Control | Keys.T),

                // Common commands (player-non player)
                new KeyEventArgs(Keys.F1),
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.C),
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.K),
                new KeyEventArgs(Keys.F12),
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.F12),

                // Commands not related to player
                new KeyEventArgs(Keys.Control | Keys.O),
                new KeyEventArgs(Keys.Control | Keys.N),
                new KeyEventArgs(Keys.Control | Keys.S),
                new KeyEventArgs(Keys.Control | Keys.Z),
                new KeyEventArgs(Keys.Control | Keys.W),

                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.Tab),

                new KeyEventArgs(Keys.Control | Keys.C),//CmdGenericCopy, 
                new KeyEventArgs(Keys.Control | Keys.X),//CmdGenericCut,
                new KeyEventArgs(Keys.Control | Keys.V),//CmdGenricPaste,
                new KeyEventArgs(Keys.F5),//CmdGenericRefresh,
                new KeyEventArgs(Keys.Delete),//CmdGenericDelete,
                new KeyEventArgs(Keys.F2),//CmdGenericRename,
                new KeyEventArgs(Keys.Control | Keys.F),//CmdGenericSearch,
                new KeyEventArgs(Keys.Back),//CmdNavigateUp,
                new KeyEventArgs(Keys.Control | Keys.Left),//CmdNavigateLeft,
                new KeyEventArgs(Keys.Control | Keys.Right),//CmdNavigateRight,
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.D),//CmdChangeDisk,
                new KeyEventArgs(Keys.Control | Keys.M),//CmdFavManager,
                new KeyEventArgs(Keys.Control | Keys.NumPad3),//CmdTaggingWizard,
                new KeyEventArgs(Keys.Control | Keys.G),//CmdCatalogWizard,
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.M),//CmdCatalogMerge,
                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.A),//CmdCdRipperWizard,

                new KeyEventArgs(Keys.Control | Keys.Alt | Keys.F2),//CmdEditPath,
            };

            keyCommands.Clear();
            altKeyCommands.Clear();

            foreach (KeyEventArgs args in actionKeys1)
            {
                if (!keyCommands.Contains(args))
                {
                    keyCommands.Add(args);
                }
            }
            foreach (KeyEventArgs args in actionKeys2)
            {
                if (!altKeyCommands.Contains(args))
                {
                    altKeyCommands.Add(args);
                }
            }

            if (save)
            {
                Save();
            }
        }
    }

    public enum OPMShortcut
    {
        // Playback control
        CmdPlayPause,
        CmdStop,
        CmdPrev,
        CmdNext,
        CmdLoad,
        CmdOpenDisk,
        CmdOpenURL, 
        
        // Full Screen
        CmdFullScreen,
        
        // Media seek control
        CmdFwd,
        CmdRew,
        
        // Volume control
        CmdVolUp,
        CmdVolDn,
        
        // Playlist control
        CmdMoveUp,
        CmdMoveDown,
        CmdDelete,

        CmdClear,
        CmdLoadPlaylist,
        CmdSavePlaylist,

        CmdLoopPlay,
        CmdPlaylistEnd,
        CmdToggleShuffle,
        CmdJumpToItem,

        // Player configuration
        CmdCfgVideo,
        CmdCfgAudio,
        CmdCfgTimer,
        CmdCfgSubtitles,
        CmdCfgRemote,

        // Subtitles
        CmdSearchSubtitles,

        // Common commands (player-non player)
        CmdOpenHelp,
        CmdOpenSettings,
        CmdCfgKeyboard,
        CmdShowLogConsole,
        CmdDumpDebugStats,

        // Commands not related to player
        CmdGenericOpen,
        CmdGenericNew,
        CmdGenericSave,
        CmdGenericUndo,
        CmdGenericApply,

        // 
        CmdSwitchWindows, 

        // 
        CmdGenericCopy,
        CmdGenericCut,
        CmdGenericPaste,

        CmdGenericRefresh,
        CmdGenericDelete,
        CmdGenericRename,
        CmdGenericSearch,

        CmdNavigateUp,
        CmdNavigateBack,
        CmdNavigateForward,
        CmdChangeDisk,
        CmdFavManager,
        CmdTaggingWizard,
        CmdCatalogWizard,
        CmdCatalogMerge,
        CmdCdRipperWizard,

        CmdEditPath,
        
        CmdOutOfRange,
    };
}
