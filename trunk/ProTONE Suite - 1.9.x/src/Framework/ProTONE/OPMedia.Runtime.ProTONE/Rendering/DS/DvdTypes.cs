#if HAVE_DSHOW

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using OPMedia.Runtime.ProTONE.Rendering.Base;
using OPMedia.Runtime.ProTONE.Rendering.DS.BaseClasses;
using System.Text;


namespace OPMedia.Runtime.ProTONE.Rendering.DS
{
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5a4a97e4-94ee-4a55-9751-74b5643aa27d")]
    public interface IDvdCmd
    {
        [PreserveSig]
        void WaitForStart();
        [PreserveSig]
        void WaitForEnd();
    }

    [ComImport, Guid("A70EFE61-E2A3-11d0-A9BE-00AA0061BE93"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdControl
    {
        [PreserveSig]
        int TitlePlay([In] int ulTitle);

        [PreserveSig]
        int ChapterPlay(
            [In] int ulTitle,
            [In] int ulChapter
            );

        [PreserveSig]
        int TimePlay(
            [In] int ulTitle,
            [In] int bcdTime
            );

        [PreserveSig]
        int StopForResume();

        [PreserveSig]
        int GoUp();

        [PreserveSig]
        int TimeSearch([In] int bcdTime);

        [PreserveSig]
        int ChapterSearch([In] int ulChapter);

        [PreserveSig]
        int PrevPGSearch();

        [PreserveSig]
        int TopPGSearch();

        [PreserveSig]
        int NextPGSearch();

        [PreserveSig]
        int ForwardScan([In] double dwSpeed);

        [PreserveSig]
        int BackwardScan([In] double dwSpeed);

        [PreserveSig]
        int MenuCall([In] DvdMenuId MenuID);

        [PreserveSig]
        int Resume();

        [PreserveSig]
        int UpperButtonSelect();

        [PreserveSig]
        int LowerButtonSelect();

        [PreserveSig]
        int LeftButtonSelect();

        [PreserveSig]
        int RightButtonSelect();

        [PreserveSig]
        int ButtonActivate();

        [PreserveSig]
        int ButtonSelectAndActivate([In] int ulButton);

        [PreserveSig]
        int StillOff();

        [PreserveSig]
        int PauseOn();

        [PreserveSig]
        int PauseOff();

        [PreserveSig]
        int MenuLanguageSelect([In] int Language);

        [PreserveSig]
        int AudioStreamChange([In] int ulAudio);

        [PreserveSig]
        int SubpictureStreamChange(
            [In] int ulSubPicture,
            [In, MarshalAs(UnmanagedType.Bool)] bool bDisplay
            );

        [PreserveSig]
        int AngleChange([In] int ulAngle);

        [PreserveSig]
        int ParentalLevelSelect([In] int ulParentalLevel);

        [PreserveSig]
        int ParentalCountrySelect([In] short wCountry);

        [PreserveSig]
        int KaraokeAudioPresentationModeChange([In] int ulMode);

        [PreserveSig]
        int VideoModePreferrence([In] int ulPreferredDisplayMode);

        [PreserveSig]
        int SetRoot([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

        [PreserveSig]
        int MouseActivate([In] Point point);

        [PreserveSig]
        int MouseSelect([In] Point point);

        [PreserveSig]
        int ChapterPlayAutoStop(
            [In] int ulTitle,
            [In] int ulChapter,
            [In] int ulChaptersToPlay
            );
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class OptIDvdCmd
    {
        public IDvdCmd dvdCmd;
    }

    [ComVisible(true), ComImport,
       Guid("33BC7430-EEC0-11D2-8201-00A0C9D74842"),
       InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]

    public interface IDvdControl2
    {
        [PreserveSig]
        int PlayTitle(int ulTitle, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayChapterInTitle(int ulTitle, int ulChapter, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayAtTimeInTitle(int ulTitle, [In] ref DvdHMSFTimeCode pStartTime, DvdCmdFlags dwFlags,
               [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int Stop();

        [PreserveSig]
        int ReturnFromSubmenu(DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayAtTime([In] ref DvdHMSFTimeCode pTime, DvdCmdFlags dwFlags,
               [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayChapter(int ulChapter, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayPrevChapter(DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int ReplayChapter(DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayNextChapter(DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayForwards(double dSpeed, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayBackwards(double dSpeed, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int ShowMenu(DvdMenuId MenuID, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int Resume(DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int SelectRelativeButton(DvdRelativeButton buttonDir);

        [PreserveSig]
        int ActivateButton();

        [PreserveSig]
        int SelectButton(int ulButton);

        [PreserveSig]
        int SelectAndActivateButton(int ulButton);

        [PreserveSig]
        int StillOff();

        [PreserveSig]
        int Pause(
                [In, MarshalAs(UnmanagedType.Bool)]                             bool bState);

        [PreserveSig]
        int SelectAudioStream(int ulAudio, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int SelectSubpictureStream(int ulSubPicture, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int SetSubpictureState(
                [In, MarshalAs(UnmanagedType.Bool)]                             bool bState,
                                                                                                                DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int SelectAngle(int ulAngle, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int SelectParentalLevel(int ulParentalLevel);

        [PreserveSig]
        int SelectParentalCountry(byte[] bCountry);

        [PreserveSig]
        int SelectKaraokeAudioPresentationMode(int ulMode);

        [PreserveSig]
        int SelectVideoModePreference(int ulPreferredDisplayMode);

        [PreserveSig]
        int SetDVDDirectory(
                [In, MarshalAs(UnmanagedType.LPWStr)]                   string pszwPath);

        [PreserveSig]
        int ActivateAtPosition(DsPOINT point);

        [PreserveSig]
        int SelectAtPosition(DsPOINT point);

        [PreserveSig]
        int PlayChaptersAutoStop(int ulTitle, int ulChapter, int ulChaptersToPlay, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int AcceptParentalLevelChange(
                [In, MarshalAs(UnmanagedType.Bool)]                             bool bAccept);

        [PreserveSig]
        int SetOption(DvdOptionFlag flag,
                [In, MarshalAs(UnmanagedType.Bool)]                             bool fState);

        [PreserveSig]
        int SetState(IDvdState pState, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int PlayPeriodInTitleAutoStop(int ulTitle,
                [In]                                                                            ref DvdHMSFTimeCode pStartTime,
                [In]                                                                            ref DvdHMSFTimeCode pEndTime,
                                                                                                                DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int SetGPRM(int ulIndex, short wValue, DvdCmdFlags dwFlags,
                [Out]                                                                                   OptIDvdCmd ppCmd);

        [PreserveSig]
        int SelectDefaultMenuLanguage(int Language);

        [PreserveSig]
        int SelectDefaultAudioLanguage(int Language, DvdAudioLangExt audioExtension);

        [PreserveSig]
        int SelectDefaultSubpictureLanguage(int Language, DvdSubPictureLangExt subpictureExtension);
    }



    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("FCC152B6-F372-11d0-8E00-00C04FD7C08B")]
    public interface IDvdGraphBuilder
    {
        [PreserveSig]
        void GetFiltergraph(out IMediaControl pMC);
        [PreserveSig]
        void GetDvdInterface([In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvIF);
        [PreserveSig]
        void RenderDvdVideoVolume([In, MarshalAs(UnmanagedType.LPWStr)] string lpcwszPathName, [In] AMDvdGraphFlags dwFlags, out AMDvdRenderStatus pStatus);
    }

    [ComImport, Guid("34151510-EEC0-11D2-8201-00A0C9D74842"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdInfo2
    {
        [PreserveSig]
        void GetCurrentDomain(out DvdDomain pDomain);
        [PreserveSig]
        void GetCurrentLocation(out DvdPlaybackLocation2 pLocation);
        [PreserveSig]
        void GetTotalTitleTime(out DvdHMSFTimeCode pTotalTime, out DvdTimeCodeFlags ulTimeCodeFlags);
        [PreserveSig]
        void GetCurrentButton(out int pulButtonsAvailable, out int pulCurrentButton);
        [PreserveSig]
        void GetCurrentAngle(out int pulAnglesAvailable, out int pulCurrentAngle);
        [PreserveSig]
        void GetCurrentAudio(out int pulStreamsAvailable, out int pulCurrentStream);
        [PreserveSig]
        void GetCurrentSubpicture(out int pulStreamsAvailable, out int pulCurrentStream, [MarshalAs(UnmanagedType.Bool)] out bool pbIsDisabled);
        [PreserveSig]
        void GetCurrentUOPS(out ValidUOPFlag pulUOPs);
        [PreserveSig]
        void GetAllSPRMs(out SPRMArray pRegisterArray);
        [PreserveSig]
        void GetAllGPRMs(out GPRMArray pRegisterArray);
        [PreserveSig]
        void GetAudioLanguage([In] int ulStream, out int pLanguage);
        [PreserveSig]
        void GetSubpictureLanguage([In] int ulStream, out int pLanguage);
        [PreserveSig]
        void GetTitleAttributes([In] int ulTitle, out DvdMenuAttributes pMenu, [In, Out] DvdTitleAttributes pTitle);
        [PreserveSig]
        void GetVMGAttributes(out DvdMenuAttributes pATR);
        [PreserveSig]
        void GetCurrentVideoAttributes(out DvdVideoAttributes pATR);
        [PreserveSig]
        void GetAudioAttributes([In] int ulStream, out DvdAudioAttributes pATR);
        [PreserveSig]
        void GetKaraokeAttributes([In] int ulStream, [In, Out] DvdKaraokeAttributes pAttributes);
        [PreserveSig]
        void GetSubpictureAttributes([In] int ulStream, out DvdSubpictureAttributes pATR);
        [PreserveSig]
        void GetDVDVolumeInfo(out int pulNumOfVolumes, out int pulVolume, out DvdDiscSide pSide, out int pulNumOfTitles);
        [PreserveSig]
        void GetDVDTextNumberOfLanguages(out int pulNumOfLangs);
        [PreserveSig]
        void GetDVDTextLanguageInfo([In] int ulLangIndex, out int pulNumOfStrings, out int pLangCode, out DvdTextCharSet pbCharacterSet);
        [PreserveSig]
        void GetDVDTextStringAsNative([In] int ulLangIndex, [In] int ulStringIndex, [MarshalAs(UnmanagedType.LPStr)] StringBuilder pbBuffer, [In] int ulMaxBufferSize, out int pulActualSize, out DvdTextStringType pType);
        [PreserveSig]
        void GetDVDTextStringAsUnicode([In] int ulLangIndex, [In] int ulStringIndex, StringBuilder pchwBuffer, [In] int ulMaxBufferSize, out int pulActualSize, out DvdTextStringType pType);
        [PreserveSig]
        void GetPlayerParentalLevel(out int pulParentalLevel, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, SizeConst = 2)] byte[] pbCountryCode);
        [PreserveSig]
        void GetNumberOfChapters([In] int ulTitle, out int pulNumOfChapters);
        [PreserveSig]
        void GetTitleParentalLevels([In] int ulTitle, out DvdParentalLevel pulParentalLevels);
        [PreserveSig]
        void GetDVDDirectory(StringBuilder pszwPath, [In] int ulMaxSize, out int pulActualSize);
        [PreserveSig]
        void IsAudioStreamEnabled([In] int ulStreamNum, [MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);
        [PreserveSig]
        void GetDiscID([In, MarshalAs(UnmanagedType.LPWStr)] string pszwPath, out long pullDiscID);
        [PreserveSig]
        void GetState(out IDvdState pStateData);
        [PreserveSig]
        void GetMenuLanguages([MarshalAs(UnmanagedType.LPArray)] int[] pLanguages, [In] int ulMaxLanguages, out int pulActualLanguages);
        [PreserveSig]
        void GetButtonAtPosition([In] Point point, out int pulButtonIndex);
        [PreserveSig]
        void GetCmdFromEvent([In] int lParam1, out IDvdCmd pCmdObj);
        [PreserveSig]
        void GetDefaultMenuLanguage(out int pLanguage);
        [PreserveSig]
        int GetDefaultAudioLanguage(out int pLanguage, out DvdAudioLangExt pAudioExtension);
        [PreserveSig]
        void GetDefaultSubpictureLanguage(out int pLanguage, out DvdSubPictureLangExt pSubpictureExtension);
        [PreserveSig]
        void GetDecoderCaps(ref DvdDecoderCaps pCaps);
        [PreserveSig]
        void GetButtonRect([In] int ulButton, [Out] DsRect pRect);
        [PreserveSig]
        void IsSubpictureStreamEnabled([In] int ulStreamNum, [MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);
    }

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("86303d6d-1c4a-4087-ab42-f711167048ef")]
    public interface IDvdState
    {
        [PreserveSig]
        void GetDiscID(out long pullUniqueID);
        [PreserveSig]
        void GetParentalLevel(out int pulParentalLevel);
    }
}

#endif
