
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of VoteReferral in the data source
    /// </summary>
	public class VoteReferralCount : BaseEntityCount<VoteReferral> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public VoteReferralCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetVoteReferralPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}