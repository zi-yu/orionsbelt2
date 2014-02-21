
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class GlobalStatsPagination : BasePagination<GlobalStats> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<GlobalStats>();
		}
		
		#endregion BasePagination Implementation
			
	};

}