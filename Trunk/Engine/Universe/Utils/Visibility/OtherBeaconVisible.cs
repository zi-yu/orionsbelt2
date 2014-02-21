using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	public class OtherBeaconVisible : UniverseVisibility {
		#region Fields

		private readonly int level;
		private readonly IPlayer owner;

		#endregion Fields

		#region Properties

		public override int Level {
			get {return level;}
		}

		public override int ImportanceLevel {
			get {return 4;}
		}

		public IPlayer Owner {
			get { return owner; }
		}

		#endregion Properties

		#region Constructor

		public OtherBeaconVisible(int level, IPlayer owner) {
			this.level = level;
			this.owner = owner;
		}

		#endregion Constructor
	}
}