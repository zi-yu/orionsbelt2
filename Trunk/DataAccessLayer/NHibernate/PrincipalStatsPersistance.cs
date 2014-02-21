using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PrincipalStatsPersistance : 
			NHibernatePersistance<PrincipalStats>, IPrincipalStatsPersistance {
	
		#region Static Access
		
		internal static PrincipalStatsPersistance CreateSession()
		{
			return new PrincipalStatsPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPrincipalStats) );
		}
				
		internal static PrincipalStatsPersistance AttachSession( IPersistanceSession owner )
		{
			PrincipalStatsPersistance persistance = new PrincipalStatsPersistance ( owner.Session as ISession, typeof(SpecializedPrincipalStats) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PrincipalStatsPersistance globalSession = null;
        internal static PrincipalStatsPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PrincipalStatsPersistance GetSession()
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
		
		internal static PrincipalStatsPersistance GetValidatedSession()
        {
            PrincipalStatsPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PrincipalStatsPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PrincipalStats Create()
		{	
			SpecializedPrincipalStats entity = new SpecializedPrincipalStats ();
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
		
 		public IList<PrincipalStats> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalStats e where e.Id = '{0}'", id);
		}

		public IList<PrincipalStats> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPrincipalStats e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalStats> SelectByMaxElo ( int maxElo )
		{
			return SelectByMaxElo (-1, -1, maxElo );
		}
		
		public long CountByMaxElo ( int maxElo )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalStats e where e.MaxElo = '{0}'", maxElo);
		}

		public IList<PrincipalStats> SelectByMaxElo ( int start, int count, int maxElo )
		{
			IList list = Query(start, count, "from SpecializedPrincipalStats e where e.MaxElo = {0}", maxElo);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalStats> SelectByMinElo ( int minElo )
		{
			return SelectByMinElo (-1, -1, minElo );
		}
		
		public long CountByMinElo ( int minElo )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalStats e where e.MinElo = '{0}'", minElo);
		}

		public IList<PrincipalStats> SelectByMinElo ( int start, int count, int minElo )
		{
			IList list = Query(start, count, "from SpecializedPrincipalStats e where e.MinElo = {0}", minElo);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalStats> SelectByNumberPlayedBattles ( int numberPlayedBattles )
		{
			return SelectByNumberPlayedBattles (-1, -1, numberPlayedBattles );
		}
		
		public long CountByNumberPlayedBattles ( int numberPlayedBattles )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalStats e where e.NumberPlayedBattles = '{0}'", numberPlayedBattles);
		}

		public IList<PrincipalStats> SelectByNumberPlayedBattles ( int start, int count, int numberPlayedBattles )
		{
			IList list = Query(start, count, "from SpecializedPrincipalStats e where e.NumberPlayedBattles = {0}", numberPlayedBattles);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalStats> SelectByMaxLadder ( int maxLadder )
		{
			return SelectByMaxLadder (-1, -1, maxLadder );
		}
		
		public long CountByMaxLadder ( int maxLadder )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalStats e where e.MaxLadder = '{0}'", maxLadder);
		}

		public IList<PrincipalStats> SelectByMaxLadder ( int start, int count, int maxLadder )
		{
			IList list = Query(start, count, "from SpecializedPrincipalStats e where e.MaxLadder = {0}", maxLadder);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalStats> SelectByMinLadder ( int minLadder )
		{
			return SelectByMinLadder (-1, -1, minLadder );
		}
		
		public long CountByMinLadder ( int minLadder )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalStats e where e.MinLadder = '{0}'", minLadder);
		}

		public IList<PrincipalStats> SelectByMinLadder ( int start, int count, int minLadder )
		{
			IList list = Query(start, count, "from SpecializedPrincipalStats e where e.MinLadder = {0}", minLadder);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PrincipalStats
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
