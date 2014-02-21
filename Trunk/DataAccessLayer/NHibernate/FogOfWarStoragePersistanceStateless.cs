using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class FogOfWarStoragePersistanceStateless : 
			NHibernatePersistanceStateless<FogOfWarStorage>, IFogOfWarStoragePersistance {
	
		#region Static Access
		
		internal static FogOfWarStoragePersistanceStateless CreateSession()
		{
			return new FogOfWarStoragePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedFogOfWarStorage) );
		}
				
		internal static FogOfWarStoragePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			FogOfWarStoragePersistanceStateless persistance = new FogOfWarStoragePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedFogOfWarStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static FogOfWarStoragePersistanceStateless globalSession = null;
        internal static FogOfWarStoragePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static FogOfWarStoragePersistanceStateless GetSession()
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
		
		internal static FogOfWarStoragePersistanceStateless GetValidatedSession()
        {
            FogOfWarStoragePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private FogOfWarStoragePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override FogOfWarStorage Create()
		{	
			SpecializedFogOfWarStorage entity = new SpecializedFogOfWarStorage ();
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
		
 		public IList<FogOfWarStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedFogOfWarStorage e where e.Id = '{0}'", id);
		}

		public IList<FogOfWarStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedFogOfWarStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<FogOfWarStorage> SelectBySystemX ( int systemX )
		{
			return SelectBySystemX (-1, -1, systemX );
		}
		
		public long CountBySystemX ( int systemX )
		{
			return ExecuteScalar("select count(*) from SpecializedFogOfWarStorage e where e.SystemX = '{0}'", systemX);
		}

		public IList<FogOfWarStorage> SelectBySystemX ( int start, int count, int systemX )
		{
			IList list = Query(start, count, "from SpecializedFogOfWarStorage e where e.SystemX = {0}", systemX);
			return ToTypedCollection(list);
		}
		
 		public IList<FogOfWarStorage> SelectBySystemY ( int systemY )
		{
			return SelectBySystemY (-1, -1, systemY );
		}
		
		public long CountBySystemY ( int systemY )
		{
			return ExecuteScalar("select count(*) from SpecializedFogOfWarStorage e where e.SystemY = '{0}'", systemY);
		}

		public IList<FogOfWarStorage> SelectBySystemY ( int start, int count, int systemY )
		{
			IList list = Query(start, count, "from SpecializedFogOfWarStorage e where e.SystemY = {0}", systemY);
			return ToTypedCollection(list);
		}
		
 		public IList<FogOfWarStorage> SelectBySectors ( string sectors )
		{
			return SelectBySectors (-1, -1, sectors );
		}
		
		public long CountBySectors ( string sectors )
		{
			return ExecuteScalar("select count(*) from SpecializedFogOfWarStorage e where e.Sectors = '{0}'", sectors);
		}

		public IList<FogOfWarStorage> SelectBySectors ( int start, int count, string sectors )
		{
			IList list = Query(start, count, "from SpecializedFogOfWarStorage e where e.Sectors like '{0}'", sectors);
			return ToTypedCollection(list);
		}
		
 		public IList<FogOfWarStorage> SelectByHasDiscoveredAll ( bool hasDiscoveredAll )
		{
			return SelectByHasDiscoveredAll (-1, -1, hasDiscoveredAll );
		}
		
		public long CountByHasDiscoveredAll ( bool hasDiscoveredAll )
		{
			return ExecuteScalar("select count(*) from SpecializedFogOfWarStorage e where e.HasDiscoveredAll = '{0}'", hasDiscoveredAll);
		}

		public IList<FogOfWarStorage> SelectByHasDiscoveredAll ( int start, int count, bool hasDiscoveredAll )
		{
			IList list = Query(start, count, "from SpecializedFogOfWarStorage e where e.HasDiscoveredAll = {0}", hasDiscoveredAll);
			return ToTypedCollection(list);
		}
		
 		public IList<FogOfWarStorage> SelectByHasDiscoveredHalf ( bool hasDiscoveredHalf )
		{
			return SelectByHasDiscoveredHalf (-1, -1, hasDiscoveredHalf );
		}
		
		public long CountByHasDiscoveredHalf ( bool hasDiscoveredHalf )
		{
			return ExecuteScalar("select count(*) from SpecializedFogOfWarStorage e where e.HasDiscoveredHalf = '{0}'", hasDiscoveredHalf);
		}

		public IList<FogOfWarStorage> SelectByHasDiscoveredHalf ( int start, int count, bool hasDiscoveredHalf )
		{
			IList list = Query(start, count, "from SpecializedFogOfWarStorage e where e.HasDiscoveredHalf = {0}", hasDiscoveredHalf);
			return ToTypedCollection(list);
		}
		
 		public IList<FogOfWarStorage> SelectByOwner ( PlayerStorage owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return ExecuteScalar("select count(*) from SpecializedFogOfWarStorage e where e.Owner = '{0}'", owner);
		}

		public IList<FogOfWarStorage> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			IList list = Query(start, count, "from SpecializedFogOfWarStorage e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : FogOfWarStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfSectors );
        }
		public static LifecyleVeto ValidateMaxSizeOfSectors ( FogOfWarStorage e ) 
        {
			return ValidateStringMaxSize( "FogOfWarStorage", "Sectors", e.Sectors, 64000 );
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
