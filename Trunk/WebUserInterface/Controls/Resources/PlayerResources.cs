using OrionsBelt.Engine;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Web.UI;
using OrionsBelt.RulesCore;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PlayerResources : ControlBase {

		#region Private

		private static void WriteResource(HtmlTextWriter writer, IResourceInfo resource, int quantity) {
			writer.Write("<li>");

			string token = LanguageManager.Instance.Get(resource.Name);
            writer.Write("<a href='{0}'>", ManualUtils.GetUrl(resource));
			writer.Write("{0} ", ResourcesManager.GetResourceSmallImageHtml(resource));
            writer.Write("</a>");
			writer.Write("<span id='{1}'>{0}</span>", quantity, resource.Name);

			writer.Write("</li>");
		}

		private static void WriteDummyResources(HtmlTextWriter writer, int i) {
			if( i < 8 ) {
				for (int j = i; j < 8; ++j ) {
					writer.Write("<li/>");
				}
			}
		}

		#endregion Private

        #region Control Events

        protected override void Render(HtmlTextWriter writer)
        {
            if (!PlayerUtils.HasPlayer) {
                return;
            }

            IPlayer player = PlayerUtils.Current;

			writer.Write("<div id='playerResources'><ul>");
        	int i = 0;
            foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(player)) { 
                WriteResource(writer, info, player.GetQuantity(info));
				++i;
            }
			WriteDummyResources(writer,i);
            writer.Write("</ul></div>");
        }

        #endregion Control Events

    };
}
