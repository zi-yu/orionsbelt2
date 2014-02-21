using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using System.Web.UI.HtmlControls;

namespace OrionsBelt.WebUserInterface {

	public class InvoicePage: Page 
    {
	    protected Button print;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Invoice invoice = EntityUtils.GetFromQueryString<Invoice>();
            print.Text = LanguageManager.Instance.Get("Print");
            if(!Utils.Principal.IsInRole("financial"))
            {
                int id = invoice.Payment.PrincipalId;
                if(id != Utils.Principal.Id)
                {
                    Page.Response.Redirect("PaymentHistory.aspx");
                }
            }

        }

        
    }
}
