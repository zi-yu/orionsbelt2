using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class AvailableQuantity : ProductQuantity
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
            if(0 != entity.Quantity)
            {
                writer.Write(entity.Quantity);
            }else
            {
                writer.Write(LanguageManager.Instance.Get("Unlimited"));
            }
        }

        #endregion BaseFieldControl<Product> Implementatio
    }
}
