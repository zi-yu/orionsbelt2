
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class FriendOrFoePagination : BasePagination<FriendOrFoe> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<FriendOrFoe>();
		}
		
		#endregion BasePagination Implementation
			
	};

}