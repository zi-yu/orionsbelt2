using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class BattleStatsPersistanceStateless : 
			NHibernatePersistanceStateless<BattleStats>, IBattleStatsPersistance {
	
		#region Static Access
		
		internal static BattleStatsPersistanceStateless CreateSession()
		{
			return new BattleStatsPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedBattleStats) );
		}
				
		internal static BattleStatsPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			BattleStatsPersistanceStateless persistance = new BattleStatsPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedBattleStats) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static BattleStatsPersistanceStateless globalSession = null;
        internal static BattleStatsPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static BattleStatsPersistanceStateless GetSession()
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
		
		internal static BattleStatsPersistanceStateless GetValidatedSession()
        {
            BattleStatsPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private BattleStatsPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override BattleStats Create()
		{	
			SpecializedBattleStats entity = new SpecializedBattleStats ();
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
		
 		public IList<BattleStats> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleStats e where e.Id = '{0}'", id);
		}

		public IList<BattleStats> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedBattleStats e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleStats> SelectByWins ( int wins )
		{
			return SelectByWins (-1, -1, wins );
		}
		
		public long CountByWins ( int wins )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleStats e where e.Wins = '{0}'", wins);
		}

		public IList<BattleStats> SelectByWins ( int start, int count, int wins )
		{
			IList list = Query(start, count, "from SpecializedBattleStats e where e.Wins = {0}", wins);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleStats> SelectByDefeats ( int defeats )
		{
			return SelectByDefeats (-1, -1, defeats );
		}
		
		public long CountByDefeats ( int defeats )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleStats e where e.Defeats = '{0}'", defeats);
		}

		public IList<BattleStats> SelectByDefeats ( int start, int count, int defeats )
		{
			IList list = Query(start, count, "from SpecializedBattleStats e where e.Defeats = {0}", defeats);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleStats> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleStats e where e.Type = '{0}'", type);
		}

		public IList<BattleStats> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedBattleStats e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleStats> SelectByDetail ( string detail )
		{
			return SelectByDetail (-1, -1, detail );
		}
		
		public long CountByDetail ( string detail )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleStats e where e.Detail = '{0}'", detail);
		}

		public IList<BattleStats> SelectByDetail ( int start, int count, string detail )
		{
			IList list = Query(start, count, "from SpecializedBattleStats e where e.Detail like '{0}'", detail);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleStats> SelectByGiveUps ( int giveUps )
		{
			return SelectByGiveUps (-1, -1, giveUps );
		}
		
		public long CountByGiveUps ( int giveUps )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleStats e where e.GiveUps = '{0}'", giveUps);
		}

		public IList<BattleStats> SelectByGiveUps ( int start, int count, int giveUps )
		{
			IList list = Query(start, count, "from SpecializedBattleStats e where e.GiveUps = {0}", giveUps);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleStats> SelectByStats ( PrincipalStats stats )
		{
			return SelectByStats (-1, -1, stats );
		}
		
		public long CountByStats ( PrincipalStats stats )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleStats e where e.Stats = '{0}'", stats);
		}

		public IList<BattleStats> SelectByStats ( int start, int count, PrincipalStats stats )
		{
			IList list = Query(start, count, "from SpecializedBattleStats e where e.StatsNHibernate.Id = {0}", stats.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleStats> SelectByPlayerStats ( PlayerStats playerStats )
		{
			return SelectByPlayerStats (-1, -1, playerStats );
		}
		
		public long CountByPlayerStats ( PlayerStats playerStats )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleStats e where e.PlayerStats = '{0}'", playerStats);
		}

		public IList<BattleStats> SelectByPlayerStats ( int start, int count, PlayerStats playerStats )
		{
			IList list = Query(start, count, "from SpecializedBattleStats e where e.PlayerStatsNHibernate.Id = {0}", playerStats.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : BattleStats
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDetail );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( BattleStats e ) 
        {
			return ValidateStringMaxSize( "BattleStats", "Type", e.Type, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfDetail ( BattleStats e ) 
        {
			return ValidateStringMaxSize( "BattleStats", "Detail", e.Detail, 100 );
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
