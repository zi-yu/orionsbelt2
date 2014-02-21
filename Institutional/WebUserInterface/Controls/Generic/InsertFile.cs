using System.Web.UI;
using System.Web;
using System.IO;

namespace Institutional.WebUserInterface.Controls {

    public class InsertFile : Control
    {
        private string file;

        public string SourceFile
        {
            get { return file; }
            set { file = value; }
        }
	

		#region Control Events

		protected override void Render(HtmlTextWriter writer) {
            string path = HttpContext.Current.Request.MapPath(SourceFile);
            if (File.Exists(path)) {
                writer.Write(File.ReadAllText(path));
            } else {
                writer.Write("<!-- File {0} not found -->", path);
            }
		}

		#endregion Control Events

	};

}
