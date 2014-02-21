using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using OrionsBelt.Generic.Log;

namespace OrionsBelt.Generic {

    /// <summary>
    /// Manages time in the game, but delegates turn processing to another foreign entity
    /// </summary>
    public class ProxyClock : TickClock {

        #region Base Implementation

        public override void Advance()
        {
            Server.Refresh();

            //Logger.Debug(LogType.Clock, "Proxy Clock Advance, new Tick: {0}", Server.Properties.CurrentTick);

            Started = Server.Properties.CurrentTick;
            Tick = Started;
            LastTickDate = Server.Properties.LastTickDate;

            Start();
            OnTicked();
        }

        #endregion Base Implementation

    };

}
