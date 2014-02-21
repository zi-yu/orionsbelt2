using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ArenaHistoricalPersistanceStateless : 
			NHibernatePersistanceStateless<ArenaHistorical>, IArenaHistoricalPersistance {
	
		#region Static Access
		
		internal static ArenaHistoricalPersistanceStateless CreateSession()
		{
			return new ArenaHistoricalPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedArenaHistorical) );
		}
				
		internal static ArenaHistoricalPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			ArenaHistoricalPersistanceStateless persistance = new ArenaHistoricalPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedArenaHistorical) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ArenaHistoricalPersistanceStateless globalSession = null;
        internal static ArenaHistoricalPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ArenaHistoricalPersistanceStateless GetSession()
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
		
		internal static ArenaHistoricalPersistanceStateless GetValidatedSession()
        {
            ArenaHistoricalPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ArenaHistoricalPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ArenaHistorical Create()
		{	
			SpecializedArenaHistorical entity = new SpecializedArenaHistorical ();
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
		
 		public IList<ArenaHistorical> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.Id = '{0}'", id);
		}

		public IList<ArenaHistorical> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaHistorical> SelectByChampionId ( int championId )
		{
			return SelectByChampionId (-1, -1, championId );
		}
		
		public long CountByChampionId ( int championId )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.ChampionId = '{0}'", championId);
		}

		public IList<ArenaHistorical> SelectByChampionId ( int start, int count, int championId )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.ChampionId = {0}", championId);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaHistorical> SelectByChallengerId ( int challengerId )
		{
			return SelectByChallengerId (-1, -1, challengerId );
		}
		
		public long CountByChallengerId ( int challengerId )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.ChallengerId = '{0}'", challengerId);
		}

		public IList<ArenaHistorical> SelectByChallengerId ( int start, int count, int challengerId )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.ChallengerId = {0}", challengerId);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaHistorical> SelectByWinner ( int winner )
		{
			return SelectByWinner (-1, -1, winner );
		}
		
		public long CountByWinner ( int winner )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.Winner = '{0}'", winner);
		}

		public IList<ArenaHistorical> SelectByWinner ( int start, int count, int winner )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.Winner = {0}", winner);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaHistorical> SelectByWinningSequence ( int winningSequence )
		{
			return SelectByWinningSequence (-1, -1, winningSequence );
		}
		
		public long CountByWinningSequence ( int winningSequence )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.WinningSequence = '{0}'", winningSequence);
		}

		public IList<ArenaHistorical> SelectByWinningSequence ( int start, int count, int winningSequence )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.WinningSequence = {0}", winningSequence);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaHistorical> SelectByBattleId ( int battleId )
		{
			return SelectByBattleId (-1, -1, battleId );
		}
		
		public long CountByBattleId ( int battleId )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.BattleId = '{0}'", battleId);
		}

		public IList<ArenaHistorical> SelectByBattleId ( int start, int count, int battleId )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.BattleId = {0}", battleId);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaHistorical> SelectByStartTick ( int startTick )
		{
			return SelectByStartTick (-1, -1, startTick );
		}
		
		public long CountByStartTick ( int startTick )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.StartTick = '{0}'", startTick);
		}

		public IList<ArenaHistorical> SelectByStartTick ( int start, int count, int startTick )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.StartTick = {0}", startTick);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaHistorical> SelectByEndTick ( int endTick )
		{
			return SelectByEndTick (-1, -1, endTick );
		}
		
		public long CountByEndTick ( int endTick )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.EndTick = '{0}'", endTick);
		}

		public IList<ArenaHistorical> SelectByEndTick ( int start, int count, int endTick )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.EndTick = {0}", endTick);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaHistorical> SelectByArena ( ArenaStorage arena )
		{
			return SelectByArena (-1, -1, arena );
		}
		
		public long CountByArena ( ArenaStorage arena )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaHistorical e where e.Arena = '{0}'", arena);
		}

		public IList<ArenaHistorical> SelectByArena ( int start, int count, ArenaStorage arena )
		{
			IList list = Query(start, count, "from SpecializedArenaHistorical e where e.ArenaNHibernate.Id = {0}", arena.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : ArenaHistorical
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
