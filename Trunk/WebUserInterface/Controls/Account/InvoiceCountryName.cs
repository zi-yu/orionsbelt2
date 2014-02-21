using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.Engine.MarketPlace;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class InvoiceCountryName : InvoiceCountry
    {
        #region BaseFieldControl<Product> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Invoice entity, int renderCount, bool flipFlop)
        { 
            if(!string.IsNullOrEmpty(entity.Country))
            {
                writer.Write(LanguageManager.Instance.Get(InvoiceUtils.GetCountry(entity.Country).Name));   
            }
                
        }

        #endregion BaseFieldControl<Product> Implementatio
    }
}
