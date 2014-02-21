using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.IO;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Engine;
using System.Web.Caching;

namespace OrionsBelt.WebUserInterface.Engine.Forum {
    public class ListThreadsRenderer {

        #region Fields

        private static string listThreadsKey = "ListThreads";
        
        #endregion Fields

        #region Private

        private static ForumTopic GetTopic(int topicId) {
            IList<ForumTopic> topic =  Hql.StatelessQuery<ForumTopic>("select t from SpecializedForumTopic t left join fetch t.ThreadsNHibernate th where t.Id = :id", Hql.Param("id", topicId));
            if(topic.Count > 0 ) {
                return topic[0];
            }
            return null;
        }

        private static string GetCacheKey(int topicId) {
            return string.Format("{0}-{1}", listThreadsKey,topicId);
        }

        private static string GetBreadCrum() {
            return string.Format("<div class='forumHeader'><a href='javascript:Forum.showTopics();'>{0}</a></div>", LanguageManager.Localize("ReturnTopics"));
        }

        #endregion Private

        #region Renderers

        private static string RenderThreads(ForumTopic topic) {
            StringWriter writer = new StringWriter();
            writer.Write("<input type='hidden' name='topicId' id='topicId' value='{0}' />", topic.Id);
            writer.Write("<table class='newtable'>");
            RenderHeader(writer);

            if (topic.Threads.Count > 0) {
                List<ForumThread> ordered = (List<ForumThread>)topic.Threads;
                ordered.Sort(ForumThreadComparison.Instance);

                foreach (ForumThread thread in ordered) {
                    RenderThread(writer, thread);
                }
            } else {
                string colspan = Utils.Principal.IsInRole("admin") ? "6" : "5";
                writer.Write("<tr><td colspan='{1}'>{0}</td></tr>", LanguageManager.Localize("NoThreads"), colspan);
            }
            writer.Write("</table>");

            string t = string.Format("{1}<h2>{0}</h2>", topic.Title,GetBreadCrum());

            StringWriter swriter = new StringWriter();
            swriter.Write("<div id='forumTopic'>");
            Border.RenderBig(swriter, t, writer.ToString());
            swriter.Write("</div>");

            return swriter.ToString();
        }

        private static void RenderHeader(TextWriter writer) {
            writer.Write("<tr><th></th><th></th>");
            writer.Write("<th>{0}</th>", LanguageManager.Localize("Posts"));
            writer.Write("<th>{0}</th>", LanguageManager.Localize("Views"));
            writer.Write("<th>{0}</th>", LanguageManager.Localize("LastPost"));
            if (Utils.Principal.IsInRole("admin")) {
                writer.Write("<th>{0}</th>", LanguageManager.Localize("Erase"));
            }
            writer.Write("</tr>");
        }

        private static void RenderThread(TextWriter writer, ForumThread thread) {
            writer.Write("<tr>");
            string readUnread = GetReadUnread(thread);
            writer.Write("<td><div class='{0}' title='{1}'></div></td>", readUnread, LanguageManager.Localize(readUnread));
            writer.Write("<td><a href='javascript:Forum.showThread({1})'>{0}</a></td>", thread.Title, thread.Id);
            writer.Write("<td>{0}</td>", thread.TotalReplies);
            writer.Write("<td>{0}</td>", thread.TotalViews);
            writer.Write("<td>{0}</td>", GetLastPost(thread.Id));
            if (Utils.Principal.IsInRole("admin")) {
                writer.Write("<td><img src='{0}' onclick='Forum.eraseThread({1});'/></td>", ResourcesManager.GetImage("Error.gif"), thread.Id);
            }
            writer.Write("</tr>");
        }

        private static string GetReadUnread(ForumThread thread) {
            foreach (ForumReadMarking marking in PlayerUtils.Current.Storage.ReadMarkings) {
                if (marking.Thread.Id == thread.Id) {
                    return "forumRead";
                }
            }
            return string.Format("forumUnread{0}", PlayerUtils.Current.RaceInfo.Race);
        }

        private static string GetLastPost(int threadId) {
            IList<ForumPost> forumPost = Hql.StatelessQuery<ForumPost>(1, 1, "select p from SpecializedForumPost p inner join fetch p.OwnerNHibernate inner join fetch p.ThreadNHibernate t where t.Id = :id Order By p.CreatedDate desc", Hql.Param("id", threadId));
            if (forumPost.Count > 0) {
                ForumPost post = forumPost[0];
                StringWriter writer = new StringWriter();
                string player = WebUtilities.PlayerSimpleUrl(post.Owner.Name, post.Owner.Id);
                writer.Write("<div class='lastPost'><p>{0} {1} {2} {3}</p>", LanguageManager.Localize("On"), post.CreatedDate.ToString("dd/MM/yyyy"), LanguageManager.Localize("At"), post.CreatedDate.ToString("HH:mm"));
                writer.Write("<p>{0} {1} <a href='#/Type_showThread/ThreadId_{3}/'><img src='{2}' /></a></p></div>", LanguageManager.Localize("By"), player, ResourcesManager.GetForumImage("Latest.gif"), post.Thread.Id);
                return writer.ToString();
            }
            return LanguageManager.Localize("NoPost");
        }

        #endregion Renderers

        #region Public

        public static void Render(TextWriter writer,int topicId) {
            string content = RenderThreads(GetTopic(topicId));
            writer.Write(content);
        }

        public static void RemoveThreadCache(int topicId) {
            State.Cache.Remove(GetCacheKey(topicId));
        }

        #endregion Public

    }
}
