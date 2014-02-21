
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// CampaignStatus editor control
    /// </summary>
	public partial class CampaignStatusEditor : BaseEntityEditor<CampaignStatus> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public CampaignStatusEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetCampaignStatusPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Level</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Moves</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusMovesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Completed</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusCompletedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Campaign</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusCampaignEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Principal</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusPrincipalEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Battle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LevelTemplate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusLevelTemplateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignStatusLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<CampaignStatus> Implementation
		
	};

}