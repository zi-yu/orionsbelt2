
using System;
using System.IO;
using System.Collections.Generic;
using Loki.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Proxy;

namespace OrionsBelt.DataAccessLayer {
	public static class NHibernateUtilities {
	
		#region Static Fields
		
		private static Configuration cfg = new Configuration();
		private static ISessionFactory factory = null;
		
		#endregion Static Fields
		
		#region Static Properties
		
		public static Configuration Config {
			get { return cfg; }
		}
		
		public static ISessionFactory Factory {
			get { return factory; }
		}
		
		public static NHibernate.Stat.IStatistics Statistics {
            get { return Factory.Statistics; }
        }
		
		public static bool IncludeStats {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["UseNHibernateStats"] == "true";
            }
        }

		public static bool UseMasterSession {
            get { return !InWebContext;  }
        }

        public static bool InWebContext {
            get {
                return System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Items != null;
            }
        }

        public static ISession masterSession = null;
		public static ISession OpenSession {
			get {
                if (InWebContext) {
                    return PrepareMode(Factory.OpenSession());
                }
                if (masterSession == null || !masterSession.IsOpen) {
                    masterSession = PrepareMode(Factory.OpenSession());
                }
                return masterSession;
			}
		}
		
		private static ISession PrepareMode(ISession iSession)
        {
            iSession.FlushMode = FlushMode.Never;
            return iSession;
        }
		
		public static IStatelessSession masterStatelessSession = null;
		public static IStatelessSession OpenStatelessSession {
			get {
                if (InWebContext) {
                    return Factory.OpenStatelessSession();
                }
                if (masterStatelessSession == null || !IsSessionOpen(masterStatelessSession)) {
                    masterStatelessSession = Factory.OpenStatelessSession();
                }
                return masterStatelessSession;
			}
		}

        public static bool IsSessionOpen(object obj)
        {
            ISession session = obj as ISession;
            if (session != null) {
                return session.IsOpen;
            }
            IStatelessSession ssession = obj as IStatelessSession;
            if (ssession != null) {
                return ssession.Connection.State == System.Data.ConnectionState.Open;
            }
            return false;
        }
		
		public static string ConnectionString {
			get { 
				return Config.GetProperty("connection.connection_string");
			}
		}
		
		#endregion Static Properties
	
		#region Initialization
		
		static NHibernateUtilities()
		{
			if( File.Exists(ConfigFile) ) {
				Log.Info("Using `{0}` con configure NHibernate", ConfigFile);
				PrepareNHibernate();
			} else {
				throw new DALException("NHibernate Config File `"+ConfigFile+"` does not exist");
			}
		}
		
		private static void PrepareNHibernate()
        {
            try {
                Config.Configure(ConfigFile);
                Config.AddXmlFile(ModelFile);
                factory = cfg.BuildSessionFactory();
                factory.Statistics.IsStatisticsEnabled = IncludeStats;
            } catch (Exception ex) {
                //Console.Error.Write("*** FATAL ERROR");
                //Console.Error.Write(ex);
                throw ex;
            }
        }
		
        /// <summary>
        /// Checks the entity session
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="midSession">The target midgard session</param>
        public static void CheckSession(Loki.DataRepresentation.IEntity entity, ISession target)
        {
            INHibernateProxy proxy = entity as INHibernateProxy;
            if (proxy == null) {
                return;
            }
            if (!NHibernateUtil.IsInitialized(proxy)) {
                proxy.HibernateLazyInitializer.Session = target.GetSessionImplementation();
                NHibernateUtil.Initialize(proxy);
            }
        }
        
        internal static bool IsCollectionOk(System.Collections.IList bag)
        {
			try
            {
                if (!NHibernateUtil.IsInitialized(bag)) {
                    NHibernateUtil.Initialize(bag);
                }
                // sanity check
                Console.Write(bag.Count);
                return true;
            }
            catch
            {
                StatsInterceptor.Instance.RegisterLazyError();
                return false;
            }
        }

