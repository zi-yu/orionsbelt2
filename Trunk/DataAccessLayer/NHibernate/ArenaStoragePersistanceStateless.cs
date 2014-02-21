using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ArenaStoragePersistanceStateless : 
			NHibernatePersistanceStateless<ArenaStorage>, IArenaStoragePersistance {
	
		#region Static Access
		
		internal static ArenaStoragePersistanceStateless CreateSession()
		{
			return new ArenaStoragePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedArenaStorage) );
		}
				
		internal static ArenaStoragePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			ArenaStoragePersistanceStateless persistance = new ArenaStoragePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedArenaStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ArenaStoragePersistanceStateless globalSession = null;
        internal static ArenaStoragePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ArenaStoragePersistanceStateless GetSession()
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
		
		internal static ArenaStoragePersistanceStateless GetValidatedSession()
        {
            ArenaStoragePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ArenaStoragePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ArenaStorage Create()
		{	
			SpecializedArenaStorage entity = new SpecializedArenaStorage ();
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
		
 		public IList<ArenaStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.Id = '{0}'", id);
		}

		public IList<ArenaStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.Name = '{0}'", name);
		}

		public IList<ArenaStorage> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByIsInBattle ( int isInBattle )
		{
			return SelectByIsInBattle (-1, -1, isInBattle );
		}
		
		public long CountByIsInBattle ( int isInBattle )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.IsInBattle = '{0}'", isInBattle);
		}

		public IList<ArenaStorage> SelectByIsInBattle ( int start, int count, int isInBattle )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.IsInBattle = {0}", isInBattle);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByConquestTick ( int conquestTick )
		{
			return SelectByConquestTick (-1, -1, conquestTick );
		}
		
		public long CountByConquestTick ( int conquestTick )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.ConquestTick = '{0}'", conquestTick);
		}

		public IList<ArenaStorage> SelectByConquestTick ( int start, int count, int conquestTick )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.ConquestTick = {0}", conquestTick);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByBattleType ( string battleType )
		{
			return SelectByBattleType (-1, -1, battleType );
		}
		
		public long CountByBattleType ( string battleType )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.BattleType = '{0}'", battleType);
		}

		public IList<ArenaStorage> SelectByBattleType ( int start, int count, string battleType )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.BattleType like '{0}'", battleType);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByCoordinate ( string coordinate )
		{
			return SelectByCoordinate (-1, -1, coordinate );
		}
		
		public long CountByCoordinate ( string coordinate )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.Coordinate = '{0}'", coordinate);
		}

		public IList<ArenaStorage> SelectByCoordinate ( int start, int count, string coordinate )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.Coordinate like '{0}'", coordinate);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByPayment ( int payment )
		{
			return SelectByPayment (-1, -1, payment );
		}
		
		public long CountByPayment ( int payment )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.Payment = '{0}'", payment);
		}

		public IList<ArenaStorage> SelectByPayment ( int start, int count, int payment )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.Payment = {0}", payment);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByLevel ( int level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( int level )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.Level = '{0}'", level);
		}

		public IList<ArenaStorage> SelectByLevel ( int start, int count, int level )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.Level = {0}", level);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByFleet ( Fleet fleet )
		{
			return SelectByFleet (-1, -1, fleet );
		}
		
		public long CountByFleet ( Fleet fleet )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.Fleet = '{0}'", fleet);
		}

		public IList<ArenaStorage> SelectByFleet ( int start, int count, Fleet fleet )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.FleetNHibernate.Id = {0}", fleet.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectByOwner ( PlayerStorage owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.Owner = '{0}'", owner);
		}

		public IList<ArenaStorage> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<ArenaStorage> SelectBySector ( SectorStorage sector )
		{
			return SelectBySector (-1, -1, sector );
		}
		
		public long CountBySector ( SectorStorage sector )
		{
			return ExecuteScalar("select count(*) from SpecializedArenaStorage e where e.Sector = '{0}'", sector);
		}

		public IList<ArenaStorage> SelectBySector ( int start, int count, SectorStorage sector )
		{
			IList list = Query(start, count, "from SpecializedArenaStorage e where e.SectorNHibernate.Id = {0}", sector.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : ArenaStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBattleType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCoordinate );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( ArenaStorage e ) 
        {
			return ValidateStringMaxSize( "ArenaStorage", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfBattleType ( ArenaStorage e ) 
        {
			return ValidateStringMaxSize( "ArenaStorage", "BattleType", e.BattleType, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCoordinate ( ArenaStorage e ) 
        {
			return ValidateStringMaxSize( "ArenaStorage", "Coordinate", e.Coordinate, 100 );
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
