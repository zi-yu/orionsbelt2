using System;
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

	public class MemoryPersistance<T> :
			IPersistance<T>, 
			ILifecycle<T>,
			IDisposable 
			where T : IEntity {
			
        #region Static memory support

        private static Dictionary<int, T> db = new Dictionary<int, T>();
		private static readonly Random random = new Random();
        
        protected static Dictionary<int, T> Database {
            get { return db; }
        }
		
		#endregion Static memory support
		
		#region Ctor and Fields
			
		/// <summary>
        /// Access to the Generic session
        /// </summary>
		public object Session {
			get { return new object(); }
		}
		
		public Type PersistanceType {
			 get { return typeof(T); }
		}
		
		#endregion Ctor and Fields
		
		#region IDisposable Implementation
		
		/// <summary>
        ///  Closes the NHibernate session
        /// </summary>
		public void Dispose()
		{
		}
		
		/// <summary>
        /// Closes the session
        /// </summary>
        public void Close()
        {
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
        }
        
        /// <summary>
        /// Clears the session cache
        /// </summary>
        public void Clear()
        {
        }
        
        /// <summary>
        /// Closes the current session and creates a new one
        /// </summary>
        public void Reset()
        {
        }
		
		/// <summary>
        /// Selects the element with the given Id
        /// </summary>
        /// <param name="id">The target's id</param>
        /// <returns>The associated object</returns>
		public T Select( int id )
		{
			if (Database.ContainsKey(id)){
                return Database[id];
            }

            throw new DALException("No `{0}` with id `{1}` found", PersistanceType.Name, id);
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
			return new List<T>(Database.Values);
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
        public void AddValidators()
        {
			throw new NotImplementedException();
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
            return new ArrayList();
        }
        
        /// <summary>
        /// Performs multiple queries
        /// </summary>
        /// <param name="hqls">The queries</param>
        /// <param name="args">The arguments</param>
        /// <returns>The resultset</returns>
        public IList MultiQuery(IEnumerable<string> hqls, Dictionary<string, object> args)
        {
            return new ArrayList();
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
			return new List<T>();
        }
		
		/// <summary>
        /// Persists an object
        /// </summary>
        /// <param name="t">The object</param>
		public void Update( T t )
		{
			if( t.Id == 0 ) {
				t.Id = random.Next();
			}
			
			Database[t.Id] = t;
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
        /// Deletes an object from the persistance repository
        /// </summary>
        /// <param name="t">The target object</param>
		public void Delete( T t )
		{
			Delete(t.Id);
		}
		
		/// <summary>
        /// Deletes an object from the persistance repository
        /// </summary>
        /// <param name="id">The target object's Id</param>
        /// <returns>The number of objects deleted</returns>
		public int Delete( int id )
		{
			if( Database.ContainsKey(id) ) {
				Database.Remove(id);
				return 1;
			}
			return 0;
		}
		
		/// <summary>
        /// Deletes all objects from the persistance repository
        /// </summary>
        /// <returns>The number of objects deleted</returns>
		public int DeleteAll()
		{
			int count = Database.Count;
			Database.Clear();
			return count;
		}
		
		/// <summary>
        /// Deletes objects based on a HQL
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <returns>The number of objects deleted</returns>
		public int Delete(string hql)
		{
			return 0;
		}
		
		/// <summary>
        /// Deletes objects based on a HQL
        /// </summary>
        /// <param name="hql">The HQL</param>
        /// <param name="args">The parameters to format the HQL</param>
        /// <returns>The number of deleted objects</returns>
		public int Delete(string hql, params object[] args)
        {
            return 0;
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
            return 0;
        }
		
		/// <summary>
        /// Starts a transaction
        /// </summary>
		public void StartTransaction()
		{
		}
		
		/// <summary>
        /// Commit transaction
        /// </summary>
		public void CommitTransaction()
		{
		}
		
		/// <summary>
        /// Rollback transaction
        /// </summary>
		public void RollbackTransaction()
		{
		}
		
		/// <summary>
        /// Updates the persistance repository with the information stilll in memory
        /// </summary>
		public void Flush()
		{
		}
		
		/// <summary>
        /// True to throw on flush
        /// </summary>
		public bool ShouldThrowOnFlush {
			get { return false; }
			set {}
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
		
		#region Static Count Management
		
		private static object sync = new object();
		
		/// <summary>
        /// Gets the static count for an entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The number of objects persisted</returns>
		private static long GetStaticCount( string entity )
		{
			return Database.Count;
		}
		
		/// <summary>
        /// Clears the static count
        /// </summary>
		private static void ResetStaticCount()
		{
		}
		
		#endregion
		
	};
}
