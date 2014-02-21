using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface {

    public class AddToAuction : Page 
    {
        protected DropDownList resources,times;
        protected CheckBox advertise;
        protected Button send;
        protected RequiredFieldValidator quantityRequired, bidRequired;
        protected RegularExpressionValidator quantityValidator, bidValidator, buyoutValidator;
        protected TextBox quantity, bid, buyout;
        protected CustomValidator invalidQuantity, invalidBid, invalidBuyout, invalidAdvertising;
        protected CompareValidator buyBidValidator;
        private Dictionary<string, int> playerResources;
        protected Literal condition;
        private string selectedResource;

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            send.Text = LanguageManager.Instance.Get("Send");
            quantityRequired.Text = LanguageManager.Instance.Get("NotEmpty");
            bidRequired.Text = LanguageManager.Instance.Get("NotEmpty");
            quantityValidator.Text = LanguageManager.Instance.Get("NumericValue");
            bidValidator.Text = LanguageManager.Instance.Get("NumericValue");
            buyoutValidator.Text = LanguageManager.Instance.Get("NumericValue");
            invalidBuyout.Text = LanguageManager.Instance.Get("BuyBidValidator");
            invalidBid.Text = LanguageManager.Instance.Get("BidValidator");
            invalidAdvertising.Text = LanguageManager.Instance.Get("AdvertisingValidator");

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

            bool haveBattles = HaveHomeBattles();
            GetResources(!haveBattles);

            if(haveBattles)
            {
                condition.Text = string.Format("<br/><span class='red'>{0}</span>", LanguageManager.Instance.Get("CantPutRares"));
            }

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

            if(!AuctionHouseUtil.ValidatePlayers(PlayerUtils.Current.Storage))
            {
                ErrorBoard.AddLocalizedMessage("SamePlayer3Days");
                return;
            }

            int ticks = (Clock.Instance.ConvertToTicks(TimeSpan.FromDays(Convert.ToDouble(times.SelectedValue))));
            IResourceInfo info = RulesUtils.GetResource(selectedResource);
            IAuctionItem item = new AuctionItem(info, Convert.ToInt32(quantity.Text), Convert.ToInt32(bid.Text),
                                                      buyValue, PlayerUtils.Current.Storage, ticks);
            AuctionHouseUtil.PutInAuction(item, PlayerUtils.Current.GetHomePlanet().DefenseFleet,false, advertise.Checked);
            InformationBoard.AddLocalizedMessage("Ok");
        }

        protected void ValidateQuantity(object source, ServerValidateEventArgs args)
        {
            int limit = playerResources[selectedResource];
            invalidQuantity.Text = string.Format(Resources.CantBeHigherThanToken, limit);
            args.IsValid = (Convert.ToInt32(quantity.Text) <= limit);

        }

        protected void ValidateBuyout(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Convert.ToInt32(bid.Text) < Convert.ToInt32(buyout.Text));
        }

        protected void ValidateBid(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Convert.ToInt32(bid.Text) > 1);
        }

        protected void ValidateAdvertising(object source, ServerValidateEventArgs args)
        {
            if (advertise.Checked)
            {
                args.IsValid = (Utils.Principal.Credits > 20);
            }
        }

        #endregion Events

        #region Private Methods

        private static bool HaveHomeBattles()
        {
            using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance())
            {
                long count = persistance.ExecuteScalar("select count(s) from SpecializedSectorStorage s where s.OwnerNHibernate.Id={0} and s.IsInBattle = 1 and s.Type='PlanetBattleSector'", PlayerUtils.Current.Id);
                return count != 0;
            }
        }

        private void GetUnits()
        {
            IPlanet planet = PlayerUtils.Current.GetHomePlanet();
            foreach (KeyValuePair<string, IFleetElement> unit in planet.DefenseFleet.Units)
            {
                resources.Items.Add(new ListItem(LanguageManager.Instance.Get(unit.Value.Name), unit.Value.Name));
                playerResources.Add(unit.Value.Name, unit.Value.Quantity);
            }
        }

        private void GetResources(bool putRares)
        {
            IEnumerable<KeyValuePair<IResourceInfo,int>> res = ResourceUtils.GetAuctionHouseResources(PlayerUtils.Current);
            foreach (KeyValuePair<IResourceInfo, int> resource in res)
            {
                if ((!putRares && resource.Key.IsRare) /*|| resource.Key.Races == RaceUtils.Mercs*/)
                {
                    continue;
                }
                if (resource.Value > 0)
                {
                    resources.Items.Add(new ListItem(LanguageManager.Instance.Get(resource.Key.Name), resource.Key.Name));
                }
                playerResources.Add(resource.Key.Name, resource.Value);
            }
        }

        #endregion Private Methods
    }
}
