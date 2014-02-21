using System;
using System.Web.UI;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using System.Web.UI.WebControls;
using OrionsBelt.WebUserInterface.PaymentSystems;
using OrionsBelt.Engine.MarketPlace;

namespace OrionsBelt.WebUserInterface {

	public class PrintInvoicePage: Page 
    {
        private Invoice invoice;
	    protected Literal article;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            invoice = EntityUtils.GetFromQueryString<Invoice>();
            if(!Utils.Principal.IsInRole("financial"))
            {
                int id = invoice.Payment.PrincipalId;
                if(id != Utils.Principal.Id)
                {
                    Page.Response.Redirect("PaymentHistory.aspx");
                }
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if(invoice.Payment.Method == PaymentMethodEnum.SMS.ToString())
            {
                return;
            }

            if(string.IsNullOrEmpty(invoice.Country))
            {
                article.Text = LanguageManager.Instance.Get("NoIvaB");
                return;
            }

            if(invoice.Country != "PT")
            {
                Country country = InvoiceUtils.GetCountry(invoice.Country);

                if(!country.IsEU)
                {
                    article.Text = LanguageManager.Instance.Get("NoIvaB");
                    return;
                }

                if(country.IsEU && InvoiceUtils.IsCorporate(invoice))
                {
                    article.Text = LanguageManager.Instance.Get("NoIvaA");
                    return;
                }


            }
        }

        
    }
}
