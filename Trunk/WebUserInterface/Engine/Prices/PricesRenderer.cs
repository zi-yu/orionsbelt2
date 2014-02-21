using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Core;
using OrionsBelt.WebUserInterface.Alliance;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.PaymentSystems;

namespace OrionsBelt.WebUserInterface.Engine
{
    public class PricesRenderer
    {
        public static void Render(TextWriter tw , string language)
        {
			if( language.Equals("pt")){
        		List<PaymentDescription> descriptions = PaymentDescriptionLoader.GetPaymentDescriptions("Sms");
        		List<PaymentDescription> descriptionsByLang = descriptions.FindAll(delegate(PaymentDescription p) { return p.Locale.Equals(language); });
        		foreach (PaymentDescription description in descriptionsByLang) {
        			SMS sms = new SMS();
        			string render = sms.Render(Utils.Principal, CurrencyEnum.Euro, description);
					tw.Write(render);
        		}
			}else {
				List<PaymentDescription> descriptions = PaymentDescriptionLoader.GetPaymentDescriptions("OneBip");
				foreach (PaymentDescription description in descriptions) {
					tw.Write("<div class='onebip'>");
					OneBip sms = new OneBip();
					string render = sms.Render(Utils.Principal, CurrencyEnum.Euro, description);
					tw.Write(render);
					tw.Write("</div>");
				}
			}


			//IList<SMSInfoContainer> info = infos[language];
			//foreach (SMSInfoContainer container in info){
			//    tw.Write("<span><ul><li><b>Orions:</b> {0}</li><li><b>{1}:</b> {2} {3}</li><li><b>{4}:</b> {5}</li>",
			//    container.Orions, LanguageManager.Instance.Get("Cost"), container.Money, container.Currency,LanguageManager.Instance.Get("Number"), container.Number);
			//    string server = "s0";
			//    if(servers.ContainsKey(Server.Properties.BaseUrl)){
			//        server = servers[Server.Properties.BaseUrl];
			//    }
			//    tw.Write("<li><b>{0}:</b> ob {1} {2}</li></ul></span>", LanguageManager.Instance.Get("Message"), server, Utils.Principal.Id);
			//}
            
        }
    }
}
