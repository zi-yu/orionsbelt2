
using System.Web.UI;
using System.Web;
using Institutional.DataAccessLayer;
using NHibernate.Stat;
using System.Collections.Generic;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Renders NHibernate statistics (if available)
    /// </summary>
	public class NHStats : Control  {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            if (!HttpContext.Current.User.IsInRole("admin")) {
                return;
			}

            NHibernate.Stat.IStatistics stats = NHibernateUtilities.Statistics;

            WriteCSS(writer);
            writer.Write("<div id='nhStats'>");

            writer.Write("<h1>Request Statistics</h1>");
            WriteRequestStats(writer);

            writer.Write("<h1>Overall Statistics</h1>");
            WriteGeneric(writer, stats);
            WriteQueries(writer, stats);
            WriteEntities(writer, stats);
            WriteCollections(writer, stats);

            writer.Write("<h1>SQL Statistics</h1>");
            WriteSQL(writer);

            writer.Write("</div>");
        }

        private void WriteCSS(HtmlTextWriter writer)
        {
            writer.Write(@"<style>
#nhStats
{
    clear:both;
	color:#000;
	margin-top:10px;
}
#nhStats h1
{
	background-color:#6797CB;
	border:1px solid #6797CB;
	padding:5px;
	font-size:18px;
    margin:0;
}
#nhStats h2
{
	background-color:#F1EBBD;
	border:1px solid #6797CB;
	padding:5px;
	font-size:14px;
    margin:0;
}
#nhStats table
{
	background-color:#DEEAF3;
	display:block;
	padding:10px;
}

#nhStats table tr:hover
{
	background-color:#F1EBBD;
}

#nhStats table tr th
{
	background-color:#CBE1F1;
	border:1px solid #6797CB;
}

#nhStats table tr td
{
	border:1px solid #6797CB;
	
}
</style>");
        }

        private void WriteRequestStats(HtmlTextWriter writer)
        {
            StatsInterceptor.Stats stats = (StatsInterceptor.Stats)HttpContext.Current.Items["StatsInterceptor"];
            if (stats == null) {
                return;
            }

            writer.Write("<h2>Entity Stats</h2>");
            writer.Write("<table>");
            writer.Write("<tr>");
            writer.Write("<th>Info</th>");
            writer.Write("<th>Value</th>");
            writer.Write("</tr>");

            writer.Write("<tr><td>SQL Count</td><td>{0}</td></tr>", stats.SqlList.Count);
            writer.Write("<tr><td>Entity Load Count</td><td>{0}</td></tr>", stats.Loads.Count);
            writer.Write("<tr><td>Entity Flushes Count</td><td>{0}</td></tr>", stats.Flushes);
            writer.Write("<tr><td>Entity Insert Count</td><td>{0}</td></tr>", stats.Saves.Count);
            writer.Write("<tr><td>Entity Delete Count</td><td>{0}</td></tr>", stats.Deleteds.Count);

            WriteList(writer, "Queries", stats.QueryList);
            WriteDic(writer, "Loads", stats.Loads);
            WriteDic(writer, "Saves", stats.Saves);
            WriteDic(writer, "Deletes", stats.Deleteds);

            writer.Write("</table>");
        }

        private static void WriteSQL(HtmlTextWriter writer)
        {
            StatsInterceptor.Stats stats = (StatsInterceptor.Stats)HttpContext.Current.Items["StatsInterceptor"];
            if (stats == null) {
                return;
            }
            writer.Write("<h2>SQL Queries Performed on this request</h2>");

            writer.Write("<table>");
            writer.Write("<tr>");
            writer.Write("<th>#</th>");
            writer.Write("<th>SQL</th>");
            writer.Write("</tr>");

            int i = 0;
            foreach (string sql in stats.SqlList)
            {
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", ++i);

                writer.Write("<td>");
                writer.Write(sql);
                writer.Write("<p/>--</p>");
                writer.Write(stats.SqlListStackTrace[i - 1]);
                writer.Write("</td>");

                writer.Write("</tr>");
            }

            writer.Write("</table>");
        }

        private void WriteList(HtmlTextWriter writer, string title, List<string> list)
        {
            writer.Write("<tr>");
            writer.Write("<td>{0}</td>", title);
            writer.Write("<td><ul>");
            foreach (string str in list){
                writer.WriteLine("<li>{0}", str);
            }
            writer.Write("</ul></td>");
            writer.Write("<tr>");
        }

        private void WriteDic(HtmlTextWriter writer, string title, Dictionary<string, int> dictionary)
        {
            writer.Write("<tr>");
            writer.Write("<td>{0}</td>", title);
            writer.Write("<td><ul>");
            foreach (KeyValuePair<string, int> pair in dictionary){
                writer.WriteLine("<li>{0} : {1}</li>", pair.Key, pair.Value);
            }
            writer.Write("</ul></td>");
            writer.Write("<tr>");
        }

        private void WriteEntities(HtmlTextWriter writer, IStatistics stats)
        {
            writer.Write("<h2>Entity Stats</h2>");
            writer.Write("<table>");
            writer.Write("<tr>");
            writer.Write("<th>Info</th>");
            writer.Write("<th>Value</th>");
            writer.Write("</tr>");

            writer.Write("<tr><td>Entity Load Count</td><td>{0}</td></tr>", stats.EntityLoadCount);
            writer.Write("<tr><td>Entity Fetch Count</td><td>{0}</td></tr>", stats.EntityFetchCount);
            writer.Write("<tr><td>Entity Insert Count</td><td>{0}</td></tr>", stats.EntityInsertCount);
            writer.Write("<tr><td>Entity Delete Count</td><td>{0}</td></tr>", stats.EntityDeleteCount);
            writer.Write("<tr><td>Entity Update Count</td><td>{0}</td></tr>", stats.EntityUpdateCount);

            //foreach (string entity in stats.EntityNames)
            //{
            //    EntityStatistics estats = stats.GetEntityStatistics(entity);

            //    long check = estats.DeleteCount + estats.FetchCount + estats.InsertCount + estats.LoadCount + estats.OptimisticFailureCount + estats.UpdateCount;
            //    if (check == 0) {
            //        continue;
            //    }
            //    writer.Write("<tr>");
            //    writer.Write("<td>{0}</td>", entity);
            //    writer.Write("<td>");
            //    writer.Write("DeleteCount:{0}; ", estats.DeleteCount);
            //    writer.Write("FetchCount:{0}; ", estats.FetchCount);
            //    writer.Write("InsertCount:{0}; ", estats.InsertCount);
            //    writer.Write("LoadCount:{0}; ", estats.LoadCount);
            //    writer.Write("OptimisticFailureCount:{0}; ", estats.OptimisticFailureCount);
            //    writer.Write("UpdateCount:{0}; ", estats.UpdateCount);
            //    writer.Write("<td>");
            //    writer.Write("<tr>");
            //}

            writer.Write("</table>");
        }

        private void WriteQueries(HtmlTextWriter writer, IStatistics stats)
        {
            writer.Write("<h2>Query Stats</h2>");
            writer.Write("<table>");
            writer.Write("<tr>");
            writer.Write("<th>Info</th>");
            writer.Write("<th>Value</th>");
            writer.Write("</tr>");

            writer.Write("<tr><td>QueryExecutionCount</td><td>{0}</td></tr>", stats.QueryExecutionCount);
            writer.Write("<tr><td>PrepareStatementCount</td><td>{0}</td></tr>", stats.PrepareStatementCount);
            writer.Write("<tr><td>QueryCacheHitCount</td><td>{0}</td></tr>", stats.QueryCacheHitCount);
            writer.Write("<tr><td>QueryCacheMissCount</td><td>{0}</td></tr>", stats.QueryCacheMissCount);
            writer.Write("<tr><td>QueryCachePutCount</td><td>{0}</td></tr>", stats.QueryCachePutCount);

            writer.Write("<tr><td>QueryExecutionMaxTime</td><td>{0}</td></tr>", stats.QueryExecutionMaxTime);
            writer.Write("<tr><td>QueryExecutionMaxTime</td><td>{0}</td></tr>", stats.QueryExecutionMaxTimeQueryString);

            writer.Write("</table>");

            writer.Write("<table>");
            writer.Write("<tr>");
            writer.Write("<th>Query</th>");
            writer.Write("<th>Count</th>");
            writer.Write("<th>RowCount</th>");
            writer.Write("<th>AvgTime</th>");
            writer.Write("<th>MaxTime</th>");
            writer.Write("<th>MinTime</th>");
            writer.Write("<th>CacheHit</th>");
            writer.Write("<th>CacheMiss</th>");
            writer.Write("<th>CachePut</th>");
            writer.Write("</tr>");

            int count = 0;
            foreach (string query in SortQueries(stats)) {
                if (++count == 50) {
                    break;
                }
                QueryStatistics qstats = stats.GetQueryStatistics(query);
                writer.Write("<tr>");

                writer.Write("<td>{0}</td>", qstats.CategoryName);
                writer.Write("<td>{0}</td>", qstats.ExecutionCount);
                writer.Write("<td>{0}</td>", qstats.ExecutionRowCount);
                writer.Write("<td>{0}</td>", qstats.ExecutionAvgTime);
                writer.Write("<td>{0}</td>", qstats.ExecutionMaxTime);
                writer.Write("<td>{0}</td>", qstats.ExecutionMinTime);
                writer.Write("<td>{0}</td>", qstats.CacheHitCount);
                writer.Write("<td>{0}</td>", qstats.CacheMissCount);
                writer.Write("<td>{0}</td>", qstats.CachePutCount);

                writer.Write("</tr>");
            }

            writer.Write("</table>");
        }
        
        private IEnumerable<string> SortQueries(IStatistics stats)
        {
            List<string> list = new List<string>();

            list.AddRange(stats.Queries);
            list.Sort(delegate(string b, string a) { return stats.GetQueryStatistics(a).ExecutionCount.CompareTo(stats.GetQueryStatistics(b).ExecutionCount); });

            return list;
        }

        private static void WriteGeneric(HtmlTextWriter writer, NHibernate.Stat.IStatistics stats)
        {
            writer.Write("<h2>Generic Stats</h2>");
            writer.Write("<table>");
            writer.Write("<tr>");
            writer.Write("<th>Info</th>");
            writer.Write("<th>Value</th>");
            writer.Write("</tr>");
            
            writer.Write("<tr><td>Start Time</td><td>{0}</td></tr>", stats.StartTime);
            writer.Write("<tr><td>Connection Count</td><td>{0}</td></tr>", stats.ConnectCount);
            writer.Write("<tr><td>Connection Close Count</td><td>{0}</td></tr>", stats.CloseStatementCount);
            writer.Write("<tr><td>Session Open Count</td><td>{0}</td></tr>", stats.SessionOpenCount);
            writer.Write("<tr><td>Session Close Count</td><td>{0}</td></tr>", stats.SessionCloseCount);
            writer.Write("<tr><td>Flush Count</td><td>{0}</td></tr>", stats.FlushCount);
            writer.Write("<tr><td>Transaction Count</td><td>{0}</td></tr>", stats.TransactionCount);
            writer.Write("<tr><td>Successful Transaction Count</td><td>{0}</td></tr>", stats.SuccessfulTransactionCount);

            writer.Write("</table>");
        }

        private static void WriteCollections(HtmlTextWriter writer, NHibernate.Stat.IStatistics stats)
        {
            writer.Write("<h2>Collection Stats</h2>");
            writer.Write("<table>");
            writer.Write("<tr>");
            writer.Write("<th>Info</th>");
            writer.Write("<th>Value</th>");
            writer.Write("</tr>");

            writer.Write("<tr><td>Collection Fetch Count</td><td>{0}</td></tr>", stats.CollectionFetchCount);
            writer.Write("<tr><td>Collection Load Count</td><td>{0}</td></tr>", stats.CollectionLoadCount);
            writer.Write("<tr><td>Collection Recreate Count</td><td>{0}</td></tr>", stats.CollectionRecreateCount);
            writer.Write("<tr><td>Collection Remove Count</td><td>{0}</td></tr>", stats.CollectionRemoveCount);
            writer.Write("<tr><td>Collection Update Count</td><td>{0}</td></tr>", stats.CollectionUpdateCount);

            foreach (string role in stats.CollectionRoleNames){
                CollectionStatistics cstats = stats.GetCollectionStatistics(role);
                long check = cstats.FetchCount + cstats.LoadCount + cstats.RemoveCount + cstats.RecreateCount + cstats.UpdateCount;
                if (check == 0) {
                    continue;
                }
                string prettyName = GetCollectionShortName(role);
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", prettyName);
                writer.Write("<td>");
                writer.Write("FetchCount:{0}; ", cstats.FetchCount);
                writer.Write("LoadCount:{0}; ", cstats.LoadCount);
                writer.Write("RecreateCount:{0}; ", cstats.RecreateCount);
                writer.Write("RemoveCount:{0}; ", cstats.RemoveCount);
                writer.Write("UpdateCount:{0}; ", cstats.UpdateCount);
                writer.Write("<td>");
                writer.Write("<tr>");
            }
            
            writer.Write("</table>");
            
        }

        private static string GetCollectionShortName(string role)
        {
            int idx = role.IndexOf("Specialized");
            if (idx >= 0) {
                return role.Remove(0, idx);
            }
            return role;
        }

        #endregion Rendering
        
	};

}
