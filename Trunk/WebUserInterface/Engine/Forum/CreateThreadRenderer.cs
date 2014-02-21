using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.IO;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Engine.Forum {

    public class CreateThreadRenderer {

        #region Render

        public static void Render(TextWriter writer) {
            string title = string.Format("<h2>{0}</h2>",LanguageManager.Localize("CreateThread"));

            StringWriter content = new StringWriter();
            content.Write("<dl><dt>{0}</dt>", LanguageManager.Localize("Title"));
            content.Write("<dd><input id='threadTitle' type='text'/></dd>");
            content.Write("<dt>{0}</dt>", LanguageManager.Localize("Text"));
            content.Write("<dd><textarea id='threadDescription' ></textarea></dd></dl>");

            StringWriter bottom = new StringWriter();
            GenericRenderer.WriteRightLinkButton(bottom, "javascript:Forum.createThread()", LanguageManager.Localize("Create"));
            bottom.Write(" ");
            GenericRenderer.WriteRightLinkButton(bottom, "javascript:Forum.closeCreateThread()", LanguageManager.Localize("Close"));

            Border.RenderNormal(writer, title, content.ToString(), bottom.ToString());
        }

        public static void RenderButton(TextWriter writer) {
            writer.Write("<div id='createThread'>");
            writer.Write("<input type='text' class='button' value='{0}' onclick='Forum.showCreateThread();'/>", LanguageManager.Localize("CreateThread"));
            writer.Write("</div>");
        }
        
        #endregion Render

    }
}
