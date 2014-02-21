using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
	/// DropSomeAlreadyAtMaxLevelResult result
    /// </summary>
    public class DropSomeAlreadyAtMaxLevelResult : RulesResultItem  {

        #region Ctor & Properties

		public DropSomeAlreadyAtMaxLevelResult(IResourceInfo resource, int quantity)
			: base(string.Format("Only {0} units of the resource '{1}' were drop because it's already at maximum quantity.", quantity, resource.Name), quantity.ToString(), resource.Name)
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
