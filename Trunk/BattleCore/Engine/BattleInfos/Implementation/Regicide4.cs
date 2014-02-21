using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("Regicide4")]
	public class Regicide4: BattleInfo4Players {

		#region Private

		protected override void UpdateSpecialUnits() {
			//if ((BattleType == OrionsBelt.RulesCore.Enum.BattleType.Regicide || BattleType == OrionsBelt.RulesCore.Enum.BattleType.Regicide4) && HasEnded()) {
			//    foreach (IElement element in GetFlags()) {
			//        IBattlePlayer player = element.Owner;
			//        if (player.HasLost) {
			//            IBattlePlayer enemy = Players.Find(delegate(IBattlePlayer p) { return p.TeamNumber != player.TeamNumber && !player.HasLost; });
			//            BattleStatistics.UpdateStatistics(enemy, player, player.UltimateUnit.Element.Unit, 1);
			//        }
			//    }
			//}
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
		/// Resolves the current losers of a battle
		/// </summary>
		/// <param name="flags">List of flags currently active</param>
		private void ResolveLosers( List<IElement> flags ) {
			foreach( IBattlePlayer p in Players ) {
				IElement element = flags.Find(delegate( IElement e ) { return e.Owner.PlayerNumber == p.PlayerNumber; });
				if( element == null ) {
					SetLoser(p);
				}
			}
		}

		/// <summary>
		/// Sets the passed player has a loser
		/// </summary>
		private void SetLoser( IBattlePlayer loser ) {
			RemovePlayerUnits(loser);
			loser.HasLost = true;
		}

		/// <summary>
		/// Verifies if a team has won
		/// </summary>
		/// <param name="flags"></param>
		/// <returns></returns>
		private static bool HasTeamWon( List<IElement> flags ) {
			int team = -1;
			foreach( IElement flag in flags ) {
				if( team == -1 ) {
					team = flag.Owner.TeamNumber;
					continue;
				}
				if( team != flag.Owner.TeamNumber ) {
					return false;
				}
			}
			return true;
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
				List<IElement> flags = GetFlags();
				ResolveLosers(flags);

				if ( !HasTeamWon(flags) ) {
					return false;
				}
			}
			return true;
		}

		#endregion Overriden Methods

		#region Constructor

		public Regicide4() { }

		public Regicide4( IBattle battle ) : base(battle) {
			BattleType = OrionsBelt.RulesCore.Enum.BattleType.Regicide4;
			AddFlags();
		}

		#endregion Constructor

		#region IFactory

		public override object create( object args ) {
			return new Regicide4((IBattle) args);
		}

		#endregion IFactory

	}
}
