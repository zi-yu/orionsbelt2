
using System;
using System.Collections.Generic;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	public class TestimonialPagination : BasePagination<Testimonial> {
	
		#region BasePagination Implementation
		
		protected override long GetTotalItems()
		{
			return Persistance.GetEntityCount<Testimonial>();
		}
		
		#endregion BasePagination Implementation
			
	};

}