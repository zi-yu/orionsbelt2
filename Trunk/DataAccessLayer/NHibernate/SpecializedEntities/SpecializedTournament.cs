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
    /// Specialized NHibernate class for Tournament
    /// </summary>
	public class SpecializedTournament : Tournament {
	
		#region Fields
		
		private System.Collections.Generic.IList<PlayersGroupStorage> groups;
		private System.Collections.Generic.IList<Battle> battles;
		private System.Collections.Generic.IList<PrincipalTournament> regists;

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
		
		#region Tournament Implementation
	
		/// <summary>
        /// Gets the Tournament's Groups
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayersGroupStorage> Groups {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.groups == null ) {
					this.groups = new List<PlayersGroupStorage>();
				}
				CheckCollectionSession(this.groups);
				return this.GroupsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PlayersGroupStorage> bag = this.groups as NHibernate.Collection.Generic.PersistentGenericBag<PlayersGroupStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.groups = new List<PlayersGroupStorage>(bag);
                    } else {
                        this.groups = null;
                    }
                }
				if( this.groups == null ) {
					if (Transient) {
						this.groups = new List<PlayersGroupStorage>();
					} else {
						using( IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance ()) {
							this.groups = persistance.SelectByTournament (this);
						}
						if( this.groups == null ) {
							this.groups = new List<PlayersGroupStorage>();
						}
					}
				}
				return this.groups;
#endif
			} 
			set {
				this.groups = value;
			}
		}
		
		/// <summary>
        /// Gets the Tournament's Groups NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlayersGroupStorage> GroupsNHibernate {
			get { return this.groups; } 
			set { this.groups = value; }
		}

		/// <summary>
        /// Gets the Tournament's Battles
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Battle> Battles {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.battles == null ) {
					this.battles = new List<Battle>();
				}
				CheckCollectionSession(this.battles);
				return this.BattlesNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Battle> bag = this.battles as NHibernate.Collection.Generic.PersistentGenericBag<Battle>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.battles = new List<Battle>(bag);
                    } else {
                        this.battles = null;
                    }
                }
				if( this.battles == null ) {
					if (Transient) {
						this.battles = new List<Battle>();
					} else {
						using( IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance ()) {
							this.battles = persistance.SelectByTournament (this);
						}
						if( this.battles == null ) {
							this.battles = new List<Battle>();
						}
					}
				}
				return this.battles;
#endif
			} 
			set {
				this.battles = value;
			}
		}
		
		/// <summary>
        /// Gets the Tournament's Battles NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Battle> BattlesNHibernate {
			get { return this.battles; } 
			set { this.battles = value; }
		}

		/// <summary>
        /// Gets the Tournament's Regists
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PrincipalTournament> Regists {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.regists == null ) {
					this.regists = new List<PrincipalTournament>();
				}
				CheckCollectionSession(this.regists);
				return this.RegistsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PrincipalTournament> bag = this.regists as NHibernate.Collection.Generic.PersistentGenericBag<PrincipalTournament>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.regists = new List<PrincipalTournament>(bag);
                    } else {
                        this.regists = null;
                    }
                }
				if( this.regists == null ) {
					if (Transient) {
						this.regists = new List<PrincipalTournament>();
					} else {
						using( IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance ()) {
							this.regists = persistance.SelectByTournament (this);
						}
						if( this.regists == null ) {
							this.regists = new List<PrincipalTournament>();
						}
					}
				}
				return this.regists;
#endif
			} 
			set {
				this.regists = value;
			}
		}
		
		/// <summary>
        /// Gets the Tournament's Regists NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PrincipalTournament> RegistsNHibernate {
			get { return this.regists; } 
			set { this.regists = value; }
		}

		#endregion Tournament Implementation
		
	};
}
