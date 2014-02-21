using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class Script : Control {

		#region Fields

		private List<string> scripts = null;
		protected static readonly string scriptBase = "<script src='{0}?v={1}' type='text/javascript' ></script>";
		
		#endregion Fields

		#region Properties

		public static Script Instance {
			get { return (Script) State.Items["Script"]; }
		}

        public static string GlobalEngineScript { 
            get {
                return string.Format("{0}/v{1}/Engine-{2}.js", ResourcesManager.ScriptsPath, ResourcesManager.ScriptsVersion, LanguageManager.CurrentLanguage);
            }
        }

		#endregion Properties

		#region Public

		public void RegisterScript( string name ) {
			if( null == scripts) {
				scripts = new List<string>();
			}
			scripts.Add(name);
		}

		#endregion Public

		#region Private

		protected void Write( HtmlTextWriter writer, string file ) {
            writer.Write(scriptBase, ResourcesManager.GetScript(file), ResourcesManager.ScriptsVersion);
		}

		#endregion

		#region Control Events

		protected override void Render( HtmlTextWriter writer ) {
            WriteFixedScripts(writer);
			
			if( null != scripts ){
				foreach (string script in scripts) {
					Write(writer, script);	
				}
			}
		}

        private void WriteFixedScripts(HtmlTextWriter writer)
        {
#if DEBUG
            Write(writer, string.Format("I18N-{0}", LanguageManager.CurrentLanguage));
            foreach (string script in scriptList){
                Write(writer, script);
            }
#else
            writer.Write("<script src='{0}' type='text/javascript' ></script>", GlobalEngineScript);
#endif
        }

		#endregion Control Events

		#region Constructor

		public Script() {
			State.Items["Script"] = this;
		}

		#endregion Constructor

        #region Static

        private static List<string> scriptList = new List<string>();

        public static List<string> ScriptList {
            get { return scriptList;  }
        }

        static Script()
        {
            scriptList.Add("Mootools");
            scriptList.Add("Blackbird");
            scriptList.Add("HistoryManager");
            scriptList.Add("Site");
            scriptList.Add("Tutorial");
            scriptList.Add("AttackUtils");
            scriptList.Add("Information");
            scriptList.Add("Units");
            scriptList.Add("Utils");
            scriptList.Add("Item");
            scriptList.Add("RaiseError");
            scriptList.Add("Undo");
            scriptList.Add("Reset");
            scriptList.Add("Planet");
            scriptList.Add("Attack");
            scriptList.Add("Replay");
            scriptList.Add("Moves");
            scriptList.Add("Battle");
            scriptList.Add("Deploy");
            scriptList.Add("FillInformationOnly");
            scriptList.Add("Load");
            scriptList.Add("UniverseUtils");
            scriptList.Add("Menu");
            scriptList.Add("Fleet");
            scriptList.Add("Market");
            scriptList.Add("Ticker");
            scriptList.Add("Advertising");
			scriptList.Add("CustomElements");
            scriptList.Add("Prices");
			scriptList.Add("Quests");
			scriptList.Add("FleetCargo");
            scriptList.Add("Forum");
        }

        #endregion Static

    }
}
