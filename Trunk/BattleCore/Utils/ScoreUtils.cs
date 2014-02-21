using DesignPatterns;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	internal static class ScoreUtils {
		
		#region Fields

		private static readonly FactoryContainer container = new FactoryContainer(typeof(BaseScore));
		
		#endregion

		#region Public

		public static IScore GetScore( IBattleInfo battleInfo ) {
			string battleMode = string.Format("{0}Score", battleInfo.BattleMode);
			return (IScore)container.create(battleMode, battleInfo );
		}

		#endregion Public

	}
}
