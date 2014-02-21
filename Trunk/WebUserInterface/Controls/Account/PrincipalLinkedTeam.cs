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

    public class PrincipalLinkedTeam : PrincipalTeam
    {

        #region Events

        protected override void Render(HtmlTextWriter writer, Principal t, int renderCount, bool flipFlop)
        {
            if (null != t.Team)
            {
                writer.Write("<a href='{0}Tournaments/Team.aspx?TeamStorage={1}'>{2}</a>", WebUtilities.ApplicationPath,
                             t.Team.Id, t.Team.Name);
            }
        }

        #endregion Events

    };
}

