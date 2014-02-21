using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

    public class AHMyBid : BaseFieldControl<AuctionHouse>, INamingContainer {
        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop){
            IList<int> mybids;
            if(State.HasItems("MyBids")) {
                mybids = (IList<int>)State.GetItems("MyBids");
            }else{
                mybids = Hql.Query<int>("select a.ResourceNHibernate.Id from SpecializedBidHistorical a where a.MadeByNHibernate.Id=:id",Hql.Param("id",PlayerUtils.Current.Storage.Id)); 
                State.SetItems("MyBids",mybids);
            }

            foreach(int id in mybids) {
                if(entity.Id == id) {
                    writer.Write("class='mybid'");
                    return;
                }
            }
        }
    }
}
