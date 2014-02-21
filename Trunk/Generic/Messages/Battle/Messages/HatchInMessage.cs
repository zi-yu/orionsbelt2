using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("HatchInMessage")]
	public class HatchInMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new HatchInMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Public

		public override string Translate() {
			string param0 = CoordinateTranslator.Translate(Parameters[0]);

			return string.Format(LanguageTranslator.Translate(SubCategory), param0, Parameters[1]);
		}

		#endregion Public

		#region Constructor

		public HatchInMessage() { }

		public HatchInMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "Egg in position {0} will hatch on {1} turn(s).";
		}

		#endregion Constructor
	}
}
