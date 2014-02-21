using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PromotionNameWithLink : PromotionName
    {
        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Promotion entity, int renderCount, bool flipFlop)
        {
            writer.Write(string.Format("<a href='{0}Stats/UpdatePromotion.aspx?Promotion={1}'>{2}</a>",
                                           WebUtilities.ApplicationPath, entity.Id, entity.Name));
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
