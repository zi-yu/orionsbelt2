using System;
using System.IO;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Shows entity messages
    /// </summary>
	public class EmpireMessages : Control {

		#region Private

		private static string GetTime(IMessage message) {
            return TimeFormatter.GetFormattedTimeSmall(DateTime.Now - message.Date);
		}

		private static string ConvertMessage(IMessage message) {
			message.LanguageTranslator = LanguageParameterTranslator.Instance;
			return message.Translate();
		}

    	private static void WriteMessages(TextWriter writer) {
			writer.Write("<ul id='empireMessages'>");
			foreach (IMessage message in GetMessages()) {
				writer.Write("<li>");
				writer.Write("<div class='{1}Message'>{0}</div>", ConvertMessage(message), message.Importance);
				writer.Write("<div class='time'>{0}</div>", GetTime(message));
				writer.Write("</li>");
			}
			writer.Write("<ul>");
		}

		private static System.Collections.Generic.IEnumerable<IMessage> GetMessages() {
			return Messenger.ConvertMessages(PlayerUtils.GetPlayerMessages(PlayerUtils.Current,13));
		}
		
		#endregion Private

        #region Rendering

        protected override void Render(HtmlTextWriter writer){
            writer.Write("<div class='defaultMessages'>");
            StringWriter header = new StringWriter();
        	WriteHeader(header);

            StringWriter content = new StringWriter();
        	WriteMessages(content);

            StringWriter footer = new StringWriter();
            WriteFooter(footer);

            Border.RenderSpecialMedium(writer, header.ToString(), content.ToString(), footer.ToString());
            writer.Write("</div>");
        }

		private static void WriteHeader(TextWriter writer) {
			writer.Write("<h2>{0}</h2>", LanguageManager.Localize("EmpireMessages"));
            writer.Write("<div class='defaultMessagesOptionsTop'>");
            writer.Write("<a href='{0}Feeds/PlayerMessages.ashx?Player={1}&Token={2}'>RSS</a>",
                    WebUtilities.ApplicationPath,
                    PlayerUtils.Current.Id,
                    PlayerUtils.GetSecretCode(PlayerUtils.Current)
            );
            writer.Write(" | <a id='deleteAllMessages' href='javascript:Utils.deleteAllMessages();'>{0}</a></div>", LanguageManager.Localize("DeleteAll"));
		}

        private static void WriteFooter(TextWriter writer) {
            writer.Write("<div class='defaultMessagesOptions'>");
            writer.Write("<a href='{0}Feeds/PlayerMessages.ashx?Player={1}&Token={2}'>RSS</a>",
                    WebUtilities.ApplicationPath,
                    PlayerUtils.Current.Id,
                    PlayerUtils.GetSecretCode(PlayerUtils.Current)
            );
            writer.Write(" | <a id='deleteAllMessages' href='javascript:Utils.deleteAllMessages();'>{0}</a></div>", LanguageManager.Localize("DeleteAll"));
        }

		#endregion Rendering

    };
}

