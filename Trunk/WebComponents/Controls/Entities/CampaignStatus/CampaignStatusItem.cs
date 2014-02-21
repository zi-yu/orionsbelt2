
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// CampaignStatus control renderer
    /// </summary>
	public class CampaignStatusItem : BaseEntityItem<CampaignStatus> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public CampaignStatusItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetCampaignStatusPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<CampaignStatus> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Level</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Moves</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusMoves () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Completed</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusCompleted () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Campaign</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusCampaign () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Principal</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusPrincipal () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Battle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LevelTemplate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusLevelTemplate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<CampaignStatus> Implementation
		
	};

}
