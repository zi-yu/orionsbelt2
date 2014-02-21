using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ArenaName : ArenaStorageName
    {
        #region BaseFieldControl<ArenaStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, ArenaStorage entity, int renderCount, bool flipFlop)
        {
            writer.Write(entity.Name);
        }

        #endregion BaseFieldControl<ArenaStorage> Implementatio
    }
}
