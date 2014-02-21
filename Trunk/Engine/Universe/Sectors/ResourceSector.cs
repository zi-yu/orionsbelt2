using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("ResourceSector")]
	public class ResourceSector : Sector{

		#region Fields

		//private readonly static Random random = new Random((int)DateTime.Now.Ticks);
		private static readonly string type = "ResourceSector";
		
		#endregion Fields

		#region Properties

		public override string Type {
			get { return type; }
		}

		public override string DisplayTypeShort {
			get { return "r"; }
		}

		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new ResourceSector(sectorStorage);
		}

		#endregion Private

		#region Public

		public override void AddCelestialBody(ICelestialBody celestialBody) { }

		#endregion Public

		#region IBackToStorage<SectorStorage> Members

		public override void UpdateStorage() {
			base.UpdateStorage();
			if ( Resource != null ) {
			    storage.AdditionalInformation = string.Format("{0};{1}", Resource.Resource.Name, Resource.Quantity);
			}else {
			    storage.AdditionalInformation = string.Empty;
			}
		}

		public override bool IsDirty {
			get { return false; }
			set { }
		}

		#endregion IBackToStorage<SectorStorage> Members

		#region Constructor

		public ResourceSector() {}

		public ResourceSector(Coordinate system, Coordinate sector, int level)
			: base(system, sector, level) {
			Resource = new ResourceQuantity();
		}

		public ResourceSector(SectorStorage sectorStorage) 
		    : base(sectorStorage) 
		{
		    string addInfo = sectorStorage.AdditionalInformation;
		    if (!string.IsNullOrEmpty(addInfo)) {
		        string[] resourceStr = addInfo.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		        IResourceInfo resourceInfo = RulesUtils.GetResource(resourceStr[0]);
		        int quantity = int.Parse(resourceStr[1]);
		        Resource = new ResourceQuantity(resourceInfo, quantity);
		    }
			isDirty = false;
		}

		#endregion Constructor

	}
}
