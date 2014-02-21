	// WARNING: Generated File! Do not modify by hand!
	// *************************************************************

using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using Loki.DataRepresentation;
using Loki;

namespace OrionsBelt.Core {
	//[Serializable()]
	public abstract partial class Principal : OrionsBelt.Core.Entity, IDescriptable, IComparable ,System.Security.Principal.IPrincipal  {

		#region Fields

		private bool isBot;
		private int myStatsId;
		private int eloRanking;
		private bool receiveMail;
		private int credits;
		private bool ladderActive;
		private int ladderPosition;
		private int isInBattle;
		private int restUntil;
		private int stoppedUntil;
		private int availableVacationTicks;
		private int vacationStartTick;
		private int vacationEndtick;
		private bool autoStartVacations;
		private int referrerId;
		private bool canChangeName;
		private string avatar;
		private string webSite;
		private int tutorialState;
		private string duplicatedIds;
		private int numberOfWarnings;
		private bool acceptedTerms;
		private int warningPoints;
		private DateTime lastWarningDate = DateTime.Now;
		private string botUrl;
		private int referrerPriceCount;
		private bool isOnVacations;
		private string name;
		private string password;
		private string email;
		private string ip;
		private DateTime registDate = DateTime.Now;
		private DateTime lastLogin = DateTime.Now;
		private bool approved;
		private bool isOnline;
		private bool locked;
		private string locale;
		private string confirmationCode;
		private string rawRoles;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Principal's IsBot
        /// </summary>
		public virtual bool IsBot {
			set{ this.isBot = value;}
			get{ return this.isBot;}
		}

		/// <summary>
        /// Gets the Principal's MyStatsId
        /// </summary>
		public virtual int MyStatsId {
			set{ this.myStatsId = value;}
			get{ return this.myStatsId;}
		}

		/// <summary>
        /// Gets the Principal's EloRanking
        /// </summary>
		public virtual int EloRanking {
			set{ this.eloRanking = value;}
			get{ return this.eloRanking;}
		}

		/// <summary>
        /// Gets the Principal's ReceiveMail
        /// </summary>
		public virtual bool ReceiveMail {
			set{ this.receiveMail = value;}
			get{ return this.receiveMail;}
		}

		/// <summary>
        /// Gets the Principal's Credits
        /// </summary>
		public virtual int Credits {
			set{ this.credits = value;}
			get{ return this.credits;}
		}

		/// <summary>
        /// Gets the Principal's LadderActive
        /// </summary>
		public virtual bool LadderActive {
			set{ this.ladderActive = value;}
			get{ return this.ladderActive;}
		}

		/// <summary>
        /// Gets the Principal's LadderPosition
        /// </summary>
		public virtual int LadderPosition {
			set{ this.ladderPosition = value;}
			get{ return this.ladderPosition;}
		}

		/// <summary>
        /// Gets the Principal's IsInBattle
        /// </summary>
		public virtual int IsInBattle {
			set{ this.isInBattle = value;}
			get{ return this.isInBattle;}
		}

		/// <summary>
        /// Gets the Principal's RestUntil
        /// </summary>
		public virtual int RestUntil {
			set{ this.restUntil = value;}
			get{ return this.restUntil;}
		}

		/// <summary>
        /// Gets the Principal's StoppedUntil
        /// </summary>
		public virtual int StoppedUntil {
			set{ this.stoppedUntil = value;}
			get{ return this.stoppedUntil;}
		}

		/// <summary>
        /// Gets the Principal's AvailableVacationTicks
        /// </summary>
		public virtual int AvailableVacationTicks {
			set{ this.availableVacationTicks = value;}
			get{ return this.availableVacationTicks;}
		}

		/// <summary>
        /// Gets the Principal's VacationStartTick
        /// </summary>
		public virtual int VacationStartTick {
			set{ this.vacationStartTick = value;}
			get{ return this.vacationStartTick;}
		}

