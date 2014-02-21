using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.IO;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface.Engine.Forum {

    public class CreatePostRenderer {

       
        #region Render

        public static void Render(TextWriter writer) {
            string title = string.Format("<h2>{0}</h2>",LanguageManager.Localize("CreatePost"));

            StringWriter content = new StringWriter();
            content.Write("<div id='postText'><textarea id='postTextArea'></textarea></div>");
            content.Write("<div id='forumSmilies'>{0}</div>", ForumSmilies.GetSmilies());

            StringWriter bottom = new StringWriter();
            GenericRenderer.WriteRightLinkButton(bottom, "javascript:Forum.createPost()", LanguageManager.Localize("Create"));
            bottom.Write(" ");
            GenericRenderer.WriteRightLinkButton(bottom, "javascript:Forum.closeCreatePost()", LanguageManager.Localize("Close"));

            Border.RenderBig(writer, title, content.ToString(), bottom.ToString());
        }

        public static void Render(TextWriter writer, ForumPost post) {
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("EditPost"));

            StringWriter content = new StringWriter();
            content.Write("<div id='postText'><textarea id='postTextArea'>{0}</textarea></div>", post.Text);
            content.Write("<div id='forumSmilies'>{0}</div>", ForumSmilies.GetSmilies());

            StringWriter bottom = new StringWriter();
            GenericRenderer.WriteRightLinkButton(bottom, string.Format("javascript:Forum.editPost({0})",post.Id), LanguageManager.Localize("Edit"));
            bottom.Write(" ");
            GenericRenderer.WriteRightLinkButton(bottom, "javascript:Forum.closeEditPost()", LanguageManager.Localize("Close"));

            Border.RenderBig(writer, title, content.ToString(), bottom.ToString());
        }

        public static void RenderButton(TextWriter writer) {
            writer.Write("<div id='createPost'>");
            writer.Write("<input type='text' class='button' value='{0}' onclick='Forum.showCreatePost();'/>", LanguageManager.Localize("CreatePost"));
            writer.Write("</div>");
        }
        
        #endregion Render

      

    }
}
