
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PendingBotRequest editor control
    /// </summary>
	public partial class PendingBotRequestEditor : BaseEntityEditor<PendingBotRequest> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PendingBotRequestEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPendingBotRequestPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PendingBotRequest> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BotName</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestBotNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Xml</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestXmlEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BattleId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestBattleIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BotId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestBotIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Code</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestCodeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PendingBotRequest> Implementation
		
	};

}