using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;


namespace OrionsBelt.WebUserInterface {

    public class MyAuctionItems : Page 
    {
        protected AuctionHousePagedList paged, olds;

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            paged.Where = string.Format("e.BuyedInTick=0 and e.OwnerNHibernate.Id={0}", PlayerUtils.Current.Storage.Id);
            olds.Where = string.Format("e.BuyedInTick<>0 and e.HigherBidOwner<>0 and e.OwnerNHibernate.Id={0}", PlayerUtils.Current.Storage.Id);
        }


        #endregion Events

    }
}
