using System.IO;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Web.UI;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PlanetBottomInfoRenderer : Control {

        #region Rendering

		protected override void Render(HtmlTextWriter writer) {
			writer.Write("<div id='planetBottomInfo'>");
			writer.Write("<div id='planetBottomInfoSquare'>");
			writer.Write("<h3>{0}</h3>",LanguageManager.Instance.Get("Recruit"));
			string recruitContent = string.Format(LanguageManager.Instance.Get("RecruitContent"), OrionsBelt.Generic.Server.Properties.Name, Utils.Principal.Id);
			writer.Write("<div id='planetBottomInfoContent'>{0}</div>", recruitContent);
			writer.Write("<div id='planetBottomInfoBottom'></div>");
			writer.Write("</div>");
			writer.Write("<div id='planetBottomInfoSquare'>");
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("ObtainOrions"));
			string paymentContent = string.Format(LanguageManager.Instance.Get("ObtainOrionsContent"), ResourcesManager.GetIconsImage("Orions"), WebUtilities.ApplicationPath);
			writer.Write("<div id='planetBottomInfoContent'>{0}</div>", paymentContent);
			writer.Write("<div id='planetBottomInfoBottom'></div>");
			writer.Write("</div>");
			writer.Write("</div>");
		}

        #endregion Rendering

    };
}

