
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PlayerBattleInformation in the data source
    /// </summary>
	public class PlayerBattleInformationCount : BaseEntityCount<PlayerBattleInformation> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerBattleInformationCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerBattleInformationPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}