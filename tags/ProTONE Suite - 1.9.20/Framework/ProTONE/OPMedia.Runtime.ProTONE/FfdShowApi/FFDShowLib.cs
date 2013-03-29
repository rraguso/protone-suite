#if HAVE_DSHOW

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Remoting.Messaging;
using OPMedia.Runtime.ProTONE.Rendering.DS;
using OPMedia.Core;

namespace OPMedia.Runtime.ProTONE.FfdShowApi
{
  /// <summary>
  /// FFDShowAPI library class. Use this class to get/set FFDShow live settings
  /// </summary>
  internal class FfdShowLib : IDisposable
  {
    #region Structures

    /// <summary>
    /// FFDShow instance structure
    /// </summary>
    public struct FFDShowInstance
    {
      /// <summary>
      /// Unique identifier for this FFDShow instance
      /// </summary>
      public IntPtr handle;
      /// <summary>
      /// File name of the media being played by this instance (may be null)
      /// </summary>
      public string fileName;
    }
    #endregion Structures

    //Copy data flags
    private const int FFDSM_SET_ACTIVE_PRESET_STR = 10;
    private const int FFDSM_SET_SHORTOSD_MSG = 18;
    private const int FFDSM_SET_OSD_MSG = 19;

    public const int minRevision = 3452;

    private static string ffdshowRegKey = @"SOFTWARE\GNU\ffdshow";
    private static string ffdshowAudioRegKey = @"SOFTWARE\GNU\ffdshow_audio";
    private static string strAppName = "ffdshow_remote_class";

    const uint FFDShowAPIRemoteId = 32786;


    #region Variables
    /// <summary>
    /// Unique identifier of the running instance of FFDShow
    /// </summary>
    protected IntPtr ffDShowInstanceHandle = IntPtr.Zero;
    private int requestTimeout = 2000;
    private FFDShowReceiver receiver = null;
    private bool IsFFDShowActive = false;
    private string fileName = null;
    private IntPtr initFFDShowInstanceHandle = IntPtr.Zero;
    private static bool ffrwNoOSD = false;
    
    #endregion Variables

    #region Base Properties
    /// <summary>
    /// Gets the FFDShow instance handle (number that identifies the FFDShow instance)
    /// </summary>
    public IntPtr FFDShowInstanceHandle
    {
      get
      {
        return ffDShowInstanceHandle;
      }
    }

    /// <summary>
    /// Gets or sets the FFDShow registry key. Used sometimes when ffdshow is not active (for presets)
    /// </summary>
    public static string FFDShowRegKey
    {
      get
      {
        return ffdshowRegKey;
      }
      set
      {
        ffdshowRegKey = value;
      }
    }

    /// <summary>
    /// Gets or sets the registry key of FFDShow audio
    /// Used to get or set the default audio preset
    /// </summary>
    public static string FFDShowAudioRegKey
    {
      get
      {
        return ffdshowAudioRegKey;
      }
      set
      {
        ffdshowAudioRegKey = value;
      }
    }


    /// <summary>
    /// Gets or sets the OSD display when doing FastForward/Rewind
    /// This is a static parameter that will be applied to all the running FFDShow instances
    /// </summary>
    public static bool FFRWNoOSD
    {
      get
      {
        return ffrwNoOSD;
      }
      set
      {
        ffrwNoOSD = value;
      }
    }


    #endregion Base Properties

    #region Presets properties

    /// <summary>
    /// Gets or sets the default video preset (does not apply to currently running instances)
    /// </summary>
    public static String DefaultVideoPreset
    {
      get
      {
        using (RegistryKey preferencesKey = Registry.CurrentUser.OpenSubKey(ffdshowRegKey))
        {
          if (preferencesKey != null)
          {
            return (string)preferencesKey.GetValue("activePreset");
          }
          else return null;
        }
      }

      set
      {
        string[] presetList = VideoPresets;
        // Check if we set an existing preset
        bool found = false;
        for (int i = 0; i < presetList.Length; i++)
        {
          if (presetList[i].Equals(value))
          {
            found = true;
            break;
          }
        }
        if (found)
          using (RegistryKey preferencesKey = Registry.CurrentUser.CreateSubKey(ffdshowRegKey))
          {
            if (preferencesKey != null)
            {
              preferencesKey.SetValue("activePreset", value);
            }
          }
      }
    }

    /// <summary>
    /// Gets or sets the default audio preset (does not apply to currently running instances)
    /// </summary>
    public static string DefaultAudioPreset
    {
      get
      {
        using (RegistryKey preferencesKey = Registry.CurrentUser.OpenSubKey(ffdshowAudioRegKey))
        {
          if (preferencesKey != null)
          {
            return (string)preferencesKey.GetValue("activePreset");
          }
          else return null;
        }
      }
      set
      {
        string[] presetList = AudioPresets;
        // Check if we set an existing preset
        bool found = false;
        for (int i = 0; i < presetList.Length; i++)
        {
          if (presetList[i].Equals(value))
          {
            found = true;
            break;
          }
        }
        if (!found) return;
        using (RegistryKey preferencesKey = Registry.CurrentUser.CreateSubKey(ffdshowAudioRegKey))
        {
          if (preferencesKey != null)
          {
            preferencesKey.SetValue("activePreset", value);
          }
        }
      }
    }



