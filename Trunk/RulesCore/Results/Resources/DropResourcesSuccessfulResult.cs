using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// DropResourcesSuccessfulResult result
    /// </summary>
    public class DropResourcesSuccessfulResult : RulesResultItem  {

        #region Ctor & Properties

		public DropResourcesSuccessfulResult(IResourceInfo resource, int quantity)
			: base(string.Format("{0} units of the resource '{1}' were drop successfully.", quantity, resource.Name), quantity.ToString(), resource.Name)
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
