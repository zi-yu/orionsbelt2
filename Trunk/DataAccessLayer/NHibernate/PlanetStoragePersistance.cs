using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PlanetStoragePersistance : 
			NHibernatePersistance<PlanetStorage>, IPlanetStoragePersistance {
	
		#region Static Access
		
		internal static PlanetStoragePersistance CreateSession()
		{
			return new PlanetStoragePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPlanetStorage) );
		}
				
		internal static PlanetStoragePersistance AttachSession( IPersistanceSession owner )
		{
			PlanetStoragePersistance persistance = new PlanetStoragePersistance ( owner.Session as ISession, typeof(SpecializedPlanetStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PlanetStoragePersistance globalSession = null;
        internal static PlanetStoragePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PlanetStoragePersistance GetSession()
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
		
		internal static PlanetStoragePersistance GetValidatedSession()
        {
            PlanetStoragePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PlanetStoragePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PlanetStorage Create()
		{	
			SpecializedPlanetStorage entity = new SpecializedPlanetStorage ();
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
		
 		public IList<PlanetStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Id = '{0}'", id);
		}

		public IList<PlanetStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Name = '{0}'", name);
		}

		public IList<PlanetStorage> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByProductionFactor ( double productionFactor )
		{
			return SelectByProductionFactor (-1, -1, productionFactor );
		}
		
		public long CountByProductionFactor ( double productionFactor )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.ProductionFactor = '{0}'", productionFactor);
		}

		public IList<PlanetStorage> SelectByProductionFactor ( int start, int count, double productionFactor )
		{
			throw new NotImplementedException();
		}
		
 		public IList<PlanetStorage> SelectByModifiers ( string modifiers )
		{
			return SelectByModifiers (-1, -1, modifiers );
		}
		
		public long CountByModifiers ( string modifiers )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Modifiers = '{0}'", modifiers);
		}

		public IList<PlanetStorage> SelectByModifiers ( int start, int count, string modifiers )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.Modifiers like '{0}'", modifiers);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByRichness ( string richness )
		{
			return SelectByRichness (-1, -1, richness );
		}
		
		public long CountByRichness ( string richness )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Richness = '{0}'", richness);
		}

		public IList<PlanetStorage> SelectByRichness ( int start, int count, string richness )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.Richness like '{0}'", richness);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByInfo ( string info )
		{
			return SelectByInfo (-1, -1, info );
		}
		
		public long CountByInfo ( string info )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Info = '{0}'", info);
		}

		public IList<PlanetStorage> SelectByInfo ( int start, int count, string info )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.Info like '{0}'", info);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByTerrain ( string terrain )
		{
			return SelectByTerrain (-1, -1, terrain );
		}
		
		public long CountByTerrain ( string terrain )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Terrain = '{0}'", terrain);
		}

		public IList<PlanetStorage> SelectByTerrain ( int start, int count, string terrain )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.Terrain like '{0}'", terrain);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByIsPrivate ( bool isPrivate )
		{
			return SelectByIsPrivate (-1, -1, isPrivate );
		}
		
		public long CountByIsPrivate ( bool isPrivate )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.IsPrivate = '{0}'", isPrivate);
		}

		public IList<PlanetStorage> SelectByIsPrivate ( int start, int count, bool isPrivate )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.IsPrivate = {0}", isPrivate);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectBySystemX ( int systemX )
		{
			return SelectBySystemX (-1, -1, systemX );
		}
		
		public long CountBySystemX ( int systemX )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.SystemX = '{0}'", systemX);
		}

		public IList<PlanetStorage> SelectBySystemX ( int start, int count, int systemX )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.SystemX = {0}", systemX);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectBySystemY ( int systemY )
		{
			return SelectBySystemY (-1, -1, systemY );
		}
		
		public long CountBySystemY ( int systemY )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.SystemY = '{0}'", systemY);
		}

		public IList<PlanetStorage> SelectBySystemY ( int start, int count, int systemY )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.SystemY = {0}", systemY);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectBySectorX ( int sectorX )
		{
			return SelectBySectorX (-1, -1, sectorX );
		}
		
		public long CountBySectorX ( int sectorX )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.SectorX = '{0}'", sectorX);
		}

		public IList<PlanetStorage> SelectBySectorX ( int start, int count, int sectorX )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.SectorX = {0}", sectorX);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectBySectorY ( int sectorY )
		{
			return SelectBySectorY (-1, -1, sectorY );
		}
		
		public long CountBySectorY ( int sectorY )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.SectorY = '{0}'", sectorY);
		}

		public IList<PlanetStorage> SelectBySectorY ( int start, int count, int sectorY )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.SectorY = {0}", sectorY);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByScore ( int score )
		{
			return SelectByScore (-1, -1, score );
		}
		
		public long CountByScore ( int score )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Score = '{0}'", score);
		}

		public IList<PlanetStorage> SelectByScore ( int start, int count, int score )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.Score = {0}", score);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByLevel ( int level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( int level )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Level = '{0}'", level);
		}

		public IList<PlanetStorage> SelectByLevel ( int start, int count, int level )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.Level = {0}", level);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByLastPillageTick ( int lastPillageTick )
		{
			return SelectByLastPillageTick (-1, -1, lastPillageTick );
		}
		
		public long CountByLastPillageTick ( int lastPillageTick )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.LastPillageTick = '{0}'", lastPillageTick);
		}

		public IList<PlanetStorage> SelectByLastPillageTick ( int start, int count, int lastPillageTick )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.LastPillageTick = {0}", lastPillageTick);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByLastConquerTick ( int lastConquerTick )
		{
			return SelectByLastConquerTick (-1, -1, lastConquerTick );
		}
		
		public long CountByLastConquerTick ( int lastConquerTick )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.LastConquerTick = '{0}'", lastConquerTick);
		}

		public IList<PlanetStorage> SelectByLastConquerTick ( int start, int count, int lastConquerTick )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.LastConquerTick = {0}", lastConquerTick);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByFacilityLevel ( int facilityLevel )
		{
			return SelectByFacilityLevel (-1, -1, facilityLevel );
		}
		
		public long CountByFacilityLevel ( int facilityLevel )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.FacilityLevel = '{0}'", facilityLevel);
		}

		public IList<PlanetStorage> SelectByFacilityLevel ( int start, int count, int facilityLevel )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.FacilityLevel = {0}", facilityLevel);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectByPlayer ( PlayerStorage player )
		{
			return SelectByPlayer (-1, -1, player );
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Player = '{0}'", player);
		}

		public IList<PlanetStorage> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.PlayerNHibernate.Id = {0}", player.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetStorage> SelectBySector ( SectorStorage sector )
		{
			return SelectBySector (-1, -1, sector );
		}
		
		public long CountBySector ( SectorStorage sector )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetStorage e where e.Sector = '{0}'", sector);
		}

		public IList<PlanetStorage> SelectBySector ( int start, int count, SectorStorage sector )
		{
			IList list = Query(start, count, "from SpecializedPlanetStorage e where e.SectorNHibernate.Id = {0}", sector.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PlanetStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfModifiers );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfRichness );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfInfo );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTerrain );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( PlanetStorage e ) 
        {
			return ValidateStringMaxSize( "PlanetStorage", "Name", e.Name, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfModifiers ( PlanetStorage e ) 
        {
			return ValidateStringMaxSize( "PlanetStorage", "Modifiers", e.Modifiers, 2000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfRichness ( PlanetStorage e ) 
        {
			return ValidateStringMaxSize( "PlanetStorage", "Richness", e.Richness, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfInfo ( PlanetStorage e ) 
        {
			return ValidateStringMaxSize( "PlanetStorage", "Info", e.Info, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTerrain ( PlanetStorage e ) 
        {
			return ValidateStringMaxSize( "PlanetStorage", "Terrain", e.Terrain, 100 );
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
