using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using OPMedia.UI.Wizards;
using OPMedia.Core.TranslationSupport;
using OPMedia.Runtime.ProTONE.FileInformation;
using System.IO;
using OPMedia.Core;
using OPMedia.UI;
using OPMedia.Runtime;
using OPMedia.Core.Utilities;
using OPMedia.Addons.Builtin.Navigation.FileExplorer.FileOperations.Tasks;
using OPMedia.UI.FileTasks;
using System.Drawing.Design;

namespace OPMedia.Addons.Builtin.TaggedFileProp.TaggingWizard
{
    public enum TaskType
    {
        MultiRename,
        EditTag,
        FillTagByFS,
    }

    public class Task : BackgroundTask
    {
        #region Task Properties
        string artist = "<A>";
        [Browsable(true)]
        [TranslatableDisplayName("TXT_ARTIST")]
        [TranslatableCategory("TXT_TAGINFO_PATTERNS")]
        public string Artist
        { get { return artist; } set { artist = value; } }

        string album = "<B>";
        [Browsable(true)]
        [TranslatableDisplayName("TXT_ALBUM")]
        [TranslatableCategory("TXT_TAGINFO_PATTERNS")]
        public string Album
        { get { return album; } set { album = value; } }

        string title = "<T>";
        [Browsable(true)]
        [TranslatableDisplayName("TXT_TITLE")]
        [TranslatableCategory("TXT_TAGINFO_PATTERNS")]
        public string Title
        { get { return title; } set { title = value; } }

        string comments = "<C>";
        [Browsable(true)]
        [TranslatableDisplayName("TXT_COMMENTS")]
        [TranslatableCategory("TXT_TAGINFO_PATTERNS")]
        public string Comments
        { get { return comments; } set { comments = value; } }

        string genre = "<G>";
        [Browsable(true)]
        [TranslatableDisplayName("TXT_GENRE")]
        [TranslatableCategory("TXT_TAGINFO_PATTERNS")]
        [Editor("OPMedia.Runtime.ProTONE.GenrePropertyBrowser, OPMedia.Runtime.ProTONE", typeof(UITypeEditor))]
        public string Genre
        { get { return genre; } set { genre = value; } }

        string track = "<#>";
        [Browsable(true)]
        [TranslatableDisplayName("TXT_TRACK")]
        [TranslatableCategory("TXT_TAGINFO_PATTERNS")]

        public string Track
        { get { return track; } set { track = value; } }

        string year = "<Y>";
        [Browsable(true)]
        [TranslatableDisplayName("TXT_YEAR")]
        [TranslatableCategory("TXT_TAGINFO_PATTERNS")]

        public string Year
        { get { return year; } set { year = value; } }
        
        string tagFilePattern = "<A> - <T>";
        [Browsable(false)]
        public string TagFilePattern
        { get { return tagFilePattern; } set { tagFilePattern = value; } }


        string tagFolderPattern = "<A> - <B>";
        [Browsable(false)]
        public string TagFolderPattern
        { get { return tagFolderPattern; } set { tagFolderPattern = value; } }


        string remamePattern = "<N>";
        [Browsable(false)]
        public string RemamePattern
        { get { return remamePattern; } set { remamePattern = value; } }
        
        TaskType taskType = TaskType.MultiRename;
        [Browsable(false)]
        public TaskType TaskType
        { get { return taskType; } set { taskType = value; } }

        List<string> files = new List<string>();
        [Browsable(false)]
        public List<string> Files
        { get { return files; } set { files = value; } }

        WordCasing _wordCasing = WordCasing.KeepCase;
        [Browsable(false)]
        public WordCasing WordCasing
        { get { return _wordCasing; } set { _wordCasing = value; } }

        #endregion

        #region BackgroundTask overrides
        [Browsable(false)]
        public override int CurrentStep
        {
            get { return currentStep; }
        }

        [Browsable(false)]
        public override int TotalSteps
        {
            get { return files.Count; }
        }

        [Browsable(false)]
        public override StepDetail RunNextStep()
        {
            StepDetail result = ProcessFile(files[currentStep]);
            currentStep++;
            return result;
        }

        public override void Reset()
        {
            currentStep = 0;
        }

        int currentStep = 0;
        [Browsable(false)]
        public override bool IsFinished
        { get { return (currentStep >= files.Count); } }
        #endregion

        #region Implementation
        private StepDetail ProcessFile(string file)
        {
            StepDetail detail = new StepDetail();
            detail.Description = "TXT_PROCESSING_FILE: " + file;
            RaiseTaskStepInitEvent(detail);

            detail.Results = Translator.Translate("TXT_UNHANDLED");
            detail.IsSuccess = false;

            try
            {
                switch (taskType)
                {
                    case TaskType.MultiRename:
                        detail.Results = RenameFile(file);
                        break;

                    case TaskType.EditTag:
                        detail.Results = ChangeTag(file);
                        break;

                    case TaskType.FillTagByFS:
                        detail.Results = GenerateTag(file);
                        break;
                }

                detail.IsSuccess = true;
            }
            catch (Exception ex)
            {
                detail.Results = ex.Message;
                detail.IsSuccess = false;
            }

            return detail;
        }

        private string RenameFile(string oldPath)
        {
            string newPath = new TaggedMediaFileRenamer(oldPath, remamePattern).GetNewPath(_wordCasing);

            FEFileTaskSupport support = new FEFileTaskSupport(null);

            FileInfo fi = new FileInfo(oldPath);
            List<string> linkedFiles = support.GetChildFiles(fi, FileTaskType.Move);

            File.Move(oldPath, newPath);

            if (linkedFiles != null)
            {
                string oldName = Path.GetFileNameWithoutExtension(oldPath);
                string newName = Path.GetFileNameWithoutExtension(newPath);

                foreach (string linkedFile in linkedFiles)
                {
                    string newLinkedFile = linkedFile.Replace(oldName, newName);
                    File.Move(linkedFile, StringUtils.Capitalize(newLinkedFile, _wordCasing));
                }
            }

            files[currentStep] = newPath;
            return Translator.Translate("TXT_SUCCESS");
        }

        private string ChangeTag(string path)
        {
            new MediaFileTagger(path, this).UpdateTag(_wordCasing);
            return Translator.Translate("TXT_SUCCESS");
        }

        private string GenerateTag(string path)
        {
            new MediaFileTagger(path, this).FillTagFromFileFolderName(_wordCasing);
            return Translator.Translate("TXT_SUCCESS");
        }
        #endregion
    }
}
