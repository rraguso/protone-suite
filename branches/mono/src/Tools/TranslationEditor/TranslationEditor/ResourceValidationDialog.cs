using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TranslationEditor
{
    public partial class ResourceValidationDialog : Form
    {
        public Dictionary<string, Dictionary<string, TranslationItem>> _resources =
            new Dictionary<string, Dictionary<string, TranslationItem>>();

        string[] _scanAssemblies = null;

        public ResourceValidationDialog(string[] assemblies)
        {
            InitializeComponent();

            _resources.Add("en", new Dictionary<string, TranslationItem>());

            foreach (string lang in TranslationFile.SupportedLanguages)
            {
                _resources.Add(lang, new Dictionary<string, TranslationItem>());
            }

            _scanAssemblies = assemblies;

            this.Load += new EventHandler(ResourceValidationDialog_Load);
        }

        void ResourceValidationDialog_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<TranslationItem[]>> duplicateTranslations =
                new Dictionary<string, List<TranslationItem[]>>();

            foreach (string file in _scanAssemblies)
            {
                if (!duplicateTranslations.ContainsKey("en"))
                {
                    duplicateTranslations["en"] = new List<TranslationItem[]>();
                }

                TranslationFile tf = new TranslationFile(file, "ro");

                foreach (TranslationItem ti in tf.Items.Values)
                {
                    try
                    {
                        TranslationItem conflict = null;
                        if (CheckConflictingResource("en", ti, ref conflict))
                        {
                            List<TranslationItem[]> lst = duplicateTranslations["en"];
                            TranslationItem[] pair = new TranslationItem[2] { ti, conflict };

                            lst.Add(pair);
                        }
                    }
                    catch
                    {
                    }
                }


                foreach (string lang in TranslationFile.SupportedLanguages)
                {
                    if (!duplicateTranslations.ContainsKey(lang))
                    {
                        duplicateTranslations[lang] = new List<TranslationItem[]>();
                    }
                    
                    tf = new TranslationFile(file, lang);

                    foreach (TranslationItem ti in tf.Items.Values)
                    {
                        try
                        {
                            TranslationItem conflict = null;
                            if (CheckConflictingResource(lang, ti, ref conflict))
                            {
                                List<TranslationItem[]> lst = duplicateTranslations[lang];
                                TranslationItem[] pair = new TranslationItem[2] { ti, conflict };

                                lst.Add(pair);
                            }
                        }
                        catch 
                        {
                        }
                    }
                }
            }

            tvResults.Nodes.Clear();

            foreach (KeyValuePair<string, List<TranslationItem[]>> kvp in duplicateTranslations)
            {
                TreeNode langNode = tvResults.Nodes.Add(string.Format("{0} - {1} conflict(s) found", kvp.Key, kvp.Value.Count));

                List<TranslationItem[]> lst = null;

                try
                {
                    lst = kvp.Value.ToList();
                    lst.Sort(CompareSort);
                }
                catch
                {
                }

                foreach (TranslationItem[] cds in lst)
                {
                    TreeNode conflictNode = langNode.Nodes.Add(cds[0].StringName);

                    conflictNode.Nodes.Add(cds[0].ToString());
                    conflictNode.Nodes.Add(cds[1].ToString());
                }
            }

            //tvResults.ExpandAll();
        }

        private static int CompareSort(TranslationItem[] x, TranslationItem[] y)
        {
            return string.Compare(x[0].StringName, y[0].StringName);
        }

        public bool CheckConflictingResource(string language, TranslationItem ti, ref TranslationItem conflict)
        {
            Dictionary<string, TranslationItem> langResources = _resources[language];
            string cmp = (language == "en") ? ti.BaseString : ti.TranslatedString;

            foreach (KeyValuePair<string, TranslationItem> kvp in langResources)
            {
                string s1 = kvp.Key.Trim().ToLowerInvariant();
                string s2 = cmp.Trim().ToLowerInvariant();

                if ((s1 == s2) || (s1 == s2 + ":") || (s1 + ":" == s2))
                {
                    conflict = kvp.Value;
                    return true;
                }
            }

            langResources.Add(cmp, ti);

            return false;
        }
    }
    /*
    public class ConflictDetail
    {
        public string Origin { get; private set; }
        public TranslationItem Item { get; private set; }

        public override string ToString()
        {
            return string.Format("'{0}' in '{1}'", Item, Origin);
        }

        public ConflictDetail(string origin, TranslationItem item)
        {
            this.Origin = origin;
            this.Item = item;
        }
    }*/
}
