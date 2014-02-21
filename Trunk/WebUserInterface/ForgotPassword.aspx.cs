using System;
using System.Web.UI.WebControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Account;
using OrionsBelt.WebComponents;
using System.Text.RegularExpressions;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface {
    public partial class ForgotPasswordPage : System.Web.UI.Page {

        #region Fields

        protected TextBox username;
        protected TextBox mail;
        protected Button send;
        protected Literal message;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            send.Click += new EventHandler(send_Click);
            send.Text = LanguageManager.Instance.Get("Send");
        }

        void send_Click(object sender, EventArgs e)
        {
            if (!Check(username) || !Check(mail)) {
                return;
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                IList<Principal> list = persistance.TypedQuery("select p from SpecializedPrincipal p where p.Name = '{0}' and p.Email = '{1}'", username.Text, mail.Text);
                if (list.Count == 0) {
                    InformationBoard.AddLocalizedMessage("ForgotPasswordNoUserName");
                    return;
                }

                Principal principal = list[0];
                string newPass = Guid.NewGuid().ToString().Substring(0, 8);
                string source = "noreply@orionsbelt.eu";
                string title = string.Format(LanguageManager.Instance.Get("ForgotPasswordMailTitle"), principal.DisplayName);
                string body = string.Format(LanguageManager.Instance.Get("ForgotPasswordMailBody"), principal.DisplayName, newPass);

                MailSender.Send(principal.Email, source, title, body);
                principal.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newPass, "sha1");
                persistance.Update(principal);
                persistance.Flush();
                SuccessBoard.AddLocalizedMessage("ForgotPasswordSent");
            }
        }

        private bool Check(TextBox mail)
        {
            if (string.IsNullOrEmpty(mail.Text) || !Regex.IsMatch(mail.Text, "^([a-z]|[A-Z]|@|-|.)+$")) {
                InformationBoard.AddLocalizedMessage("InvalidForgotMessageInput");
                return false;
            }

            return true;
        }

        #endregion Events

    };
}
