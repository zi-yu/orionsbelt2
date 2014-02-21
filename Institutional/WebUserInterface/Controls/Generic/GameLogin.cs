using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Institutional.WebComponents;
using System.IO;

namespace Institutional.WebUserInterface.Controls {

    public class GameLogin : Control {

        #region Fields

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // hack
            Controls.Add(new LiteralControl("<input type='submit' style='display:none;' />"));

            Controls.Add(new LiteralControl("<table class='login'>"));

            Controls.Add(new LiteralControl("<tr>"));
            Controls.Add(new LiteralControl(string.Format("<td>{0}</td>", LanguageManager.Instance.Get("LoginUsername"))));
            Controls.Add(new LiteralControl("<td>"));
            Controls.Add(new LiteralControl("<input type='text' name='u' id='u' />"));
            Controls.Add(new LiteralControl("</td>"));
            Controls.Add(new LiteralControl("<tr>"));

            Controls.Add(new LiteralControl("<tr>"));
            Controls.Add(new LiteralControl(string.Format("<td>{0}</td>", LanguageManager.Instance.Get("LoginPassword"))));
            Controls.Add(new LiteralControl("<td>"));
            Controls.Add(new LiteralControl("<input type='password' name='p' id='p' />"));
            Controls.Add(new LiteralControl("</td>"));
            Controls.Add(new LiteralControl("<tr>"));

            Controls.Add(new LiteralControl("<tr>"));
            Controls.Add(new LiteralControl(string.Format("<td>{0}</td>", LanguageManager.Instance.Get("LoginServer"))));
            Controls.Add(new LiteralControl("<td>"));
            AddServerList();
            Controls.Add(new LiteralControl("</td>"));
            Controls.Add(new LiteralControl("<tr>"));

            Controls.Add(new LiteralControl("<tr>"));
            //Controls.Add(new LiteralControl(string.Format("<td><a href='#'>{0}</a></td>", LanguageManager.Instance.Get("RegisterAction"))));
            //Controls.Add(new LiteralControl(string.Format("<td><div class='buttonSmall'><a href='#'><div>{0}</div></a></div></td>", LanguageManager.Instance.Get("LoginAction"))));
            Controls.Add(new LiteralControl("<td></td>"));
            Controls.Add(new LiteralControl(string.Format("<td><div class='button'><a href='javascript:goLogin();'><div>{0}</div></a></div></td>", LanguageManager.Instance.Get("LoginAction"))));
            Controls.Add(new LiteralControl("<tr>"));

            Controls.Add(new LiteralControl("</table>"));

            Controls.Add(new LiteralControl("<script type='text/javascript'>"));
            Controls.Add(new LiteralControl(GetInitScript()));
            Controls.Add(new LiteralControl(GetLoginScript()));
            Controls.Add(new LiteralControl("</script>"));
        }

        private void AddServerList()
        {
            Controls.Add(new LiteralControl("<select id='serverList' class='styled'>"));
            Controls.Add(new LiteralControl(
                    string.Format("<option value='{0}LoginAuto.aspx'>{1}</a>", 
                        WebUtilities.CurrentServer.Url, 
                        string.Format(LanguageManager.Instance.Get("UniverseName"), WebUtilities.CurrentServer.Name)
                    )
                 ));
            Controls.Add(new LiteralControl("</select>"));
        }

        private string GetInitScript()
        {
            TextWriter writer = new StringWriter();

            writer.Write(@"var form = document.forms[0];form.action = '" + WebUtilities.CurrentServerLoginUrl + @"';");

            return writer.ToString();
        }

        private string GetLoginScript()
        {
            TextWriter writer = new StringWriter();

            writer.Write(@"function goLogin() {
                var select = document.getElementById('serverList');
                var form = document.forms[0];
                form.action = select.value;
                form.submit();
            }");

            return writer.ToString();
        }

        #endregion Events

    };

}
