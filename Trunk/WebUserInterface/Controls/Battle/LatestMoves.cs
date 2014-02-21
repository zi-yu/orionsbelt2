using OrionsBelt.WebUserInterface.WebBattle;
using System.Web.UI;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using System;
using System.Web.Caching;
using System.IO;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Controls {
	public class LatestMoves : Control {

        #region Fields

        private int specificBattle = -1;

        public int SpecificBattle
        {
            get { return specificBattle; }
            set { specificBattle = value; }
        }

        public virtual bool IncludeBounties {
            get { return false; }
        }

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!State.HasFileCache(GetKey())) {
                Controls.Add(new LiteralControl(string.Format("<div class='LatestMoves'>")));
                foreach (Battle battle in GetLatest()) {
                    Add(battle);
                }
                if (IncludeBounties) {
                    AddBounties();
                }
                Controls.Add(new LiteralControl("</div><div class='clear'></div>"));
            }
        }

        protected virtual string GetKey()
        {
            return string.Format("LatestBattles{0}-{1}", SpecificBattle, LanguageManager.CurrentLanguage);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterHiddenField("numberOfPlayers", "2");
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (State.HasFileCache(GetKey())) {
                writer.Write(State.GetFileCache(GetKey()));
                return;
            }

            HtmlTextWriter cache = new HtmlTextWriter(new StringWriter());
            base.Render(cache);
            string all = cache.InnerWriter.ToString();
            writer.Write(all);
            State.SetFileCache(GetKey(), all, TimeSpan.FromMinutes(40));
        }

        private void AddBounties()
        {
            Controls.Add(new LiteralControl("<dl class='bigger'>"));
            Controls.Add(new LiteralControl("<dd>"));
            Controls.Add(new LiteralControl(GetLatestBounties()));
            Controls.Add(new LiteralControl("<dd>"));

            Controls.Add(new LiteralControl("</dl>"));
        }

        private string GetLatestBounties()
        {
            TextWriter writer = new StringWriter();

            writer.Write("<table class='newtable'>");
            writer.Write("<th colspan='3'><a href='{1}Quests/Bounties.aspx'>{0}</a></th>", LanguageManager.Instance.Get("CustomBountyPrizeList"), WebUtilities.ApplicationPath);


            IList<QuestStorage> quests = GetQuestList();
            if (quests.Count == 0) {
                writer.Write("<tr><td colspan='3'>{0}</td></tr>", LanguageManager.Instance.Get("NoneAvailable"));
            } else {
                WritePlayerBounties(writer, quests);
            }

            writer.Write("</table>");

            return writer.ToString();
        }

        private void WritePlayerBounties(TextWriter writer, IList<QuestStorage> quests)
        {
            foreach (QuestStorage storage in quests) {
                IQuestData data = QuestConversion.ConvertStorageToQuest(storage);
                writer.Write("<tr>");
                writer.Write("<td><a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a></td>", WebUtilities.ApplicationPath, data.QuestIntConfig["TargetId"], data.QuestStringConfig["TargetName"]);
                //writer.Write("<td>{0:#0}%</td>", data.Percentage);
                writer.Write("<td>{0} {1}</td>", data.QuestIntConfig["Reward"], LanguageManager.Instance.Get("Orions"));
				writer.Write("<td style='width:90px;'><div class='buttonSmall'><a href='javascript:Quests.getBounty(\"{0}\");'>{1}</a></div></td>", storage.Id, LanguageManager.Instance.Get("More"));
                writer.Write("</tr>");
            }
        }

        private void Add(Battle battle)
        {
            BattleRenderer renderer = new BattleRenderer();
            renderer.IsPreview = true;
            renderer.BattleInfo = BattleManager.GetBattle(battle);

            Controls.Add(new LiteralControl("<dl>"));
            Controls.Add(new LiteralControl(GetLinkHtml(battle)));

            Controls.Add(new LiteralControl("<dd>"));
            Controls.Add(renderer);
            Controls.Add(new LiteralControl(GetPlayersHtml(battle)));
            Controls.Add(new LiteralControl("<dd>"));

            Controls.Add(new LiteralControl("</dl>"));
        }

        private string GetLinkHtml(Battle battle)
        {
            TextWriter writer = new StringWriter();

            writer.Write("<dt>");
            writer.Write("<div class='button'><a href='{0}Battle/Battle.aspx?Id={1}'>{2}</a></div>", WebUtilities.ApplicationPath, battle.Id, LanguageManager.Instance.Get("ViewBattle"));
            writer.Write("</dt>");

            return writer.ToString();
        }

        private static string GetPlayersHtml(Battle battle)
        {
            TextWriter writer = new StringWriter();

            writer.Write("<table class='newtable'>");
            WritePlayerLinks(writer, battle.PlayerInformation[0]);
            WritePlayerLinks(writer, battle.PlayerInformation[1]);
            writer.Write("</table>");

            return writer.ToString();
        }

        private static void WritePlayerLinks(TextWriter writer, PlayerBattleInformation player)
        {
            BattleMode type = (BattleMode)Enum.Parse(typeof(BattleMode), player.Battle.BattleMode);
            if (type == BattleMode.Arena || type == BattleMode.Battle) {
                writer.Write("<tr>");
                writer.Write("<td><a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a></td>", WebUtilities.ApplicationPath, player.Owner, player.Name);
                writer.Write("<td>{0}%</td>", player.VictoryPercentage);
                writer.Write("<tr>");
            } else {
                writer.Write("<tr>");
                writer.Write("<td><a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a></td>", WebUtilities.ApplicationPath, player.Owner, player.Name);
                writer.Write("<td>{0}%</td>", player.VictoryPercentage);
                writer.Write("<tr>");
            }
        }

        #endregion Events

        #region Database

        protected virtual IList<Battle> GetLatest()
        {
            if (SpecificBattle < 0) {
                return Hql.StatelessQuery<Battle>(0, 4,
                        "select battle from SpecializedBattle battle where battle.HasEnded = 0 and battle.IsDeployTime = 0 and battle.BattleMode = 'Tournament' and battle.CurrentTurn > 10 and battle.BattleType not like '%4' order by battle.UpdatedDate desc",
                        null
                    );
            } else {
                return Hql.StatelessQuery<Battle>( "select battle from SpecializedBattle battle where battle.Id = :id", Hql.Param("id", SpecificBattle) );
            }
        }

        private void FetchBattleElements(IBattlePersistance persistance, IList<Battle> battles)
        {
            
        }

        private IList<QuestStorage> GetQuestList()
        {
            return Hql.StatelessQuery<QuestStorage>(0, 9, "select quest from SpecializedQuestStorage quest where quest.Type = 'CustomPlayerBountyTemplate' and quest.Completed = false order by quest.UpdatedDate desc", null);
        }

        #endregion Database

    };
}
