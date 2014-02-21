
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PrincipalTournament in the data source
    /// </summary>
	public class PrincipalTournamentCount : BaseEntityCount<PrincipalTournament> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalTournamentCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalTournamentPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}