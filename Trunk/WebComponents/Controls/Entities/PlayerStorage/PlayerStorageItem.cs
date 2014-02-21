
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlayerStorage control renderer
    /// </summary>
	public class PlayerStorageItem : BaseEntityItem<PlayerStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerStoragePersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastProcessedTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageLastProcessedTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IntrinsicLimits</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIntrinsicLimits () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Score</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageScore () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>AllianceRank</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageAllianceRank () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Race</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageRace () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HomePlanetId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageHomePlanetId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PirateRanking</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStoragePirateRanking () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BountyRanking</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageBountyRanking () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MerchantRanking</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageMerchantRanking () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>GladiatorRanking</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageGladiatorRanking () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ColonizerRanking</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageColonizerRanking () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IntrinsicQuantities</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIntrinsicQuantities () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PlanetLevel</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStoragePlanetLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>QuestContextLevel</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageQuestContextLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Active</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageActive () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Avatar</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageAvatar () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UltimateWeaponLevel</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageUltimateWeaponLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Services</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageServices () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UltimateWeaponCooldown</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageUltimateWeaponCooldown () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ActivatedInTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageActivatedInTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsGeneralActive</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIsGeneralActive () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>GeneralId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageGeneralId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>GeneralName</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageGeneralName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>GeneralFriendlyName</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageGeneralFriendlyName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsPrimary</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIsPrimary () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsOnVacations</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageIsOnVacations () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TotalPosts</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageTotalPosts () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Signature</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageSignature () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ForumRole</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageForumRole () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Principal</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStoragePrincipal () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Alliance</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageAlliance () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Stats</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageStats () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlayerStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlayerStorage> Implementation
		
	};

}
