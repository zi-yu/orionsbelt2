using System;
using System.Web;
using OrionsBelt.WebUserInterface.Engine;
using System.Web.Security;

namespace OrionsBelt.WebUserInterface {
    public partial class LoginLoginAuto : System.Web.UI.Page {

        #region Auto Login Logic

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //foreach (string key in HttpContext.Current.Request.QueryString.AllKeys) {
            //    HttpContext.Current.Response.Write(string.Format("key={0} value={1}<p/>", key, HttpContext.Current.Request.QueryString[key], HttpContext.Current.Request.Url.Fragment));
            //}

            if (IsAutoAuth() && WebUtilities.OBUserProvider.ValidateUser(GetUsername(), GetPassword())) {
                FormsAuthentication.SetAuthCookie(GetUsername(), GetRememberMe());
                HttpContext.Current.Response.Write("Go Default");
                Response.Redirect("~/Default.aspx");
            } else {
                HttpContext.Current.Response.Write("Go Login");
                //Response.Redirect("~/Login.aspx?type=wrongCredentials");
                Response.Redirect(string.Format("{0}?type=wrongCredentials",WebUtilities.LoginPath));
            }
        }

        private string GetUsername()
        {
            return GetValue("u");
        }

        private string GetPassword()
        {
            return GetValue("p");
        }

        private bool GetRememberMe()
        {
            string value = GetValue("r");
            if (string.IsNullOrEmpty(value)) {
                return false;
            }
            return true;
        }

        private string GetValue(string key)
        {
            string value = HttpContext.Current.Request.QueryString[key];
            if (!string.IsNullOrEmpty(value)) {
                return value;
            }

            value = HttpContext.Current.Request.Form[key];
            if (!string.IsNullOrEmpty(value)) {
                return value;
            }

            value = HttpContext.Current.Request.QueryString["ob"+key];
            if (!string.IsNullOrEmpty(value)) {
                return value;
            }

            value = HttpContext.Current.Request.Form["ob" + key];
            if (!string.IsNullOrEmpty(value)) {
                return value;
            }

            return null;
        }

        private bool IsAutoAuth()
        {
            return !string.IsNullOrEmpty(GetUsername());
        }

        #endregion Auto Login Logic

    };
}
