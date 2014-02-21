using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class UniverseSpecialSectorPersistanceStateless : 
			NHibernatePersistanceStateless<UniverseSpecialSector>, IUniverseSpecialSectorPersistance {
	
		#region Static Access
		
		internal static UniverseSpecialSectorPersistanceStateless CreateSession()
		{
			return new UniverseSpecialSectorPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedUniverseSpecialSector) );
		}
				
		internal static UniverseSpecialSectorPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			UniverseSpecialSectorPersistanceStateless persistance = new UniverseSpecialSectorPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedUniverseSpecialSector) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static UniverseSpecialSectorPersistanceStateless globalSession = null;
        internal static UniverseSpecialSectorPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static UniverseSpecialSectorPersistanceStateless GetSession()
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
		
		internal static UniverseSpecialSectorPersistanceStateless GetValidatedSession()
        {
            UniverseSpecialSectorPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private UniverseSpecialSectorPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override UniverseSpecialSector Create()
		{	
			SpecializedUniverseSpecialSector entity = new SpecializedUniverseSpecialSector ();
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
		
 		public IList<UniverseSpecialSector> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedUniverseSpecialSector e where e.Id = '{0}'", id);
		}

		public IList<UniverseSpecialSector> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedUniverseSpecialSector e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<UniverseSpecialSector> SelectBySystemX ( int systemX )
		{
			return SelectBySystemX (-1, -1, systemX );
		}
		
		public long CountBySystemX ( int systemX )
		{
			return ExecuteScalar("select count(*) from SpecializedUniverseSpecialSector e where e.SystemX = '{0}'", systemX);
		}

		public IList<UniverseSpecialSector> SelectBySystemX ( int start, int count, int systemX )
		{
			IList list = Query(start, count, "from SpecializedUniverseSpecialSector e where e.SystemX = {0}", systemX);
			return ToTypedCollection(list);
		}
		
 		public IList<UniverseSpecialSector> SelectBySystemY ( int systemY )
		{
			return SelectBySystemY (-1, -1, systemY );
		}
		
		public long CountBySystemY ( int systemY )
		{
			return ExecuteScalar("select count(*) from SpecializedUniverseSpecialSector e where e.SystemY = '{0}'", systemY);
		}

		public IList<UniverseSpecialSector> SelectBySystemY ( int start, int count, int systemY )
		{
			IList list = Query(start, count, "from SpecializedUniverseSpecialSector e where e.SystemY = {0}", systemY);
			return ToTypedCollection(list);
		}
		
 		public IList<UniverseSpecialSector> SelectBySectorX ( int sectorX )
		{
			return SelectBySectorX (-1, -1, sectorX );
		}
		
		public long CountBySectorX ( int sectorX )
		{
			return ExecuteScalar("select count(*) from SpecializedUniverseSpecialSector e where e.SectorX = '{0}'", sectorX);
		}

		public IList<UniverseSpecialSector> SelectBySectorX ( int start, int count, int sectorX )
		{
			IList list = Query(start, count, "from SpecializedUniverseSpecialSector e where e.SectorX = {0}", sectorX);
			return ToTypedCollection(list);
		}
		
 		public IList<UniverseSpecialSector> SelectBySectorY ( int sectorY )
		{
			return SelectBySectorY (-1, -1, sectorY );
		}
		
		public long CountBySectorY ( int sectorY )
		{
			return ExecuteScalar("select count(*) from SpecializedUniverseSpecialSector e where e.SectorY = '{0}'", sectorY);
		}

		public IList<UniverseSpecialSector> SelectBySectorY ( int start, int count, int sectorY )
		{
			IList list = Query(start, count, "from SpecializedUniverseSpecialSector e where e.SectorY = {0}", sectorY);
			return ToTypedCollection(list);
		}
		
 		public IList<UniverseSpecialSector> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedUniverseSpecialSector e where e.Type = '{0}'", type);
		}

		public IList<UniverseSpecialSector> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedUniverseSpecialSector e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<UniverseSpecialSector> SelectByOwner ( PlayerStorage owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return ExecuteScalar("select count(*) from SpecializedUniverseSpecialSector e where e.Owner = '{0}'", owner);
		}

		public IList<UniverseSpecialSector> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			IList list = Query(start, count, "from SpecializedUniverseSpecialSector e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<UniverseSpecialSector> SelectBySector ( SectorStorage sector )
		{
			return SelectBySector (-1, -1, sector );
		}
		
		public long CountBySector ( SectorStorage sector )
		{
			return ExecuteScalar("select count(*) from SpecializedUniverseSpecialSector e where e.Sector = '{0}'", sector);
		}

		public IList<UniverseSpecialSector> SelectBySector ( int start, int count, SectorStorage sector )
		{
			IList list = Query(start, count, "from SpecializedUniverseSpecialSector e where e.SectorNHibernate.Id = {0}", sector.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : UniverseSpecialSector
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( UniverseSpecialSector e ) 
        {
			return ValidateStringMaxSize( "UniverseSpecialSector", "Type", e.Type, 100 );
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
