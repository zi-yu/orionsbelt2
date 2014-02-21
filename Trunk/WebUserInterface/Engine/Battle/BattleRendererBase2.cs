using System.Collections.Generic;
using DesignPatterns;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;
using OrionsBelt.Engine;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public abstract class BattleRendererBase2 : BattleRendererBase {

		#region Fields

		private static readonly FactoryContainer container = new FactoryContainer(typeof(UltimateUnitsRendererBase));
		protected IBattlePlayer enemy;

		#endregion Fields

		#region Private

		private IBattlePlayer GetEnemy(){
			if( battlePlayer.PlayerNumber == 1 ) {
				return battleInfo.Players[0];
			}
			return battleInfo.Players[1];
		}

		#endregion Private

		#region Protected

		/// <summary>
		/// Writes the game Board
		/// </summary>
		protected virtual void WriteBoard(  ) {
			writer.Write("<table id='board2'><tbody>");

			Dictionary<string,IElement> board = battleInfo.GetBoard(battlePlayer);

			for( int i = 1; i < 9; ++i ) {
				writer.Write("<tr>");
				for( int j = 1; j < 9; ++j ) {
					string coord = string.Format("{0}_{1}", i, j);
					IElement e = null;
					if( board.ContainsKey(coord)) {
						e = board[coord];
					}
					WriteCoordinate(coord, e);
				}
				writer.Write("</tr>");
			}
			writer.Write("</tbody></table>");
		}

		protected void WriteUltimateUnit(){
			UltimateUnitsRendererBase ultimateUnit = (UltimateUnitsRendererBase)container.create(battlePlayer.UltimateUnit.Code);
			ultimateUnit.Render(writer);
			AddJsonElement(battleInfo.GetUltimateUnit(battlePlayer, battlePlayer));
		}

		protected void WriteEnemyUltimateUnit(){
			if (enemy.HasUltimateUnit) {
				UltimateUnitsRendererBase ultimateUnit = (UltimateUnitsRendererBase)container.create(enemy.UltimateUnit.Code);
				ultimateUnit.RenderEnemy(writer);
				AddJsonElement(battleInfo.GetUltimateUnit(battlePlayer, enemy));
			}
		}

		#region Upper Layout

		private static string GetAvatar(IBattleOwner iBattleOwner) {
			if (string.IsNullOrEmpty(iBattleOwner.Avatar)) {
				return ResourcesManager.DefaultAvatar;
			}
			return iBattleOwner.Avatar;
		}

		private void WritePlayerInfo(IBattlePlayer player, string className) {
			writer.Write("<div id='{0}'>", className);
			writer.Write("<h2>{0}</h2>", WebUtilities.GetBattlePlayerUrl(battleInfo.BattleMode, player));
			writer.Write("<b>{0}</b>: {1}<br/>", LanguageManager.Instance.Get("EloRanking"), player.Owner.Elo);
			if (battleInfo.BattleMode == BattleMode.Battle || battleInfo.BattleMode == BattleMode.Arena) {
				writer.Write("<b>{0}</b>: {1}<br/>", LanguageManager.Instance.Get("WinScore"), player.WinScore);
				writer.Write("<b>{0}</b>: {1}", LanguageManager.Instance.Get("LoseScore"), player.LoseScore);
			} else {
				writer.Write("<b>{0}</b>: {1}", LanguageManager.Instance.Get("Score"), player.WinScore);
			}

			writer.Write("</div>");
		}

		protected void WritePlayers() {
			IBattlePlayer p1 = battleInfo.Players[0];
			IBattlePlayer p2 = battleInfo.Players[1];

            RenderSocialPublish(writer, battleInfo);

			writer.Write("<div id='players'>");
			WritePlayerInfo(p1, "player1Info");
			writer.Write("<div id='player1Avatar'><img src='{0}' alt='{1}' title='{1}' /></div>", GetAvatar(p1.Owner), p1.Name);
			writer.Write("<div id='player2Avatar'><img src='{0}' alt='{1}' title='{1}' /></div>", GetAvatar(p2.Owner), p2.Name);
			WritePlayerInfo(p2, "player2Info");
			writer.Write("</div>");
		}

        private static object GetOtherPlayerName(IBattleInfo battleInfo)
        {
            foreach (IBattlePlayer player in battleInfo.Players) {
                if (player.Name != PlayerUtils.Current.Name) {
                    return player.Name;
                }
            }
            return "?";
        }

        private static void RenderSocialPublish(TextWriter writer, IBattleInfo battleInfo)
        {
            if (battleInfo.HasEnded() && IsCurrentWinner(battleInfo))
            {
                writer.Write("<div class='shareBattle'>");
                string battleUrl = string.Format("{0}/Battle/Battle.aspx?Id={1}", Server.Properties.BaseUrl, battleInfo.Id);
                string body = string.Format(LanguageManager.Localize("WonBattleDescriptionBody"), LanguageManager.Localize(battleInfo.BattleType.ToString()), LanguageManager.Localize(battleInfo.TournamentMode.ToString()), GetOtherPlayerName(battleInfo), battleUrl);
                SocialUtils.PublishToFacebook(writer,
                        LanguageManager.Localize("WonBattleAtOrionsBelt"),
                        body,
                        "http://www.orionsbelt.eu",
                        WebUtilities.GetAvatar(PlayerUtils.Current.Storage),
                        battleUrl
                    );
                SocialUtils.PublishToTwitter(writer, body);
                writer.Write("</div>");
            }
        }

        private static bool IsCurrentWinner(IBattleInfo battleInfo)
        {
            foreach (IBattlePlayer player in battleInfo.GetBattlePlayerWinners()) {
                if (PlayerUtils.Current.Id == player.Owner.Id || Utils.Principal.Id == player.Owner.Id) {
                    return true;
                }
            }
            return false;
        }

		#endregion Upper Layout

		#endregion Protected

		#region Constructor

		public BattleRendererBase2( IBattleInfo battleInfo, IBattleOwner owner )
			: base(battleInfo, owner) 
		{
			enemy = GetEnemy();			
		}

		#endregion Constructor
	
	}
}
