
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of BotHandler in the data source
    /// </summary>
	public class BotHandlerCount : BaseEntityCount<BotHandler> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BotHandlerCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBotHandlerPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}