		/// <summary>
        /// Gets the Principal's VacationEndtick
        /// </summary>
		public virtual int VacationEndtick {
			set{ this.vacationEndtick = value;}
			get{ return this.vacationEndtick;}
		}

		/// <summary>
        /// Gets the Principal's AutoStartVacations
        /// </summary>
		public virtual bool AutoStartVacations {
			set{ this.autoStartVacations = value;}
			get{ return this.autoStartVacations;}
		}

		/// <summary>
        /// Gets the Principal's ReferrerId
        /// </summary>
		public virtual int ReferrerId {
			set{ this.referrerId = value;}
			get{ return this.referrerId;}
		}

		/// <summary>
        /// Gets the Principal's CanChangeName
        /// </summary>
		public virtual bool CanChangeName {
			set{ this.canChangeName = value;}
			get{ return this.canChangeName;}
		}

		/// <summary>
        /// Gets the Principal's Avatar
        /// </summary>
		public virtual string Avatar {
			set{ this.avatar = value;}
			get{ return this.avatar;}
		}

		/// <summary>
        /// Gets the Principal's WebSite
        /// </summary>
		public virtual string WebSite {
			set{ this.webSite = value;}
			get{ return this.webSite;}
		}

		/// <summary>
        /// Gets the Principal's TutorialState
        /// </summary>
		public virtual int TutorialState {
			set{ this.tutorialState = value;}
			get{ return this.tutorialState;}
		}

		/// <summary>
        /// Gets the Principal's DuplicatedIds
        /// </summary>
		public virtual string DuplicatedIds {
			set{ this.duplicatedIds = value;}
			get{ return this.duplicatedIds;}
		}

		/// <summary>
        /// Gets the Principal's NumberOfWarnings
        /// </summary>
		public virtual int NumberOfWarnings {
			set{ this.numberOfWarnings = value;}
			get{ return this.numberOfWarnings;}
		}

		/// <summary>
        /// Gets the Principal's AcceptedTerms
        /// </summary>
		public virtual bool AcceptedTerms {
			set{ this.acceptedTerms = value;}
			get{ return this.acceptedTerms;}
		}

		/// <summary>
        /// Gets the Principal's WarningPoints
        /// </summary>
		public virtual int WarningPoints {
			set{ this.warningPoints = value;}
			get{ return this.warningPoints;}
		}

		/// <summary>
        /// Gets the Principal's LastWarningDate
        /// </summary>
		public virtual DateTime LastWarningDate {
			set{ this.lastWarningDate = value;}
			get{ return this.lastWarningDate;}
		}

		/// <summary>
        /// Gets the Principal's BotUrl
        /// </summary>
		public virtual string BotUrl {
			set{ this.botUrl = value;}
			get{ return this.botUrl;}
		}

		/// <summary>
        /// Gets the Principal's ReferrerPriceCount
        /// </summary>
		public virtual int ReferrerPriceCount {
			set{ this.referrerPriceCount = value;}
			get{ return this.referrerPriceCount;}
		}

		/// <summary>
        /// Gets the Principal's IsOnVacations
        /// </summary>
		public virtual bool IsOnVacations {
			set{ this.isOnVacations = value;}
			get{ return this.isOnVacations;}
		}

		/// <summary>
        /// Gets the Principal's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the Principal's Password
        /// </summary>
		public virtual string Password {
			set{ this.password = value;}
			get{ return this.password;}
		}

		/// <summary>
        /// Gets the Principal's Email
        /// </summary>
		public virtual string Email {
			set{ this.email = value;}
			get{ return this.email;}
		}

		/// <summary>
        /// Gets the Principal's Ip
        /// </summary>
		public virtual string Ip {
			set{ this.ip = value;}
			get{ return this.ip;}
		}

		/// <summary>
        /// Gets the Principal's RegistDate
        /// </summary>
		public virtual DateTime RegistDate {
			set{ this.registDate = value;}
			get{ return this.registDate;}
		}

