
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Tournament in the data source
    /// </summary>
	public class TournamentCount : BaseEntityCount<Tournament> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TournamentCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTournamentPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}