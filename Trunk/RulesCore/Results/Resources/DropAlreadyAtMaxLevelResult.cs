using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// AlreadyAtMaxLevelResult result
    /// </summary>
    public class DropAlreadyAtMaxLevelResult : RulesResultItem  {

        #region Ctor & Properties

		public DropAlreadyAtMaxLevelResult(IResourceInfo resource)
            : base(string.Format("Could not drop resource {0} because it's already at max level", resource.Name), resource.Name)
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
