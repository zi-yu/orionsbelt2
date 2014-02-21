using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls{
    public class ResourcesViewer : Control {
        #region Private

        private static string GetContent(IEnumerable<KeyValuePair<IResourceInfo, int>> resources) {
            StringWriter content = new StringWriter();
            
            content.Write("<table class='newtable'><tr><th>{0}</th><th>{1}</th></tr>", LanguageManager.Instance.Get("Resources"), LanguageManager.Instance.Get("Quantity"));
            foreach (KeyValuePair<IResourceInfo, int> resource in resources) {
                content.Write("<tr><td>{0}</td><td>{1}</td></td>", ResourcesManager.GetResourceSmallImageHtml(resource.Key), resource.Value.ToString());
            }
            content.Write("</table>");

            return content.ToString();
        }

        #endregion Private

        #region Control Events

        protected override void  Render(HtmlTextWriter writer){
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("YourResources"));

            IEnumerable<KeyValuePair<IResourceInfo, int>> resources = ResourceUtils.GetAuctionHouseResources(PlayerUtils.Current);

            string content = GetContent(resources);

            Border.RenderSmall(writer, title, content);
        }
       
        #endregion Control Events
    }
}
