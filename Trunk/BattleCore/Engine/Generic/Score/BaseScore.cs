using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	public abstract class BaseScore: IScore  {

		#region Fields

		protected IBattleInfo battleInfo;

		#endregion Fields

		#region Public

		/// <summary>
		/// Calculates the partial score, the score before the game ends
		/// </summary>
		/// <param name="allPlayers">Other Players in combat</param>
		/// <returns>The total value with the modifiers applied</returns>
		public virtual void SetPlayersScore( List<IBattlePlayer> allPlayers ) {
			foreach( IBattlePlayer current in allPlayers) {
				int total = 0;
				Dictionary<IUnitInfo, int> unitsDestroyed = battleInfo.BattleStatistics.GetDestroyedUnits(current);
				foreach( KeyValuePair<IUnitInfo, int> pair in unitsDestroyed ) {
					total += pair.Key.UnitValue*pair.Value;
				}
				current.WinScore = total;
			}
		}

		#endregion Public

		#region Constructor

		public BaseScore() {}

		public BaseScore( IBattleInfo battleInfo ) {
			this.battleInfo = battleInfo;
		}

		#endregion Constructor

		#region IFactory Members

		public abstract object create(object args);

		#endregion IFactory Members

	}
}
