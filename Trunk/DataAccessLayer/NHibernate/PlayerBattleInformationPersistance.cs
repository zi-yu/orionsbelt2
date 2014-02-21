using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PlayerBattleInformationPersistance : 
			NHibernatePersistance<PlayerBattleInformation>, IPlayerBattleInformationPersistance {
	
		#region Static Access
		
		internal static PlayerBattleInformationPersistance CreateSession()
		{
			return new PlayerBattleInformationPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPlayerBattleInformation) );
		}
				
		internal static PlayerBattleInformationPersistance AttachSession( IPersistanceSession owner )
		{
			PlayerBattleInformationPersistance persistance = new PlayerBattleInformationPersistance ( owner.Session as ISession, typeof(SpecializedPlayerBattleInformation) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PlayerBattleInformationPersistance globalSession = null;
        internal static PlayerBattleInformationPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PlayerBattleInformationPersistance GetSession()
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
		
		internal static PlayerBattleInformationPersistance GetValidatedSession()
        {
            PlayerBattleInformationPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PlayerBattleInformationPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PlayerBattleInformation Create()
		{	
			SpecializedPlayerBattleInformation entity = new SpecializedPlayerBattleInformation ();
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
		
 		public IList<PlayerBattleInformation> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.Id = '{0}'", id);
		}

		public IList<PlayerBattleInformation> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByInitialContainer ( string initialContainer )
		{
			return SelectByInitialContainer (-1, -1, initialContainer );
		}
		
		public long CountByInitialContainer ( string initialContainer )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.InitialContainer = '{0}'", initialContainer);
		}

		public IList<PlayerBattleInformation> SelectByInitialContainer ( int start, int count, string initialContainer )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.InitialContainer like '{0}'", initialContainer);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByHasPositioned ( bool hasPositioned )
		{
			return SelectByHasPositioned (-1, -1, hasPositioned );
		}
		
		public long CountByHasPositioned ( bool hasPositioned )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.HasPositioned = '{0}'", hasPositioned);
		}

		public IList<PlayerBattleInformation> SelectByHasPositioned ( int start, int count, bool hasPositioned )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.HasPositioned = {0}", hasPositioned);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByTeamNumber ( int teamNumber )
		{
			return SelectByTeamNumber (-1, -1, teamNumber );
		}
		
		public long CountByTeamNumber ( int teamNumber )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.TeamNumber = '{0}'", teamNumber);
		}

		public IList<PlayerBattleInformation> SelectByTeamNumber ( int start, int count, int teamNumber )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.TeamNumber = {0}", teamNumber);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByHasLost ( bool hasLost )
		{
			return SelectByHasLost (-1, -1, hasLost );
		}
		
		public long CountByHasLost ( bool hasLost )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.HasLost = '{0}'", hasLost);
		}

		public IList<PlayerBattleInformation> SelectByHasLost ( int start, int count, bool hasLost )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.HasLost = {0}", hasLost);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByWinScore ( int winScore )
		{
			return SelectByWinScore (-1, -1, winScore );
		}
		
		public long CountByWinScore ( int winScore )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.WinScore = '{0}'", winScore);
		}

		public IList<PlayerBattleInformation> SelectByWinScore ( int start, int count, int winScore )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.WinScore = {0}", winScore);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByFleetId ( int fleetId )
		{
			return SelectByFleetId (-1, -1, fleetId );
		}
		
		public long CountByFleetId ( int fleetId )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.FleetId = '{0}'", fleetId);
		}

		public IList<PlayerBattleInformation> SelectByFleetId ( int start, int count, int fleetId )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.FleetId = {0}", fleetId);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByUpdateFleet ( bool updateFleet )
		{
			return SelectByUpdateFleet (-1, -1, updateFleet );
		}
		
		public long CountByUpdateFleet ( bool updateFleet )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.UpdateFleet = '{0}'", updateFleet);
		}

		public IList<PlayerBattleInformation> SelectByUpdateFleet ( int start, int count, bool updateFleet )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.UpdateFleet = {0}", updateFleet);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByHasGaveUp ( bool hasGaveUp )
		{
			return SelectByHasGaveUp (-1, -1, hasGaveUp );
		}
		
		public long CountByHasGaveUp ( bool hasGaveUp )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.HasGaveUp = '{0}'", hasGaveUp);
		}

		public IList<PlayerBattleInformation> SelectByHasGaveUp ( int start, int count, bool hasGaveUp )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.HasGaveUp = {0}", hasGaveUp);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByLoseScore ( int loseScore )
		{
			return SelectByLoseScore (-1, -1, loseScore );
		}
		
		public long CountByLoseScore ( int loseScore )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.LoseScore = '{0}'", loseScore);
		}

		public IList<PlayerBattleInformation> SelectByLoseScore ( int start, int count, int loseScore )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.LoseScore = {0}", loseScore);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByVictoryPercentage ( int victoryPercentage )
		{
			return SelectByVictoryPercentage (-1, -1, victoryPercentage );
		}
		
		public long CountByVictoryPercentage ( int victoryPercentage )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.VictoryPercentage = '{0}'", victoryPercentage);
		}

		public IList<PlayerBattleInformation> SelectByVictoryPercentage ( int start, int count, int victoryPercentage )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.VictoryPercentage = {0}", victoryPercentage);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByDominationPoints ( int dominationPoints )
		{
			return SelectByDominationPoints (-1, -1, dominationPoints );
		}
		
		public long CountByDominationPoints ( int dominationPoints )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.DominationPoints = '{0}'", dominationPoints);
		}

		public IList<PlayerBattleInformation> SelectByDominationPoints ( int start, int count, int dominationPoints )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.DominationPoints = {0}", dominationPoints);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByTimeouts ( int timeouts )
		{
			return SelectByTimeouts (-1, -1, timeouts );
		}
		
		public long CountByTimeouts ( int timeouts )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.Timeouts = '{0}'", timeouts);
		}

		public IList<PlayerBattleInformation> SelectByTimeouts ( int start, int count, int timeouts )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.Timeouts = {0}", timeouts);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByOwner ( int owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( int owner )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.Owner = '{0}'", owner);
		}

		public IList<PlayerBattleInformation> SelectByOwner ( int start, int count, int owner )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.Owner = {0}", owner);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.Name = '{0}'", name);
		}

		public IList<PlayerBattleInformation> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByTeamName ( string teamName )
		{
			return SelectByTeamName (-1, -1, teamName );
		}
		
		public long CountByTeamName ( string teamName )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.TeamName = '{0}'", teamName);
		}

		public IList<PlayerBattleInformation> SelectByTeamName ( int start, int count, string teamName )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.TeamName like '{0}'", teamName);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByUltimateUnit ( string ultimateUnit )
		{
			return SelectByUltimateUnit (-1, -1, ultimateUnit );
		}
		
		public long CountByUltimateUnit ( string ultimateUnit )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.UltimateUnit = '{0}'", ultimateUnit);
		}

		public IList<PlayerBattleInformation> SelectByUltimateUnit ( int start, int count, string ultimateUnit )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.UltimateUnit like '{0}'", ultimateUnit);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByBotId ( int botId )
		{
			return SelectByBotId (-1, -1, botId );
		}
		
		public long CountByBotId ( int botId )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.BotId = '{0}'", botId);
		}

		public IList<PlayerBattleInformation> SelectByBotId ( int start, int count, int botId )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.BotId = {0}", botId);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerBattleInformation> SelectByBattle ( Battle battle )
		{
			return SelectByBattle (-1, -1, battle );
		}
		
		public long CountByBattle ( Battle battle )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerBattleInformation e where e.Battle = '{0}'", battle);
		}

		public IList<PlayerBattleInformation> SelectByBattle ( int start, int count, Battle battle )
		{
			IList list = Query(start, count, "from SpecializedPlayerBattleInformation e where e.BattleNHibernate.Id = {0}", battle.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PlayerBattleInformation
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfInitialContainer );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTeamName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUltimateUnit );
        }
		public static LifecyleVeto ValidateMaxSizeOfInitialContainer ( PlayerBattleInformation e ) 
        {
			return ValidateStringMaxSize( "PlayerBattleInformation", "InitialContainer", e.InitialContainer, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfName ( PlayerBattleInformation e ) 
        {
			return ValidateStringMaxSize( "PlayerBattleInformation", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTeamName ( PlayerBattleInformation e ) 
        {
			return ValidateStringMaxSize( "PlayerBattleInformation", "TeamName", e.TeamName, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUltimateUnit ( PlayerBattleInformation e ) 
        {
			return ValidateStringMaxSize( "PlayerBattleInformation", "UltimateUnit", e.UltimateUnit, 100 );
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
