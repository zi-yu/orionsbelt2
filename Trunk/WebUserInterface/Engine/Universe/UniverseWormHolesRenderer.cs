
namespace OrionsBelt.WebUserInterface.Engine {

	public class UniverseWormHolesRenderer : UniverseWormHolesBaseRenderer {

		#region Fields

		private static readonly UniverseWormHolesRenderer instance = new UniverseWormHolesRenderer();

		#endregion Fields

		#region Properties

		public static UniverseWormHolesRenderer Instance {
			get { return instance; }
		}

		#endregion Properties

		#region Constructor

		private UniverseWormHolesRenderer() : base(13, 17) {
			xyWormHoleMap = new int[] { 10, 258 };
		}

		#endregion Constructor

	}

}
