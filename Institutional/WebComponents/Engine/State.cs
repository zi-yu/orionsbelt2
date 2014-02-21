
#define USER_MEMORY_IN_SESSION
#define CACHE_USER_LOGIN

using System;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using System.Web.Caching;
using System.Security.Principal;
using System.IO;

namespace Institutional.WebComponents {

    /// <summary>
    /// Provides access to the ASP.NET state containers
    /// </summary>
    public static class State {

        #region Properties

        /// <summary>
        /// Session state
        /// </summary>
        public static HttpSessionState Session {
            get { return HttpContext.Current.Session; }
        }

        /// <summary>
        /// Items state
        /// </summary>
        public static IDictionary Items {
            get { return HttpContext.Current.Items; }
        }

        /// <summary>
        /// Application state
        /// </summary>
        public static HttpApplicationState Application {
            get { return HttpContext.Current.Application; }
        }

        /// <summary>
        /// Cache state
        /// </summary>
        public static Cache Cache {
            get { return HttpContext.Current.Cache; }
        }

        #endregion Properties

        #region FileCache

        private static string fileCacheDir;
        private static string FileCacheDir {
            get {
                if (string.IsNullOrEmpty(fileCacheDir)) {
                    string dir = Path.Combine(LanguageManager.LanguageDirectory, "..");
                    fileCacheDir = Path.Combine(dir, "Cache");
                    Directory.CreateDirectory(fileCacheDir);
                }
                return fileCacheDir;
            }
        }

        /// <summary>
        /// Returns if there is a state Cache object for the given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>True if exists</returns>
        public static bool HasFileCache(string key)
        {
            string contentFile = GetFileCacheContentFile(key);
            string deadlineCache = GetFileCacheDeadlineFile(key);

            return File.Exists(contentFile) && NotOnDeadline(deadlineCache);
        }

        /// <summary>
        /// Checks id the given file is on the deadline
        /// </summary>
        /// <param name="deadlineCache">The deadline file</param>
        /// <returns>True is is wtill ok</returns>
        private static bool NotOnDeadline(string deadlineCache)
        {
            if (!File.Exists(deadlineCache)) {
                return false;
            }

            return File.GetLastWriteTime(deadlineCache) > DateTime.Now;
        }

        /// <summary>
        /// Gets the deadline file name
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The path</returns>
        private static string GetFileCacheDeadlineFile(string key)
        {
            return Path.Combine(FileCacheDir, string.Format("{0}_deadline", key));
        }

        /// <summary>
        /// Gets the content file name
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The file path</returns>
        private static string GetFileCacheContentFile(string key)
        {
            return Path.Combine(FileCacheDir, key);
        }

        /// <summary>
        /// Sets the Cache with a state object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="state">The state</param>
        /// <param name="deadline">The deadline</param>
        public static void SetFileCache(string key, string state, TimeSpan deadline)
        {
            string contentFile = GetFileCacheContentFile(key);
            string deadlineCache = GetFileCacheDeadlineFile(key);

            DateTime deadlineDate = DateTime.Now.Add(deadline);

            File.WriteAllText(contentFile, state);
            File.WriteAllText(deadlineCache, deadlineDate.ToString());

            File.SetLastWriteTime(deadlineCache, deadlineDate);
        }

        /// <summary>
        /// Sets the Cache with a state object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="state">The state</param>
        public static void SetFileCache(string key, string state)
        {
            SetFileCache(key, state, TimeSpan.FromDays(7));
        }

        /// <summary>
        /// Removes an entry from the file cache
        /// </summary>
        /// <param name="key">The key</param>
        public static void RemoveFileCache(string key)
        {
            string contentFile = GetFileCacheContentFile(key);
            if (File.Exists(contentFile)) {
                File.Delete(contentFile);
            }

            string deadlineCache = GetFileCacheDeadlineFile(key);
            if (File.Exists(deadlineCache)) {
                File.Delete(deadlineCache);
            }
        }

        /// <summary>
        /// Gets the Cache object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The object</returns>
        public static string GetFileCache(string key)
        {
            return File.ReadAllText(GetFileCacheContentFile(key));
        }

