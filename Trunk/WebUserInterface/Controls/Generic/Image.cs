using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class Image : Control {

		#region Fields

		private string title;
		private string alt;
		private string src;
		private string className;
		private bool localized;
        private bool serverRoot;
        private bool isCommon = true;

		#endregion Fields

		#region Properties

		public string Title {
			get { return title; }
			set { title = value; }
		}

		public string Alt {
			get { return alt; }
			set { alt = value; }
		}

		public string Src {
			get { return src; }
			set { src = value; }
		}

		public string Class {
			get { return className; }
			set { className = value; }
		}

		public bool Localized {
			get { return localized; }
			set { localized = value; }
		}

        public bool ServerRoot { 
            get { return serverRoot; }
            set { serverRoot = value; }
        }

	    public bool IsCommon
	    {
	        get { return isCommon; }
	        set { isCommon = value; }
	    }

	    #endregion Properties

		#region Private

		private static void WriteProperty(HtmlTextWriter writer, string name, string value) {
			if (!string.IsNullOrEmpty(value)) {
				writer.Write(" {0}='{1}' ", name, value);
			}
		}

		#endregion Private

		#region Control Events

		protected override void Render(HtmlTextWriter writer) {
			if (string.IsNullOrEmpty(Src) ) {
				throw new UIException("Src is needed @ Image Control");
			}

			if (Localized) {
				writer.Write("<img src='{0}' ", ResourcesManager.GetLocalizedImage(Src));	
			}else {
                if (ServerRoot) {
                    writer.Write("<img src='{0}{1}' ", WebUtilities.ApplicationPath, Src);
                } else {
                    if (IsCommon)
                    {
                        writer.Write("<img src='{0}' ", ResourcesManager.GetImage(Src));
                    }else
                    {
                        writer.Write("<img src='{0}' ", ResourcesManager.GetIntergalacticImage(Src));
                    }
                }
			}
			
			WriteProperty(writer, "title", Title);
			WriteProperty(writer, "alt", Alt);
			WriteProperty(writer, "class", Class);
			writer.Write("/>");
		}

		#endregion Control Events
	}
}
