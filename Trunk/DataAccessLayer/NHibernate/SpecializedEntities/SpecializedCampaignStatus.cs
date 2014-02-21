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
    /// Specialized NHibernate class for CampaignStatus
    /// </summary>
	public class SpecializedCampaignStatus : CampaignStatus {
	
		#region Fields
		
		private Campaign campaign;
		private Principal principal;
		private Battle battle;
		private CampaignLevel levelTemplate;

		#endregion Fields
		
		#region NHibernate Utils

        private ISession session;

        internal virtual ISession NHibernateSession {
            get { return session; }
            set { session = value; }
        }
        
        internal virtual void CheckSession()
        {
            NHibernateUtilities.CheckSession(this);
        }
        
        internal virtual void CheckSession(IEntity entity)
        {
            NHibernateUtilities.CheckSession(entity);
        }
        
        internal virtual void CheckCollectionSession(IEnumerable coll)
        {
            NHibernateUtilities.CheckCollectionSession(NHibernateSession, this, coll);
        }

        #endregion NHibernate Utils
		
		#region CampaignStatus Implementation
	
		/// <summary>
        /// Gets the CampaignStatus's Campaign
        /// </summary>
		public override Campaign Campaign {
			get { 
				CheckSession(this.campaign);
				return this.campaign;
			}
			set { this.campaign = value; }
		}
		
		/// <summary>
        /// Gets the CampaignStatus's Campaign
        /// </summary>
		internal virtual SpecializedCampaign CampaignNHibernate {
			get { return (SpecializedCampaign) this.campaign;}
			set { this.campaign = value; }
		}

		/// <summary>
        /// Gets the CampaignStatus's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				CheckSession(this.principal);
				return this.principal;
			}
			set { this.principal = value; }
		}
		
		/// <summary>
        /// Gets the CampaignStatus's Principal
        /// </summary>
		internal virtual SpecializedPrincipal PrincipalNHibernate {
			get { return (SpecializedPrincipal) this.principal;}
			set { this.principal = value; }
		}

		/// <summary>
        /// Gets the CampaignStatus's Battle
        /// </summary>
		public override Battle Battle {
			get { 
				CheckSession(this.battle);
				return this.battle;
			}
			set { this.battle = value; }
		}
		
		/// <summary>
        /// Gets the CampaignStatus's Battle
        /// </summary>
		internal virtual SpecializedBattle BattleNHibernate {
			get { return (SpecializedBattle) this.battle;}
			set { this.battle = value; }
		}

		/// <summary>
        /// Gets the CampaignStatus's LevelTemplate
        /// </summary>
		public override CampaignLevel LevelTemplate {
			get { 
				CheckSession(this.levelTemplate);
				return this.levelTemplate;
			}
			set { this.levelTemplate = value; }
		}
		
		/// <summary>
        /// Gets the CampaignStatus's LevelTemplate
        /// </summary>
		internal virtual SpecializedCampaignLevel LevelTemplateNHibernate {
			get { return (SpecializedCampaignLevel) this.levelTemplate;}
			set { this.levelTemplate = value; }
		}

		#endregion CampaignStatus Implementation
		
	};
}
