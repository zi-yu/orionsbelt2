using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls {
	public class ChooseBot : ControlBase {

		#region Fields

		
		#endregion Fields

		#region Private

		#region Players

		private static IList<Principal> GetBots() {
			return Generals.List;
		}

		private void WriteBots() {
			IList<Principal> principals = GetBots();
			Write("<select id='botOpponent' onchange='Site.botOpponentChanged();' class='styled'>");
			Write("<option value=''></option>");
			foreach (Principal player in principals) {
				Write("<option value='{0}'>{1}</option>", player.Id.ToString(), player.Name);
			}
			Write("</select>");
		}

		#endregion Players


		private void WriteContent() {
            Write("<div id='chooseBot' class='smallBorder'><div class='top'><h2>{0}</h2></div><div class='center'>", LanguageManager.Instance.Get("ChooseBot"));
            WriteBots();
            Write("</div><div class='bottom'></div></div>");
		}
		
		#endregion Private

		#region Public

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

		#endregion Control Events
	}
}