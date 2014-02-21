using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Account
{
    public class PaymentPage : System.Web.UI.Page {
        protected Literal discloser;

        protected override void OnPreRender(System.EventArgs e){
            string title = string.Format("<h2>{0}</h2>",LanguageManager.Localize("ImportantMessage"));
            string text = string.Format("<span class='green'>{0}</span>",LanguageManager.Localize("PaymentDiscloser"));

            StringWriter writer = new StringWriter();
            Border.RenderByRaceInformation(writer, title, text);

            discloser.Text = writer.ToString();
            
        }


   };
}
