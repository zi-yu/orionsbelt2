using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Controls;


namespace OrionsBelt.WebUserInterface {
	public class AHRegist : Page {

        #region Fields

	    protected AuctionHouseBuyer buyer;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList<Principal> principals =
                    persistance.TypedQuery("SELECT p FROM SpecializedPrincipal p inner join fetch p.PlayerNHibernate");
                buyer.Principals = principals;
            }
          
        }
	    #endregion Events

        

    };
}

