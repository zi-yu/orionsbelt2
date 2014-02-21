using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ArenaType : ArenaStorageBattleType
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
            writer.Write("{0}",LanguageManager.Instance.Get(entity.BattleType));
        }

        #endregion BaseFieldControl<ArenaStorage> Implementatio
    }
}
