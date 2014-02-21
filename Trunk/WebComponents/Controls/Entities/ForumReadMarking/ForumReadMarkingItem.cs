
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ForumReadMarking control renderer
    /// </summary>
	public class ForumReadMarkingItem : BaseEntityItem<ForumReadMarking> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumReadMarkingItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumReadMarkingPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ForumReadMarking> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumReadMarkingId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastRead</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumReadMarkingLastRead () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Player</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumReadMarkingPlayer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Thread</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumReadMarkingThread () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumReadMarkingCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumReadMarkingUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ForumReadMarkingLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ForumReadMarking> Implementation
		
	};

}
