
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of BotCredential in the data source
    /// </summary>
	public class BotCredentialCount : BaseEntityCount<BotCredential> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BotCredentialCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBotCredentialPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}