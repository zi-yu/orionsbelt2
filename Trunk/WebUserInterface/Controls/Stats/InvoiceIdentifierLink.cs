using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class InvoiceIdentifierLink : InvoiceMoney
    {
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
            writer.Write(string.Format("<a href='{0}Account/Invoice.aspx?Invoice={1}'>{2}</a>",
                                           WebUtilities.ApplicationPath, entity.Id, entity.Identifier));
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
