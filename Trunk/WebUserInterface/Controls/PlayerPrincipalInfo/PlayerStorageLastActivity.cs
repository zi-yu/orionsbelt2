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

    public class PlayerStorageLastActivity : BaseFieldControl<PlayerStorage> {

        #region Events

        protected override void Render(HtmlTextWriter writer, PlayerStorage t, int renderCount, bool flipFlop)
        {
            TimeSpan lastOnline = DateTime.Now - Clock.Instance.GetDate(t.LastProcessedTick);
            if (lastOnline.TotalMinutes <= 10) {
                writer.Write("<span class='green'>{0}</span>", LanguageManager.Instance.Get("Online"));
            } else {
                writer.Write(TimeFormatter.GetFormattedTime(lastOnline));
            }
        }

        #endregion Events

    };

}
