
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Principal in the data source
    /// </summary>
	public class PrincipalCount : BaseEntityCount<Principal> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}