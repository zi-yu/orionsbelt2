﻿
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class FleetNumberPagination : BaseNumberPagination<Fleet> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<Fleet>();
		}
		
		#endregion BasePagination Implementation
			
	};

}