﻿
using System.Web.UI;
using Institutional.Core;

namespace Institutional.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a Principal's UpdatedDate
    /// </summary>
	public class PrincipalUpdatedDateSort : BaseSort<Principal> {
	
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			
						writer.Write("<a href='{0}?Sort=UpdatedDate{2}'>{1}</a>", GetCleanUrl(), innerHTML, GetQueryStringElements());
			
		}
		
	};

}
