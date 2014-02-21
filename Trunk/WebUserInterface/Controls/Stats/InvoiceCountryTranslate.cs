using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class InvoiceCountryTranslate : InvoiceCountry
    {
        private IList<Country> countries;

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
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
        }
        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Invoice entity, int renderCount, bool flipFlop)
        {
            writer.Write("{0}", GetCountry(entity.Country));
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio

        private string GetCountry(string code)
        {
            foreach (Country country in countries)
            {
                if (country.Abbreviation == code)
                {
                    return LanguageManager.Instance.Get(country.Name);
                }
            }
            return code;
        }
    }
}
