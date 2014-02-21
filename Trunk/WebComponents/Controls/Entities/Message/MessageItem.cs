
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Message control renderer
    /// </summary>
	public class MessageItem : BaseEntityItem<Message> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public MessageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetMessagePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Message> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Parameters</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageParameters () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Category</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageCategory () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SubCategory</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageSubCategory () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>OwnerId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageOwnerId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Date</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Extended</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageExtended () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TickDeadline</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageTickDeadline () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Message> Implementation
		
	};

}
