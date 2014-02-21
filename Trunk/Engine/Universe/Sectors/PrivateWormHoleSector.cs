using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("PrivateWormHoleSector")]
	public class PrivateWormHoleSector : Sector {

		#region Fields

		private static readonly string type = "PrivateWormHoleSector";
		
		#endregion Fields

		#region Properties

		public override string Type {
			get { return type; }
		}

		public override bool IsStatic {
			get { return true; }
			set { }
		}

		public override bool IsConstructing {
			get { return false; }
			set {}
		}

		public override string DisplayTypeShort {
			get { return "pw"; }
		}
		
		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new PrivateWormHoleSector(sectorStorage);
		}

		#endregion Private

		#region Public

		public override bool IsDirty {
			get { return false; }
			set { }
		}

		#endregion Public

		#region Constructor

		public PrivateWormHoleSector(){}

		public PrivateWormHoleSector(Coordinate system, Coordinate sector, int level)
			: base(system, sector, level) {
		}

		public PrivateWormHoleSector( SectorStorage sectorStorage ) 
			: base(sectorStorage) 
		{
		}

		#endregion Constructor

	}
}
