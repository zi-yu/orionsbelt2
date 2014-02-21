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
    /// Specialized NHibernate class for PlayerBattleInformation
    /// </summary>
	public class SpecializedPlayerBattleInformation : PlayerBattleInformation {
	
		#region Fields
		
		private Battle battle;

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
		
		#region PlayerBattleInformation Implementation
	
		/// <summary>
        /// Gets the PlayerBattleInformation's Battle
        /// </summary>
		public override Battle Battle {
			get { 
				CheckSession(this.battle);
				return this.battle;
			}
			set { this.battle = value; }
		}
		
		/// <summary>
        /// Gets the PlayerBattleInformation's Battle
        /// </summary>
		internal virtual SpecializedBattle BattleNHibernate {
			get { return (SpecializedBattle) this.battle;}
			set { this.battle = value; }
		}

		#endregion PlayerBattleInformation Implementation
		
	};
}
