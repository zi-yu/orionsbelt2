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
    /// Renders in XHTML the content of a GlobalStats's CreatedDate
    /// </summary>
	public class GlobalStatsCreatedDate : BaseFieldControl<GlobalStats>, INamingContainer {
	
		#region BaseFieldControl<GlobalStats> Implementation
		
		/// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, GlobalStats entity, int renderCount, bool flipFlop )
		{
			writer.Write( entity.CreatedDate );
		}
		
		#endregion BaseFieldControl<GlobalStats> Implementation
		
	};

}
