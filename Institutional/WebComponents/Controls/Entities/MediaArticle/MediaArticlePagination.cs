
using System;
using System.Collections.Generic;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	public class MediaArticlePagination : BasePagination<MediaArticle> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<MediaArticle>();
		}
		
		#endregion BasePagination Implementation
			
	};

}