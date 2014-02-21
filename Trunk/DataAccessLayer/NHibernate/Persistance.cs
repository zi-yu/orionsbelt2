using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Loki.Exceptions;
using Loki.Interfaces;
using Loki.Generic;
using OrionsBelt.Core;
using LifecycleVeto = Loki.DataRepresentation.LifecyleVeto;

namespace OrionsBelt.DataAccessLayer {

	public class NHibernatePersistance<T> :
			IPersistance<T>, 
			ILifecycle<T>,
			IDisposable 
			where T : IEntity {
		
		#region Ctor and Fields
		
		private ISession session = null;
		private ITransaction transaction = null;
		private IPersistanceSession attached = null;
		private Type persistanceType = null;
		private bool shouldThrowOnFlush = false;
		
		/// <summary>
        /// Constructor to use by derived classes
        /// </summary>
        /// <param name="currSession">The current NHibernate session</param>
        /// <param name="type">The current type</param>
		protected NHibernatePersistance ( ISession currSession, Type type ) 
		{
			NHibernateSession = currSession;
			PersistanceType = type;
		}
		
		/// <summary>
        /// Access to the Generic session
        /// </summary>
		public object Session {
			get { return session; }
		}
		
		/// <summary>
        /// Access to the NHibernateSession session
        /// </summary>
		internal ISession NHibernateSession {
			get { 
				if (session == null || !NHibernateUtilities.IsSessionOpen(session)) {
                    session = NHibernateUtilities.OpenSession;
                }
				return session; 
			}
			set { session = value; }
		}
		
		/// <summary>
        /// Access to the current NHibernate transaction
        /// </summary>
		internal ITransaction Transaction {
			get { return transaction; }
			private set { transaction = value; }
		}
		
		/// <summary>
        /// Weather this persistance session is attached to another
        /// </summary>
        /// <remarks>
        /// If attached then when you close this Persistance instance, the NHibernate
        /// session will remain open. It's the parent Persistance instance (the one you attached to)
        /// that has the responsability to close the NHibernate session
        /// </remarks>
		internal IPersistanceSession Attached {
			get { return attached; }
			set { attached = value; }
		}
		
		/// <summary>
        /// True to throw on flush
        /// </summary>
		public bool ShouldThrowOnFlush {
			get {
				if( shouldThrowOnFlush ) {
					return true;
				}
				return Attached != null && Attached.ShouldThrowOnFlush;
			}
			set { shouldThrowOnFlush = value; }
		}
		
		/// <summary>
        /// The Type to persist
        /// </summary>
		public Type PersistanceType {
			get { return persistanceType; }
			set { persistanceType = value; }
		}
		
		#endregion Ctor and Fields
		
		#region IDisposable Implementation
		
		/// <summary>
        ///  Closes the NHibernate session
        /// </summary>
		public void Dispose()
		{
			if( Attached == null && !NHibernateUtilities.UseMasterSession ) {
				Close();
			}
		}

        /// <summary>
        /// Closes the session
        /// </summary>
        public void Close()
        {
            NHibernateSession.Dispose();
        }
		
		#endregion
	
		#region IPersistance
			
		/// <summary>
        /// Creates an instance of the type T
        /// </summary>
        /// <returns>The created instance</returns>
		public virtual T Create()
		{
			throw new DALException(" Cannot create an instance of the abstract class '"+PersistanceType.Name+"'");
		}
		
		/// <summary>
        /// Prepares the entity for a scenario where its session may be closed and
        /// it needs a new one
        /// </summary>
        /// <param name="entity">The target entity</param>
        public void PrepareLaziness(IEntity entity)
        {
			NHibernateUtilities.CheckSession(entity, NHibernateSession);
        }
        
        /// <summary>
        /// Clears the session cache
        /// </summary>
        public void Clear()
        {
			Flush();
			NHibernateSession.Clear();
        }
        
        /// <summary>
        /// Closes the current session and creates a new one
        /// </summary>
        public void Reset()
        {
			RollbackTransaction();
			NHibernateSession.Close();
			NHibernateSession = NHibernateUtilities.OpenSession;
        }
		
		/// <summary>
        /// Selects the element with the given Id
        /// </summary>
        /// <param name="id">The target's id</param>
        /// <returns>The associated object</returns>
		public T Select( int id )
		{
			StatsInterceptor.Instance.RegisterQuery(string.Format("select * from {0}", PersistanceType.FullName));
			return (T) NHibernateSession.Load(PersistanceType, id);
		}
		
		/// <summary>
        /// Selects all elements
        /// </summary>
        /// <returns>The list with all elements</returns>
		public IList<T> Select()
		{
			return Select(-1, -1, "Id", true);
		}
		
		/// <summary>
        /// Selects all elements with a given order
        /// </summary>
        /// <param name="orderByProperty">Field to order by</param>
        /// <param name="ascending">Order direction</param>
        /// <returns>The list with all elements</returns>
		public IList<T> Select( string orderByProperty, bool ascending )
		{
			return Select(-1, -1, orderByProperty, ascending);
		}
		
		/// <summary>
        /// Selects all elements with a given order
        /// </summary>
        /// <param name="orderByProperties">Fields to order by</param>
        /// <param name="ascending">Order directions</param>
        /// <returns>The list with all elements</returns>
		public IList<T> Select( string[] orderByProperties, bool[] ascending )
		{
			return Select( -1, -1, orderByProperties, ascending);
		}
		
		/// <summary>
        /// Selects a subset of all the elements
        /// </summary>
        /// <param name="start">The first element index</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The list with the elements</returns>
		public IList<T> Select( int start, int count )
		{
			return Select(start, count, "Id", true);
		}

		/// <summary>
        /// Selects a subset of all the elements ordered by the given fields
        /// </summary>
        /// <param name="start">The first element index</param>
        /// <param name="count">The number of elements</param>
        /// <param name="orderByProperty">Field to order by</param>
        /// <param name="ascending">Order direction</param>
        /// <returns>The list with the elements</returns>
		public IList<T> Select(int start, int count, string orderByProperty, bool ascending)
		{
			return Select(start, count, new string[] {orderByProperty}, new bool[]{ascending});
		}
		
		/// <summary>
        /// Selects a subset of all the elements ordered by the given fields
        /// </summary>
        /// <param name="start">The first element index</param>
        /// <param name="count">The number of elements</param>
        /// <param name="orderByProperties">Fields to order by</param>
        /// <param name="ascending">Order directions</param>
        /// <returns>The list with the elements</returns>
		public IList<T> Select( int start, int count, string[] orderByProperties, bool[] ascending )
		{
            StatsInterceptor.Instance.RegisterQuery(string.Format("select * from {0} with some parameter", PersistanceType.FullName));

			if( ascending == null ) {
				ascending = GetBoolArray(orderByProperties.Length);
			}
			ICriteria criteria = NHibernateSession.CreateCriteria(PersistanceType);
			
			for( int i = 0; i < orderByProperties.Length; ++i ) {
				string propery = orderByProperties[i];
				bool asc = ascending[i];
				criteria.AddOrder( CreateOrderExpression(propery, asc) );
			}
			
			if( start >= 0 ) {
				criteria.SetFirstResult(start);
			}
			if( count > 0 ) {
				criteria.SetMaxResults(count);
			}

			return ToTypedCollection( criteria.List() );
		}
		
		/// <summary>
        /// Gets the number of instanced persisted
        /// </summary>
        /// <returns>The instance count</returns>
		public long GetCount()
		{
			return GetStaticCount( PersistanceType.Name );
		}
		
		/// <summary>
        /// Gets a random element
        /// </summary>
        /// <returns>An element</returns>
		public T GetRandom()
		{
			int count = (int)GetCount();
			Random rnd = new Random();
			int lucky = rnd.Next(count);
			
			return Select(lucky, 1)[0];
		}
		
		/// <summary>
        /// Adds logic validation to the entities
        /// </summary>
        public virtual void AddValidators()
        {
        }
		
		/// <summary>
        /// Performs a HQL query
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <returns>The list</returns>
		public IList Query( string hql )
		{
            return Query(-1, -1, hql, new object[0]);
		}
		
		/// <summary>
        /// Performs a HQL query
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <param name="args">Arguments to format the HQL</param>
        /// <returns>The list</returns>
		public IList Query( string hql, params object[] args )
		{
            return Query(-1, -1, hql, args);
		}

		/// <summary>
        /// Performs a HQL query
        /// </summary>
        /// <param name="start">The first index</param>
        /// <param name="count">The number of elements to return</param>
        /// <param name="hql">The HQL</param>
        /// <param name="args">Parameters to format the HQL</param>
        /// <returns>The list</returns>
        public IList Query( int start, int count, string hql, params object[] args )
        {
            StatsInterceptor.Instance.RegisterQuery( string.Format(hql, args) );
            IQuery query = NHibernateSession.CreateQuery(string.Format(hql, args));
            if (start >= 0) {
                query.SetFirstResult(start);
            }
            if( count >= 0 ) {
                query.SetMaxResults(count);
            }
            return query.List();
        }
        
        /// <summary>
        /// Performs multiple queries
        /// </summary>
        /// <param name="hqls">The queries</param>
        /// <param name="args">The arguments</param>
        /// <returns>The resultset</returns>
        public IList MultiQuery(IEnumerable<string> hqls, Dictionary<string, object> args)
        {
            IMultiQuery mq = NHibernateSession.CreateMultiQuery();

            foreach (string hql in hqls) {
                mq.Add(hql);
            }
            
			if (args != null) {
				foreach (KeyValuePair<string, object> arg in args) {
					mq.SetParameter(arg.Key, arg.Value);
				}
            }

            return mq.List();
        }
		
		/// <summary>
        /// Performs a HQL query
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <returns>The list</returns>
		public IList<T> TypedQuery( string hql )
		{
            return TypedQuery(-1, -1, hql, new object[0]);
		}
		
		/// <summary>
        /// Performs a HQL query
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <param name="args">Arguments to format the HQL</param>
        /// <returns>The list</returns>
		public IList<T> TypedQuery( string hql, params object[] args )
		{
            return TypedQuery(-1, -1, hql, args);
		}

		/// <summary>
        /// Performs a HQL query
        /// </summary>
        /// <param name="start">The first index</param>
        /// <param name="count">The number of elements to return</param>
        /// <param name="hql">The HQL</param>
        /// <param name="args">Parameters to format the HQL</param>
        /// <returns>The list</returns>
        public IList<T> TypedQuery( int start, int count, string hql, params object[] args )
        {
			try {
                StatsInterceptor.Instance.RegisterQuery( string.Format(hql,args) );
	            IQuery query = NHibernateSession.CreateQuery(string.Format(hql, args));
	            if (start >= 0) {
	                query.SetFirstResult(start);
	            }
	            if( count >= 0 ) {
	                query.SetMaxResults(count);
	            }
	            return ToTypedCollection(query.List());
			} catch( Exception ex ) {
				throw new DALException("Could not execute `" + string.Format(hql, args) + "'", ex);
			}
        }
		
		/// <summary>
        /// Persists an object
        /// </summary>
        /// <param name="t">The object</param>
		public void Update( T t )
		{
			LifecycleVeto veto = LifecycleVeto.Continue;
			if( t.Id == 0 ) {
				veto = OnSave(t);
				if( veto != LifecycleVeto.Abort ) {
					t.CreatedDate = DateTime.Now;
					t.UpdatedDate = t.CreatedDate;
                    SetLastUser(t);
					NHibernateSession.Save(t);
                    StatsInterceptor.Instance.RegisterCreate();
					ResetStaticCount();
				}
			} else {
				veto = OnUpdate(t);
				if( veto != LifecycleVeto.Abort ) {
					t.UpdatedDate = DateTime.Now;
                    SetLastUser(t);
					NHibernateSession.Update(t);
                    StatsInterceptor.Instance.RegisterUpdate();
				}
			}
			
			if( veto == LifecycleVeto.Abort ) {
				throw new LifecycleAbortException();
			}
		}
		
		/// <summary>
        /// Persists an object
        /// </summary>
        /// <param name="t">The list of objects</param>
		public void Update( IEnumerable<T> ts )
		{
			foreach(T t in ts)
			{
				Update(t);
			}
		}
		
		/// <summary>
        /// Sets the entity with the current user
        /// </summary>
        /// <param name="t"></param>
        private void SetLastUser(T t)
        {
            t.LastActionUserId = -1;
            if (HttpContext.Current != null && HttpContext.Current.User is Principal) {
                t.LastActionUserId = ((Principal)HttpContext.Current.User).Id;
            }
        }
		
		/// <summary>
        /// Deletes an object from the persistance repository
        /// </summary>
        /// <param name="t">The target object</param>
		public void Delete( T t )
		{
			NHibernateSession.Delete(t);
			ResetStaticCount();
		}
		
		/// <summary>
        /// Deletes an object from the persistance repository
        /// </summary>
        /// <param name="id">The target object's Id</param>
        /// <returns>The number of objects deleted</returns>
		public int Delete( int id )
		{
			string query = string.Format("from {0} e where e.Id={1}", PersistanceType.Name, id);
			ResetStaticCount();
			return (int)NHibernateSession.Delete(query);
		}
		
		/// <summary>
        /// Deletes all objects from the persistance repository
        /// </summary>
        /// <returns>The number of objects deleted</returns>
		public int DeleteAll()
		{
			string query = string.Format("from {0}", PersistanceType.Name);
			ResetStaticCount();
			return (int)NHibernateSession.Delete(query);
		}
		
		/// <summary>
        /// Deletes objects based on a HQL
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <returns>The number of objects deleted</returns>
		public int Delete(string hql)
		{
			ResetStaticCount();
			return (int)NHibernateSession.Delete(hql);
		}
		
		/// <summary>
        /// Deletes objects based on a HQL
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <param name="args">The parameters to format the HQL</param>
        /// <returns>The number of deleted objects</returns>
		public int Delete(string hql, params object[] args)
        {
            return Delete(string.Format(hql, args));
        }
        
		/// <summary>
        /// Executes HQL
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <param name="args">The parameters to format the HQL</param>
        /// <returns>The result</returns>
		public long ExecuteScalar(string hql, params object[] args)
        {
            return ExecuteScalar( string.Format(hql, args) );
        }

		/// <summary>
        /// Executes HQL
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <returns>The result</returns>
        public long ExecuteScalar(string hql)
        {
            IList list = Query(hql);
            if(null == list[0])
            {
                return 0;
            }
            if( list[0] is long ) 
                return (long)list[0];
            return (long)(int)list[0];
        }
		
		/// <summary>
        /// Starts a transaction
        /// </summary>
		public void StartTransaction()
		{
			Transaction = NHibernateSession.BeginTransaction();
			NHibernateSession.FlushMode = FlushMode.Commit;
		}
		
		/// <summary>
        /// Commit transaction
        /// </summary>
		public void CommitTransaction()
		{
			if( Transaction != null && Transaction.IsActive ) {
				transaction.Commit();
			}
		}
		
		/// <summary>
        /// Rollback transaction
        /// </summary>
		public void RollbackTransaction()
		{
			if( Transaction != null && Transaction.IsActive ) {
				transaction.Rollback();
			}
		}
		
		/// <summary>
        /// Updates the persistance repository with the information stilll in memory
        /// </summary>
		public void Flush()
		{
			if( ShouldThrowOnFlush ) {
				throw new LokiException("Flush called and shouldThrowOnFlush is true");
			}
			StatsInterceptor.Instance.RegisterFlush();
			NHibernateSession.Flush();
		}
		
		/// <summary>
        /// Resets the entity's state (forces the persistance respository break)
        /// </summary>
        /// <param name="entity">The entity</param>
        public void ResetEntity(IEntity entity)
        {
			entity.Id = 0;
        }
		
		#endregion IPersistance
		
		#region Lifecycle Implementation
		
		/// <summary>
        /// OnLoad event
        /// </summary>
		public event Lifecycle<T>.Event LoadEvent;
		
		/// <summary>
        /// Save event
        /// </summary>
		public event Lifecycle<T>.ActionEvent SaveEvent;
		
		/// <summary>
        /// Update event
        /// </summary>
		public event Lifecycle<T>.ActionEvent UpdateEvent;
		
		/// <summary>
        /// Delete event
        /// </summary>
		public event Lifecycle<T>.ActionEvent DeleteEvent;
		
		/// <summary>
        /// Calls the load events
        /// </summary>
        /// <param name="t">The loaded object</param>
		protected virtual void OnLoad( T t)
		{
			CallEvent(t, LoadEvent);
		}
		
		/// <summary>
        /// Calls the Save events
        /// </summary>
        /// <param name="t">The object to save</param>
        /// <returns>The LifecyleVeto</returns>
		protected virtual LifecyleVeto OnSave( T t )
		{
			return CallActionEvent(t, SaveEvent);
		}
		
		/// <summary>
        /// Calls the Update events
        /// </summary>
        /// <param name="t">The object to update</param>
        /// <returns>The LifecyleVeto</returns>
		protected virtual LifecyleVeto OnUpdate( T t )
		{
			return CallActionEvent(t, UpdateEvent);
		}
		
		/// <summary>
        /// Calls the Delete events
        /// </summary>
        /// <param name="t">The object to delete</param>
        /// <returns>The LifecyleVeto</returns>
		protected virtual LifecyleVeto OnDelete( T t )
		{
			return CallActionEvent(t, DeleteEvent);
		}
		
		/// <summary>
        /// Calls the event's actions
        /// </summary>
        /// <param name="t">The object</param>
        /// <param name="handler">The handler</param>
        /// <returns>The LifecyleVeto</returns>
		private LifecyleVeto CallActionEvent( T t, Lifecycle<T>.ActionEvent handler )
		{
			if( handler != null ) {
				foreach( Lifecycle<T>.ActionEvent e in handler.GetInvocationList() ) {
					LifecycleVeto veto = e(t);
					if( veto == LifecycleVeto.Abort ) {
						return veto;
					}	
				}
			}
			return LifecycleVeto.Continue;
		}
		
		/// <summary>
        /// Calls events
        /// </summary>
        /// <param name="t">The object</param>
        /// <param name="handler">The handler</param>
		private void CallEvent( T t, Lifecycle<T>.Event handler )
		{
			if( handler != null ) {
				foreach( Lifecycle<T>.Event e in handler.GetInvocationList() ) {
					e(t);
				}
			}
		}
		
		#endregion Lifecycle Implementation
		
		#region Utilities
		
		/// <summary>
        /// Creates a typed collections given an object collection
        /// </summary>
        /// <param name="col">The collection</param>
        /// <returns>Tye typed collection</returns>
		protected List<T> ToTypedCollection( ICollection col )
		{
			List<T> toReturn = new List<T>();
			foreach( T item in col ) {
				toReturn.Add(item);
			}
			return toReturn;
		}
		
		/// <summary>
        /// Creates the order by expression
        /// </summary>
        /// <param name="orderPropery">The property to order</param>
        /// <param name="ascending">The order direction</param>
        /// <returns>The NHibernate expression</returns>
		protected NHibernate.Criterion.Order CreateOrderExpression( string orderPropery, bool ascending)
		{
			string column = orderPropery;
			return new NHibernate.Criterion.Order(column, ascending);
		}
		
		/// <summary>
        /// Gets a boolean array
        /// </summary>
        /// <param name="length">The number of items</param>
        /// <returns>The bool array</returns>
		protected bool[] GetBoolArray( int length )
		{
			bool[] array = new bool[length];
			for( int i = 0; i < length; ++i ) {
				array[i] = true;
			}
			return array;
		}
	
		#endregion Utilities
		
		#region Static Count Management
		
		private static long count = -1;
		private static object sync = new object();
		
		/// <summary>
        /// Gets the static count for an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The number of objects persisted</returns>
		private static long GetStaticCount( string entity )
		{
			lock(sync) {
				if( count < 0 ) {
					IList list = NHibernateUtilities.HqlQuery((string.Format("select count(*) from {0}", entity)));
					count = (long)list[0];
				}
				return count;
			}
		}
		
		/// <summary>
        /// Clears the static count
        /// </summary>
		private static void ResetStaticCount()
		{
			lock(sync) {
				count = -1;
			}
		}
		
		#endregion
		
	};
}
