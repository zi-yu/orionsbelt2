
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class BattleStatsNumberPagination : BaseNumberPagination<BattleStats> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<BattleStats>();
		}
		
		#endregion BasePagination Implementation
			
	};

}