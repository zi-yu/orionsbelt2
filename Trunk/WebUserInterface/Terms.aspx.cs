using System;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {
	public partial class Terms : System.Web.UI.Page {

        protected override void OnLoad(EventArgs e){
            if (Utils.PrincipalExists) {
                termsNotAccepted.Visible = !Utils.Principal.AcceptedTerms;
                termsButton.Visible = termsNotAccepted.Visible;
                acceptTerms.Text = LanguageManager.Instance.Get("IAccept");
                acceptTerms.Click += AcceptTermsClick;
            }else {
            	termsNotAccepted.Visible = false;
            	termsButton.Visible = false;
            }
        }

        protected void AcceptTermsClick(object sender, EventArgs e){
            using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                Principal principal = Utils.Principal;
                principal.AcceptedTerms = true;
                persistance.Update(principal);
                persistance.Flush();
                Response.Redirect("Default.aspx");
            }
        }
	}
}
