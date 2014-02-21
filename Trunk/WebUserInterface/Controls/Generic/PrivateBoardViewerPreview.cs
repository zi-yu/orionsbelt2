using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PrivateBoardViewerPreview: PrivateBoardViewer {

        #region Events

        protected override void Render(HtmlTextWriter main)
        {
#if !DEBUG
            string key = string.Format("PrivateBoard-{0}-{1}-{2}", ReceiverType, ReceiverId,LanguageManager.CurrentLanguage);
            if (State.HasFileCache(key)) {
                main.Write(State.GetFileCache(key));
                return;
            }
#endif

            TextWriter writer = new StringWriter();
            writer.Write("<div class='defaultMessages'>");

            TextWriter header = new StringWriter();
            WriterHeader(header);

            TextWriter content = new StringWriter();
            WriterContent(content);

            TextWriter footer = new StringWriter();
            WriterFooter(footer,string.Empty);
    
            Border.RenderSpecialMedium(writer, header.ToString(), content.ToString(), footer.ToString());

            writer.Write("</div>");

            main.Write(writer.ToString());
#if !DEBUG
            State.SetFileCache(key, writer.ToString());
#endif
        }

        private void WriterFooter(TextWriter writer, string className) {
            if (ReceiverId != 0 && !string.IsNullOrEmpty(ReceiverType)) {
                writer.Write("<div class='defaultMessagesOptions{0}'>", className);
                writer.Write("<a href='{1}Alliance/Messages.aspx'>{0}</a></div>", LanguageManager.Instance.Get("ViewOrComment"), WebUtilities.ApplicationPath);
            }
        }

        private void WriterContent(TextWriter writer) {
            if (ReceiverId == 0 || string.IsNullOrEmpty(ReceiverType)) {
                string message = string.Format(LanguageManager.Instance.Get("NoAllianceMessage"), WebUtilities.ApplicationPath);
                writer.Write("<div id='noAlliance'>{0}</div>",message);
            } else {

                IList<PrivateBoard> messages = GetMessages(10);

                writer.Write("<ul id='allianceMessages'>");
                foreach (PrivateBoard board in messages) {
                    string msg = board.Message;
                    if (msg.Length > 130) {
                        msg = string.Format("{0}...", msg.Substring(0, 130));
                    }
                    writer.Write("<li><p>{1}</p><p>{0}</p></li>", msg, WebUtilities.WritePlayerWithAvatar(board.Sender, true, false));
                }

                writer.Write("</ul>");
            }
        }

        private void WriterHeader(TextWriter writer) {
            writer.Write("<h2>{0}</h2>", LanguageManager.Localize("AllianceMessages"));
            WriterFooter(writer, "Top");
        }

        #endregion Events

        #region Utils

        protected override IList<PrivateBoard> GetMessages(int total)
        {
            IList<PrivateBoard> messages = base.GetMessages(total);
            return messages;
        }

        #endregion Utils

    };
}
