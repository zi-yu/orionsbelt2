using System.IO;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
    public class GenericBattleRenderBase {
        #region Fields	

        protected readonly TextWriter writer;
		protected Count battles;
		protected readonly BattleMode battleMode;
		protected readonly bool allBattles;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Private	

        protected void WriteTitle(string caption) {
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get(caption));
        }

		protected virtual void WriteTitles() {
            writer.Write("<tr>");
            WriteTitle( "Turn");
            WriteTitle( "Opponent");
            WriteTitle( "BattleType");
			WriteTournamentTitle();
			WriteTitle( "Status");
			if (!allBattles) {
				WriteTitle( "Timeout");
				WriteTitle( "EnemyTimeout");
				WriteTitle( "WinPercentage");
			}
			
            WriteTitle( "TimeLeft");
            writer.Write("</tr>");
        }

		protected virtual void WriteContent() {
            foreach (SimpleBattleInfo info in battles.Battles ) {
                writer.Write("<tr>");
                WriteBattle(info);
                writer.Write("</tr>");
            }
        }

		protected virtual void WriteBattle(SimpleBattleInfo info) {
            WriteTd(info.CurrentTurn);
            WriteTd( info.GetOpponents(allBattles) );
            WriteTd( info.BattleType );
			WriteTournamentType(info);
			WriteTd(string.Format("<a href='{2}Battle/Battle.aspx?id={0}'>{1}</a>", info.BattleId, GetStatus(info), WebUtilities.ApplicationPath));
			if (!allBattles) {
				WriteTd( info.Timeouts );
				WriteTd( info.Opponents[0].Timeouts );
				if (info.VictoryPercentage >= 50 ) {
					WriteTd(string.Format("{0}%", info.VictoryPercentage), "percentageGreen");
				}else {
					WriteTd(string.Format("{0}%", info.VictoryPercentage), "percentageRed");
				}
			}
        	WriteTd( info.TimeLeft );
        }

		protected void WriteTd(object value) {
            writer.Write("<td>{0}</td>", value);
        }

		protected void WriteTd(string value, string className) {
			writer.Write("<td class='{1}'>{0}</td>", value, className);
		}

		protected string GetStatus(SimpleBattleInfo info) {
			if( allBattles ) {
				return LanguageManager.Instance.Get("ViewBattle");
			}

            if( info.IsDeployTime ) {
                if( info.HasDeployed ) {
                    return LanguageManager.Instance.Get("OpponentsDeploy");
                }
                return LanguageManager.Instance.Get("YourDeploy");
            }

            if( info.IsTurn ) {
                return LanguageManager.Instance.Get("YourTurn");
            }
            return LanguageManager.Instance.Get("OpponentsTurn");
        }

		protected void WriteTournamentTitle() {
			if (battleMode == BattleMode.Tournament) {
				WriteTitle("TournamentType");
			}
		}

		protected void WriteTournamentType(SimpleBattleInfo info) {
			if (battleMode == BattleMode.Tournament) {
				if (info.TournamentMode == TournamentMode.Normal) {
                    WriteTd(string.Format("<a href='{2}Tournaments/Tournament.aspx?Tournament={1}&Stage=0'>{0}</a>", info.TournamentName,info.TournamentId,WebUtilities.ApplicationPath));	
				}else {
					WriteTd(LanguageManager.Localize(info.TournamentMode.ToString()));	
				}
			}
		}

        #endregion Private

        #region Public	

		public void Render() {
			writer.Write("<table class='newtable'><tbody>");
            WriteTitles();
            WriteContent();
			writer.Write("</tbody></table>");
        }

        #endregion Public

        #region Constructor

        public GenericBattleRenderBase( Mode mode, TextWriter writer ) {
            this.writer = writer;
			battleMode = mode.BattleMode;
        }

		public GenericBattleRenderBase(Mode mode, TextWriter writer, bool allBattles) {
			this.writer = writer;
			this.allBattles = allBattles;
			battleMode = mode.BattleMode;
        }
        #endregion Constructor
    }
}