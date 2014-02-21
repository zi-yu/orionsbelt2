using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class SectorStoragePersistance : 
			NHibernatePersistance<SectorStorage>, ISectorStoragePersistance {
	
		#region Static Access
		
		internal static SectorStoragePersistance CreateSession()
		{
			return new SectorStoragePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedSectorStorage) );
		}
				
		internal static SectorStoragePersistance AttachSession( IPersistanceSession owner )
		{
			SectorStoragePersistance persistance = new SectorStoragePersistance ( owner.Session as ISession, typeof(SpecializedSectorStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static SectorStoragePersistance globalSession = null;
        internal static SectorStoragePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static SectorStoragePersistance GetSession()
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
		
		internal static SectorStoragePersistance GetValidatedSession()
        {
            SectorStoragePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private SectorStoragePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override SectorStorage Create()
		{	
			SpecializedSectorStorage entity = new SpecializedSectorStorage ();
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
		
 		public IList<SectorStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.Id = '{0}'", id);
		}

		public IList<SectorStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByIsStatic ( bool isStatic )
		{
			return SelectByIsStatic (-1, -1, isStatic );
		}
		
		public long CountByIsStatic ( bool isStatic )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.IsStatic = '{0}'", isStatic);
		}

		public IList<SectorStorage> SelectByIsStatic ( int start, int count, bool isStatic )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.IsStatic = {0}", isStatic);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.Type = '{0}'", type);
		}

		public IList<SectorStorage> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectBySubType ( string subType )
		{
			return SelectBySubType (-1, -1, subType );
		}
		
		public long CountBySubType ( string subType )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.SubType = '{0}'", subType);
		}

		public IList<SectorStorage> SelectBySubType ( int start, int count, string subType )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.SubType like '{0}'", subType);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectBySystemX ( int systemX )
		{
			return SelectBySystemX (-1, -1, systemX );
		}
		
		public long CountBySystemX ( int systemX )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.SystemX = '{0}'", systemX);
		}

		public IList<SectorStorage> SelectBySystemX ( int start, int count, int systemX )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.SystemX = {0}", systemX);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectBySystemY ( int systemY )
		{
			return SelectBySystemY (-1, -1, systemY );
		}
		
		public long CountBySystemY ( int systemY )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.SystemY = '{0}'", systemY);
		}

		public IList<SectorStorage> SelectBySystemY ( int start, int count, int systemY )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.SystemY = {0}", systemY);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectBySectorX ( int sectorX )
		{
			return SelectBySectorX (-1, -1, sectorX );
		}
		
		public long CountBySectorX ( int sectorX )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.SectorX = '{0}'", sectorX);
		}

		public IList<SectorStorage> SelectBySectorX ( int start, int count, int sectorX )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.SectorX = {0}", sectorX);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectBySectorY ( int sectorY )
		{
			return SelectBySectorY (-1, -1, sectorY );
		}
		
		public long CountBySectorY ( int sectorY )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.SectorY = '{0}'", sectorY);
		}

		public IList<SectorStorage> SelectBySectorY ( int start, int count, int sectorY )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.SectorY = {0}", sectorY);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByAdditionalInformation ( string additionalInformation )
		{
			return SelectByAdditionalInformation (-1, -1, additionalInformation );
		}
		
		public long CountByAdditionalInformation ( string additionalInformation )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.AdditionalInformation = '{0}'", additionalInformation);
		}

		public IList<SectorStorage> SelectByAdditionalInformation ( int start, int count, string additionalInformation )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.AdditionalInformation like '{0}'", additionalInformation);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByIsInBattle ( bool isInBattle )
		{
			return SelectByIsInBattle (-1, -1, isInBattle );
		}
		
		public long CountByIsInBattle ( bool isInBattle )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.IsInBattle = '{0}'", isInBattle);
		}

		public IList<SectorStorage> SelectByIsInBattle ( int start, int count, bool isInBattle )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.IsInBattle = {0}", isInBattle);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByIsConstructing ( bool isConstructing )
		{
			return SelectByIsConstructing (-1, -1, isConstructing );
		}
		
		public long CountByIsConstructing ( bool isConstructing )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.IsConstructing = '{0}'", isConstructing);
		}

		public IList<SectorStorage> SelectByIsConstructing ( int start, int count, bool isConstructing )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.IsConstructing = {0}", isConstructing);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByLevel ( int level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( int level )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.Level = '{0}'", level);
		}

		public IList<SectorStorage> SelectByLevel ( int start, int count, int level )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.Level = {0}", level);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByIsMoving ( bool isMoving )
		{
			return SelectByIsMoving (-1, -1, isMoving );
		}
		
		public long CountByIsMoving ( bool isMoving )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.IsMoving = '{0}'", isMoving);
		}

		public IList<SectorStorage> SelectByIsMoving ( int start, int count, bool isMoving )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.IsMoving = {0}", isMoving);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByOwner ( PlayerStorage owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.Owner = '{0}'", owner);
		}

		public IList<SectorStorage> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<SectorStorage> SelectByAlliance ( AllianceStorage alliance )
		{
			return SelectByAlliance (-1, -1, alliance );
		}
		
		public long CountByAlliance ( AllianceStorage alliance )
		{
			return ExecuteScalar("select count(*) from SpecializedSectorStorage e where e.Alliance = '{0}'", alliance);
		}

		public IList<SectorStorage> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			IList list = Query(start, count, "from SpecializedSectorStorage e where e.AllianceNHibernate.Id = {0}", alliance.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : SectorStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfSubType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfAdditionalInformation );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( SectorStorage e ) 
        {
			return ValidateStringMaxSize( "SectorStorage", "Type", e.Type, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfSubType ( SectorStorage e ) 
        {
			return ValidateStringMaxSize( "SectorStorage", "SubType", e.SubType, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfAdditionalInformation ( SectorStorage e ) 
        {
			return ValidateStringMaxSize( "SectorStorage", "AdditionalInformation", e.AdditionalInformation, 1000 );
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
