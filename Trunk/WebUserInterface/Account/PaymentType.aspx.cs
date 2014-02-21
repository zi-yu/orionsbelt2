using System;
using System.Configuration;
using System.Web.UI;
using DesignPatterns;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.PaysafeWS;
using Paysafecard.Client;
using System.Web.Services.Protocols;

namespace OrionsBelt.WebUserInterface.Account {
	public partial class PaymentType : Page {

		private static readonly FactoryContainer container = new FactoryContainer(typeof(PaymentControlBase));

		protected override void OnLoad(EventArgs e) {
			string type = Page.Request.QueryString["Type"];
			if (container.ContainsKey(type)) {
				PaymentControlBase paymentControlBase = (PaymentControlBase)container.create(type);
				panel.Controls.Add(paymentControlBase);
			}else {
				panel.Controls.Add(new LiteralControl("Invalid"));
			}

            if(Page.Request.Form.HasKeys())
            {
                string[] data = Page.Request.Form.GetKey(0).Split('_');
                Send(Convert.ToDouble(data[1]));
            }
		}

        private void Send(double cost)
        {
            try
            {
                bool useWS = Convert.ToBoolean(ConfigurationManager.AppSettings["paysafeUseWS"]);
                string url;
                string basePath = OrionsBelt.Generic.Server.Properties.BaseUrl;

                if (useWS)
                {
                    PaysafeProxy paysafeWS = new PaysafeProxy();
                    url = paysafeWS.CreatePost(cost, Utils.Principal.Id, Utils.Principal.Locale, basePath);
                }
                else
                {
                    url = CreatePost(cost, Utils.Principal.Id, Utils.Principal.Locale, basePath);
                }

                Response.Redirect(url);
                
            }
            catch (SoapException pscEx)
            {
                ErrorBoard.AddLocalizedMessage("PaysafeTransError");
                ExceptionLogger.Log(pscEx.InnerException);
            }
        }

        private static string CreatePost(double cost, int principalId, string principalLang, string basePath)
        {
            Paysafecard.Client.Configuration config = new Paysafecard.Client.Configuration(ConfigurationManager.AppSettings["merchant.properties"]);
            string merchantId = config["merchantId"];
            string confCur = config["currency"];
            string businessType = config["businessType"];
            string reportingCriteria = config["reportingCriteria"];
            string amount = string.Format("{0}.00", cost);
            MerchantApi api = new MerchantApi(merchantId, config, config["language"]);
            string merchantTransactionId = api.GenerateMerchantTransactionId();
            string okUrl = string.Format("{0}Account/Ok.aspx?mtid={1}&amount={2}&id={3}", basePath,
                                         merchantTransactionId, cost, principalId);
            string notOkUrl = basePath + "Account/NotOk.aspx";
            api.CreateDisposition(merchantTransactionId, amount, confCur, businessType,
                                  reportingCriteria, okUrl, notOkUrl);

            string lang = principalLang;
            if (string.IsNullOrEmpty(lang))
            {
                lang = config["clientLang"];
            }
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", config["redirect_URL"],
                                       "?currency=", confCur,
                                       "&mid=", merchantId,
                                       "&mtid=", merchantTransactionId,
                                       "&amount=", amount,
                                       "&language=", lang);

            //return string.Format("<form action='{0}' method='post'>", url);

        }
	}
}
