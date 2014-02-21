using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class Style : Control {

		#region Fields

		private List<string> styles = null;
		private List<string> localizedStyles = null;
		protected static readonly string styleBase = "<link rel='stylesheet' type='text/css' media='screen' href='{0}?v={1}' />";
		
		#endregion Fields

		#region Properties

		public static Script Instance {
			get { return (Script) State.Items["Style"]; }
		}

        public static string GlobalEngineScript { 
            get {
                return string.Format("{0}/v{1}/Engine.css", ResourcesManager.StylesPath, ResourcesManager.ScriptsVersion, LanguageManager.CurrentLanguage);
            }
        }

		#endregion Properties

		#region Public

		public void RegisterStyle( string name ) {
			if( null == styles) {
				styles = new List<string>();
			}
			styles.Add(name);
		}

		public void RegisterLocalizedStyle(string name) {
			if (null == localizedStyles) {
				localizedStyles = new List<string>();
			}
			localizedStyles.Add(name);
		}

		#endregion Public

		#region Private

		protected void Write( HtmlTextWriter writer, string file ) {
            writer.Write(styleBase, ResourcesManager.GetStyle(file), ResourcesManager.ScriptsVersion);
		}

		protected void WriteLocalized(HtmlTextWriter writer, string file) {
            writer.Write(styleBase, ResourcesManager.GetLocalizedStyle(file), ResourcesManager.ScriptsVersion);
		}

		#endregion

		#region Control Events

		protected override void Render( HtmlTextWriter writer ) {
            WriteShortcutIcon(writer);
            WriteFixedScripts(writer);

			if (null != localizedStyles) {
				foreach (string style in localizedStyles) {
					Write(writer, style);	
				}
			}
		}

        private void WriteShortcutIcon(HtmlTextWriter writer)
        {
            writer.Write("<link rel='shortcut icon' href='{0}/favicon.ico' />", ResourcesManager.ImagesCommonPath);
        }

        private void WriteFixedScripts(HtmlTextWriter writer)
        {
#if DEBUG
            foreach (string script in scriptList)  {
                Write(writer, script);
            }
#else
            writer.Write("<link rel='stylesheet' type='text/css' media='screen' href='{0}' />", GlobalEngineScript);
#endif
        }

		#endregion Control Events

		#region Constructor

		public Style() {
			State.Items["Style"] = this;
		}

		#endregion Constructor

        #region Static

        private static List<string> scriptList = new List<string>();

        public static List<string> ScriptList {
            get { return scriptList;  }
        }

        static Style()
        {
            scriptList.Add("Style");
            scriptList.Add("Planets");
			scriptList.Add("Universe");
            scriptList.Add("Blackbird");
#if !DEBUG
            scriptList.Add("ReleaseOnly");
#endif
        }

        #endregion Static

	}
}
