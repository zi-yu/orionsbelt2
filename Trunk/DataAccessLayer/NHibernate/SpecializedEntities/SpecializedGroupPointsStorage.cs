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
    /// Specialized NHibernate class for GroupPointsStorage
    /// </summary>
	public class SpecializedGroupPointsStorage : GroupPointsStorage {
	
		#region Fields
		
		private PrincipalTournament regist;

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
		
		#region GroupPointsStorage Implementation
	
		/// <summary>
        /// Gets the GroupPointsStorage's Regist
        /// </summary>
		public override PrincipalTournament Regist {
			get { 
				CheckSession(this.regist);
				return this.regist;
			}
			set { this.regist = value; }
		}
		
		/// <summary>
        /// Gets the GroupPointsStorage's Regist
        /// </summary>
		internal virtual SpecializedPrincipalTournament RegistNHibernate {
			get { return (SpecializedPrincipalTournament) this.regist;}
			set { this.regist = value; }
		}

		#endregion GroupPointsStorage Implementation
		
	};
}
