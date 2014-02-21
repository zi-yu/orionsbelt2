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
    /// Specialized NHibernate class for FriendOrFoe
    /// </summary>
	public class SpecializedFriendOrFoe : FriendOrFoe {
	
		#region Fields
		
		private PlayerStorage source;
		private PlayerStorage target;

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
		
		#region FriendOrFoe Implementation
	
		/// <summary>
        /// Gets the FriendOrFoe's Source
        /// </summary>
		public override PlayerStorage Source {
			get { 
				CheckSession(this.source);
				return this.source;
			}
			set { this.source = value; }
		}
		
		/// <summary>
        /// Gets the FriendOrFoe's Source
        /// </summary>
		internal virtual SpecializedPlayerStorage SourceNHibernate {
			get { return (SpecializedPlayerStorage) this.source;}
			set { this.source = value; }
		}

		/// <summary>
        /// Gets the FriendOrFoe's Target
        /// </summary>
		public override PlayerStorage Target {
			get { 
				CheckSession(this.target);
				return this.target;
			}
			set { this.target = value; }
		}
		
		/// <summary>
        /// Gets the FriendOrFoe's Target
        /// </summary>
		internal virtual SpecializedPlayerStorage TargetNHibernate {
			get { return (SpecializedPlayerStorage) this.target;}
			set { this.target = value; }
		}

		#endregion FriendOrFoe Implementation
		
	};
}
