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
    /// Specialized NHibernate class for PlayersGroupStorage
    /// </summary>
	public class SpecializedPlayersGroupStorage : PlayersGroupStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<Battle> battles;
		private Tournament tournament;

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
		
		#region PlayersGroupStorage Implementation
	
		/// <summary>
        /// Gets the PlayersGroupStorage's Battles
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
							this.battles = persistance.SelectByGroup (this);
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
        /// Gets the PlayersGroupStorage's Battles NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Battle> BattlesNHibernate {
			get { return this.battles; } 
			set { this.battles = value; }
		}

		/// <summary>
        /// Gets the PlayersGroupStorage's Tournament
        /// </summary>
		public override Tournament Tournament {
			get { 
				CheckSession(this.tournament);
				return this.tournament;
			}
			set { this.tournament = value; }
		}
		
		/// <summary>
        /// Gets the PlayersGroupStorage's Tournament
        /// </summary>
		internal virtual SpecializedTournament TournamentNHibernate {
			get { return (SpecializedTournament) this.tournament;}
			set { this.tournament = value; }
		}

		#endregion PlayersGroupStorage Implementation
		
	};
}
