using DesignPatterns.Attributes;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("h")]
	public class Hatch : Effect {

		#region Fields

		private static readonly string name = "Hatch";
		private static readonly string code = "h";

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
		/// Creates an Hatch Effect instance
		/// </summary>
		/// <param name="args">Owner of this effect (IElement)</param>
		public override object create( object args ) {
			object[] arguments = (object[]) args;
			IElement e = (IElement) arguments[0];

			string[] s = (string[]) arguments[1];
			int tl = int.Parse(s[1]);

			return new Hatch(e, tl);
		}

		/// <summary>
		/// Resolves the effect at the end of the turn.
		/// </summary>
		/// <returns>True if the effect has ended, false otherside</returns>
		public override bool Resolve(IBattleInfo battleInfo) {
			bool ended = base.Resolve(battleInfo);
			if (ended) {
				element.Unit = Unit.Create("m");
				element.Quantity = battleInfo.GetTotalUnitQuantity(element.Owner) / 15;
				element.RemainingDefense = element.Unit.Defense;
				battleInfo.AddTurnMessage(new HatchMessage(battleInfo.Id, battleInfo.CurrentTurn, element.Coordinate, element.Quantity));
			}else {
				battleInfo.AddTurnMessage(new HatchInMessage(battleInfo.Id, battleInfo.CurrentTurn, element.Coordinate, turnsLeft));
			}

			return ended;
		}

		/// <summary>
		/// Converts the cooldown effect into it's string representation
		/// </summary>
		/// <returns>The cooldown effect into it's string representation</returns>
		public override string ToString() {
			return string.Format("h#{0}", TurnsLeft);
		}

		#endregion Public

		#region Constructor

        public Hatch() { }

		public Hatch(IElement owner)
			:base(owner) {
			turnsLeft = 4;
		}

		public Hatch(IElement owner, int turnsLeft)
			: base(owner) {
			this.turnsLeft = turnsLeft;
		}

		#endregion Constructor

	}
}
