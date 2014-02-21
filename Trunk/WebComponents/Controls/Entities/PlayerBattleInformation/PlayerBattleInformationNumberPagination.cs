
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class PlayerBattleInformationNumberPagination : BaseNumberPagination<PlayerBattleInformation> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<PlayerBattleInformation>();
		}
		
		#endregion BasePagination Implementation
			
	};

}