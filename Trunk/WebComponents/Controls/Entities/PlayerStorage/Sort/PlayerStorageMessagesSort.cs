﻿
using System.Web.UI;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a PlayerStorage's Messages
    /// </summary>
	public class PlayerStorageMessagesSort : BaseSort<PlayerStorage> {
	
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			
						writer.Write("<a href='{0}?Sort=MessagesNHibernate.Id{2}'>{1}</a>", GetCleanUrl(), innerHTML, GetQueryStringElements());
			
		}
		
	};

}
