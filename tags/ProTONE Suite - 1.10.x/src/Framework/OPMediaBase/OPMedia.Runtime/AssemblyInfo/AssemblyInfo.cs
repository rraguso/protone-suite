using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using OPMedia.Core;

namespace OPMedia.Runtime.AssemblyInfo
{
    public static class AssemblyInfo
    {
        public static string GetTitle(Assembly callingAssembly)
        {
            // Get all Title attributes on this assembly
            object[] attributes = callingAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            // If there is at least one Title attribute
            if (attributes.Length > 0)
            {
                // Select the first one
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                // If it is not an empty string, return it
                if (titleAttribute.Title != "")
                    return titleAttribute.Title;
            }
            // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }

        public static string GetVersionNumber(Assembly callingAssembly)
        {
            Version v = callingAssembly.GetName().Version;
            return v.ToString((v.Revision > 0) ? 4 : 3);
        }

        public static string GetDescription(Assembly callingAssembly)
        {
            // Get all Description attributes on this assembly
            object[] attributes = callingAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            // If there aren't any Description attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Description attribute, return its value
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }

        public static string GetProductName(Assembly callingAssembly)
        {
            // Get all Product attributes on this assembly
            object[] attributes = callingAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            // If there aren't any Product attributes, return an empty string
            if (attributes.Length == 0)
                return "";
           
            // If there is a Product attribute, return its value
            return ((AssemblyProductAttribute)attributes[0]).Product;
        }

        public static string GetCopyright(Assembly callingAssembly)
        {
            // Get all Copyright attributes on this assembly
            object[] attributes = callingAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            // If there aren't any Copyright attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Copyright attribute, return its value
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }

        public static string GetCompany(Assembly callingAssembly)
        {
            // Get all Company attributes on this assembly
            object[] attributes = callingAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            // If there aren't any Company attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Company attribute, return its value
            return ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }
}
