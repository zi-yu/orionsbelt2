using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class InteractionRemove : InteractionDelete
    {
        /// <summary>
        /// Renders an Interaction delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The Interaction instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Interaction entity, int renderCount, bool flipFlop)
        {
            writer.Write("<a href='javascript:DeleteInteraction({0})'><img src='{1}' alt='delete' title='delete'></a>", 
                entity.Id.ToString(),ResourcesManager.GetImage("Error.gif"));
        }
    }
}
