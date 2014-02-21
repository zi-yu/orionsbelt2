using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a paged collection of CampaignLevel 
    /// </summary>
	public class CampaignLevelPagedList : BasePagedList<CampaignLevel> {
		
		#region BasePagedList<CampaignLevel> Implementation
		
		/// <summary>
        /// The current persistance object
        /// </summary>
		protected override IPersistance<CampaignLevel> Persistance {
			get { 
				return OrionsBelt.DataAccessLayer.Persistance.Instance.GetCampaignLevelPersistance ();
			}
		}
		
		/// <summary>
        /// The current entity name
        /// </summary>
		protected override string EntityName { 
			get { 
				return "CampaignLevel";
			}
		}
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			CampaignLevelItem entity = new CampaignLevelItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"10\"> Listing <i>") );
			Controls.Add( new CampaignLevelCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>CampaignLevel</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>BotFleet</th>") );
			Controls.Add( new LiteralControl("<th>PlayerFleet</th>") );
			Controls.Add( new LiteralControl("<th>Level</th>") );
			Controls.Add( new LiteralControl("<th>BotName</th>") );
			Controls.Add( new LiteralControl("<th>Campaign</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new CampaignLevelDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelBotFleet () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelPlayerFleet () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelLevel () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelBotName () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelCampaign () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new CampaignLevelDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BasePagedList<CampaignLevel> Implementation
		
	};

}