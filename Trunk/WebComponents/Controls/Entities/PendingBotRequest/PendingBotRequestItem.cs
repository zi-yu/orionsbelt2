
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PendingBotRequest control renderer
    /// </summary>
	public class PendingBotRequestItem : BaseEntityItem<PendingBotRequest> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PendingBotRequestItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPendingBotRequestPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BotName</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestBotName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Xml</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestXml () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BattleId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestBattleId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BotId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestBotId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Code</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestCode () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PendingBotRequestLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PendingBotRequest> Implementation
		
	};

}
