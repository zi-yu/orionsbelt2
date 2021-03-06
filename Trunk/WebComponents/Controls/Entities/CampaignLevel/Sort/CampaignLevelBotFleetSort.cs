﻿
using System.Web.UI;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a CampaignLevel's BotFleet
    /// </summary>
	public class CampaignLevelBotFleetSort : BaseSort<CampaignLevel> {
	
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			
						writer.Write("<a href='{0}?Sort=BotFleet{2}'>{1}</a>", GetCleanUrl(), innerHTML, GetQueryStringElements());
			
		}
		
	};

}
