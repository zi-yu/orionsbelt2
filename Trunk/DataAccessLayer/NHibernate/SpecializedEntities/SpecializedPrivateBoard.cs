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
    /// Specialized NHibernate class for PrivateBoard
    /// </summary>
	public class SpecializedPrivateBoard : PrivateBoard {
	
		#region Fields
		
		private PlayerStorage sender;

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
		
		#region PrivateBoard Implementation
	
		/// <summary>
        /// Gets the PrivateBoard's Sender
        /// </summary>
		public override PlayerStorage Sender {
			get { 
				CheckSession(this.sender);
				return this.sender;
			}
			set { this.sender = value; }
		}
		
		/// <summary>
        /// Gets the PrivateBoard's Sender
        /// </summary>
		internal virtual SpecializedPlayerStorage SenderNHibernate {
			get { return (SpecializedPlayerStorage) this.sender;}
			set { this.sender = value; }
		}

		#endregion PrivateBoard Implementation
		
	};
}
