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
    /// Specialized Memory class for Battle
    /// </summary>
	public class SpecializedMemoryBattle : Battle {
	
		#region Fields
		
		private System.Collections.Generic.IList<PlayerBattleInformation> playerInformation;
		private System.Collections.Generic.IList<BattleExtention> battleExtension;
		private System.Collections.Generic.IList<TimedActionStorage> timedAction;
		private System.Collections.Generic.IList<CampaignStatus> campaigns;
		private Tournament tournament;
		private PlayersGroupStorage group;

		#endregion Fields
		
		#region Battle Implementation
	
		/// <summary>
        /// Gets the Battle's PlayerInformation
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayerBattleInformation> PlayerInformation {
			get {
				if( this.playerInformation == null ) {
					this.playerInformation = new List<PlayerBattleInformation>();
				}
				return this.playerInformation;
			} 
			set {
				this.playerInformation = value;
			}
		}

		/// <summary>
        /// Gets the Battle's BattleExtension
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BattleExtention> BattleExtension {
			get {
				if( this.battleExtension == null ) {
					this.battleExtension = new List<BattleExtention>();
				}
				return this.battleExtension;
			} 
			set {
				this.battleExtension = value;
			}
		}

		/// <summary>
        /// Gets the Battle's TimedAction
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<TimedActionStorage> TimedAction {
			get {
				if( this.timedAction == null ) {
					this.timedAction = new List<TimedActionStorage>();
				}
				return this.timedAction;
			} 
			set {
				this.timedAction = value;
			}
		}

		/// <summary>
        /// Gets the Battle's Campaigns
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
        /// Gets the Battle's Tournament
        /// </summary>
		public override Tournament Tournament {
			get { 
				return this.tournament;
			}
			set { this.tournament = value; }
		}

		/// <summary>
        /// Gets the Battle's Group
        /// </summary>
		public override PlayersGroupStorage Group {
			get { 
				return this.group;
			}
			set { this.group = value; }
		}

		#endregion Battle Implementation
		
	};
}
