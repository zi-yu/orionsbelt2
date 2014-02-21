using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class TimedActionStoragePersistanceStateless : 
			NHibernatePersistanceStateless<TimedActionStorage>, ITimedActionStoragePersistance {
	
		#region Static Access
		
		internal static TimedActionStoragePersistanceStateless CreateSession()
		{
			return new TimedActionStoragePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedTimedActionStorage) );
		}
				
		internal static TimedActionStoragePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			TimedActionStoragePersistanceStateless persistance = new TimedActionStoragePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedTimedActionStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static TimedActionStoragePersistanceStateless globalSession = null;
        internal static TimedActionStoragePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static TimedActionStoragePersistanceStateless GetSession()
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
		
		internal static TimedActionStoragePersistanceStateless GetValidatedSession()
        {
            TimedActionStoragePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private TimedActionStoragePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override TimedActionStorage Create()
		{	
			SpecializedTimedActionStorage entity = new SpecializedTimedActionStorage ();
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
		
 		public IList<TimedActionStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedTimedActionStorage e where e.Id = '{0}'", id);
		}

		public IList<TimedActionStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedTimedActionStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<TimedActionStorage> SelectByStartTick ( int startTick )
		{
			return SelectByStartTick (-1, -1, startTick );
		}
		
		public long CountByStartTick ( int startTick )
		{
			return ExecuteScalar("select count(*) from SpecializedTimedActionStorage e where e.StartTick = '{0}'", startTick);
		}

		public IList<TimedActionStorage> SelectByStartTick ( int start, int count, int startTick )
		{
			IList list = Query(start, count, "from SpecializedTimedActionStorage e where e.StartTick = {0}", startTick);
			return ToTypedCollection(list);
		}
		
 		public IList<TimedActionStorage> SelectByEndTick ( int endTick )
		{
			return SelectByEndTick (-1, -1, endTick );
		}
		
		public long CountByEndTick ( int endTick )
		{
			return ExecuteScalar("select count(*) from SpecializedTimedActionStorage e where e.EndTick = '{0}'", endTick);
		}

		public IList<TimedActionStorage> SelectByEndTick ( int start, int count, int endTick )
		{
			IList list = Query(start, count, "from SpecializedTimedActionStorage e where e.EndTick = {0}", endTick);
			return ToTypedCollection(list);
		}
		
 		public IList<TimedActionStorage> SelectByData ( string data )
		{
			return SelectByData (-1, -1, data );
		}
		
		public long CountByData ( string data )
		{
			return ExecuteScalar("select count(*) from SpecializedTimedActionStorage e where e.Data = '{0}'", data);
		}

		public IList<TimedActionStorage> SelectByData ( int start, int count, string data )
		{
			IList list = Query(start, count, "from SpecializedTimedActionStorage e where e.Data like '{0}'", data);
			return ToTypedCollection(list);
		}
		
 		public IList<TimedActionStorage> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedTimedActionStorage e where e.Name = '{0}'", name);
		}

		public IList<TimedActionStorage> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedTimedActionStorage e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<TimedActionStorage> SelectByPlayer ( PlayerStorage player )
		{
			return SelectByPlayer (-1, -1, player );
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return ExecuteScalar("select count(*) from SpecializedTimedActionStorage e where e.Player = '{0}'", player);
		}

		public IList<TimedActionStorage> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			IList list = Query(start, count, "from SpecializedTimedActionStorage e where e.PlayerNHibernate.Id = {0}", player.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<TimedActionStorage> SelectByBattle ( Battle battle )
		{
			return SelectByBattle (-1, -1, battle );
		}
		
		public long CountByBattle ( Battle battle )
		{
			return ExecuteScalar("select count(*) from SpecializedTimedActionStorage e where e.Battle = '{0}'", battle);
		}

		public IList<TimedActionStorage> SelectByBattle ( int start, int count, Battle battle )
		{
			IList list = Query(start, count, "from SpecializedTimedActionStorage e where e.BattleNHibernate.Id = {0}", battle.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : TimedActionStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfData );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
        }
		public static LifecyleVeto ValidateMaxSizeOfData ( TimedActionStorage e ) 
        {
			return ValidateStringMaxSize( "TimedActionStorage", "Data", e.Data, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfName ( TimedActionStorage e ) 
        {
			return ValidateStringMaxSize( "TimedActionStorage", "Name", e.Name, 100 );
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
