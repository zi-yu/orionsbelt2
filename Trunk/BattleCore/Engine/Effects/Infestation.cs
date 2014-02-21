using DesignPatterns.Attributes;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
namespace OrionsBelt.BattleCore {

	[FactoryKey("i")]
	public class Infestation: Effect {

		#region Fields

		private static readonly string name = "Infestation";
		private static readonly string code = "i";
		private readonly int damage;
		private readonly int sourcePlayerId;

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

		/// <summary>
		/// Indicates if this effect can be applied several times
		/// to the same Element. The Default value is false.
		/// </summary>
		public override bool Cumulative {
			get { return true; }
		}

		#endregion Properties

		#region Public

		/// <summary>
		/// Creates an Infestation Effect instance
		/// </summary>
		/// <param name="args">Owner of this effect (IElement)</param>
		public override object create( object args ) {
			object[] arguments = (object[]) args;
			IElement e = (IElement) arguments[0];

			string[] s = (string[]) arguments[1];

			int tl = int.Parse(s[1]);
			int d = int.Parse(s[2]);
			int spi = 0;
			if( s.Length > 3 ) {
				spi = int.Parse(s[3]);
			}

			return new Infestation(e, spi,tl, d);
		}

		/// <summary>
		/// Resolves the effect at the end of the turn.
		/// </summary>
		/// <returns>True if the effect has ended, false otherside</returns>
		public override bool Resolve( IBattleInfo battleInfo ) {
			int defense = element.Unit.Defense;
			int unitsDestroyed = AttackUtils.ResolveDamage(damage, defense, battleInfo, element);

			if( sourcePlayerId > 0 ) {
				IBattlePlayer source = battleInfo.Players[sourcePlayerId];
				battleInfo.BattleStatistics.UpdateStatistics(source, battleInfo.GetPlayer(element.Owner.Owner), element.Unit, unitsDestroyed);
			}

			battleInfo.AddTurnMessage(new InfestationDamageMessage(battleInfo.Id, battleInfo.CurrentTurn, element.Coordinate, unitsDestroyed, TurnsLeft));
			
			return base.Resolve(battleInfo);
		}

		/// <summary>
		/// Converts the infestation effect into it's string representation
		/// </summary>
		/// <returns>The infestation effect into it's string representation</returns>
		public override string ToString() {
			return string.Format("i#{0}#{1}#{2}", TurnsLeft, damage, sourcePlayerId);
		}

		#endregion Public

		#region Constructor

		public Infestation(){}

		public Infestation(IElement target, int sourcePlayerId, int damage)
			: base(target) {
			this.damage = (int)(damage * 0.2d);
			this.sourcePlayerId = sourcePlayerId;
			turnsLeft = 2;
		}

		public Infestation(IElement target, int sourcePlayerId, int turnsLeft, int damage)
			: base(target) {
			this.damage = damage;
			this.turnsLeft = turnsLeft;
			this.sourcePlayerId = sourcePlayerId;
		}


		#endregion Constructor

	}
}
