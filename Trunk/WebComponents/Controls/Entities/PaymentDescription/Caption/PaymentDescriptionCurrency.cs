﻿
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a PaymentDescription's Currency
    /// </summary>
	public class PaymentDescriptionCurrency : BaseFieldControl<PaymentDescription>, INamingContainer {
	
		#region BaseFieldControl<PaymentDescription> Implementation
		
		/// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, PaymentDescription entity, int renderCount, bool flipFlop )
		{
			writer.Write( entity.Currency );
		}
		
		#endregion BaseFieldControl<PaymentDescription> Implementation
		
	};

}
