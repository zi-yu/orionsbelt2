using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class TournamentPersistanceStateless : 
			NHibernatePersistanceStateless<Tournament>, ITournamentPersistance {
	
		#region Static Access
		
		internal static TournamentPersistanceStateless CreateSession()
		{
			return new TournamentPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedTournament) );
		}
				
		internal static TournamentPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			TournamentPersistanceStateless persistance = new TournamentPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedTournament) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static TournamentPersistanceStateless globalSession = null;
        internal static TournamentPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static TournamentPersistanceStateless GetSession()
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
		
		internal static TournamentPersistanceStateless GetValidatedSession()
        {
            TournamentPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private TournamentPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Tournament Create()
		{	
			SpecializedTournament entity = new SpecializedTournament ();
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
		
 		public IList<Tournament> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.Id = '{0}'", id);
		}

		public IList<Tournament> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.Name = '{0}'", name);
		}

		public IList<Tournament> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByWarningTick ( int warningTick )
		{
			return SelectByWarningTick (-1, -1, warningTick );
		}
		
		public long CountByWarningTick ( int warningTick )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.WarningTick = '{0}'", warningTick);
		}

		public IList<Tournament> SelectByWarningTick ( int start, int count, int warningTick )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.WarningTick = {0}", warningTick);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByPrize ( string prize )
		{
			return SelectByPrize (-1, -1, prize );
		}
		
		public long CountByPrize ( string prize )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.Prize = '{0}'", prize);
		}

		public IList<Tournament> SelectByPrize ( int start, int count, string prize )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.Prize like '{0}'", prize);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByCostCredits ( int costCredits )
		{
			return SelectByCostCredits (-1, -1, costCredits );
		}
		
		public long CountByCostCredits ( int costCredits )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.CostCredits = '{0}'", costCredits);
		}

		public IList<Tournament> SelectByCostCredits ( int start, int count, int costCredits )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.CostCredits = {0}", costCredits);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByTournamentType ( string tournamentType )
		{
			return SelectByTournamentType (-1, -1, tournamentType );
		}
		
		public long CountByTournamentType ( string tournamentType )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.TournamentType = '{0}'", tournamentType);
		}

		public IList<Tournament> SelectByTournamentType ( int start, int count, string tournamentType )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.TournamentType like '{0}'", tournamentType);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByFleetId ( int fleetId )
		{
			return SelectByFleetId (-1, -1, fleetId );
		}
		
		public long CountByFleetId ( int fleetId )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.FleetId = '{0}'", fleetId);
		}

		public IList<Tournament> SelectByFleetId ( int start, int count, int fleetId )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.FleetId = {0}", fleetId);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByIsPublic ( bool isPublic )
		{
			return SelectByIsPublic (-1, -1, isPublic );
		}
		
		public long CountByIsPublic ( bool isPublic )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.IsPublic = '{0}'", isPublic);
		}

		public IList<Tournament> SelectByIsPublic ( int start, int count, bool isPublic )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.IsPublic = {0}", isPublic);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByIsSurvival ( bool isSurvival )
		{
			return SelectByIsSurvival (-1, -1, isSurvival );
		}
		
		public long CountByIsSurvival ( bool isSurvival )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.IsSurvival = '{0}'", isSurvival);
		}

		public IList<Tournament> SelectByIsSurvival ( int start, int count, bool isSurvival )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.IsSurvival = {0}", isSurvival);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByTurnTime ( int turnTime )
		{
			return SelectByTurnTime (-1, -1, turnTime );
		}
		
		public long CountByTurnTime ( int turnTime )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.TurnTime = '{0}'", turnTime);
		}

		public IList<Tournament> SelectByTurnTime ( int start, int count, int turnTime )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.TurnTime = {0}", turnTime);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectBySubscriptionTime ( int subscriptionTime )
		{
			return SelectBySubscriptionTime (-1, -1, subscriptionTime );
		}
		
		public long CountBySubscriptionTime ( int subscriptionTime )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.SubscriptionTime = '{0}'", subscriptionTime);
		}

		public IList<Tournament> SelectBySubscriptionTime ( int start, int count, int subscriptionTime )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.SubscriptionTime = {0}", subscriptionTime);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByMaxPlayers ( int maxPlayers )
		{
			return SelectByMaxPlayers (-1, -1, maxPlayers );
		}
		
		public long CountByMaxPlayers ( int maxPlayers )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.MaxPlayers = '{0}'", maxPlayers);
		}

		public IList<Tournament> SelectByMaxPlayers ( int start, int count, int maxPlayers )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.MaxPlayers = {0}", maxPlayers);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByMinPlayers ( int minPlayers )
		{
			return SelectByMinPlayers (-1, -1, minPlayers );
		}
		
		public long CountByMinPlayers ( int minPlayers )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.MinPlayers = '{0}'", minPlayers);
		}

		public IList<Tournament> SelectByMinPlayers ( int start, int count, int minPlayers )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.MinPlayers = {0}", minPlayers);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByNPlayersToPlayoff ( int nPlayersToPlayoff )
		{
			return SelectByNPlayersToPlayoff (-1, -1, nPlayersToPlayoff );
		}
		
		public long CountByNPlayersToPlayoff ( int nPlayersToPlayoff )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.NPlayersToPlayoff = '{0}'", nPlayersToPlayoff);
		}

		public IList<Tournament> SelectByNPlayersToPlayoff ( int start, int count, int nPlayersToPlayoff )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.NPlayersToPlayoff = {0}", nPlayersToPlayoff);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByMaxElo ( int maxElo )
		{
			return SelectByMaxElo (-1, -1, maxElo );
		}
		
		public long CountByMaxElo ( int maxElo )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.MaxElo = '{0}'", maxElo);
		}

		public IList<Tournament> SelectByMaxElo ( int start, int count, int maxElo )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.MaxElo = {0}", maxElo);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByMinElo ( int minElo )
		{
			return SelectByMinElo (-1, -1, minElo );
		}
		
		public long CountByMinElo ( int minElo )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.MinElo = '{0}'", minElo);
		}

		public IList<Tournament> SelectByMinElo ( int start, int count, int minElo )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.MinElo = {0}", minElo);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByStartTime ( DateTime startTime )
		{
			return SelectByStartTime (-1, -1, startTime );
		}
		
		public long CountByStartTime ( DateTime startTime )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.StartTime = '{0}'", startTime);
		}

		public IList<Tournament> SelectByStartTime ( int start, int count, DateTime startTime )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Tournament> SelectByEndDate ( DateTime endDate )
		{
			return SelectByEndDate (-1, -1, endDate );
		}
		
		public long CountByEndDate ( DateTime endDate )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.EndDate = '{0}'", endDate);
		}

		public IList<Tournament> SelectByEndDate ( int start, int count, DateTime endDate )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Tournament> SelectByToken ( string token )
		{
			return SelectByToken (-1, -1, token );
		}
		
		public long CountByToken ( string token )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.Token = '{0}'", token);
		}

		public IList<Tournament> SelectByToken ( int start, int count, string token )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.Token like '{0}'", token);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByTokenNumber ( int tokenNumber )
		{
			return SelectByTokenNumber (-1, -1, tokenNumber );
		}
		
		public long CountByTokenNumber ( int tokenNumber )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.TokenNumber = '{0}'", tokenNumber);
		}

		public IList<Tournament> SelectByTokenNumber ( int start, int count, int tokenNumber )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.TokenNumber = {0}", tokenNumber);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByIsCustom ( bool isCustom )
		{
			return SelectByIsCustom (-1, -1, isCustom );
		}
		
		public long CountByIsCustom ( bool isCustom )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.IsCustom = '{0}'", isCustom);
		}

		public IList<Tournament> SelectByIsCustom ( int start, int count, bool isCustom )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.IsCustom = {0}", isCustom);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByPaymentsRequired ( int paymentsRequired )
		{
			return SelectByPaymentsRequired (-1, -1, paymentsRequired );
		}
		
		public long CountByPaymentsRequired ( int paymentsRequired )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.PaymentsRequired = '{0}'", paymentsRequired);
		}

		public IList<Tournament> SelectByPaymentsRequired ( int start, int count, int paymentsRequired )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.PaymentsRequired = {0}", paymentsRequired);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByNumberPassGroup ( int numberPassGroup )
		{
			return SelectByNumberPassGroup (-1, -1, numberPassGroup );
		}
		
		public long CountByNumberPassGroup ( int numberPassGroup )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.NumberPassGroup = '{0}'", numberPassGroup);
		}

		public IList<Tournament> SelectByNumberPassGroup ( int start, int count, int numberPassGroup )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.NumberPassGroup = {0}", numberPassGroup);
			return ToTypedCollection(list);
		}
		
 		public IList<Tournament> SelectByDescriptionToken ( string descriptionToken )
		{
			return SelectByDescriptionToken (-1, -1, descriptionToken );
		}
		
		public long CountByDescriptionToken ( string descriptionToken )
		{
			return ExecuteScalar("select count(*) from SpecializedTournament e where e.DescriptionToken = '{0}'", descriptionToken);
		}

		public IList<Tournament> SelectByDescriptionToken ( int start, int count, string descriptionToken )
		{
			IList list = Query(start, count, "from SpecializedTournament e where e.DescriptionToken like '{0}'", descriptionToken);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Tournament
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfPrize );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTournamentType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfToken );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDescriptionToken );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Tournament e ) 
        {
			return ValidateStringMaxSize( "Tournament", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfPrize ( Tournament e ) 
        {
			return ValidateStringMaxSize( "Tournament", "Prize", e.Prize, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTournamentType ( Tournament e ) 
        {
			return ValidateStringMaxSize( "Tournament", "TournamentType", e.TournamentType, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfToken ( Tournament e ) 
        {
			return ValidateStringMaxSize( "Tournament", "Token", e.Token, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfDescriptionToken ( Tournament e ) 
        {
			return ValidateStringMaxSize( "Tournament", "DescriptionToken", e.DescriptionToken, 100 );
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
