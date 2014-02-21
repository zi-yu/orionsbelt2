using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Loki.DataRepresentation;
using Institutional.DataAccessLayer;
using Institutional.Core;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Provides persistance objects
    /// </summary>
    public static class Persistance {
    
		#region Static persistance access
		
		private static IPersistanceProvider provider;
		public static IPersistanceProvider Instance {
			get { return provider; }
			set { provider = value; }
		}
		
		private static IPersistanceProvider stateless;
		public static IPersistanceProvider Stateless {
			get { return stateless; }
			set { stateless = value; }
		}
		
		static Persistance()
		{
#if MEMORY_PERSISTANCE
            Instance = new MemoryProvider();
            Stateless = Instance;
#else
			Instance = new NHibernateProvider();
			Stateless = new NHibernateProviderStateless();
#endif
		}
		
		#endregion Static persistance access
		
		#region Persistance Utils

        #region GetEntity
        
        /// <summary>
        /// Creates an entity object
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>The created entity</returns>
        public static T Create<T>()
        {
            using (IPersistance<T> persistance = Persistance.Instance.GetPersistance<T>()) {
                return persistance.Create();
            }
        }
        
        /// <summary>
        /// Creates an entity object
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="owner">The owner</param>
        /// <returns>The created entity</returns>
        public static T Create<T>(IPersistanceSession owner)
        {
            using (IPersistance<T> persistance = Persistance.Instance.GetPersistance<T>(owner)){
                return persistance.Create();
            }
        }

        /// <summary>
        /// Gets an Entity
        /// </summary>
        /// <typeparam name="E">The entity's type</typeparam>
        /// <param name="id">The identifier</param>
        /// <returns>The entity</returns>
        public static E GetEntity<E>(int id)
        {
            using (IPersistance<E> persistance = Instance.GetPersistance<E>()) {
                return persistance.Select(id);
            }
        }

        /// <summary>
        /// Gets an Entity
        /// </summary>
        /// <typeparam name="E">The entity's type</typeparam>
        /// <param name="id">The identifier</param>
        /// <returns>The entity</returns>
        public static E GetEntity<E>(int id, IPersistanceSession session)
        {
            using (IPersistance<E> persistance = Instance.GetPersistance<E>(session)) {
                return persistance.Select(id);
            }
        }

        /// <summary>
        /// Gets an entity
        /// </summary>
        /// <typeparam name="E">The entity type</typeparam>
        /// <param name="propertyName">The property name</param>
        /// <param name="propertyValue">the property value</param>
        /// <returns>The Entity</returns>
        public static E GetEntity<E>(string propertyName, string propertyValue)
        {
            using (IPersistance<E> persistance = Instance.GetPersistance<E>()) {
                return GetEntityObject<E>(persistance, propertyName, propertyValue);
            }
        }

        /// <summary>
        /// Gets an entity
        /// </summary>
        /// <typeparam name="E">The entity type</typeparam>
        /// <param name="propertyName">The property name</param>
        /// <param name="propertyValue">The property value</param>
        /// <param name="session">The session to attach</param>
        /// <returns>The entity</returns>
        public static E GetEntity<E>(string propertyName, string propertyValue, IPersistanceSession session)
        {
            using (IPersistance<E> persistance = Instance.GetPersistance<E>(session)) {
                return GetEntityObject<E>(persistance, propertyName, propertyValue);
            }
        }

        /// <summary>
        /// Gets an entity
        /// </summary>
        /// <typeparam name="E">The entity type</typeparam>
        /// <param name="persistance">The persistance object</param>
        /// <param name="propertyName">The property name</param>
        /// <param name="propertyValue">The peroperty value</param>
        /// <returns>The entity</returns>
        private static E GetEntityObject<E>(IPersistance<E> persistance, string propertyName, string propertyValue)
        {
            IList<E> list = persistance.TypedQuery("from Specialized{0} e where e.{1} = '{2}'", typeof(E).Name, propertyName, propertyValue);
            if (list != null && list.Count > 0) {
                return list[0];
            }
            return default(E);
        }
        
        /// <summary>
		/// Gets the entity count
		/// </summary>
		/// <returns>The entity count</returns>
		public static long GetEntityCount<E>() {
			using( IPersistance<E> persistance = Instance.GetPersistance<E>() ) {
				return persistance.GetCount();
			}
		}
		
		/// <summary>
        /// If the given entity is transient, session.Update will be called
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        public static void ResolveTransient<T>(T entity) where T : IEntity
        {
            using (IPersistance<T> persistance = Instance.GetPersistance<T>()) {
                ResolveTransient<T>(persistance, entity);
            }
        }

        /// <summary>
        /// If the given entity is transient, session.Update will be called
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="session">The session</param>
        /// <param name="entity">The entity</param>
        public static void ResolveTransient<T>(IPersistance<T> session, T entity) where T : IEntity
        {
            if (entity == null) {
                return;
            }

            if (entity.Transient) {
                session.Update(entity);
            }
        }
        
        /// <summary>
        /// Removes an object from the nhibernate cache
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        public static void Evict(IEntity entity)
        {
            Evict(Instance.GetGenericPersistance(), entity);
        }

        /// <summary>
        /// Removes an object from the nhibernate cache
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="entity">The entiry to remove</param>
        public static void Evict(IPersistanceSession session, IEntity entity)
        {
            NHibernate.ISession nhsession = session.Session as NHibernate.ISession;
            if (nhsession != null) {
                nhsession.Evict(entity);
            }
        }

        #endregion GetEntity

        #region Exists

        /// <summary>
        /// Returns true if an entity exists
        /// </summary>
        /// <typeparam name="E">Entity type</typeparam>
        /// <param name="id">The identifier</param>
        /// <returns>True if exists</returns>
        public static bool Exists<E>(int id)
        {
            return Exists(typeof(E).Name, id);
        }

        /// <summary>
        /// Returns true if an entity exists
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>True if exists</returns>
        public static bool Exists(IEntity entity)
        {
            return Exists(entity.TypeName, entity.Id);
        }

        /// <summary>
        /// Returns true if an entity exists
        /// </summary>
        /// <param name="entityName">The entity name</param>
        /// <param name="id">The identifier</param>
        /// <returns>True if exists</returns>
        public static bool Exists(string entityName, int id)
        {
			if (id == 0) {
                return false;
            }
            using (IPersistanceSession persistance = Instance.GetGenericPersistance()) {
                System.Collections.IList fromBD = persistance.Query("select e.Id from Specialized{0} e where e.Id = {1}", entityName, id);
                return fromBD != null && fromBD.Count > 0;
            }
        }

        #endregion Exists
        
		#region Entity Type List
		
		/// <summary>
        /// Gets all the entities for a given type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The entities</returns>
        public static IEnumerable<IEntity> GetAll(Type type)
        {
            using (IPersistanceSession session = Instance.GetPersistance(type)) {
                IList list = session.Query("from Specialized{0}", type.Name);
                foreach (IEntity entity in list) {
                    yield return entity;
                }
            }
        }

        /// <summary>
        /// Gets the persistable types, orderer by dependecies
        /// </summary>
        /// <returns>The types</returns>
        public static IEnumerable<Type> GetPersistableTypes()
        {
            List<Type> list = new List<Type>();

            list.Add( typeof( Server ) );
            list.Add( typeof( MediaArticle ) );
            list.Add( typeof( Testimonial ) );
            list.Add( typeof( Referral ) );
            list.Add( typeof( Principal ) );
            list.Add( typeof( ExceptionInfo ) );

            return list;
        }

        #endregion Entity Type List
        
        #region Session Utils
        
        /// <summary>
        /// Prepares the entity session
        /// </summary>
        /// <param name="entity">The entity</param>
        public static void PrepareLaziness(IEntity entity)
        {
            using (IPersistanceSession session = Instance.GetGenericPersistance()) {
                session.PrepareLaziness(entity);
            }
        }
        
        /// <summary>
        /// Clears the current session's cache
        /// </summary>
        public static void Clear()
        {
            using (IPersistanceSession session = Instance.GetGenericPersistance()) {
                session.Clear();
            }
        }
        
        /// <summary>
        /// Flushes the session
        /// </summary>
        public static void Flush()
        {
            using (IPersistanceSession session = Instance.GetGenericPersistance()) {
                session.Flush();
            }
        }
        
        /// <summary>
        /// Closes the current session
        /// </summary>
        public static void CloseCurrentSession()
        {
            using (IPersistanceSession session = Instance.GetGenericPersistance()) {
				session.Clear();
                session.Close();
            }
        }
        
        /// <summary>
        /// Closes the current session and creates a new one
        /// </summary>
        public static void ResetSession()
        {
            using (IPersistanceSession session = Instance.GetGenericPersistance())  {
                session.Reset();
            }
        }
        
        /// <summary>
        /// Refreshes an entity from the database
        /// </summary>
        /// <param name="entity">The entity to be refreshed</param>
        public static void RefreshEntity(IEntity entity)
        { 
            using (IPersistanceSession session = Instance.GetGenericPersistance())  {
                NHibernate.ISession nhSession = session.Session as NHibernate.ISession;
                if (nhSession != null) {
                    nhSession.Refresh(entity);
                }
            }
        }
        
        #endregion Session Utils

        #endregion Persistance Utils
		
    };
}

