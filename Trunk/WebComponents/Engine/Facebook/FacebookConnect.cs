
using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;

namespace OrionsBelt.WebComponents.Controls {
    public class FacebookConnect : Control {

        #region Control Events

        protected override void Render(HtmlTextWriter writer) {
            if (!Utils.PrincipalExists) {
                writer.Write("<div><fb:login-button v=\"2\" size=\"small\" onlogin=\"window.location='Auth/FacebookAuth.ashx';\" >{0}</fb:login-button></div>", LanguageManager.Localize("Connect"));
            }
        }

        #endregion Control Events
    }
}
