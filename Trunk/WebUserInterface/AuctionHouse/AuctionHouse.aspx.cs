using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.RulesCore.Common;

using OrionsBelt.WebComponents;
using System;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Controls.Auction_House;

namespace OrionsBelt.WebUserInterface {

	public class AuctionHousePage: Page 
    {
	    protected AuctionSearch search;
        protected AuctionHousePagedList paged;
	    protected AuctionHouseNumberPagination pagination;
	    protected AuctionHouseTimeoutSort sortTime;
	    protected AuctionHouseCurrentBidSort sortBid;
        protected AuctionHouseBuyoutSort sortBuyout;

        protected override void OnInit(EventArgs e)
        { 
            base.OnInit(e);
            string id = HttpContext.Current.Request.QueryString["buy"];
            int itemId;
            if (Int32.TryParse(id, out itemId))
            {
                string result = AuctionHouseUtil.MakeBuyout(itemId, PlayerUtils.Current.Storage);
                if (result != "Ok")
                {
                    ErrorBoard.AddLocalizedMessage(result);
                }
                else
                {
                    InformationBoard.AddLocalizedMessage(result);
                }
                return;
            }

            id = HttpContext.Current.Request.QueryString["bid"];
            if (Int32.TryParse(id, out itemId))
            {
                string result = AuctionHouseUtil.MakeBid(itemId, PlayerUtils.Current.Storage);
                if( result != "Ok")
                {
                    ErrorBoard.AddLocalizedMessage(result);
                }
                else
                {
                    InformationBoard.AddLocalizedMessage(result);
                }
                string req = HttpContext.Current.Request.Url.AbsolutePath;
                id = HttpContext.Current.Request.QueryString["Page"];
                if (Int32.TryParse(id, out itemId))
                {
                    req += string.Format("?Page={0}", itemId);

                    id = HttpContext.Current.Request.QueryString["Sort"];
                    if (!string.IsNullOrEmpty(id))
                    {
                        req += string.Format("&Sort={0}", id);
                    }
                }
                else
                {
                    id = HttpContext.Current.Request.QueryString["Sort"];
                    if(!string.IsNullOrEmpty(id))
                    {
                        req += string.Format("?Sort={0}", id);
                    }
                }
                HttpContext.Current.Response.Redirect(req);
                return;
            }
            sortTime.InnerHTML = LanguageManager.Instance.Get("EndTick");
            sortBid.InnerHTML = LanguageManager.Instance.Get("NextBid");
            sortBuyout.InnerHTML = LanguageManager.Instance.Get("Buyout");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            string arg = HttpContext.Current.Request.Form["searchChange"];
            if (arg == "1")
            {
                BasePagedList<AuctionHouse>.SetStart(0);
                paged.Where += search.Where;
                State.Session["AuctionSearch"] = search.Where;
            }
            else
            {
                if (null != State.Session["AuctionSearch"])
                {
                    paged.Where += State.Session["AuctionSearch"];
                }
            }


            long count;
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                count =
                    persistance.ExecuteScalar("select count(*) from SpecializedAuctionHouse where {0}", paged.Where);
                persistance.TypedQuery(
                    "select e,r from SpecializedAuctionHouse e inner join fetch e.OwnerNHibernate r where e.BuyedInTick=0");
            }
            State.SetItems(BasePagination<AuctionHouse>.CountKey, count);
            
        }
    }
}
