
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
    /// Control that enables Principal search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PrincipalPagedList
    /// </remarks>
	public class PrincipalSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox isBot = new TextBox();
		protected DropDownList operatorsForIsBot = new DropDownList();
		protected TextBox myStatsId = new TextBox();
		protected DropDownList operatorsForMyStatsId = new DropDownList();
		protected TextBox eloRanking = new TextBox();
		protected DropDownList operatorsForEloRanking = new DropDownList();
		protected TextBox receiveMail = new TextBox();
		protected DropDownList operatorsForReceiveMail = new DropDownList();
		protected TextBox credits = new TextBox();
		protected DropDownList operatorsForCredits = new DropDownList();
		protected TextBox ladderActive = new TextBox();
		protected DropDownList operatorsForLadderActive = new DropDownList();
		protected TextBox ladderPosition = new TextBox();
		protected DropDownList operatorsForLadderPosition = new DropDownList();
		protected TextBox isInBattle = new TextBox();
		protected DropDownList operatorsForIsInBattle = new DropDownList();
		protected TextBox restUntil = new TextBox();
		protected DropDownList operatorsForRestUntil = new DropDownList();
		protected TextBox stoppedUntil = new TextBox();
		protected DropDownList operatorsForStoppedUntil = new DropDownList();
		protected TextBox availableVacationTicks = new TextBox();
		protected DropDownList operatorsForAvailableVacationTicks = new DropDownList();
		protected TextBox vacationStartTick = new TextBox();
		protected DropDownList operatorsForVacationStartTick = new DropDownList();
		protected TextBox vacationEndtick = new TextBox();
		protected DropDownList operatorsForVacationEndtick = new DropDownList();
		protected TextBox autoStartVacations = new TextBox();
		protected DropDownList operatorsForAutoStartVacations = new DropDownList();
		protected TextBox referrerId = new TextBox();
		protected DropDownList operatorsForReferrerId = new DropDownList();
		protected TextBox canChangeName = new TextBox();
		protected DropDownList operatorsForCanChangeName = new DropDownList();
		protected TextBox avatar = new TextBox();
		protected DropDownList operatorsForAvatar = new DropDownList();
		protected TextBox webSite = new TextBox();
		protected DropDownList operatorsForWebSite = new DropDownList();
		protected TextBox tutorialState = new TextBox();
		protected DropDownList operatorsForTutorialState = new DropDownList();
		protected TextBox duplicatedIds = new TextBox();
		protected DropDownList operatorsForDuplicatedIds = new DropDownList();
		protected TextBox numberOfWarnings = new TextBox();
		protected DropDownList operatorsForNumberOfWarnings = new DropDownList();
		protected TextBox acceptedTerms = new TextBox();
		protected DropDownList operatorsForAcceptedTerms = new DropDownList();
		protected TextBox warningPoints = new TextBox();
		protected DropDownList operatorsForWarningPoints = new DropDownList();
		protected TextBox lastWarningDate = new TextBox();
		protected DropDownList operatorsForLastWarningDate = new DropDownList();
		protected TextBox botUrl = new TextBox();
		protected DropDownList operatorsForBotUrl = new DropDownList();
		protected TextBox referrerPriceCount = new TextBox();
		protected DropDownList operatorsForReferrerPriceCount = new DropDownList();
		protected TextBox isOnVacations = new TextBox();
		protected DropDownList operatorsForIsOnVacations = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox password = new TextBox();
		protected DropDownList operatorsForPassword = new DropDownList();
		protected TextBox email = new TextBox();
		protected DropDownList operatorsForEmail = new DropDownList();
		protected TextBox ip = new TextBox();
		protected DropDownList operatorsForIp = new DropDownList();
		protected TextBox registDate = new TextBox();
		protected DropDownList operatorsForRegistDate = new DropDownList();
		protected TextBox lastLogin = new TextBox();
		protected DropDownList operatorsForLastLogin = new DropDownList();
		protected TextBox approved = new TextBox();
		protected DropDownList operatorsForApproved = new DropDownList();
		protected TextBox isOnline = new TextBox();
		protected DropDownList operatorsForIsOnline = new DropDownList();
		protected TextBox locked = new TextBox();
		protected DropDownList operatorsForLocked = new DropDownList();
		protected TextBox locale = new TextBox();
		protected DropDownList operatorsForLocale = new DropDownList();
		protected TextBox confirmationCode = new TextBox();
		protected DropDownList operatorsForConfirmationCode = new DropDownList();
		protected TextBox rawRoles = new TextBox();
		protected DropDownList operatorsForRawRoles = new DropDownList();
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
        /// Search box for Principal's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Principal's IsBot property
        /// </summary>
		public TextBox IsBot {
			get { return isBot; }
			set { isBot = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's IsBot operators
        /// </summary>
		public DropDownList OperatorsForIsBot {
			get { return operatorsForIsBot; }
			set { operatorsForIsBot = value; }
		}
		
		/// <summary>
        /// Search box for Principal's MyStatsId property
        /// </summary>
		public TextBox MyStatsId {
			get { return myStatsId; }
			set { myStatsId = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's MyStatsId operators
        /// </summary>
		public DropDownList OperatorsForMyStatsId {
			get { return operatorsForMyStatsId; }
			set { operatorsForMyStatsId = value; }
		}
		
		/// <summary>
        /// Search box for Principal's EloRanking property
        /// </summary>
		public TextBox EloRanking {
			get { return eloRanking; }
			set { eloRanking = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's EloRanking operators
        /// </summary>
		public DropDownList OperatorsForEloRanking {
			get { return operatorsForEloRanking; }
			set { operatorsForEloRanking = value; }
		}
		
		/// <summary>
        /// Search box for Principal's ReceiveMail property
        /// </summary>
		public TextBox ReceiveMail {
			get { return receiveMail; }
			set { receiveMail = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's ReceiveMail operators
        /// </summary>
		public DropDownList OperatorsForReceiveMail {
			get { return operatorsForReceiveMail; }
			set { operatorsForReceiveMail = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Credits property
        /// </summary>
		public TextBox Credits {
			get { return credits; }
			set { credits = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Credits operators
        /// </summary>
		public DropDownList OperatorsForCredits {
			get { return operatorsForCredits; }
			set { operatorsForCredits = value; }
		}
		
		/// <summary>
        /// Search box for Principal's LadderActive property
        /// </summary>
		public TextBox LadderActive {
			get { return ladderActive; }
			set { ladderActive = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's LadderActive operators
        /// </summary>
		public DropDownList OperatorsForLadderActive {
			get { return operatorsForLadderActive; }
			set { operatorsForLadderActive = value; }
		}
		
		/// <summary>
        /// Search box for Principal's LadderPosition property
        /// </summary>
		public TextBox LadderPosition {
			get { return ladderPosition; }
			set { ladderPosition = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's LadderPosition operators
        /// </summary>
		public DropDownList OperatorsForLadderPosition {
			get { return operatorsForLadderPosition; }
			set { operatorsForLadderPosition = value; }
		}
		
		/// <summary>
        /// Search box for Principal's IsInBattle property
        /// </summary>
		public TextBox IsInBattle {
			get { return isInBattle; }
			set { isInBattle = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's IsInBattle operators
        /// </summary>
		public DropDownList OperatorsForIsInBattle {
			get { return operatorsForIsInBattle; }
			set { operatorsForIsInBattle = value; }
		}
		
		/// <summary>
        /// Search box for Principal's RestUntil property
        /// </summary>
		public TextBox RestUntil {
			get { return restUntil; }
			set { restUntil = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's RestUntil operators
        /// </summary>
		public DropDownList OperatorsForRestUntil {
			get { return operatorsForRestUntil; }
			set { operatorsForRestUntil = value; }
		}
		
		/// <summary>
        /// Search box for Principal's StoppedUntil property
        /// </summary>
		public TextBox StoppedUntil {
			get { return stoppedUntil; }
			set { stoppedUntil = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's StoppedUntil operators
        /// </summary>
		public DropDownList OperatorsForStoppedUntil {
			get { return operatorsForStoppedUntil; }
			set { operatorsForStoppedUntil = value; }
		}
		
		/// <summary>
        /// Search box for Principal's AvailableVacationTicks property
        /// </summary>
		public TextBox AvailableVacationTicks {
			get { return availableVacationTicks; }
			set { availableVacationTicks = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's AvailableVacationTicks operators
        /// </summary>
		public DropDownList OperatorsForAvailableVacationTicks {
			get { return operatorsForAvailableVacationTicks; }
			set { operatorsForAvailableVacationTicks = value; }
		}
		
		/// <summary>
        /// Search box for Principal's VacationStartTick property
        /// </summary>
		public TextBox VacationStartTick {
			get { return vacationStartTick; }
			set { vacationStartTick = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's VacationStartTick operators
        /// </summary>
		public DropDownList OperatorsForVacationStartTick {
			get { return operatorsForVacationStartTick; }
			set { operatorsForVacationStartTick = value; }
		}
		
		/// <summary>
        /// Search box for Principal's VacationEndtick property
        /// </summary>
		public TextBox VacationEndtick {
			get { return vacationEndtick; }
			set { vacationEndtick = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's VacationEndtick operators
        /// </summary>
		public DropDownList OperatorsForVacationEndtick {
			get { return operatorsForVacationEndtick; }
			set { operatorsForVacationEndtick = value; }
		}
		
		/// <summary>
        /// Search box for Principal's AutoStartVacations property
        /// </summary>
		public TextBox AutoStartVacations {
			get { return autoStartVacations; }
			set { autoStartVacations = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's AutoStartVacations operators
        /// </summary>
		public DropDownList OperatorsForAutoStartVacations {
			get { return operatorsForAutoStartVacations; }
			set { operatorsForAutoStartVacations = value; }
		}
		
		/// <summary>
        /// Search box for Principal's ReferrerId property
        /// </summary>
		public TextBox ReferrerId {
			get { return referrerId; }
			set { referrerId = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's ReferrerId operators
        /// </summary>
		public DropDownList OperatorsForReferrerId {
			get { return operatorsForReferrerId; }
			set { operatorsForReferrerId = value; }
		}
		
		/// <summary>
        /// Search box for Principal's CanChangeName property
        /// </summary>
		public TextBox CanChangeName {
			get { return canChangeName; }
			set { canChangeName = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's CanChangeName operators
        /// </summary>
		public DropDownList OperatorsForCanChangeName {
			get { return operatorsForCanChangeName; }
			set { operatorsForCanChangeName = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Avatar property
        /// </summary>
		public TextBox Avatar {
			get { return avatar; }
			set { avatar = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Avatar operators
        /// </summary>
		public DropDownList OperatorsForAvatar {
			get { return operatorsForAvatar; }
			set { operatorsForAvatar = value; }
		}
		
		/// <summary>
        /// Search box for Principal's WebSite property
        /// </summary>
		public TextBox WebSite {
			get { return webSite; }
			set { webSite = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's WebSite operators
        /// </summary>
		public DropDownList OperatorsForWebSite {
			get { return operatorsForWebSite; }
			set { operatorsForWebSite = value; }
		}
		
		/// <summary>
        /// Search box for Principal's TutorialState property
        /// </summary>
		public TextBox TutorialState {
			get { return tutorialState; }
			set { tutorialState = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's TutorialState operators
        /// </summary>
		public DropDownList OperatorsForTutorialState {
			get { return operatorsForTutorialState; }
			set { operatorsForTutorialState = value; }
		}
		
		/// <summary>
        /// Search box for Principal's DuplicatedIds property
        /// </summary>
		public TextBox DuplicatedIds {
			get { return duplicatedIds; }
			set { duplicatedIds = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's DuplicatedIds operators
        /// </summary>
		public DropDownList OperatorsForDuplicatedIds {
			get { return operatorsForDuplicatedIds; }
			set { operatorsForDuplicatedIds = value; }
		}
		
		/// <summary>
        /// Search box for Principal's NumberOfWarnings property
        /// </summary>
		public TextBox NumberOfWarnings {
			get { return numberOfWarnings; }
			set { numberOfWarnings = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's NumberOfWarnings operators
        /// </summary>
		public DropDownList OperatorsForNumberOfWarnings {
			get { return operatorsForNumberOfWarnings; }
			set { operatorsForNumberOfWarnings = value; }
		}
		
		/// <summary>
        /// Search box for Principal's AcceptedTerms property
        /// </summary>
		public TextBox AcceptedTerms {
			get { return acceptedTerms; }
			set { acceptedTerms = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's AcceptedTerms operators
        /// </summary>
		public DropDownList OperatorsForAcceptedTerms {
			get { return operatorsForAcceptedTerms; }
			set { operatorsForAcceptedTerms = value; }
		}
		
		/// <summary>
        /// Search box for Principal's WarningPoints property
        /// </summary>
		public TextBox WarningPoints {
			get { return warningPoints; }
			set { warningPoints = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's WarningPoints operators
        /// </summary>
		public DropDownList OperatorsForWarningPoints {
			get { return operatorsForWarningPoints; }
			set { operatorsForWarningPoints = value; }
		}
		
		/// <summary>
        /// Search box for Principal's LastWarningDate property
        /// </summary>
		public TextBox LastWarningDate {
			get { return lastWarningDate; }
			set { lastWarningDate = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's LastWarningDate operators
        /// </summary>
		public DropDownList OperatorsForLastWarningDate {
			get { return operatorsForLastWarningDate; }
			set { operatorsForLastWarningDate = value; }
		}
		
		/// <summary>
        /// Search box for Principal's BotUrl property
        /// </summary>
		public TextBox BotUrl {
			get { return botUrl; }
			set { botUrl = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's BotUrl operators
        /// </summary>
		public DropDownList OperatorsForBotUrl {
			get { return operatorsForBotUrl; }
			set { operatorsForBotUrl = value; }
		}
		
		/// <summary>
        /// Search box for Principal's ReferrerPriceCount property
        /// </summary>
		public TextBox ReferrerPriceCount {
			get { return referrerPriceCount; }
			set { referrerPriceCount = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's ReferrerPriceCount operators
        /// </summary>
		public DropDownList OperatorsForReferrerPriceCount {
			get { return operatorsForReferrerPriceCount; }
			set { operatorsForReferrerPriceCount = value; }
		}
		
		/// <summary>
        /// Search box for Principal's IsOnVacations property
        /// </summary>
		public TextBox IsOnVacations {
			get { return isOnVacations; }
			set { isOnVacations = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's IsOnVacations operators
        /// </summary>
		public DropDownList OperatorsForIsOnVacations {
			get { return operatorsForIsOnVacations; }
			set { operatorsForIsOnVacations = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Password property
        /// </summary>
		public TextBox Password {
			get { return password; }
			set { password = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Password operators
        /// </summary>
		public DropDownList OperatorsForPassword {
			get { return operatorsForPassword; }
			set { operatorsForPassword = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Email property
        /// </summary>
		public TextBox Email {
			get { return email; }
			set { email = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Email operators
        /// </summary>
		public DropDownList OperatorsForEmail {
			get { return operatorsForEmail; }
			set { operatorsForEmail = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Ip property
        /// </summary>
		public TextBox Ip {
			get { return ip; }
			set { ip = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Ip operators
        /// </summary>
		public DropDownList OperatorsForIp {
			get { return operatorsForIp; }
			set { operatorsForIp = value; }
		}
		
		/// <summary>
        /// Search box for Principal's RegistDate property
        /// </summary>
		public TextBox RegistDate {
			get { return registDate; }
			set { registDate = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's RegistDate operators
        /// </summary>
		public DropDownList OperatorsForRegistDate {
			get { return operatorsForRegistDate; }
			set { operatorsForRegistDate = value; }
		}
		
		/// <summary>
        /// Search box for Principal's LastLogin property
        /// </summary>
		public TextBox LastLogin {
			get { return lastLogin; }
			set { lastLogin = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's LastLogin operators
        /// </summary>
		public DropDownList OperatorsForLastLogin {
			get { return operatorsForLastLogin; }
			set { operatorsForLastLogin = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Approved property
        /// </summary>
		public TextBox Approved {
			get { return approved; }
			set { approved = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Approved operators
        /// </summary>
		public DropDownList OperatorsForApproved {
			get { return operatorsForApproved; }
			set { operatorsForApproved = value; }
		}
		
		/// <summary>
        /// Search box for Principal's IsOnline property
        /// </summary>
		public TextBox IsOnline {
			get { return isOnline; }
			set { isOnline = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's IsOnline operators
        /// </summary>
		public DropDownList OperatorsForIsOnline {
			get { return operatorsForIsOnline; }
			set { operatorsForIsOnline = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Locked property
        /// </summary>
		public TextBox Locked {
			get { return locked; }
			set { locked = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Locked operators
        /// </summary>
		public DropDownList OperatorsForLocked {
			get { return operatorsForLocked; }
			set { operatorsForLocked = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Locale property
        /// </summary>
		public TextBox Locale {
			get { return locale; }
			set { locale = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Locale operators
        /// </summary>
		public DropDownList OperatorsForLocale {
			get { return operatorsForLocale; }
			set { operatorsForLocale = value; }
		}
		
		/// <summary>
        /// Search box for Principal's ConfirmationCode property
        /// </summary>
		public TextBox ConfirmationCode {
			get { return confirmationCode; }
			set { confirmationCode = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's ConfirmationCode operators
        /// </summary>
		public DropDownList OperatorsForConfirmationCode {
			get { return operatorsForConfirmationCode; }
			set { operatorsForConfirmationCode = value; }
		}
		
		/// <summary>
        /// Search box for Principal's RawRoles property
        /// </summary>
		public TextBox RawRoles {
			get { return rawRoles; }
			set { rawRoles = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's RawRoles operators
        /// </summary>
		public DropDownList OperatorsForRawRoles {
			get { return operatorsForRawRoles; }
			set { operatorsForRawRoles = value; }
		}
		
		/// <summary>
        /// Search box for Principal's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Principal's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Principal's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( IsBot.Text ) ) {
					writer.Write( "{2} e.IsBot {0} '{1}' ",
							operatorsForIsBot.SelectedValue, 
							IsBot.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MyStatsId.Text ) ) {
					writer.Write( "{2} e.MyStatsId {0} '{1}' ",
							operatorsForMyStatsId.SelectedValue, 
							MyStatsId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( EloRanking.Text ) ) {
					writer.Write( "{2} e.EloRanking {0} '{1}' ",
							operatorsForEloRanking.SelectedValue, 
							EloRanking.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ReceiveMail.Text ) ) {
					writer.Write( "{2} e.ReceiveMail {0} '{1}' ",
							operatorsForReceiveMail.SelectedValue, 
							ReceiveMail.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Credits.Text ) ) {
					writer.Write( "{2} e.Credits {0} '{1}' ",
							operatorsForCredits.SelectedValue, 
							Credits.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LadderActive.Text ) ) {
					writer.Write( "{2} e.LadderActive {0} '{1}' ",
							operatorsForLadderActive.SelectedValue, 
							LadderActive.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LadderPosition.Text ) ) {
					writer.Write( "{2} e.LadderPosition {0} '{1}' ",
							operatorsForLadderPosition.SelectedValue, 
							LadderPosition.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsInBattle.Text ) ) {
					writer.Write( "{2} e.IsInBattle {0} '{1}' ",
							operatorsForIsInBattle.SelectedValue, 
							IsInBattle.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( RestUntil.Text ) ) {
					writer.Write( "{2} e.RestUntil {0} '{1}' ",
							operatorsForRestUntil.SelectedValue, 
							RestUntil.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( StoppedUntil.Text ) ) {
					writer.Write( "{2} e.StoppedUntil {0} '{1}' ",
							operatorsForStoppedUntil.SelectedValue, 
							StoppedUntil.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( AvailableVacationTicks.Text ) ) {
					writer.Write( "{2} e.AvailableVacationTicks {0} '{1}' ",
							operatorsForAvailableVacationTicks.SelectedValue, 
							AvailableVacationTicks.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( VacationStartTick.Text ) ) {
					writer.Write( "{2} e.VacationStartTick {0} '{1}' ",
							operatorsForVacationStartTick.SelectedValue, 
							VacationStartTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( VacationEndtick.Text ) ) {
					writer.Write( "{2} e.VacationEndtick {0} '{1}' ",
							operatorsForVacationEndtick.SelectedValue, 
							VacationEndtick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( AutoStartVacations.Text ) ) {
					writer.Write( "{2} e.AutoStartVacations {0} '{1}' ",
							operatorsForAutoStartVacations.SelectedValue, 
							AutoStartVacations.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ReferrerId.Text ) ) {
					writer.Write( "{2} e.ReferrerId {0} '{1}' ",
							operatorsForReferrerId.SelectedValue, 
							ReferrerId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CanChangeName.Text ) ) {
					writer.Write( "{2} e.CanChangeName {0} '{1}' ",
							operatorsForCanChangeName.SelectedValue, 
							CanChangeName.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( WebSite.Text ) ) {
					writer.Write( "{2} e.WebSite {0} '{1}' ",
							operatorsForWebSite.SelectedValue, 
							WebSite.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TutorialState.Text ) ) {
					writer.Write( "{2} e.TutorialState {0} '{1}' ",
							operatorsForTutorialState.SelectedValue, 
							TutorialState.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( DuplicatedIds.Text ) ) {
					writer.Write( "{2} e.DuplicatedIds {0} '{1}' ",
							operatorsForDuplicatedIds.SelectedValue, 
							DuplicatedIds.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NumberOfWarnings.Text ) ) {
					writer.Write( "{2} e.NumberOfWarnings {0} '{1}' ",
							operatorsForNumberOfWarnings.SelectedValue, 
							NumberOfWarnings.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( AcceptedTerms.Text ) ) {
					writer.Write( "{2} e.AcceptedTerms {0} '{1}' ",
							operatorsForAcceptedTerms.SelectedValue, 
							AcceptedTerms.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( WarningPoints.Text ) ) {
					writer.Write( "{2} e.WarningPoints {0} '{1}' ",
							operatorsForWarningPoints.SelectedValue, 
							WarningPoints.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastWarningDate.Text ) ) {
					writer.Write( "{2} e.LastWarningDate {0} '{1}' ",
							operatorsForLastWarningDate.SelectedValue, 
							LastWarningDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BotUrl.Text ) ) {
					writer.Write( "{2} e.BotUrl {0} '{1}' ",
							operatorsForBotUrl.SelectedValue, 
							BotUrl.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ReferrerPriceCount.Text ) ) {
					writer.Write( "{2} e.ReferrerPriceCount {0} '{1}' ",
							operatorsForReferrerPriceCount.SelectedValue, 
							ReferrerPriceCount.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Name.Text ) ) {
					writer.Write( "{2} e.Name {0} '{1}' ",
							operatorsForName.SelectedValue, 
							Name.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Password.Text ) ) {
					writer.Write( "{2} e.Password {0} '{1}' ",
							operatorsForPassword.SelectedValue, 
							Password.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Email.Text ) ) {
					writer.Write( "{2} e.Email {0} '{1}' ",
							operatorsForEmail.SelectedValue, 
							Email.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Ip.Text ) ) {
					writer.Write( "{2} e.Ip {0} '{1}' ",
							operatorsForIp.SelectedValue, 
							Ip.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( RegistDate.Text ) ) {
					writer.Write( "{2} e.RegistDate {0} '{1}' ",
							operatorsForRegistDate.SelectedValue, 
							RegistDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastLogin.Text ) ) {
					writer.Write( "{2} e.LastLogin {0} '{1}' ",
							operatorsForLastLogin.SelectedValue, 
							LastLogin.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Approved.Text ) ) {
					writer.Write( "{2} e.Approved {0} '{1}' ",
							operatorsForApproved.SelectedValue, 
							Approved.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsOnline.Text ) ) {
					writer.Write( "{2} e.IsOnline {0} '{1}' ",
							operatorsForIsOnline.SelectedValue, 
							IsOnline.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Locked.Text ) ) {
					writer.Write( "{2} e.Locked {0} '{1}' ",
							operatorsForLocked.SelectedValue, 
							Locked.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Locale.Text ) ) {
					writer.Write( "{2} e.Locale {0} '{1}' ",
							operatorsForLocale.SelectedValue, 
							Locale.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ConfirmationCode.Text ) ) {
					writer.Write( "{2} e.ConfirmationCode {0} '{1}' ",
							operatorsForConfirmationCode.SelectedValue, 
							ConfirmationCode.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( RawRoles.Text ) ) {
					writer.Write( "{2} e.RawRoles {0} '{1}' ",
							operatorsForRawRoles.SelectedValue, 
							RawRoles.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Principal>.GetWhereKey("Principal")] = writer.ToString();
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
			IsBot.ID = "searchIsBot";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsBot</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsBot ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsBot );
			Controls.Add( new LiteralControl("</td><tr>") );
			MyStatsId.ID = "searchMyStatsId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MyStatsId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMyStatsId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MyStatsId );
			Controls.Add( new LiteralControl("</td><tr>") );
			EloRanking.ID = "searchEloRanking";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>EloRanking</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEloRanking ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( EloRanking );
			Controls.Add( new LiteralControl("</td><tr>") );
			ReceiveMail.ID = "searchReceiveMail";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ReceiveMail</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForReceiveMail ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ReceiveMail );
			Controls.Add( new LiteralControl("</td><tr>") );
			Credits.ID = "searchCredits";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Credits</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCredits ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Credits );
			Controls.Add( new LiteralControl("</td><tr>") );
			LadderActive.ID = "searchLadderActive";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LadderActive</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLadderActive ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LadderActive );
			Controls.Add( new LiteralControl("</td><tr>") );
			LadderPosition.ID = "searchLadderPosition";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LadderPosition</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLadderPosition ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LadderPosition );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsInBattle.ID = "searchIsInBattle";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsInBattle</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsInBattle ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsInBattle );
			Controls.Add( new LiteralControl("</td><tr>") );
			RestUntil.ID = "searchRestUntil";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RestUntil</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRestUntil ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RestUntil );
			Controls.Add( new LiteralControl("</td><tr>") );
			StoppedUntil.ID = "searchStoppedUntil";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>StoppedUntil</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStoppedUntil ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( StoppedUntil );
			Controls.Add( new LiteralControl("</td><tr>") );
			AvailableVacationTicks.ID = "searchAvailableVacationTicks";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>AvailableVacationTicks</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAvailableVacationTicks ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( AvailableVacationTicks );
			Controls.Add( new LiteralControl("</td><tr>") );
			VacationStartTick.ID = "searchVacationStartTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>VacationStartTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForVacationStartTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( VacationStartTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			VacationEndtick.ID = "searchVacationEndtick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>VacationEndtick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForVacationEndtick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( VacationEndtick );
			Controls.Add( new LiteralControl("</td><tr>") );
			AutoStartVacations.ID = "searchAutoStartVacations";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>AutoStartVacations</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAutoStartVacations ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( AutoStartVacations );
			Controls.Add( new LiteralControl("</td><tr>") );
			ReferrerId.ID = "searchReferrerId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ReferrerId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForReferrerId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ReferrerId );
			Controls.Add( new LiteralControl("</td><tr>") );
			CanChangeName.ID = "searchCanChangeName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CanChangeName</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCanChangeName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CanChangeName );
			Controls.Add( new LiteralControl("</td><tr>") );
			Avatar.ID = "searchAvatar";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Avatar</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAvatar ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Avatar );
			Controls.Add( new LiteralControl("</td><tr>") );
			WebSite.ID = "searchWebSite";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>WebSite</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWebSite ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( WebSite );
			Controls.Add( new LiteralControl("</td><tr>") );
			TutorialState.ID = "searchTutorialState";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TutorialState</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTutorialState ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TutorialState );
			Controls.Add( new LiteralControl("</td><tr>") );
			DuplicatedIds.ID = "searchDuplicatedIds";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>DuplicatedIds</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDuplicatedIds ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( DuplicatedIds );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberOfWarnings.ID = "searchNumberOfWarnings";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberOfWarnings</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberOfWarnings ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberOfWarnings );
			Controls.Add( new LiteralControl("</td><tr>") );
			AcceptedTerms.ID = "searchAcceptedTerms";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>AcceptedTerms</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAcceptedTerms ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( AcceptedTerms );
			Controls.Add( new LiteralControl("</td><tr>") );
			WarningPoints.ID = "searchWarningPoints";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>WarningPoints</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWarningPoints ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( WarningPoints );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastWarningDate.ID = "searchLastWarningDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastWarningDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastWarningDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastWarningDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			BotUrl.ID = "searchBotUrl";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BotUrl</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBotUrl ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BotUrl );
			Controls.Add( new LiteralControl("</td><tr>") );
			ReferrerPriceCount.ID = "searchReferrerPriceCount";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ReferrerPriceCount</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForReferrerPriceCount ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ReferrerPriceCount );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsOnVacations.ID = "searchIsOnVacations";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsOnVacations</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsOnVacations ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsOnVacations );
			Controls.Add( new LiteralControl("</td><tr>") );
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
			Controls.Add( new LiteralControl("</td><tr>") );
			Password.ID = "searchPassword";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Password</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPassword ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Password );
			Controls.Add( new LiteralControl("</td><tr>") );
			Email.ID = "searchEmail";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Email</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEmail ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Email );
			Controls.Add( new LiteralControl("</td><tr>") );
			Ip.ID = "searchIp";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Ip</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIp ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Ip );
			Controls.Add( new LiteralControl("</td><tr>") );
			RegistDate.ID = "searchRegistDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RegistDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRegistDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RegistDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastLogin.ID = "searchLastLogin";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastLogin</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastLogin ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastLogin );
			Controls.Add( new LiteralControl("</td><tr>") );
			Approved.ID = "searchApproved";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Approved</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForApproved ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Approved );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsOnline.ID = "searchIsOnline";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsOnline</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsOnline ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsOnline );
			Controls.Add( new LiteralControl("</td><tr>") );
			Locked.ID = "searchLocked";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Locked</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLocked ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Locked );
			Controls.Add( new LiteralControl("</td><tr>") );
			Locale.ID = "searchLocale";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Locale</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLocale ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Locale );
			Controls.Add( new LiteralControl("</td><tr>") );
			ConfirmationCode.ID = "searchConfirmationCode";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ConfirmationCode</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForConfirmationCode ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ConfirmationCode );
			Controls.Add( new LiteralControl("</td><tr>") );
			RawRoles.ID = "searchRawRoles";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RawRoles</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRawRoles ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RawRoles );
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
