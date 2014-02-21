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
using System.Text.RegularExpressions;

namespace OrionsBelt.WebUserInterface.Engine.Forum {
    public class ListPostsRenderer {

        #region Fields

        private static string listPostsKey = "ListPosts";
        private static Dictionary<Regex, string> replacements = new Dictionary<Regex, string>();
        
        #endregion Fields

        #region Private

        private static ForumThread GetThread(int threadId) {
            if (State.HasItems("CurrentThread")) {
                return (ForumThread)State.GetItems("CurrentThread");
            }

            IList<ForumThread> thread = Hql.StatelessQuery<ForumThread>("select t from SpecializedForumThread t inner join fetch t.PostsNHibernate inner join fetch t.TopicNHibernate where t.Id = :id", Hql.Param("id", threadId));
            if (thread.Count > 0) {
                return thread[0];
            }
            return null;
        }

        private static string GetCacheKey(int threadId) {
            return string.Format("{0}-{1}", listPostsKey, threadId);
        }

        private static string GetRanking(int ranking) {
            if(ranking < 100 ) {
                return LanguageManager.Localize("Weak");
            }
            if (ranking < 500) {
                return LanguageManager.Localize("Pacific");
            }
            if (ranking < 1000) {
                return LanguageManager.Localize("Agressive");
            }
            if (ranking < 2000) {
                return LanguageManager.Localize("Audacious");
            }
            if (ranking < 4000) {
                return LanguageManager.Localize("Fearless");
            }
            return LanguageManager.Localize("Legend");
        }

