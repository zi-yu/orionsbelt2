
using System;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Principal in the data source
    /// </summary>
	public class PrincipalCount : BaseEntityCount<Principal> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalCount () : base( Institutional.DataAccessLayer.Persistance.Instance.GetPrincipalPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}