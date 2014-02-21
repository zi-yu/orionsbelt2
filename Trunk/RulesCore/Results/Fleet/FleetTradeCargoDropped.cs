using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class FleetTradeCargoDropped : RulesResultItem  {

        #region Ctor & Properties

        public FleetTradeCargoDropped(IFleetInfo src)
    		: base("Fleet '{0}' dropped all it's trade goods.", src.Name)
        {
        }

        public override bool Ok {
	        get { 
		         return false;
	        }
        }

        #endregion Ctor & Properties

    };
}
