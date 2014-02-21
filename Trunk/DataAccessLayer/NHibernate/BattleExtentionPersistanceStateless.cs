using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class BattleExtentionPersistanceStateless : 
			NHibernatePersistanceStateless<BattleExtention>, IBattleExtentionPersistance {
	
		#region Static Access
		
		internal static BattleExtentionPersistanceStateless CreateSession()
		{
			return new BattleExtentionPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedBattleExtention) );
		}
				
		internal static BattleExtentionPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			BattleExtentionPersistanceStateless persistance = new BattleExtentionPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedBattleExtention) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static BattleExtentionPersistanceStateless globalSession = null;
        internal static BattleExtentionPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static BattleExtentionPersistanceStateless GetSession()
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
		
		internal static BattleExtentionPersistanceStateless GetValidatedSession()
        {
            BattleExtentionPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private BattleExtentionPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override BattleExtention Create()
		{	
			SpecializedBattleExtention entity = new SpecializedBattleExtention ();
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
		
 		public IList<BattleExtention> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleExtention e where e.Id = '{0}'", id);
		}

		public IList<BattleExtention> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedBattleExtention e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleExtention> SelectByBattleFinalStates ( string battleFinalStates )
		{
			return SelectByBattleFinalStates (-1, -1, battleFinalStates );
		}
		
		public long CountByBattleFinalStates ( string battleFinalStates )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleExtention e where e.BattleFinalStates = '{0}'", battleFinalStates);
		}

		public IList<BattleExtention> SelectByBattleFinalStates ( int start, int count, string battleFinalStates )
		{
			IList list = Query(start, count, "from SpecializedBattleExtention e where e.BattleFinalStates like '{0}'", battleFinalStates);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleExtention> SelectByBattleMovements ( string battleMovements )
		{
			return SelectByBattleMovements (-1, -1, battleMovements );
		}
		
		public long CountByBattleMovements ( string battleMovements )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleExtention e where e.BattleMovements = '{0}'", battleMovements);
		}

		public IList<BattleExtention> SelectByBattleMovements ( int start, int count, string battleMovements )
		{
			IList list = Query(start, count, "from SpecializedBattleExtention e where e.BattleMovements like '{0}'", battleMovements);
			return ToTypedCollection(list);
		}
		
 		public IList<BattleExtention> SelectByBattle ( Battle battle )
		{
			return SelectByBattle (-1, -1, battle );
		}
		
		public long CountByBattle ( Battle battle )
		{
			return ExecuteScalar("select count(*) from SpecializedBattleExtention e where e.Battle = '{0}'", battle);
		}

		public IList<BattleExtention> SelectByBattle ( int start, int count, Battle battle )
		{
			IList list = Query(start, count, "from SpecializedBattleExtention e where e.BattleNHibernate.Id = {0}", battle.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : BattleExtention
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBattleFinalStates );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBattleMovements );
        }
		public static LifecyleVeto ValidateMaxSizeOfBattleFinalStates ( BattleExtention e ) 
        {
			return ValidateStringMaxSize( "BattleExtention", "BattleFinalStates", e.BattleFinalStates, 6000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfBattleMovements ( BattleExtention e ) 
        {
			return ValidateStringMaxSize( "BattleExtention", "BattleMovements", e.BattleMovements, 64000 );
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
