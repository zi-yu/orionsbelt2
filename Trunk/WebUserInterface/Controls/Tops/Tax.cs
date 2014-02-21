using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class Tax : TransactionIdentityTypeSpend
    {
        #region BaseFieldControl<AllianceStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Transaction entity, int renderCount, bool flipFlop)
        {           
            writer.Write(entity.CreditsSpend - entity.CreditsGain);
        }

        #endregion BaseFieldControl<AllianceStorage> Implementatio
    }
}
