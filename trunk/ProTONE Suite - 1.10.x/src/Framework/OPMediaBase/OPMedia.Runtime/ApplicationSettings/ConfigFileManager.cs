#region Using directives
using System;
using System.Xml;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using OPMedia.OSDependentLayer;
#endregion

namespace OPMedia.Runtime.ApplicationSettings
{
    public class ConfigFileManager
	{
        // Fields
        protected string _filePath = string.Empty;

        private bool _isLoaded = false;
        private object _syncRoot = new object();
        private NameValueCollection _values = new NameValueCollection();
        private const string KeyName = "key";
        private const string RootNodeName = "AppSettings";
        private const string SettingNodeName = "add";
        private const string ValueName = "value";

        public ConfigFileManager(string filePath)
        {
            _filePath = filePath;
        }

        public ConfigFileManager()
        {
        }

        public void Load()
        {
            LoadFromFile(_filePath);
        }

        public void LoadFromFile(string path)
        {
            lock (_syncRoot)
            {
                XmlDocument document = new XmlDocument();
                if (File.Exists(path))
                {
                    using (FileStream stream = new FileStream(path, FileMode.Open))
                    {
                        document.Load(stream);
                    }

                    XmlNode node = document.SelectSingleNode(RootNodeName);
                    if (node != null)
                    {
                        foreach (XmlNode node2 in node.ChildNodes)
                        {
                            if (node2.Name == SettingNodeName)
                            {
                                ReadSettingNode(node2);
                            }
                        }
                    }
                }
               
                _isLoaded = true;
            }
        }

        private void AddSettingNode(XmlNode parentNode, string settingName, string settingValue)
        {
            XmlNode newChild = parentNode.OwnerDocument.CreateElement(SettingNodeName);
            parentNode.AppendChild(newChild);
            XmlAttribute node = parentNode.OwnerDocument.CreateAttribute(KeyName);
            node.Value = settingName;
            newChild.Attributes.Append(node);
            node = parentNode.OwnerDocument.CreateAttribute(ValueName);
            node.Value = settingValue;
            newChild.Attributes.Append(node);
        }



        public void Clear()
        {
            lock (_syncRoot)
            {
                _values.Clear();
            }
        }

        public string GetValue(string name)
        {
            lock (_syncRoot)
            {
                try
                {
                    RefreshIfNotLoaded();
                    return _values[name];
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool GetValue(string name, bool defaultSetting)
        {
            bool flag = defaultSetting;
            try
            {
                string str = GetValue(name);
                if (str != null)
                {
                    flag = bool.Parse(str);
                }
            }
            catch (FormatException)
            {
            }
            return flag;
        }

        public decimal GetValue(string name, decimal defaultSetting)
        {
            decimal num = defaultSetting;
            try
            {
                string s = GetValue(name);
                if (s != null)
                {
                    num = decimal.Parse(s, CultureInfo.InvariantCulture);
                }
            }
            catch (FormatException)
            {
            }
            return num;
        }

        public double GetValue(string name, double defaultSetting)
        {
            double num = defaultSetting;
            try
            {
                string s = GetValue(name);
                if (s != null)
                {
                    num = double.Parse(s, CultureInfo.InvariantCulture);
                }
            }
            catch (FormatException)
            {
            }
            return num;
        }

        public int GetValue(string name, int defaultSetting)
        {
            int num = defaultSetting;
            try
            {
                string s = GetValue(name);
                if (s != null)
                {
                    num = int.Parse(s, CultureInfo.InvariantCulture);
                }
            }
            catch (FormatException)
            {
            }
            return num;
        }

        public DateTime GetValue(string name, DateTime defaultSetting)
        {
            DateTime num = defaultSetting;
            try
            {
                string s = GetValue(name);
                if (s != null)
                {
                    num = DateTime.Parse(s, CultureInfo.InvariantCulture);
                }
            }
            catch (FormatException)
            {
            }
            return num;
        }

        public TimeSpan GetValue(string name, TimeSpan defaultSetting)
        {
            TimeSpan num = defaultSetting;
            try
            {
                string s = GetValue(name);
                if (s != null)
                {
                    num = TimeSpan.Parse(s);
                }
            }
            catch (FormatException)
            {
            }
            return num;
        }

        public string GetValue(string name, string defaultSetting)
        {
            string str = GetValue(name);
            return ((str != null) ? str : defaultSetting);
        }

        private void ReadSettingNode(XmlNode settingNode)
        {
            XmlAttribute attribute = settingNode.Attributes[KeyName];
            XmlAttribute attribute2 = settingNode.Attributes[ValueName];
            if ((attribute != null) && (attribute2 != null))
            {
                _values[attribute.Value] = attribute2.Value;
            }
        }

        private void RefreshIfNotLoaded()
        {
            if (!_isLoaded)
            {
                Load();
            }
        }

        public void Save()
        {
            SaveToFile(_filePath);
        }

        public void SaveToFile(string path)
        {
            lock (_syncRoot)
            {
                XmlDocument document = new XmlDocument();
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    document.AppendChild(document.CreateXmlDeclaration("1.0", "utf-8", ""));
                    XmlNode parentNode = document.AppendChild(document.CreateElement(RootNodeName));
                    for (int i = 0; i < _values.Count; i++)
                    {
                        string key = _values.GetKey(i);
                        string settingValue = _values[i];

                        // Don't write nulls
                        if (settingValue != null)
                        {
                            AddSettingNode(parentNode, key, settingValue);
                        }
                    }
                    document.Save(stream);
                }
            }
        }

        public void SetValue(string name, object setting)
        {
            lock (_syncRoot)
            {
                RefreshIfNotLoaded();
                _values[name] = setting.ToString();
            }
        }

        public void DeleteValue(string name)
        {
            lock (_syncRoot)
            {
                try
                {
                    if (_values[name] != null)
                    {
                        _values[name] = null;
                    }
                }
                catch
                {
                }
            }
        }
	}
}
