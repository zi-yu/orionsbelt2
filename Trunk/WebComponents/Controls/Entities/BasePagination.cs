using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;
using System.Web;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Base control for BasePagedList pagination
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
	public abstract class BasePagination<T> : Control where T : IDescriptable {

		#region Ctor & Control Fields
		
		protected int itemsPerPage = 25;
		protected int currentPage = 1;
		private long totalNumberOfItems = -1;
	
		#endregion Control Fields
		
		#region Control Properties

        public long TotalNumberOfItems {
            get {
                if (totalNumberOfItems < 0) {
                    totalNumberOfItems = GetCount();
                }
                return totalNumberOfItems;
            }
        }

		/// <summary>
        /// Number of objects to render
        /// </summary>
		public int ItemsPerPage{
			get{ return itemsPerPage; }
			set{ itemsPerPage = value; }
		}
		
		/// <summary>
		/// Page to Render
		/// </summary>
		public int StartPage {
			get {
				int start = ( currentPage - 1 ) * ItemsPerPage;
				if( start < 0 /*|| start > TotalNumberOfItems*/ ) {
					return 0;
				}
				return start;
			}
		}

        /// <summary>
        /// Key for the Items state bag
        /// </summary>
        public static string CountKey {
            get {
                string key = string.Format("BasePagination - {0} Count", typeof(T).Name);
                return key;
            }
        }
		
		#endregion Control Properties
	
		#region Control Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			string current = Page.Request.QueryString["Page"];
			if(!string.IsNullOrEmpty(current)) {
				currentPage = int.Parse(current);
			}
			
			BasePagedList<T>.SetStart( StartPage );
			
			base.OnInit(args);
		}
		
		/// <summary>
        /// Renders this control
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
		protected override void Render( HtmlTextWriter writer )
		{
            int numberOfPages = (int)Math.Ceiling((double)(GetCount() / itemsPerPage));
			writer.Write("<ul>");
			writer.Write("<li><a href='{0}?Page=1'>First</a></li>", Page.Request.RawUrl);
			writer.Write("<li><a href='{0}?Page={1}'>Previous</a></li>", Page.Request.RawUrl, GetPrevious());
			for(int iter = 1; iter <= numberOfPages; ++iter){
				if(iter == currentPage)
				{
					writer.Write("<li class='selected'><a href='{0}?Page={1}'>{1}</a></li>", Page.Request.RawUrl);
				}
				else
					writer.Write("<li><a href='{0}?Page={1}'>{1}</a></li>", Page.Request.RawUrl);

			}
			writer.Write("</ul>");	
		}
		
		#endregion Control Rendering
				
		#region Private Methods

		/// <summary>
        /// Get's the previous page
        /// </summary>
        /// <returns>The page number</returns>
		private int GetPrevious(){
		
			if(currentPage == 1)
				return 1;
			else
			{
				return currentPage - 1;
			}			
		}
		
		/// <summary>
		/// Gets the url of the current page
		/// </summary>
		/// <returns></returns>
		protected string GetPaginationUrl() {
			string url = Page.Request.RawUrl;
			int i = url.IndexOf("?");
			if( i != -1 ) {
				return url.Substring( 0, i );
			}
			return url;
		}

		#endregion Private Methods
		
		#region Abstract Members

        /// <summary>
        /// Gets the current number of items to paginate
        /// </summary>
        /// <returns>The number of items</returns>
        protected virtual long GetCount()
        {
            string key = CountKey;
            if (State.HasItems(key)) {
                return (long)State.GetItems(key);
            }
            return GetTotalItems();
        }
		
		/// <summary>
        /// Gets the total number of objects to show
        /// </summary>
        /// <returns>The objects number</returns>
		protected abstract long GetTotalItems();
		
		#endregion Abstract Members
		
	};
}