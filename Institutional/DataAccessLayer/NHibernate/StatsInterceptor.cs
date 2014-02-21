
using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using Loki.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Proxy;
using Institutional.Core;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Logs NHibernate statistics
    /// </summary>
	public class StatsInterceptor : IInterceptor {

        #region Static Access

        private static StatsInterceptor instance = new StatsInterceptor();
        public static StatsInterceptor Instance {
            get { return instance; }
        }

        #endregion Static Access

        #region Non NHibernate Stats

        public void RegisterQuery( string query )
        {
            ++Statistics.Queries;
			Statistics.AddQueries( query );
        }

        public void RegisterSql(string sql)
        {
            ++Statistics.SQLs;
            Statistics.AddSql(sql);
            Statistics.AddSqlStackTrace(System.Environment.StackTrace);
        }

        internal void RegisterFlush()
        {
            ++Statistics.Flushes;
        }

        internal void RegisterCreate()
        {
            ++Statistics.Creates;
        }

        internal void RegisterUpdate()
        {
            ++Statistics.Updates;
        }

        internal void RegisterLazyError()
        {
            ++Statistics.LazyErrors;
        }

        #endregion Non NHibernate Stats

        #region Properties

        System.Collections.IDictionary container = new System.Collections.Hashtable();
        private System.Collections.IDictionary Container {
            get {
                if (HttpContext.Current == null) {
                    return container;
                } else {
                    return HttpContext.Current.Items;
                }
            }
        }

        public Stats Statistics {
            get {
                Stats stats = (Stats) Container["StatsInterceptor"];
                if (stats != null) {
                    return stats;
                }
                stats = new Stats();
                Container["StatsInterceptor"] = stats;
                return stats;
            }
        }

        #endregion Properties

        #region Util Class

        public class Stats {
            public int Flushes = 0;
            public int Creates = 0;
            public int Updates = 0;
            public int Queries = 0;
            public int SQLs = 0;
            public int LazyErrors = 0;
            public Dictionary<string, int> Saves = new Dictionary<string, int>();
            public Dictionary<string, int> Loads = new Dictionary<string, int>();
            public Dictionary<string, int> Deleteds = new Dictionary<string, int>();
            public Dictionary<string, int> Instanciates = new Dictionary<string, int>();
			public List<string> QueryList = new List<string>();
            public List<string> SqlList = new List<string>();
            public List<string> SqlListStackTrace = new List<string>();

			internal void AddQueries( string query ) {
				QueryList.Add(query);
			}

            internal void AddSql(string sql)
            {
                SqlList.Add(sql);
            }

            internal void AddSaves(string key)
            {
                Increment(Saves, key);
            }

            internal void AddInstantiate(string key)
            {
                Increment(Instanciates, key);
            }

            internal void AddDeleteds(string key)
            {
                Increment(Deleteds, key);
            }

            internal void AddLoads(string key)
            {
                Increment(Loads, key);
            }

            private void Increment(Dictionary<string, int> dic, string key)
            {
                int actual = 0;
                if (dic.ContainsKey(key)){
                    actual = dic[key];
                }
                dic[key] = ++actual;
            }

            #region Object Implementation

            public override string ToString()
            {
                TextWriter writer = new StringWriter();

                writer.WriteLine("<pre>");
                writer.WriteLine("NHibernate Stats");
                writer.WriteLine("--");
                writer.WriteLine("Flushes: {0}", Flushes);
                writer.WriteLine("Queries: {0}", Queries);
                writer.WriteLine("Creates: {0}", Creates);
                writer.WriteLine("Updates: {0}", Updates);

                WriteDic(writer, Loads, "Loads");
                WriteDic(writer, Saves, "Saves");
                //WriteDic(writer, Instanciates, "Instantiates");
                WriteDic(writer, Deleteds, "Deletes");
				WriteList(writer, QueryList, "Queries Made");

                writer.WriteLine("</pre>");

                return writer.ToString();
            }

			private static void WriteList( TextWriter writer, List<string> list, string title ) {
				writer.WriteLine("--");
				writer.WriteLine("{0}:", title);
				foreach( string query in list ) {
					writer.WriteLine(" - {0}", query );
				}
			}

			private static void WriteDic( TextWriter writer, Dictionary<string, int> dic, string title )
            {
                writer.WriteLine("--");
                writer.WriteLine("{0}:", title);
                foreach (KeyValuePair<string, int> pair in dic)
                {
                    writer.WriteLine(" - {0} : {1}", pair.Key, pair.Value);
                }
            }

            #endregion Object Implementation

            internal void AddSqlStackTrace(string st)
            {
                SqlListStackTrace.Add(st);
            }
        };

        #endregion Util Class

        #region IInterceptor Members

        public void AfterTransactionBegin(ITransaction tx)
        {
        }

        public void AfterTransactionCompletion(ITransaction tx)
        {
        }

        public void BeforeTransactionCompletion(ITransaction tx)
        {
        }

        public int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            return null;
        }

        public object Instantiate(Type type, object id)
        {
            Statistics.AddInstantiate(type.Name);
            return null;
        }

        public object IsUnsaved(object entity)
        {
            return null;
        }

        public void OnDelete(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            if (entity == null) {
                return;
            }
            Statistics.AddDeleteds(entity.GetType().Name);
        }

        public bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            return false;
        }

        public bool OnLoad(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            if (entity == null) {
                return false;
            }
            Statistics.AddLoads(entity.GetType().Name);
            return false;
        }

        public bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            if (entity == null) {
                return false;
            }
            Statistics.AddSaves(entity.GetType().Name);
            return false;
        }

        public void PostFlush(System.Collections.ICollection entities)
        {
        }

        public void PreFlush(System.Collections.ICollection entities)
        {
        }

        public void SetSession(ISession session)
        {
        }

        #endregion

        #region Object Implementation

        public override string ToString()
        {
            return Statistics.ToString();
        }

        #endregion Object Implementation
        
        #region Extra IInterceptor Members

        public object GetEntity(string entityName, object id)
        {
            return null;
        }

        public string GetEntityName(object entity)
        {
            return null;
        }

        public object Instantiate(string entityName, EntityMode entityMode, object id)
        {
            return null;
        }

        public bool? IsTransient(object entity)
        {
            return null;
        }

        public void OnCollectionRecreate(object collection, object key)
        {
        }

        public void OnCollectionRemove(object collection, object key)
        {
        }

        public void OnCollectionUpdate(object collection, object key)
        {
        }

        public NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            return sql;
        }

        #endregion

    };

}
