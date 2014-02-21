using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BuyFiringSquadGeneralSuccessMessage")]
    public class BuyFiringSquadGeneralSuccessMessage : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyFiringSquadGeneralSuccessMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

		#endregion Overriden

		#region Constructor

		public BuyFiringSquadGeneralSuccessMessage() {}

		public BuyFiringSquadGeneralSuccessMessage(int ownerId)
			: base(ownerId) {
			log = "You now have a Firing Squad General at your disposal.";
		}

		#endregion Constructor
	}
}
