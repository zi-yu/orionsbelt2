using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine.Universe {
	public class UniverseArea {

		#region Fields

		private readonly Coordinate lowerCoordinate;
		private readonly Coordinate upperCoordinate;
		private readonly int level;

		#endregion Fields

		#region Properties

		public int Level {
			get { return level; }
		}
		
		#endregion Properties

		#region Public

		public bool ContainsCoordinate(Coordinate coordinate ) {
			return coordinate.IsInLimits(lowerCoordinate, upperCoordinate);
		}

		#endregion Public

		#region Constructor

		public UniverseArea(Coordinate lowerCoordinate, Coordinate upperCoordinate, int level) {
			this.lowerCoordinate = lowerCoordinate;
			this.upperCoordinate = upperCoordinate;
			this.level = level;
			
		}

		public UniverseArea(int x1, int y1, int x2, int y2, int level) {
			lowerCoordinate = new Coordinate(x1,y1);
			upperCoordinate = new Coordinate(x2, y2);
			this.level = level;
		}

		#endregion Constructor

	}
}
