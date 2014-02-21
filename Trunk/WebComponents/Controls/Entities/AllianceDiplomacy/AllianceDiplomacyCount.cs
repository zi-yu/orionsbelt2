
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of AllianceDiplomacy in the data source
    /// </summary>
	public class AllianceDiplomacyCount : BaseEntityCount<AllianceDiplomacy> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AllianceDiplomacyCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAllianceDiplomacyPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}