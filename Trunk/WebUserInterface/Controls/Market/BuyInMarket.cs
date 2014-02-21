using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class BuyInMarket : BaseFieldControl<Product>, INamingContainer
    {
        #region BaseFieldControl<Product> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Product entity, int renderCount, bool flipFlop)
        {

			writer.Write("<input type='text' name='{0}' value='0'/><input type='submit' class='buttonSmall' name='b_{0}' value='{1}'/><div>{2}:<div>0</div></div>", 
                entity.Name, LanguageManager.Instance.Get("Buy"), LanguageManager.Instance.Get("BuyingQuantity"));

        }

        #endregion BaseFieldControl<Product> Implementatio
    }
}
