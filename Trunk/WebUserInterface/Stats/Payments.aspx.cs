using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface {

	public class PaymentsPage: Page 
    {
	    protected PaymentCreatedDateSort sortDate;
	    protected PaymentPrincipalIdSort sortName;
        protected PayerControl payer;
	    protected PaymentMethodSort sortMethod;
        protected PaymentVerifyStateSort verifyStateSort;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            sortDate.InnerHTML = LanguageManager.Instance.Get("Date");
            sortName.InnerHTML = LanguageManager.Instance.Get("Name");
            sortMethod.InnerHTML = LanguageManager.Instance.Get("Method");
            verifyStateSort.InnerHTML = LanguageManager.Instance.Get("VerifyState");
            IDictionary<int, string> data = new Dictionary<int, string>();
            GetPrincipalDictionary(data);

            payer.Principals = data;

        }

        private static void GetPrincipalDictionary(IDictionary<int, string> data)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList principals = persistance.Query("SELECT e.Id,e.Name FROM SpecializedPrincipal e");
                foreach (IList list in principals)
                {
                    data.Add(Convert.ToInt32(list[0]), list[1].ToString());
                }

            }
        }
    }
}
