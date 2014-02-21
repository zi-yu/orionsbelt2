using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using System.Collections.Generic;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TournamentDescription : ControlBase
    {
        private Core.Tournament tour;

        public Core.Tournament Tournament
        {
            get { return tour; }
            set { tour = value; }
        }

        #region Control Events

        protected override void  OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!string.IsNullOrEmpty(tour.DescriptionToken))
            {
                Write("<div class='center'>{0}</div>", LanguageManager.Instance.Get(tour.DescriptionToken));
            }
        }

        #endregion Control Events
    }
}
