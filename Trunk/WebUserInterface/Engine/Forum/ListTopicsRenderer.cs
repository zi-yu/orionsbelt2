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
    public class ListTopicsRenderer {

        #region Fields

        private static string listTopicsPublicKey = "listTopicsPublic";
        private static string listTopicsPrivateKey = "listTopicsPrivate";
        
        #endregion Fields

        #region Private

        private static IList<ForumTopic> GetThreads() {
            if (State.HasCache(listTopicsPublicKey)) {
                return (IList<ForumTopic>)State.GetCache(listTopicsPublicKey);
            }

            IList<ForumTopic> topics = Hql.StatelessQuery<ForumTopic>("select t from SpecializedForumTopic t left join fetch t.ThreadsNHibernate where t.IsPrivate = 0 Order By t.CreatedDate asc");
            topics = Hql.Unify<ForumTopic>(topics);
#if !DEBUG
            HttpContext.Current.Cache.Add(listTopicsPublicKey, topics, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
#endif
            return topics;
        }

        private static IList<ForumTopic> GetPrivateThreads() {
            if (State.HasCache(listTopicsPrivateKey)) {
                return (IList<ForumTopic>)State.GetCache(listTopicsPrivateKey);
            }

            IList<ForumTopic> topics = Hql.StatelessQuery<ForumTopic>("select t from SpecializedForumTopic t left join fetch t.ThreadsNHibernate where t.IsPrivate = 1 and t.ForumRoles = :role Order By t.CreatedDate asc", Hql.Param("role", PlayerUtils.Current.ForumRole));
            topics = Hql.Unify<ForumTopic>(topics);
#if !DEBUG
            HttpContext.Current.Cache.Add(listTopicsPrivateKey, topics, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
#endif
            return topics;
        }

        #endregion Private

        #region Renderers

        private static void RenderPrivate(TextWriter writer) {
            if (string.IsNullOrEmpty(PlayerUtils.Current.ForumRole)) {
                return;
            }

            string content = RenderThreads(GetPrivateThreads(), "PrivateForum", listTopicsPrivateKey);            
            writer.Write(content);
        }

        private static void RenderPublic(TextWriter writer) {
            
            string content = RenderThreads(GetThreads(), "PublicForum", listTopicsPublicKey);
            writer.Write(content);
        }

        private static string RenderThreads(IList<ForumTopic> threads, string title, string key) {
            StringWriter writer = new StringWriter();
            writer.Write("<table class='newtable'>");
            RenderHeader(writer);

            if (threads.Count > 0) {
                foreach (ForumTopic thread in threads) {
                    RenderTopic(writer, thread);
                }
            } else {
                string colspan = Utils.Principal.IsInRole("admin")?"6":"5";
                writer.Write("<tr><td colspan='{1}'>{0}</td></tr>", LanguageManager.Localize("NoTopics"),colspan);
            }
            writer.Write("</table>");

            StringWriter swriter = new StringWriter();
            string t = string.Format("<h2>{0}</h2>", LanguageManager.Localize(title));
            swriter.Write("<div id='{0}'>", title.ToLower());
            Border.RenderBig(swriter, t, writer.ToString());
            swriter.Write("</div>");
            return swriter.ToString();
        }

        private static void RenderHeader(TextWriter writer) {
            writer.Write("<tr><th></th>");
            writer.Write("<th></th>");
            writer.Write("<th>{0}</th>",LanguageManager.Localize("Threads"));
            writer.Write("<th>{0}</th>", LanguageManager.Localize("Posts"));
            writer.Write("<th>{0}</th>", LanguageManager.Localize("LastPost"));
            if (Utils.Principal.IsInRole("admin")) {
                writer.Write("<th>{0}</th>", LanguageManager.Localize("Erase"));
            }
            writer.Write("</tr>");
        }

        private static void RenderTopic(TextWriter writer,ForumTopic topic) {
            writer.Write("<tr>");
            string readUnread = GetReadUnread(topic);
            writer.Write("<td><div class='{0}' title='{1}'></div></td>", readUnread, LanguageManager.Localize(readUnread));
            writer.Write("<td><p><a href='javascript:Forum.showTopic({2})'>{0}</a></p><p>{1}</p></td>", topic.Title, topic.Description,topic.Id);
            writer.Write("<td>{0}</td>", topic.TotalThreads);
            writer.Write("<td>{0}</td>", topic.TotalPosts);
            writer.Write("<td>{0}</td>", GetLastPost(topic.Id));
            if (Utils.Principal.IsInRole("admin")) {
                writer.Write("<td><img src='{0}' onclick='Forum.eraseTopic({1});'/></td>", ResourcesManager.GetImage("Error.gif"), topic.Id);
            }
            writer.Write("</tr>");
        }

        private static string GetReadUnread(ForumTopic topic) {
            if (topic.TotalThreads == 0) {
                return "forumRead";
            }

            foreach (ForumThread thread in topic.Threads) {
                foreach (ForumReadMarking marking in PlayerUtils.Current.Storage.ReadMarkings) {
                    if (marking.Thread.Id == thread.Id) {
                        return "forumRead";
                    }
                }
            }
            return string.Format("forumUnread{0}",PlayerUtils.Current.RaceInfo.Race);
        }

        private static string GetLastPost(int topicId) {
            IList<ForumPost> forumPost = Hql.StatelessQuery<ForumPost>(1, 1, "select p from SpecializedForumPost p inner join fetch p.OwnerNHibernate inner join fetch p.ThreadNHibernate t inner join t.TopicNHibernate th where th.Id = :id Order By p.CreatedDate desc", Hql.Param("id", topicId));
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

        public static void Render(TextWriter writer) {
            Render(writer, false);
        }

        public static void Render(TextWriter writer, bool renderPrivate) {
            if (renderPrivate) {
                RenderPrivate(writer);
            } else {
                RenderPublic(writer);
            }
        }

        public static void RemovePublicForumCache() {
            State.Cache.Remove(listTopicsPublicKey);
        }

        public static void RemovePrivateForumCache() {
            State.Cache.Remove(listTopicsPrivateKey);
        }

        #endregion Public

    }
}
