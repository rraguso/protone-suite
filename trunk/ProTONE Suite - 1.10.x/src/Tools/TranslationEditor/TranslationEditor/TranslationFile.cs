using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace TranslationEditor
{
    public class TranslationItem
    {
        public override string ToString()
        {

            return string.Format("{0} in '{3}': {1} -> {2}", StringName, BaseString, TranslatedString, Path);
        }

        public string StringName { get; set; }
        public string BaseString { get; set; }
        public string TranslatedString { get; set; }

        public string Path { get; private set; }

        public TranslationItem(string path)
        {
            this.Path = path;
        }
    }

    public class TranslationItemDictionary : Dictionary<string, TranslationItem>
    {
        public event EventHandler DictionaryChanged;

        public new void Add(string key, TranslationItem translationItem)
        {
            base.Add(key, translationItem);
            if (DictionaryChanged != null)
            {
                DictionaryChanged(this, EventArgs.Empty);
            }
        }

        public new void Remove(string key)
        {
            if (base.Remove(key))
            {
                if (DictionaryChanged != null)
                {
                    DictionaryChanged(this, EventArgs.Empty);
                }
            }
        }
    }

    public class TranslationFile
    {
        public static readonly string[] SupportedLanguages = new string[]
        {
            "ro", "de", "fr"
        };

        public const string TranslationFileEnglishName = "translation.resx";
        public const string TranslationFilePattern = "translation.{0}.resx";

        public TranslationItemDictionary Items { get; private set; }

        public bool IsModified { get; private set; }

        public string Path { get { return _path; } }
        public string AltPath { get { return _altPath; } }

        string _path = string.Empty;
        string _altPath = string.Empty;

        public void Save()
        {
            if (Items != null && Items.Count > 0 && IsModified)
            {
                ForceSave();
            }
        }

        public void ForceSave()
        {
            try
            {
                SaveBaseItems();
                SaveTranslatedItems();
            }
            finally
            {
                IsModified = false;
            }
        }

        public TranslationFile(string path, string languageName)
        {
            _path = path;
            _altPath = path.ToLowerInvariant().Replace(TranslationFileEnglishName,
                string.Format(TranslationFilePattern, languageName.ToLowerInvariant()));

            Items = new TranslationItemDictionary();
            Items.DictionaryChanged += new EventHandler(Items_DictionaryChanged);

            try
            {
                if (BuildBaseItems())
                {
                    UpdateTranslatedItems();
                }
            }
            finally
            {
                IsModified = false;
            }
        }

        void Items_DictionaryChanged(object sender, EventArgs e)
        {
            IsModified = true;
        }

        private bool BuildBaseItems()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_path);

                XmlNodeList nodes = doc.GetElementsByTagName("data");
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (XmlNode node in nodes)
                    {
                        TranslationItem ti = new TranslationItem(_path);
                        ti.StringName = node.Attributes["name"].Value;
                        ti.BaseString = GetValueFromNode(node);

                        if (Items.ContainsKey(ti.StringName))
                        {
                            Items[ti.StringName].BaseString = ti.BaseString;
                        }
                        else
                        {
                            Items.Add(ti.StringName, ti);
                        }
                    }

                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("BuildBaseItems failed: " + ex.Message);
            }

            return false;
        }

        private void UpdateTranslatedItems()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_altPath);

                XmlNodeList nodes = doc.GetElementsByTagName("data");
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (XmlNode node in nodes)
                    {
                        string name = node.Attributes["name"].Value;
                        if (Items.ContainsKey(name))
                        {
                            Items[name].TranslatedString = GetValueFromNode(node);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateTranslatedItems failed: " + ex.Message);
            }
        }

        private string GetValueFromNode(XmlNode node)
        {
            try
            {
                if (node != null)
                {
                    if (node.HasChildNodes)
                    {
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            if (childNode.Name == "value")
                            {
                                return childNode.InnerText;
                            }
                        }
                    }

                    return node.InnerText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetValueFromInnerXml failed: " + ex.Message);
            }

            return string.Empty;
        }

        private void SaveBaseItems()
        {
            XmlWriter xw = null;

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.NewLineHandling = NewLineHandling.Entitize;
                settings.OmitXmlDeclaration = true;
                settings.NewLineChars = "\r\n";
                settings.Indent = true;
                settings.IndentChars = "  ";
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.CloseOutput = true;

                StringBuilder sb = new StringBuilder();
                xw = XmlWriter.Create(sb, settings);
                {
                    foreach (TranslationItem ti in Items.Values)
                    {
                        xw.WriteStartElement("data");
                        xw.WriteAttributeString("name", ti.StringName);
                        xw.WriteStartElement("value");
                        xw.WriteValue(ti.BaseString);
                        xw.WriteEndElement();
                        xw.WriteEndElement();
                    }
                }

                xw.Flush();

                string header = File.ReadAllText("XMLPreamble.xml");
                string text = header.Replace("<!-- INSERT GENERATED CONTENT HERE -->", sb.ToString());

                File.WriteAllText(_path, text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveBaseItems failed: " + ex.Message);
            }
            finally
            {
                if (xw != null)
                {
                    xw.Close();
                }

            }
        }

        private void SaveTranslatedItems()
        {
            XmlWriter xw = null;

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.NewLineHandling = NewLineHandling.Entitize;
                settings.OmitXmlDeclaration = true;
                settings.NewLineChars = "\r\n";
                settings.Indent = true;
                settings.IndentChars = "  ";
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.CloseOutput = true;

                StringBuilder sb = new StringBuilder();
                xw = XmlWriter.Create(sb, settings);
                {
                    foreach (TranslationItem ti in Items.Values)
                    {
                        xw.WriteStartElement("data");
                        xw.WriteAttributeString("name", ti.StringName);
                        xw.WriteStartElement("value");
                        xw.WriteValue(ti.TranslatedString);
                        xw.WriteEndElement();
                        xw.WriteEndElement();
                    }
                }

                xw.Flush();

                string header = File.ReadAllText("XMLPreamble.xml");
                string text = header.Replace("<!-- INSERT GENERATED CONTENT HERE -->", sb.ToString());

                File.WriteAllText(_altPath, text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveTranslatedItems failed: " + ex.Message);
            }
            finally
            {
                if (xw != null)
                {
                    xw.Close();
                }

            }
        }

    }
}
