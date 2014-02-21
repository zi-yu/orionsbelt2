using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class BonusCardPrincipal : BaseFieldControl<BonusCard>, INamingContainer
    {

        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, BonusCard entity, int renderCount, bool flipFlop)
        {
            if (entity.UsedBy != null)
            {
                writer.Write("<a href='{0}PrincipalInfo.aspx?Principal={2}'>{1}</a>", WebUtilities.ApplicationPath,
                             entity.UsedBy,entity.UsedBy.Id);
            }

        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
