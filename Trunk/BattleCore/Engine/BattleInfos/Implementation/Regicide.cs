using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("Regicide")]
	public class Regicide: BattleInfo2Players {

		#region Private

		protected override void UpdateSpecialUnits() {
			if ((BattleType == OrionsBelt.RulesCore.Enum.BattleType.Regicide || BattleType == OrionsBelt.RulesCore.Enum.BattleType.Regicide4) && HasEnded()) {
				foreach (IElement element in GetFlags()) {
					IBattlePlayer player = element.Owner;
					if (player.HasLost) {
						BattleStatistics.UpdateStatistics(GetEnemyPlayer(player), player, element.Unit, 1);
					}
				}
			}
		}

		/// <summary>
		/// Adds a flag to all the players
		/// </summary>
		private void AddFlags() {
			IUnitInfo flag = Unit.Create("fg");
			foreach( IBattlePlayer player in Players ) {
				player.InitialContainer.AddUnit(flag, 1);
			}
		}

		/// <summary>
		/// Gets all the flags in the board
		/// </summary>
		/// <returns>A list with the flags in the battle field</returns>
		private List<IElement> GetFlags() {
			List<IElement> flags = new List<IElement>();
			foreach( IElement element in board.Values ) {
				if( element.Unit is Flag ) {
					flags.Add(element);
				}
			}
			return flags;
		}

		/// <summary>
		/// Sets the loser of the battle
		/// </summary>
		/// <param name="loser"></param>
		private static void SetLoser( IBattlePlayer loser ) {
			loser.HasLost = true;
		}

		/// <summary>
		/// If the user has the flag
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		private bool HasLost(IBattlePlayer player) {
			List<IElement> elements = new List<IElement>();
			bool hasFlag = false;
			foreach (IElement element in board.Values) {
				if (element.Owner.PlayerNumber == player.PlayerNumber ) {
					if (element.Unit is Flag ) {
						hasFlag = true;
					}else {
						elements.Add(element);
					}
				}
			}
			return !hasFlag || elements.Count == 0;
		}

		#endregion Private

		#region Overriden Methods

		/// <summary>
		/// Verifies if the battle has ended
		/// </summary>
		/// <returns></returns>
		public override bool HasEnded() {
			if( !AllPlayersPositioned ) {
				return false;
			}

			if( !Battle.HasEnded ) {
				foreach(IBattlePlayer player in Players) {
					if (HasLost(player)) {
						SetLoser(player);
						return true;
					}
				}
				return false;
			}
			return true;
		}

		#endregion Overriden Methods

		#region Constructor

		public Regicide() { }

		public Regicide( IBattle battle ) : base(battle) {
			BattleType = OrionsBelt.RulesCore.Enum.BattleType.Regicide;
			AddFlags();
		}

		#endregion Constructor

		#region IFactory

		public override object create( object args ) {
			return new Regicide((IBattle) args);
		}

		#endregion IFactory

	}
}
