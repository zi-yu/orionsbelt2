using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class TeamStoragePersistanceStateless : 
			NHibernatePersistanceStateless<TeamStorage>, ITeamStoragePersistance {
	
		#region Static Access
		
		internal static TeamStoragePersistanceStateless CreateSession()
		{
			return new TeamStoragePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedTeamStorage) );
		}
				
		internal static TeamStoragePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			TeamStoragePersistanceStateless persistance = new TeamStoragePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedTeamStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static TeamStoragePersistanceStateless globalSession = null;
        internal static TeamStoragePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static TeamStoragePersistanceStateless GetSession()
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
		
		internal static TeamStoragePersistanceStateless GetValidatedSession()
        {
            TeamStoragePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private TeamStoragePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override TeamStorage Create()
		{	
			SpecializedTeamStorage entity = new SpecializedTeamStorage ();
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
		
 		public IList<TeamStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.Id = '{0}'", id);
		}

		public IList<TeamStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.Name = '{0}'", name);
		}

		public IList<TeamStorage> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByEloRanking ( int eloRanking )
		{
			return SelectByEloRanking (-1, -1, eloRanking );
		}
		
		public long CountByEloRanking ( int eloRanking )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.EloRanking = '{0}'", eloRanking);
		}

		public IList<TeamStorage> SelectByEloRanking ( int start, int count, int eloRanking )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.EloRanking = {0}", eloRanking);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByNumberPlayedBattles ( int numberPlayedBattles )
		{
			return SelectByNumberPlayedBattles (-1, -1, numberPlayedBattles );
		}
		
		public long CountByNumberPlayedBattles ( int numberPlayedBattles )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.NumberPlayedBattles = '{0}'", numberPlayedBattles);
		}

		public IList<TeamStorage> SelectByNumberPlayedBattles ( int start, int count, int numberPlayedBattles )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.NumberPlayedBattles = {0}", numberPlayedBattles);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByLadderActive ( bool ladderActive )
		{
			return SelectByLadderActive (-1, -1, ladderActive );
		}
		
		public long CountByLadderActive ( bool ladderActive )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.LadderActive = '{0}'", ladderActive);
		}

		public IList<TeamStorage> SelectByLadderActive ( int start, int count, bool ladderActive )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.LadderActive = {0}", ladderActive);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByLadderPosition ( int ladderPosition )
		{
			return SelectByLadderPosition (-1, -1, ladderPosition );
		}
		
		public long CountByLadderPosition ( int ladderPosition )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.LadderPosition = '{0}'", ladderPosition);
		}

		public IList<TeamStorage> SelectByLadderPosition ( int start, int count, int ladderPosition )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.LadderPosition = {0}", ladderPosition);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByIsInBattle ( int isInBattle )
		{
			return SelectByIsInBattle (-1, -1, isInBattle );
		}
		
		public long CountByIsInBattle ( int isInBattle )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.IsInBattle = '{0}'", isInBattle);
		}

		public IList<TeamStorage> SelectByIsInBattle ( int start, int count, int isInBattle )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.IsInBattle = {0}", isInBattle);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByRestUntil ( int restUntil )
		{
			return SelectByRestUntil (-1, -1, restUntil );
		}
		
		public long CountByRestUntil ( int restUntil )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.RestUntil = '{0}'", restUntil);
		}

		public IList<TeamStorage> SelectByRestUntil ( int start, int count, int restUntil )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.RestUntil = {0}", restUntil);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByStoppedUntil ( int stoppedUntil )
		{
			return SelectByStoppedUntil (-1, -1, stoppedUntil );
		}
		
		public long CountByStoppedUntil ( int stoppedUntil )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.StoppedUntil = '{0}'", stoppedUntil);
		}

		public IList<TeamStorage> SelectByStoppedUntil ( int start, int count, int stoppedUntil )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.StoppedUntil = {0}", stoppedUntil);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByMyStatsId ( int myStatsId )
		{
			return SelectByMyStatsId (-1, -1, myStatsId );
		}
		
		public long CountByMyStatsId ( int myStatsId )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.MyStatsId = '{0}'", myStatsId);
		}

		public IList<TeamStorage> SelectByMyStatsId ( int start, int count, int myStatsId )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.MyStatsId = {0}", myStatsId);
			return ToTypedCollection(list);
		}
		
 		public IList<TeamStorage> SelectByIsComplete ( bool isComplete )
		{
			return SelectByIsComplete (-1, -1, isComplete );
		}
		
		public long CountByIsComplete ( bool isComplete )
		{
			return ExecuteScalar("select count(*) from SpecializedTeamStorage e where e.IsComplete = '{0}'", isComplete);
		}

		public IList<TeamStorage> SelectByIsComplete ( int start, int count, bool isComplete )
		{
			IList list = Query(start, count, "from SpecializedTeamStorage e where e.IsComplete = {0}", isComplete);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : TeamStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( TeamStorage e ) 
        {
			return ValidateStringMaxSize( "TeamStorage", "Name", e.Name, 450 );
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
