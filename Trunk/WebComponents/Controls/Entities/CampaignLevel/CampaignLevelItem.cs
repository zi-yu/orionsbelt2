
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// CampaignLevel control renderer
    /// </summary>
	public class CampaignLevelItem : BaseEntityItem<CampaignLevel> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public CampaignLevelItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetCampaignLevelPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BotFleet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelBotFleet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PlayerFleet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelPlayerFleet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Level</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BotName</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelBotName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Campaign</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelCampaign () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new CampaignLevelLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<CampaignLevel> Implementation
		
	};

}
