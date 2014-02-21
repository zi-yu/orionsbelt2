using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;


namespace OrionsBelt.WebUserInterface {

    public class MyBids : Page 
    {
        protected AuctionHousePagedList paged,olds;


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            paged.Where = string.Format(
                @"e.Id in 
                (select a.ResourceNHibernate.Id from SpecializedBidHistorical a where a.MadeByNHibernate.Id={0}) 
                and e.BuyedInTick=0", PlayerUtils.Current.Storage.Id);

            olds.Where = string.Format("e.BuyedInTick<>0 and e.HigherBidOwner={0}",PlayerUtils.Current.Storage.Id);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}