        #endregion FileCache

        #region Application Utilities

        /// <summary>
        /// Returns if there is a state Application object for the given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>True if exists</returns>
        public static bool HasApplication (string key)
        {
            return Application[key] != null;
        }

        /// <summary>
        /// Returns if there is a state Application object for the given entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>True if exists</returns>
        public static bool HasApplication<T>()
        {
            return HasApplication (typeof(T).Name);
        }

        /// <summary>
        /// Sets the Application with a state object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="state">The state</param>
        public static void SetApplication(string key, object state)
        {
            Application[key] = state;
        }

        /// <summary>
        /// Sets the Application with a state object for a given entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        public static void SetApplication<T>(T entity)
        {
            SetApplication ( typeof(T).Name, entity );
        }

        /// <summary>
        /// Gets the Application object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The object</returns>
        public static object GetApplication(string key)
        {
            object obj = Application[key];
            if (obj == null) {
                throw new UIException("No state in Application for key '{0}'", key);
            }
            return obj;
        }

        /// <summary>
        /// Gets the Application entity for a given key
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>The entity</returns>
        public static T GetApplication<T>()
        {
            return (T) GetApplication ( typeof(T).Name );
        }

        /// <summary>
        /// Gets an int object form Application
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The integer</returns>
        public static int GetApplicationInt(string key)
        {
            return (int) GetApplication(key);
        }

        /// <summary>
        /// Gets a string object form Application
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The integer</returns>
        public static string GetApplicationString(string key)
        {
            return (string) GetApplication(key);
        }

        #endregion Session Utilities

        #region Cache Utilities

        /// <summary>
        /// Returns if there is a state Cache object for the given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>True if exists</returns>
        public static bool HasCache (string key)
        {
            return Cache[key] != null;
        }

        /// <summary>
        /// Returns if there is a state Cache object for the given entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>True if exists</returns>
        public static bool HasCache<T>()
        {
            return HasCache (typeof(T).Name);
        }

        /// <summary>
        /// Sets the Cache with a state object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="state">The state</param>
        public static void SetCache(string key, object state)
        {
            Cache[key] = state;
        }

        /// <summary>
        /// Sets the Cache with a state object for a given entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        public static void SetCache<T>(T entity)
        {
            SetCache ( typeof(T).Name, entity );
        }

        /// <summary>
        /// Gets the Cache object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The object</returns>
        public static object GetCache(string key)
        {
            object obj = Cache[key];
            if (obj == null) {
                throw new UIException("No state in Cache for key '{0}'", key);
            }
            return obj;
        }

        /// <summary>
        /// Gets the Cache entity for a given key
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>The entity</returns>
        public static T GetCache<T>()
        {
            return (T) GetCache ( typeof(T).Name );
        }

        /// <summary>
        /// Gets an int object form Cache
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The integer</returns>
        public static int GetCacheInt(string key)
        {
            return (int) GetCache(key);
        }

        /// <summary>
        /// Gets a string object form Cache
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The integer</returns>
        public static string GetCacheString(string key)
        {
            return (string) GetCache(key);
        }

        #endregion Session Utilities

        #region Items Utilities

        /// <summary>
        /// Returns if there is a state Items object for the given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>True if exists</returns>
        public static bool HasItems (string key)
        {
            return Items[key] != null;
        }

        /// <summary>
        /// Returns if there is a state Items object for the given entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>True if exists</returns>
        public static bool HasItems<T>()
        {
            return HasItems (typeof(T).Name);
        }

        /// <summary>
        /// Sets the Items with a state object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="state">The state</param>
        public static void SetItems(string key, object state)
        {
            Items[key] = state;
        }

        /// <summary>
        /// Sets the Items with a state object for a given entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        public static void SetItems<T>(T entity)
        {
            SetItems ( typeof(T).Name, entity );
        }

        /// <summary>
        /// Gets the Items object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The object</returns>
        public static object GetItems(string key)
        {
            object obj = Items[key];
            if (obj == null) {
                throw new UIException("No state in Items for key '{0}'", key);
            }
            return obj;
        }

