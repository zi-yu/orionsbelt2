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
    /// Specialized NHibernate class for ExceptionInfo
    /// </summary>
	public class SpecializedExceptionInfo : ExceptionInfo {
	
		#region Fields
		
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
		
		#region ExceptionInfo Implementation
	
		/// <summary>
        /// Gets the ExceptionInfo's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				CheckSession(this.principal);
				return this.principal;
			}
			set { this.principal = value; }
		}
		
		/// <summary>
        /// Gets the ExceptionInfo's Principal
        /// </summary>
		internal virtual SpecializedPrincipal PrincipalNHibernate {
			get { return (SpecializedPrincipal) this.principal;}
			set { this.principal = value; }
		}

		#endregion ExceptionInfo Implementation
		
	};
}
