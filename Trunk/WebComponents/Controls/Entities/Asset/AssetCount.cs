
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Asset in the data source
    /// </summary>
	public class AssetCount : BaseEntityCount<Asset> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AssetCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAssetPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}