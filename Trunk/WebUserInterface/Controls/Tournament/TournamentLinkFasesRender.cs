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

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TournamentLinkFasesRender : ControlBase
    {
        #region Control Events

        protected override void  OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);
            long fases = 1;
            int tourId = Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]);
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                fases = persistance.ExecuteScalar("select count(distinct pt.EliminatoryNumber) from SpecializedPlayersGroupStorage pt where pt.TournamentNHibernate.Id = {0}", tourId);
            }

            Write("<ul class='submenu'>");
            for(int iter = 1; iter <= fases; ++iter)
            {
                Write("<li><a href='{0}?Tournament={3}&Stage={1}'>{2}</a></li>", Page.Request.Url.AbsolutePath, iter.ToString(),
                    LanguageManager.Instance.Get("Stage" + iter), tourId.ToString());
            }
            Write("<li><a href='{0}?Tournament={2}&Stage=0'>{1}</a></li>", Page.Request.Url.AbsolutePath,
                    LanguageManager.Instance.Get("Playoffs"), tourId.ToString());
            Write("</ul>");
        }

        #endregion Control Events
    }
}
