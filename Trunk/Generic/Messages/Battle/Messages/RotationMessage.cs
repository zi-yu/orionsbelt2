using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RotationMessage")]
	public class RotationMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new RotationMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Public

		public override string Translate() {
			string param1 = CoordinateTranslator.Translate(Parameters[0]);
			string param2 = PositionTranslator.Translate(Parameters[1]);

			return string.Format(LanguageTranslator.Translate(SubCategory), param1, param2);
		}

		#endregion Public

		#region Constructor

		public RotationMessage() {}

		public RotationMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Unit at coordinate {0} made a {1} rotation.";
		}

		#endregion Constructor
	}
}
