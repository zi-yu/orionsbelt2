using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface {

    public class AddToStorehouse : Page 
    {
        protected DropDownList resources;
        protected Button send;
        protected RequiredFieldValidator quantityRequired;
        protected RegularExpressionValidator quantityValidator;
        protected TextBox quantity;
        protected CustomValidator invalidQuantity;
        private Dictionary<string, int> playerResources;
        protected Literal condition, link;
        private string selectedResource;

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            link.Text = string.Format("<a href='AddToStorehouse.aspx?Id={0}'>{1}</a>", PlayerUtils.Current.Alliance.Storage.Id,
                    LanguageManager.Instance.Get("Deposit"));
            send.Text = LanguageManager.Instance.Get("Send");
            quantityRequired.Text = LanguageManager.Instance.Get("NotEmpty");
            quantityValidator.Text = LanguageManager.Instance.Get("NumericValue");

            AllianceMenu.CurrentPage = "Storehouse";
       }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AllianceWebUtils.AssertCurrentPlayerBelongsToCurrentAlliance();

            playerResources = new Dictionary<string, int>();
            selectedResource = resources.SelectedValue;
            resources.Items.Clear();

            bool haveBattles = HaveHomeBattles();
            GetResources(!haveBattles);

            if(haveBattles)
            {
                condition.Text = string.Format("<br/><span class='red'>{0}</span>", LanguageManager.Instance.Get("CantDepositRares"));
            }

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

            if(!AuctionHouseUtil.ValidatePlayers(PlayerUtils.Current.Storage))
            {
                ErrorBoard.AddLocalizedMessage("SamePlayer3Days");
                return;
            }
            using (IOfferingPersistance persistance = Persistance.Instance.GetOfferingPersistance())
            {
                Offering offer = persistance.Create();
                offer.CurrentValue = Convert.ToInt32(Convert.ToInt32(quantity.Text)*0.9);
                offer.InitialValue = offer.CurrentValue;
                offer.Donor = PlayerUtils.Current.Storage;
                offer.Alliance = PlayerUtils.Current.Alliance.Storage;
                offer.Product = resources.SelectedValue;
                persistance.Update(offer);

                PlayerUtils.Current.RemoveQuantity(RulesUtils.GetResource(resources.SelectedValue),
                                                   Convert.ToInt32(quantity.Text));
                GameEngine.Persist(PlayerUtils.Current);
            }
            InformationBoard.AddLocalizedMessage("Ok");
        }

        protected void ValidateQuantity(object source, ServerValidateEventArgs args)
        {
            int limit = playerResources[selectedResource];
            invalidQuantity.Text = string.Format(Resources.CantBeHigherThanToken, limit);
            args.IsValid = (Convert.ToInt32(quantity.Text) <= limit);

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
