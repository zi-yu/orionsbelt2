﻿
using System.Web.UI;
using Institutional.Core;

namespace Institutional.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a MediaArticle's Name
    /// </summary>
	public class MediaArticleNameSort : BaseSort<MediaArticle> {
	
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			
						writer.Write("<a href='{0}?Sort=Name{2}'>{1}</a>", GetCleanUrl(), innerHTML, GetQueryStringElements());
			
		}
		
	};

}
