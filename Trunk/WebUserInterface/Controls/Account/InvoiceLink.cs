using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class InvoiceLink : PaymentInvoice
    {
        #region BaseFieldControl<Product> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Payment entity, int renderCount, bool flipFlop)
        {
        
            if(entity.Invoice.Count > 0)
            {
                writer.Write("<a href='Invoice.aspx?Invoice={0}'>{1}</a>", 
                    entity.Invoice[0].Id,LanguageManager.Instance.Get("Invoice"));
            }
        }

        #endregion BaseFieldControl<Product> Implementatio
    }
}
