using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class ResetCoolDown : ISpecialMove {

		#region Fields

		private static readonly ResetCoolDown coolDown = new ResetCoolDown();

		#endregion Fields

		#region Public

		public static ISpecialMove Instance {
			get { return coolDown; }
		}

		#endregion Public

		#region ISpecialMove Members

		public void ResolveMove(IBattleInfo battleInfo, IElement unit, IElement target) {
			unit.Cooldown = unit.Unit.CoolDown;
		}

		#endregion

		#region Constructor

		private ResetCoolDown() { }

		#endregion Constructor

	}
}
