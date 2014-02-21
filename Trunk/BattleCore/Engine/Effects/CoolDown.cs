using DesignPatterns.Attributes;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("c")]
	public class CoolDown: Effect {

		#region Fields

		private static readonly string name = "CoolDown";
		private static readonly string code = "c";

		#endregion Fields

		#region Properties

		/// <summary>
		/// Name of the effect
		/// </summary>
		public override string Name {
			get { return name; }
		}

		/// <summary>
		/// Code to represent the effect
		/// </summary>
		public override string Code {
			get { return code; }
		}

		#endregion Properties

		#region Public

		/// <summary>
		/// Creates an Paralyse Effect instance
		/// </summary>
		/// <param name="args">Owner of this effect (IElement)</param>
		public override object create( object args ) {
			object[] arguments = (object[]) args;
			IElement e = (IElement) arguments[0];

			string[] s = (string[]) arguments[1];
			int tl = int.Parse(s[1]);

			return new CoolDown(e, tl);
		}

		/// <summary>
		/// Resolves the effect at the end of the turn.
		/// </summary>
		/// <returns>True if the effect has ended, false otherside</returns>
		public override bool Resolve(IBattleInfo battleInfo) {
			if (element.Cooldown > 0) {
				--element.Cooldown;

				battleInfo.AddTurnMessage(new CoolDownMessage(battleInfo.Id, battleInfo.CurrentTurn, element.Unit.Name, element.Cooldown, element.Owner.Name));
				element.CanBeMoved = true;
				return false;
			}
			battleInfo.AddTurnMessage(new CoolDownEndedMessage(battleInfo.Id, battleInfo.CurrentTurn, element.Unit.Name, element.Owner.Name)); 
			return true;
		}

		/// <summary>
		/// Converts the cooldown effect into it's string representation
		/// </summary>
		/// <returns>The cooldown effect into it's string representation</returns>
		public override string ToString() {
			return string.Format("c#{0}", TurnsLeft);
		}

		#endregion Public

		#region Constructor

		public CoolDown() { }

		public CoolDown(IElement owner, int turnsLeft)
			: base(owner) {
			this.turnsLeft = turnsLeft;
			owner.CanBeMoved = false;
		}

		#endregion Constructor

	}
}
