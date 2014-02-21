using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    /// <summary>
    /// Renders in XHTML the content of a ArenaStorage's Payment
    /// </summary>
    public class ArenaStoragePayment : BaseFieldControl<ArenaStorage>, INamingContainer {

        #region BaseFieldControl<ArenaStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, ArenaStorage entity, int renderCount, bool flipFlop) {
            writer.Write("{0}  <img src='{1}' alt='Orions' Title='Orions'/>", entity.Payment, ResourcesManager.GetImage("Icons/Orions.png"));
        }

        #endregion BaseFieldControl<ArenaStorage> Implementation

    };
}
