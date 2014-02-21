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
using Institutional.Core;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Specialized NHibernate class for Principal
    /// </summary>
	public class SpecializedPrincipal : Principal {
	
		#region Fields
		
		private System.Collections.Generic.IList<ExceptionInfo> exceptions;

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
		
		#region Principal Implementation
	
		/// <summary>
        /// Gets the Principal's Exceptions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ExceptionInfo> Exceptions {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.exceptions == null ) {
					this.exceptions = new List<ExceptionInfo>();
				}
				CheckCollectionSession(this.exceptions);
				return this.ExceptionsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ExceptionInfo> bag = this.exceptions as NHibernate.Collection.Generic.PersistentGenericBag<ExceptionInfo>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.exceptions = new List<ExceptionInfo>(bag);
                    } else {
                        this.exceptions = null;
                    }
                }
				if( this.exceptions == null ) {
					if (Transient) {
						this.exceptions = new List<ExceptionInfo>();
					} else {
						using( IExceptionInfoPersistance persistance = Persistance.Instance.GetExceptionInfoPersistance ()) {
							this.exceptions = persistance.SelectByPrincipal (this);
						}
						if( this.exceptions == null ) {
							this.exceptions = new List<ExceptionInfo>();
						}
					}
				}
				return this.exceptions;
#endif
			} 
			set {
				this.exceptions = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's Exceptions NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ExceptionInfo> ExceptionsNHibernate {
			get { return this.exceptions; } 
			set { this.exceptions = value; }
		}

		#endregion Principal Implementation
		
	};
}
