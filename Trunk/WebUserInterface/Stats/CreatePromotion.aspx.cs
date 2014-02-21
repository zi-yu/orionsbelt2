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
    public partial class CreatePromotion : Page
    {

		protected override void OnInit(EventArgs e) {
            generate.Text = LanguageManager.Instance.Get("Create");
            beginEndDate.Text = LanguageManager.Instance.Get("BeginEndDate");
            endValidator.Text = LanguageManager.Instance.Get("EndDateHigherToday");
            revValidator.Text = LanguageManager.Instance.Get("NumericValue");
            beginValidator.Text = LanguageManager.Instance.Get("NumericValue");
            endRValidator.Text = LanguageManager.Instance.Get("NumericValue");
            codeValidator.Text = LanguageManager.Instance.Get("NumericValue");
            bonusNValidator.Text = LanguageManager.Instance.Get("NumericValue");

            foreach (RevenueType elem in Enum.GetValues(typeof(RevenueType)))
            {
                revenueType.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
            }
            foreach (PromotionType elem in Enum.GetValues(typeof(PromotionType)))
            {
                promotionType.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
            }
            foreach (BonusType elem in Enum.GetValues(typeof(BonusType)))
            {
                bonusType.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
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
                double rev = 0;
                int bRange = 0;
                int eRange = 0;
                int pCode = 0;
                int bonus = 0;
                if (!string.IsNullOrEmpty(revenueValue.Text))
                {
                    rev = Convert.ToDouble(revenueValue.Text);
                }
                if (!string.IsNullOrEmpty(beginRange.Text))
                {
                    bRange = Convert.ToInt32(beginRange.Text);
                }
                if (!string.IsNullOrEmpty(endRange.Text))
                {
                    eRange = Convert.ToInt32(endRange.Text);
                }
                if (!string.IsNullOrEmpty(promotionCode.Text))
                {
                    pCode = Convert.ToInt32(promotionCode.Text);
                }
                if (!string.IsNullOrEmpty(bonusValue.Text))
                {
                    bonus = Convert.ToInt32(bonusValue.Text);
                }
                bool result = PromotionUtil.CreatePromotion(finder.GetSelectedPlayerId(), name.Text, begin.GetDate(), end.GetDate(),
                                              revenueType.SelectedValue, rev,
                                              promotionType.SelectedValue, bRange,
                                              eRange, pCode, bonusType.SelectedValue, bonus, description.Text);

                if(result)
                {
                    InformationBoard.AddLocalizedMessage("Ok");
                }
                else
                {
                    ErrorBoard.AddLocalizedMessage("InvalidRequest");
                }
            }
		}
	}
}
