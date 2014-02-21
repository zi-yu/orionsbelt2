
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate.Impl;
using NHibernate;

using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.DataAccessLayer {

	/// <summary>
    /// Performs interactions with the DB
    /// </summary>
    public static class Hql {

        #region Stateless Query

        public static IList<T> StatelessQuery<T>(string hql, params KeyValuePair<string, object>[] args)
        {
            return StatelessQuery<T>(-1, -1, hql, (IEnumerable<KeyValuePair<string, object>>)args);
        }
        
        public static IList<T> StatelessQuery<T>(int start, int count, string hql, params KeyValuePair<string, object>[] args) 
        {
            return StatelessQuery<T>(start, count, hql, (IEnumerable<KeyValuePair<string, object>>)args);
        }

        public static IList<T> StatelessQuery<T>(string hql, IEnumerable<KeyValuePair<string, object>> args)
        {
            return StatelessQuery<T>(-1, -1, hql, args);
        }

        public static IList<T> StatelessQuery<T>(int start, int count, string hql, IEnumerable<KeyValuePair<string, object>> args)
        {
            StatsInterceptor.Instance.RegisterQuery(hql);
            using (IStatelessSession session = NHibernateUtilities.Factory.OpenStatelessSession()) {
                IQuery query = session.CreateQuery(hql);
                return DoQuery<T>(start, count, query, args);
            }
        }

        #endregion Stateless Query

        #region Query
        
        public static IList Query( string hql, params KeyValuePair<string, object>[] args )
        {
            return Query( -1, -1, hql, args );
        }

        public static IList Query( string hql, IEnumerable<KeyValuePair<string, object>> args )
        {
            return Query( -1, -1, hql, args );
        }

        public static IList Query( int start, int limit, string hql, IEnumerable<KeyValuePair<string, object>> args )
        {
            StatsInterceptor.Instance.RegisterQuery( hql );
            using ( IPersistanceSession midSession = Persistance.Instance.GetGenericPersistance() ) {
                ISession session = (ISession) midSession.Session;
                IQuery query = session.CreateQuery( hql );
                return DoQuery( start, limit, query, args );
            }
        }

        public static IList<T> Query<T>(string hql, params KeyValuePair<string, object>[] args)
        {
            return Query<T>(-1, -1, hql, args);
        }

        public static IList<T> Query<T>(string hql, IEnumerable<KeyValuePair<string, object>> args)
        {
            return Query<T>(-1, -1, hql, args);
        }

        public static IList<T> Query<T>(int start, int limit, string hql, IEnumerable<KeyValuePair<string, object>> args)
        {
            StatsInterceptor.Instance.RegisterQuery(hql);
            using (IPersistanceSession midSession = Persistance.Instance.GetGenericPersistance()) {
                ISession session = (ISession)midSession.Session;
                IQuery query = session.CreateQuery(hql);
                return DoQuery<T>(start, limit, query, args);
            }
        }

        #endregion Query
        
        #region Execute Scalar

        public static object ExecuteScalar(string hql, params KeyValuePair<string, object>[] args)
        {
            StatsInterceptor.Instance.RegisterQuery(hql);
            using (IPersistanceSession midSession = Persistance.Instance.GetGenericPersistance())  {
                ISession session = (ISession)midSession.Session;
                IQuery query = session.CreateQuery(hql);
                IList result = DoQuery(-1, -1, query, args);
                if (result != null && result.Count > 0) {
                    return result[0];
                }
                return null;
            }
        }

        #endregion Execute Scalar

        #region Utilities
        
        public static IList<T> Unify<T>(IList<T> raw)
        {
            List<T> list = new List<T>();

            foreach (T t in raw) {
                if (!list.Contains(t)) {
                    list.Add(t);
                }
            }

            return list;
        }

        public static KeyValuePair<string, object> Param(string str, object obj)
        {
            return new KeyValuePair<string, object>(str, obj);
        }

        public static IEnumerable<KeyValuePair<string, object>> GetParams(params KeyValuePair<string, object>[] args)
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
            if (args == null) {
                return list;
            }

            list.AddRange(args);
            return list;
        }

        #endregion Utilities

        #region Private

        private static IList<T> DoQuery<T>(int start, int limit, IQuery query, IEnumerable<KeyValuePair<string, object>> args)
        {
            if (args != null) {
                foreach (KeyValuePair<string, object> arg in args) {
                    ICollection col = arg.Value as ICollection;
                    if ( col != null ) {
                        query.SetParameterList( arg.Key, col );
                    } else {
                        query.SetParameter( arg.Key, arg.Value );
                    }
                }
            }

            if (start > 0) {
                query.SetFirstResult(0);
            }

            if (limit > 0) {
                query.SetMaxResults(limit);
            }

            return query.List<T>();
        }
        
        private static System.Collections.IList DoQuery(int start, int limit, IQuery query, IEnumerable<KeyValuePair<string, object>> args)
        {
            if (args != null) {
                foreach (KeyValuePair<string, object> arg in args) {
                    ICollection col = arg.Value as ICollection;
                    if ( col != null ) {
                        query.SetParameterList( arg.Key, col );
                    } else {
                        query.SetParameter( arg.Key, arg.Value );
                    }
                }
            }

            if (start > 0) {
                query.SetFirstResult(0);
            }

            if (limit > 0) {
                query.SetMaxResults(limit);
            }

            return query.List();
        }

        #endregion Private

	};
}
