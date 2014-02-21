
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that enables PlayerStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PlayerStoragePagedList
    /// </remarks>
	public class PlayerStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox lastProcessedTick = new TextBox();
		protected DropDownList operatorsForLastProcessedTick = new DropDownList();
		protected TextBox intrinsicLimits = new TextBox();
		protected DropDownList operatorsForIntrinsicLimits = new DropDownList();
		protected TextBox score = new TextBox();
		protected DropDownList operatorsForScore = new DropDownList();
		protected TextBox allianceRank = new TextBox();
		protected DropDownList operatorsForAllianceRank = new DropDownList();
		protected TextBox race = new TextBox();
		protected DropDownList operatorsForRace = new DropDownList();
		protected TextBox homePlanetId = new TextBox();
		protected DropDownList operatorsForHomePlanetId = new DropDownList();
		protected TextBox pirateRanking = new TextBox();
		protected DropDownList operatorsForPirateRanking = new DropDownList();
		protected TextBox bountyRanking = new TextBox();
		protected DropDownList operatorsForBountyRanking = new DropDownList();
		protected TextBox merchantRanking = new TextBox();
		protected DropDownList operatorsForMerchantRanking = new DropDownList();
		protected TextBox gladiatorRanking = new TextBox();
		protected DropDownList operatorsForGladiatorRanking = new DropDownList();
		protected TextBox colonizerRanking = new TextBox();
		protected DropDownList operatorsForColonizerRanking = new DropDownList();
		protected TextBox intrinsicQuantities = new TextBox();
		protected DropDownList operatorsForIntrinsicQuantities = new DropDownList();
		protected TextBox planetLevel = new TextBox();
		protected DropDownList operatorsForPlanetLevel = new DropDownList();
		protected TextBox questContextLevel = new TextBox();
		protected DropDownList operatorsForQuestContextLevel = new DropDownList();
		protected TextBox active = new TextBox();
		protected DropDownList operatorsForActive = new DropDownList();
		protected TextBox avatar = new TextBox();
		protected DropDownList operatorsForAvatar = new DropDownList();
		protected TextBox ultimateWeaponLevel = new TextBox();
		protected DropDownList operatorsForUltimateWeaponLevel = new DropDownList();
		protected TextBox services = new TextBox();
		protected DropDownList operatorsForServices = new DropDownList();
		protected TextBox ultimateWeaponCooldown = new TextBox();
		protected DropDownList operatorsForUltimateWeaponCooldown = new DropDownList();
		protected TextBox activatedInTick = new TextBox();
		protected DropDownList operatorsForActivatedInTick = new DropDownList();
		protected TextBox isGeneralActive = new TextBox();
		protected DropDownList operatorsForIsGeneralActive = new DropDownList();
		protected TextBox generalId = new TextBox();
		protected DropDownList operatorsForGeneralId = new DropDownList();
		protected TextBox generalName = new TextBox();
		protected DropDownList operatorsForGeneralName = new DropDownList();
		protected TextBox generalFriendlyName = new TextBox();
		protected DropDownList operatorsForGeneralFriendlyName = new DropDownList();
		protected TextBox isPrimary = new TextBox();
		protected DropDownList operatorsForIsPrimary = new DropDownList();
		protected TextBox isOnVacations = new TextBox();
		protected DropDownList operatorsForIsOnVacations = new DropDownList();
		protected TextBox totalPosts = new TextBox();
		protected DropDownList operatorsForTotalPosts = new DropDownList();
		protected TextBox signature = new TextBox();
		protected DropDownList operatorsForSignature = new DropDownList();
		protected TextBox forumRole = new TextBox();
		protected DropDownList operatorsForForumRole = new DropDownList();
		protected TextBox createdDate = new TextBox();
		protected DropDownList operatorsForCreatedDate = new DropDownList();
		protected TextBox updatedDate = new TextBox();
		protected DropDownList operatorsForUpdatedDate = new DropDownList();
		protected TextBox lastActionUserId = new TextBox();
		protected DropDownList operatorsForLastActionUserId = new DropDownList();
		protected Button button = new Button();

		#endregion Control Fields
		
		#region Control Properties
		
		/// <summary>
        /// Search box for PlayerStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's LastProcessedTick property
        /// </summary>
		public TextBox LastProcessedTick {
			get { return lastProcessedTick; }
			set { lastProcessedTick = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's LastProcessedTick operators
        /// </summary>
		public DropDownList OperatorsForLastProcessedTick {
			get { return operatorsForLastProcessedTick; }
			set { operatorsForLastProcessedTick = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's IntrinsicLimits property
        /// </summary>
		public TextBox IntrinsicLimits {
			get { return intrinsicLimits; }
			set { intrinsicLimits = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's IntrinsicLimits operators
        /// </summary>
		public DropDownList OperatorsForIntrinsicLimits {
			get { return operatorsForIntrinsicLimits; }
			set { operatorsForIntrinsicLimits = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's Score property
        /// </summary>
		public TextBox Score {
			get { return score; }
			set { score = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's Score operators
        /// </summary>
		public DropDownList OperatorsForScore {
			get { return operatorsForScore; }
			set { operatorsForScore = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's AllianceRank property
        /// </summary>
		public TextBox AllianceRank {
			get { return allianceRank; }
			set { allianceRank = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's AllianceRank operators
        /// </summary>
		public DropDownList OperatorsForAllianceRank {
			get { return operatorsForAllianceRank; }
			set { operatorsForAllianceRank = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's Race property
        /// </summary>
		public TextBox Race {
			get { return race; }
			set { race = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's Race operators
        /// </summary>
		public DropDownList OperatorsForRace {
			get { return operatorsForRace; }
			set { operatorsForRace = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's HomePlanetId property
        /// </summary>
		public TextBox HomePlanetId {
			get { return homePlanetId; }
			set { homePlanetId = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's HomePlanetId operators
        /// </summary>
		public DropDownList OperatorsForHomePlanetId {
			get { return operatorsForHomePlanetId; }
			set { operatorsForHomePlanetId = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's PirateRanking property
        /// </summary>
		public TextBox PirateRanking {
			get { return pirateRanking; }
			set { pirateRanking = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's PirateRanking operators
        /// </summary>
		public DropDownList OperatorsForPirateRanking {
			get { return operatorsForPirateRanking; }
			set { operatorsForPirateRanking = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's BountyRanking property
        /// </summary>
		public TextBox BountyRanking {
			get { return bountyRanking; }
			set { bountyRanking = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's BountyRanking operators
        /// </summary>
		public DropDownList OperatorsForBountyRanking {
			get { return operatorsForBountyRanking; }
			set { operatorsForBountyRanking = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's MerchantRanking property
        /// </summary>
		public TextBox MerchantRanking {
			get { return merchantRanking; }
			set { merchantRanking = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's MerchantRanking operators
        /// </summary>
		public DropDownList OperatorsForMerchantRanking {
			get { return operatorsForMerchantRanking; }
			set { operatorsForMerchantRanking = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's GladiatorRanking property
        /// </summary>
		public TextBox GladiatorRanking {
			get { return gladiatorRanking; }
			set { gladiatorRanking = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's GladiatorRanking operators
        /// </summary>
		public DropDownList OperatorsForGladiatorRanking {
			get { return operatorsForGladiatorRanking; }
			set { operatorsForGladiatorRanking = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's ColonizerRanking property
        /// </summary>
		public TextBox ColonizerRanking {
			get { return colonizerRanking; }
			set { colonizerRanking = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's ColonizerRanking operators
        /// </summary>
		public DropDownList OperatorsForColonizerRanking {
			get { return operatorsForColonizerRanking; }
			set { operatorsForColonizerRanking = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's IntrinsicQuantities property
        /// </summary>
		public TextBox IntrinsicQuantities {
			get { return intrinsicQuantities; }
			set { intrinsicQuantities = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's IntrinsicQuantities operators
        /// </summary>
		public DropDownList OperatorsForIntrinsicQuantities {
			get { return operatorsForIntrinsicQuantities; }
			set { operatorsForIntrinsicQuantities = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's PlanetLevel property
        /// </summary>
		public TextBox PlanetLevel {
			get { return planetLevel; }
			set { planetLevel = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's PlanetLevel operators
        /// </summary>
		public DropDownList OperatorsForPlanetLevel {
			get { return operatorsForPlanetLevel; }
			set { operatorsForPlanetLevel = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's QuestContextLevel property
        /// </summary>
		public TextBox QuestContextLevel {
			get { return questContextLevel; }
			set { questContextLevel = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's QuestContextLevel operators
        /// </summary>
		public DropDownList OperatorsForQuestContextLevel {
			get { return operatorsForQuestContextLevel; }
			set { operatorsForQuestContextLevel = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's Active property
        /// </summary>
		public TextBox Active {
			get { return active; }
			set { active = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's Active operators
        /// </summary>
		public DropDownList OperatorsForActive {
			get { return operatorsForActive; }
			set { operatorsForActive = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's Avatar property
        /// </summary>
		public TextBox Avatar {
			get { return avatar; }
			set { avatar = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's Avatar operators
        /// </summary>
		public DropDownList OperatorsForAvatar {
			get { return operatorsForAvatar; }
			set { operatorsForAvatar = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's UltimateWeaponLevel property
        /// </summary>
		public TextBox UltimateWeaponLevel {
			get { return ultimateWeaponLevel; }
			set { ultimateWeaponLevel = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's UltimateWeaponLevel operators
        /// </summary>
		public DropDownList OperatorsForUltimateWeaponLevel {
			get { return operatorsForUltimateWeaponLevel; }
			set { operatorsForUltimateWeaponLevel = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's Services property
        /// </summary>
		public TextBox Services {
			get { return services; }
			set { services = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's Services operators
        /// </summary>
		public DropDownList OperatorsForServices {
			get { return operatorsForServices; }
			set { operatorsForServices = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's UltimateWeaponCooldown property
        /// </summary>
		public TextBox UltimateWeaponCooldown {
			get { return ultimateWeaponCooldown; }
			set { ultimateWeaponCooldown = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's UltimateWeaponCooldown operators
        /// </summary>
		public DropDownList OperatorsForUltimateWeaponCooldown {
			get { return operatorsForUltimateWeaponCooldown; }
			set { operatorsForUltimateWeaponCooldown = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's ActivatedInTick property
        /// </summary>
		public TextBox ActivatedInTick {
			get { return activatedInTick; }
			set { activatedInTick = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's ActivatedInTick operators
        /// </summary>
		public DropDownList OperatorsForActivatedInTick {
			get { return operatorsForActivatedInTick; }
			set { operatorsForActivatedInTick = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's IsGeneralActive property
        /// </summary>
		public TextBox IsGeneralActive {
			get { return isGeneralActive; }
			set { isGeneralActive = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's IsGeneralActive operators
        /// </summary>
		public DropDownList OperatorsForIsGeneralActive {
			get { return operatorsForIsGeneralActive; }
			set { operatorsForIsGeneralActive = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's GeneralId property
        /// </summary>
		public TextBox GeneralId {
			get { return generalId; }
			set { generalId = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's GeneralId operators
        /// </summary>
		public DropDownList OperatorsForGeneralId {
			get { return operatorsForGeneralId; }
			set { operatorsForGeneralId = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's GeneralName property
        /// </summary>
		public TextBox GeneralName {
			get { return generalName; }
			set { generalName = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's GeneralName operators
        /// </summary>
		public DropDownList OperatorsForGeneralName {
			get { return operatorsForGeneralName; }
			set { operatorsForGeneralName = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's GeneralFriendlyName property
        /// </summary>
		public TextBox GeneralFriendlyName {
			get { return generalFriendlyName; }
			set { generalFriendlyName = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's GeneralFriendlyName operators
        /// </summary>
		public DropDownList OperatorsForGeneralFriendlyName {
			get { return operatorsForGeneralFriendlyName; }
			set { operatorsForGeneralFriendlyName = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's IsPrimary property
        /// </summary>
		public TextBox IsPrimary {
			get { return isPrimary; }
			set { isPrimary = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's IsPrimary operators
        /// </summary>
		public DropDownList OperatorsForIsPrimary {
			get { return operatorsForIsPrimary; }
			set { operatorsForIsPrimary = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's IsOnVacations property
        /// </summary>
		public TextBox IsOnVacations {
			get { return isOnVacations; }
			set { isOnVacations = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's IsOnVacations operators
        /// </summary>
		public DropDownList OperatorsForIsOnVacations {
			get { return operatorsForIsOnVacations; }
			set { operatorsForIsOnVacations = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's TotalPosts property
        /// </summary>
		public TextBox TotalPosts {
			get { return totalPosts; }
			set { totalPosts = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's TotalPosts operators
        /// </summary>
		public DropDownList OperatorsForTotalPosts {
			get { return operatorsForTotalPosts; }
			set { operatorsForTotalPosts = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's Signature property
        /// </summary>
		public TextBox Signature {
			get { return signature; }
			set { signature = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's Signature operators
        /// </summary>
		public DropDownList OperatorsForSignature {
			get { return operatorsForSignature; }
			set { operatorsForSignature = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's ForumRole property
        /// </summary>
		public TextBox ForumRole {
			get { return forumRole; }
			set { forumRole = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's ForumRole operators
        /// </summary>
		public DropDownList OperatorsForForumRole {
			get { return operatorsForForumRole; }
			set { operatorsForForumRole = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStorage's LastActionUserId operators
        /// </summary>
		public DropDownList OperatorsForLastActionUserId {
			get { return operatorsForLastActionUserId; }
			set { operatorsForLastActionUserId = value; }
		}
		
		#endregion Control Properties
		
		#region Control Events
		
		/// <summary>
        /// Initialization
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			EnsureChildControls();
			button.Text = "Search";
		}
		
		/// <summary>
        /// Control actions
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnLoad( EventArgs args )
		{
			base.OnLoad(args);
			if( Page.IsPostBack ) {
				StringWriter writer = new StringWriter();
				bool first = true;
				
				if( !string.IsNullOrEmpty( Id.Text ) ) {
					writer.Write( "{2} e.Id {0} '{1}' ",
							operatorsForId.SelectedValue, 
							Id.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Name.Text ) ) {
					writer.Write( "{2} e.Name {0} '{1}' ",
							operatorsForName.SelectedValue, 
							Name.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastProcessedTick.Text ) ) {
					writer.Write( "{2} e.LastProcessedTick {0} '{1}' ",
							operatorsForLastProcessedTick.SelectedValue, 
							LastProcessedTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IntrinsicLimits.Text ) ) {
					writer.Write( "{2} e.IntrinsicLimits {0} '{1}' ",
							operatorsForIntrinsicLimits.SelectedValue, 
							IntrinsicLimits.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Score.Text ) ) {
					writer.Write( "{2} e.Score {0} '{1}' ",
							operatorsForScore.SelectedValue, 
							Score.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( AllianceRank.Text ) ) {
					writer.Write( "{2} e.AllianceRank {0} '{1}' ",
							operatorsForAllianceRank.SelectedValue, 
							AllianceRank.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Race.Text ) ) {
					writer.Write( "{2} e.Race {0} '{1}' ",
							operatorsForRace.SelectedValue, 
							Race.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( HomePlanetId.Text ) ) {
					writer.Write( "{2} e.HomePlanetId {0} '{1}' ",
							operatorsForHomePlanetId.SelectedValue, 
							HomePlanetId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PirateRanking.Text ) ) {
					writer.Write( "{2} e.PirateRanking {0} '{1}' ",
							operatorsForPirateRanking.SelectedValue, 
							PirateRanking.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BountyRanking.Text ) ) {
					writer.Write( "{2} e.BountyRanking {0} '{1}' ",
							operatorsForBountyRanking.SelectedValue, 
							BountyRanking.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MerchantRanking.Text ) ) {
					writer.Write( "{2} e.MerchantRanking {0} '{1}' ",
							operatorsForMerchantRanking.SelectedValue, 
							MerchantRanking.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( GladiatorRanking.Text ) ) {
					writer.Write( "{2} e.GladiatorRanking {0} '{1}' ",
							operatorsForGladiatorRanking.SelectedValue, 
							GladiatorRanking.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ColonizerRanking.Text ) ) {
					writer.Write( "{2} e.ColonizerRanking {0} '{1}' ",
							operatorsForColonizerRanking.SelectedValue, 
							ColonizerRanking.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IntrinsicQuantities.Text ) ) {
					writer.Write( "{2} e.IntrinsicQuantities {0} '{1}' ",
							operatorsForIntrinsicQuantities.SelectedValue, 
							IntrinsicQuantities.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PlanetLevel.Text ) ) {
					writer.Write( "{2} e.PlanetLevel {0} '{1}' ",
							operatorsForPlanetLevel.SelectedValue, 
							PlanetLevel.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( QuestContextLevel.Text ) ) {
					writer.Write( "{2} e.QuestContextLevel {0} '{1}' ",
							operatorsForQuestContextLevel.SelectedValue, 
							QuestContextLevel.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Active.Text ) ) {
					writer.Write( "{2} e.Active {0} '{1}' ",
							operatorsForActive.SelectedValue, 
							Active.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Avatar.Text ) ) {
					writer.Write( "{2} e.Avatar {0} '{1}' ",
							operatorsForAvatar.SelectedValue, 
							Avatar.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UltimateWeaponLevel.Text ) ) {
					writer.Write( "{2} e.UltimateWeaponLevel {0} '{1}' ",
							operatorsForUltimateWeaponLevel.SelectedValue, 
							UltimateWeaponLevel.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Services.Text ) ) {
					writer.Write( "{2} e.Services {0} '{1}' ",
							operatorsForServices.SelectedValue, 
							Services.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UltimateWeaponCooldown.Text ) ) {
					writer.Write( "{2} e.UltimateWeaponCooldown {0} '{1}' ",
							operatorsForUltimateWeaponCooldown.SelectedValue, 
							UltimateWeaponCooldown.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ActivatedInTick.Text ) ) {
					writer.Write( "{2} e.ActivatedInTick {0} '{1}' ",
							operatorsForActivatedInTick.SelectedValue, 
							ActivatedInTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsGeneralActive.Text ) ) {
					writer.Write( "{2} e.IsGeneralActive {0} '{1}' ",
							operatorsForIsGeneralActive.SelectedValue, 
							IsGeneralActive.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( GeneralId.Text ) ) {
					writer.Write( "{2} e.GeneralId {0} '{1}' ",
							operatorsForGeneralId.SelectedValue, 
							GeneralId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( GeneralName.Text ) ) {
					writer.Write( "{2} e.GeneralName {0} '{1}' ",
							operatorsForGeneralName.SelectedValue, 
							GeneralName.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( GeneralFriendlyName.Text ) ) {
					writer.Write( "{2} e.GeneralFriendlyName {0} '{1}' ",
							operatorsForGeneralFriendlyName.SelectedValue, 
							GeneralFriendlyName.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsPrimary.Text ) ) {
					writer.Write( "{2} e.IsPrimary {0} '{1}' ",
							operatorsForIsPrimary.SelectedValue, 
							IsPrimary.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsOnVacations.Text ) ) {
					writer.Write( "{2} e.IsOnVacations {0} '{1}' ",
							operatorsForIsOnVacations.SelectedValue, 
							IsOnVacations.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TotalPosts.Text ) ) {
					writer.Write( "{2} e.TotalPosts {0} '{1}' ",
							operatorsForTotalPosts.SelectedValue, 
							TotalPosts.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Signature.Text ) ) {
					writer.Write( "{2} e.Signature {0} '{1}' ",
							operatorsForSignature.SelectedValue, 
							Signature.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ForumRole.Text ) ) {
					writer.Write( "{2} e.ForumRole {0} '{1}' ",
							operatorsForForumRole.SelectedValue, 
							ForumRole.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CreatedDate.Text ) ) {
					writer.Write( "{2} e.CreatedDate {0} '{1}' ",
							operatorsForCreatedDate.SelectedValue, 
							CreatedDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UpdatedDate.Text ) ) {
					writer.Write( "{2} e.UpdatedDate {0} '{1}' ",
							operatorsForUpdatedDate.SelectedValue, 
							UpdatedDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastActionUserId.Text ) ) {
					writer.Write( "{2} e.LastActionUserId {0} '{1}' ",
							operatorsForLastActionUserId.SelectedValue, 
							LastActionUserId.Text, first ? "" : ","
						);
					first = false;
				}

				string search = writer.ToString();
				if( !string.IsNullOrEmpty(search) ) {
					HttpContext.Current.Items[BasePagedList<PlayerStorage>.GetWhereKey("PlayerStorage")] = writer.ToString();
				}
			}
		}
		
		/// <summary>
        /// Creates the control tree
        /// </summary>
		protected override void CreateChildControls()
        {
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th>Field</th><th>Operator</th><th>Search</th></tr>") );
			Id.ID = "searchId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Id</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Id );
			Controls.Add( new LiteralControl("</td><tr>") );
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastProcessedTick.ID = "searchLastProcessedTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastProcessedTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastProcessedTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastProcessedTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			IntrinsicLimits.ID = "searchIntrinsicLimits";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IntrinsicLimits</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIntrinsicLimits ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IntrinsicLimits );
			Controls.Add( new LiteralControl("</td><tr>") );
			Score.ID = "searchScore";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Score</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForScore ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Score );
			Controls.Add( new LiteralControl("</td><tr>") );
			AllianceRank.ID = "searchAllianceRank";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>AllianceRank</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAllianceRank ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( AllianceRank );
			Controls.Add( new LiteralControl("</td><tr>") );
			Race.ID = "searchRace";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Race</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRace ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Race );
			Controls.Add( new LiteralControl("</td><tr>") );
			HomePlanetId.ID = "searchHomePlanetId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HomePlanetId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHomePlanetId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HomePlanetId );
			Controls.Add( new LiteralControl("</td><tr>") );
			PirateRanking.ID = "searchPirateRanking";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PirateRanking</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPirateRanking ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PirateRanking );
			Controls.Add( new LiteralControl("</td><tr>") );
			BountyRanking.ID = "searchBountyRanking";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BountyRanking</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBountyRanking ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BountyRanking );
			Controls.Add( new LiteralControl("</td><tr>") );
			MerchantRanking.ID = "searchMerchantRanking";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MerchantRanking</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMerchantRanking ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MerchantRanking );
			Controls.Add( new LiteralControl("</td><tr>") );
			GladiatorRanking.ID = "searchGladiatorRanking";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>GladiatorRanking</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForGladiatorRanking ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( GladiatorRanking );
			Controls.Add( new LiteralControl("</td><tr>") );
			ColonizerRanking.ID = "searchColonizerRanking";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ColonizerRanking</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForColonizerRanking ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ColonizerRanking );
			Controls.Add( new LiteralControl("</td><tr>") );
			IntrinsicQuantities.ID = "searchIntrinsicQuantities";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IntrinsicQuantities</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIntrinsicQuantities ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IntrinsicQuantities );
			Controls.Add( new LiteralControl("</td><tr>") );
			PlanetLevel.ID = "searchPlanetLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PlanetLevel</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPlanetLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PlanetLevel );
			Controls.Add( new LiteralControl("</td><tr>") );
			QuestContextLevel.ID = "searchQuestContextLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>QuestContextLevel</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForQuestContextLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( QuestContextLevel );
			Controls.Add( new LiteralControl("</td><tr>") );
			Active.ID = "searchActive";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Active</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForActive ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Active );
			Controls.Add( new LiteralControl("</td><tr>") );
			Avatar.ID = "searchAvatar";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Avatar</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAvatar ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Avatar );
			Controls.Add( new LiteralControl("</td><tr>") );
			UltimateWeaponLevel.ID = "searchUltimateWeaponLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UltimateWeaponLevel</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUltimateWeaponLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UltimateWeaponLevel );
			Controls.Add( new LiteralControl("</td><tr>") );
			Services.ID = "searchServices";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Services</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForServices ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Services );
			Controls.Add( new LiteralControl("</td><tr>") );
			UltimateWeaponCooldown.ID = "searchUltimateWeaponCooldown";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UltimateWeaponCooldown</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUltimateWeaponCooldown ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UltimateWeaponCooldown );
			Controls.Add( new LiteralControl("</td><tr>") );
			ActivatedInTick.ID = "searchActivatedInTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ActivatedInTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForActivatedInTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ActivatedInTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsGeneralActive.ID = "searchIsGeneralActive";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsGeneralActive</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsGeneralActive ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsGeneralActive );
			Controls.Add( new LiteralControl("</td><tr>") );
			GeneralId.ID = "searchGeneralId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>GeneralId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForGeneralId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( GeneralId );
			Controls.Add( new LiteralControl("</td><tr>") );
			GeneralName.ID = "searchGeneralName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>GeneralName</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForGeneralName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( GeneralName );
			Controls.Add( new LiteralControl("</td><tr>") );
			GeneralFriendlyName.ID = "searchGeneralFriendlyName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>GeneralFriendlyName</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForGeneralFriendlyName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( GeneralFriendlyName );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsPrimary.ID = "searchIsPrimary";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsPrimary</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsPrimary ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsPrimary );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsOnVacations.ID = "searchIsOnVacations";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsOnVacations</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsOnVacations ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsOnVacations );
			Controls.Add( new LiteralControl("</td><tr>") );
			TotalPosts.ID = "searchTotalPosts";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TotalPosts</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTotalPosts ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TotalPosts );
			Controls.Add( new LiteralControl("</td><tr>") );
			Signature.ID = "searchSignature";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Signature</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSignature ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Signature );
			Controls.Add( new LiteralControl("</td><tr>") );
			ForumRole.ID = "searchForumRole";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ForumRole</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForForumRole ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ForumRole );
			Controls.Add( new LiteralControl("</td><tr>") );
			CreatedDate.ID = "searchCreatedDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CreatedDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCreatedDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CreatedDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			UpdatedDate.ID = "searchUpdatedDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UpdatedDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUpdatedDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UpdatedDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastActionUserId.ID = "searchLastActionUserId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastActionUserId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastActionUserId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastActionUserId );
			Controls.Add( new LiteralControl("</td><tr>") );
			Controls.Add( new LiteralControl("<tr><td></td><td></td><td>") );
			Controls.Add( button );
			Controls.Add( new LiteralControl("</td></tr>") );
			Controls.Add( new LiteralControl("</table>") );
        }
		
		#endregion Control Events
		
		#region Utilities
		
		/// <summary>
        /// Adds Search operators
        /// </summary>
        /// <param name="list">The Target List</param>
        /// <returns>The target list</returns>
		private DropDownList AddOperators( DropDownList list )
		{
			list.Items.Add( "=" );
			list.Items.Add( "!=" );
			list.Items.Add( "<" );
			list.Items.Add( ">" );
			list.Items.Add( "<=" );
			list.Items.Add( ">=" );
			list.Items.Add( "like" );
			list.Items.Add( "not like" );
			
			return list;
		}
		
		#endregion Utilities
	
	};

}
