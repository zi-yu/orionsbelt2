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
    /// Specialized Memory class for CampaignStatus
    /// </summary>
	public class SpecializedMemoryCampaignStatus : CampaignStatus {
	
		#region Fields
		
		private Campaign campaign;
		private Principal principal;
		private Battle battle;
		private CampaignLevel levelTemplate;

		#endregion Fields
		
		#region CampaignStatus Implementation
	
		/// <summary>
        /// Gets the CampaignStatus's Campaign
        /// </summary>
		public override Campaign Campaign {
			get { 
				return this.campaign;
			}
			set { this.campaign = value; }
		}

		/// <summary>
        /// Gets the CampaignStatus's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				return this.principal;
			}
			set { this.principal = value; }
		}

		/// <summary>
        /// Gets the CampaignStatus's Battle
        /// </summary>
		public override Battle Battle {
			get { 
				return this.battle;
			}
			set { this.battle = value; }
		}

		/// <summary>
        /// Gets the CampaignStatus's LevelTemplate
        /// </summary>
		public override CampaignLevel LevelTemplate {
			get { 
				return this.levelTemplate;
			}
			set { this.levelTemplate = value; }
		}

		#endregion CampaignStatus Implementation
		
	};
}
