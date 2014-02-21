using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PrincipalYou : BaseFieldControl<Principal>, INamingContainer {
        #region BaseFieldControl<LadderInfo> Implementation


        protected override void Render(HtmlTextWriter writer, Principal entity, int renderCount, bool flipFlop) {
            if (entity.Id == Utils.Principal.Id) {
                writer.Write(" class='my' ");
            }
        }

        #endregion BaseFieldControl<LadderInfo> Implementatio
    }
}
