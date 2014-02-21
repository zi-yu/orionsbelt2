using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class EarningIdentifier : TransactionIdentityTypeSpend
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
            if (entity.IdentityTypeGain == TransactionIdentifier.Player.ToString())
            {
                writer.Write(string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2} = {1}</a>",
                WebUtilities.ApplicationPath,entity.IdentifierGain,entity.IdentityTypeGain));
                return;
            }

            if (entity.IdentityTypeGain == TransactionIdentifier.Principal.ToString())
            {
                writer.Write(string.Format("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2} = {1}</a>",
                WebUtilities.ApplicationPath, entity.IdentifierGain, entity.IdentityTypeGain));
                return;
            }
            if (entity.IdentityTypeGain == TransactionIdentifier.Arena.ToString())
            {
                writer.Write(string.Format("<a href='{0}Arenas/ArenaInfo.aspx?ArenaStorage={1}'>{2} = {1}</a>",
                WebUtilities.ApplicationPath,entity.IdentifierGain,entity.IdentityTypeGain));
                return;
            }
            if (entity.TransactionContext == TransactionContext.Market.ToString())
            {
                writer.Write(string.Format("<a href='{0}MarketView.aspx?Market={1}'>{2} = {1}</a>",
                WebUtilities.ApplicationPath, entity.IdentifierGain, entity.IdentityTypeGain));
                return;
            }

            writer.Write(string.Format("{1} = {0}", entity.IdentifierGain, entity.IdentityTypeGain));
        }

        #endregion BaseFieldControl<AllianceStorage> Implementatio
    }
}
