﻿
using System.Web.UI;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a Interaction's UpdatedDate
    /// </summary>
	public class InteractionUpdatedDateSort : BaseSort<Interaction> {
	
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			
						writer.Write("<a href='{0}?Sort=UpdatedDate{2}'>{1}</a>", GetCleanUrl(), innerHTML, GetQueryStringElements());
			
		}
		
	};

}