		/// <summary>
        /// Gets the Principal's LastLogin
        /// </summary>
		public virtual DateTime LastLogin {
			set{ this.lastLogin = value;}
			get{ return this.lastLogin;}
		}

		/// <summary>
        /// Gets the Principal's Approved
        /// </summary>
		public virtual bool Approved {
			set{ this.approved = value;}
			get{ return this.approved;}
		}

		/// <summary>
        /// Gets the Principal's IsOnline
        /// </summary>
		public virtual bool IsOnline {
			set{ this.isOnline = value;}
			get{ return this.isOnline;}
		}

		/// <summary>
        /// Gets the Principal's Locked
        /// </summary>
		public virtual bool Locked {
			set{ this.locked = value;}
			get{ return this.locked;}
		}

		/// <summary>
        /// Gets the Principal's Locale
        /// </summary>
		public virtual string Locale {
			set{ this.locale = value;}
			get{ return this.locale;}
		}

		/// <summary>
        /// Gets the Principal's ConfirmationCode
        /// </summary>
		public virtual string ConfirmationCode {
			set{ this.confirmationCode = value;}
			get{ return this.confirmationCode;}
		}

		/// <summary>
        /// Gets the Principal's RawRoles
        /// </summary>
		public virtual string RawRoles {
			set{ this.rawRoles = value;}
			get{ return this.rawRoles;}
		}

		/// <summary>
        /// Gets the Principal's Tournaments
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PrincipalTournament> Tournaments {get;set; }

		/// <summary>
        /// Gets the Principal's Fleets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Fleet> Fleets {get;set; }

		/// <summary>
        /// Gets the Principal's Player
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlayerStorage> Player {get;set; }

		/// <summary>
        /// Gets the Principal's Medals
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Medal> Medals {get;set; }

		/// <summary>
        /// Gets the Principal's CreatedCampaigns
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Campaign> CreatedCampaigns {get;set; }

		/// <summary>
        /// Gets the Principal's Campaigns
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<CampaignStatus> Campaigns {get;set; }

		/// <summary>
        /// Gets the Principal's UsedCards
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<BonusCard> UsedCards {get;set; }

		/// <summary>
        /// Gets the Principal's Promotions
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Promotion> Promotions {get;set; }

		/// <summary>
        /// Gets the Principal's ActivePromotions
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ActivatedPromotion> ActivePromotions {get;set; }

		/// <summary>
        /// Gets the Principal's Exceptions
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ExceptionInfo> Exceptions {get;set; }

