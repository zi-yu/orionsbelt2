
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Battle in the data source
    /// </summary>
	public class BattleCount : BaseEntityCount<Battle> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BattleCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBattlePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}