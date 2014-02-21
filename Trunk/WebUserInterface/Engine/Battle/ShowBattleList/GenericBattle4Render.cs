using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
    public class GenericBattle4Render : GenericBattleRenderBase {
		
        #region Properties

        #endregion Properties

        #region Private	

        protected override void WriteTitles() {
            writer.Write("<tr>");
            WriteTitle( "Turn");
            WriteTitle( "Opponents");
            WriteTitle( "BattleType");
        	WriteTournamentTitle();
            WriteTitle( "Status");
			if (!allBattles) {
				WriteTitle( "Timeout");
				WriteTitle( "EnemyTimeout");
				WriteTitle("WinPercentage");
			}
        	WriteTitle( "TimeLeft");
            writer.Write("</tr>");
        }

        protected override void WriteContent() {
            foreach (SimpleBattleInfo info in battles.Battles ) {
                Dictionary<int, int> victoryPercentage = GetVictoryPercentage(info);
                writer.Write("<tr>");
                WriteBattle(info, victoryPercentage);
                writer.Write("</tr>");
            }
        }

        private static Dictionary<int,int> GetVictoryPercentage(SimpleBattleInfo info){
            Dictionary<int,int> victoryPercentage = new Dictionary<int, int>();
            victoryPercentage.Add(info.TeamNumber, info.VictoryPercentage);

            foreach( OtherPlayersInformations other in info.Opponents ){
                if( victoryPercentage.ContainsKey(other.TeamNumber)){
                    victoryPercentage[other.TeamNumber] += other.VictoryPercentage;
                }else{
                    victoryPercentage.Add(other.TeamNumber, other.VictoryPercentage);
                }    
            }

            return victoryPercentage;
        }

        private void WriteBattle(SimpleBattleInfo info, Dictionary<int, int> victoryPercentage){
            WriteTd(info.CurrentTurn);
			WriteTd(info.GetOpponents(allBattles));
            WriteTd( info.BattleType );
			WriteTournamentType(info);
			WriteTd(string.Format("<a href='{2}Battle/Battle.aspx?id={0}'>{1}</a>", info.BattleId, GetStatus(info), WebUtilities.ApplicationPath));
			if (!allBattles) {
				WriteTd( info.Timeouts );
				WriteTd( info.Opponents[0].Timeouts );
				int vp = victoryPercentage[info.TeamNumber];
				if( vp >= 50) {
					WriteTd(string.Format("{0}%", vp), "percentageGreen");
				}else {
					if( vp > 0 ) {
						WriteTd(string.Format("{0}%", vp), "percentageRed");
					}else {
						WriteTd("-");
					}
				}
				
			}
        	WriteTd( info.TimeLeft );
        }


        #endregion Private

        #region Constructor

		public GenericBattle4Render(Mode mode, TextWriter writer) 
			: base(mode,writer) {
            battles = mode.GetBattles(4);
        }

		public GenericBattle4Render(Mode mode, TextWriter writer, bool allBattles)
			: base(mode, writer,allBattles) {
             battles = mode.GetBattles(4);
        }

        #endregion Constructor
    }
}