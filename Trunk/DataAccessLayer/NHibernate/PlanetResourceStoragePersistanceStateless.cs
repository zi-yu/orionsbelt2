using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PlanetResourceStoragePersistanceStateless : 
			NHibernatePersistanceStateless<PlanetResourceStorage>, IPlanetResourceStoragePersistance {
	
		#region Static Access
		
		internal static PlanetResourceStoragePersistanceStateless CreateSession()
		{
			return new PlanetResourceStoragePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedPlanetResourceStorage) );
		}
				
		internal static PlanetResourceStoragePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			PlanetResourceStoragePersistanceStateless persistance = new PlanetResourceStoragePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedPlanetResourceStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PlanetResourceStoragePersistanceStateless globalSession = null;
        internal static PlanetResourceStoragePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PlanetResourceStoragePersistanceStateless GetSession()
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
		
		internal static PlanetResourceStoragePersistanceStateless GetValidatedSession()
        {
            PlanetResourceStoragePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PlanetResourceStoragePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PlanetResourceStorage Create()
		{	
			SpecializedPlanetResourceStorage entity = new SpecializedPlanetResourceStorage ();
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
		
 		public IList<PlanetResourceStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.Id = '{0}'", id);
		}

		public IList<PlanetResourceStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectByQuantity ( int quantity )
		{
			return SelectByQuantity (-1, -1, quantity );
		}
		
		public long CountByQuantity ( int quantity )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.Quantity = '{0}'", quantity);
		}

		public IList<PlanetResourceStorage> SelectByQuantity ( int start, int count, int quantity )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.Quantity = {0}", quantity);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectByState ( string state )
		{
			return SelectByState (-1, -1, state );
		}
		
		public long CountByState ( string state )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.State = '{0}'", state);
		}

		public IList<PlanetResourceStorage> SelectByState ( int start, int count, string state )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.State like '{0}'", state);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectByLevel ( int level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( int level )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.Level = '{0}'", level);
		}

		public IList<PlanetResourceStorage> SelectByLevel ( int start, int count, int level )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.Level = {0}", level);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.Type = '{0}'", type);
		}

		public IList<PlanetResourceStorage> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectByQueueOrder ( int queueOrder )
		{
			return SelectByQueueOrder (-1, -1, queueOrder );
		}
		
		public long CountByQueueOrder ( int queueOrder )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.QueueOrder = '{0}'", queueOrder);
		}

		public IList<PlanetResourceStorage> SelectByQueueOrder ( int start, int count, int queueOrder )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.QueueOrder = {0}", queueOrder);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectBySlot ( string slot )
		{
			return SelectBySlot (-1, -1, slot );
		}
		
		public long CountBySlot ( string slot )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.Slot = '{0}'", slot);
		}

		public IList<PlanetResourceStorage> SelectBySlot ( int start, int count, string slot )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.Slot like '{0}'", slot);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectByEndTick ( int endTick )
		{
			return SelectByEndTick (-1, -1, endTick );
		}
		
		public long CountByEndTick ( int endTick )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.EndTick = '{0}'", endTick);
		}

		public IList<PlanetResourceStorage> SelectByEndTick ( int start, int count, int endTick )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.EndTick = {0}", endTick);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectByPlanet ( PlanetStorage planet )
		{
			return SelectByPlanet (-1, -1, planet );
		}
		
		public long CountByPlanet ( PlanetStorage planet )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.Planet = '{0}'", planet);
		}

		public IList<PlanetResourceStorage> SelectByPlanet ( int start, int count, PlanetStorage planet )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.PlanetNHibernate.Id = {0}", planet.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlanetResourceStorage> SelectByPlayer ( PlayerStorage player )
		{
			return SelectByPlayer (-1, -1, player );
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return ExecuteScalar("select count(*) from SpecializedPlanetResourceStorage e where e.Player = '{0}'", player);
		}

		public IList<PlanetResourceStorage> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			IList list = Query(start, count, "from SpecializedPlanetResourceStorage e where e.PlayerNHibernate.Id = {0}", player.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : PlanetResourceStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfState );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfSlot );
        }
		public static LifecyleVeto ValidateMaxSizeOfState ( PlanetResourceStorage e ) 
        {
			return ValidateStringMaxSize( "PlanetResourceStorage", "State", e.State, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfType ( PlanetResourceStorage e ) 
        {
			return ValidateStringMaxSize( "PlanetResourceStorage", "Type", e.Type, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfSlot ( PlanetResourceStorage e ) 
        {
			return ValidateStringMaxSize( "PlanetResourceStorage", "Slot", e.Slot, 100 );
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
