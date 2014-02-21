using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;

namespace Institutional.WebComponents.Controls {

    /// <summary>
    /// Base control that knows the the quantity of records of a specficic entity T
    /// </summary>
    /// <typeparam name="T">The Entity Type</typeparam>
	public abstract class BaseEntityCount<T> : Control where T : IDescriptable {
	
		#region Ctor & Control Fields
		
		private IPersistance<T> persistance = null;
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="per">The persistance object to obtain the quantity</param>
		public BaseEntityCount( IPersistance<T> per )
		{
			Persistance = per;
		}
		
		#endregion Control Fields
		
		#region Control Properties
		
		/// <summary>
        /// The Persistance object to be used
        /// </summary>
		public IPersistance<T> Persistance {
			get { return persistance; }
			set { persistance = value; }
		}
		
		#endregion Control Properties
	
		#region Control Events
		
		/// <summary>
        /// Renders the control in XHTML
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
		protected override void Render( HtmlTextWriter writer )
		{
			writer.Write( Persistance.GetCount() );
		}
		
		#endregion Control Rendering
		
	};

}