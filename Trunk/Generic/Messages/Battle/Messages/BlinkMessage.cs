using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BlinkMessage")]
	public class BlinkMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new BlinkMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Public

		public override string Translate() {
			string param2 = CoordinateTranslator.Translate(Parameters[2]);
			string param3 = CoordinateTranslator.Translate(Parameters[3]);

			return string.Format(LanguageTranslator.Translate(SubCategory), Parameters[0], Parameters[1], param2, param3);
		}

		#endregion Public

		#region Constructor

		public BlinkMessage() {}

		public BlinkMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "{0} {1} blinked from coordinate {2} to coordinate {3}.";
		}

		#endregion Constructor
	}
}
