using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("InfestationMessage")]
	public class InfestationMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new InfestationMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Public

		public override string Translate() {
			string param1 = CoordinateTranslator.Translate(Parameters[0]);
			
			return string.Format(LanguageTranslator.Translate(SubCategory), param1);
		}

		#endregion Public

		#region Constructor

		public InfestationMessage() {}

		public InfestationMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Unit at coordinate {0} was infestacted.";
		}

		#endregion Constructor
	}
}
