using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("ArenaSector")]
	public class ArenaSector : Sector {

		#region Fields

		private static readonly string type = "ArenaSector";
		
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
			get { return "a"; }
		}

		public ArenaStorage Arena {
			get {
				if (Storage != null && Storage.Arenas.Count > 0 ) {
					return Storage.Arenas[0];
				}
				return null;
			}
		}
		
		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new ArenaSector(sectorStorage);
		}

		#endregion Private

		#region Public

		public override bool IsDirty {
			get { return false; }
			set { }
		}

		#endregion Public

		#region Constructor

		public ArenaSector(){}

		public ArenaSector(Coordinate system, Coordinate sector, int level)
			: base(system, sector, level) {
		}

        public ArenaSector(SectorStorage sectorStorage) 
			: base(sectorStorage) 
		{
			
		}

		#endregion Constructor

	}
}
