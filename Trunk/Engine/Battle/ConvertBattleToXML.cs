using System.Collections.Generic;
using System.IO;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine {
	public static class ConvertBattleToXML {
		
		#region Fields

		#endregion

		#region Private

		private static void WriteResponseUrl(StringWriter writer) {
			writer.Write("<ResponseUrl>{0}Ajax/Battle/BotBattle.ashx</ResponseUrl>", Server.Properties.BaseUrl);
		}

		private static void WritePlayers(StringWriter writer, IBattleInfo info) {
			writer.Write("<Players>");
			foreach (IBattlePlayer player in info.Players) {
				writer.Write("<Player id='{0}' ownerId='{1}' botid='{3}'>{2}</Player>", player.PlayerNumber, player.Owner.Id, player.Name,player.Owner.BotId);
			}
			writer.Write("</Players>");
		}

		private static void WriteCurrentPlayer(StringWriter writer, IBattleInfo info) {
			writer.Write("<CurrentPlayer id='{0}' ownerId='{1}' botId='{3}'>{2}</CurrentPlayer>", info.CurrentBattlePlayer.PlayerNumber, info.CurrentBattlePlayer.Owner.Id, info.CurrentBattlePlayer.Name, info.CurrentBattlePlayer.Owner.BotId);
		}

		private static void WriteBotId(StringWriter writer, IBattlePlayer player) {
			writer.Write("<CurrentPlayer id='{0}' ownerId='{1}' botId='{3}' >{2}</CurrentPlayer>", player.PlayerNumber, player.Owner.Id, player.Name,player.Owner.BotId);
		}

		private static void WriteBattle(StringWriter writer, IBattleInfo info, IBattlePlayer player) {
			writer.Write("<Elements>");
			foreach (IElement element in GetElements(info, player)) {
				writer.Write("<Element coordinate='{0}' ",element.Coordinate);
				writer.Write(" canBeMoved='{0}' ", element.CanBeMoved);
				writer.Write(" canUseSpecialHabilities='{0}' ", element.CanUseSpecialAbilities);
				writer.Write(" id='{0}' ", element.Owner.PlayerNumber);
				writer.Write(" ownerId='{0}' ", element.Owner.Owner.Id);
                writer.Write(" direction='{0}' ", element.Position);
				writer.Write(" quantity='{0}' ", element.Quantity);
				writer.Write(" remainingDefense='{0}' ", element.RemainingDefense);
				writer.Write(" name='{0}'", element.Unit.Name);
                writer.Write(" code='{0}'", element.Unit.Code);
                writer.Write(" isInfestated='{0}'", element.IsInfestated);
				writer.Write("/>");
			}
			writer.Write("</Elements>");
		}

		private static void WriteUnitToDeploy(StringWriter writer, IBattlePlayer player) {
			writer.Write("<Units>");
			foreach (IElement element in player.InitialContainer.InitialUnits) {
				writer.Write("<Unit quantity='{0}' ", element.Quantity);
				writer.Write("name='{0}' ", element.Unit.Name);
				writer.Write("code='{0}' ", element.Unit.Code);
				writer.Write("/>");
			}
			writer.Write("</Units>");
		}

		private static IEnumerable<IElement> GetElements(IBattleInfo info, IBattlePlayer requester) {
			IEnumerable<IElement> board;
			if( requester != null){
				board = info.GetBoard(requester).Values;
			}else {
				board = info.GetBoard().Values;
			}
			foreach (IElement element in board) {
				yield return element;	
			}
		}

		private static IBattlePlayer GetBot(IBattleInfo info, int requesterId) {
			return info.Players.Find(delegate(IBattlePlayer p) { return p.Owner.BotId == requesterId; });
		}
		
		#endregion Private

		#region Public

		public static string Convert(IBattleInfo info, int requesterId) {
            using (StringWriter writer = new StringWriter()) {
                IBattlePlayer player = GetBot(info, requesterId);
                writer.Write("<Battle id='{0}' botName='{2}' state='battle' turn='{1}' terrain='{3}'>", info.Id, info.CurrentTurn, player.Owner.BotName, info.Terrain);
                WriteResponseUrl(writer);
                WritePlayers(writer, info);

                WriteCurrentPlayer(writer, info);
                WriteBattle(writer, info, player);
                writer.Write("</Battle>");
                return writer.ToString();
            }
		}

		public static string UnitToDeploy(IBattleInfo info, int requesterId) {
			IBattlePlayer player = GetBot(info, requesterId);
            using (StringWriter writer = new StringWriter()) {
                writer.Write("<Battle id='{0}' botName='{1}' state='deploy' terrain='{2}'>", info.Id, player.Owner.BotName, info.Terrain);
                WriteResponseUrl(writer);
                WritePlayers(writer, info);
                WriteBotId(writer, player);
                WriteUnitToDeploy(writer, player);
                writer.Write("</Battle>");
                return writer.ToString();
            }
		}
		
		#endregion Public

	}
}
