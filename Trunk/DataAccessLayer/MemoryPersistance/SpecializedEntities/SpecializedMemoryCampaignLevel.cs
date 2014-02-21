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
    /// Specialized Memory class for CampaignLevel
    /// </summary>
	public class SpecializedMemoryCampaignLevel : CampaignLevel {
	
		#region Fields
		
		private System.Collections.Generic.IList<CampaignStatus> campaignStatus;
		private Campaign campaign;

		#endregion Fields
		
		#region CampaignLevel Implementation
	
		/// <summary>
        /// Gets the CampaignLevel's CampaignStatus
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<CampaignStatus> CampaignStatus {
			get {
				if( this.campaignStatus == null ) {
					this.campaignStatus = new List<CampaignStatus>();
				}
				return this.campaignStatus;
			} 
			set {
				this.campaignStatus = value;
			}
		}

		/// <summary>
        /// Gets the CampaignLevel's Campaign
        /// </summary>
		public override Campaign Campaign {
			get { 
				return this.campaign;
			}
			set { this.campaign = value; }
		}

		#endregion CampaignLevel Implementation
		
	};
}
