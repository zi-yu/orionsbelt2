
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Interaction in the data source
    /// </summary>
	public class InteractionCount : BaseEntityCount<Interaction> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public InteractionCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetInteractionPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}