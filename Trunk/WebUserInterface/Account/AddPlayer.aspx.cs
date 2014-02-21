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
    public class AddPlayer : System.Web.UI.Page {

        #region Fields

        protected TextBox playerName;
        protected Button goToChooseRace;
        protected Literal message;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            goToChooseRace.Click += new EventHandler(goToChooseRace_Click);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!Page.IsPostBack) {
                playerName.Text = Utils.Principal.DisplayName;
            }
        }

        void goToChooseRace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(playerName.Text) || playerName.Text.Length > 20) {
                NotifyInvalidName();
                return;
            }

            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
                long count = persistance.CountByName(playerName.Text);
                if (count != 0) {
                    NotifyNameAlreadyExists();
                    return;
                }
                count = persistance.ExecuteScalar("select count(*) from SpecializedPlayerStorage p where p.PrincipalNHibernate.Id = {0}", Utils.Principal.Id);
                if (count >= 3) {
                    NotifiyMaxPlayers();
                    return;
                }
            }

            State.SetSession("PlayerName", playerName.Text);
            Response.Redirect("../CreatePlayer.aspx");
        }

        private void NotifiyMaxPlayers()
        {
            message.Text = "Max players reached";
        }

        private void NotifyNameAlreadyExists()
        {
            message.Text = "Name already exists";
        }

        private void NotifyInvalidName()
        {
            message.Text = "invalid name";
        }

        #endregion Events

    };
}
