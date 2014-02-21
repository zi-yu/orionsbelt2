using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Threading;
using System.Resources;
using System.Globalization;
using System.Reflection;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents {
		
	/// <summary>
    /// This class agregates localized resources for a specific culture
    /// </summary>
	public class LanguageResources {
	
		#region Static Utilities

        private static bool logExceptions = true;

        /// <summary>
        ///  Indicates if the exceptions should be logged
        /// </summary>
        public static bool LogExceptions {
            get { return logExceptions; }
            set { logExceptions = value; }
        }

        #endregion Static Utilities
		
        #region Public Members

        /// <summary>
        /// Get's this LanguageResources name
        /// </summary>
        public string LanguageName {
            get { return language; }
        }

        /// <summary>
        /// Gets the culture associated with this LanguageResources
        /// </summary>
		public CultureInfo Culture {
            get { return culture; }
            set { culture = value; }
        }
		
        /// <summary>
        /// Get's a localized string via a specified key
        /// </summary>
        /// <param name="key">The key to search</param>
        /// <returns>The localized resource</returns>
		public string Get( string key )
        {
            try {
                return resources[key];
            } catch( Exception ex ) {
                if (LogExceptions) {
                    ExceptionLogger.Log(new Exception("Error Getting localization for '" + key + "'", ex));
                }
                return string.Format("@({0})", key);
            }
        }
        
        /// <summary>
        /// Verifies if the given key is present on this language
        /// </summary>
        /// <param name="key">The key to query</param>
        /// <returns>True if it exists</returns>
        public bool HasKey(string key)
        {
            return resources.ContainsKey(key);
        }

        /// <summary>
        /// Registers a new key/resource pair for this Culture
        /// </summary>
        /// <param name="key">The resource's Key</param>
        /// <param name="resource">The Localized resource</param>
        public virtual void Register( string key, string resource )
        {
            resources[key] = resource;
        }

        #endregion Public Members

        #region Instance Fields

        private DateTime date = DateTime.Now;
        private string language = null;
        private CultureInfo culture = null;
        private Dictionary<string,string> resources = new Dictionary<string,string>();
		
		#endregion Instance Fields

        #region Ctor & Utils

        /// <summary>
        /// LanguageResources Contructor
        /// </summary>
        /// <param name="lang">Associated language</param>
        public LanguageResources(string lang)
        {
            language = lang;
            try {
                culture = CultureInfo.GetCultureInfo(lang);
            } catch (Exception ex) {
                ExceptionLogger.Log(ex);
                culture = CultureInfo.InvariantCulture;
            }
        }

        /// <summary>
        /// Get's this Object's Description
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format("{{Culture:{0} Count:{1} Created:{2}}}", LanguageName, resources.Count, date);
        }

        #endregion Ctor & Utils

    };
}
