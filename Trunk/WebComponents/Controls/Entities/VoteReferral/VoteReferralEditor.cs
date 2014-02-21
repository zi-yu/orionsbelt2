
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// VoteReferral editor control
    /// </summary>
	public partial class VoteReferralEditor : BaseEntityEditor<VoteReferral> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public VoteReferralEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetVoteReferralPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ShortName</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralShortNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Url</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralUrlEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ImageUrl</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralImageUrlEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Reward</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralRewardEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ClickCount</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralClickCountEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>VoteOrder</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralVoteOrderEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new VoteReferralLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<VoteReferral> Implementation
		
	};

}