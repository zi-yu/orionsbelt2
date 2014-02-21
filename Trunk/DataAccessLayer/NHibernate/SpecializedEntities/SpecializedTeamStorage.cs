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
    /// Specialized NHibernate class for TeamStorage
    /// </summary>
	public class SpecializedTeamStorage : TeamStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<Principal> principals;
		private System.Collections.Generic.IList<PrincipalTournament> tournaments;

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
		
		#region TeamStorage Implementation
	
		/// <summary>
        /// Gets the TeamStorage's Principals
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Principal> Principals {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.principals == null ) {
					this.principals = new List<Principal>();
				}
				CheckCollectionSession(this.principals);
				return this.PrincipalsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Principal> bag = this.principals as NHibernate.Collection.Generic.PersistentGenericBag<Principal>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.principals = new List<Principal>(bag);
                    } else {
                        this.principals = null;
                    }
                }
				if( this.principals == null ) {
					if (Transient) {
						this.principals = new List<Principal>();
					} else {
						using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance ()) {
							this.principals = persistance.SelectByTeam (this);
						}
						if( this.principals == null ) {
							this.principals = new List<Principal>();
						}
					}
				}
				return this.principals;
#endif
			} 
			set {
				this.principals = value;
			}
		}
		
		/// <summary>
        /// Gets the TeamStorage's Principals NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Principal> PrincipalsNHibernate {
			get { return this.principals; } 
			set { this.principals = value; }
		}

		/// <summary>
        /// Gets the TeamStorage's Tournaments
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PrincipalTournament> Tournaments {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.tournaments == null ) {
					this.tournaments = new List<PrincipalTournament>();
				}
				CheckCollectionSession(this.tournaments);
				return this.TournamentsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PrincipalTournament> bag = this.tournaments as NHibernate.Collection.Generic.PersistentGenericBag<PrincipalTournament>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.tournaments = new List<PrincipalTournament>(bag);
                    } else {
                        this.tournaments = null;
                    }
                }
				if( this.tournaments == null ) {
					if (Transient) {
						this.tournaments = new List<PrincipalTournament>();
					} else {
						using( IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance ()) {
							this.tournaments = persistance.SelectByTeam (this);
						}
						if( this.tournaments == null ) {
							this.tournaments = new List<PrincipalTournament>();
						}
					}
				}
				return this.tournaments;
#endif
			} 
			set {
				this.tournaments = value;
			}
		}
		
		/// <summary>
        /// Gets the TeamStorage's Tournaments NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PrincipalTournament> TournamentsNHibernate {
			get { return this.tournaments; } 
			set { this.tournaments = value; }
		}

		#endregion TeamStorage Implementation
		
	};
}