		/// <summary>
        /// Checks an entity session
        /// </summary>
        /// <param name="entity">The entity</param>
        public static void CheckSession(Loki.DataRepresentation.IEntity entity)
        {
			INHibernateProxy proxy = entity as INHibernateProxy;
            if (proxy == null) {
                return;
            }
            if (NHibernateUtil.IsInitialized(proxy)) {
				return;
            }
            PrincipalPersistance persistance = null;
            try {
                persistance = PrincipalPersistance.GetSession();
                CheckSession(entity, persistance.NHibernateSession);
            } catch {
                if (persistance != null){
                    persistance.Dispose();
                }
            }
        }

        /// <summary>
        /// Resets the given object's session
        /// </summary>
        /// <param name="entity"></param>
        internal static void ResetSession(Loki.DataRepresentation.IEntity entity)
        {
            PrincipalPersistance session = null;
            
            try {

                session = PrincipalPersistance.GetSession();

                // hack to force NHibernate to associate the new session with the given entity
                session.NHibernateSession.Update(entity);

            } catch {
                if (session != null) {
                    session.Dispose();
                }
                throw;
            }
        }

        /// <summary>
        /// Checks if the given collection needs to bem reseted
        /// </summary>
        /// <param name="current">The current session (if any)</param>
        /// <param name="entity">The owner entity</param>
        /// <param name="collection">The collection</param>
        internal static void CheckCollectionSession(ISession current, Loki.DataRepresentation.IEntity entity, System.Collections.IEnumerable collection)
        {
            if( NHibernateUtil.IsInitialized(collection) ){
                return;
            }
            
            IPersistentCollection pc = collection as IPersistentCollection;
            if (pc != null && pc.IsDirty) {
                pc.ClearDirty();
            }
            
            ResetSession(entity);
        }
		
		#endregion Initialization
	
		#region Utilities
		
		public static string ConfigFile {
			get {
                return GetFile("OrionsBelt.cfg.xml");
			}
		}

        private static string GetFile(string cfgFile)
        {
			string fromAppSettings = System.Configuration.ConfigurationManager.AppSettings[cfgFile];
            if (!string.IsNullOrEmpty(fromAppSettings)) {
                return fromAppSettings;
            }
            string path = typeof(NHibernateUtilities).Assembly.CodeBase; 
			path = new Uri(path).AbsolutePath; 
            path = Path.GetDirectoryName(path); 
            path = Path.Combine(path, "..");
            path = Path.Combine(path, "Config");
            cfgFile = Path.Combine(path, cfgFile);
            return cfgFile;
        }

        public static string ModelFile {
            get {
                return GetFile("Model.hbm.xml");
            }
        }
		
		#endregion Utilities
		
		#region Queries
		
		public static System.Collections.IList HqlQuery( string hql )
		{
			return HqlQuery( -1, -1, hql, new object[0] );
		}
		
		public static System.Collections.IList HqlQuery( int start, int count, string hql )
		{
			return HqlQuery( start, count, hql, new object[0] );
		}
		
		public static System.Collections.IList HqlQuery( int start, int count, string hql, params object[] args )
		{
			ISession session = OpenSession;
            IQuery query = session.CreateQuery(string.Format(hql, args));
            if (start >= 0) {
                query.SetFirstResult(start);
            }
            if (count >= 0) {
                query.SetMaxResults(count);
            }
			return query.List();
		}
		
		#endregion Queries
		
		#region Database Creation
		
		public static void DropSchema( string file )
		{
			SchemaExport exporter = new SchemaExport(Config);
			exporter.SetOutputFile(file);
			exporter.Drop(true, true);
		}
		
		public static void CreateSchema( string file )
		{
			SchemaExport exporter = new SchemaExport(Config);
			exporter.SetOutputFile(file);
            exporter.Create(true, true);
		}
		
		#endregion
		
	}
}
