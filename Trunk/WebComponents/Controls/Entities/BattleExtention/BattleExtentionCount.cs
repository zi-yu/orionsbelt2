
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of BattleExtention in the data source
    /// </summary>
	public class BattleExtentionCount : BaseEntityCount<BattleExtention> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BattleExtentionCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBattleExtentionPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}