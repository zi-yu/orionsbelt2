
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class PrincipalStatsNumberPagination : BaseNumberPagination<PrincipalStats> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<PrincipalStats>();
		}
		
		#endregion BasePagination Implementation
			
	};

}