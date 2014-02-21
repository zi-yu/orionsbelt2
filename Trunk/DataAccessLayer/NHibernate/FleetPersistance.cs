using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class FleetPersistance : 
			NHibernatePersistance<Fleet>, IFleetPersistance {
	
		#region Static Access
		
		internal static FleetPersistance CreateSession()
		{
			return new FleetPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedFleet) );
		}
				
		internal static FleetPersistance AttachSession( IPersistanceSession owner )
		{
			FleetPersistance persistance = new FleetPersistance ( owner.Session as ISession, typeof(SpecializedFleet) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static FleetPersistance globalSession = null;
        internal static FleetPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static FleetPersistance GetSession()
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
		
		internal static FleetPersistance GetValidatedSession()
        {
            FleetPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private FleetPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Fleet Create()
		{	
			SpecializedFleet entity = new SpecializedFleet ();
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
		
 		public IList<Fleet> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.Id = '{0}'", id);
		}

		public IList<Fleet> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.Name = '{0}'", name);
		}

		public IList<Fleet> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByUnits ( string units )
		{
			return SelectByUnits (-1, -1, units );
		}
		
		public long CountByUnits ( string units )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.Units = '{0}'", units);
		}

		public IList<Fleet> SelectByUnits ( int start, int count, string units )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.Units like '{0}'", units);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByTournamentFleet ( bool tournamentFleet )
		{
			return SelectByTournamentFleet (-1, -1, tournamentFleet );
		}
		
		public long CountByTournamentFleet ( bool tournamentFleet )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.TournamentFleet = '{0}'", tournamentFleet);
		}

		public IList<Fleet> SelectByTournamentFleet ( int start, int count, bool tournamentFleet )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.TournamentFleet = {0}", tournamentFleet);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByIsMovable ( bool isMovable )
		{
			return SelectByIsMovable (-1, -1, isMovable );
		}
		
		public long CountByIsMovable ( bool isMovable )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.IsMovable = '{0}'", isMovable);
		}

		public IList<Fleet> SelectByIsMovable ( int start, int count, bool isMovable )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.IsMovable = {0}", isMovable);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByUltimateUnit ( string ultimateUnit )
		{
			return SelectByUltimateUnit (-1, -1, ultimateUnit );
		}
		
		public long CountByUltimateUnit ( string ultimateUnit )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.UltimateUnit = '{0}'", ultimateUnit);
		}

		public IList<Fleet> SelectByUltimateUnit ( int start, int count, string ultimateUnit )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.UltimateUnit like '{0}'", ultimateUnit);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByIsInBattle ( bool isInBattle )
		{
			return SelectByIsInBattle (-1, -1, isInBattle );
		}
		
		public long CountByIsInBattle ( bool isInBattle )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.IsInBattle = '{0}'", isInBattle);
		}

		public IList<Fleet> SelectByIsInBattle ( int start, int count, bool isInBattle )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.IsInBattle = {0}", isInBattle);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByIsPlanetDefenseFleet ( bool isPlanetDefenseFleet )
		{
			return SelectByIsPlanetDefenseFleet (-1, -1, isPlanetDefenseFleet );
		}
		
		public long CountByIsPlanetDefenseFleet ( bool isPlanetDefenseFleet )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.IsPlanetDefenseFleet = '{0}'", isPlanetDefenseFleet);
		}

		public IList<Fleet> SelectByIsPlanetDefenseFleet ( int start, int count, bool isPlanetDefenseFleet )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.IsPlanetDefenseFleet = {0}", isPlanetDefenseFleet);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectBySystemX ( int systemX )
		{
			return SelectBySystemX (-1, -1, systemX );
		}
		
		public long CountBySystemX ( int systemX )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.SystemX = '{0}'", systemX);
		}

		public IList<Fleet> SelectBySystemX ( int start, int count, int systemX )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.SystemX = {0}", systemX);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectBySystemY ( int systemY )
		{
			return SelectBySystemY (-1, -1, systemY );
		}
		
		public long CountBySystemY ( int systemY )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.SystemY = '{0}'", systemY);
		}

		public IList<Fleet> SelectBySystemY ( int start, int count, int systemY )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.SystemY = {0}", systemY);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectBySectorX ( int sectorX )
		{
			return SelectBySectorX (-1, -1, sectorX );
		}
		
		public long CountBySectorX ( int sectorX )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.SectorX = '{0}'", sectorX);
		}

		public IList<Fleet> SelectBySectorX ( int start, int count, int sectorX )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.SectorX = {0}", sectorX);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectBySectorY ( int sectorY )
		{
			return SelectBySectorY (-1, -1, sectorY );
		}
		
		public long CountBySectorY ( int sectorY )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.SectorY = '{0}'", sectorY);
		}

		public IList<Fleet> SelectBySectorY ( int start, int count, int sectorY )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.SectorY = {0}", sectorY);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByCargo ( string cargo )
		{
			return SelectByCargo (-1, -1, cargo );
		}
		
		public long CountByCargo ( string cargo )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.Cargo = '{0}'", cargo);
		}

		public IList<Fleet> SelectByCargo ( int start, int count, string cargo )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.Cargo like '{0}'", cargo);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByIsBot ( bool isBot )
		{
			return SelectByIsBot (-1, -1, isBot );
		}
		
		public long CountByIsBot ( bool isBot )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.IsBot = '{0}'", isBot);
		}

		public IList<Fleet> SelectByIsBot ( int start, int count, bool isBot )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.IsBot = {0}", isBot);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByWayPoints ( string wayPoints )
		{
			return SelectByWayPoints (-1, -1, wayPoints );
		}
		
		public long CountByWayPoints ( string wayPoints )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.WayPoints = '{0}'", wayPoints);
		}

		public IList<Fleet> SelectByWayPoints ( int start, int count, string wayPoints )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.WayPoints like '{0}'", wayPoints);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByImmunityStartTick ( int immunityStartTick )
		{
			return SelectByImmunityStartTick (-1, -1, immunityStartTick );
		}
		
		public long CountByImmunityStartTick ( int immunityStartTick )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.ImmunityStartTick = '{0}'", immunityStartTick);
		}

		public IList<Fleet> SelectByImmunityStartTick ( int start, int count, int immunityStartTick )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.ImmunityStartTick = {0}", immunityStartTick);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByCurrentPlanet ( PlanetStorage currentPlanet )
		{
			return SelectByCurrentPlanet (-1, -1, currentPlanet );
		}
		
		public long CountByCurrentPlanet ( PlanetStorage currentPlanet )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.CurrentPlanet = '{0}'", currentPlanet);
		}

		public IList<Fleet> SelectByCurrentPlanet ( int start, int count, PlanetStorage currentPlanet )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.CurrentPlanetNHibernate.Id = {0}", currentPlanet.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByPrincipalOwner ( Principal principalOwner )
		{
			return SelectByPrincipalOwner (-1, -1, principalOwner );
		}
		
		public long CountByPrincipalOwner ( Principal principalOwner )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.PrincipalOwner = '{0}'", principalOwner);
		}

		public IList<Fleet> SelectByPrincipalOwner ( int start, int count, Principal principalOwner )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.PrincipalOwnerNHibernate.Id = {0}", principalOwner.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectBySector ( SectorStorage sector )
		{
			return SelectBySector (-1, -1, sector );
		}
		
		public long CountBySector ( SectorStorage sector )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.Sector = '{0}'", sector);
		}

		public IList<Fleet> SelectBySector ( int start, int count, SectorStorage sector )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.SectorNHibernate.Id = {0}", sector.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Fleet> SelectByPlayerOwner ( PlayerStorage playerOwner )
		{
			return SelectByPlayerOwner (-1, -1, playerOwner );
		}
		
		public long CountByPlayerOwner ( PlayerStorage playerOwner )
		{
			return ExecuteScalar("select count(*) from SpecializedFleet e where e.PlayerOwner = '{0}'", playerOwner);
		}

		public IList<Fleet> SelectByPlayerOwner ( int start, int count, PlayerStorage playerOwner )
		{
			IList list = Query(start, count, "from SpecializedFleet e where e.PlayerOwnerNHibernate.Id = {0}", playerOwner.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Fleet
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUnits );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUltimateUnit );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCargo );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfWayPoints );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Fleet e ) 
        {
			return ValidateStringMaxSize( "Fleet", "Name", e.Name, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUnits ( Fleet e ) 
        {
			return ValidateStringMaxSize( "Fleet", "Units", e.Units, 500 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUltimateUnit ( Fleet e ) 
        {
			return ValidateStringMaxSize( "Fleet", "UltimateUnit", e.UltimateUnit, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCargo ( Fleet e ) 
        {
			return ValidateStringMaxSize( "Fleet", "Cargo", e.Cargo, 500 );
		}
		public static LifecyleVeto ValidateMaxSizeOfWayPoints ( Fleet e ) 
        {
			return ValidateStringMaxSize( "Fleet", "WayPoints", e.WayPoints, 100 );
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
