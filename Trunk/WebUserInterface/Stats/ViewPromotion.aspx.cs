using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface {

    public class ViewPromotion : Page 
    {
        protected PromotionOwnerSort sortOwner;
        protected PromotionBeginDateSort sortBeginDate;
        protected PromotionEndDateSort sortEndDate;
        protected PromotionNameSort sortName;
        protected PromotionRevenueSort sortRevenue;
        protected PromotionRevenueTypeSort sortRevenueType;
        protected PromotionPromotionTypeSort sortPromotionType;
        protected PromotionRangeBeginSort sortRangeBegin;
        protected PromotionRangeEndSort sortRangeEnd;
        protected PromotionPromotionCodeSort sortPromotionCode;
        protected PromotionBonusTypeSort sortBonusType;
        protected PromotionBonusSort sortBonus;
        protected PromotionStatusSort sortStatus;
        protected PromotionUsesSort sortUses;
        protected PromotionDescriptionSort sortDescription;
        protected Button filter;
        protected PromotionPagedList paged;
	    protected InvoiceCreatedDateEditor begin;
        protected InvoiceUpdatedDateEditor end;
	    protected Literal groupTable;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Hql.Query<Promotion>("from SpecializedInvoice a inner join fetch a.PaymentNHibernate", null);
            sortOwner.InnerHTML = LanguageManager.Instance.Get("Owner");
            sortBeginDate.InnerHTML = LanguageManager.Instance.Get("BeginDate");
            sortEndDate.InnerHTML = LanguageManager.Instance.Get("EndDate");
            sortName.InnerHTML = LanguageManager.Instance.Get("Name");
            sortRevenue.InnerHTML = LanguageManager.Instance.Get("Revenue");
            sortRevenueType.InnerHTML = LanguageManager.Instance.Get("RevenueType");
            sortPromotionType.InnerHTML = LanguageManager.Instance.Get("PromotionType");
            sortRangeBegin.InnerHTML = LanguageManager.Instance.Get("BeginRange");
            sortRangeEnd.InnerHTML = LanguageManager.Instance.Get("EndRange");
            sortPromotionCode.InnerHTML = LanguageManager.Instance.Get("PromotionCode");
            sortBonusType.InnerHTML = LanguageManager.Instance.Get("BonusType");
            sortBonus.InnerHTML = LanguageManager.Instance.Get("Bonus");
            sortStatus.InnerHTML = LanguageManager.Instance.Get("Status");
            sortDescription.InnerHTML = LanguageManager.Instance.Get("Description");
            sortUses.InnerHTML = LanguageManager.Instance.Get("Uses");
            /*
            filter.Text = LanguageManager.Instance.Get("Search");
            
            if(end.GetSelectedDate() > new DateTime(1900,1,1).Date)
            {
                paged.Where = string.Format("e.CreatedDate >='{0}' and e.CreatedDate <='{1}'",
                    begin.GetSelectedDate().ToString("yyyy-MM-dd"), end.GetSelectedDate().ToString("yyyy-MM-dd"));
                State.SetMemory("InvoiceDateFilter", paged.Where);
                State.SetMemory("InvoiceBeginDate", begin.GetSelectedDate());
                State.SetMemory("InvoiceEndDate", end.GetSelectedDate());
                end.SetSelectedDate(end.GetSelectedDate());
                begin.SetSelectedDate(begin.GetSelectedDate());
            }
            else
            {
                if (State.InMemory("InvoiceDateFilter"))
                {
                    paged.Where = State.GetFromMemory("InvoiceDateFilter").ToString();
                    end.SetSelectedDate((DateTime)State.GetFromMemory("InvoiceEndDate"));
                    begin.SetSelectedDate((DateTime)State.GetFromMemory("InvoiceBeginDate"));
                }
            }

            IList<Country> countries;
            if (State.HasCache("CountriesTable"))
            {
                countries = (IList<Country>)State.GetCache("CountriesTable");
            }
            else
            {
                using (ICountryPersistance persistance = Persistance.Instance.GetCountryPersistance())
                {
                    countries = persistance.Select();
                    State.SetCache("CountriesTable", countries);
                }
            }
            */
            //groupTable.Text = InvoiceUtils.GetCountriesHtml(paged.Where, countries, Convert.ToDouble(ConfigurationManager.AppSettings["iva"]) / 100);
        }


        protected void Filter(object sender, EventArgs e)
        {
            

        }
    }
}
