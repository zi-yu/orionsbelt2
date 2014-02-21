
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ForumPost editor control
    /// </summary>
	public partial class ForumPostEditor : BaseEntityEditor<ForumPost> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumPostEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumPostPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ForumPost> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumPostIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Text</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumPostTextEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Thread</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumPostThreadEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumPostOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumPostCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumPostUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumPostLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ForumPost> Implementation
		
	};

}