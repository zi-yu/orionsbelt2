using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("kh")]
	public class BattleKahuna: Kahuna {

		#region Constructor

		public BattleKahuna() {
			PosAttackMoves.Add( Rebound.Instance );
			bonus[Terrain.Terrest.ToString()] = new AttackBonus(400);
			bonus[Terrain.Terrest.ToString()] = new DefenseBonus(400);
			bonus[UnitDisplacement.Air.ToString()] = new DefenseBonus(400);
		}

		#endregion Constructor
		
	}
}
