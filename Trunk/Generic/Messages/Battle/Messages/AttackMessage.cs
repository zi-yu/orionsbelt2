using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("AttackMessage")]
	public class AttackMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new AttackMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		#region Public

		public override string Translate() {
			string param1 = CoordinateTranslator.Translate(Parameters[0]);
			string param2 = CoordinateTranslator.Translate(Parameters[1]);

			return string.Format(LanguageTranslator.Translate(SubCategory), param1, param2);
		}

		#endregion Public

		public AttackMessage() {}

		public AttackMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Unit at coordinate {0} attacked the unit at the coordinate {1}";
		}

		#endregion Constructor
	}
}
