namespace OrionsBelt.WebUserInterface.Engine {

	public class UniverseWormHolesMapRenderer : UniverseWormHolesBaseRenderer {

		#region Fields

		private static readonly UniverseWormHolesMapRenderer instance = new UniverseWormHolesMapRenderer();
		
		#endregion Fields 

		#region Properties

		public static UniverseWormHolesMapRenderer Instance {
			get { return instance; }
		}

		#endregion Properties

		#region Constructor

		private UniverseWormHolesMapRenderer() : base(11, 17){
			xyWormHoleMap = new int[] { 3, 3 };
		}

		#endregion Constructor

	}

}
