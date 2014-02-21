using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[NoAutoRegister]
	public abstract class UltimateSectorBase : Sector {

		#region Fields

		private int ultimateLevel;
		
		#endregion Fields

		#region Properties

		public override bool IsStatic {
			get { return true; }
			set { }
		}

		public override bool IsConstructing {
			get { return false; }
			set {}
		}

		public int UltimateLevel {
			get { return ultimateLevel; }
			set { ultimateLevel = value; }
		}

		#endregion Properties

		#region Public

		public override bool IsDirty {
			get { return false; }
			set { }
		}

		public static int AllianceAvailableLevel {
			get { return 7; }
		}

		#endregion Public

		#region IBackToStorage<SectorStorage> Members

		public override void UpdateStorage() {
			base.UpdateStorage();
			storage.AdditionalInformation = UltimateLevel.ToString();
			IsDirty = false;
		}

		#endregion IBackToStorage<SectorStorage> Members

		#region Constructor

		public UltimateSectorBase() { }

		public UltimateSectorBase(IPlayer owner, SectorCoordinate coordinate, int level)
            : base(coordinate.System, coordinate.Sector, level){
            this.owner = owner;
			UltimateLevel = owner.UltimateWeaponLevel;
		}

		public UltimateSectorBase(SectorStorage sectorStorage) 
			: base(sectorStorage) 
		{}

		#endregion Constructor

	}
}