    /// <summary>
    /// Gets or sets the video preset for the current instance. Also sets the preset as default.
    /// </summary>
    public String ActivePreset
    {
      get
      {
        string tmpStr = getStringParam(FFDShowConstants.FFDShowDataId.IDFF_OSDcurPreset);
        if (tmpStr != null && !tmpStr.Equals(""))
        {
          return tmpStr;
        }
        else
        {
          return DefaultVideoPreset;
        }
      }
      set
      {
        if (IsFFDShowActive)
        {
          PlayState playState = getState();
          if (playState == PlayState.PlayState || playState == PlayState.FastForwardRewind)
            pauseVideo();
          
           COPYDATASTRUCT cd = new COPYDATASTRUCT();
          cd.dwData = new UIntPtr((uint)FFDSM_SET_ACTIVE_PRESET_STR);
#if UNICODE
                    cd.lpData = Marshal.StringToHGlobalUni(value);
#else
          cd.lpData = Marshal.StringToHGlobalAnsi(value);
#endif
          cd.cbData = (uint)Kernel32.GlobalSize(cd.lpData);
          if (receiver == null)
            receiver = new FFDShowReceiver(Thread.CurrentThread);
          receiver.ReceivedString = null;
          receiver.ReceivedType = 0;
          //receiver.ParentThread = Thread.CurrentThread;
          User32.SendMessage(ffDShowInstanceHandle, (int)Messages.WM_COPYDATA, receiver.Handle.ToInt32(), ref cd);
          if (playState == PlayState.PlayState || playState == PlayState.FastForwardRewind)
            startVideo();
        }
        DefaultVideoPreset = value;
      }
    }


    /// <summary>
    /// Gets or sets the default audio preset (does not apply to currently running instances).
    /// Same behaviour as DefaultAudioPreset property
    /// </summary>
    public string ActiveAudioPreset
    {
      get
      {
        return DefaultAudioPreset;
      }
      set
      {
        DefaultAudioPreset = value;
      }
    }
    #endregion Presets properties

