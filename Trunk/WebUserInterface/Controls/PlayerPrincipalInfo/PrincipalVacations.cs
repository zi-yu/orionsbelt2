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
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PrincipalVacations : BaseFieldControl<Principal> {

        #region Events

        protected override void Render(HtmlTextWriter writer, Principal t, int renderCount, bool flipFlop)
        {
            if (t.VacationStartTick > 0){
                writer.Write(string.Format(LanguageManager.Instance.Get("InVacations"),
                    TimeFormatter.GetFormattedTicks(t.VacationEndtick - Clock.Instance.Tick)));
            }else{
                writer.Write(TimeFormatter.GetFormattedTicks(t.AvailableVacationTicks));
            }
        }

        #endregion Events

    };

}
