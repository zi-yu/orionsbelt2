
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PrincipalStats in the data source
    /// </summary>
	public class PrincipalStatsCount : BaseEntityCount<PrincipalStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalStatsCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalStatsPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}