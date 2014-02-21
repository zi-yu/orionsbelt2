using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ViewArena : ArenaStorageName
    {
        #region BaseFieldControl<ArenaStorage> Implementation

        protected override void Render(HtmlTextWriter writer, ArenaStorage entity, int renderCount, bool flipFlop)
        {
            writer.Write("<div class='buttonSmall'><a href='ArenaInfo.aspx?ArenaStorage={0}'>{1}</a></div>", entity.Id, LanguageManager.Localize("ShowArena"));
        }

        #endregion BaseFieldControl<ArenaStorage> Implementatio
    }
}
