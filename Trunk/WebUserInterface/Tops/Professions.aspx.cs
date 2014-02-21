using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using System;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.WebUserInterface.Controls.Auction_House;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface {

	public class Professions: Page 
    {
	    protected Literal header;
        protected PlayerStoragePagedList paged;
	    private long count;

        protected override void OnInit(EventArgs e)
        { 
            base.OnInit(e);
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                count = persistance.GetCount();
            }
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string id = HttpContext.Current.Request.QueryString["page"];
            int page;
            Int32.TryParse(id, out page);

            if (0 == page)
            {
                page = 1;
            }

            string prop = HttpContext.Current.Request.QueryString["sort"];

            if (string.IsNullOrEmpty(prop)){
                prop = "PirateRanking";
            }

            //BuildPagination(prop);

            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                paged.Collection = persistance.Select((page-1) * paged.ItemsPerPage, paged.ItemsPerPage, prop, false);
            }

            StringBuilder sb = new StringBuilder();

            WriteColumn(sb,page,"PirateRanking");
            WriteColumn(sb,page,"BountyRanking");
            WriteColumn(sb,page,"MerchantRanking");
            WriteColumn(sb,page,"ColonizerRanking");
            WriteColumn(sb,page,"GladiatorRanking");

            header.Text = sb.ToString();
        }

        private static void WriteColumn(StringBuilder writer, int page, string column)
        {
            
            writer.Append(string.Format("<th><a href='{0}?page={1}&sort={3}'>{2}</a></th>",
                         HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get(column), column));
        }

	    private void BuildPagination(string prop)
	    {
	        TextWriter writer = new StringWriter();
	        double numberOfPages = Math.Ceiling((double)count / paged.ItemsPerPage);

	        WebUtilities.RenderPages(writer, numberOfPages, "&sort=" + prop);
	        //pagination.Text = writer.ToString();
	    }
    }
}
