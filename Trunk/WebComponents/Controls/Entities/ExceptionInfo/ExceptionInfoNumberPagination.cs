
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	public class ExceptionInfoNumberPagination : BaseNumberPagination<ExceptionInfo> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<ExceptionInfo>();
		}
		
		#endregion BasePagination Implementation
			
	};

}