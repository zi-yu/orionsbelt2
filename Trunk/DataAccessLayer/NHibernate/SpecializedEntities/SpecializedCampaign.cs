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
    /// Specialized NHibernate class for Campaign
    /// </summary>
	public class SpecializedCampaign : Campaign {
	
		#region Fields
		
		private System.Collections.Generic.IList<CampaignStatus> participants;
		private System.Collections.Generic.IList<CampaignLevel> levels;
		private Principal principal;

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
		
		#region Campaign Implementation
	
		/// <summary>
        /// Gets the Campaign's Participants
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<CampaignStatus> Participants {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.participants == null ) {
					this.participants = new List<CampaignStatus>();
				}
				CheckCollectionSession(this.participants);
				return this.ParticipantsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<CampaignStatus> bag = this.participants as NHibernate.Collection.Generic.PersistentGenericBag<CampaignStatus>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.participants = new List<CampaignStatus>(bag);
                    } else {
                        this.participants = null;
                    }
                }
				if( this.participants == null ) {
					if (Transient) {
						this.participants = new List<CampaignStatus>();
					} else {
						using( ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance ()) {
							this.participants = persistance.SelectByCampaign (this);
						}
						if( this.participants == null ) {
							this.participants = new List<CampaignStatus>();
						}
					}
				}
				return this.participants;
#endif
			} 
			set {
				this.participants = value;
			}
		}
		
		/// <summary>
        /// Gets the Campaign's Participants NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<CampaignStatus> ParticipantsNHibernate {
			get { return this.participants; } 
			set { this.participants = value; }
		}

		/// <summary>
        /// Gets the Campaign's Levels
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<CampaignLevel> Levels {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.levels == null ) {
					this.levels = new List<CampaignLevel>();
				}
				CheckCollectionSession(this.levels);
				return this.LevelsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<CampaignLevel> bag = this.levels as NHibernate.Collection.Generic.PersistentGenericBag<CampaignLevel>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.levels = new List<CampaignLevel>(bag);
                    } else {
                        this.levels = null;
                    }
                }
				if( this.levels == null ) {
					if (Transient) {
						this.levels = new List<CampaignLevel>();
					} else {
						using( ICampaignLevelPersistance persistance = Persistance.Instance.GetCampaignLevelPersistance ()) {
							this.levels = persistance.SelectByCampaign (this);
						}
						if( this.levels == null ) {
							this.levels = new List<CampaignLevel>();
						}
					}
				}
				return this.levels;
#endif
			} 
			set {
				this.levels = value;
			}
		}
		
		/// <summary>
        /// Gets the Campaign's Levels NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<CampaignLevel> LevelsNHibernate {
			get { return this.levels; } 
			set { this.levels = value; }
		}

		/// <summary>
        /// Gets the Campaign's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				CheckSession(this.principal);
				return this.principal;
			}
			set { this.principal = value; }
		}
		
		/// <summary>
        /// Gets the Campaign's Principal
        /// </summary>
		internal virtual SpecializedPrincipal PrincipalNHibernate {
			get { return (SpecializedPrincipal) this.principal;}
			set { this.principal = value; }
		}

		#endregion Campaign Implementation
		
	};
}
