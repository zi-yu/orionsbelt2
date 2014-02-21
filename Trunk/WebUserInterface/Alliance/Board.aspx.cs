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
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Enum;
using System.IO;

namespace OrionsBelt.WebUserInterface.Alliance {

    public class BoardPage : System.Web.UI.Page {

        #region Fields

        protected Button send;
        protected Button sendPrivate;
        protected TextBox publicBoard;
        protected TextBox privateBoard;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AllianceWebUtils.AssertCurrentPlayerOwnsCurrentAlliance();
            send.Text = sendPrivate.Text = LanguageManager.Instance.Get("Update");
            send.Click += new EventHandler(send_Click);
            sendPrivate.Click += new EventHandler(sendPrivate_Click);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Page.IsPostBack) {
                return;
            }

            string dir = AllianceBoard.GetDir();
            string privateFile = Path.Combine(dir, string.Format("Alliance{0}_{1}.html", AllianceWebUtils.Current.Storage.Id, "Private"));
            string publicFile = Path.Combine(dir, string.Format("Alliance{0}_{1}.html", AllianceWebUtils.Current.Storage.Id, "Public"));

            if (File.Exists(privateFile)) {
                privateBoard.Text = File.ReadAllText(privateFile);
            }

            if (File.Exists(publicFile)) {
                publicBoard.Text = File.ReadAllText(publicFile);
            }
        }

        void send_Click(object sender, EventArgs e)
        {
            string dir = AllianceBoard.GetDir();
            string publicFile = Path.Combine(dir, string.Format("Alliance{0}_{1}.html", AllianceWebUtils.Current.Storage.Id, "Public"));
            File.WriteAllText(publicFile, Prepare(publicBoard.Text));
        }

        void sendPrivate_Click(object sender, EventArgs e) {
            string dir = AllianceBoard.GetDir();
            string privateFile = Path.Combine(dir, string.Format("Alliance{0}_{1}.html", AllianceWebUtils.Current.Storage.Id, "Private"));
            File.WriteAllText(privateFile, Prepare(privateBoard.Text));
        }

        private string Prepare(string raw)
        {
            if (raw.Length > 2000) {
                return raw.Substring(0, 2000);
            }
            return raw;
        }

        #endregion Events

    };
}
