using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class SpendIdentifier : TransactionIdentityTypeSpend
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
            if (entity.IdentityTypeSpend == TransactionIdentifier.Player.ToString())
            {
                writer.Write(string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2} = {1}</a>",
                WebUtilities.ApplicationPath,entity.IdentifierSpend,entity.IdentityTypeSpend));
                return;
            }
            if (entity.IdentityTypeSpend == TransactionIdentifier.Arena.ToString())
            {
                writer.Write(string.Format("<a href='{0}Arenas/ArenaInfo.aspx?ArenaStorage={1}'>{2} = {1}</a>",
                WebUtilities.ApplicationPath, entity.IdentifierSpend, entity.IdentityTypeSpend));
                return;
            }

            writer.Write(string.Format("{1} = {0}", entity.IdentifierSpend, entity.IdentityTypeSpend));

        }

        #endregion BaseFieldControl<AllianceStorage> Implementatio
    }
}
