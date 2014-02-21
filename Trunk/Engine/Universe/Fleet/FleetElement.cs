using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Common {
	public class FleetElement : IFleetElement {

		#region Fields

		private IUnitInfo unitInfo;
		private int quantity;

		#endregion Fields

		#region Properties

		/// <summary>
		/// Object that represents the unit
		/// </summary>
		public IUnitInfo UnitInfo {
			get { return unitInfo; }
			set { unitInfo = value; }
		}

		/// <summary>
		/// Name of the unit inside the element
		/// </summary>
		public string Name {
			get { return unitInfo.Name; }
		}

		/// <summary>
		/// Quanity of element
		/// </summary>
		public int Quantity {
			get { return quantity; }
			set { quantity = value; }
		}

		#endregion Properties

		#region Public

		public override string ToString() {
			return string.Format("{0}-{1};",UnitInfo.Code,Quantity);
		}

		#endregion Public

		#region Constructor

		public FleetElement( string unitName, int quantity ) {
			if( unitName.Length <= 3 ) {
				UnitInfo = FleetInfo.GetUnitByShortName(unitName);
			}else {
				UnitInfo = FleetInfo.GetUnit(unitName);	
			}
			
			Quantity = quantity;
		}

		public FleetElement( IUnitInfo unit, int quantity ) {
			UnitInfo = unit;
			Quantity = quantity;
		}

		#endregion Constructor
	}
}
