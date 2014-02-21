using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class AssetPersistance : 
			NHibernatePersistance<Asset>, IAssetPersistance {
	
		#region Static Access
		
		internal static AssetPersistance CreateSession()
		{
			return new AssetPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedAsset) );
		}
				
		internal static AssetPersistance AttachSession( IPersistanceSession owner )
		{
			AssetPersistance persistance = new AssetPersistance ( owner.Session as ISession, typeof(SpecializedAsset) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static AssetPersistance globalSession = null;
        internal static AssetPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static AssetPersistance GetSession()
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
		
		internal static AssetPersistance GetValidatedSession()
        {
            AssetPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private AssetPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Asset Create()
		{	
			SpecializedAsset entity = new SpecializedAsset ();
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
		
 		public IList<Asset> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedAsset e where e.Id = '{0}'", id);
		}

		public IList<Asset> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedAsset e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Asset> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedAsset e where e.Type = '{0}'", type);
		}

		public IList<Asset> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedAsset e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<Asset> SelectByDescription ( string description )
		{
			return SelectByDescription (-1, -1, description );
		}
		
		public long CountByDescription ( string description )
		{
			return ExecuteScalar("select count(*) from SpecializedAsset e where e.Description = '{0}'", description);
		}

		public IList<Asset> SelectByDescription ( int start, int count, string description )
		{
			IList list = Query(start, count, "from SpecializedAsset e where e.Description like '{0}'", description);
			return ToTypedCollection(list);
		}
		
 		public IList<Asset> SelectByCoordinate ( string coordinate )
		{
			return SelectByCoordinate (-1, -1, coordinate );
		}
		
		public long CountByCoordinate ( string coordinate )
		{
			return ExecuteScalar("select count(*) from SpecializedAsset e where e.Coordinate = '{0}'", coordinate);
		}

		public IList<Asset> SelectByCoordinate ( int start, int count, string coordinate )
		{
			IList list = Query(start, count, "from SpecializedAsset e where e.Coordinate like '{0}'", coordinate);
			return ToTypedCollection(list);
		}
		
 		public IList<Asset> SelectByOwner ( PlayerStorage owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return ExecuteScalar("select count(*) from SpecializedAsset e where e.Owner = '{0}'", owner);
		}

		public IList<Asset> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			IList list = Query(start, count, "from SpecializedAsset e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Asset> SelectByTask ( Task task )
		{
			return SelectByTask (-1, -1, task );
		}
		
		public long CountByTask ( Task task )
		{
			return ExecuteScalar("select count(*) from SpecializedAsset e where e.Task = '{0}'", task);
		}

		public IList<Asset> SelectByTask ( int start, int count, Task task )
		{
			IList list = Query(start, count, "from SpecializedAsset e where e.TaskNHibernate.Id = {0}", task.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Asset> SelectByAlliance ( AllianceStorage alliance )
		{
			return SelectByAlliance (-1, -1, alliance );
		}
		
		public long CountByAlliance ( AllianceStorage alliance )
		{
			return ExecuteScalar("select count(*) from SpecializedAsset e where e.Alliance = '{0}'", alliance);
		}

		public IList<Asset> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			IList list = Query(start, count, "from SpecializedAsset e where e.AllianceNHibernate.Id = {0}", alliance.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Asset
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDescription );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCoordinate );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( Asset e ) 
        {
			return ValidateStringMaxSize( "Asset", "Type", e.Type, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfDescription ( Asset e ) 
        {
			return ValidateStringMaxSize( "Asset", "Description", e.Description, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCoordinate ( Asset e ) 
        {
			return ValidateStringMaxSize( "Asset", "Coordinate", e.Coordinate, 100 );
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
