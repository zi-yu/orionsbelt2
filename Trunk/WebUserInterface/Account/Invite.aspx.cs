using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.Engine;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Account
{
    public class InvitePage : System.Web.UI.Page {

        #region Fields

        protected Button send;
        protected TextBox mail;
        protected TextBox message;
        protected Literal notification;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            send.Text = LanguageManager.Instance.Get("Send");
            send.Click += new EventHandler(send_Click);
        }

        void send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mail.Text)) {
                SetInvalidMailMessage();
                return;
            }

            string source = "noreply@orionsbelt.eu";
            string title = string.Format(LanguageManager.Instance.Get("InviteMailTitle"), Utils.Principal.DisplayName);
            string body =  string.Format(LanguageManager.Instance.Get("InviteMailBody"), Utils.Principal.DisplayName, message.Text, OrionsBelt.Generic.Server.Properties.BaseUrl, Utils.Principal.Id);

            try {
                MailSender.Send(mail.Text, source, title, body);
            } catch(FormatException) {
                SetInvalidMailMessage();
                return;
            }

            SetSuccessMessage();
        }

        #endregion Events

        #region Notifications

        private void SetInvalidMailMessage()
        {
            ErrorBoard.AddLocalizedMessage("InvalidMail");
        }

        private void SetSuccessMessage()
        {
            SuccessBoard.AddLocalizedMessage("GenericSuccess");
        }

        #endregion Notifications

    };
}
