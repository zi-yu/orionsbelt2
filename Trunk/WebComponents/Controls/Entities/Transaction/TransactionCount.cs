
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Transaction in the data source
    /// </summary>
	public class TransactionCount : BaseEntityCount<Transaction> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TransactionCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTransactionPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}