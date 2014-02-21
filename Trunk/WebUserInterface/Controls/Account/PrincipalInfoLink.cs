using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Core;
using System.IO;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls {

	public class PrincipalInfoLink: BaseFieldControl<Principal> {

        #region Events

        protected override void Render(HtmlTextWriter writer, Principal t, int renderCount, bool flipFlop)
        {
            writer.Write("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a>", WebUtilities.ApplicationPath, t.Id, t.Name);
        }

        #endregion Events

    };
}

