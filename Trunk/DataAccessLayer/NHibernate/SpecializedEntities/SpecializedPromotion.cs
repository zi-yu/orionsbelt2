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
    /// Specialized NHibernate class for Promotion
    /// </summary>
	public class SpecializedPromotion : Promotion {
	
		#region Fields
		
		private System.Collections.Generic.IList<ActivatedPromotion> activations;
		private Principal owner;

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
		
		#region Promotion Implementation
	
		/// <summary>
        /// Gets the Promotion's Activations
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ActivatedPromotion> Activations {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.activations == null ) {
					this.activations = new List<ActivatedPromotion>();
				}
				CheckCollectionSession(this.activations);
				return this.ActivationsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ActivatedPromotion> bag = this.activations as NHibernate.Collection.Generic.PersistentGenericBag<ActivatedPromotion>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.activations = new List<ActivatedPromotion>(bag);
                    } else {
                        this.activations = null;
                    }
                }
				if( this.activations == null ) {
					if (Transient) {
						this.activations = new List<ActivatedPromotion>();
					} else {
						using( IActivatedPromotionPersistance persistance = Persistance.Instance.GetActivatedPromotionPersistance ()) {
							this.activations = persistance.SelectByPromotion (this);
						}
						if( this.activations == null ) {
							this.activations = new List<ActivatedPromotion>();
						}
					}
				}
				return this.activations;
#endif
			} 
			set {
				this.activations = value;
			}
		}
		
		/// <summary>
        /// Gets the Promotion's Activations NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ActivatedPromotion> ActivationsNHibernate {
			get { return this.activations; } 
			set { this.activations = value; }
		}

		/// <summary>
        /// Gets the Promotion's Owner
        /// </summary>
		public override Principal Owner {
			get { 
				CheckSession(this.owner);
				return this.owner;
			}
			set { this.owner = value; }
		}
		
		/// <summary>
        /// Gets the Promotion's Owner
        /// </summary>
		internal virtual SpecializedPrincipal OwnerNHibernate {
			get { return (SpecializedPrincipal) this.owner;}
			set { this.owner = value; }
		}

		#endregion Promotion Implementation
		
	};
}
