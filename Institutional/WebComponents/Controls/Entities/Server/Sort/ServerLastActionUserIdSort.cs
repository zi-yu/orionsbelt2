
using System.Web.UI;
using Institutional.Core;

namespace Institutional.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a Server's LastActionUserId
    /// </summary>
	public class ServerLastActionUserIdSort : BaseSort<Server> {
	
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			
						writer.Write("<a href='{0}?Sort=LastActionUserId{2}'>{1}</a>", GetCleanUrl(), innerHTML, GetQueryStringElements());
			
		}
		
	};

}
