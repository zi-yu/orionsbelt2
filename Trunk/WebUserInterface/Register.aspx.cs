using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using System;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {
	public class Register: Page {

		#region Fields

		
		protected TextBox userName;
		protected TextBox password;
		protected TextBox confirmPassword;
		protected TextBox email;
		protected CheckBox terms;
		protected Button register;
		protected Literal errorMessage;

		protected RequiredFieldValidator userNameRequired;
		protected RequiredFieldValidator passwordRequired;
		protected RequiredFieldValidator confirmPasswordRequired;
		protected RequiredFieldValidator emailRequired;
		protected RegularExpressionValidator emailValidator;
		protected CompareValidator passwordCompare;

		#endregion Fields

		#region Private

		private void SetValidatorsText() {
			userNameRequired.ToolTip = LanguageManager.Instance.Get("UserNameRequired");
			passwordRequired.ToolTip = LanguageManager.Instance.Get("PasswordRequired");
			confirmPasswordRequired.ToolTip = LanguageManager.Instance.Get("MustPasswordConfirm");
			emailRequired.ToolTip = LanguageManager.Instance.Get("EmailRequired");
			emailValidator.ErrorMessage = LanguageManager.Instance.Get("EmailValidator");
			emailValidator.ToolTip = LanguageManager.Instance.Get("EmailValidator");
			passwordCompare.ErrorMessage = LanguageManager.Instance.Get("PasswordCompare");
			passwordCompare.ToolTip = LanguageManager.Instance.Get("PasswordCompare");
		}

		private void SetError(string token) {
			errorMessage.Text = LanguageManager.Instance.Get(token);
		}

		#endregion Private

		#region Control Events

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
            {
                OrionsBelt.WebUserInterface.Modules.AuthenticateModule.SetLanguage(Request.QueryString["lang"]);

            }
        }
		protected override void OnInit( EventArgs e ) {
			SetValidatorsText();
			terms.Text = LanguageManager.Instance.Get("AcceptTermsConditions");
			register.Text = LanguageManager.Instance.Get("CreateUser");
			register.Click += RegisterPlayer;
		}

		protected void RegisterPlayer(object obj, EventArgs args){
			if( !terms.Checked ) {
				SetError("MustAcceptTermsConditions");
			}else{
			    MembershipCreateStatus status;
                if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
                {
                    status = WebUtilities.OBUserProvider.CreateUser(userName.Text, password.Text, email.Text, Request.QueryString["lang"]);
                }
                else
                {
                    status = WebUtilities.OBUserProvider.CreateUser(userName.Text, password.Text, email.Text, LanguageManager.DefaultLanguage);
                }
			    if (status == MembershipCreateStatus.Success){
					FormsAuthentication.SetAuthCookie(userName.Text, false);
					Response.Redirect("CreatePlayer.aspx");
				}else {
					VerifyStatus(status);
				}
			}
        }

		private void VerifyStatus(MembershipCreateStatus status) {
			switch(status) {
				case MembershipCreateStatus.InvalidUserName:
					SetError("InvalidUserName");
					break;
				case MembershipCreateStatus.DuplicateEmail:
					SetError("DuplicateEmail");
					break;
			}
		}

		#endregion Control Events

	}
}
