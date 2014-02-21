using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class LinkedPrincipalName : BaseFieldControl<Principal>, INamingContainer
    {
        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Principal entity, int renderCount, bool flipFlop)
        {
            if (0 < entity.Player.Count)
            {
                writer.Write(string.Format("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a>",
                                           WebUtilities.ApplicationPath, entity.Id, entity.Name));
            }else
            {
                writer.Write(string.Format(entity.Name));
            }
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
