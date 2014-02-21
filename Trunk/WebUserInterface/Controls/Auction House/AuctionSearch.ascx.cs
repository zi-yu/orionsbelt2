using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using OrionsBelt.RulesCore;

namespace OrionsBelt.WebUserInterface.Controls.Auction_House
{
    public partial class AuctionSearch : System.Web.UI.UserControl {
        public string Where
        {
            get {
                StringWriter sw = new StringWriter(); 
                string arg = HttpContext.Current.Request.Form[until.UniqueID];
                int aux;
                if (!string.IsNullOrEmpty(arg) && Int32.TryParse(arg, out aux))
                {
                    sw.Write(" and CurrentBid<{0} ", arg);
                }

                arg = HttpContext.Current.Request.Form[until2.UniqueID];
                if (!string.IsNullOrEmpty(arg) && Int32.TryParse(arg, out aux))
                {
                    sw.Write(" and Buyout<{0} ", arg);
                }

                arg = HttpContext.Current.Request.Form[typeRes.BrowserID];
                if (!string.IsNullOrEmpty(arg))
                {
                    sw.Write(" and Details='{0}' ", arg);
                }

                arg = HttpContext.Current.Request.Form[groupType.BrowserID];
                if (!string.IsNullOrEmpty(arg))
                {
                    sw.Write(" and ({0} & ComplexNumber)<>0", arg);
                }

                arg = HttpContext.Current.Request.Form[raceChooser.UniqueID];
                if (!string.IsNullOrEmpty(arg))
                {
                    sw.Write(" and ({0} & ComplexNumber)<>0", arg);
                }

                return sw.ToString(); 
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterHiddenField("searchChange", "");
            filter.Text = LanguageManager.Instance.Get("Search");
            untilValidator.Text = LanguageManager.Instance.Get("NumericValue");
            until2Validator.Text = LanguageManager.Instance.Get("NumericValue");
            raceChooser.Items.Add(new ListItem("",""));
            raceChooser.Items.Add(new ListItem(LanguageManager.Instance.Get("Bugs"), "512"));
            raceChooser.Items.Add(new ListItem(LanguageManager.Instance.Get("DarkHumans"), "256"));
            raceChooser.Items.Add(new ListItem(LanguageManager.Instance.Get("Humans"), "128"));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string arg = HttpContext.Current.Request.Form["searchChange"];

            if (arg != "1" && null != State.Session["AuctionSearchBid"])
            {
                until.Text = State.Session["AuctionSearchBid"].ToString();
                until2.Text = State.Session["AuctionSearchBuyout"].ToString();
                raceChooser.SelectedValue = State.Session["AuctionSearchRace"].ToString();
            }
        }

        protected void Filter(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                State.Session["AuctionSearchBid"] = until.Text;
                State.Session["AuctionSearchBuyout"] = until2.Text;
                State.Session["AuctionSearchRace"] = raceChooser.SelectedValue;
                State.Session["AuctionSearchResource"] = HttpContext.Current.Request.Form[typeRes.BrowserID];
                State.Session["AuctionSearchResourceGroup"] = HttpContext.Current.Request.Form[groupType.BrowserID];
            }
        }
    }
}