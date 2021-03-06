using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class InvoiceWithoutTaxMoney : InvoiceMoney
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
            double iva = Convert.ToDouble(ConfigurationManager.AppSettings["iva"])/100;
            double value = 0;
            if(entity.Country == "PT")
            {
                value = entity.Money - entity.Money * iva;
            }

            writer.Write("{0} �",value);
            
        }

        #endregion BaseFieldControl<Product> Implementatio
    }
}
