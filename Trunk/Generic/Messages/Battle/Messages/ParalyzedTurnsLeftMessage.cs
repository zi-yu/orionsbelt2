using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("ParalysedTurnsLeftMessage")]
	public class ParalysedTurnsLeftMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new ParalysedTurnsLeftMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Public

		public override string Translate() {
			string param1 = CoordinateTranslator.Translate(Parameters[0]);

			return string.Format(LanguageTranslator.Translate(SubCategory), param1, Parameters[1]);
		}

		#endregion Public

		#region Constructor

		public ParalysedTurnsLeftMessage() { }

		public ParalysedTurnsLeftMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Turns remaing for the Paralyse to end on the unit at coordinate {0}: {1} turns.";
		}

		#endregion Constructor
	}
}
