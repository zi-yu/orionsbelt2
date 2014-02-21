
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// CampaignLevel editor control
    /// </summary>
	public partial class CampaignLevelEditor : BaseEntityEditor<CampaignLevel> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public CampaignLevelEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetCampaignLevelPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<CampaignLevel> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BotFleet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelBotFleetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PlayerFleet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelPlayerFleetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Level</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BotName</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelBotNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Campaign</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelCampaignEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<CampaignLevel> Implementation
		
	};

}