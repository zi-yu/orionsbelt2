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
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;
using System.IO;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface
{
    public partial class ContactPage : System.Web.UI.Page
    {
        #region Fields

        protected TextBox message;
        protected DropDownList topics;
        protected Button send;
        protected Panel messagePanel;
        
        #endregion Fields

        #region Private

        private void WriteMessageBoard(string msg){
            string title = LanguageManager.Instance.Get(msg + "Title");
            string text = LanguageManager.Instance.Get(msg);
            
            StringWriter writer = new StringWriter();
            writer.Write("<table class='table'>");
            writer.Write("<tr><th>{0}</th></tr>", title);
            writer.Write("<tr><td>{0}</td></tr>", text);
            writer.Write("</table>");

            messagePanel.Controls.Add(new LiteralControl( writer.ToString() ) );
            messagePanel.Visible = true;
        }

        private void WriteMessage(){
            string msg = HttpContext.Current.Request.QueryString["message"];
            if ( !string.IsNullOrEmpty(msg)){
                WriteMessageBoard(msg);
                if(msg == "Blocked")
                {
                    topics.SelectedValue = "Multiple Users";
                }
            }
        }

        #endregion

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            messagePanel.Visible = false;
            send.Click += new EventHandler(send_Click);
            send.Text = LanguageManager.Instance.Get("Send");
            if (!Page.IsPostBack) {
                topics.Items.Add(new ListItem(LanguageManager.Instance.Get("Feedback"), "Feedback"));
                topics.Items.Add(new ListItem(LanguageManager.Instance.Get("Help"), "Help"));
                topics.Items.Add(new ListItem(LanguageManager.Instance.Get("BugReport"), "Bug Report"));
                topics.Items.Add(new ListItem(LanguageManager.Instance.Get("MultipleUsers"), "Multiple Users"));
                topics.Items.Add(new ListItem(LanguageManager.Instance.Get("Other"), "Other"));
            }
            WriteMessage();
        }

        void send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(message.Text)) {
                return;
            }

            TextWriter writer = new StringWriter();
            writer.Write("<h1>Details</h1>");
            writer.Write("<ul>");
            writer.Write("<li>Username: {0}</li>", Utils.Principal.Name);
            writer.Write("<li>Mail: {0}</li>", Utils.Principal.Email);
            writer.Write("<li>Server: {0} [{1}]</li>", OrionsBelt.Generic.Server.Properties.Name, OrionsBelt.Generic.Server.Properties.BaseUrl);
            writer.Write("<li>Type: {0}</li>", topics.SelectedValue);
            writer.Write("</ul>");
            writer.Write("<h2>Message</h2>");
            writer.Write("<p>{0}</p>", message.Text.Replace(Environment.NewLine, "<p/>"));

            MailSender.Send("manual@orionsbelt.eu", "Orion's Belt Feedback <feedback@orionsbelt.eu>", string.Format("{0} ({1})", topics.SelectedValue, Utils.Principal.Name), writer.ToString());
            SuccessBoard.AddLocalizedMessage("DiagogueSent");

        }

        #endregion Events

    };
}
