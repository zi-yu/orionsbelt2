using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class TaskPersistance : 
			NHibernatePersistance<Task>, ITaskPersistance {
	
		#region Static Access
		
		internal static TaskPersistance CreateSession()
		{
			return new TaskPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedTask) );
		}
				
		internal static TaskPersistance AttachSession( IPersistanceSession owner )
		{
			TaskPersistance persistance = new TaskPersistance ( owner.Session as ISession, typeof(SpecializedTask) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static TaskPersistance globalSession = null;
        internal static TaskPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static TaskPersistance GetSession()
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
		
		internal static TaskPersistance GetValidatedSession()
        {
            TaskPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private TaskPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Task Create()
		{	
			SpecializedTask entity = new SpecializedTask ();
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
		
 		public IList<Task> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedTask e where e.Id = '{0}'", id);
		}

		public IList<Task> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedTask e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Task> SelectByStatus ( string status )
		{
			return SelectByStatus (-1, -1, status );
		}
		
		public long CountByStatus ( string status )
		{
			return ExecuteScalar("select count(*) from SpecializedTask e where e.Status = '{0}'", status);
		}

		public IList<Task> SelectByStatus ( int start, int count, string status )
		{
			IList list = Query(start, count, "from SpecializedTask e where e.Status like '{0}'", status);
			return ToTypedCollection(list);
		}
		
 		public IList<Task> SelectByPriority ( string priority )
		{
			return SelectByPriority (-1, -1, priority );
		}
		
		public long CountByPriority ( string priority )
		{
			return ExecuteScalar("select count(*) from SpecializedTask e where e.Priority = '{0}'", priority);
		}

		public IList<Task> SelectByPriority ( int start, int count, string priority )
		{
			IList list = Query(start, count, "from SpecializedTask e where e.Priority like '{0}'", priority);
			return ToTypedCollection(list);
		}
		
 		public IList<Task> SelectByTitle ( string title )
		{
			return SelectByTitle (-1, -1, title );
		}
		
		public long CountByTitle ( string title )
		{
			return ExecuteScalar("select count(*) from SpecializedTask e where e.Title = '{0}'", title);
		}

		public IList<Task> SelectByTitle ( int start, int count, string title )
		{
			IList list = Query(start, count, "from SpecializedTask e where e.Title like '{0}'", title);
			return ToTypedCollection(list);
		}
		
 		public IList<Task> SelectByNecessity ( Necessity necessity )
		{
			return SelectByNecessity (-1, -1, necessity );
		}
		
		public long CountByNecessity ( Necessity necessity )
		{
			return ExecuteScalar("select count(*) from SpecializedTask e where e.Necessity = '{0}'", necessity);
		}

		public IList<Task> SelectByNecessity ( int start, int count, Necessity necessity )
		{
			IList list = Query(start, count, "from SpecializedTask e where e.NecessityNHibernate.Id = {0}", necessity.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Task
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfStatus );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfPriority );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTitle );
        }
		public static LifecyleVeto ValidateMaxSizeOfStatus ( Task e ) 
        {
			return ValidateStringMaxSize( "Task", "Status", e.Status, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfPriority ( Task e ) 
        {
			return ValidateStringMaxSize( "Task", "Priority", e.Priority, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTitle ( Task e ) 
        {
			return ValidateStringMaxSize( "Task", "Title", e.Title, 100 );
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
