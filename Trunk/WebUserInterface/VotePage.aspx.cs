using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {
	public class VotePage : System.Web.UI.Page {
		protected Panel voteMessage;

		protected override void OnLoad(EventArgs e) {
			voteMessage.Controls.Add(new LiteralControl(string.Format(LanguageManager.Instance.Get("VoteForOrionsBeltMessage"), ResourcesManager.GetIconsImage("Orions"), LanguageManager.Instance.Get("Orions"))));
		}
	}
}
