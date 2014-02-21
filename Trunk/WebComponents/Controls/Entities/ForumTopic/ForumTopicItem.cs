
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ForumTopic control renderer
    /// </summary>
	public class ForumTopicItem : BaseEntityItem<ForumTopic> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumTopicItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumTopicPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Title</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicTitle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastPost</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicLastPost () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TotalPosts</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicTotalPosts () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TotalThreads</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicTotalThreads () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsPrivate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicIsPrivate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ForumRoles</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicForumRoles () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Description</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicDescription () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumTopicLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ForumTopic> Implementation
		
	};

}
