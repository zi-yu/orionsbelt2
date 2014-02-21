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
    /// Specialized Memory class for Principal
    /// </summary>
	public class SpecializedMemoryPrincipal : Principal {
	
		#region Fields
		
		private System.Collections.Generic.IList<PrincipalTournament> tournaments;
		private System.Collections.Generic.IList<Fleet> fleets;
		private System.Collections.Generic.IList<PlayerStorage> player;
		private System.Collections.Generic.IList<Medal> medals;
		private System.Collections.Generic.IList<Campaign> createdCampaigns;
		private System.Collections.Generic.IList<CampaignStatus> campaigns;
		private System.Collections.Generic.IList<BonusCard> usedCards;
		private System.Collections.Generic.IList<Promotion> promotions;
		private System.Collections.Generic.IList<ActivatedPromotion> activePromotions;
		private System.Collections.Generic.IList<ExceptionInfo> exceptions;
		private TeamStorage team;

		#endregion Fields
		
		#region Principal Implementation
	
		/// <summary>
        /// Gets the Principal's Tournaments
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PrincipalTournament> Tournaments {
			get {
				if( this.tournaments == null ) {
					this.tournaments = new List<PrincipalTournament>();
				}
				return this.tournaments;
			} 
			set {
				this.tournaments = value;
			}
		}

		/// <summary>
        /// Gets the Principal's Fleets
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
        /// Gets the Principal's Player
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayerStorage> Player {
			get {
				if( this.player == null ) {
					this.player = new List<PlayerStorage>();
				}
				return this.player;
			} 
			set {
				this.player = value;
			}
		}

		/// <summary>
        /// Gets the Principal's Medals
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
        /// Gets the Principal's CreatedCampaigns
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Campaign> CreatedCampaigns {
			get {
				if( this.createdCampaigns == null ) {
					this.createdCampaigns = new List<Campaign>();
				}
				return this.createdCampaigns;
			} 
			set {
				this.createdCampaigns = value;
			}
		}

		/// <summary>
        /// Gets the Principal's Campaigns
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<CampaignStatus> Campaigns {
			get {
				if( this.campaigns == null ) {
					this.campaigns = new List<CampaignStatus>();
				}
				return this.campaigns;
			} 
			set {
				this.campaigns = value;
			}
		}

		/// <summary>
        /// Gets the Principal's UsedCards
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BonusCard> UsedCards {
			get {
				if( this.usedCards == null ) {
					this.usedCards = new List<BonusCard>();
				}
				return this.usedCards;
			} 
			set {
				this.usedCards = value;
			}
		}

		/// <summary>
        /// Gets the Principal's Promotions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Promotion> Promotions {
			get {
				if( this.promotions == null ) {
					this.promotions = new List<Promotion>();
				}
				return this.promotions;
			} 
			set {
				this.promotions = value;
			}
		}

		/// <summary>
        /// Gets the Principal's ActivePromotions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ActivatedPromotion> ActivePromotions {
			get {
				if( this.activePromotions == null ) {
					this.activePromotions = new List<ActivatedPromotion>();
				}
				return this.activePromotions;
			} 
			set {
				this.activePromotions = value;
			}
		}

		/// <summary>
        /// Gets the Principal's Exceptions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ExceptionInfo> Exceptions {
			get {
				if( this.exceptions == null ) {
					this.exceptions = new List<ExceptionInfo>();
				}
				return this.exceptions;
			} 
			set {
				this.exceptions = value;
			}
		}

		/// <summary>
        /// Gets the Principal's Team
        /// </summary>
		public override TeamStorage Team {
			get { 
				return this.team;
			}
			set { this.team = value; }
		}

		#endregion Principal Implementation
		
	};
}
