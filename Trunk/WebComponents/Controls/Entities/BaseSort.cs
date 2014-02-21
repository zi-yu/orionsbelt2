using System;
using System.Text;
using System.Web.UI;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Base control for sorting
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
	public abstract class BaseSort<T> : Control where T : IDescriptable {

		#region Ctor & Control Fields

	    protected bool isAscending = true;
	    protected string innerHTML = string.Empty;
        private string queryString = string.Empty;
	
		#endregion Control Fields
		
		#region Control Properties

		/// <summary>
        /// Sort type
        /// </summary>
        public bool IsAscending
        {
            get { return isAscending; }
            set { isAscending = value; }
		}

	    public string InnerHTML
	    {
	        get { return innerHTML; }
	        set { innerHTML = value; }
	    }

	    #endregion Control Properties

        /// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);
            string sort = Page.Request.QueryString["Sort"];
            if (string.IsNullOrEmpty(sort))
            {
                return;
            }

            BasePagedList<T>.SetOrderBy(sort);
            
			if (!ToString().Contains(sort))
            {
                return;
            }
            
            if(isAscending)
            {
                BasePagedList<T>.SetOrderByParam("asc"); 
            }
            else
            {
                BasePagedList<T>.SetOrderByParam("desc");
            }
            
        }

        /// <summary>
        /// Gets all the elements in the query string except the "Page" element
        /// </summary>
        /// <returns></returns>
        protected string GetQueryStringElements()
        {
            if (queryString.Length == 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string c in Page.Request.QueryString.AllKeys)
                {
                    if (string.Compare(c, "Sort", true) == 0)
                    {
                        continue;
                    }
                    builder.AppendFormat("&{0}={1}", c, Page.Request.QueryString[c]);
                }
                queryString = builder.ToString();
            }
            return queryString;
        }

        /// <summary>
        /// Gets the url of the current page
        /// </summary>
        /// <returns></returns>
        protected string GetCleanUrl()
        {
            string url = Page.Request.RawUrl;
            int i = url.IndexOf("?");
            if (i != -1)
            {
                return url.Substring(0, i);
            }
            return url;
        }
	
	};
}