
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Necessity in the data source
    /// </summary>
	public class NecessityCount : BaseEntityCount<Necessity> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public NecessityCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetNecessityPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}