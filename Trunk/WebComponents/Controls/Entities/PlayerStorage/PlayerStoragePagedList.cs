using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a paged collection of PlayerStorage 
    /// </summary>
	public class PlayerStoragePagedList : BasePagedList<PlayerStorage> {
		
		#region BasePagedList<PlayerStorage> Implementation
		
		/// <summary>
        /// The current persistance object
        /// </summary>
		protected override IPersistance<PlayerStorage> Persistance {
			get { 
				return OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerStoragePersistance ();
			}
		}
		
		/// <summary>
        /// The current entity name
        /// </summary>
		protected override string EntityName { 
			get { 
				return "PlayerStorage";
			}
		}
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			PlayerStorageItem entity = new PlayerStorageItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"59\"> Listing <i>") );
			Controls.Add( new PlayerStorageCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>PlayerStorage</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>Name</th>") );
			Controls.Add( new LiteralControl("<th>LastProcessedTick</th>") );
			Controls.Add( new LiteralControl("<th>IntrinsicLimits</th>") );
			Controls.Add( new LiteralControl("<th>Score</th>") );
			Controls.Add( new LiteralControl("<th>AllianceRank</th>") );
			Controls.Add( new LiteralControl("<th>Race</th>") );
			Controls.Add( new LiteralControl("<th>HomePlanetId</th>") );
			Controls.Add( new LiteralControl("<th>PirateRanking</th>") );
			Controls.Add( new LiteralControl("<th>BountyRanking</th>") );
			Controls.Add( new LiteralControl("<th>MerchantRanking</th>") );
			Controls.Add( new LiteralControl("<th>GladiatorRanking</th>") );
			Controls.Add( new LiteralControl("<th>ColonizerRanking</th>") );
			Controls.Add( new LiteralControl("<th>IntrinsicQuantities</th>") );
			Controls.Add( new LiteralControl("<th>PlanetLevel</th>") );
			Controls.Add( new LiteralControl("<th>QuestContextLevel</th>") );
			Controls.Add( new LiteralControl("<th>Active</th>") );
			Controls.Add( new LiteralControl("<th>Avatar</th>") );
			Controls.Add( new LiteralControl("<th>UltimateWeaponLevel</th>") );
			Controls.Add( new LiteralControl("<th>Services</th>") );
			Controls.Add( new LiteralControl("<th>UltimateWeaponCooldown</th>") );
			Controls.Add( new LiteralControl("<th>ActivatedInTick</th>") );
			Controls.Add( new LiteralControl("<th>IsGeneralActive</th>") );
			Controls.Add( new LiteralControl("<th>GeneralId</th>") );
			Controls.Add( new LiteralControl("<th>GeneralName</th>") );
			Controls.Add( new LiteralControl("<th>GeneralFriendlyName</th>") );
			Controls.Add( new LiteralControl("<th>IsPrimary</th>") );
			Controls.Add( new LiteralControl("<th>IsOnVacations</th>") );
			Controls.Add( new LiteralControl("<th>TotalPosts</th>") );
			Controls.Add( new LiteralControl("<th>Signature</th>") );
			Controls.Add( new LiteralControl("<th>ForumRole</th>") );
			Controls.Add( new LiteralControl("<th>Principal</th>") );
			Controls.Add( new LiteralControl("<th>Alliance</th>") );
			Controls.Add( new LiteralControl("<th>Stats</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new PlayerStorageDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageName () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageLastProcessedTick () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageIntrinsicLimits () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageScore () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageAllianceRank () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageRace () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageHomePlanetId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStoragePirateRanking () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageBountyRanking () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageMerchantRanking () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageGladiatorRanking () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageColonizerRanking () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageIntrinsicQuantities () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStoragePlanetLevel () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageQuestContextLevel () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageActive () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageAvatar () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageUltimateWeaponLevel () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageServices () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageUltimateWeaponCooldown () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageActivatedInTick () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageIsGeneralActive () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageGeneralId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageGeneralName () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageGeneralFriendlyName () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageIsPrimary () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageIsOnVacations () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageTotalPosts () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageSignature () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageForumRole () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStoragePrincipal () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageAlliance () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageStats () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlayerStorageDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BasePagedList<PlayerStorage> Implementation
		
	};

}