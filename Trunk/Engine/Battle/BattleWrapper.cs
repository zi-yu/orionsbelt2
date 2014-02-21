using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine {
	public class BattleWrapper : IBattle {

		#region Fields

		private readonly BattleOwner battleOwner = new BattleOwner();
		private readonly Core.Battle battle;

		#endregion
		#region Properties

		public Core.Battle Storage {
			get {
				return battle;
			}
		}
				
		#endregion Properties

		#region Public

		/// <summary>
		/// Gets the battle owner represented by the passed player
		/// </summary>
		/// <param name="p">PlayerBattleInformation that represents the user to convert</param>
		/// <returns>IBattle owner that represents it</returns>
		public IBattleOwner GetBattleOwner(Core.PlayerBattleInformation p) {
			return battleOwner.Get(p);
		}

		#endregion Public

		#region Constructor

		public BattleWrapper(Core.Battle battle) {
			this.battle = battle;
		}
		
		#endregion


	}
}
