using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using System.Collections.Generic;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface {
	public partial class ResendConfirmation : Page {
		
		#region Events

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);
			send.Click += send_Click;
			send.Text = LanguageManager.Instance.Get("Send");
		}

		void send_Click(object sender, EventArgs e) {
			if (!Check(username) || !Check(mail)) {
				return;
			}
			IList<Principal> list = Hql.StatelessQuery<Principal>("select p from SpecializedPrincipal p where p.Name = :user and p.Email = :mail",Hql.Param("user",username.Text),Hql.Param("mail",mail.Text));
			if (list.Count == 0) {
                InformationBoard.AddLocalizedMessage("ForgotPasswordNoUserName");
				return;
			}

			Principal principal = list[0];
			if( principal.Approved ) {
                InformationBoard.AddLocalizedMessage("ResendConfirmationAlreadyApproved");
				return;
			}

			string source = "noreply@orionsbelt.eu";
			string title = string.Format(LanguageManager.Instance.Get("ResendConfirmationMailTitle"), principal.DisplayName);
			string body = string.Format(LanguageManager.Instance.Get("ResendConfirmationMailBody"), OrionsBelt.Generic.Server.Properties.BaseUrl, principal.DisplayName, principal.ConfirmationCode);

			MailSender.Send(principal.Email, source, title, body);
            SuccessBoard.AddLocalizedMessage("ResendConfirmationSent");
		}

		private static bool Check(TextBox mail) {
			if (string.IsNullOrEmpty(mail.Text) || !Regex.IsMatch(mail.Text, "^([a-z]|[A-Z]|@|-|.)+$")) {
                InformationBoard.AddLocalizedMessage("InvalidResendConfirmationMessageInput");
				return false;
			}

			return true;
		}

		#endregion Events
	}
}
