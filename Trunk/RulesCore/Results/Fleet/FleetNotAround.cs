using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class FleetNotAround : RulesResultItem  {

        #region Ctor & Properties

		public FleetNotAround(IFleetInfo src, IFleetInfo dst)
    		: base("Fleet '{0}' is not close enough from fleet '{1}' to make a unit transfer", src.Name, dst.Name)
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
