
using System;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Referral in the data source
    /// </summary>
	public class ReferralCount : BaseEntityCount<Referral> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ReferralCount () : base( Institutional.DataAccessLayer.Persistance.Instance.GetReferralPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}