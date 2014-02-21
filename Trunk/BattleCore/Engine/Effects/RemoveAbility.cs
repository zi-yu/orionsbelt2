using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("r")]
	public class RemoveAbility: Effect {

		#region Fields

		private static readonly string name = "RemoveAbility";
		private static readonly string code = "t";

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
		/// Creates an removeAbility Effect instance
		/// </summary>
		/// <param name="args">Owner of this effect (IElement)</param>
		public override object create( object args ) {
			object[] arguments = (object[]) args;
			IElement e = (IElement) arguments[0];

			string[] s = (string[]) arguments[1];
			int tl = int.Parse(s[1]);

			return new RemoveAbility(e, tl);
		}

		/// <summary>
		/// Resolves the effect at the end of the turn.
		/// </summary>
		/// <returns>True if the effect has ended, false otherside</returns>
		public override bool Resolve(IBattleInfo battleInfo) {
			bool ended = base.Resolve(battleInfo);
			if( ended ) {
				element.CanUseSpecialAbilities = true;	
			}else {
				element.CanUseSpecialAbilities = false;
			}

			return ended;
		}

		/// <summary>
		/// Converts the removeAbility effect into it's string representation
		/// </summary>
		/// <returns>The removeAbility effect into it's string representation</returns>
		public override string ToString() {
			return string.Format("r#{0}", TurnsLeft);
		}

		#endregion Public

		#region Constructor

		public RemoveAbility() { }

		public RemoveAbility( IElement owner ) 
			: base(owner) {
			turnsLeft = 1;
		}

		public RemoveAbility(IElement owner, int turnsLeft)
			: base(owner) {
			this.turnsLeft = turnsLeft;
			owner.CanUseSpecialAbilities = false;
		}

		#endregion Constructor

	}
}
