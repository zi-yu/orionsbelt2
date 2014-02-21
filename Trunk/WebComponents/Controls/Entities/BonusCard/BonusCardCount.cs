
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of BonusCard in the data source
    /// </summary>
	public class BonusCardCount : BaseEntityCount<BonusCard> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BonusCardCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBonusCardPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}