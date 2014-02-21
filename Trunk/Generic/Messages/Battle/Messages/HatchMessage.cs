using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("HatchMessage")]
	public class HatchMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new HatchMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Public

		public override string Translate() {
			string param0 = CoordinateTranslator.Translate(Parameters[0]);

			return string.Format(LanguageTranslator.Translate(SubCategory), param0, Parameters[1]);
		}

		#endregion Public

		#region Constructor

		public HatchMessage() { }

		public HatchMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "Egg in position {0} hatched. {1} Maggots were born.";
		}

		#endregion Constructor
	}
}
