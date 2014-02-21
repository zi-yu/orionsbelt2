using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;


namespace OrionsBelt.WebUserInterface.Controls {
	public class ChooseOpponent : ControlBase {

		#region Fields

		protected bool searchPrincipals = true;
		protected bool searchPlayers = false;
		private readonly TextBox opponent = new TextBox();
		private string titleToken;
        private string htmlId = "chooseOpponent";

		#endregion Fields

		#region Properties

		public bool SearchPrincipals {
			get { return searchPrincipals; }
			set {
				searchPlayers = false;
				searchPrincipals = value;
			}
		}

		public bool SearchPlayers {
			get { return searchPlayers; }
			set {
				searchPrincipals = false;
				searchPlayers = value;
			}
		}

		public string TitleToken {
			get { return titleToken; }
			set {titleToken = value;}
		}

        public string HtmlId {
            get { return htmlId; }
            set { htmlId = value; }
        }

		#endregion

		#region Private

		protected virtual void WriteExtendedContent() {}

		private void WriteContent() {
            Write("<div id='{0}' class='smallBorder'>", htmlId);
            Write("<div class='top'><h2>{0}</h2></div><div class='center'>", LanguageManager.Instance.Get(TitleToken));
            
            opponent.ID = "opponnent";
            Write("<p>");
            Controls.Add(opponent);
            Write("</p><p><span id='results'></span></p></div>");
            Write("<div class='bottom'>");
            Write("<input id='searchOpponent' class='button' type='button' onclick='Site.searchOpponent();' value='{0}'/>", LanguageManager.Instance.Get("Search"));
            Write("</div></div>");

            WriteExtendedContent();

			Page.ClientScript.RegisterHiddenField("opponentId", opponent.ClientID);
			Page.ClientScript.RegisterHiddenField("opponentUser", string.Empty);
			Page.ClientScript.RegisterHiddenField("searchType", searchPrincipals?"principal":"player");
		}
		
		#endregion Private

		#region Public

        public void SetValue(int id, string text)
        {
            //Page.Request.Form["opponentUser"] = id.ToString();
            opponent.Text = text;
        }

		public int GetSelectedPlayerId() {
			string o = Page.Request.Form["opponentUser"];
			int i;
			if( int.TryParse(o, out i ) ) {
				return i;
			}
			return 0;
		}

		#endregion

		#region Control Events

		protected override void OnInit( System.EventArgs e ) {
			WriteContent();			
		}

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            string name = Page.Request.QueryString["Name"];
            if (!string.IsNullOrEmpty(name) && !Page.IsPostBack) {
                opponent.Text = name;
            }
        }

		#endregion Control Events
	}
}