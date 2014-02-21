
using System;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Server in the data source
    /// </summary>
	public class ServerCount : BaseEntityCount<Server> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ServerCount () : base( Institutional.DataAccessLayer.Persistance.Instance.GetServerPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}