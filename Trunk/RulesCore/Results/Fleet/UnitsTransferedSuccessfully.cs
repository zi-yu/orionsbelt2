using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class UnitsTransferedSuccessfully : RulesResultItem  {

        #region Ctor & Properties

    	public UnitsTransferedSuccessfully(IFleetInfo src, IFleetInfo dst, string unitName, int quantity)
    		: base("{0} {1} were transfered from fleet '{2}' to fleet '{3}' successfully", quantity.ToString(), unitName, src.Name, dst.Name)
        {
        }

        public override bool Ok {
	        get { 
		         return true;
	        }
        }

        #endregion Ctor & Properties

    };
}
