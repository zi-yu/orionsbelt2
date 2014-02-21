using System.IO;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.WebBattle;

namespace OrionsBelt.WebUserInterface.Engine {

	public class RightBattleMenu4 : RightBattleMenuBase {
	
		#region Private

		private static string GetPlayerClass(IBattlePlayer current, IBattlePlayer player, int i) {
			if (null == player || (current.TeamNumber == player.TeamNumber && current.PlayerNumber != player.PlayerNumber)) {
				return "playerFriendly";
			}
			return string.Format("player{0}", i);
		}

        private static void WritePlayerInfo(TextWriter writer, IBattlePlayer player, IBattleInfo battleInfo) {
            writer.Write("<div class='content'><h4>{0}</h4>", WebUtilities.GetBattlePlayerUrl(battleInfo.BattleMode, player));
            int elo = 1000;
            if (player != null)
            {
                elo = player.Owner.Elo;
            }
			writer.Write("<b>{0}</b>: {1}<br/>", LanguageManager.Instance.Get("EloRanking"), elo);
            writer.Write("</div>");
		}

		private static void RenderPlayers(TextWriter writer, InitialContainerManager manager, IBattleInfo battleInfo) {
			IBattlePlayer current = manager.GetPlayer(0);
			for( int i = 0; i < 4; ++i ) {
				IBattlePlayer player = manager.GetPlayer(i);
                if(null == player)
                {
                    continue;
                }
				string playerClass = GetPlayerClass(current, player, i);
				writer.Write("<div class='battlePlayer {0}'>", playerClass);
				writer.Write("<div class='avatar'><img src='{0}'/></div>",GetAvatar(player));
			    WritePlayerInfo(writer,player,battleInfo);
				writer.Write("</div>");
			}
		}

		private static string GetAvatar(IBattlePlayer player) {
            if (player == null || string.IsNullOrEmpty(player.Owner.Avatar))
            {
				return ResourcesManager.DefaultAvatar;
			}
			return player.Owner.Avatar;
		}

		#endregion Private

		#region Public

		public static void Render(TextWriter writer, OptionType optionType, IBattleInfo battleInfo, InitialContainerManager manager) {
			writer.Write("<div id='rightBattleMenu'>");
			RenderPlayers(writer, manager, battleInfo);
			writer.Write("<h3>{0}</h3>",LanguageManager.Instance.Get("Options"));
			RenderOptions(writer, optionType, battleInfo.IsDeployTime);
			RenderTurnMoves(writer, optionType);
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("Quantity"));
			writer.Write("<div class='quantityToMoveMenu'>");
            writer.Write("{0}:<input id='quantity' type='text' /><br/>", LanguageManager.Instance.Get("InsertQuantity"));
            writer.Write("{0}:<span id='minquantity'></span><br/>", LanguageManager.Instance.Get("MinQuantity"));
            writer.Write("{0}:<span id='maxquantity'></span><br/>", LanguageManager.Instance.Get("MaxQuantity"));
			writer.Write("</div>");
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("UnitsDestroyed"));
			writer.Write("<div class='unitsDestroyedMenu'><div id='damage'></div></div>");
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("RotateUnit"));
			RenderRotationTable(writer);
			writer.Write("</div>");
		}

		#endregion Public

	}
}