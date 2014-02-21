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
    /// Specialized Memory class for Campaign
    /// </summary>
	public class SpecializedMemoryCampaign : Campaign {
	
		#region Fields
		
		private System.Collections.Generic.IList<CampaignStatus> participants;
		private System.Collections.Generic.IList<CampaignLevel> levels;
		private Principal principal;

		#endregion Fields
		
		#region Campaign Implementation
	
		/// <summary>
        /// Gets the Campaign's Participants
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<CampaignStatus> Participants {
			get {
				if( this.participants == null ) {
					this.participants = new List<CampaignStatus>();
				}
				return this.participants;
			} 
			set {
				this.participants = value;
			}
		}

		/// <summary>
        /// Gets the Campaign's Levels
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<CampaignLevel> Levels {
			get {
				if( this.levels == null ) {
					this.levels = new List<CampaignLevel>();
				}
				return this.levels;
			} 
			set {
				this.levels = value;
			}
		}

		/// <summary>
        /// Gets the Campaign's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				return this.principal;
			}
			set { this.principal = value; }
		}

		#endregion Campaign Implementation
		
	};
}
