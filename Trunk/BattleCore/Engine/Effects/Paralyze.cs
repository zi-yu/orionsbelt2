using DesignPatterns.Attributes;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("p")]
	public class Paralyse: Effect {

		#region Fields

		private static readonly string name = "Paralyze";
		private static readonly string code = "p";

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

			return new Paralyse(e, tl);
		}

		/// <summary>
		/// Resolves the effect at the end of the turn.
		/// </summary>
		/// <returns>True if the effect has ended, false otherside</returns>
		public override bool Resolve(IBattleInfo battleInfo) {
			bool ended = base.Resolve(battleInfo);
			if( ended ) {
				element.CanBeMoved = true;
				battleInfo.AddTurnMessage(new ParalysedEndedMessage(battleInfo.Id, battleInfo.CurrentTurn, element.Coordinate));
			}else {
				element.CanBeMoved = false;
				battleInfo.AddTurnMessage(new ParalysedTurnsLeftMessage(battleInfo.Id, battleInfo.CurrentTurn, element.Coordinate, TurnsLeft + 1));
			}

			return ended;
		}

		/// <summary>
		/// Converts the Paralyse effect into it's string representation
		/// </summary>
		/// <returns>The Paralyse effect into it's string representation</returns>
		public override string ToString() {
			return string.Format("p#{0}", TurnsLeft);
		}

		#endregion Public

		#region Constructor

		public Paralyse() { }

		public Paralyse( IElement owner ) 
			: base(owner) {
			turnsLeft = 1;
		}

		public Paralyse( IElement owner, int turnsLeft )
			: base(owner) {
			this.turnsLeft = turnsLeft;
			owner.CanBeMoved = false;
		}

		#endregion Constructor

	}
}