		/// <summary>
        /// Gets the Principal's Team
        /// </summary>
		public abstract TeamStorage Team {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Principal) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Name);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = IsBot.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsBot\" : \"{0}\", ", str);
			str = MyStatsId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MyStatsId\" : \"{0}\", ", str);
			str = EloRanking.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EloRanking\" : \"{0}\", ", str);
			str = ReceiveMail.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ReceiveMail\" : \"{0}\", ", str);
			str = Credits.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Credits\" : \"{0}\", ", str);
			str = LadderActive.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LadderActive\" : \"{0}\", ", str);
			str = LadderPosition.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LadderPosition\" : \"{0}\", ", str);
			str = IsInBattle.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsInBattle\" : \"{0}\", ", str);
			str = RestUntil.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RestUntil\" : \"{0}\", ", str);
			str = StoppedUntil.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"StoppedUntil\" : \"{0}\", ", str);
			str = AvailableVacationTicks.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"AvailableVacationTicks\" : \"{0}\", ", str);
			str = VacationStartTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"VacationStartTick\" : \"{0}\", ", str);
			str = VacationEndtick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"VacationEndtick\" : \"{0}\", ", str);
			str = AutoStartVacations.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"AutoStartVacations\" : \"{0}\", ", str);
			str = ReferrerId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ReferrerId\" : \"{0}\", ", str);
			str = CanChangeName.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CanChangeName\" : \"{0}\", ", str);
			str = Avatar.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Avatar\" : \"{0}\", ", str);
			str = WebSite.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"WebSite\" : \"{0}\", ", str);
			str = TutorialState.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TutorialState\" : \"{0}\", ", str);
			str = DuplicatedIds.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"DuplicatedIds\" : \"{0}\", ", str);
			str = NumberOfWarnings.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberOfWarnings\" : \"{0}\", ", str);
			str = AcceptedTerms.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"AcceptedTerms\" : \"{0}\", ", str);
			str = WarningPoints.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"WarningPoints\" : \"{0}\", ", str);
			str = LastWarningDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastWarningDate\" : \"{0}\", ", str);
			str = BotUrl.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BotUrl\" : \"{0}\", ", str);
			str = ReferrerPriceCount.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ReferrerPriceCount\" : \"{0}\", ", str);
			str = IsOnVacations.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsOnVacations\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = Password.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Password\" : \"{0}\", ", str);
			str = Email.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Email\" : \"{0}\", ", str);
			str = Ip.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Ip\" : \"{0}\", ", str);
			str = RegistDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RegistDate\" : \"{0}\", ", str);
			str = LastLogin.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastLogin\" : \"{0}\", ", str);
			str = Approved.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Approved\" : \"{0}\", ", str);
			str = IsOnline.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsOnline\" : \"{0}\", ", str);
			str = Locked.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Locked\" : \"{0}\", ", str);
			str = Locale.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Locale\" : \"{0}\", ", str);
			str = ConfirmationCode.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ConfirmationCode\" : \"{0}\", ", str);
			str = RawRoles.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RawRoles\" : \"{0}\", ", str);
			str = CreatedDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CreatedDate\" : \"{0}\", ", str);
			str = UpdatedDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UpdatedDate\" : \"{0}\", ", str);
			str = LastActionUserId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastActionUserId\" : \"{0}\", ", str);
			writer.Write("\"TypeName\" : \"{0}\" ", TypeName);
			writer.Write("}");
			return writer.ToString();
		}

		public override string TypeName { 
			get { return "Principal"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Principal other = obj as Principal;
			if( other == null ) {
				// we don't know how to compare diferent entities
				return 0;
			}
			
			return other.Id.CompareTo(this.Id);
		}

		#endregion IComparable Implementation

		#region Overrided Members
		
		public override string ToString()
		{
			if( Name == null ) {
				return string.Empty;
			}
			return Name.ToString();
		}
		
		#endregion Overrided Members
		
		#region IPrincipal Members
		
		/// <summary>
        /// The correct display name
        /// </summary>
        public string DisplayName {
            get { 
                try {
                    int idx = Name.LastIndexOf(":");
                    if (idx < 0) {
                        return Name;
                    }
                    idx += 1;
                    return Name.Substring(idx, Name.Length - idx); 
                } catch( Exception ex ) {
                    return Name;
                }
            }
        }

		System.Security.Principal.IIdentity identity = null;

		[XmlIgnore()]
		public virtual System.Security.Principal.IIdentity Identity {
			get { return identity; }
			set { identity = value; }
		}
		
		private static readonly char[] RolesSeparator = {','};
        private IEnumerable<string> roles = null;
        [XmlIgnore()]
        public virtual IEnumerable<string> Roles {
            get {
                if (roles == null) {
                    if (!string.IsNullOrEmpty(RawRoles)) {
                        roles = RawRoles.Split(RolesSeparator, StringSplitOptions.RemoveEmptyEntries);
                    }
                    if (roles == null) {
                        roles = new string[0];
                    }
                }
                return roles; 
            }
            set { 
                roles = value; 
            }
        }

		public virtual bool IsInRole( string role ) {
			if( string.IsNullOrEmpty( role ) ) {
				return false;
			}
			if( role == "user" ) {
				return true;
			}
			return RoleManager.IsInRole(role, Roles);
		}

		#endregion
		
	};
}
