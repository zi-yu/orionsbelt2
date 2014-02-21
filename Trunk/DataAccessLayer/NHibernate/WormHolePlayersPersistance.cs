using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class WormHolePlayersPersistance : 
			NHibernatePersistance<WormHolePlayers>, IWormHolePlayersPersistance {
	
		#region Static Access
		
		internal static WormHolePlayersPersistance CreateSession()
		{
			return new WormHolePlayersPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedWormHolePlayers) );
		}
				
		internal static WormHolePlayersPersistance AttachSession( IPersistanceSession owner )
		{
			WormHolePlayersPersistance persistance = new WormHolePlayersPersistance ( owner.Session as ISession, typeof(SpecializedWormHolePlayers) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static WormHolePlayersPersistance globalSession = null;
        internal static WormHolePlayersPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static WormHolePlayersPersistance GetSession()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			
			if (context == null) {
                return CreateSession();
            }

			if( context.Items == null ) {
				return CreateSession();
			}

            object persistance = context.Items["Persistance"];
			NHibernatePersistance<Principal> session = null;
			
			if( persistance != null ) {
				session = (NHibernatePersistance<Principal>) persistance;
			} else {
                session = PrincipalPersistance.CreateSession();
				context.Items["Persistance"] = session;
			}
			
			ISession nhSession = session.Session as ISession;
            if (nhSession != null && !NHibernateUtilities.IsSessionOpen(nhSession) ) {
				nhSession.Dispose();
                session.NHibernateSession = NHibernateUtilities.OpenSession;
            }
			
			return AttachSession( session );
		}
		
		internal static WormHolePlayersPersistance GetValidatedSession()
        {
            WormHolePlayersPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private WormHolePlayersPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override WormHolePlayers Create()
		{	
			SpecializedWormHolePlayers entity = new SpecializedWormHolePlayers ();
            entity.NHibernateSession = NHibernateSession;
            return entity;
		}

		/// <summary>
        /// Adds logic validation to the entities
        /// </summary>
        public override void AddValidators()
        {
			AddValidation(this);
        }
        
		#endregion IPersistance
		
		#region ExtendedMethods		
		
 		public IList<WormHolePlayers> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedWormHolePlayers e where e.Id = '{0}'", id);
		}

		public IList<WormHolePlayers> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedWormHolePlayers e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<WormHolePlayers> SelectByPlayerCount ( int playerCount )
		{
			return SelectByPlayerCount (-1, -1, playerCount );
		}
		
		public long CountByPlayerCount ( int playerCount )
		{
			return ExecuteScalar("select count(*) from SpecializedWormHolePlayers e where e.PlayerCount = '{0}'", playerCount);
		}

		public IList<WormHolePlayers> SelectByPlayerCount ( int start, int count, int playerCount )
		{
			IList list = Query(start, count, "from SpecializedWormHolePlayers e where e.PlayerCount = {0}", playerCount);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : WormHolePlayers
        {
        }

		public static LifecyleVeto ValidateStringMaxSize( string entityName, string propertyName, string val, int maxSize ) 
        {
			if( string.IsNullOrEmpty( val ) ) {
				return LifecyleVeto.Continue;
			}
			
			if( val.Length > maxSize ) {
				throw new DALException("The `{4}' property of `{0}' has too many chars (max: {1}, found:{2}, text:{3})", entityName, maxSize, val.Length, val, propertyName);
			}
			
			return LifecyleVeto.Continue;
		}

		#endregion Validation
		
	};
}
