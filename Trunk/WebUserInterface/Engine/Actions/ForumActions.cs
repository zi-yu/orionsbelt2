using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine.Forum;
using System.IO;
using System.Web;
using OrionsBelt.Core;
using System.Text.RegularExpressions;
using System;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebUserInterface.Controls;
using System.Collections.Generic;
using OrionsBelt.WebUserInterface.Exceptions;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {
	
	public class ForumActions : ActionBase {

        #region Private

        private static bool HasPermission(int ownerId) {
            return PlayerUtils.Current.Id == ownerId || IsAdmin();
        }

        private static bool IsAdmin() {
            return Utils.Principal.IsInRole("admin");
        }

        #endregion Private 

        #region Delegates

        private static void ShowCreateTopic() {
            using (StringWriter writer = new StringWriter()) {
                CreateTopicRenderer.Render(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void ShowCreateThread() {
            using (StringWriter writer = new StringWriter()) {
                CreateThreadRenderer.Render(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void ShowCreatePost() {
            using (StringWriter writer = new StringWriter()) {
                CreatePostRenderer.Render(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void ShowEditPost() {
            using (StringWriter writer = new StringWriter()) {
                int postId = ForumUtils.GetIntQueryString("PostId");
                ForumPost post = ForumUtils.GetForumPost(postId);
                CreatePostRenderer.Render(writer,post);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void ShowTopic() {
            using (StringWriter writer = new StringWriter()) {
                try {
                    ListThreadsRenderer.Render(writer, ForumUtils.GetIntQueryString("TopicId"));
                    CreateThreadRenderer.RenderButton(writer);
                }catch(Exception e){
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("InvalidText");
                    ErrorBoard.GetBoardHtml(writer);
                }
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void ShowTopics() {
            using (StringWriter writer = new StringWriter()) {
                ListTopicsRenderer.Render(writer);
                ListTopicsRenderer.Render(writer,true);
                CreateTopicRenderer.RenderButton(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void ShowThread() {
            using (StringWriter writer = new StringWriter()) {
                try {
                    ListPostsRenderer.Render(writer, ForumUtils.GetIntQueryString("ThreadId"));
                    CreatePostRenderer.RenderButton(writer);
                }catch(Exception e){
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("InvalidText");
                    ErrorBoard.GetBoardHtml(writer);
                }
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void CloseCreateTopic() {
            using (StringWriter writer = new StringWriter()) {
                CreateTopicRenderer.RenderButton(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void CloseCreateThread() {
            using (StringWriter writer = new StringWriter()) {
                CreateThreadRenderer.RenderButton(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void CloseCreatePost() {
            using (StringWriter writer = new StringWriter()) {
                CreatePostRenderer.RenderButton(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void CreateTopic() {
            using (StringWriter writer = new StringWriter()) {
                try {
                    ForumUtils.CreateForumTopic();
                } catch (Exception e) {
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("InvalidText");
                    ErrorBoard.GetBoardHtml(writer);
                }

                ListTopicsRenderer.RemovePublicForumCache();
                ListTopicsRenderer.Render(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void CreateThread() {
            using (StringWriter writer = new StringWriter()) {
                int topicId = ForumUtils.GetIntForm("TopicId");
                try {
                    ForumUtils.CreateForumThread(topicId);
                } catch (Exception e) {
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("InvalidText");
                    ErrorBoard.GetBoardHtml(writer);
                }

                ListThreadsRenderer.RemoveThreadCache(topicId);
                ListThreadsRenderer.Render(writer, topicId);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void CreatePost() {
            using (StringWriter writer = new StringWriter()) {
                int threadId = ForumUtils.GetIntForm("ThreadId");
                try {
                    ForumUtils.CreateForumPost(threadId);
                } catch (Exception e) {
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("InvalidText");
                    ErrorBoard.GetBoardHtml(writer);
                }

                ListPostsRenderer.RemovePostCache(threadId);
                ListPostsRenderer.Render(writer, threadId);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void EraseTopic() {
            using (StringWriter writer = new StringWriter()) {
                try {
                    if (IsAdmin()) {
                        ForumUtils.EraseForumTopic();
                    }
                } catch (Exception e) {
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("ErrorRemovingTopic");
                    ErrorBoard.GetBoardHtml(writer);
                }
                
                ListTopicsRenderer.Render(writer);
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }


        private static void EraseThread() {
            using (StringWriter writer = new StringWriter()) {
                int topicId = 0;
                try {
                    int threadId = ForumUtils.GetIntQueryString("ThreadId");
                    ForumThread thread = ForumUtils.GetForumThread(threadId);
                    if(HasPermission(thread.Owner.Id)) {
                        topicId = thread.Topic.Id;
                        ForumUtils.EraseForumThread(thread);
                        ListThreadsRenderer.RemoveThreadCache(topicId);
                        ListThreadsRenderer.Render(writer, topicId);
                    } else {
                        ErrorBoard.AddLocalizedMessage("CannotRemoveThread");
                        ErrorBoard.GetBoardHtml(writer);
                    }
                } catch (Exception e) {
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("ErrorRemovingThread");
                    ErrorBoard.GetBoardHtml(writer);
                }

                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void ErasePost() {
            using (StringWriter writer = new StringWriter()) {
                int threadId = 0;
                try {
                    int postId = ForumUtils.GetIntQueryString("PostId");
                    ForumPost post = ForumUtils.GetForumPost(postId);
                    if (HasPermission(post.Owner.Id)) {
                        ForumUtils.EraseForumPost(threadId, post);
                        ListPostsRenderer.Render(writer, post.Thread);
                    } else {
                        ErrorBoard.AddLocalizedMessage("CannotRemovePost");
                        ErrorBoard.GetBoardHtml(writer);
                    }
                } catch (Exception e) {
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("ErrorRemovingPost");
                    ErrorBoard.GetBoardHtml(writer);
                }
                
                HttpContext.Current.Response.Write(writer.ToString());
            }
        }

        private static void EditPost() {
            using (StringWriter writer = new StringWriter()) {
                try {
                    int postId = ForumUtils.GetIntForm("PostId");
                    ForumPost post = ForumUtils.GetForumPost(postId);
                    if (HasPermission(post.Owner.Id)) {
                        ForumUtils.EditForumPost(post);
                    }
                    ListPostsRenderer.RemovePostCache(post.Thread.Id);
                    ListPostsRenderer.Render(writer, post.Thread);
                } catch (Exception e) {
                    Logger.Error(LogType.Forum, e);
                    ErrorBoard.AddLocalizedMessage("InvalidText");
                    ErrorBoard.GetBoardHtml(writer);
                }
                HttpContext.Current.Response.Write(writer.ToString());
            }

        }
		#endregion Delegates

        #region Public

        public static void ProcessActions(string type) {
            if (actions.ContainsKey(type)) {
                actions[type]();
            }
        }

        #endregion

		#region Constructor

        static ForumActions() {
            actions["showCreateTopic"] = ShowCreateTopic;
            actions["showCreateThread"] = ShowCreateThread;
            actions["showCreatePost"] = ShowCreatePost;
            actions["showEditPost"] = ShowEditPost;
            actions["showTopic"] = ShowTopic;
            actions["showTopics"] = ShowTopics;
            actions["showThread"] = ShowThread;
            actions["closeCreateTopic"] = CloseCreateTopic;
            actions["closeCreateThread"] = CloseCreateThread;
            actions["closeCreatePost"] = CloseCreatePost;
            actions["closeEditPost"] = CloseCreatePost;
            actions["createTopic"] = CreateTopic;
            actions["createThread"] = CreateThread;
            actions["createPost"] = CreatePost;
            actions["eraseTopic"] = EraseTopic;
            actions["eraseThread"] = EraseThread;
            actions["erasePost"] = ErasePost;
            actions["editPost"] = EditPost;
            
        }

		#endregion Constructor
	
	}
}
