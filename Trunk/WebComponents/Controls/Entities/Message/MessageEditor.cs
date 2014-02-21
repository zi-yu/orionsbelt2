
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Message editor control
    /// </summary>
	public partial class MessageEditor : BaseEntityEditor<Message> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public MessageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetMessagePersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Parameters</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageParametersEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Category</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageCategoryEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SubCategory</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageSubCategoryEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>OwnerId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageOwnerIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Date</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Extended</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageExtendedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TickDeadline</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageTickDeadlineEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MessageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Message> Implementation
		
	};

}