        private static string GetOwnerInfo(ForumPost post) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("<ul class='postOwner'>");
                writer.Write("<li>{0}</li>", WebUtilities.PlayerUrl(post.Owner.Name, post.Owner.Id));
                writer.Write("<li>{0}: {1}</li>", LanguageManager.Localize("Rank"), GetRanking(post.Owner.TotalPosts));
                writer.Write("<li>{0}: {1}</li>", LanguageManager.Localize("Posts"), post.Owner.TotalPosts);
                writer.Write("<li>{0}: {1}</li>", LanguageManager.Localize("Joined"), post.Owner.CreatedDate.ToString("dd/MM/yyyy"));
                writer.Write("</ul>");
                return writer.ToString();
            }
        }

        private static string GetPost(ForumPost post) {
            using (StringWriter writer = new StringWriter()) {
                RenderBanner(writer,post);
                writer.Write("<div class='postText'>{0}</div>", MakeReplacements(post.Text));

                return writer.ToString();
            }
        }

        private static string MakeReplacements(string text) {
            Regex regexObj;
            foreach (Regex regex in replacements.Keys) {
                text = regex.Replace(text, replacements[regex]);
            }
            return text;
        }

        private static void RenderBanner(StringWriter writer, ForumPost post) {
            writer.Write("<ul id='postBanner'>");
            if (PlayerUtils.Current.Id == post.Owner.Id || Utils.Principal.IsInRole("admin") ) {
                writer.Write("<li><img src='{0}' alt='{2}' title='{2}' onclick='Forum.showEditPost({1});'/></li>", ResourcesManager.GetForumImage("Edit.gif"), post.Id, LanguageManager.Localize("EditPost"));
                writer.Write("<li><img src='{0}' alt='{2}' title='{2}' onclick='Forum.erasePost({1});'/></li>", ResourcesManager.GetForumImage("Delete.gif"), post.Id, LanguageManager.Localize("ErasePost"));
            }
            writer.Write("</ul>");
        }

        private static string GetBreadCrum(ForumThread thread) {
            return string.Format("<div class='forumHeader'><a href='javascript:Forum.showTopics();'>{0}</a> » <a href='javascript:Forum.showTopic({1});'>{2} '{3}'</a> </div>", LanguageManager.Localize("ReturnTopics"),thread.Topic.Id, LanguageManager.Localize("ReturnThread"), thread.Topic.Title);
        }

        #endregion Private

        #region Renderers

        private static string RenderPosts(ForumThread thread, string key) {
            StringWriter writer = new StringWriter();
            writer.Write("<input type='hidden' name='threadId' id='threadId' value='{0}' />", thread.Id);
            writer.Write("<table class='newtable'>");
            
            List<ForumPost> ordered = (List<ForumPost>)thread.Posts;
            if (ordered.Count > 0) {
                ordered.Sort(ForumPostComparison.Instance);
                foreach (ForumPost post in ordered) {
                    RenderPost(writer, post);
                }
            } else {
                writer.Write("</table>");
            }
        
            writer.Write("</table>");

            string t = string.Format("{1}<h2>{0}</h2>", thread.Title, GetBreadCrum(thread));

            StringWriter swriter = new StringWriter();
            swriter.Write("<div id='forumThread'>");
            Border.RenderBig(swriter, t, writer.ToString());
            swriter.Write("</div>");

            string toReturn = swriter.ToString();
            HttpContext.Current.Cache.Add(key, toReturn, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return toReturn;
        }

        private static void RenderPost(TextWriter writer, ForumPost post) {
            writer.Write("<tr>");
            writer.Write("<td>{0}</td>", GetOwnerInfo(post));
            writer.Write("<td>{0}</td>", GetPost(post));
            writer.Write("</tr>");
        }

        private static void RenderNoPost(TextWriter writer, ForumPost post) {
            writer.Write("<tr>");
            writer.Write("<td colspan='2'>{0}</td>", LanguageManager.Localize("NoPosts"));
            writer.Write("</tr>");
        }

        #endregion Renderers

        #region Public

        public static void Render(TextWriter writer, int threadId) {
            ForumThread thread = GetThread(threadId);
            Render(writer, thread);
        }

        public static void Render(TextWriter writer, ForumThread thread) {
            using (IForumThreadPersistance persistance = Persistance.Instance.GetForumThreadPersistance()) {
                persistance.StartTransaction();
                thread.TotalViews += 1;
                persistance.Update(thread);

                ForumUtils.UpdateMarking(thread, false);

                persistance.CommitTransaction();
            }
            string key = GetCacheKey(thread.Id);

#if !DEBUG 
            if (State.HasCache(key)) {
                writer.Write(State.GetCache(key));
                return;
            }
#endif
            string content = RenderPosts(thread, key);
            writer.Write(content);
        }

        public static void RemovePostCache(int threadId) {
            State.Cache.Remove(GetCacheKey(threadId));
        }

        #endregion Public

        #region Constructor

        static ListPostsRenderer() {
            replacements[new Regex("\n")] = "<br/>";
            replacements[new Regex(@"\[b\](.+?)\[/b\]")] = "<strong>$1</strong>";
            replacements[new Regex(@"\[i\](.+?)\[/i\]")] = "<em>$1</em>";
            replacements[new Regex(@"\[u\](.+?)\[/u\]")] = "<u>$1</u>";
            replacements[new Regex(@"\[url\]([^\]]+)\[/url\]")] = "<a href=\"$1\">$1</a>";
            replacements[new Regex(@"\[img\]([^\]]+)\[/img\]")] = "<img src=\"$1\" />";           
            replacements[new Regex(":D")] = ResourcesManager.GetForumSmile("VeryHappy");
            replacements[new Regex(@":\)")] = ResourcesManager.GetForumSmile("Happy");
            replacements[new Regex(@":\(")] = ResourcesManager.GetForumSmile("Sad");
            replacements[new Regex(":o")] = ResourcesManager.GetForumSmile("Surprised");
            replacements[new Regex(":shock:")] = ResourcesManager.GetForumSmile("Shocked");
            replacements[new Regex(":s")] = ResourcesManager.GetForumSmile("Confused");
            replacements[new Regex(@"8\)")] = ResourcesManager.GetForumSmile("Cool");
            replacements[new Regex(":lol:")] = ResourcesManager.GetForumSmile("Laughing");
            replacements[new Regex(":x")] = ResourcesManager.GetForumSmile("Mad");
            replacements[new Regex(":P")] = ResourcesManager.GetForumSmile("Razz");
            replacements[new Regex(":red:")] = ResourcesManager.GetForumSmile("RedFace");
            replacements[new Regex(":cry:")] = ResourcesManager.GetForumSmile("Cry");
            replacements[new Regex(":twisted:")] = ResourcesManager.GetForumSmile("Twisted");
            replacements[new Regex(@":\|")] = ResourcesManager.GetForumSmile("Neutral");
            replacements[new Regex(":wink:")] = ResourcesManager.GetForumSmile("Wink");
        }

        #endregion Constructor

    }
}
