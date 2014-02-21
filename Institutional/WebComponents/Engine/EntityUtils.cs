
using System;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using System.Web.Caching;
using System.Security.Principal;
using Loki.DataRepresentation;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents {

    /// <summary>
    /// Generic entity utils
    /// </summary>
    public static class EntityUtils {

        #region Entity Fetching

        #region Getting Id from Query String

        /// <summary>
        /// Gets an entity ID from the Query String
        /// </summary>
        /// <typeparam name="T">The entity's type</typeparam>
        /// <returns>The provided Id</returns>
        public static int GetIdFromQueryString<T>()
        {
            return GetIdFromQueryString<T>(typeof(T).Name);
        }

        /// <summary>
        /// Gets an entity ID from que query string
        /// </summary>
        /// <typeparam name="T">The entity's type</typeparam>
        /// <param name="key">The query string key</param>
        /// <returns>The id</returns>
        public static int GetIdFromQueryString<T>(string key)
        {
            string raw = HttpContext.Current.Request.QueryString[key];
            if (string.IsNullOrEmpty(raw)) {
                throw new UIException("No {0} key found at query string", key);
            }

            int id = 0;

            if (!int.TryParse(raw, out id)) {
                throw new UIException("Error parsing `{0}' to integer", raw);
            }

            return id;
        }

        #endregion Getting Id from Query String

        #region Getting Entity From Query String

        /// <summary>
        /// Gets an entity from the query string
        /// </summary>
        /// <typeparam name="T">The entity's type</typeparam>
        /// <returns>The entity</returns>
        public static T GetFromQueryString<T>()
        {
            return GetFromQueryString<T>(typeof(T).Name);
        }

        /// <summary>
        /// Gets an entity from the query string
        /// </summary>
        /// <typeparam name="T">The entity's type</typeparam>
        /// <param name="key">The query string key</param>
        /// <returns>The entity</returns>
        public static T GetFromQueryString<T>(string key)
        {
            int id = GetIdFromQueryString<T>(key);
            using (IPersistance<T> persistance = Persistance.Instance.GetPersistance<T>()) {
                return persistance.Select(id);
            }
        }

        #endregion Getting Entity From Query String

        #endregion Entity Fetching

    };
}