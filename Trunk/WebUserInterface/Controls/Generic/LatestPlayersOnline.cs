using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Web;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using System;
using System.Web.Caching;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {
	public class LatestPlayersOnline : Control  {

        #region Fields

        protected SiteFooter siteFooter = new SiteFooter();

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            Controls.Add(siteFooter);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string key = string.Format("LatestPlayers-{0}", LanguageManager.CurrentLanguage);
            if (State.HasFileCache(key)) {
                writer.Write(State.GetFileCache(key));
                base.Render(writer);
                writer.Write("</div>");
                return;
            }

            TextWriter tmp = new StringWriter();

            IList<PlayerStorage> players = GetPlayers();

            tmp.Write("<div id='latestPlayers'>");

            tmp.Write("<h5>");
            tmp.Write(LanguageManager.Instance.Get("LatestPlayers"));
            tmp.Write("</h5>");

            tmp.Write("<ul>");
            foreach (PlayerStorage storage in players) {
                tmp.Write("<li>");
                tmp.Write(WebUtilities.WritePlayerWithAvatar(storage, true, false));
                tmp.Write("</li>");
            }
            tmp.Write("</ul>");

            State.SetFileCache(key, tmp.ToString(), TimeSpan.FromMinutes(20));
            writer.Write(tmp.ToString());

            base.Render(writer);
            writer.Write("</div>");
                
        }

        #endregion Events

        #region Utilities

        private static IList<PlayerStorage> GetPlayers()
        {
            IList<PlayerStorage> players = Hql.Query<PlayerStorage>(0, 12, "select player from SpecializedPlayerStorage player order by player.UpdatedDate desc", null);
            return players;
        }

        #endregion Utilities

    };
}
