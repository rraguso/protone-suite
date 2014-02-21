using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#pragma warning disable 1591

namespace OPMedia.Runtime.ProTONE.NuSoap
{
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "searchSubtitles_wsdlBinding", Namespace = "api.getsubtitle.com/nusoap")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(Language))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(SubtitleArchive))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(SubtitleDownload))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(findSubtitleFile))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(SubtitleFile))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(Subtitle))]
    public partial class NuSoapWsdl : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback searchSubtitlesOperationCompleted;

        private System.Threading.SendOrPostCallback searchSubtitlesByHashOperationCompleted;

        private System.Threading.SendOrPostCallback findSubtitlesByHashOperationCompleted;

        private System.Threading.SendOrPostCallback downloadSubtitlesOperationCompleted;

        private System.Threading.SendOrPostCallback getLanguagesOperationCompleted;

        private System.Threading.SendOrPostCallback uploadSubtitleOperationCompleted;

        private System.Threading.SendOrPostCallback uploadSubtitle2OperationCompleted;

        private bool useDefaultCredentialsSetExplicitly;

        /// <remarks/>
        public NuSoapWsdl(string url)
        {
            this.Url = url;
            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        public new string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true)
                            && (this.useDefaultCredentialsSetExplicitly == false))
                            && (this.IsLocalFileSystemWebService(value) == false)))
                {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        public new bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        /// <remarks/>
        public event searchSubtitlesCompletedEventHandler searchSubtitlesCompleted;

        /// <remarks/>
        public event searchSubtitlesByHashCompletedEventHandler searchSubtitlesByHashCompleted;

        /// <remarks/>
        public event findSubtitlesByHashCompletedEventHandler findSubtitlesByHashCompleted;

        /// <remarks/>
        public event downloadSubtitlesCompletedEventHandler downloadSubtitlesCompleted;

        /// <remarks/>
        public event getLanguagesCompletedEventHandler getLanguagesCompleted;

        /// <remarks/>
        public event uploadSubtitleCompletedEventHandler uploadSubtitleCompleted;

        /// <remarks/>
        public event uploadSubtitle2CompletedEventHandler uploadSubtitle2Completed;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("searchSubtitles_wsdl#searchSubtitles", RequestNamespace = "searchSubtitles_wsdl", ResponseNamespace = "searchSubtitles_wsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public Subtitle[] searchSubtitles(string query, string language, int index, int count)
        {
            object[] results = this.Invoke("searchSubtitles", new object[] {
                    query,
                    language,
                    index,
                    count});
            return ((Subtitle[])(results[0]));
        }

        /// <remarks/>
        public void searchSubtitlesAsync(string query, string language, int index, int count)
        {
            this.searchSubtitlesAsync(query, language, index, count, null);
        }

        /// <remarks/>
        public void searchSubtitlesAsync(string query, string language, int index, int count, object userState)
        {
            if ((this.searchSubtitlesOperationCompleted == null))
            {
                this.searchSubtitlesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsearchSubtitlesOperationCompleted);
            }
            this.InvokeAsync("searchSubtitles", new object[] {
                    query,
                    language,
                    index,
                    count}, this.searchSubtitlesOperationCompleted, userState);
        }

        private void OnsearchSubtitlesOperationCompleted(object arg)
        {
            if ((this.searchSubtitlesCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.searchSubtitlesCompleted(this, new searchSubtitlesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("searchSubtitlesByHash_wsdl#searchSubtitlesByHash", RequestNamespace = "searchSubtitlesByHash_wsdl", ResponseNamespace = "searchSubtitlesByHash_wsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public SubtitleFile[] searchSubtitlesByHash(string hash, string language, int index, int count)
        {
            object[] results = this.Invoke("searchSubtitlesByHash", new object[] {
                    hash,
                    language,
                    index,
                    count});
            return ((SubtitleFile[])(results[0]));
        }

        /// <remarks/>
        public void searchSubtitlesByHashAsync(string hash, string language, int index, int count)
        {
            this.searchSubtitlesByHashAsync(hash, language, index, count, null);
        }

        /// <remarks/>
        public void searchSubtitlesByHashAsync(string hash, string language, int index, int count, object userState)
        {
            if ((this.searchSubtitlesByHashOperationCompleted == null))
            {
                this.searchSubtitlesByHashOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsearchSubtitlesByHashOperationCompleted);
            }
            this.InvokeAsync("searchSubtitlesByHash", new object[] {
                    hash,
                    language,
                    index,
                    count}, this.searchSubtitlesByHashOperationCompleted, userState);
        }

        private void OnsearchSubtitlesByHashOperationCompleted(object arg)
        {
            if ((this.searchSubtitlesByHashCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.searchSubtitlesByHashCompleted(this, new searchSubtitlesByHashCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("findSubtitlesByHash_wsdl#findSubtitlesByHash", RequestNamespace = "findSubtitlesByHash_wsdl", ResponseNamespace = "findSubtitlesByHash_wsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public findSubtitleFile[] findSubtitlesByHash(string hash, string language, int index, int count)
        {
            object[] results = this.Invoke("findSubtitlesByHash", new object[] {
                    hash,
                    language,
                    index,
                    count});
            return ((findSubtitleFile[])(results[0]));
        }

        /// <remarks/>
        public void findSubtitlesByHashAsync(string hash, string language, int index, int count)
        {
            this.findSubtitlesByHashAsync(hash, language, index, count, null);
        }

        /// <remarks/>
        public void findSubtitlesByHashAsync(string hash, string language, int index, int count, object userState)
        {
            if ((this.findSubtitlesByHashOperationCompleted == null))
            {
                this.findSubtitlesByHashOperationCompleted = new System.Threading.SendOrPostCallback(this.OnfindSubtitlesByHashOperationCompleted);
            }
            this.InvokeAsync("findSubtitlesByHash", new object[] {
                    hash,
                    language,
                    index,
                    count}, this.findSubtitlesByHashOperationCompleted, userState);
        }

        private void OnfindSubtitlesByHashOperationCompleted(object arg)
        {
            if ((this.findSubtitlesByHashCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.findSubtitlesByHashCompleted(this, new findSubtitlesByHashCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("downloadSubtitles_wsdl#downloadSubtitles", RequestNamespace = "downloadSubtitles_wsdl", ResponseNamespace = "downloadSubtitles_wsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public SubtitleArchive[] downloadSubtitles(SubtitleDownload[] subtitles)
        {
            object[] results = this.Invoke("downloadSubtitles", new object[] {
                    subtitles});
            return ((SubtitleArchive[])(results[0]));
        }

        /// <remarks/>
        public void downloadSubtitlesAsync(SubtitleDownload[] subtitles)
        {
            this.downloadSubtitlesAsync(subtitles, null);
        }

        /// <remarks/>
        public void downloadSubtitlesAsync(SubtitleDownload[] subtitles, object userState)
        {
            if ((this.downloadSubtitlesOperationCompleted == null))
            {
                this.downloadSubtitlesOperationCompleted = new System.Threading.SendOrPostCallback(this.OndownloadSubtitlesOperationCompleted);
            }
            this.InvokeAsync("downloadSubtitles", new object[] {
                    subtitles}, this.downloadSubtitlesOperationCompleted, userState);
        }

        private void OndownloadSubtitlesOperationCompleted(object arg)
        {
            if ((this.downloadSubtitlesCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.downloadSubtitlesCompleted(this, new downloadSubtitlesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("getLanguages_wsdl#getLanguages", RequestNamespace = "getLanguages_wsdl", ResponseNamespace = "getLanguages_wsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public Language[] getLanguages()
        {
            object[] results = this.Invoke("getLanguages", new object[0]);
            return ((Language[])(results[0]));
        }

        /// <remarks/>
        public void getLanguagesAsync()
        {
            this.getLanguagesAsync(null);
        }

        /// <remarks/>
        public void getLanguagesAsync(object userState)
        {
            if ((this.getLanguagesOperationCompleted == null))
            {
                this.getLanguagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetLanguagesOperationCompleted);
            }
            this.InvokeAsync("getLanguages", new object[0], this.getLanguagesOperationCompleted, userState);
        }

        private void OngetLanguagesOperationCompleted(object arg)
        {
            if ((this.getLanguagesCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getLanguagesCompleted(this, new getLanguagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("uploadSubtitle_wsdl#uploadSubtitle", RequestNamespace = "uploadSubtitle_wsdl", ResponseNamespace = "uploadSubtitle_wsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string uploadSubtitle(string movieHash, int movieByteSize, string subtitle, string format, string fileName, string fps)
        {
            object[] results = this.Invoke("uploadSubtitle", new object[] {
                    movieHash,
                    movieByteSize,
                    subtitle,
                    format,
                    fileName,
                    fps});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void uploadSubtitleAsync(string movieHash, int movieByteSize, string subtitle, string format, string fileName, string fps)
        {
            this.uploadSubtitleAsync(movieHash, movieByteSize, subtitle, format, fileName, fps, null);
        }

        /// <remarks/>
        public void uploadSubtitleAsync(string movieHash, int movieByteSize, string subtitle, string format, string fileName, string fps, object userState)
        {
            if ((this.uploadSubtitleOperationCompleted == null))
            {
                this.uploadSubtitleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnuploadSubtitleOperationCompleted);
            }
            this.InvokeAsync("uploadSubtitle", new object[] {
                    movieHash,
                    movieByteSize,
                    subtitle,
                    format,
                    fileName,
                    fps}, this.uploadSubtitleOperationCompleted, userState);
        }

        private void OnuploadSubtitleOperationCompleted(object arg)
        {
            if ((this.uploadSubtitleCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.uploadSubtitleCompleted(this, new uploadSubtitleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("uploadSubtitle2_wsdl#uploadSubtitle", RequestNamespace = "uploadSubtitle2_wsdl", ResponseNamespace = "uploadSubtitle2_wsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string uploadSubtitle2(string movieHash, int movieByteSize, string subtitle, string format, string fileName, string fps, string language)
        {
            object[] results = this.Invoke("uploadSubtitle2", new object[] {
                    movieHash,
                    movieByteSize,
                    subtitle,
                    format,
                    fileName,
                    fps,
                    language});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void uploadSubtitle2Async(string movieHash, int movieByteSize, string subtitle, string format, string fileName, string fps, string language)
        {
            this.uploadSubtitle2Async(movieHash, movieByteSize, subtitle, format, fileName, fps, language, null);
        }

        /// <remarks/>
        public void uploadSubtitle2Async(string movieHash, int movieByteSize, string subtitle, string format, string fileName, string fps, string language, object userState)
        {
            if ((this.uploadSubtitle2OperationCompleted == null))
            {
                this.uploadSubtitle2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnuploadSubtitle2OperationCompleted);
            }
            this.InvokeAsync("uploadSubtitle2", new object[] {
                    movieHash,
                    movieByteSize,
                    subtitle,
                    format,
                    fileName,
                    fps,
                    language}, this.uploadSubtitle2OperationCompleted, userState);
        }

        private void OnuploadSubtitle2OperationCompleted(object arg)
        {
            if ((this.uploadSubtitle2Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.uploadSubtitle2Completed(this, new uploadSubtitle2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        private bool IsLocalFileSystemWebService(string url)
        {
            if (((url == null)
                        || (url == string.Empty)))
            {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024)
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0)))
            {
                return true;
            }
            return false;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "api.getsubtitle.com/nusoap")]
    public partial class Subtitle
    {

        private int cod_movieField;

        private string titleField;

        private string movie_nameField;

        private string release_nameField;

        private int yearField;

        private string hashField;

        private string languageField;

        private string flagField;

        private string formatField;

        private string totalField;

        private string fpsField;

        private int cdsField;

        private string post_dateField;

        private string linkField;

        /// <remarks/>
        public int cod_movie
        {
            get
            {
                return this.cod_movieField;
            }
            set
            {
                this.cod_movieField = value;
            }
        }

        /// <remarks/>
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string movie_name
        {
            get
            {
                return this.movie_nameField;
            }
            set
            {
                this.movie_nameField = value;
            }
        }

        /// <remarks/>
        public string release_name
        {
            get
            {
                return this.release_nameField;
            }
            set
            {
                this.release_nameField = value;
            }
        }

        /// <remarks/>
        public int year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <remarks/>
        public string hash
        {
            get
            {
                return this.hashField;
            }
            set
            {
                this.hashField = value;
            }
        }

        /// <remarks/>
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string flag
        {
            get
            {
                return this.flagField;
            }
            set
            {
                this.flagField = value;
            }
        }

        /// <remarks/>
        public string format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }

        /// <remarks/>
        public string total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <remarks/>
        public string fps
        {
            get
            {
                return this.fpsField;
            }
            set
            {
                this.fpsField = value;
            }
        }

        /// <remarks/>
        public int cds
        {
            get
            {
                return this.cdsField;
            }
            set
            {
                this.cdsField = value;
            }
        }

        /// <remarks/>
        public string post_date
        {
            get
            {
                return this.post_dateField;
            }
            set
            {
                this.post_dateField = value;
            }
        }

        /// <remarks/>
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "api.getsubtitle.com/nusoap")]
    public partial class Language
    {

        private int cod_languageField;

        private string languageField;

        private string flagField;

        private string desc_reduzidoField;

        private string charsetField;

        /// <remarks/>
        public int cod_language
        {
            get
            {
                return this.cod_languageField;
            }
            set
            {
                this.cod_languageField = value;
            }
        }

        /// <remarks/>
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string flag
        {
            get
            {
                return this.flagField;
            }
            set
            {
                this.flagField = value;
            }
        }

        /// <remarks/>
        public string desc_reduzido
        {
            get
            {
                return this.desc_reduzidoField;
            }
            set
            {
                this.desc_reduzidoField = value;
            }
        }

        /// <remarks/>
        public string charset
        {
            get
            {
                return this.charsetField;
            }
            set
            {
                this.charsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "api.getsubtitle.com/nusoap")]
    public partial class SubtitleArchive
    {

        private int cod_subtitle_fileField;

        private string dataField;

        /// <remarks/>
        public int cod_subtitle_file
        {
            get
            {
                return this.cod_subtitle_fileField;
            }
            set
            {
                this.cod_subtitle_fileField = value;
            }
        }

        /// <remarks/>
        public string data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "api.getsubtitle.com/nusoap")]
    public partial class SubtitleDownload
    {

        private string movie_hashField;

        private int cod_subtitle_fileField;

        /// <remarks/>
        public string movie_hash
        {
            get
            {
                return this.movie_hashField;
            }
            set
            {
                this.movie_hashField = value;
            }
        }

        /// <remarks/>
        public int cod_subtitle_file
        {
            get
            {
                return this.cod_subtitle_fileField;
            }
            set
            {
                this.cod_subtitle_fileField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "api.getsubtitle.com/nusoap")]
    public partial class findSubtitleFile
    {

        private string subtitle_hashField;

        private string formatField;

        private string file_nameField;

        private int upload_countField;

        private int download_countField;

        private string post_dateField;

        private string linkField;

        private int totalField;

        private string fpsField;

        private int imdbField;

        private int cod_languageField;

        /// <remarks/>
        public string subtitle_hash
        {
            get
            {
                return this.subtitle_hashField;
            }
            set
            {
                this.subtitle_hashField = value;
            }
        }

        /// <remarks/>
        public string format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }

        /// <remarks/>
        public string file_name
        {
            get
            {
                return this.file_nameField;
            }
            set
            {
                this.file_nameField = value;
            }
        }

        /// <remarks/>
        public int upload_count
        {
            get
            {
                return this.upload_countField;
            }
            set
            {
                this.upload_countField = value;
            }
        }

        /// <remarks/>
        public int download_count
        {
            get
            {
                return this.download_countField;
            }
            set
            {
                this.download_countField = value;
            }
        }

        /// <remarks/>
        public string post_date
        {
            get
            {
                return this.post_dateField;
            }
            set
            {
                this.post_dateField = value;
            }
        }

        /// <remarks/>
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <remarks/>
        public int total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <remarks/>
        public string fps
        {
            get
            {
                return this.fpsField;
            }
            set
            {
                this.fpsField = value;
            }
        }

        /// <remarks/>
        public int imdb
        {
            get
            {
                return this.imdbField;
            }
            set
            {
                this.imdbField = value;
            }
        }

        /// <remarks/>
        public int cod_language
        {
            get
            {
                return this.cod_languageField;
            }
            set
            {
                this.cod_languageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "api.getsubtitle.com/nusoap")]
    public partial class SubtitleFile
    {

        private string file_nameField;

        private string post_dateField;

        private string languageField;

        private string desc_reduzidoField;

        private string sub_hashField;

        private int cod_subtitle_fileField;

        /// <remarks/>
        public string file_name
        {
            get
            {
                return this.file_nameField;
            }
            set
            {
                this.file_nameField = value;
            }
        }

        /// <remarks/>
        public string post_date
        {
            get
            {
                return this.post_dateField;
            }
            set
            {
                this.post_dateField = value;
            }
        }

        /// <remarks/>
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string desc_reduzido
        {
            get
            {
                return this.desc_reduzidoField;
            }
            set
            {
                this.desc_reduzidoField = value;
            }
        }

        /// <remarks/>
        public string sub_hash
        {
            get
            {
                return this.sub_hashField;
            }
            set
            {
                this.sub_hashField = value;
            }
        }

        /// <remarks/>
        public int cod_subtitle_file
        {
            get
            {
                return this.cod_subtitle_fileField;
            }
            set
            {
                this.cod_subtitle_fileField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void searchSubtitlesCompletedEventHandler(object sender, searchSubtitlesCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class searchSubtitlesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal searchSubtitlesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public Subtitle[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((Subtitle[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void searchSubtitlesByHashCompletedEventHandler(object sender, searchSubtitlesByHashCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class searchSubtitlesByHashCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal searchSubtitlesByHashCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public SubtitleFile[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((SubtitleFile[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void findSubtitlesByHashCompletedEventHandler(object sender, findSubtitlesByHashCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class findSubtitlesByHashCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal findSubtitlesByHashCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public findSubtitleFile[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((findSubtitleFile[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void downloadSubtitlesCompletedEventHandler(object sender, downloadSubtitlesCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class downloadSubtitlesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal downloadSubtitlesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public SubtitleArchive[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((SubtitleArchive[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getLanguagesCompletedEventHandler(object sender, getLanguagesCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getLanguagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal getLanguagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public Language[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((Language[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void uploadSubtitleCompletedEventHandler(object sender, uploadSubtitleCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class uploadSubtitleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal uploadSubtitleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void uploadSubtitle2CompletedEventHandler(object sender, uploadSubtitle2CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class uploadSubtitle2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal uploadSubtitle2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591

