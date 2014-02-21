
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Xml.XPath;
using System.Threading;
using System.Resources;
using System.Globalization;
using System.Reflection;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents {

   /// <summary>
    /// This class handles all the localization needs
    /// </summary>
	public class LanguageManager : ILanguageHandler {

        #region Static Members

        private static string[] supported = new string[] {   "en"    , "pt"    , "es"    , "hr"    , "fr"    , "de"   };
                
        private static object sync = new object();
        private static string defaultLanguage = "en";
        private static ILanguageHandler manager = new LanguageManager();
        private static Dictionary<string, object> staticCache = new Dictionary<string, object>();
        private static string languageDirectory = null;
        private static bool initialized = false;
        private static bool initializing = false;

        /// <summary>
        /// Indicates that the language resources are ready
        /// </summary>
        public static bool IsInitialized {
            get {
                foreach (string lang in supported) {
                    LanguageResources res = GetCache(lang);
                    if (res == null) {
                        initialized = false;
                        initializing = false;
                    }
                }
                return initialized; 
            }
            private set { initialized = value; }
        }

        /// <summary>
        /// True if the manager is initializing
        /// </summary>
        public static bool IsInitializing {
            get { return initializing; }
            private set { initializing = value; }
        }

        /// <summary>
        /// Gets the current supported languages
        /// </summary>
        public static string[] SupportedLanguages {
            get { return supported; }
        }

        /// <summary>
        /// Gets this object sync access
        /// </summary>
        public static object Sync {
            get { return sync; }
        }

        /// <summary>
        /// Gets the language used when the response language is not available
        /// </summary>
        public static string DefaultLanguage {
            get { return defaultLanguage; }
            set { defaultLanguage = value; }
        }
        
        /// <summary>
        /// Get's the current language to use
        /// </summary>
        public static string CurrentLanguage {
			get {
                string sessionLanguage = GetSessionLanguage();
                if (sessionLanguage != null)  {
                    return sessionLanguage;
                }
                return CurrentCulture.Name; 
            }
        }
		
		/// <summary>
        /// Gets the current request language
        /// </summary>
        /// <remarks>
        /// If there is no current language, DefaultLanguage will be returned
        /// </remarks>
        public static string RequestLanguage {
            get {
                if (HttpContext.Current.Request.UserLanguages == null ||
                    HttpContext.Current.Request.UserLanguages.Length == 0) {
                        return DefaultLanguage;
                }
                return HttpContext.Current.Request.UserLanguages[0];
            }
        }

        /// <summary>
        /// Singleton Access for LanguageManager
        /// </summary>
        public static ILanguageHandler Instance {
            get { return manager; }
            set { manager = value; }
        }
        
        /// <summary>
        /// True if the current language can be stored in session via Query String
        /// </summary>
        public static bool SessionLanguageEnabled {
            get { return sessionLanguageEnabled; }
            set { sessionLanguageEnabled = value; }
        }
        private static bool sessionLanguageEnabled = false;

        /// <summary>
        /// Set's up the LanguageManager
        /// </summary>
        static LanguageManager()
        {
        }
        
        /// <summary>
        /// Gets the current session language
        /// </summary>
        /// <returns>The language, or null</returns>
        public static string GetSessionLanguage()
        {
			if (!SessionLanguageEnabled) {
                return null;
            }
            const string CurrentLanguageKey = "CurrentLanguage";
            if (HttpContext.Current == null || HttpContext.Current.Session == null)  {
                return null;
            }
            string fromRequest = HttpContext.Current.Request.QueryString["Language"];
            if (fromRequest != null && ValidateCulture(fromRequest)) {
                State.SetSession(CurrentLanguageKey, fromRequest);
                return fromRequest;
            }

            if (State.HasSession(CurrentLanguageKey))   {
                return (string) State.GetSession(CurrentLanguageKey);
            }

            return null;
        }

        /// <summary>
        /// Validates a culture
        /// </summary>
        /// <param name="fromRequest">Culture name</param>
        /// <returns>True if the culture exists</returns>
        private static bool ValidateCulture(string culture)
        {
            try {
                CultureInfo info = CultureInfo.GetCultureInfo(culture);
                return info != null;
            } catch {
                return false;
            }
        }

        #endregion Static Members

        #region Constructor

        /// <summary>
        /// The ctor is private, this class is only accesible via LanguageManager.Instance
        /// </summary>
        private LanguageManager()
        {
        }

        #endregion Constructor

        #region Public Members

        /// <summary>
        /// Gets the current response culture
        /// </summary>
        public static CultureInfo CurrentCulture {
            get { return Thread.CurrentThread.CurrentUICulture; }
            set { Thread.CurrentThread.CurrentUICulture = value; }
        }

        /// <summary>
        /// Gets a localized resource for the current language
        /// </summary>
        /// <param name="key">The identifier</param>
        /// <returns>The Localized string</returns>
        public string Get(string key)
        {
            string language = Resolve(CurrentCulture.Name);
            if (GetLanguageResources(language).HasKey(key)) {
                return Get(language, key);
            }
            return Get(DefaultLanguage, key);
        }
        
        /// <summary>
        /// Gets a localized resource for the current language
        /// </summary>
        /// <param name="key">The identifier</param>
        /// <returns>The Localized string</returns>
        public static string Localize(string key)
        {
            return Instance.Get(key);
        }

        /// <summary>
        /// Gets a localized resource for a specified language
        /// </summary>
        /// <param name="language">The language</param>
        /// <param name="key">The identifier</param>
        /// <returns>The localized string</returns>
        public string Get(string language, string key)
        {
			return GetLanguageResources(language).Get(key);
        }

        /// <summary>
        /// Given a language string, returns a supported language
        /// </summary>
        /// <param name="language">The wanted language</param>
        /// <returns>The supported language</returns>
        private static string Resolve( string language )
        {
            if (RegisteredKey(language)) {
                return language;
            }

            if (language.Contains("_")) {
                string stronger = language.Split('_')[0];
                if (RegisteredKey(stronger)) {
                    return stronger;
                }
            }

            if (!RegisteredKey(DefaultLanguage)) {
                BuildLanguageResources();
            }

            return DefaultLanguage;
        }

        /// <summary>
        /// Indicates if the requested language is available
        /// </summary>
        /// <param name="language">The wanted language</param>
        /// <returns>True if it's available</returns>
        private static bool RegisteredKey(string language)
        {
            if (HttpContext.Current != null){
                return HttpContext.Current.Application[GetCacheKey(language)] != null;
            }

            return staticCache.ContainsKey(language);
        }

        /// <summary>
        /// Gets the LanguageResources for a specified Language
        /// </summary>
        /// <param name="language">The language</param>
        /// <returns>The LanguageResources</returns>
        public LanguageResources GetLanguageResources(string language)
        {
            LanguageResources fromCache = GetCache(language);
            if (fromCache != null) {
                return fromCache;
            } else {

                BuildLanguageResources();
                fromCache = GetCache(language);
                if (fromCache == null) {
                    throw new UIException("No language resources for language `{0}'", language);
                }
            }

            return fromCache;
        }

        /// <summary>
        /// Gets a LanguageResources from Cache
        /// </summary>
        /// <param name="language">The language</param>
        /// <returns>The LanguageResources</returns>
        private static LanguageResources GetCache(string language)
        {
            if (HttpContext.Current != null) {
                return (LanguageResources)HttpContext.Current.Application[GetCacheKey(language)];
            }
            if (staticCache.ContainsKey(language)) {
                return (LanguageResources)staticCache[language];
            }
            return null;
        }

        /// <summary>
        /// Set's a LanguageResources to Cache
        /// </summary>
        /// <param name="language">The Language</param>
        /// <param name="resources">The LanguageResources</param>
        private static void SetCache( string language, LanguageResources resources )
        {
            if (HttpContext.Current != null) {
                HttpContext.Current.Application[GetCacheKey(language)] = resources;
                return;
            }
            staticCache[language] = resources;
        }

        /// <summary>
        /// Gets a Cache Key string based on the language
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>The Cache Key</returns>
        private static string GetCacheKey(string language)
        {
            return string.Format("I18N:{0}", language);
        }

        /// <summary>
        /// Gets the LanguageResource for a specified language
        /// </summary>
        /// <remarks>
        /// If the LanguageResources does not exist, it will be created
        /// </remarks>
        /// <param name="language">The language</param>
        /// <returns>The LanguageResources</returns>
        private static LanguageResources GetOrCreateLanguageResources(string language)
        {
            LanguageResources fromCache = GetCache(language);
            if (fromCache == null) {
                return new LanguageResources(language);
            }
            return fromCache;
        }

        /// <summary>
        /// Builds the Resources's objects from the XML file
        /// </summary>
        private static void BuildLanguageResources()
        {
            lock (Sync) {
                while (!IsInitialized && IsInitializing) {
                    Thread.Sleep(500);
                }
                if (IsInitialized) {
                    return;
                }

                IsInitializing = true;
            }

            foreach (string file in GetResourcesFiles()) {
                LoadLanguageFile(file);
            }

            IsInitialized = true;
        }

        /// <summary>
        /// Enumerates all language XML files found
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> GetResourcesFiles()
        {
            foreach( string file in Directory.GetFiles(LanguageDirectory, "*.xml") ) {
                yield return file;
            }

            foreach (string dir in Directory.GetDirectories(LanguageDirectory)) {
                foreach (string file in Directory.GetFiles(dir, "*.xml")) {
                    yield return file;
                }
            }
        }

        /// <summary>
        /// Loads a XML resources file to memory
        /// </summary>
        /// <param name="file"></param>
        private static void LoadLanguageFile(string file)
        {
            string content = File.ReadAllText(file);
            XPathNodeIterator iter = GetNodeIterator(content, "/resources/entry");
            while (iter.MoveNext()) {
                string entry = GetXpathValue(iter.Current.OuterXml, "/entry/@key");
                XPathNodeIterator lang = GetNodeIterator(iter.Current.OuterXml, "/entry/lang");
                while (lang.MoveNext()) {
                    StoreLanguageInfo(entry, lang.Current.OuterXml);
                }
            }
        }

        /// <summary>
        /// Stores the Language Data for a specific entry in a LanguageResources
        /// </summary>
        /// <param name="entry">Entry Name</param>
        /// <param name="xml">Entry XML</param>
        private static void StoreLanguageInfo(string entry, string xml)
        {
            string lang = GetXpathValue(xml, "/lang/@key");
            string localized = GetXpathContent(xml, "/lang");

            LanguageResources resources = GetOrCreateLanguageResources(lang);
            resources.Register(entry, localized);

            SetCache(lang, resources);
        }

        /// <summary>
        /// Gets the Language Directory
        /// </summary>
        public static string LanguageDirectory {
            get {
                if (languageDirectory == null) {
                    // WebUserInterface/bin/
                    string dir = AppDomain.CurrentDomain.BaseDirectory;

                    // WebUserInterface/Localization
                    languageDirectory = Path.Combine(dir, "Localization");
                }

                return languageDirectory;
            }
            set {
                languageDirectory = value;
            }
        }

        #endregion Public Members

        #region XPath Utilities

        /// <summary>
        /// Gets a XPathNodeIterator for a spcific XML/xpath expression
        /// </summary>
        /// <param name="content">XML content</param>
        /// <param name="xpath">XPath expression</param>
        /// <returns>The XPathNodeIterator</returns>
        private static XPathNodeIterator GetNodeIterator(string content, string xpath)
        {
            XPathDocument doc = new XPathDocument(new StringReader(content));
            XPathNavigator nav = doc.CreateNavigator();
            return nav.Select(xpath);
        }

        /// <summary>
        /// Gets a Node Value
        /// </summary>
        /// <param name="xml">The XML content</param>
        /// <param name="xpath">The XPath Exression</param>
        /// <returns>The value</returns>
        private static string GetXpathValue(string xml, string xpath)
        {
            XPathNodeIterator iter = GetNodeIterator(xml, xpath);
            iter.MoveNext();
            return iter.Current.Value;
        }

        /// <summary>
        /// Gets a Node Content
        /// </summary>
        /// <param name="xml">The XML content</param>
        /// <param name="xpath">The XPath Exression</param>
        /// <returns>The Inner XML</returns>
        private static string GetXpathContent(string xml, string xpath)
        {
            XPathNodeIterator iter = GetNodeIterator(xml, xpath);
            iter.MoveNext();
            return iter.Current.InnerXml;
        }

        #endregion XPath Utilities

    };
}
