
using System;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Testimonial in the data source
    /// </summary>
	public class TestimonialCount : BaseEntityCount<Testimonial> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TestimonialCount () : base( Institutional.DataAccessLayer.Persistance.Instance.GetTestimonialPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}