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
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

	public class PrincipalPlayers: Control {

        #region Events

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            string raw = HttpContext.Current.Request.QueryString["SetActive"];
            if (!string.IsNullOrEmpty(raw)) {
                int id = int.Parse(raw);
                using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
                    persistance.StartTransaction();
                    foreach (PlayerStorage storage in GetAllPlayers()) {
                        if (storage.Active) {
                            storage.Active = false;
                            persistance.Update(storage);
                        }
                        if (storage.Id == id) {
                            storage.Active = true;
                            storage.ActivatedInTick = Clock.Instance.Tick;
                            PlayerUtils.Current = PlayerUtils.LoadPlayer(storage);
                            persistance.Update(storage);
                        }
                    }
                    persistance.CommitTransaction();
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("ManagePlayers"));

            StringWriter content = new StringWriter();
            content.Write("<dl>");
            foreach (PlayerStorage playerStorage in GetAllPlayers()) {
                IPlayer player = new Player(playerStorage);
                WritePlayer(content, player);
            }
            content.Write("</ul>");

            string bottom = string.Format("<div class='button'><a href='AddPlayer.aspx'>{1}</a></div>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("AddNewPlayer"));

            writer.Write("<div id='managePlayers'>");
            Border.RenderMedium(writer,title,content.ToString(),bottom);
            writer.Write("</div>");
        }

        private void WritePlayer(TextWriter writer, IPlayer player)
        {
            writer.Write("<dt class='{0}'>&nbsp;</dt>",player.RaceInfo.Race);
            writer.Write("<dd>");

            if (player.Id != PlayerUtils.Current.Id) {
                writer.Write("<p><div class='buttonSmall'><a href='ManagePlayers.aspx?SetActive={0}'>{1}</a></div></p>", player.Id, LanguageManager.Instance.Get("SetActive"));
            }

            writer.Write("<p><a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a></p>", WebUtilities.ApplicationPath, player.Id, player.Name);
            writer.Write("<p>{0}: {1}</p>", LanguageManager.Instance.Get("Level"), player.PlanetLevel);
            writer.Write("<p>{0}: <span class='{2}'>{1}</span></p>", LanguageManager.Instance.Get("Active"), LanguageManager.Instance.Get(player.Active.ToString()),player.Active?"green":"red");
            
            
            writer.Write("</dd>");
        }

        #endregion Events

        #region Utils

        private IList<PlayerStorage> allPlayers = null;
        private IList<PlayerStorage> GetAllPlayers()
        {
            if (allPlayers == null){
                allPlayers = Hql.Query<PlayerStorage>("from SpecializedPlayerStorage p where p.PrincipalNHibernate.Id = :id", Hql.Param("id", Utils.Principal.Id));
            }
            return allPlayers;
        }

        #endregion

    };
}

