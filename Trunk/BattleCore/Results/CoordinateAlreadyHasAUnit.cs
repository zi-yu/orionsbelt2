using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class CoordinateAlreadyHasAUnit : ResultItem {

		#region Constructor

		public CoordinateAlreadyHasAUnit(IBattleCoordinate coordinate) {
			parameters = new string[] { coordinate.ToString() };
			log = "Coordinate {0} already has a unit.";
		}

		#endregion Constructor


	}
}
