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
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PrincipalLastActivity : BaseFieldControl<Principal> {

        #region Events

        protected override void Render(HtmlTextWriter writer, Principal t, int renderCount, bool flipFlop)
        {
            int lastTick = 0;
            foreach (PlayerStorage storage in t.Player)
            {
                if(storage.LastProcessedTick > lastTick)
                {
                    lastTick = storage.LastProcessedTick;
                }
            }

            TimeSpan lastOnline = DateTime.Now - Clock.Instance.GetDate(lastTick);

            if (IsOnline(t, lastOnline))
            {
                writer.Write("<span class='green'>{0}</span>", LanguageManager.Instance.Get("Online"));
            } else {
                writer.Write(TimeFormatter.GetFormattedTime(lastOnline));
            }
        }

        private static bool IsOnline(Principal t, TimeSpan lastOnline)
        {
            return lastOnline.TotalMinutes <= 20 || t.IsBot;
        }

        #endregion Events

    };

}
