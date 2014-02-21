using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.IO;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Engine.Forum {

    public class CreateTopicRenderer {

        #region Render

        public static void Render(TextWriter writer) {
            string title = string.Format("<h2>{0}</h2>",LanguageManager.Localize("CreateTopic"));

            StringWriter content = new StringWriter();
            content.Write("<dl><dt>{0}</dt>", LanguageManager.Localize("Name"));
            content.Write("<dd><input id='topicName' type='text'/></dd>");
            content.Write("<dt>{0}</dt>", LanguageManager.Localize("Description"));
            content.Write("<dd><textarea id='topicDescription' ></textarea></dd></dl>");

            StringWriter bottom = new StringWriter();
            GenericRenderer.WriteRightLinkButton(bottom, "javascript:Forum.createTopic()", LanguageManager.Localize("Create"));
            bottom.Write(" ");
            GenericRenderer.WriteRightLinkButton(bottom, "javascript:Forum.closeCreateTopic()", LanguageManager.Localize("Close"));

            Border.RenderNormal(writer, title, content.ToString(), bottom.ToString());
        }

        public static void RenderButton(TextWriter writer) {
            writer.Write("<div id='createTopic'>");
            writer.Write("<input type='text' class='button' value='{0}' onclick='Forum.showCreateTopic();'/>", LanguageManager.Localize("CreateTopic"));
            writer.Write("</div>");
        }
        
        #endregion Render

    }
}
