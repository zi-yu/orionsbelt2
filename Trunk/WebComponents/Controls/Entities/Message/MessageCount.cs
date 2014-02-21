
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Message in the data source
    /// </summary>
	public class MessageCount : BaseEntityCount<Message> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public MessageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetMessagePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}