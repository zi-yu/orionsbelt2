using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    public class AllianceDiplomacyLevelTranslated : BaseFieldControl<AllianceStorage> {

        #region Events

        protected override void Render(HtmlTextWriter writer, AllianceStorage t, int renderCount, bool flipFlop)
        {
            string level = (string) State.GetItems(string.Format("Diplomacy{0}_{1}", AllianceWebUtils.Current.Storage.Id, t.Id));
            writer.Write("<span class='{1}'>{0}</span>",LanguageManager.Localize(level),level.ToLower());
        }

        #endregion Events

    };

}
