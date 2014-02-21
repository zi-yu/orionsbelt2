using System;
using System.Web.UI;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {

	public class PaymentHistory: Page 
    {
        protected PaymentPagedList paged;
        protected PaymentNumberPagination pagination;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            paged.Where += string.Format("e.VerifyState<>'BadRequest' and e.VerifyState<>'Invalid' and e.ParentPayment=0 and e.PrincipalId={0}",Utils.Principal.Id);
        }

        
    }
}
