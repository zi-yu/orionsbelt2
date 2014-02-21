
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ForumThread editor control
    /// </summary>
	public partial class ForumThreadEditor : BaseEntityEditor<ForumThread> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumThreadEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumThreadPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ForumThread> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Title</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadTitleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TotalViews</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadTotalViewsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TotalReplies</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadTotalRepliesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Topic</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadTopicEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumThreadLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ForumThread> Implementation
		
	};

}