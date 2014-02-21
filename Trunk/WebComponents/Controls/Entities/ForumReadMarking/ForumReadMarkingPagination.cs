
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class ForumReadMarkingPagination : BasePagination<ForumReadMarking> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<ForumReadMarking>();
		}
		
		#endregion BasePagination Implementation
			
	};

}