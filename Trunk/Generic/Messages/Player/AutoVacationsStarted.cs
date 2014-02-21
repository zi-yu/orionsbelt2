using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("AutoVacationsStarted")]
    public class AutoVacationsStarted : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new AutoVacationsStarted(ownerid);
		}

        public override Category Category  {
            get { return Category.Principal; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public AutoVacationsStarted() {}

        public AutoVacationsStarted(int ownerId)
			: base(ownerId) {
			log = "Vacations Auto Started.";
		}

		#endregion Constructor
	}
}
