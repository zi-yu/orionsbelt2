using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Loki.Exceptions;
using Loki.Interfaces;
using Loki.Generic;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {

	/// <summary>
    /// Specialized Memory class for PlayerStorage
    /// </summary>
	public class SpecializedMemoryPlayerStorage : PlayerStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<TimedActionStorage> actions;
		private System.Collections.Generic.IList<PlanetStorage> planets;
		private System.Collections.Generic.IList<PlanetResourceStorage> resources;
		private System.Collections.Generic.IList<SectorStorage> sector;
		private System.Collections.Generic.IList<FogOfWarStorage> discoveredUniverse;
		private System.Collections.Generic.IList<Fleet> fleets;
		private System.Collections.Generic.IList<UniverseSpecialSector> specialSectores;
		private System.Collections.Generic.IList<QuestStorage> quests;
		private System.Collections.Generic.IList<BidHistorical> bids;
		private System.Collections.Generic.IList<AuctionHouse> auction;
		private System.Collections.Generic.IList<ArenaStorage> arena;
		private System.Collections.Generic.IList<FriendOrFoe> myFriends;
		private System.Collections.Generic.IList<FriendOrFoe> otherFriends;
		private System.Collections.Generic.IList<Medal> medals;
		private System.Collections.Generic.IList<PrivateBoard> messages;
		private System.Collections.Generic.IList<Asset> assets;
		private System.Collections.Generic.IList<Necessity> necessities;
		private System.Collections.Generic.IList<Offering> offerings;
		private System.Collections.Generic.IList<Offering> forfeit;
		private System.Collections.Generic.IList<ForumThread> threads;
		private System.Collections.Generic.IList<ForumPost> posts;
		private System.Collections.Generic.IList<ForumReadMarking> readMarkings;
		private Principal principal;
		private AllianceStorage alliance;
		private PlayerStats stats;

		#endregion Fields
		
		#region PlayerStorage Implementation
	
		/// <summary>
        /// Gets the PlayerStorage's Actions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<TimedActionStorage> Actions {
			get {
				if( this.actions == null ) {
					this.actions = new List<TimedActionStorage>();
				}
				return this.actions;
			} 
			set {
				this.actions = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Planets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlanetStorage> Planets {
			get {
				if( this.planets == null ) {
					this.planets = new List<PlanetStorage>();
				}
				return this.planets;
			} 
			set {
				this.planets = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Resources
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlanetResourceStorage> Resources {
			get {
				if( this.resources == null ) {
					this.resources = new List<PlanetResourceStorage>();
				}
				return this.resources;
			} 
			set {
				this.resources = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Sector
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<SectorStorage> Sector {
			get {
				if( this.sector == null ) {
					this.sector = new List<SectorStorage>();
				}
				return this.sector;
			} 
			set {
				this.sector = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's DiscoveredUniverse
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<FogOfWarStorage> DiscoveredUniverse {
			get {
				if( this.discoveredUniverse == null ) {
					this.discoveredUniverse = new List<FogOfWarStorage>();
				}
				return this.discoveredUniverse;
			} 
			set {
				this.discoveredUniverse = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Fleets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Fleet> Fleets {
			get {
				if( this.fleets == null ) {
					this.fleets = new List<Fleet>();
				}
				return this.fleets;
			} 
			set {
				this.fleets = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's SpecialSectores
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<UniverseSpecialSector> SpecialSectores {
			get {
				if( this.specialSectores == null ) {
					this.specialSectores = new List<UniverseSpecialSector>();
				}
				return this.specialSectores;
			} 
			set {
				this.specialSectores = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Quests
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<QuestStorage> Quests {
			get {
				if( this.quests == null ) {
					this.quests = new List<QuestStorage>();
				}
				return this.quests;
			} 
			set {
				this.quests = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Bids
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BidHistorical> Bids {
			get {
				if( this.bids == null ) {
					this.bids = new List<BidHistorical>();
				}
				return this.bids;
			} 
			set {
				this.bids = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Auction
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<AuctionHouse> Auction {
			get {
				if( this.auction == null ) {
					this.auction = new List<AuctionHouse>();
				}
				return this.auction;
			} 
			set {
				this.auction = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Arena
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ArenaStorage> Arena {
			get {
				if( this.arena == null ) {
					this.arena = new List<ArenaStorage>();
				}
				return this.arena;
			} 
			set {
				this.arena = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's MyFriends
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<FriendOrFoe> MyFriends {
			get {
				if( this.myFriends == null ) {
					this.myFriends = new List<FriendOrFoe>();
				}
				return this.myFriends;
			} 
			set {
				this.myFriends = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's OtherFriends
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<FriendOrFoe> OtherFriends {
			get {
				if( this.otherFriends == null ) {
					this.otherFriends = new List<FriendOrFoe>();
				}
				return this.otherFriends;
			} 
			set {
				this.otherFriends = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Medals
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Medal> Medals {
			get {
				if( this.medals == null ) {
					this.medals = new List<Medal>();
				}
				return this.medals;
			} 
			set {
				this.medals = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Messages
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PrivateBoard> Messages {
			get {
				if( this.messages == null ) {
					this.messages = new List<PrivateBoard>();
				}
				return this.messages;
			} 
			set {
				this.messages = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Assets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Asset> Assets {
			get {
				if( this.assets == null ) {
					this.assets = new List<Asset>();
				}
				return this.assets;
			} 
			set {
				this.assets = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Necessities
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Necessity> Necessities {
			get {
				if( this.necessities == null ) {
					this.necessities = new List<Necessity>();
				}
				return this.necessities;
			} 
			set {
				this.necessities = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Offerings
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Offering> Offerings {
			get {
				if( this.offerings == null ) {
					this.offerings = new List<Offering>();
				}
				return this.offerings;
			} 
			set {
				this.offerings = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Forfeit
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Offering> Forfeit {
			get {
				if( this.forfeit == null ) {
					this.forfeit = new List<Offering>();
				}
				return this.forfeit;
			} 
			set {
				this.forfeit = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Threads
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumThread> Threads {
			get {
				if( this.threads == null ) {
					this.threads = new List<ForumThread>();
				}
				return this.threads;
			} 
			set {
				this.threads = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Posts
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumPost> Posts {
			get {
				if( this.posts == null ) {
					this.posts = new List<ForumPost>();
				}
				return this.posts;
			} 
			set {
				this.posts = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's ReadMarkings
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumReadMarking> ReadMarkings {
			get {
				if( this.readMarkings == null ) {
					this.readMarkings = new List<ForumReadMarking>();
				}
				return this.readMarkings;
			} 
			set {
				this.readMarkings = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStorage's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				return this.principal;
			}
			set { this.principal = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				return this.alliance;
			}
			set { this.alliance = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Stats
        /// </summary>
		public override PlayerStats Stats {
			get { 
				return this.stats;
			}
			set { this.stats = value; }
		}

		#endregion PlayerStorage Implementation
		
	};
}
