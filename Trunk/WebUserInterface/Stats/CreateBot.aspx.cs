using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {
	public partial class CreateBot : Page {

		protected override void OnInit(System.EventArgs e) {
			register.Click += Register_Click;
			register.Text = LanguageManager.Instance.Get("CreateBot");
		}

		protected void Register_Click(object sender, System.EventArgs e) {
			if( Page.IsValid ) {
				Principal p = WebUtilities.OBUserProvider.CreateBotUser(botName.Text, botUrl.Text);
				using( IBotCredentialPersistance persistance = Persistance.Instance.GetBotCredentialPersistance()) {
					BotCredential botCredential = persistance.Create();
					botCredential.BotId = p.Id;
					botCredential.Name = p.Name;
					botCredential.VerificationCode = p.Password;
					botCredential.Server = OrionsBelt.Generic.Server.Properties.BaseUrl;
					persistance.Update(botCredential);
				}

				Persistance.Flush();
				InformationBoard.AddLocalizedMessage("BotCreated");
			}else {
				ErrorBoard.AddLocalizedMessage("BotNotCreated");
			}
		}
	}
}
