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
using OrionsBelt.Engine.Resources;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PlayerStorageProfession : BaseFieldControl<PlayerStorage> {

        #region Events

        protected override void Render(HtmlTextWriter writer, PlayerStorage t, int renderCount, bool flipFlop)
        {
            writer.Write(LanguageManager.Instance.Get(new Player(t).MainProfession.ToString()));
        }

        #endregion Events

    };

}
