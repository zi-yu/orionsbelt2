using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

	public abstract class MessageBoard : Control {

		#region Fields

		protected List<string> messages = new List<string>();
		protected string title = null;
		protected string image = null;
        protected bool isInfo = false;

		#endregion

		#region Private

		protected static void SearchSimilarControls<T>( string keyS,ControlCollection controls) {
			if (!State.HasItems(keyS)) {
				foreach (Control c in controls) {
					if (c is T) {
						State.SetItems(keyS, c);
						continue;
					}
					SearchSimilarControls<T>(keyS, c.Controls);
				}
			}
		}
		
		#endregion Private

		#region Public

		public string Title {
			set {
                string classname = isInfo ? "green" : "red";
                title = string.Format("<h2 class='{1}'>{0}</h2>",value,classname); }
			get {
				return title;
			}
		}
		
		public void InsertMessage( string message ) {
			messages.Add( message );
		}

		public void InsertLocalizedMessage( string k) {
			messages.Add( LanguageManager.Instance.Get(k) );
		}
		
		public void InsertLocalizedMessage( string k, params string[] parameters) {
			messages.Add( string.Format(LanguageManager.Instance.Get(k),parameters) );
		}

		public void GetBoardHtml(TextWriter writer) {
            if (messages == null || messages.Count == 0) {
                return;
            }

            Border.RenderByRaceInformation(writer, Title, GetMessages());
			//FramesHtml.FrameHtmlTitleIcon(writer, "informationTable", Title, GetMessages(), ResourcesManager.GetImage(image));
			messages.Clear();
		}

		#endregion Public

		#region Events

		protected override void Render(HtmlTextWriter writer) {
			if( messages.Count == 0  ) {
				Visible = false;
				return;
			}
			GetBoardHtml(writer);
		}

		private string GetMessages() {
			StringWriter writer = new StringWriter();
			writer.Write("<ul>");
			foreach( string message in messages ) {
				writer.Write("<li>{0}</li>", message);
			}
			writer.Write("</ul>");
			return writer.ToString();
		}
		
		#endregion

        #region Static

        public static string GetSimpleBoardHtml(string content)
        {
            TextWriter writer = new StringWriter();
            string title = string.Format("<h2><span class='green'>{0}</span></h2>",LanguageManager.Instance.Get("Information"));
            Border.RenderBig("messageBoard", writer, title, string.Empty, content);
            return writer.ToString();
        }

        #endregion Static

        #region Construtor


        #endregion Constructor
    }
}
