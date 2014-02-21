
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Interaction editor control
    /// </summary>
	public partial class InteractionEditor : BaseEntityEditor<Interaction> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public InteractionEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetInteractionPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Source</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionSourceEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Target</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionTargetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Type</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Response</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionResponseEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ResponseExtension</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionResponseExtensionEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>InteractionContext</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionInteractionContextEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Resolved</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionResolvedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SourceAditionalData</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionSourceAditionalDataEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TargetAditionalData</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionTargetAditionalDataEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SourceType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionSourceTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TargetType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionTargetTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InteractionLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Interaction> Implementation
		
	};

}