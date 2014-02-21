using System.Collections;
using System.Collections.Generic;
using NHibernate;
using Loki.DataRepresentation;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Performs interactions with the DB
    /// </summary>
    public static class Sql {

        #region Stateless Query

        public static IList StatelessQuery(string sql, params KeyValuePair<string, object>[] args)
        {
            return StatelessQuery(-1, -1, sql, args);
        }

        public static IList StatelessQuery(string sql, IEnumerable<KeyValuePair<string, object>> args)
        {
            return StatelessQuery(-1, -1, sql, args);
        }

        public static IList StatelessQuery(int start, int count, string sql, IEnumerable<KeyValuePair<string, object>> args)
        {
            StatsInterceptor.Instance.RegisterSql(sql);
            using (IStatelessSession session = NHibernateUtilities.Factory.OpenStatelessSession()) {
                IQuery query = session.CreateSQLQuery(sql);
                return DoQuery(start, count, query, args);
            }
        }

        #endregion Stateless Query

        #region Query

        public static IList Query(string sql, params KeyValuePair<string, object>[] args)
        {
            return Query(-1, -1, sql, args);
        }

        public static IList Query(string sql, IEnumerable<KeyValuePair<string, object>> args)
        {
            return Query(-1, -1, sql, args);
        }

        public static IList Query(int start, int limit, string sql, IEnumerable<KeyValuePair<string, object>> args)
        {
            StatsInterceptor.Instance.RegisterSql(sql);
            using (IPersistanceSession midSession = Persistance.Instance.GetGenericPersistance()) {
                ISession session = (ISession)midSession.Session;
                IQuery query = session.CreateSQLQuery(sql);
                return DoQuery(start, limit, query, args);
            }
        }

        #endregion Query

        #region Utilities

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

        private static IList DoQuery(int start, int limit, IQuery query, IEnumerable<KeyValuePair<string, object>> args)
        {
            if (args != null) {
                foreach (KeyValuePair<string, object> arg in args) {
                    query.SetParameter(arg.Key, arg.Value);
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
