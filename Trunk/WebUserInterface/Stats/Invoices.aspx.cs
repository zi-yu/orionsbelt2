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

	public class InvoicesPage: Page 
    {
	    protected InvoiceMoneySort sortMoney;
	    protected InvoiceCreatedDateSort sortDate;
        protected InvoiceNifSort sortNif;
        protected Button filter;
	    protected InvoicePagedList paged;
	    protected InvoiceCreatedDateEditor begin;
        protected InvoiceUpdatedDateEditor end;
	    protected InvoiceCountrySort invoiceCountrySort;
	    protected Literal groupTable;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Hql.Query<Invoice>("from SpecializedInvoice a inner join fetch a.PaymentNHibernate",null);

            sortMoney.InnerHTML = LanguageManager.Instance.Get("Money");
            sortDate.InnerHTML = LanguageManager.Instance.Get("Date");
            sortNif.InnerHTML = LanguageManager.Instance.Get("Nif");
            invoiceCountrySort.InnerHTML = LanguageManager.Instance.Get("Country");

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

            //groupTable.Text = InvoiceUtils.GetCountriesHtml(paged.Where, countries, Convert.ToDouble(ConfigurationManager.AppSettings["iva"]) / 100);
        }


        protected void Filter(object sender, EventArgs e)
        {
            

        }
    }
}
