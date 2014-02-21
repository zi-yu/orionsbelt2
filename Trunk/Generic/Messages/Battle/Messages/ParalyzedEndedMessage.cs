using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("ParalysedEndedMessage")]
	public class ParalysedEndedMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new ParalysedEndedMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Public

		public override string Translate() {
			string param1 = CoordinateTranslator.Translate(Parameters[0]);

			return string.Format(LanguageTranslator.Translate(SubCategory), param1);
		}

		#endregion Public

		#region Constructor

		public ParalysedEndedMessage() { }

		public ParalysedEndedMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Unit at coordinate {0} is not Paralysed anymore.";
		}

		#endregion Constructor
	}
}
