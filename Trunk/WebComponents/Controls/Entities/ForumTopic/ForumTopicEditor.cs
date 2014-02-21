
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ForumTopic editor control
    /// </summary>
	public partial class ForumTopicEditor : BaseEntityEditor<ForumTopic> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumTopicEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumTopicPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ForumTopic> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Title</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicTitleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastPost</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicLastPostEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TotalPosts</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicTotalPostsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TotalThreads</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicTotalThreadsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsPrivate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicIsPrivateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ForumRoles</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicForumRolesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Description</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicDescriptionEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ForumTopic> Implementation
		
	};

}