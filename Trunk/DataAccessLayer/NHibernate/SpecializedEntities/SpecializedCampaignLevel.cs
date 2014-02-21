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
    /// Specialized NHibernate class for CampaignLevel
    /// </summary>
	public class SpecializedCampaignLevel : CampaignLevel {
	
		#region Fields
		
		private System.Collections.Generic.IList<CampaignStatus> campaignStatus;
		private Campaign campaign;

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
		
		#region CampaignLevel Implementation
	
		/// <summary>
        /// Gets the CampaignLevel's CampaignStatus
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<CampaignStatus> CampaignStatus {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.campaignStatus == null ) {
					this.campaignStatus = new List<CampaignStatus>();
				}
				CheckCollectionSession(this.campaignStatus);
				return this.CampaignStatusNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<CampaignStatus> bag = this.campaignStatus as NHibernate.Collection.Generic.PersistentGenericBag<CampaignStatus>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.campaignStatus = new List<CampaignStatus>(bag);
                    } else {
                        this.campaignStatus = null;
                    }
                }
				if( this.campaignStatus == null ) {
					if (Transient) {
						this.campaignStatus = new List<CampaignStatus>();
					} else {
						using( ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance ()) {
							this.campaignStatus = persistance.SelectByLevelTemplate (this);
						}
						if( this.campaignStatus == null ) {
							this.campaignStatus = new List<CampaignStatus>();
						}
					}
				}
				return this.campaignStatus;
#endif
			} 
			set {
				this.campaignStatus = value;
			}
		}
		
		/// <summary>
        /// Gets the CampaignLevel's CampaignStatus NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<CampaignStatus> CampaignStatusNHibernate {
			get { return this.campaignStatus; } 
			set { this.campaignStatus = value; }
		}

		/// <summary>
        /// Gets the CampaignLevel's Campaign
        /// </summary>
		public override Campaign Campaign {
			get { 
				CheckSession(this.campaign);
				return this.campaign;
			}
			set { this.campaign = value; }
		}
		
		/// <summary>
        /// Gets the CampaignLevel's Campaign
        /// </summary>
		internal virtual SpecializedCampaign CampaignNHibernate {
			get { return (SpecializedCampaign) this.campaign;}
			set { this.campaign = value; }
		}

		#endregion CampaignLevel Implementation
		
	};
}
