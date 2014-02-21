
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlayerStorage editor control
    /// </summary>
	public partial class PlayerStorageEditor : BaseEntityEditor<PlayerStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PlayerStorage> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastProcessedTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageLastProcessedTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IntrinsicLimits</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIntrinsicLimitsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Score</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageScoreEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>AllianceRank</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageAllianceRankEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Race</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageRaceEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HomePlanetId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageHomePlanetIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PirateRanking</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStoragePirateRankingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BountyRanking</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageBountyRankingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MerchantRanking</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageMerchantRankingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>GladiatorRanking</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageGladiatorRankingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ColonizerRanking</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageColonizerRankingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IntrinsicQuantities</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIntrinsicQuantitiesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PlanetLevel</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStoragePlanetLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>QuestContextLevel</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageQuestContextLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Active</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageActiveEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Avatar</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageAvatarEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UltimateWeaponLevel</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageUltimateWeaponLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Services</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageServicesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UltimateWeaponCooldown</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageUltimateWeaponCooldownEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ActivatedInTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageActivatedInTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsGeneralActive</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIsGeneralActiveEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>GeneralId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageGeneralIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>GeneralName</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageGeneralNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>GeneralFriendlyName</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageGeneralFriendlyNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsPrimary</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIsPrimaryEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsOnVacations</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIsOnVacationsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TotalPosts</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageTotalPostsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Signature</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageSignatureEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ForumRole</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageForumRoleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Principal</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStoragePrincipalEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Alliance</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageAllianceEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Stats</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageStatsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlayerStorage> Implementation
		
	};

}