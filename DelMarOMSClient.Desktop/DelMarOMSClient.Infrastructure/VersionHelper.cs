using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DelMarOMSClient.Infrastructure
{
    public static class VersionHelper
    {

        public static string DebugSuffix
        {
            get;
            set;
        }

        static VersionHelper()
        {
            DebugSuffix = String.Empty;
        }

        public static Version Version
        {
            get
            {
                if (Assembly.GetEntryAssembly() == null) return null;
                return Assembly.GetEntryAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// Returns the versions build and revision components as a
        /// <see cref="DateTime"/>.
        /// </summary>
        /// <remarks>
        /// Note that this will only work correctly if the version was built
        /// with the automatic version number feature turned on (eg Maj.Min.*).
        /// </remarks>
        /// <param name="version">Version to get the DateTime for.</param>
        /// <returns>DateTime object for the build/revision.</returns>
        public static DateTime? GetBuildRevisionAsDateTime(Version version)
        {
            if (version == null)
            {
                return null;
            }
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);

            // If the start of the year is DLS but isn't now or vice versa then
            // we need to either add or subtract an hour.
            if (DateTime.Now.IsDaylightSavingTime() != dt.IsDaylightSavingTime())
            {
                if (DateTime.Now.IsDaylightSavingTime())
                {
                    dt = dt.AddHours(1);
                }
                else
                {
                    dt = dt.AddHours(-1);
                }
            }

            dt = dt.AddDays(version.Build);
            dt = dt.AddSeconds(version.Revision * 2);
            return dt;
        }

        /// <summary>
        /// Convenience method for assembly version.
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                if (Assembly.GetEntryAssembly() == null) return String.Empty;

                Version v = Assembly.GetEntryAssembly().GetName().Version;
                return v.ToString() + " " + DebugSuffix;
            }
        }

        /// <summary>
        /// Returns the friendly version number (x.y)
        /// </summary>
        public static string AssemblyMajorVersion
        {
            get
            {
                if (Assembly.GetEntryAssembly() == null) return String.Empty;

                Version v = Assembly.GetEntryAssembly().GetName().Version;
                return String.Format(CultureInfo.CurrentCulture,
                    "{0}.{1}", v.Major, v.Minor);
            }
        }

        /// <summary>
        /// Convenience method for assembly title.
        /// </summary>
        public static string AssemblyTitle
        {
            get
            {
                if (Assembly.GetEntryAssembly() == null) return String.Empty;

                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (!String.IsNullOrEmpty(titleAttribute.Title))
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
            }
        }

        /// <summary>
        /// Convenience method for assembly description.
        /// </summary>
        public static string AssemblyDescription
        {
            get
            {
                if (Assembly.GetEntryAssembly() == null) return String.Empty;

                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Convenience method for assembly product.
        /// </summary>
        public static string AssemblyProduct
        {
            get
            {
                if (Assembly.GetEntryAssembly() == null) return String.Empty;

                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Convenience method for assembly copyright.
        /// </summary>
        public static string AssemblyCopyright
        {
            get
            {
                if (Assembly.GetEntryAssembly() == null) return String.Empty;

                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Convenience method for assembly company.
        /// </summary>
        public static string AssemblyCompany
        {
            get
            {
                if (Assembly.GetEntryAssembly() == null) return String.Empty;

                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0) return String.Empty;
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

    }
}