        /// <summary>
        /// Gets the Items entity for a given key
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>The entity</returns>
        public static T GetItems<T>()
        {
            return (T) GetItems ( typeof(T).Name );
        }

        /// <summary>
        /// Gets an int object form Items
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The integer</returns>
        public static int GetItemsInt(string key)
        {
            return (int) GetItems(key);
        }

        /// <summary>
        /// Gets a string object form Items
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The integer</returns>
        public static string GetItemsString(string key)
        {
            return (string) GetItems(key);
        }

        #endregion Session Utilities

        #region Session Utilities

        /// <summary>
        /// Returns if there is a state Session object for the given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>True if exists</returns>
        public static bool HasSession (string key)
        {
            return Session[key] != null;
        }

        /// <summary>
        /// Returns if there is a state Session object for the given entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>True if exists</returns>
        public static bool HasSession<T>()
        {
            return HasSession (typeof(T).Name);
        }

        /// <summary>
        /// Sets the Session with a state object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="state">The state</param>
        public static void SetSession(string key, object state)
        {
            Session[key] = state;
        }

        /// <summary>
        /// Sets the Session with a state object for a given entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        public static void SetSession<T>(T entity)
        {
            SetSession ( typeof(T).Name, entity );
        }

        /// <summary>
        /// Gets the Session object for a given key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The object</returns>
        public static object GetSession(string key)
        {
            object obj = Session[key];
            if (obj == null) {
                throw new UIException("No state in Session for key '{0}'", key);
            }
            return obj;
        }

        /// <summary>
        /// Gets the Session entity for a given key
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>The entity</returns>
        public static T GetSession<T>()
        {
            return (T) GetSession ( typeof(T).Name );
        }

        /// <summary>
        /// Gets an int object form Session
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The integer</returns>
        public static int GetSessionInt(string key)
        {
            return (int) GetSession(key);
        }

        /// <summary>
        /// Gets a string object form Session
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The integer</returns>
        public static string GetSessionString(string key)
        {
            return (string) GetSession(key);
        }

        #endregion Session Utilities

        #region User Memory

        /// <summary>
        /// Checks if a given key exists in user memory
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>True if exists</returns>
        public static bool InMemory(string key)
        {
#if USER_MEMORY_IN_SESSION
            return State.HasSession(key);
#else
            return State.HasItems(key);
#endif
        }

        /// <summary>
        /// Sets user memory with data
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="obj">The object</param>
        public static void SetMemory(string key, object obj)
        {
#if USER_MEMORY_IN_SESSION
            State.SetSession(key, obj);
#else
            State.SetItems(key, obj);
#endif
        }

        /// <summary>
        /// Gets data from user memory
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The object</returns>
        public static object GetFromMemory(string key)
        {
#if USER_MEMORY_IN_SESSION
            return State.GetSession(key);
#else
            return State.GetItems(key);
#endif
        }

        /// <summary>
        /// Checks if the uers is in memory
        /// </summary>
        /// <param name="name">The username</param>
        /// <returns>True if it is</returns>
        public static bool HasUserInMemory(string name)
        {
#if CACHE_USER_LOGIN
            return HasCache(name);
#else
            return false;
#endif
        }

        /// <summary>
        /// Saves the user in memoru
        /// </summary>
        /// <param name="name">The username</param>
        /// <param name="principal">The user</param>
        public static void SetUserInMemory(string name, IPrincipal principal)
        {
#if CACHE_USER_LOGIN
            Cache.Add(name, principal, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), CacheItemPriority.Normal, null);
#endif
        }

        /// <summary>
        /// Gets the user from memory
        /// </summary>
        /// <param name="name">The username</param>
        /// <returns>The user</returns>
        public static IPrincipal GetUserFromMemory(string name)
        {
#if CACHE_USER_LOGIN
            return (IPrincipal)GetCache(name);
#else
            throw new Exception("User in memory not supported");
#endif
        }

        #endregion User Memory

    };

}