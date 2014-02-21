using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class CountryDropDownEditor: InvoiceCountryEditor
    {
        protected DropDownList countriesDropDown = new DropDownList();
        private IList<Country> countries;

        protected override void OnInit(EventArgs args)
        {
            base.OnInit(args);

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
            countriesDropDown.Items.Add(new ListItem("",""));
            foreach (Country country in countries)
            {
                countriesDropDown.Items.Add(new ListItem(LanguageManager.Instance.Get(country.Name),country.Abbreviation));
            }
			Controls.Add(countriesDropDown);
        }

        protected override void Render(HtmlTextWriter writer, Invoice t, int renderCount, bool flipFlop)
        {
            Utils.SetCssClass(countriesDropDown, "styled");

            //countriesDropDown.SelectedIndex = FindIndex(countriesDropDown, t.Country);
            if (string.IsNullOrEmpty(t.Country))
            {
                countriesDropDown.RenderControl(writer);
            }
            else
            {
                writer.Write(GetCountry(countriesDropDown, t.Country));
            }
        }

        public override void Update(Invoice entity)
        {
            if (string.IsNullOrEmpty(entity.Country))
            {
                entity.Country = countriesDropDown.SelectedValue;
            }
        }

        private string GetCountry(ListControl list, string country)
        {
            for (int iter = 0; iter < list.Items.Count; ++iter)
            {
                if (country == list.Items[iter].Value)
                    return list.Items[iter].Text;
            }
            return string.Empty;
        }

        private static int FindIndex(ListControl list, string value)
        {
            for (int iter = 0; iter < list.Items.Count; ++iter)
            {
                if (value == list.Items[iter].Value)
                    return iter;
            }
            return 0;
        }
    }
}
