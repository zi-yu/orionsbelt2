using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RemoveAbilityMessage")]
	public class RemoveAbilityMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new RemoveAbilityMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Public

		public override string Translate() {
			string param1 = CoordinateTranslator.Translate(Parameters[0]);

			return string.Format(LanguageTranslator.Translate(SubCategory), param1);
		}

		#endregion Public

		#region Constructor

		public RemoveAbilityMessage() { }

		public RemoveAbilityMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "Unit at coordinate {0} lost all abilities.";
		}

		#endregion Constructor
	}
}
