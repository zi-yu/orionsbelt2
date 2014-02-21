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
	public abstract partial class PlayerStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private int lastProcessedTick;
		private string intrinsicLimits;
		private int score;
		private string allianceRank;
		private string race;
		private int homePlanetId;
		private int pirateRanking;
		private int bountyRanking;
		private int merchantRanking;
		private int gladiatorRanking;
		private int colonizerRanking;
		private string intrinsicQuantities;
		private int planetLevel;
		private string questContextLevel;
		private bool active;
		private string avatar;
		private int ultimateWeaponLevel;
		private string services;
		private int ultimateWeaponCooldown;
		private int activatedInTick;
		private bool isGeneralActive;
		private int generalId;
		private string generalName;
		private string generalFriendlyName;
		private bool isPrimary;
		private bool isOnVacations;
		private int totalPosts;
		private string signature;
		private string forumRole;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PlayerStorage's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the PlayerStorage's LastProcessedTick
        /// </summary>
		public virtual int LastProcessedTick {
			set{ this.lastProcessedTick = value;}
			get{ return this.lastProcessedTick;}
		}

		/// <summary>
        /// Gets the PlayerStorage's IntrinsicLimits
        /// </summary>
		public virtual string IntrinsicLimits {
			set{ this.intrinsicLimits = value;}
			get{ return this.intrinsicLimits;}
		}

		/// <summary>
        /// Gets the PlayerStorage's Score
        /// </summary>
		public virtual int Score {
			set{ this.score = value;}
			get{ return this.score;}
		}

		/// <summary>
        /// Gets the PlayerStorage's AllianceRank
        /// </summary>
		public virtual string AllianceRank {
			set{ this.allianceRank = value;}
			get{ return this.allianceRank;}
		}

		/// <summary>
        /// Gets the PlayerStorage's Race
        /// </summary>
		public virtual string Race {
			set{ this.race = value;}
			get{ return this.race;}
		}

		/// <summary>
        /// Gets the PlayerStorage's HomePlanetId
        /// </summary>
		public virtual int HomePlanetId {
			set{ this.homePlanetId = value;}
			get{ return this.homePlanetId;}
		}

		/// <summary>
        /// Gets the PlayerStorage's PirateRanking
        /// </summary>
		public virtual int PirateRanking {
			set{ this.pirateRanking = value;}
			get{ return this.pirateRanking;}
		}

		/// <summary>
        /// Gets the PlayerStorage's BountyRanking
        /// </summary>
		public virtual int BountyRanking {
			set{ this.bountyRanking = value;}
			get{ return this.bountyRanking;}
		}

		/// <summary>
        /// Gets the PlayerStorage's MerchantRanking
        /// </summary>
		public virtual int MerchantRanking {
			set{ this.merchantRanking = value;}
			get{ return this.merchantRanking;}
		}

		/// <summary>
        /// Gets the PlayerStorage's GladiatorRanking
        /// </summary>
		public virtual int GladiatorRanking {
			set{ this.gladiatorRanking = value;}
			get{ return this.gladiatorRanking;}
		}

		/// <summary>
        /// Gets the PlayerStorage's ColonizerRanking
        /// </summary>
		public virtual int ColonizerRanking {
			set{ this.colonizerRanking = value;}
			get{ return this.colonizerRanking;}
		}

		/// <summary>
        /// Gets the PlayerStorage's IntrinsicQuantities
        /// </summary>
		public virtual string IntrinsicQuantities {
			set{ this.intrinsicQuantities = value;}
			get{ return this.intrinsicQuantities;}
		}

		/// <summary>
        /// Gets the PlayerStorage's PlanetLevel
        /// </summary>
		public virtual int PlanetLevel {
			set{ this.planetLevel = value;}
			get{ return this.planetLevel;}
		}

		/// <summary>
        /// Gets the PlayerStorage's QuestContextLevel
        /// </summary>
		public virtual string QuestContextLevel {
			set{ this.questContextLevel = value;}
			get{ return this.questContextLevel;}
		}

		/// <summary>
        /// Gets the PlayerStorage's Active
        /// </summary>
		public virtual bool Active {
			set{ this.active = value;}
			get{ return this.active;}
		}

		/// <summary>
        /// Gets the PlayerStorage's Avatar
        /// </summary>
		public virtual string Avatar {
			set{ this.avatar = value;}
			get{ return this.avatar;}
		}

		/// <summary>
        /// Gets the PlayerStorage's UltimateWeaponLevel
        /// </summary>
		public virtual int UltimateWeaponLevel {
			set{ this.ultimateWeaponLevel = value;}
			get{ return this.ultimateWeaponLevel;}
		}

		/// <summary>
        /// Gets the PlayerStorage's Services
        /// </summary>
		public virtual string Services {
			set{ this.services = value;}
			get{ return this.services;}
		}

		/// <summary>
        /// Gets the PlayerStorage's UltimateWeaponCooldown
        /// </summary>
		public virtual int UltimateWeaponCooldown {
			set{ this.ultimateWeaponCooldown = value;}
			get{ return this.ultimateWeaponCooldown;}
		}

		/// <summary>
        /// Gets the PlayerStorage's ActivatedInTick
        /// </summary>
		public virtual int ActivatedInTick {
			set{ this.activatedInTick = value;}
			get{ return this.activatedInTick;}
		}

		/// <summary>
        /// Gets the PlayerStorage's IsGeneralActive
        /// </summary>
		public virtual bool IsGeneralActive {
			set{ this.isGeneralActive = value;}
			get{ return this.isGeneralActive;}
		}

		/// <summary>
        /// Gets the PlayerStorage's GeneralId
        /// </summary>
		public virtual int GeneralId {
			set{ this.generalId = value;}
			get{ return this.generalId;}
		}

		/// <summary>
        /// Gets the PlayerStorage's GeneralName
        /// </summary>
		public virtual string GeneralName {
			set{ this.generalName = value;}
			get{ return this.generalName;}
		}

		/// <summary>
        /// Gets the PlayerStorage's GeneralFriendlyName
        /// </summary>
		public virtual string GeneralFriendlyName {
			set{ this.generalFriendlyName = value;}
			get{ return this.generalFriendlyName;}
		}

		/// <summary>
        /// Gets the PlayerStorage's IsPrimary
        /// </summary>
		public virtual bool IsPrimary {
			set{ this.isPrimary = value;}
			get{ return this.isPrimary;}
		}

		/// <summary>
        /// Gets the PlayerStorage's IsOnVacations
        /// </summary>
		public virtual bool IsOnVacations {
			set{ this.isOnVacations = value;}
			get{ return this.isOnVacations;}
		}

		/// <summary>
        /// Gets the PlayerStorage's TotalPosts
        /// </summary>
		public virtual int TotalPosts {
			set{ this.totalPosts = value;}
			get{ return this.totalPosts;}
		}

		/// <summary>
        /// Gets the PlayerStorage's Signature
        /// </summary>
		public virtual string Signature {
			set{ this.signature = value;}
			get{ return this.signature;}
		}

		/// <summary>
        /// Gets the PlayerStorage's ForumRole
        /// </summary>
		public virtual string ForumRole {
			set{ this.forumRole = value;}
			get{ return this.forumRole;}
		}

		/// <summary>
        /// Gets the PlayerStorage's Actions
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<TimedActionStorage> Actions {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Planets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlanetStorage> Planets {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Resources
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlanetResourceStorage> Resources {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Sector
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<SectorStorage> Sector {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's DiscoveredUniverse
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<FogOfWarStorage> DiscoveredUniverse {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Fleets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Fleet> Fleets {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's SpecialSectores
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<UniverseSpecialSector> SpecialSectores {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Quests
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<QuestStorage> Quests {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Bids
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<BidHistorical> Bids {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Auction
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<AuctionHouse> Auction {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Arena
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ArenaStorage> Arena {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's MyFriends
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<FriendOrFoe> MyFriends {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's OtherFriends
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<FriendOrFoe> OtherFriends {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Medals
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Medal> Medals {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Messages
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PrivateBoard> Messages {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Assets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Asset> Assets {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Necessities
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Necessity> Necessities {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Offerings
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Offering> Offerings {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Forfeit
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Offering> Forfeit {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Threads
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ForumThread> Threads {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Posts
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ForumPost> Posts {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's ReadMarkings
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ForumReadMarking> ReadMarkings {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Principal
        /// </summary>
		public abstract Principal Principal {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Alliance
        /// </summary>
		public abstract AllianceStorage Alliance {get;set; }

		/// <summary>
        /// Gets the PlayerStorage's Stats
        /// </summary>
		public abstract PlayerStats Stats {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PlayerStorage) );
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
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = LastProcessedTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastProcessedTick\" : \"{0}\", ", str);
			str = IntrinsicLimits.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IntrinsicLimits\" : \"{0}\", ", str);
			str = Score.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Score\" : \"{0}\", ", str);
			str = AllianceRank.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"AllianceRank\" : \"{0}\", ", str);
			str = Race.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Race\" : \"{0}\", ", str);
			str = HomePlanetId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HomePlanetId\" : \"{0}\", ", str);
			str = PirateRanking.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PirateRanking\" : \"{0}\", ", str);
			str = BountyRanking.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BountyRanking\" : \"{0}\", ", str);
			str = MerchantRanking.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MerchantRanking\" : \"{0}\", ", str);
			str = GladiatorRanking.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"GladiatorRanking\" : \"{0}\", ", str);
			str = ColonizerRanking.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ColonizerRanking\" : \"{0}\", ", str);
			str = IntrinsicQuantities.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IntrinsicQuantities\" : \"{0}\", ", str);
			str = PlanetLevel.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PlanetLevel\" : \"{0}\", ", str);
			str = QuestContextLevel.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"QuestContextLevel\" : \"{0}\", ", str);
			str = Active.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Active\" : \"{0}\", ", str);
			str = Avatar.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Avatar\" : \"{0}\", ", str);
			str = UltimateWeaponLevel.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UltimateWeaponLevel\" : \"{0}\", ", str);
			str = Services.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Services\" : \"{0}\", ", str);
			str = UltimateWeaponCooldown.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UltimateWeaponCooldown\" : \"{0}\", ", str);
			str = ActivatedInTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ActivatedInTick\" : \"{0}\", ", str);
			str = IsGeneralActive.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsGeneralActive\" : \"{0}\", ", str);
			str = GeneralId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"GeneralId\" : \"{0}\", ", str);
			str = GeneralName.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"GeneralName\" : \"{0}\", ", str);
			str = GeneralFriendlyName.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"GeneralFriendlyName\" : \"{0}\", ", str);
			str = IsPrimary.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsPrimary\" : \"{0}\", ", str);
			str = IsOnVacations.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsOnVacations\" : \"{0}\", ", str);
			str = TotalPosts.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TotalPosts\" : \"{0}\", ", str);
			str = Signature.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Signature\" : \"{0}\", ", str);
			str = ForumRole.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ForumRole\" : \"{0}\", ", str);
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
			get { return "PlayerStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PlayerStorage other = obj as PlayerStorage;
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
		
	};
}
