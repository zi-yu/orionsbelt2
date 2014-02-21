namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class InvalidFleetName : RulesResultItem  {

        #region Ctor & Properties

		public InvalidFleetName(string fleetName)
			: base("The name '{0}' is an invalid name for a fleet.", fleetName)
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
