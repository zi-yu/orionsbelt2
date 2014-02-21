
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class PrincipalTournamentNumberPagination : BaseNumberPagination<PrincipalTournament> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<PrincipalTournament>();
		}
		
		#endregion BasePagination Implementation
			
	};

}