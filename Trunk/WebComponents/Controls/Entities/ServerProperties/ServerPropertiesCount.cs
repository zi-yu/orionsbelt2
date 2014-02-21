
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ServerProperties in the data source
    /// </summary>
	public class ServerPropertiesCount : BaseEntityCount<ServerProperties> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ServerPropertiesCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetServerPropertiesPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}