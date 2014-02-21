using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[NoAutoRegister]
	public abstract class Effect : IEffect {

		#region Fields

		protected int turnsLeft;
		protected IElement element;
		private bool resolved = false;

		#endregion Fields

		#region Properties

		/// <summary>
		/// Code to represent the effect
		/// </summary>
		public IElement Element {
			get { return element; }
		}

		/// <summary>
		/// Indicates if this effect can be applied several times
		/// to the same Element. The Default value is false.
		/// </summary>
		public virtual bool Cumulative { 
			get{ return false;}
		}

		/// <summary>
		/// Indicates if this effect was resolved 
		/// at the end of the battle
		/// </summary>
		public bool Resolved {
			get { return resolved; }
			set { resolved = value; }
		}

		/// <summary>
		/// Indicates if this effect has ended
		/// </summary>
		public bool Ended {
			get { return TurnsLeft <= 0; }
		}

		#endregion Properties

		#region Public

		/// <summary>
		/// Resolves the effect at the end of the turn.
		/// </summary>
		/// <returns>True if the effect has ended, false otherside</returns>
		public virtual bool Resolve( IBattleInfo battleInfo ) {
			if( Ended ) {
                Resolved = true;
			}
			--turnsLeft;
            return Resolved;
		}

		/// <summary>
		/// Turns left for the event to disappear
		/// </summary>
		public int TurnsLeft {
			get { return turnsLeft; }
		}

		#endregion Public

		#region Abstract Members

		/// <summary>
		/// Name of the effect
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// Code to represent the effect
		/// </summary>
		public abstract string Code { get; }

		/// <summary>
		/// Creates an effect object
		/// </summary>
		/// <param name="args"></param>
		public abstract object create( object args );

		#endregion Abstract Members

		#region Constructor

		public Effect() {}

		public Effect( IElement element ) {
			this.element = element;
		}

		#endregion Constructor

	}
}
