using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {
	public class BlogPreview: Control {

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {

            string dir = Path.Combine(Path.Combine(LanguageManager.LanguageDirectory, ".."), "Data");
            WriteFile(writer, dir, "BlogPreview","blog");
            WriteFile(writer, dir, "GazettePreview","gazette");
        }

        private void WriteFile(HtmlTextWriter writer, string dir, string fileName,string url)
        {
            string file = string.Format("{0}.html", fileName);
            file = Path.Combine(dir, file);
            if (!File.Exists(file)) {
                return;
            }

            string bottom = string.Format("<div class='defaultMessagesOptions'><a href='http://{0}.orionsbelt.eu'>{1}</a></div>", url, LanguageManager.Localize(fileName));
            writer.Write("<div class='defaultMessagesSmall'>");
            Border.RenderSpecialSmall(writer,string.Format("<h2>{0}</h2>", LanguageManager.Localize(fileName)),File.ReadAllText(file),bottom);
            writer.Write("</div>");
        }

        #endregion Events

    };
}

