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
    public class ChangePasswordPage : System.Web.UI.Page {

        #region Fields

        protected Button send;
        protected TextBox newPasswordConf;
        protected TextBox newPassword;
        protected TextBox current;
        protected Literal board;

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
            if (string.IsNullOrEmpty(current.Text) || string.IsNullOrEmpty(newPassword.Text) || string.IsNullOrEmpty(newPasswordConf.Text)
                || newPassword.Text.Length < 5 || newPassword.Text != newPasswordConf.Text || 
                FormsAuthentication.HashPasswordForStoringInConfigFile(current.Text, "sha1") != Utils.Principal.Password) {
                    InformationBoard.AddLocalizedMessage("ChangePasswordInstructions");
                    return;
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                Utils.Principal.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword.Text, "sha1");
                persistance.Update(Utils.Principal);
                persistance.Flush();
            }

            SuccessBoard.AddLocalizedMessage("ChangePasswordSuccess");
        }

        #endregion Events

    };
}
