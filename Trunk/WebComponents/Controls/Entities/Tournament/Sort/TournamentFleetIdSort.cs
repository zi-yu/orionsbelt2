﻿
using System.Web.UI;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a Tournament's FleetId
    /// </summary>
	public class TournamentFleetIdSort : BaseSort<Tournament> {
	
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			
						writer.Write("<a href='{0}?Sort=FleetId{2}'>{1}</a>", GetCleanUrl(), innerHTML, GetQueryStringElements());
			
		}
		
	};

}
