using System.Collections.Generic;
using System.IO;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
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
				writer.Write("<Player id='{0}' ownerId='{1}'>{2}</Player>", player.PlayerNumber, player.Owner.Id, player.Name);
			}
			writer.Write("</Players>");
		}

		private static void WriteCurrentPlayer(StringWriter writer, IBattleInfo info) {
			writer.Write("<CurrentPlayer id='{0}' ownerId='{1}'>{2}</CurrentPlayer>", info.CurrentBattlePlayer.PlayerNumber, info.CurrentBattlePlayer.Owner.Id, info.CurrentBattlePlayer.Name);
		}

		private static void WriteBotId(StringWriter writer, IBattlePlayer player) {
			writer.Write("<CurrentPlayer id='{0}' ownerId='{1}'>{2}</CurrentPlayer>", player.PlayerNumber, player.Owner.Id, player.Name);
		}

		private static void WriteBattle(StringWriter writer, IBattleInfo info, int requesterId) {
			writer.Write("<Elements>");
			foreach (IElement element in GetElements(info, requesterId)) {
				writer.Write("<Element coordinate='{0}' ",element.Coordinate);
				writer.Write(" canBeMoved='{0}' ", element.CanBeMoved);
				writer.Write(" canUseSpecialHabilities='{0}' ", element.CanUseSpecialAbilities);
				writer.Write(" id='{0}' ", element.Owner.PlayerNumber);
				writer.Write(" ownerId='{0}' ", element.Owner.Owner.Id);
				writer.Write(" position='{0}' ", element.Position);
				writer.Write(" quantity='{0}' ", element.Quantity);
				writer.Write(" remainingDefense='{0}' ", element.RemainingDefense);
				writer.Write(" name='{0}'", element.Unit.Name);
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

		private static IEnumerable<IElement> GetElements(IBattleInfo info, int requesterId) {
			IBattlePlayer requester = GetPlayer(info, requesterId);
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

		private static IBattlePlayer GetPlayer(IBattleInfo info, int requesterId) {
			return info.Players.Find(delegate(IBattlePlayer p) { return p.Owner.Id == requesterId; });
		}
		
		#endregion Private

		#region Public

		public static string Convert(IBattleInfo info, int requesterId) {
			StringWriter writer = new StringWriter();
			writer.Write("<Battle id='{0}' state='battle'>",info.Id);
			WriteResponseUrl(writer);
			WritePlayers(writer, info);
			
			WriteCurrentPlayer(writer, info);
			WriteBattle(writer, info, requesterId);
			writer.Write("</Battle>");
			return writer.ToString();
		}

		public static string UnitToDeploy(IBattleInfo info, int requesterId) {
			IBattlePlayer player = GetPlayer(info, requesterId);
			StringWriter writer = new StringWriter();
			writer.Write("<Battle id='{0}' state='deploy'>", info.Id);
			WriteResponseUrl(writer);
			WritePlayers(writer, info);
			WriteBotId(writer, player);
			WriteUnitToDeploy(writer, player);
			writer.Write("</Battle>");
			return writer.ToString();
		}
		
		#endregion Public

	}
}
