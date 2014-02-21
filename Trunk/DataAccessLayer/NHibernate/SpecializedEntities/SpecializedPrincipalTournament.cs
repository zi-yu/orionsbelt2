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
    /// Specialized NHibernate class for PrincipalTournament
    /// </summary>
	public class SpecializedPrincipalTournament : PrincipalTournament {
	
		#region Fields
		
		private System.Collections.Generic.IList<GroupPointsStorage> points;
		private Principal principal;
		private Tournament tournament;
		private TeamStorage team;

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
		
		#region PrincipalTournament Implementation
	
		/// <summary>
        /// Gets the PrincipalTournament's Points
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<GroupPointsStorage> Points {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.points == null ) {
					this.points = new List<GroupPointsStorage>();
				}
				CheckCollectionSession(this.points);
				return this.PointsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<GroupPointsStorage> bag = this.points as NHibernate.Collection.Generic.PersistentGenericBag<GroupPointsStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.points = new List<GroupPointsStorage>(bag);
                    } else {
                        this.points = null;
                    }
                }
				if( this.points == null ) {
					if (Transient) {
						this.points = new List<GroupPointsStorage>();
					} else {
						using( IGroupPointsStoragePersistance persistance = Persistance.Instance.GetGroupPointsStoragePersistance ()) {
							this.points = persistance.SelectByRegist (this);
						}
						if( this.points == null ) {
							this.points = new List<GroupPointsStorage>();
						}
					}
				}
				return this.points;
#endif
			} 
			set {
				this.points = value;
			}
		}
		
		/// <summary>
        /// Gets the PrincipalTournament's Points NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<GroupPointsStorage> PointsNHibernate {
			get { return this.points; } 
			set { this.points = value; }
		}

		/// <summary>
        /// Gets the PrincipalTournament's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				CheckSession(this.principal);
				return this.principal;
			}
			set { this.principal = value; }
		}
		
		/// <summary>
        /// Gets the PrincipalTournament's Principal
        /// </summary>
		internal virtual SpecializedPrincipal PrincipalNHibernate {
			get { return (SpecializedPrincipal) this.principal;}
			set { this.principal = value; }
		}

		/// <summary>
        /// Gets the PrincipalTournament's Tournament
        /// </summary>
		public override Tournament Tournament {
			get { 
				CheckSession(this.tournament);
				return this.tournament;
			}
			set { this.tournament = value; }
		}
		
		/// <summary>
        /// Gets the PrincipalTournament's Tournament
        /// </summary>
		internal virtual SpecializedTournament TournamentNHibernate {
			get { return (SpecializedTournament) this.tournament;}
			set { this.tournament = value; }
		}

		/// <summary>
        /// Gets the PrincipalTournament's Team
        /// </summary>
		public override TeamStorage Team {
			get { 
				CheckSession(this.team);
				return this.team;
			}
			set { this.team = value; }
		}
		
		/// <summary>
        /// Gets the PrincipalTournament's Team
        /// </summary>
		internal virtual SpecializedTeamStorage TeamNHibernate {
			get { return (SpecializedTeamStorage) this.team;}
			set { this.team = value; }
		}

		#endregion PrincipalTournament Implementation
		
	};
}
