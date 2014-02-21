using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class BattlePersistance : 
			NHibernatePersistance<Battle>, IBattlePersistance {
	
		#region Static Access
		
		internal static BattlePersistance CreateSession()
		{
			return new BattlePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedBattle) );
		}
				
		internal static BattlePersistance AttachSession( IPersistanceSession owner )
		{
			BattlePersistance persistance = new BattlePersistance ( owner.Session as ISession, typeof(SpecializedBattle) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static BattlePersistance globalSession = null;
        internal static BattlePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static BattlePersistance GetSession()
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
		
		internal static BattlePersistance GetValidatedSession()
        {
            BattlePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private BattlePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Battle Create()
		{	
			SpecializedBattle entity = new SpecializedBattle ();
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
		
 		public IList<Battle> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.Id = '{0}'", id);
		}

		public IList<Battle> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByCurrentTurn ( int currentTurn )
		{
			return SelectByCurrentTurn (-1, -1, currentTurn );
		}
		
		public long CountByCurrentTurn ( int currentTurn )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.CurrentTurn = '{0}'", currentTurn);
		}

		public IList<Battle> SelectByCurrentTurn ( int start, int count, int currentTurn )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.CurrentTurn = {0}", currentTurn);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByHasEnded ( bool hasEnded )
		{
			return SelectByHasEnded (-1, -1, hasEnded );
		}
		
		public long CountByHasEnded ( bool hasEnded )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.HasEnded = '{0}'", hasEnded);
		}

		public IList<Battle> SelectByHasEnded ( int start, int count, bool hasEnded )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.HasEnded = {0}", hasEnded);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByBattleType ( string battleType )
		{
			return SelectByBattleType (-1, -1, battleType );
		}
		
		public long CountByBattleType ( string battleType )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.BattleType = '{0}'", battleType);
		}

		public IList<Battle> SelectByBattleType ( int start, int count, string battleType )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.BattleType like '{0}'", battleType);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByBattleMode ( string battleMode )
		{
			return SelectByBattleMode (-1, -1, battleMode );
		}
		
		public long CountByBattleMode ( string battleMode )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.BattleMode = '{0}'", battleMode);
		}

		public IList<Battle> SelectByBattleMode ( int start, int count, string battleMode )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.BattleMode like '{0}'", battleMode);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByUnitsDestroyed ( string unitsDestroyed )
		{
			return SelectByUnitsDestroyed (-1, -1, unitsDestroyed );
		}
		
		public long CountByUnitsDestroyed ( string unitsDestroyed )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.UnitsDestroyed = '{0}'", unitsDestroyed);
		}

		public IList<Battle> SelectByUnitsDestroyed ( int start, int count, string unitsDestroyed )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.UnitsDestroyed like '{0}'", unitsDestroyed);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByTerrain ( string terrain )
		{
			return SelectByTerrain (-1, -1, terrain );
		}
		
		public long CountByTerrain ( string terrain )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.Terrain = '{0}'", terrain);
		}

		public IList<Battle> SelectByTerrain ( int start, int count, string terrain )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.Terrain like '{0}'", terrain);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByCurrentPlayer ( int currentPlayer )
		{
			return SelectByCurrentPlayer (-1, -1, currentPlayer );
		}
		
		public long CountByCurrentPlayer ( int currentPlayer )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.CurrentPlayer = '{0}'", currentPlayer);
		}

		public IList<Battle> SelectByCurrentPlayer ( int start, int count, int currentPlayer )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.CurrentPlayer = {0}", currentPlayer);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByTimeoutsAllowed ( int timeoutsAllowed )
		{
			return SelectByTimeoutsAllowed (-1, -1, timeoutsAllowed );
		}
		
		public long CountByTimeoutsAllowed ( int timeoutsAllowed )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.TimeoutsAllowed = '{0}'", timeoutsAllowed);
		}

		public IList<Battle> SelectByTimeoutsAllowed ( int start, int count, int timeoutsAllowed )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.TimeoutsAllowed = {0}", timeoutsAllowed);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByTournamentMode ( string tournamentMode )
		{
			return SelectByTournamentMode (-1, -1, tournamentMode );
		}
		
		public long CountByTournamentMode ( string tournamentMode )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.TournamentMode = '{0}'", tournamentMode);
		}

		public IList<Battle> SelectByTournamentMode ( int start, int count, string tournamentMode )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.TournamentMode like '{0}'", tournamentMode);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByIsDeployTime ( bool isDeployTime )
		{
			return SelectByIsDeployTime (-1, -1, isDeployTime );
		}
		
		public long CountByIsDeployTime ( bool isDeployTime )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.IsDeployTime = '{0}'", isDeployTime);
		}

		public IList<Battle> SelectByIsDeployTime ( int start, int count, bool isDeployTime )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.IsDeployTime = {0}", isDeployTime);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByIsTeamBattle ( bool isTeamBattle )
		{
			return SelectByIsTeamBattle (-1, -1, isTeamBattle );
		}
		
		public long CountByIsTeamBattle ( bool isTeamBattle )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.IsTeamBattle = '{0}'", isTeamBattle);
		}

		public IList<Battle> SelectByIsTeamBattle ( int start, int count, bool isTeamBattle )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.IsTeamBattle = {0}", isTeamBattle);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectBySeqNumber ( double seqNumber )
		{
			return SelectBySeqNumber (-1, -1, seqNumber );
		}
		
		public long CountBySeqNumber ( double seqNumber )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.SeqNumber = '{0}'", seqNumber);
		}

		public IList<Battle> SelectBySeqNumber ( int start, int count, double seqNumber )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Battle> SelectByIsToConquer ( bool isToConquer )
		{
			return SelectByIsToConquer (-1, -1, isToConquer );
		}
		
		public long CountByIsToConquer ( bool isToConquer )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.IsToConquer = '{0}'", isToConquer);
		}

		public IList<Battle> SelectByIsToConquer ( int start, int count, bool isToConquer )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.IsToConquer = {0}", isToConquer);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByIsInPlanet ( bool isInPlanet )
		{
			return SelectByIsInPlanet (-1, -1, isInPlanet );
		}
		
		public long CountByIsInPlanet ( bool isInPlanet )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.IsInPlanet = '{0}'", isInPlanet);
		}

		public IList<Battle> SelectByIsInPlanet ( int start, int count, bool isInPlanet )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.IsInPlanet = {0}", isInPlanet);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByCurrentBot ( int currentBot )
		{
			return SelectByCurrentBot (-1, -1, currentBot );
		}
		
		public long CountByCurrentBot ( int currentBot )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.CurrentBot = '{0}'", currentBot);
		}

		public IList<Battle> SelectByCurrentBot ( int start, int count, int currentBot )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.CurrentBot = {0}", currentBot);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByTournament ( Tournament tournament )
		{
			return SelectByTournament (-1, -1, tournament );
		}
		
		public long CountByTournament ( Tournament tournament )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.Tournament = '{0}'", tournament);
		}

		public IList<Battle> SelectByTournament ( int start, int count, Tournament tournament )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.TournamentNHibernate.Id = {0}", tournament.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Battle> SelectByGroup ( PlayersGroupStorage group )
		{
			return SelectByGroup (-1, -1, group );
		}
		
		public long CountByGroup ( PlayersGroupStorage group )
		{
			return ExecuteScalar("select count(*) from SpecializedBattle e where e.Group = '{0}'", group);
		}

		public IList<Battle> SelectByGroup ( int start, int count, PlayersGroupStorage group )
		{
			IList list = Query(start, count, "from SpecializedBattle e where e.GroupNHibernate.Id = {0}", group.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Battle
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBattleType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBattleMode );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUnitsDestroyed );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTerrain );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTournamentMode );
        }
		public static LifecyleVeto ValidateMaxSizeOfBattleType ( Battle e ) 
        {
			return ValidateStringMaxSize( "Battle", "BattleType", e.BattleType, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfBattleMode ( Battle e ) 
        {
			return ValidateStringMaxSize( "Battle", "BattleMode", e.BattleMode, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUnitsDestroyed ( Battle e ) 
        {
			return ValidateStringMaxSize( "Battle", "UnitsDestroyed", e.UnitsDestroyed, 6000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTerrain ( Battle e ) 
        {
			return ValidateStringMaxSize( "Battle", "Terrain", e.Terrain, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTournamentMode ( Battle e ) 
        {
			return ValidateStringMaxSize( "Battle", "TournamentMode", e.TournamentMode, 100 );
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
