using System;
using System.Collections.Generic;
using System.Text;
using OPMedia.Core.Logging;
using System.Threading;
using OPMedia.Core;
using System.Windows.Forms;
using System.Drawing;
using OPMedia.UI.Generic;
using OPMedia.Core.ApplicationSettings;
using OPMedia.Runtime.ProTONE.Rendering;

namespace OPMedia.Runtime.ProTONE.FfdShowApi
{
    public static class FfdShowHelper
    {
        static IntPtr _oldHandle = IntPtr.Zero;

        public static string CurrentSubtitleFile
        {
            get
            {
                using (FfdShowLib i = FfdShowInstance())
                {
                    return i.CurrentSubtitleFile;
                }
            }

            set
            {
                using (FfdShowLib i = FfdShowInstance())
                {
                    i.CurrentSubtitleFile = value;
                }
            }
        }

        public static void DisplayOsdMessage(string msg)
        {
            if (AppSettings.OsdEnabled)
            {
                using (FfdShowLib i = FfdShowInstance())
                {
                    int osdPersistTimer = AppSettings.OsdPersistTimer;
                    float frameRate = i.getFrameRate();
                    int persistFrames = (int)(osdPersistTimer * frameRate / 1000);

                    // OsdPersistTimer is given in msec
                    i.clearOsd();
                    i.setOsdDuration(persistFrames);
                    i.displayOSDMessage(msg, true);
                }
            }
        }

        public static void ReloadSettings()
        {
            using (FfdShowLib i = FfdShowInstance())
            {
                EnforceSettings(i);
            }
        }

        private static void EnforceSettings(FfdShowLib ffdShowLib)
        {
            // Subtitles
            ffdShowLib.DoShowSubtitles = AppSettings.SubEnabled;

            if (AppSettings.SubEnabled)
            {
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontColor,
                    ColorHelper.BGR(AppSettings.SubColor));
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontSizeA,
                    AppSettings.SubFont.Height);
                ffdShowLib.setStringParam(FFDShowConstants.FFDShowDataId.IDFF_fontName,
                    AppSettings.SubFont.OriginalFontName);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontCharset,
                  AppSettings.SubFont.GdiCharSet);

                LOGFONT lf = new LOGFONT();
                AppSettings.SubFont.ToLogFont(lf);

                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontWeight,
                    lf.lfWeight);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontItalic,
                   lf.lfItalic);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_fontUnderline,
                   lf.lfUnderline);
            }

            if (AppSettings.OsdEnabled)
            {
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontColor,
                    ColorHelper.BGR(AppSettings.OsdColor));
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontSize,
                    AppSettings.OsdFont.Height);
                ffdShowLib.setStringParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontName,
                    AppSettings.OsdFont.OriginalFontName);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontCharset,
                    AppSettings.OsdFont.GdiCharSet);

                LOGFONT lf = new LOGFONT();
                AppSettings.OsdFont.ToLogFont(lf);

                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontWeight,
                    lf.lfWeight);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontItalic,
                   lf.lfItalic);
                ffdShowLib.setIntParam(FFDShowConstants.FFDShowDataId.IDFF_OSDfontUnderline,
                   lf.lfUnderline);
            }
        }

        private static FfdShowLib FfdShowInstance()
        {
            string renderFile = MediaRenderer.DefaultInstance.GetRenderFile();
            FfdShowLib ffdShowLib = new FfdShowLib(renderFile);

            if (ffdShowLib.checkFFDShowActive())
            {
                if (ffdShowLib.FFDShowInstanceHandle != _oldHandle)
                {
                    // API re-created so enforce parameters
                    EnforceSettings(ffdShowLib);

                    _oldHandle = ffdShowLib.FFDShowInstanceHandle;
                }
            }

            return ffdShowLib;
        }
    }
}
