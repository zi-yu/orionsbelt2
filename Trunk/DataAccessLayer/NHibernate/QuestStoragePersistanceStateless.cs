using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class QuestStoragePersistanceStateless : 
			NHibernatePersistanceStateless<QuestStorage>, IQuestStoragePersistance {
	
		#region Static Access
		
		internal static QuestStoragePersistanceStateless CreateSession()
		{
			return new QuestStoragePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedQuestStorage) );
		}
				
		internal static QuestStoragePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			QuestStoragePersistanceStateless persistance = new QuestStoragePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedQuestStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static QuestStoragePersistanceStateless globalSession = null;
        internal static QuestStoragePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static QuestStoragePersistanceStateless GetSession()
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
		
		internal static QuestStoragePersistanceStateless GetValidatedSession()
        {
            QuestStoragePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private QuestStoragePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override QuestStorage Create()
		{	
			SpecializedQuestStorage entity = new SpecializedQuestStorage ();
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
		
 		public IList<QuestStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.Id = '{0}'", id);
		}

		public IList<QuestStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByPercentage ( double percentage )
		{
			return SelectByPercentage (-1, -1, percentage );
		}
		
		public long CountByPercentage ( double percentage )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.Percentage = '{0}'", percentage);
		}

		public IList<QuestStorage> SelectByPercentage ( int start, int count, double percentage )
		{
			throw new NotImplementedException();
		}
		
 		public IList<QuestStorage> SelectByIsTemplate ( bool isTemplate )
		{
			return SelectByIsTemplate (-1, -1, isTemplate );
		}
		
		public long CountByIsTemplate ( bool isTemplate )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.IsTemplate = '{0}'", isTemplate);
		}

		public IList<QuestStorage> SelectByIsTemplate ( int start, int count, bool isTemplate )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.IsTemplate = {0}", isTemplate);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.Name = '{0}'", name);
		}

		public IList<QuestStorage> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.Type = '{0}'", type);
		}

		public IList<QuestStorage> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByDeadlineTick ( int deadlineTick )
		{
			return SelectByDeadlineTick (-1, -1, deadlineTick );
		}
		
		public long CountByDeadlineTick ( int deadlineTick )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.DeadlineTick = '{0}'", deadlineTick);
		}

		public IList<QuestStorage> SelectByDeadlineTick ( int start, int count, int deadlineTick )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.DeadlineTick = {0}", deadlineTick);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByStartTick ( int startTick )
		{
			return SelectByStartTick (-1, -1, startTick );
		}
		
		public long CountByStartTick ( int startTick )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.StartTick = '{0}'", startTick);
		}

		public IList<QuestStorage> SelectByStartTick ( int start, int count, int startTick )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.StartTick = {0}", startTick);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByReward ( string reward )
		{
			return SelectByReward (-1, -1, reward );
		}
		
		public long CountByReward ( string reward )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.Reward = '{0}'", reward);
		}

		public IList<QuestStorage> SelectByReward ( int start, int count, string reward )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.Reward like '{0}'", reward);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByQuestStringConfig ( string questStringConfig )
		{
			return SelectByQuestStringConfig (-1, -1, questStringConfig );
		}
		
		public long CountByQuestStringConfig ( string questStringConfig )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.QuestStringConfig = '{0}'", questStringConfig);
		}

		public IList<QuestStorage> SelectByQuestStringConfig ( int start, int count, string questStringConfig )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.QuestStringConfig like '{0}'", questStringConfig);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByQuestIntConfig ( string questIntConfig )
		{
			return SelectByQuestIntConfig (-1, -1, questIntConfig );
		}
		
		public long CountByQuestIntConfig ( string questIntConfig )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.QuestIntConfig = '{0}'", questIntConfig);
		}

		public IList<QuestStorage> SelectByQuestIntConfig ( int start, int count, string questIntConfig )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.QuestIntConfig like '{0}'", questIntConfig);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByQuestIntProgress ( string questIntProgress )
		{
			return SelectByQuestIntProgress (-1, -1, questIntProgress );
		}
		
		public long CountByQuestIntProgress ( string questIntProgress )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.QuestIntProgress = '{0}'", questIntProgress);
		}

		public IList<QuestStorage> SelectByQuestIntProgress ( int start, int count, string questIntProgress )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.QuestIntProgress like '{0}'", questIntProgress);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByQuestStringProgress ( string questStringProgress )
		{
			return SelectByQuestStringProgress (-1, -1, questStringProgress );
		}
		
		public long CountByQuestStringProgress ( string questStringProgress )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.QuestStringProgress = '{0}'", questStringProgress);
		}

		public IList<QuestStorage> SelectByQuestStringProgress ( int start, int count, string questStringProgress )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.QuestStringProgress like '{0}'", questStringProgress);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByCompleted ( bool completed )
		{
			return SelectByCompleted (-1, -1, completed );
		}
		
		public long CountByCompleted ( bool completed )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.Completed = '{0}'", completed);
		}

		public IList<QuestStorage> SelectByCompleted ( int start, int count, bool completed )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.Completed = {0}", completed);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByIsProgressive ( bool isProgressive )
		{
			return SelectByIsProgressive (-1, -1, isProgressive );
		}
		
		public long CountByIsProgressive ( bool isProgressive )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.IsProgressive = '{0}'", isProgressive);
		}

		public IList<QuestStorage> SelectByIsProgressive ( int start, int count, bool isProgressive )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.IsProgressive = {0}", isProgressive);
			return ToTypedCollection(list);
		}
		
 		public IList<QuestStorage> SelectByPlayer ( PlayerStorage player )
		{
			return SelectByPlayer (-1, -1, player );
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return ExecuteScalar("select count(*) from SpecializedQuestStorage e where e.Player = '{0}'", player);
		}

		public IList<QuestStorage> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			IList list = Query(start, count, "from SpecializedQuestStorage e where e.PlayerNHibernate.Id = {0}", player.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : QuestStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfReward );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfQuestStringConfig );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfQuestIntConfig );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfQuestIntProgress );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfQuestStringProgress );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( QuestStorage e ) 
        {
			return ValidateStringMaxSize( "QuestStorage", "Name", e.Name, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfType ( QuestStorage e ) 
        {
			return ValidateStringMaxSize( "QuestStorage", "Type", e.Type, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfReward ( QuestStorage e ) 
        {
			return ValidateStringMaxSize( "QuestStorage", "Reward", e.Reward, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfQuestStringConfig ( QuestStorage e ) 
        {
			return ValidateStringMaxSize( "QuestStorage", "QuestStringConfig", e.QuestStringConfig, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfQuestIntConfig ( QuestStorage e ) 
        {
			return ValidateStringMaxSize( "QuestStorage", "QuestIntConfig", e.QuestIntConfig, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfQuestIntProgress ( QuestStorage e ) 
        {
			return ValidateStringMaxSize( "QuestStorage", "QuestIntProgress", e.QuestIntProgress, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfQuestStringProgress ( QuestStorage e ) 
        {
			return ValidateStringMaxSize( "QuestStorage", "QuestStringProgress", e.QuestStringProgress, 100 );
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
