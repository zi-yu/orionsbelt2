using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine;

namespace Orionsbelt.WebUserInterface {
	public class Confirmation : System.Web.UI.Page {

		#region Fields

		private Principal user = null;
		protected PlaceHolder confirmationHolder;
		protected PlaceHolder notApprovedHolder;
		protected TextBox confirmationEmail;
		protected Button send;
		protected RegularExpressionValidator emailValidation;

		#endregion

		#region Private

		private void MakeConfirmation() {
			confirmationHolder.Visible = true;
			string value = Context.Request.QueryString["value"];
			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
                if( user.ConfirmationCode == value ) {
                    persistance.StartTransaction();
					
                    user.Approved = true;
					persistance.Update(user);
                    if (user.ReferrerId > 0) {
                        IList<Principal> source = persistance.SelectById(user.ReferrerId);
                        if (source.Count == 1) {
                            CreditsUtil.QuickReferralReward(persistance, source[0], 20);
                        }
                        
                    }
					InformationBoard.AddLocalizedMessage("ConfirmationCompleted",user.Name);

                    persistance.CommitTransaction();
				}
			}
		}

		private void NotApproved() {
			notApprovedHolder.Visible = true;
			send.Click += Send;
			send.Text = LanguageManager.Instance.Get("Send");
			emailValidation.ErrorMessage = emailValidation.ToolTip = LanguageManager.Instance.Get("emailValidation");
		}

		private void CheckType() {
			string type = Context.Request.QueryString["type"];

			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> p = persistance.SelectByName(Context.Request.QueryString["user"]);
				if( p.Count > 0 ) {
					user = p[0];
				}
			}

			if( user == null ) {
                ErrorBoard.AddLocalizedMessage("UserNameInvalid");
				return;
			}

			switch( type ) {
				case "notApproved":
					NotApproved();
					return;
				case "confirmation":
					MakeConfirmation();
					return;
			}

			Context.Response.Redirect("Default.aspx");
		}

		#endregion

		#region Events

		protected override void OnInit( EventArgs e ) {
            Title = LanguageManager.Instance.Get("AccountConfirmation");
			CheckType();
			base.OnInit(e);
		}

		#endregion

		#region Control Events

		void Send( object sender, EventArgs e ) {
			if( confirmationEmail.Text.ToLower().CompareTo(user.Email.ToLower()) == 0 ) {
				MailSender.Send(user.Email, "noreply@orionsbelt.eu", LanguageManager.Instance.Get("registerConfirmation"), LanguageManager.Instance.Get("confirmationEmail"), user.Name, user.ConfirmationCode, user.Email, "---");
			}
			InformationBoard.AddLocalizedMessage("confirmationEmailSent");
		}

		#endregion
	}
}
