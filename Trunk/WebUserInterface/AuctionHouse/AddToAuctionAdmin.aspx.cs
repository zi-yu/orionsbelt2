using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {

    public class AddToAuctionAdmin : Page 
    {
        protected Literal message;
        protected DropDownList resources,times;
        protected Button send;
        protected RequiredFieldValidator quantityRequired, bidRequired;
        protected RegularExpressionValidator quantityValidator, bidValidator, buyoutValidator;
        protected TextBox quantity, bid, buyout;
        protected CustomValidator invalidBid, invalidBuyout;
        protected CompareValidator buyBidValidator;
        private Dictionary<string, int> playerResources;
        private string selectedResource;

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            send.Text = LanguageManager.Instance.Get("Send");
            quantityRequired.Text = LanguageManager.Instance.Get("NotEmpty");
            bidRequired.Text = LanguageManager.Instance.Get("NotEmpty");
            bidValidator.Text = LanguageManager.Instance.Get("NumericValue");
            buyoutValidator.Text = LanguageManager.Instance.Get("NumericValue");
            invalidBuyout.Text = LanguageManager.Instance.Get("BuyBidValidator");
            invalidBid.Text = LanguageManager.Instance.Get("BidValidator");

            times.Items.Add(new ListItem(LanguageManager.Instance.Get("Day1"), "1"));
            times.Items.Add(new ListItem(LanguageManager.Instance.Get("Day3"), "3"));
            times.Items.Add(new ListItem(LanguageManager.Instance.Get("Day7"), "7"));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            playerResources = new Dictionary<string, int>();
            selectedResource = resources.SelectedValue;
            resources.Items.Clear();
            GetResources();
            GetUnits();

            foreach (KeyValuePair<string, int> pair in playerResources)
            {
                if(pair.Key == selectedResource)
                {
                    resources.SelectedValue = selectedResource;
                    break;
                }
            }
        }

        protected void Send(object sender, EventArgs e)
        {
            if(!Page.IsValid)
            {
                return;
            }
            int buyValue = 0;
            if(!string.IsNullOrEmpty(buyout.Text))
            {
                buyValue = Convert.ToInt32(buyout.Text);
            }
            int ticks = (Clock.Instance.ConvertToTicks(TimeSpan.FromDays(Convert.ToDouble(times.SelectedValue))));
            IResourceInfo info = RulesUtils.GetResource(selectedResource);
            IAuctionItem item = new AuctionItem(info, Convert.ToInt32(quantity.Text), Convert.ToInt32(bid.Text),
                                                      buyValue, PlayerUtils.Current.Storage, ticks);
            AuctionHouseUtil.PutInAuction(item, PlayerUtils.Current.GetHomePlanet().DefenseFleet,true, false);
            message.Text = LanguageManager.Instance.Get("Ok");
        }

        protected void ValidateBuyout(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Convert.ToInt32(bid.Text) < Convert.ToInt32(buyout.Text));
        }

        protected void ValidateBid(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Convert.ToInt32(bid.Text) > 1);
        }

        #endregion Events

        #region Private Methods

        private void GetUnits()
        {
            IList<IUnitInfo> res = RulesUtils.GetUnitResources();
            foreach (IUnitInfo unit in res)
            {
                resources.Items.Add(unit.Name);
            }
        }

        private void GetResources()
        {
            IList<IIntrinsicInfo> res = RulesUtils.GetIntrinsicResources();
            foreach (IIntrinsicInfo unit in res)
            {
                resources.Items.Add(unit.Name);
            }
        }

        #endregion Private Methods
    }
}
