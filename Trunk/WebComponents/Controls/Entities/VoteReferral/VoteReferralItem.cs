
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// VoteReferral control renderer
    /// </summary>
	public class VoteReferralItem : BaseEntityItem<VoteReferral> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public VoteReferralItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetVoteReferralPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<VoteReferral> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ShortName</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralShortName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Url</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralUrl () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ImageUrl</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralImageUrl () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Reward</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralReward () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ClickCount</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralClickCount () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>VoteOrder</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralVoteOrder () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<VoteReferral> Implementation
		
	};

}
