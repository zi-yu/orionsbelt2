
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class ServerPropertiesNumberPagination : BaseNumberPagination<ServerProperties> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<ServerProperties>();
		}
		
		#endregion BasePagination Implementation
			
	};

}