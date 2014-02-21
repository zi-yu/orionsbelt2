using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Loki.DataRepresentation;

namespace Institutional.WebComponents.Controls {
	
	public abstract class BaseNumberPagination<T>: BasePagination<T> where T: IDescriptable {
	
		#region Fields

		private int maximum = 4;
		private int pagination = 4;
		private string queryString = string.Empty;

		#endregion Fields

		#region Private

		protected int GetStartPosition( int numberOfPages ) {
			int start = currentPage - pagination;

			int pos = currentPage + pagination;
			if( pos > numberOfPages ) {
				int p = pos - numberOfPages;
				start -= p;
			}
			return start;
		}

		protected int WritePreviousPages( HtmlTextWriter writer, string url, int numberOfPages ) {
			if( currentPage == 1 ) {
				return 0;
			}
			int start = GetStartPosition(numberOfPages);
			int count = 0;
			
			for( int i = start; i < currentPage; ++i  ) {
				if( i > 0 ) {
					writer.Write(" <a href='{0}?Page={1}{2}'>{1}</a> ", url, i, GetQueryStringElements());
					++count;
				}
			}

			return count;
		}

		protected void WriteNextPages( HtmlTextWriter writer, string url , int written, int numberOfPages ) {
			if( currentPage < numberOfPages ) {
				int total = maximum + ( maximum - written );
				for( int i = 1; i <= total; ++i ) {
					if( currentPage + i > numberOfPages ) {
						return;
					}
					writer.Write(" <a href='{0}?Page={1}{2}'>{1}</a> ", url, currentPage + i, GetQueryStringElements());
				}
			}
		}

		/// <summary>
		/// Gets all the elements in the query string except the "Page" element
		/// </summary>
		/// <returns></returns>
		protected string GetQueryStringElements() {
			if( queryString.Length == 0 ) {
				StringBuilder builder = new StringBuilder();
				foreach( string c in Page.Request.QueryString.AllKeys ) {
					if( string.Compare(c, "Page", true) == 0 ) {
						continue;
					}
					builder.AppendFormat("&{0}={1}", c, Page.Request.QueryString[c]);
				}
				queryString = builder.ToString();
			}
			return queryString;
		}

		#endregion Private

		#region Control Events

		protected override void Render( HtmlTextWriter writer ) {
			if( TotalNumberOfItems != 0 ) {
                writer.Write("<div class='pagination'>");
				int numberOfPages = (int)( ( TotalNumberOfItems / itemsPerPage ));
				if (numberOfPages >= 1){
					if( TotalNumberOfItems % itemsPerPage > 0 ) {
						numberOfPages += 1;
					}
					string url = GetPaginationUrl();

					if( currentPage != 1 ) {
						writer.Write(" <a href='{0}?Page=1{1}'>&lt;&lt;</a> ", url, GetQueryStringElements() );
					}

					int written = WritePreviousPages(writer, url, numberOfPages);
					writer.Write(" <b>{0}</b> ", currentPage);
					WriteNextPages(writer, url, written, numberOfPages);

					if( currentPage != numberOfPages ) {
						writer.Write(" <a href='{0}?Page={1}{2}'>&gt;&gt;</a> ", url, numberOfPages, GetQueryStringElements() );
					}
				}
                writer.Write("</div>");
			}
		}
		
		#endregion Control Events
	};
}