
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of BattleStats in the data source
    /// </summary>
	public class BattleStatsCount : BaseEntityCount<BattleStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BattleStatsCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBattleStatsPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}