    #region Enabled Properties
    // Show/hide subtitles
    /// <summary>
    /// Enable or disable subtitles filter
    /// </summary>
    public bool DoShowSubtitles
    {
      get
      {
        int value = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSubtitles);
        if (value == 1)
          return true;
        else return false;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSubtitles, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSubtitles, 0);
      }
    }

    /// <summary>
    /// Enable/disable crop and zoom
    /// </summary>
    public bool DoCropZoom
    {
      get
      {
        return (getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isCropNzoom) == 1);
      }
      set
      {
        if (value)
        {
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isCropNzoom, 1);
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_magnificationLocked, 0);
          //IDFF_cropNzoomMode => 2
        }
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isCropNzoom, 0);
      }
    }

    /// <summary>
    /// Enable/disable lock of cropping
    /// </summary>
    public bool isCropZoomLocked
    {
      get
      {
        int value = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_magnificationLocked);
        if (value == 1)
          return true;
        else return false;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_magnificationLocked, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_magnificationLocked, 0);
      }
    }

    /// <summary>
    /// Enable/disable picture properties
    /// </summary>
    public bool DoPictureProperties
    {
      get
      {
        int value = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isPictProp);
        if (value == 1)
          return true;
        else return false;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isPictProp, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isPictProp, 0);
      }
    }

    /// <summary>
    /// Enable/disable crop and zoom
    /// </summary>
    public bool DoPostProcessing
    {
      get
      {
        int value = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isPostproc);
        if (value == 1)
          return true;
        else return false;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isPostproc, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isPostproc, 0);
      }
    }

    /// <summary>
    /// Enable/disable crop and zoom
    /// </summary>
    public bool DoResize
    {
      get
      {
        int value = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isResize);
        if (value == 1)
          return true;
        else return false;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isResize, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isResize, 0);
      }
    }

    /// <summary>
    /// Enable/disable noise reduction
    /// </summary>
    public bool DoNoiseReduction
    {
      get
      {
        int value = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isBlur);
        if (value == 1)
          return true;
        else return false;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isBlur, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isBlur, 0);
      }
    }

    /// <summary>
    /// Enable/disable sharpen
    /// </summary>
    public bool DoSharpen
    {
      get
      {
        int value = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSharpen);
        if (value == 1)
          return true;
        else return false;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSharpen, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSharpen, 0);
      }
    }

    /// <summary>
    /// Get/Set deinterlace
    /// </summary>
    public bool DoDeinterlace
    {
      get
      {
        int value = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isDeinterlace);
        if (value == 1)
          return true;
        else return false;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isDeinterlace, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isDeinterlace, 0);
      }
    }
    #endregion Enabled Properties

    #region Subtitles/Audio streams Properties
    /// <summary>
    /// Subtitles/audio stream structure
    /// </summary>
    public struct Stream
    {
      /// <summary>
      /// Name of the stream
      /// </summary>
      public string name;
      /// <summary>
      /// Language name of the stream
      /// </summary>
      public string languageName;
      /// <summary>
      /// True if the stream is active
      /// </summary>
      public bool enabled;
      /// <summary>
      /// True if this is an external file
      /// </summary>
      public bool isFile;
      /// <summary>
      /// Constructor of a stream structure
      /// </summary>
      /// <param name="name">Name of the stream</param>
      /// <param name="languageName">Language name of the stream</param>
      /// <param name="enabled">True if the stream is active</param>
      public Stream(string name, string languageName, bool enabled)
      {
        this.name = name;
        this.languageName = languageName;
        this.enabled = enabled;
        this.isFile = false;
      }

      /// <summary>
      /// Constructor of a stream structure with external file flag
      /// </summary>
      /// <param name="name">Name of the stream</param>
      /// <param name="languageName">Language name of the stream</param>
      /// <param name="enabled">True if the stream is active</param>
      /// <param name="isFile">True if this stream is an external file</param>
      public Stream(string name, string languageName, bool enabled, bool isFile)
      {
        this.name = name;
        this.languageName = languageName;
        this.enabled = enabled;
        this.isFile = isFile;
      }
    }

    public class Streams : SortedDictionary<int, Stream>
    {
      public enum StreamType { EmbeddedOnly, FilesOnly }
      public int Size(StreamType type)
      {
        int cnt = 0;
        foreach (KeyValuePair<int, Stream> streamPair in this)
        {
          if (type == StreamType.EmbeddedOnly && !streamPair.Value.isFile) cnt++;
          else if (type == StreamType.FilesOnly && streamPair.Value.isFile) cnt++;
        }
        return cnt;
      }
    }

    /// <summary>
    /// Gets the list of subtitle streams
    /// </summary>
    public Streams SubtitleStreams
    {
      get
      {
        Streams subtitleStreams = new Streams();
        string listString = getCustomParam(FFD_MSG.GET_SUBTITLESTREAMSLIST, 0);
        parseStreamsString(listString, subtitleStreams);
        return subtitleStreams;
      }
    }


    /// <summary>
    /// Gets the list of internal audio streams
    /// </summary>
    public Streams AudioStreams
    {
      get
      {
        Streams audioStreams = new Streams();
        string listString = getCustomParam(FFD_MSG.GET_AUDIOSTREAMSLIST, 0);
        parseStreamsString(listString, audioStreams);
        return audioStreams;
      }
    }

    /// <summary>
    /// Gets or sets the current audio stream
    /// </summary>
    public int AudioStream
    {
      get
      {
        Streams audioStreams = AudioStreams;
        foreach (KeyValuePair<int, Stream> audioStream in audioStreams)
        {
          if (audioStream.Value.enabled)
            return audioStream.Key;
        }
        return 0;
      }
      set
      {
          SendMessage(FFD_WPRM.SET_AUDIO_STREAM, value);
      }
    }

    private void parseStreamsString(string listString, Streams streamsList)
    {
      string[] list = null;
      if (listString != null && listString.Length > 0)
      {
        list = listString.Split(new string[] { "</enabled></stream><stream><id>" }, StringSplitOptions.None); ;
        if (list != null)
        {
          for (int i = 0; i < list.Length; i++)
          {
            if (i == 0)
              list[i] = list[i].Replace("<stream><id>", "");
            if (i == list.Length - 1)
              list[i] = list[i].Replace("</enabled></stream>", "");

            string[] subElement = list[i].Split(new string[] { "</id><name>" }, StringSplitOptions.None);
            if (subElement != null)
            {
              int streamId = int.Parse(subElement[0]);
              string[] subSubElement = subElement[1].Split(new string[] { "</name><language_name>" }, StringSplitOptions.None);
              string streamName = subSubElement[0];
              string[] subSubSubElement = subSubElement[1].Split(new string[] { "</language_name><enabled>" }, StringSplitOptions.None);
              string streamLanguageName = subSubSubElement[0];
              string enabled = subSubSubElement[1];
              bool isEnabled = false;
              if (enabled.Equals("true"))
                isEnabled = true;


              if (streamLanguageName.IndexOf("(") > 0)
                streamLanguageName = streamLanguageName.Substring(0, streamLanguageName.IndexOf("(") - 1);
              streamsList[streamId] = new Stream(streamName, streamLanguageName, isEnabled);
            }
          }
        }
      }
    }


    /// <summary>
    /// Gets or sets the current internal subtitle stream
    /// Gets : the id of the stream is returned. Returns -1 if no stream is selected
    /// Sets : the id of the stream must be passed
    /// </summary>
    public int SubtitleStream
    {
      get
      {
        Streams subtitleStreams = SubtitleStreams;
        foreach (KeyValuePair<int, Stream> subtitleStream in subtitleStreams)
        {
          if (subtitleStream.Value.enabled)
            return subtitleStream.Key;
        }
        return -1;
      }
      set
      {
          SendMessage(FFD_WPRM.SET_SUBTITLE_STREAM, value);
      }
    }


    /// <summary>
    /// Set/get substitles delay (in ms)
    /// </summary>
    public int SubtitlesDelay
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_subDelay);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_subDelay, value);
      }
    }

    /// <summary>
    /// Set/get subtitles ratio speed (default : 1000/1000)
    /// </summary>
    public int[] SubtitlesSpeed
    {
      get
      {
        int speed1 = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_subSpeed);
        int speed2 = getIntParam(FFDShowConstants.FFDShowDataId.IDFF_subSpeed2);
        int[] values = new int[2] { speed1, speed2 };
        return values;
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_subSpeed, value[0]);
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_subSpeed2, value[1]);
      }
    }

    /// <summary>
    /// Set/get the current external subtitles file
    /// </summary>
    public string CurrentSubtitleFile
    {
      get
      {
          return getCustomParam(FFD_MSG.GET_CURRENT_SUBTITLES, 0);//FFDSM_GET_CURRENT_SUBTITLES);
      }
      set
      {
        setStringParam(FFDShowConstants.FFDShowDataId.IDFF_subTempFilename, value);
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSubtitles, 1);
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_subShowEmbedded, 0);
      }
    }

    /// <summary>
    /// Returns true if the subtitle filter is enabled, false otherwise
    /// </summary>
    public bool SubtitlesEnabled
    {
      get
      {
        return (getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSubtitles) == 1) ? true : false;
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isSubtitles, (value == true) ? 1 : 0);
      }
    }



    /// <summary>
    /// Retrieves the list of available subtitle files
    /// </summary>
    public string[] SubtitleFiles
    {
      get
      {
          string[] list = null;
          string listString = getCustomParam(FFD_MSG.GET_SUBTITLEFILESLIST, 0);//FFDSM_GET_SUBTITLEFILES);
          if (listString != null)
          {
              list = listString.Split(';');
          }
          return list;
      }
    }

    /// <summary>
    /// Horizontal position of the subtitles (percentage value : 0 to 100)
    /// </summary>
    public int SubtitleHorizontalPosition
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_subPosX);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_subPosX, value);
      }
    }

    /// <summary>
    /// Vertical position of the subtitles (percentage value : 0 to 100)
    /// </summary>
    public int SubtitleVerticalPosition
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_subPosY);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_subPosY, value);
      }
    }
    /// <summary>
    /// Set the font size of subtitles on the screen
    /// </summary>
    public int SubtitleFontSize
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontXscale);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontXscale, value);
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontYscale, value);
      }
    }
    #endregion Subtitles Properties

    #region Other Properties
    /// <summary>
    /// List of chapters. Slow to process : call it once
    /// </summary>
    public Dictionary<int, string> ChaptersList
    {
      get
      {
        Dictionary<int, string> chaptersList = new Dictionary<int, string>();
        string[] list = null;
        string listString = getCustomParam(FFD_MSG.GET_CHAPTERSLIST, 0);
        if (listString != null && listString.Length > 0)
        {
          list = listString.Split(new string[] { "</name></chapter><chapter><time>" }, StringSplitOptions.None); ;
          if (list != null)
          {
            for (int i = 0; i < list.Length; i++)
            {
              if (i == 0)
                list[i] = list[i].Replace("<chapter><time>", "");
              if (i == list.Length - 1)
                list[i] = list[i].Replace("</name></chapter>", "");
              string[] chapterElement = list[i].Split(new string[] { "</time><name>" }, StringSplitOptions.None);
              if (chapterElement != null)
              {
                int chapterTime = int.Parse(chapterElement[0]);
                string chapterName = chapterElement[1];
                chaptersList[chapterTime] = chapterName;
              }
            }
          }
        }
        return chaptersList;
      }
    }
    #endregion Other Properties

    #region Filters Properties
    /// <summary>
    ///  Set/get horizontal cropping
    /// </summary>
    public int CropHorizontal
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_magnificationX);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_magnificationX, value);
      }
    }

    /// <summary>
    /// Get/set horizontal cropping
    /// </summary>
    public int CropVertical
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_magnificationY);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_magnificationY, value);
      }
    }

    /// <summary>
    /// Get or set the vertical resize
    /// </summary>
    public int ResizeVertical
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeDy);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeDy, value);
      }
    }

    /// <summary>
    /// Get or set the vertical resize
    /// </summary>
    public bool ResizeModeFitToScreen
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeMode) == 5;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeMode, 5);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeMode, 0);
      }
    }

    /// <summary>
    /// Get or set the vertical resize
    /// </summary>
    public bool ResizeModeFreeResize
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeMode) == 0;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeMode, 0);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeMode, 5);
      }
    }

    /// <summary>
    /// Get or set the keep aspect ratio
    /// </summary>
    public bool ResizeKeepAspectRatio
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_isAspect) == 1;
      }
      set
      {
        if (value)
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isAspect, 1);
        else
          setIntParam(FFDShowConstants.FFDShowDataId.IDFF_isAspect, 0);
      }
    }


    /// <summary>
    /// Get or set the horizontal resize
    /// </summary>
    public int ResizeHorizontal
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeDx);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_resizeDx, value);
      }
    }

    /// <summary>
    ///  Set/get audio delay
    /// </summary>
    public int AudioDelay
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_videoDelay);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_videoDelay, value);
      }
    }
    #endregion Filters Properties

    #region Picture Properties
    private bool pictureEnabled = false;

    /// <summary>
    /// Gets or sets the picture gamma
    /// </summary>
    public int PictureGama
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_gammaCorrection);
      }
      set
      {
        if (!pictureEnabled)
        {
          DoPictureProperties = true;
          pictureEnabled = true;
        }
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_gammaCorrection, value);
      }
    }

    /// <summary>
    /// Gets or sets the picture hue
    /// </summary>
    public int PictureHue
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_hue);
      }
      set
      {
        if (!pictureEnabled)
        {
          DoPictureProperties = true;
          pictureEnabled = true;
        }
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_hue, value);
      }
    }

    /// <summary>
    /// Gets or sets the picture saturation
    /// </summary>
    public int PictureSaturation
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_saturation);
      }
      set
      {
        if (!pictureEnabled)
        {
          DoPictureProperties = true;
          pictureEnabled = true;
        }
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_saturation, value);
      }
    }

    /// <summary>
    /// Gets or sets the picture contrast
    /// </summary>
    public int PictureContrast
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_lumGain);
      }
      set
      {
        if (!pictureEnabled)
        {
          DoPictureProperties = true;
          pictureEnabled = true;
        }
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_lumGain, value);
      }
    }

    /// <summary>
    /// Gets or sets the picture brightness
    /// </summary>
    public int PictureBrightness
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_lumOffset);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_lumOffset, value);
      }
    }
    #endregion Picture Properties

    #region PostProcessing Properties

    /// <summary>
    /// Gets or sets the postprocessing intensity (deblocking strength)
    /// </summary>
    public int PostProcessingIntensity
    {
      get
      {
        return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_deblockStrength);
      }
      set
      {
        setIntParam(FFDShowConstants.FFDShowDataId.IDFF_deblockStrength, value);
      }
    }
    #endregion PostProcessing Properties

    #region Constructors
    /// <summary>
    /// Basic constructor using interprocess communication
    /// </summary>
    private FfdShowLib()
    {
        receiver = new FFDShowReceiver(Thread.CurrentThread);
    }

    /// <summary>
    /// Constructor where the given file name is searched for between all running FFDShow instances
    /// </summary>
    /// <param name="fileName">Media file name to look FFDShow instance for</param>
    /// <param name="fileNameMode">Filename mode (full path,...)</param>
    public FfdShowLib(string fileName) : this()
    {
      this.fileName = fileName;
    }

    /// <summary>
    /// FFDShowAPI desctructor
    /// </summary>
    ~FfdShowLib()
    {
      Dispose();
    }

    /// <summary>
    /// Cleaning
    /// </summary>
    public void Dispose()
    {
        receiver.Dispose();
    }

    #endregion Constructors

    #region Loading

    /// <summary>
    /// Initialization method. Must be called after constructor.
    /// It will look for a running FFDShow instance basing on constructor parameters.
    /// </summary>
    /// <returns>True if FFDShow instance found</returns>
    private bool init()
    {
      if (fileName == null && initFFDShowInstanceHandle == IntPtr.Zero)
      {
          ffDShowInstanceHandle = User32.FindWindow(strAppName, null);
          IsFFDShowActive = (ffDShowInstanceHandle != IntPtr.Zero);
          return IsFFDShowActive;
      }
      else
      {
        if (initFFDShowInstanceHandle != IntPtr.Zero)
        {
            ffDShowInstanceHandle = initFFDShowInstanceHandle;
            IsFFDShowActive = User32.IsWindow(ffDShowInstanceHandle);
            return IsFFDShowActive;
        }
        else if (ffDShowInstanceHandle != IntPtr.Zero)
        {
            IsFFDShowActive = User32.IsWindow(ffDShowInstanceHandle);
            return IsFFDShowActive;
        }
        else
        {
          List<FFDShowInstance> list = getFFDShowInstances();
          for (int i = 0; i < list.Count; i++)
          {
            IntPtr localFFDShowInstanceHandle = list[i].handle;
            if (string.IsNullOrEmpty(list[i].fileName))
              continue;

            if (string.Compare(fileName, list[i].fileName, true) == 0)
            {
                ffDShowInstanceHandle = localFFDShowInstanceHandle;
                return (IsFFDShowActive = true);
            }
          }
          return (IsFFDShowActive = false);
        }
      }
    }

    /// <summary>
    /// Returns the list of FFDShow instances running
    /// </summary>
    /// <returns>The list (handle and file name) of FFDShow instances running</returns>
    public static List<FFDShowInstance> getFFDShowInstances()
    {
      List<FFDShowInstance> list = new List<FFDShowInstance>();
      List<IntPtr> instancesArray = new List<IntPtr>();
      GCHandle gch = GCHandle.Alloc(instancesArray);
      int res = User32.EnumWindows(new User32.EnumWindowProc(EnumWindowCallBack), (IntPtr)gch);

      res = Kernel32.GetLastError();

      using (FfdShowLib ffDShowAPI = new FfdShowLib())
      {
        for (int i = 0; i < instancesArray.Count; i++)
        {
          ffDShowAPI.ffDShowInstanceHandle = instancesArray[i];
          string FFDShowFileName = ffDShowAPI.getFileName();
          FFDShowInstance instance = new FFDShowInstance();
          instance.handle = ffDShowAPI.ffDShowInstanceHandle;
          instance.fileName = FFDShowFileName;
          list.Add(instance);
        }
      }
      return list;
    }

    private static bool EnumWindowCallBack(IntPtr hwnd, IntPtr lParam)
    {
      GCHandle gch = (GCHandle)lParam;
      List<IntPtr> instancesArray = (List<IntPtr>)gch.Target;
      StringBuilder sbc = new StringBuilder(256);
      User32.GetClassName(hwnd, sbc, sbc.Capacity);
      //sb = new StringBuilder(1024);
      //User32.GetWindowText((int)windowHandle, sb, sb.Capacity);
      if (sbc.Length > 0)
      {
        if (sbc.ToString().Equals(strAppName))
          instancesArray.Add(hwnd);
      }
      return true;
    }

    /// <summary>
    /// Look for an active FFDShow instance basing on constructor parameters
    /// </summary>
    /// <returns>True if any</returns>
    public bool checkFFDShowActive()
    {
        IsFFDShowActive = init();
        return IsFFDShowActive;
    }

    /// <summary>
    /// Check that the previously found FFDShow instance is still active
    /// </summary>
    /// <returns></returns>
    public bool checkFFDShowStillActive()
    {
        if (ffDShowInstanceHandle == IntPtr.Zero)
            return IsFFDShowActive = false;
      
        IsFFDShowActive = User32.IsWindow(ffDShowInstanceHandle);
        return IsFFDShowActive;
    }

    #endregion Loading

    #region Commands
    /// <summary>
    /// Stop video
    /// </summary>
    public void stopVideo()
    {
      PostMessage(FFD_WPRM.PAUSE_VIDEO, 0);
    }

    /// <summary>
    /// Start video
    /// </summary>
    public void startVideo()
    {
      PostMessage(FFD_WPRM.RESUME_VIDEO, 0);
    }

    /// <summary>
    /// Pause video
    /// </summary>
    public void pauseVideo()
    {
      PostMessage(FFD_WPRM.PAUSE_VIDEO, 0);
    }

    /// <summary>
    /// Fast forward
    /// </summary>
    /// <param name="seconds">Step in seconds</param>
    public void FastForward(int seconds)
    {
      if (ffrwNoOSD)
        SendMessage(FFD_WPRM.SET_FFRW_NO_OSD, 1);
      int res = 0;
      if (seconds >= 0)
        res = SendMessage(FFD_WPRM.FASTFORWARD, seconds);
      else
        res = SendMessage(FFD_WPRM.FASTREWIND, -seconds);
    }

    /// <summary>
    /// Rewind
    /// </summary>
    /// <param name="seconds">Step in seconds</param>
    public void FastRewind(int seconds)
    {
      if (ffrwNoOSD)
        SendMessage(FFD_WPRM.SET_FFRW_NO_OSD, 1);
      SendMessage(FFD_WPRM.FASTREWIND, seconds);
    }

    /// <summary>
    /// Stop FastForward or Rewind if active
    /// </summary>
    public void StopFastForward()
    {
      SendMessage(FFD_WPRM.FASTFORWARD, 0);
    }

    /// <summary>
    /// Retrieves the step of FastForward/Rewind (negative if rewind)
    /// </summary>
    /// <returns>Step in seconds</returns>
    public int getFastForwardSpeed()
    {
      return SendMessage(FFD_WPRM.GETFASTFORWARDSPEED, 0);
    }


    /// <summary>
    /// Capture still image of the video being played.
    /// This method used the current capture parameters.
    /// The captureJPGPicture method should be called first
    /// </summary>
    /// <returns>1 if successfull</returns>
    public int captureImage()
    {
      return SendMessage(FFD_WPRM.CAPTUREIMAGE, 0);
    }

    /// <summary>
    /// Sets the position in the timeline of the media being played
    /// </summary>
    /// <param name="time">Time to set in seconds</param>
    public void setCurrentTime(int time)
    {
      int result = SendMessage(FFD_WPRM.SET_CURTIME, time);
    }

    /// <summary>
    /// Enable or disable OSD (On Screen Display)
    /// </summary>
    public void toggleOSD()
    {

      int value = SendMessage(FFD_WPRM.GET_PARAM_VALUE_INT, (int)FFDShowConstants.FFDShowDataId.IDFF_isOSD);
      if (value == 0)
        value = 1;
      else
        value = 0;
      int result = SendMessage(FFD_WPRM.SET_PARAM_NAME, (int)FFDShowConstants.FFDShowDataId.IDFF_isOSD);
      result = PostMessage(FFD_WPRM.SET_PARAM_VALUE_INT, value);
    }


    /// <summary>
    /// Retrieve play state
    /// </summary>
    /// <returns>Play state</returns>
    public PlayState getState()
    {
      return (PlayState)SendMessage(FFD_WPRM.GET_STATE, 0);
    }

    /// <summary>
    /// Retrieve duration of the media being played
    /// </summary>
    /// <returns>Duration in seconds</returns>
    public int getDuration()
    {
      return SendMessage(FFD_WPRM.GET_DURATION, 0);
    }

    /// <summary>
    /// Retrieve the current position in the timeline of the media being played
    /// </summary>
    /// <returns>Current position in seconds</returns>
    public int getCurrentTime()
    {
      return SendMessage(FFD_WPRM.GET_CUR_TIME, 0);
    }

    /// <summary>
    /// Retrieve the frame rate
    /// </summary>
    /// <returns>Retrieve the frame rate (float with decimals eventually)</returns>
    public float getFrameRate()
    {
      int fps1000 = SendMessage(FFD_WPRM.GET_FRAMERATE, 0);
      return (float)fps1000 / 1000;
    }


    /// <summary>
    /// Retrieve the file name being played
    /// </summary>
    /// <returns>File name</returns>
    public string getFileName()
    {
        return getCustomParam(FFD_MSG.GET_SOURCEFILE, 0);//FFDSM_GET_FILENAME);
    }


    /// <summary>
    /// Retrieve the number of embedded subtitles
    /// </summary>
    /// <returns>Returns 0 if no embedded</returns>
    public int getEmbeddedSubtitles()
    {
      return getIntParam(FFDShowConstants.FFDShowDataId.IDFF_subShowEmbedded);
    }


    /// <summary>
    /// Request a (un)registration to FFDShow into the Running Object Table.
    /// It lets retrieve the DirectShow graph
    /// </summary>
    /// <param name="registration">Registration command</param>
    /// <returns>Result of the registration</returns>
    public int setROTRegistration(ROTRegistration registration)
    {
      return SendMessage(FFD_WPRM.SET_ADDTOROT, (int)registration);
    }

    /// <summary>
    /// Display a short OSD (On Screen Display) message
    /// This message will be displayed a few seconds and will disappear automatically
    /// </summary>
    /// <param name="message">Message to be displayed</param>
    public void displayOSDMessage(string message, bool shortMessage)
    {
        COPYDATASTRUCT cd = new COPYDATASTRUCT();
        cd.dwData = new UIntPtr(shortMessage ? (uint)FFDSM_SET_SHORTOSD_MSG : (uint)FFDSM_SET_OSD_MSG);
        cd.lpData = Marshal.StringToHGlobalUni(message);
        cd.cbData = (uint)Kernel32.GlobalSize(cd.lpData);
        
        User32.SendMessage(ffDShowInstanceHandle, (int)Messages.WM_COPYDATA, 0, ref cd);
    }

    /// <summary>
    /// Sets the position of the OSD messages
    /// </summary>
    /// <param name="x">Horizontal position</param>
    /// <param name="y">Vertical position</param>
    public void setOSDPosition(int x, int y)
    {
      SendMessage(FFD_WPRM.SET_OSD_POSX, x);
      SendMessage(FFD_WPRM.SET_OSD_POSY, y);
    }

    public void setOsdDuration(int duration)
    {
        SendMessage(FFD_WPRM.SET_WPRM_SET_OSDDURATION, duration);
    }

    public void clearOsd()
    {
        SendMessage(FFD_WPRM.SET_WPRM_SET_OSD_CLEAN, 0);
    }

    #endregion Commands

    #region Presets commands

    /// <summary>
    /// List of FFDShow audio presets
    /// </summary>
    public static string[] AudioPresets
    {
      get
      {
        using (RegistryKey preferencesKey = Registry.CurrentUser.OpenSubKey(ffdshowAudioRegKey))
        {
          if (preferencesKey != null)
          {
            return preferencesKey.GetSubKeyNames();
          }
          else return null;
        }
      }
    }

    /// <summary>
    /// List of FFDShow video presets
    /// </summary>
    public static string[] VideoPresets
    {
      get
      {
        using (RegistryKey preferencesKey = Registry.CurrentUser.OpenSubKey(ffdshowRegKey))
        {
          if (preferencesKey != null)
          {
            return preferencesKey.GetSubKeyNames();
          }
          else return null;
        }
      }
    }

    /// <summary>
    /// Returns the list of FFDShow video presets
    /// </summary>
    /// <returns>Presets list</returns>
    public string[] getPresetList()
    {
      if (IsFFDShowActive)
      {
        string[] presetList = null;
        string presetListString = getCustomParam(FFD_MSG.GET_PRESETLIST, 0);//FFDSM_GET_PRESETLIST);
        if (presetListString != null)
        {
          presetList = presetListString.Split(';');
        }
        return presetList;
      }
      else
      {
        return VideoPresets;
      }
    }

    /// <summary>
    /// Returns the list of FFDShow audio presets
    /// </summary>
    /// <returns></returns>
    public string[] getAudioPresetList()
    {
      return AudioPresets;
    }
    #endregion Presets commands

    #region Picture grab commands
    /// <summary>
    /// Capture current frame to JPG file
    /// </summary>
    /// <param name="Prefix">Prefix of the file (frame number will be concatenated)</param>
    /// <param name="Path">Path where to store the picture file</param>
    public void captureJPGPicture(string Prefix, string Path)
    {
      PlayState playState = getState();
      if (playState != PlayState.PauseState && playState != PlayState.PlayState)
        return;
      setIntParam(FFDShowConstants.FFDShowDataId.IDFF_grabFormat, 0);
      setIntParam(FFDShowConstants.FFDShowDataId.IDFF_grabMode, 1);
      setIntParam(FFDShowConstants.FFDShowDataId.IDFF_grabDigits, 0);
      setStringParam(FFDShowConstants.FFDShowDataId.IDFF_grabPrefix, Prefix);
      setStringParam(FFDShowConstants.FFDShowDataId.IDFF_grabPath, Path);
      captureImage();
      if (playState == PlayState.PauseState)
      {
        startVideo();
        Thread.Sleep(600);
        pauseVideo();
      }
      else
        Thread.Sleep(600);
    }
    #endregion

    #region Base commands

    public static int FFDShowRevision
    {
      get
      {
        try
        {
          using (RegistryKey ffdshowGlobalKey = Registry.LocalMachine.OpenSubKey(FFDShowRegKey))
          {
            return (int)ffdshowGlobalKey.GetValue("revision", 0);
          }
        }
        catch (Exception) { }
        return 0;
      }
    }

    /// <summary>
    /// Retrieve a parameter from FFDShow. The requested parameter must match to an integer type
    /// </summary>
    /// <param name="param">Parameter to retrieve</param>
    /// <returns>Value of the parameter</returns>
    public int getIntParam(FFDShowConstants.FFDShowDataId param)
    {
        return SendMessage(FFD_WPRM.GET_PARAM_VALUE_INT, (int)param);
    }

    /// <summary>
    /// Set the value of a parameter to FFDShow. The requested parameter must match to an integer type
    /// </summary>
    /// <param name="param">Parameter to set</param>
    /// <param name="value">Value to set</param>
    public void setIntParam(FFDShowConstants.FFDShowDataId param, int value)
    {
        SendMessage(FFD_WPRM.SET_PARAM_NAME, (int)param);
        SendMessage(FFD_WPRM.SET_PARAM_VALUE_INT, value);
    }

    /// <summary>
    /// Retrieve a parameter from FFDShow. The requested parameter must match to a string type
    /// </summary>
    /// <param name="type">Type of parameter to retrieve.</param>
    /// <param name="param">Empty if type is different from FFD_MSG.GETPARAMSTR, otherwise the identifier of the string parameter to retrieve</param>
    /// <returns></returns>
    public string getCustomParam(FFD_MSG type, FFDShowConstants.FFDShowDataId param)
    {
      if (receiver == null)
        receiver = new FFDShowReceiver(Thread.CurrentThread);

      receiver.ReceivedString = null;
      receiver.ReceivedType = 0;
      IntPtr ret = new IntPtr(0);
      User32.SendMessageTimeout(ffDShowInstanceHandle, (int)type, receiver.Handle, new IntPtr((int)param),
          SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, requestTimeout, out ret);

      if (ret.ToInt32() != 1)
        return null;

      if (receiver.ReceivedType == 0)
      {
        try
        {
          Thread.Sleep(requestTimeout);
        }
        catch (ThreadInterruptedException) 
        { 
        };
      }

      // Check that the received string corresponds to the paramId we requested
      if ((param != 0 && receiver.ReceivedType == (int)param) || receiver.ReceivedType == (int)type)
        return receiver.ReceivedString;
      else return null;
    }

    /// <summary>
    /// Retrieve a string parameter from FFDShow.
    /// Same behaviour as getCustomParam(FFD_MSG.GETPARAMSTR, param)
    /// </summary>
    /// <param name="param">Parameter to retrieve</param>
    /// <returns>String value of the parameter</returns>
    public string getStringParam(FFDShowConstants.FFDShowDataId param)
    {
        return getCustomParam(FFD_MSG.GET_PARAMSTR, param);
    }

    /// <summary>
    /// Set a string parameter to FFDShow
    /// </summary>
    /// <param name="param">Identifier of the parameter</param>
    /// <param name="value"></param>
    /// <returns></returns>
    public int setStringParam(FFDShowConstants.FFDShowDataId param, string value)
    {
        int result = SendMessage(FFD_WPRM.SET_PARAM_NAME, (int)param);

        COPYDATASTRUCT cd = new COPYDATASTRUCT();
        cd.dwData = new UIntPtr((uint)FFD_WPRM.SET_PARAM_VALUE_STR);
        cd.lpData = Marshal.StringToHGlobalUni(value);
        cd.cbData = (uint)Kernel32.GlobalSize(cd.lpData);
        IntPtr returnedValue = new IntPtr(0);

        User32.SendMessageTimeout(ffDShowInstanceHandle, (int)(int)Messages.WM_COPYDATA, 
            receiver.Handle, ref cd, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, (int)requestTimeout, 
            out returnedValue);

        Marshal.FreeHGlobal(cd.lpData);
        return returnedValue.ToInt32();
    }

    private int SendMessage(FFD_WPRM wParam, int lParam)
    {
        return User32.SendMessage(ffDShowInstanceHandle.ToInt32(), FFDShowAPIRemoteId, (int)wParam, lParam).ToInt32();
    }

    private int PostMessage(FFD_WPRM wParam, int lParam)
    {
        return User32.PostMessage(ffDShowInstanceHandle.ToInt32(), FFDShowAPIRemoteId, (int)wParam, lParam).ToInt32();
    }

    #endregion Base commands
  }
}

#endif