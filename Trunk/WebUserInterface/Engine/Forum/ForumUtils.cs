using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Exceptions;
using System.Text.RegularExpressions;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine.Forum {
    public static class ForumUtils {

        #region Private

        private static string SafetyReplacements(string value) {
            value = value.Replace("&", "&#38;");
            value = value.Replace("'", "&#39;");
            value = value.Replace("<", "&#60;");
            value = value.Replace(">", "&#62;");
            value = value.Replace("?", "&#63;");
            return value;
        }

        private static void UpdateMarking(ForumThread thread) {
            using (IForumReadMarkingPersistance persistanceForumRead = Persistance.Instance.GetForumReadMarkingPersistance()) {
                persistanceForumRead.Delete("from SpecializedForumReadMarking m where m.PlayerNHibernate.Id = {0} and m.ThreadNHibernate.Id = {1}", PlayerUtils.Current.Id, thread.Id);

                ForumReadMarking marking = persistanceForumRead.Create();
                marking.Thread = thread;
                PlayerUtils.Current.PrepareStorage();
                PlayerUtils.Current.UpdateStorage();
                marking.Player = PlayerUtils.Current.Storage;
                marking.LastRead = DateTime.Now;
                persistanceForumRead.Update(marking);
            }
        }

        #endregion Private

        #region Public

        public static string GetQueryString(string key) {
            string value = HttpContext.Current.Request.QueryString[key];
            if (!string.IsNullOrEmpty(value)) {
                return SafetyReplacements(value);
            }
            throw new Exception(string.Format("Invalid Text Entered: {0}", value));
        }

        public static int GetIntQueryString(string key) {
            string value = HttpContext.Current.Request.QueryString[key];
            if (!string.IsNullOrEmpty(value)) {
                int v;
                if (int.TryParse(value, out v)) {
                    return v;
                }
            }
            throw new Exception(string.Format("Invalid Integer passed: {0}", value));
        }

        public static string GetForm(string key) {
            string value = HttpContext.Current.Request.Form[key];
            if (!string.IsNullOrEmpty(value)) {
                return SafetyReplacements(value);
            }
            throw new Exception(string.Format("Invalid Text Entered: {0}", value));
        }

        public static int GetIntForm(string key) {
            string value = HttpContext.Current.Request.Form[key];
            if (!string.IsNullOrEmpty(value)) {
                int v;
                if (int.TryParse(value, out v)) {
                    return v;
                }
            }
            throw new Exception(string.Format("Invalid Integer passed: {0}", value));
        }


        public static ForumTopic GetForumTopic(int topicId) {
            IList<ForumTopic> list = Hql.StatelessQuery<ForumTopic>("select t from SpecializedForumTopic t where t.Id = :id", Hql.Param("id", topicId));
            if (list.Count > 0) {
                return list[0];
            }
            throw new InvalidTopicException(topicId);
        }

        public static ForumTopic GetForumTopicComplete(int topicId) {
            IList<ForumTopic> list = Hql.StatelessQuery<ForumTopic>("select t from SpecializedForumTopic t left join fetch t.ThreadsNHibernate where t.Id = :id", Hql.Param("id", topicId));
            if (list.Count > 0) {
                return list[0];
            }
            throw new InvalidTopicException(topicId);
        }

        public static ForumThread GetForumThread(int threadId) {
            IList<ForumThread> list = Hql.StatelessQuery<ForumThread>("select t from SpecializedForumThread t inner join fetch t.TopicNHibernate left join fetch t.PostsNHibernate where t.Id = :id", Hql.Param("id", threadId));
            if (list.Count > 0) {
                return list[0];
            }
            throw new InvalidThreadException(threadId);
        }

        public static ForumPost GetForumPost(int postId) {
            IList<ForumPost> list = Hql.StatelessQuery<ForumPost>("select p from SpecializedForumPost p inner join fetch p.ThreadNHibernate t inner join fetch t.TopicNHibernate where p.Id = :id", Hql.Param("id", postId));
            if (list.Count > 0) {
                return list[0];
            }
            throw new InvalidPostException(postId);
        }

        public static void UpdateMarking(ForumThread thread,bool commit) {
            using (IForumReadMarkingPersistance persistanceForumRead = Persistance.Instance.GetForumReadMarkingPersistance()) {
                if (commit) {
                    persistanceForumRead.StartTransaction();
                }
                ForumReadMarking marking = persistanceForumRead.Create();
                marking.Thread = thread;
                PlayerUtils.Current.PrepareStorage();
                PlayerUtils.Current.UpdateStorage();
                marking.Player = PlayerUtils.Current.Storage;
                marking.LastRead = DateTime.Now;
                persistanceForumRead.Update(marking);
                if (commit) {
                    persistanceForumRead.CommitTransaction(); ;
                }
            }
        }


        public static void CreateForumTopic() {
            using (IForumTopicPersistance persistance = Persistance.Instance.GetForumTopicPersistance()) {
                persistance.StartTransaction();
                ForumTopic t = persistance.Create();
                t.Title = GetForm("Name");
                t.Description = GetForm("Description");
                persistance.Update(t);

                persistance.CommitTransaction();
            }
        }

        public static void CreateForumThread(int topicId) {
            using (IForumThreadPersistance persistance = Persistance.Instance.GetForumThreadPersistance()) {
                persistance.StartTransaction();
                ForumThread t = persistance.Create();
                t.Title = GetForm("Title");
                t.Owner = PlayerUtils.Current.Storage;
                t.Topic = GetForumTopic(topicId);
                t.TotalReplies += 1;
                persistance.Update(t);

                using (IForumTopicPersistance persistanceTopic = Persistance.Instance.GetForumTopicPersistance()) {
                    t.Topic.TotalPosts += 1;
                    t.Topic.TotalThreads += 1;
                    persistanceTopic.Update(t.Topic);
                }

                using (IForumPostPersistance persistancePost = Persistance.Instance.GetForumPostPersistance()) {
                    ForumPost post = persistancePost.Create();
                    post.Text = GetForm("Description");
                    post.Owner = PlayerUtils.Current.Storage;
                    post.Thread = t;
                    persistancePost.Update(post);
                }

                using (IPlayerStoragePersistance persistancePlayer = Persistance.Instance.GetPlayerStoragePersistance()) {
                    PlayerUtils.Current.TotalPosts += 1;
                    PlayerUtils.Current.PrepareStorage();
                    PlayerUtils.Current.UpdateStorage();
                    persistancePlayer.Update(PlayerUtils.Current.Storage);
                }

                persistance.CommitTransaction();
            }
        }

        public static void CreateForumPost(int threadId) {
            using (IForumThreadPersistance persistance = Persistance.Instance.GetForumThreadPersistance()) {
                persistance.StartTransaction();
                ForumThread t = GetForumThread(threadId);

                UpdateMarking(t);
                
                t.TotalReplies += 1;
                State.SetItems("CurrentThread",t);
                persistance.Update(t);

                using (IForumTopicPersistance persistanceTopic = Persistance.Instance.GetForumTopicPersistance()) {
                    t.Topic.TotalPosts += 1;
                    persistanceTopic.Update(t.Topic);
                }

                
                using (IPlayerStoragePersistance persistancePlayer = Persistance.Instance.GetPlayerStoragePersistance()) {
                    PlayerUtils.Current.TotalPosts += 1;
                    PlayerUtils.Current.UpdateStorage();
                    persistancePlayer.Update(PlayerUtils.Current.Storage);
                }

                using (IForumPostPersistance persistancePost = Persistance.Instance.GetForumPostPersistance()) {
                    ForumPost post = persistancePost.Create();
                    post.Text = GetForm("Text");
                    post.Owner = PlayerUtils.Current.Storage;
                    post.Thread = t;
                    t.Posts.Add(post);
                    persistancePost.Update(post);
                }

                persistance.CommitTransaction();
            }
        }

        public static void EditForumPost(ForumPost post) {
            using (IForumPostPersistance persistance = Persistance.Instance.GetForumPostPersistance()) {
                persistance.StartTransaction();
                post.Text = GetForm("Text");
                post.Owner = PlayerUtils.Current.Storage;
                persistance.Update(post);
                persistance.CommitTransaction();
            }
        }

        public static void EraseForumTopic() {
            int topicId = GetIntQueryString("TopicId");
            ForumTopic topic = GetForumTopicComplete(topicId);

            using (IForumTopicPersistance persistanceTopic = Persistance.Instance.GetForumTopicPersistance()) {
                persistanceTopic.StartTransaction();

                foreach (ForumThread t in topic.Threads) {
                    using (IForumThreadPersistance persistance = Persistance.Instance.GetForumThreadPersistance()) {
                        using (IForumPostPersistance persistancePost = Persistance.Instance.GetForumPostPersistance()) {
                            using (IPlayerStoragePersistance persistancePlayer = Persistance.Instance.GetPlayerStoragePersistance()) {
                                foreach (ForumPost post in t.Posts) {
                                    post.Owner.TotalPosts -= 1;
                                    persistancePlayer.Update(post.Owner);
                                    persistancePost.Delete(post);
                                }
                            }
                        }
                        using (IForumReadMarkingPersistance persistancePost = Persistance.Instance.GetForumReadMarkingPersistance()) {
                            foreach (ForumReadMarking marking in t.ReadMarkings) {
                                persistancePost.Delete(marking);
                            }
                        }

                        persistance.Delete(t);
                    }
                }

                persistanceTopic.Delete(topic);
                persistanceTopic.CommitTransaction();
                ListTopicsRenderer.RemovePublicForumCache();
            }
        }

        public static void EraseForumThread(ForumThread thread) {
            using (IForumThreadPersistance persistance = Persistance.Instance.GetForumThreadPersistance()) {
                persistance.StartTransaction();

                using (IForumPostPersistance persistancePost = Persistance.Instance.GetForumPostPersistance()) {
                    using (IPlayerStoragePersistance persistancePlayer = Persistance.Instance.GetPlayerStoragePersistance()) {
                        foreach (ForumPost post in thread.Posts) {
                            persistancePost.Delete(post);
                            thread.Topic.TotalPosts -= 1;
                            post.Owner.TotalPosts -= 1;
                            persistancePlayer.Update(post.Owner);
                        
                        }
                    }
                }
                using (IForumReadMarkingPersistance persistancePost = Persistance.Instance.GetForumReadMarkingPersistance()) {
                    foreach (ForumReadMarking marking in thread.ReadMarkings) {
                        persistancePost.Delete(marking);
                    }
                }
                using (IForumTopicPersistance persistanceTopic = Persistance.Instance.GetForumTopicPersistance()) {
                    thread.Topic.TotalThreads -= 1;
                    persistanceTopic.Update(thread.Topic);
                }

                persistance.Delete(thread);
                persistance.CommitTransaction();
            }
        }

        public static void EraseForumPost(int threadId, ForumPost post) {
            using (IForumThreadPersistance persistance = Persistance.Instance.GetForumThreadPersistance()) {
                persistance.StartTransaction();

                using (IForumTopicPersistance persistanceTopic = Persistance.Instance.GetForumTopicPersistance()) {
                    post.Thread.Topic.TotalPosts -= 1;
                    persistanceTopic.Update(post.Thread.Topic);
                }

                using (IPlayerStoragePersistance persistancePlayer = Persistance.Instance.GetPlayerStoragePersistance()) {
                    post.Owner.TotalPosts -= 1;
                    persistancePlayer.Update(post.Owner);
                }
                
                using (IForumPostPersistance persistancePost = Persistance.Instance.GetForumPostPersistance()) {
                    persistancePost.Delete(post);
                }

                post.Thread.TotalReplies -= 1;
                persistance.Update(post.Thread);

                persistance.CommitTransaction();
                ListPostsRenderer.RemovePostCache(threadId);
            }
        }

        #endregion Public

    }
}
