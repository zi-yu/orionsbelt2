using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BuyFiringSquadGeneralEndMessage")]
    public class BuyFiringSquadGeneralEndMessage : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyFiringSquadGeneralEndMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

		#endregion Overriden

		#region Constructor

		public BuyFiringSquadGeneralEndMessage() {}

		public BuyFiringSquadGeneralEndMessage(int ownerId)
			: base(ownerId) {
			log = "The contract with the Firing Squad General has expired. Go to the shop in order to renew the contract.";
		}

		#endregion Constructor
	}
}
