﻿using System.IO;
using System.Collections.Generic;
using System.Web;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// This control renders a subset of an Entity records
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
	public abstract class BasePagedList<T> : BaseList<T> where T : IDescriptable {

        #region Control Fields

        public const int DefaultItemsPerPage = 5;
        private int itemsPerPage = DefaultItemsPerPage;
        private string orderBy = "Id";
        private string orderByParam = "asc";
		private string whereParam = null;
		private string selectParam = null;
		private int start = 0;

        #endregion Control Fields

        #region Control Properties

		/// <summary>
        /// The number of entities to render
        /// </summary>
        public int ItemsPerPage {
            get {
                object obj = HttpContext.Current.Items[GetCountKey(EntityName)];
                if ( obj != null ) {
                    return (int)obj;
                }
                return itemsPerPage;
            }
			set { itemsPerPage = value; }
        }

		/// <summary>
        /// The firs element position to render
        /// </summary>
        public int Start {
            get {
                object obj = HttpContext.Current.Items[GetStartKey(EntityName)];
                if (obj != null) {
                    return (int)obj;
                }
                return start;
            }
			set { start = value; }
        }

		/// <summary>
        /// Field to order the entities
        /// </summary>
        public string OrderBy {
            get {
                object obj = HttpContext.Current.Items[GetOrderByKey(EntityName)];
                if (obj != null) {
                    return (string)obj;
                }
                return orderBy;
            }
			set { orderBy = value; }
        }

		/// <summary>
        /// Param to order the entities (asc, desc)
        /// </summary>
        public string OrderByParam {
            get {
                object obj = HttpContext.Current.Items[GetOrderByParamKey(EntityName)];
                if (obj != null) {
                    return (string)obj;
                }
                return orderByParam;
            }
			set { orderByParam = value; }
        }

		/// <summary>
        /// Where clause of the query
        /// </summary>
        public string Where {
            get {
                object obj = HttpContext.Current.Items[GetWhereKey(EntityName)];
                if (obj != null) {
                    return (string)obj;
                }
                return whereParam;
            }
			set { whereParam = value; }
        }
		
		/// <summary>
        /// Select part of the query
        /// </summary>
		public string Select {
            get {
                object obj = HttpContext.Current.Items[GetSelectKey(EntityName)];
                if (obj != null) {
                    return (string)obj;
                }
				if (selectParam == null) {
                    return string.Format("from Specialized{0} e ", EntityName);
                }
                return selectParam;
            }
            set { selectParam = value; }
        }
        
        #endregion Control Properties

        #region BaseList<T> Implementation

		/// <summary>
        /// Obtain the collection to render
        /// </summary>
        /// <returns>The collection</returns>
        protected override IList<T> GetCollection()
		{
            return Persistance.TypedQuery(
                    Start, 
                    ItemsPerPage, 
                    GenerateHql(EntityName, Select, Where, OrderBy, OrderByParam)
                );
		}
		
		#endregion BaseList<T> Implementation
		
		#region Abstract Members
		
		/// <summary>
        /// The Persistance object
        /// </summary>
		protected abstract IPersistance<T> Persistance {get;}

		/// <summary>
        /// The current entity name
        /// </summary>
		protected virtual string EntityName {
            get { return typeof(T).Name; }
        }
		
		#endregion Abstract Members

        #region Static Utilities

		/// <summary>
        /// Gets the Count key
        /// </summary>
        /// <param name="entityName">Current entity name</param>
        /// <returns>The key</returns>
        public static string GetCountKey(string entityName)
        {
            return string.Format("PagedList-{0}Count", entityName);
        }

		/// <summary>
        /// Gets the Start key
        /// </summary>
        /// <param name="entityName">Current entity name</param>
        /// <returns>The key</returns>
        public static string GetStartKey(string entityName)
        {
            return string.Format("PagedList-{0}Start", entityName);
        }

		/// <summary>
        /// Gets the OrderByParam key
        /// </summary>
        /// <param name="entityName">Current entity name</param>
        /// <returns>The key</returns>
        public static string GetOrderByParamKey(string entityName)
        {
            return string.Format("PagedList-{0}OrderByParam", entityName);
        }

		/// <summary>
        /// Gets the OrderBy key
        /// </summary>
        /// <param name="entityName">Current entity name</param>
        /// <returns>The key</returns>
        public static string GetOrderByKey(string entityName)
        {
            return string.Format("PagedList-{0}OrderBy", entityName);
        }

		/// <summary>
        /// Gets the Where key
        /// </summary>
        /// <param name="entityName">Current entity name</param>
        /// <returns>The key</returns>
        public static string GetWhereKey(string entityName)
        {
            return string.Format("PagedList-{0}Where", entityName);
        }
		
		/// <summary>
        /// Gets theSelect key
        /// </summary>
        /// <param name="entityName">Current entity name</param>
        /// <returns>The key</returns>
		public static string GetSelectKey(string entityName)
        {
            return string.Format("PagedList-{0}Select", entityName);
        }

		/// <summary>
        /// Generates the HQL to obtain the current collection
        /// </summary>
        /// <param name="entityName">The entity name</param>
        /// <param name="select">The select part of the query</param>
        /// <param name="where">The where part of the query</param>
        /// <param name="orderBy">The order by part of the query</param>
        /// <param name="orderByParam">The order by param part of the query</param>
        /// <returns>The HQL</returns>
        public static string GenerateHql(string entityName, string select, string where, string orderBy, string orderByParam)
        {
            StringWriter writer = new StringWriter();

            writer.WriteLine(select);
            if (!string.IsNullOrEmpty(where)) {
                writer.WriteLine(" where {0} ", where);
            }
            writer.Write(" order by e.{0} {1}", orderBy, orderByParam);

            return writer.ToString();
        }
        
        /// <summary>
        /// Set's the first element
        /// </summary>
        public static void SetStart( int value ) {
			HttpContext.Current.Items[GetStartKey(typeof(T).Name)] = value;
        }

        /// <summary>
        /// Set's the order by element
        /// </summary>
        public static void SetOrderBy(string value)
        {
            HttpContext.Current.Items[GetOrderByKey(typeof(T).Name)] = value;
        }

        /// <summary>
        /// Set's the order by param
        /// </summary>
        public static void SetOrderByParam(string value)
        {
            HttpContext.Current.Items[GetOrderByParamKey(typeof(T).Name)] = value;
        }
        #endregion

    };

}
