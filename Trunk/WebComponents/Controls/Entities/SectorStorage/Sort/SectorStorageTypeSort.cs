﻿
using System.Web.UI;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a SectorStorage's Type
    /// </summary>
	public class SectorStorageTypeSort : BaseSort<SectorStorage> {
	
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			
						writer.Write("<a href='{0}?Sort=Type{2}'>{1}</a>", GetCleanUrl(), innerHTML, GetQueryStringElements());
			
		}
		
	};

}
