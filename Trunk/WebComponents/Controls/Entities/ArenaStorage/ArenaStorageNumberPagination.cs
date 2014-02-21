
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class ArenaStorageNumberPagination : BaseNumberPagination<ArenaStorage> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<ArenaStorage>();
		}
		
		#endregion BasePagination Implementation
			
	};

}