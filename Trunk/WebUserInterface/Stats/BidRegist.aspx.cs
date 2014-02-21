using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {
	public class BidRegist : Page 
    {
	    protected Literal container;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string id = HttpContext.Current.Request.QueryString["Product"];

            IList<BidHistorical> historical;
            AuctionHouse product;
            using (IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance())
            {
                historical = persistance.TypedQuery("SELECT e FROM SpecializedBidHistorical e WHERE e.ResourceNHibernate.Id={0}", id);

                using (IAuctionHousePersistance persistance2 = Persistance.Instance.GetAuctionHousePersistance(persistance))
                {
                    product = persistance2.SelectById(Convert.ToInt32(id))[0];
                }
            }

            WriteDate(historical, product);
        }

        private void WriteDate(IEnumerable<BidHistorical> historical, AuctionHouse product)
        {
            TextWriter writer = new StringWriter();

            WriteProductDetails(writer, product);

            WriteBidTable(writer, historical);
            container.Text = writer.ToString();
        }

	    private static void WriteProductDetails(TextWriter writer, AuctionHouse product)
	    {
            writer.Write("<ul id='bidData'><li><b>{0}:</b> ", LanguageManager.Instance.Get("Description"));
	        if (((AuctionHouseType)Enum.Parse(typeof(AuctionHouseType), product.ComplexNumber.ToString()) & AuctionHouseType.Ship) == 0)
	        {
	            writer.Write("<a href='{1}'>{0}</a>",
	                         ResourcesManager.GetResourceSmallImageHtml(RulesUtils.GetResource(product.Details)), ManualUtils.GetUrl(RulesUtils.GetResource(product.Details)));
	        }else
	        {
	            writer.Write("<a href='{2}'><img class='smallShip' src='{0}' alt='{1}' title='{1}'/></a>",
	                         ResourcesManager.GetUnitImage(product.Details), product.Details, ManualUtils.GetUrl(RulesUtils.GetResource(product.Details)));
	        }

            writer.Write("</li><li><b>{0}:</b> {1}</li>", LanguageManager.Instance.Get("Quantity"), product.Quantity);
            writer.Write("<li><b>{0}:</b> {1}</li>", LanguageManager.Instance.Get("InitialPrice"), product.Price);
            writer.Write("<li><b>{0}:</b> {1}</li>", LanguageManager.Instance.Get("Buyout"), product.Buyout);
            writer.Write("<li><b>{0}:</b> {1}</li>", LanguageManager.Instance.Get("SellingPrice"), product.CurrentBid);
            writer.Write("<li><b>{0}:</b> <a href='{2}PrincipalInfo.aspx?Principal={3}'>{1}</a></li>",
                LanguageManager.Instance.Get("Owner"), product.Owner.Name, WebUtilities.ApplicationPath, product.Owner.Id);
            writer.Write("<li><b>{0}:</b> {1}</li>", LanguageManager.Instance.Get("PutInAHInDate"), product.CreatedDate);
            writer.Write("<li><b>{0}:</b> ", LanguageManager.Instance.Get("SellDate"));

	        if (product.BuyedInTick <= 0)
	        {
	            writer.Write("-");
	        }
	        else
	        {
	            writer.Write(product.UpdatedDate);
	        }
	        writer.Write("</li></ul>");
	    }

	    private static void WriteBidTable(TextWriter writer, IEnumerable<BidHistorical> historical)
	    {
	        writer.Write("<table class='table'><tbody><tr><th>{0}</th><th>{1}</th><th>{2}</th></tr>",
	                     LanguageManager.Instance.Get("Date"),
	                     LanguageManager.Instance.Get("MadeBy"),
	                     LanguageManager.Instance.Get("Value"));
	        foreach (BidHistorical bidHistorical in historical)
	        {
	            writer.Write("<tr><tr><td>{0}</td><td><a href='{4}PlayerInfo.aspx?PlayerStorage={3}'>{1}</a></td><td>{2}</td></tr>",
	                         bidHistorical.Date, bidHistorical.MadeBy.Name, bidHistorical.Value, bidHistorical.MadeBy.Id, WebUtilities.ApplicationPath);
	        }
	        writer.Write("</tbody></table>");
	    }
    };
}

