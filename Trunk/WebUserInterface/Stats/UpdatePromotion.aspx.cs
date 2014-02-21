using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface {
    public partial class UpdatePromotion : Page
    {
        private Promotion promotion;

        protected override void OnLoad(EventArgs e)
        {

        }
		protected override void OnInit(EventArgs e) {
            generate.Text = LanguageManager.Instance.Get("Update");
            beginEndDate.Text = LanguageManager.Instance.Get("BeginEndDate");
            endValidator.Text = LanguageManager.Instance.Get("EndDateHigherToday");
            revValidator.Text = LanguageManager.Instance.Get("NumericValue");
            beginValidator.Text = LanguageManager.Instance.Get("NumericValue");
            endRValidator.Text = LanguageManager.Instance.Get("NumericValue");
            codeValidator.Text = LanguageManager.Instance.Get("NumericValue");
            bonusNValidator.Text = LanguageManager.Instance.Get("NumericValue");

            promotion = EntityUtils.GetFromQueryString<Promotion>();

            InitDrops();

		    name.Text = promotion.Name;
            description.Text = promotion.Description;
            if (promotion.Owner != null)
            {
                finder.SetValue(promotion.Owner.Id, promotion.Owner.Name);
            }
		    begin.SetDate(promotion.BeginDate);
            end.SetDate(promotion.EndDate);
		    revenueValue.Text = promotion.Revenue.ToString();
            beginRange.Text = promotion.RangeBegin.ToString();
            endRange.Text = promotion.RangeEnd.ToString();
            promotionCode.Text = promotion.PromotionCode.ToString();
            bonusValue.Text = promotion.Bonus.ToString();
		}

        private void InitDrops()
        {
            int counter = 0;
            int index = 0;
            foreach (RevenueType elem in Enum.GetValues(typeof(RevenueType)))
            {
                if (promotion.RevenueType == elem.ToString())
                {
                    index = counter;
                }
                
                revenueType.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
                ++counter;
            }
            revenueType.SelectedIndex = index;

            counter = 0;
            index = 0;
            foreach (PromotionType elem in Enum.GetValues(typeof(PromotionType)))
            {
                if (promotion.PromotionType == elem.ToString())
                {
                    index = counter;
                }
                promotionType.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
                
                ++counter;
            }
            promotionType.SelectedIndex = index;

            counter = 0;
            index = 0;
            foreach (BonusType elem in Enum.GetValues(typeof(BonusType)))
            {
                if (promotion.BonusType == elem.ToString())
                {
                    index = counter;
                }

                bonusType.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
                ++counter;
            }
            bonusType.SelectedIndex = index;

            status.Items.Add(new ListItem(LanguageManager.Instance.Get(promotion.Status), promotion.Status));
            if(promotion.Status != "Cancelled")
            {
                status.Items.Add(new ListItem(LanguageManager.Instance.Get("Cancelled"), "Cancelled"));
            }
        }

        protected void ValidateBeginEnd(object source, ServerValidateEventArgs args)
        {
            args.IsValid = begin.GetDate() <= end.GetDate();
        }

        protected void ValidateEndDate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = DateTime.Now <= end.GetDate();
        }

		protected void Generate(object sender, EventArgs e) {
            if (Page.IsValid)
            {
                
                if (!string.IsNullOrEmpty(revenueValue.Text))
                {
                    promotion.Revenue = Convert.ToDouble(revenueValue.Text);
                }
                if (!string.IsNullOrEmpty(beginRange.Text))
                {
                    promotion.RangeBegin = Convert.ToInt32(beginRange.Text);
                }
                if (!string.IsNullOrEmpty(endRange.Text))
                {
                    promotion.RangeEnd = Convert.ToInt32(endRange.Text);
                }
                if (!string.IsNullOrEmpty(promotionCode.Text))
                {
                    promotion.PromotionCode = Convert.ToInt32(promotionCode.Text);
                }
                if (!string.IsNullOrEmpty(bonusValue.Text))
                {
                    promotion.Bonus = Convert.ToInt32(bonusValue.Text);
                }
                promotion.Name = name.Text;
                promotion.BeginDate = begin.GetDate();
                promotion.EndDate = end.GetDate();
                promotion.RevenueType = revenueType.SelectedValue;
                promotion.PromotionType = promotionType.SelectedValue;
                promotion.BonusType = bonusType.SelectedValue;
                promotion.Description = description.Text;
                promotion.Status = status.SelectedValue;

                int newId = finder.GetSelectedPlayerId();

                if ((promotion.Owner == null && newId != 0) || (promotion.Owner != null && newId != promotion.Owner.Id))
                {
                    using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                    {
                        promotion.Owner = persistance.SelectById(newId)[0];
                    }
                }

                using (IPromotionPersistance persistance = Persistance.Instance.GetPromotionPersistance())
                {
                    persistance.Update(promotion);
                    persistance.Flush();
                }
                InformationBoard.AddLocalizedMessage("Ok");
            
            }
		}
	}
}
