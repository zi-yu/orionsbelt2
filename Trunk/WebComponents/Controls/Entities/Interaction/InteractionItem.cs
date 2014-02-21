
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Interaction control renderer
    /// </summary>
	public class InteractionItem : BaseEntityItem<Interaction> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public InteractionItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetInteractionPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Interaction> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Source</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionSource () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Target</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionTarget () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Response</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionResponse () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ResponseExtension</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionResponseExtension () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>InteractionContext</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionInteractionContext () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Resolved</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionResolved () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SourceAditionalData</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionSourceAditionalData () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TargetAditionalData</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionTargetAditionalData () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SourceType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionSourceType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TargetType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionTargetType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Interaction> Implementation
		
	};

}
