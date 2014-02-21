using System;
using System.Web.UI;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface {

	public class PrincipalTransactions: Page 
    {
	    protected TransactionPagedList paged, earns;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            int principal = EntityUtils.GetIdFromQueryString<Principal>();
            paged.Where = string.Format("e.PrincipalIdSpend={0}", principal);
            earns.Where = string.Format("(e.IdentifierGain={0} and e.IdentityTypeGain='Principal')", principal);

        }
    }
}
