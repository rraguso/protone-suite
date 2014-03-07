using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using OPMedia.Runtime.Addons.AddonsBase.Navigation;
using OPMedia.Runtime.Addons.AddonsBase.Prop;
using OPMedia.Runtime.Addons.AddonsBase.Preview;
using OPMedia.Core.TranslationSupport;
using OPMedia.UI.Themes;

namespace OPMedia.Runtime.Addons.AddonsBase
{
    public static class AddonDetector
    {
        static List<string> _navAddons = new List<string>();
        static List<string> _propAddons = new List<string>();
        static List<string> _previewAddons = new List<string>();

        static Dictionary<string, string> _assemblies = new Dictionary<string, string>();

        static List<string> _requiredAddons = new List<string>();

        public static string[] NavigationAddons
        {
            get
            {
                return _navAddons.ToArray();
            }
            
        }

        public static string[] PropertyAddons
        {
            get
            {
                return _propAddons.ToArray();
            }
        }

        public static string[] PreviewAddons
        {
            get
            {
                return _previewAddons.ToArray();
            }
        }

        public static string GetAssemblyInfo(string addonName)
        {
            return _assemblies[addonName];
        }

        public static bool IsRequiredAddon(string addonName)
        {
            return _requiredAddons.Contains(addonName);
        }

        static AddonDetector()
        {
            Scan();
        }

        public static void Scan()
        {
            _navAddons = new List<string>();
            _propAddons = new List<string>();
            _previewAddons = new List<string>();
            _assemblies = new Dictionary<string, string>();
            _requiredAddons = new List<string>();

            IEnumerable<string> assemblies = Directory.EnumerateFiles(Application.StartupPath, "*.dll", SearchOption.TopDirectoryOnly);
            if (assemblies != null)
            {
                foreach (string assembly in assemblies)
                {
                    try
                    {
                        TestAssembly(assembly);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static void TestAssembly(string assembly)
        {
            Assembly asm = Assembly.LoadFrom(assembly);
            AssemblyName asmName = null;

            List<Type> types = new List<Type>();

            if (asm != null)
            {
                asmName = asm.GetName();
                types.AddRange(asm.GetExportedTypes());
            }

            if (types != null)
            {
                //types.Sort(TypeSorter);

                // By means of this flag, we'll make sure we'll register
                // only assembles that DO expose valid OPMedia addons.
                bool register = false;

                foreach (Type type in types)
                {
                    register = false;

                    if (type.IsSubclassOf(typeof(NavBaseCtl)))
                    {
                        _navAddons.Add(type.FullName);
                        _assemblies.Add(type.FullName,
                            string.Format("{0}|{1}", asmName.Name, type.FullName));

                        register = true;   
                    }
                    else if (type.IsSubclassOf(typeof(PropBaseCtl)))
                    {
                        _propAddons.Add(type.FullName);
                        _assemblies.Add(type.FullName,
                            string.Format("{0}|{1}", asmName.Name, type.FullName));

                        register = true;
                    }
                    else if (type.IsSubclassOf(typeof(PreviewBaseCtl)))
                    {
                        _previewAddons.Add(type.FullName);
                        _assemblies.Add(type.FullName,
                            string.Format("{0}|{1}", asmName.Name, type.FullName));

                        register = true;
                    }

                    // If the assembly is a valid OPMedia addon then
                    // register will be True. So try to register assembly
                    // for translations then.
                    if (register)
                    {
                        try
                        {
                            Translator.RegisterTranslationAssembly(asm);
                        }
                        catch
                        {
                        }

                        try
                        {
                            PropertyInfo pi = type.GetProperty("IsRequired", BindingFlags.Public | BindingFlags.Static);
                            if (pi != null)
                            {
                                _requiredAddons.Add(type.FullName);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }

            _navAddons.Sort();
            _propAddons.Sort();
            _previewAddons.Sort();
        }
    }
}
