
using System.IO;


namespace OrionsBelt.WebUserInterface.Engine {
	public static class FramesHtml {

		public static void FrameHtmlTitleIcon(TextWriter writer, string title, string text, string icon) {
			FrameHtmlTitleIcon(writer, string.Empty, title, text, icon);
		}

		public static void FrameHtmlTitleIcon(TextWriter writer, string id, string title, string text, string icon) {
			writer.Write("<table id='{0}' class='frame'>", id);
			writer.Write("<tr><th class='frameTopLeft'></th><th colspan='2' class='frameTopCenter'>{0}</th><th class='frameTopRight'></th></tr>", title);
			writer.Write("<tr><td class='frameMiddleLeft'></td>");
			writer.Write("<td class='frameMiddleCenter messageImage'><img src='{0}'/></td>", icon);
			writer.Write("<td class='frameMiddleCenter messageContent'>");
			writer.Write(text);
			writer.Write("</td>");
			writer.Write("<td class='frameMiddleRight'></td></tr>");
			writer.Write("<tr><td class='frameBottomLeft'></td><td colspan='2' class='frameBottomCenter'></td><td class='frameBottomRight'></td></tr></table>");
		}

		public static void FrameHtmlIcon(TextWriter writer, string id, string title, string text, string icon) {
			writer.Write("<table id='{0}' class='frame'>", id);
			writer.Write("<tr><td class='frameTopLeft'></td><td colspan='2' class='frameTopCenter'>{0}</td><td class='frameTopRight'></td></tr>", title);
			writer.Write("<tr><td class='frameMiddleLeft'></td>");
			writer.Write("<td class='frameMiddleCenter messageImage'><img src='{0}'/></td>", icon);
			writer.Write("<td class='frameMiddleCenter messageContent'>");
			writer.Write(text);
			writer.Write("</td>");
			writer.Write("<td class='frameMiddleRight'></td></tr>");
			writer.Write("<tr><td class='frameBottomLeft'></td><td colspan='2' class='frameBottomCenter'></td><td class='frameBottomRight'></td></tr></table>");
		}

		public static void FrameHtmlTitleIconX(TextWriter writer, string id, string title, string text, string icon) {
			writer.Write("<table id='{0}' class='frame'>", id);
			writer.Write("<tr><th class='frameTopLeft'></th><th colspan='2' class='frameTopCenter'>{0}</th><th class='frameTopRightCross' onclick='Utils.hideFrame(\"" + id + "\");'></th></tr>", title);
			writer.Write("<tr><td class='frameMiddleLeft'></td>");
			writer.Write("<td class='frameMiddleCenter messageImage'><img src='{0}'/></td>", icon);
			writer.Write("<td class='frameMiddleCenter messageContent'>");
			writer.Write(text);
			writer.Write("</td>");
			writer.Write("<td class='frameMiddleRight'></td></tr>");
			writer.Write("<tr><td class='frameBottomLeft'></td><td colspan='2' class='frameBottomCenter'></td><td class='frameBottomRight'></td></tr></table>");
		}

		public static void FrameHtml(TextWriter writer,string text) {
			FrameHtml(writer, string.Empty, text);
		}

		public static void FrameHtml(TextWriter writer, string id, string text) {
			writer.Write("<table id='{0}' class='frame'>", id);
			writer.Write("<tr><td class='frameTopLeft'></td><td class='frameTopCenter'></td><td class='frameTopRight'></td></tr>");
			writer.Write("<tr><td class='frameMiddleLeft'></td>");
			writer.Write("<td class='frameMiddleCenter messageContent'>");
			writer.Write(text);
			writer.Write("</td>");
			writer.Write("<td class='frameMiddleRight'></td></tr>");
			writer.Write("<tr><td class='frameBottomLeft'></td><td class='frameBottomCenter'></td><td class='frameBottomRight'></td></tr></table>");
		}

		public static void FrameHtmlTitle(TextWriter writer, string id, string title, string text) {
			writer.Write("<table id='{0}' class='frame'>", id);
			writer.Write("<tr><th class='frameTopLeft'></th><th class='frameTopCenter'>{0}</th><th class='frameTopRight'></th></tr>", title);
			writer.Write("<tr><td class='frameMiddleLeft'></td>");
			writer.Write("<td class='frameMiddleCenter messageContent'>");
			writer.Write(text);
			writer.Write("</td>");
			writer.Write("<td class='frameMiddleRight'></td></tr>");
			writer.Write("<tr><td class='frameBottomLeft'></td><td class='frameBottomCenter'></td><td class='frameBottomRight'></td></tr></table>");
		}

		public static void FrameHtmlTitleX(TextWriter writer, string id, string title, string text) {
			FrameHtmlTitleX(writer, id, title, text, "Utils.hideFrame(\"" + id + "\");");
		}

		public static void FrameHtmlTitleX(TextWriter writer, string id, string title, string text, string closeCallback) {
			writer.Write("<table id='{0}' class='frame'>", id);
			writer.Write("<tr><th class='frameTopLeft'></th><th class='frameTopCenter'>{0}</th><th class='frameTopRightCross' onclick='{1}'></th></tr>", title, closeCallback);
			writer.Write("<tr><td class='frameMiddleLeft'></td>");
			writer.Write("<td class='frameMiddleCenter messageContent'>");
			writer.Write(text);
			writer.Write("</td>");
			writer.Write("<td class='frameMiddleRight'></td></tr>");
			writer.Write("<tr><td class='frameBottomLeft'></td><td class='frameBottomCenter'></td><td class='frameBottomRight'></td></tr></table>");
		}

	}
}
