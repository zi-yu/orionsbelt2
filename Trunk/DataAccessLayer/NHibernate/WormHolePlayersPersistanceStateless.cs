using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class WormHolePlayersPersistanceStateless : 
			NHibernatePersistanceStateless<WormHolePlayers>, IWormHolePlayersPersistance {
	
		#region Static Access
		
		internal static WormHolePlayersPersistanceStateless CreateSession()
		{
			return new WormHolePlayersPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedWormHolePlayers) );
		}
				
		internal static WormHolePlayersPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			WormHolePlayersPersistanceStateless persistance = new WormHolePlayersPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedWormHolePlayers) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static WormHolePlayersPersistanceStateless globalSession = null;
        internal static WormHolePlayersPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static WormHolePlayersPersistanceStateless GetSession()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			
			if (context == null) {
                return CreateSession();
            }

			if( context.Items == null ) {
				return CreateSession();
			}

            object persistance = context.Items["PersistanceStateless"];
			NHibernatePersistanceStateless<Principal> session = null;
			
			if( persistance != null ) {
				session = (NHibernatePersistanceStateless<Principal>) persistance;
			} else {
                session = PrincipalPersistanceStateless.CreateSession();
				context.Items["PersistanceStateless"] = session;
			}
			
			IStatelessSession nhSession = session.Session as IStatelessSession;
            if (nhSession != null && !NHibernateUtilities.IsSessionOpen(nhSession) ) {
				nhSession.Dispose();
                session.NHibernateSession = NHibernateUtilities.OpenStatelessSession;
            }
			
			return AttachSession( session );
		}
		
		internal static WormHolePlayersPersistanceStateless GetValidatedSession()
        {
            WormHolePlayersPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private WormHolePlayersPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override WormHolePlayers Create()
		{	
			SpecializedWormHolePlayers entity = new SpecializedWormHolePlayers ();
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
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : WormHolePlayers
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
