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
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Create : System.Web.UI.Page {

        #region Control Fields

        protected UpdateButton updateButton;
        protected AllianceStorageEditor allianceStorageEditor;
        protected Literal information;

        #endregion Control Fields

        #region Control Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            bool pageAvailable = IsPageAvailable();
            PreparePageAvailable(pageAvailable);

            if (pageAvailable) {
                updateButton.Success += new EventHandler(updateButton_Success);
                updateButton.Text = LanguageManager.Instance.Get("Create");
                allianceStorageEditor.AutoFlush = false;
                information.Text = string.Format(LanguageManager.Instance.Get("CreateAllianceIntro"), CreateAllianceCost);
            }

            AllianceMenu.CurrentPage = "Tasks";
        }

        private void PreparePageAvailable(bool pageAvailable)
        {
            allianceStorageEditor.Visible = pageAvailable;
            updateButton.Enabled = allianceStorageEditor.Visible;
            updateButton.Visible = allianceStorageEditor.Visible;
        }

        void updateButton_Success(object sender, EventArgs e)
        {
            AllianceStorage storage = allianceStorageEditor.Current;

            if (string.IsNullOrEmpty(storage.Name)) {
                Persistance.ResetSession();
                SetInvalidName();
                return;
            }

            if (AlreadyExists(storage.Name)) {
                Persistance.ResetSession();
                SetAlreadyExistsName();
                return;
            }

            if (Utils.Principal.Credits < AllianceManager.CreateAllianceCost) {
                Persistance.ResetSession();
                SetNoOrions();
                return;
            }

            IPlayer player = PlayerUtils.Current;
            AllianceManager.CreateAlliance(player, allianceStorageEditor.Current);
            PreparePageAvailable(false);
            SetAllianceCreatedMessage();

            Persistance.Flush();
        }

        private bool AlreadyExists(string name)
        {
            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance()) {
                long count = persistance.CountByName(name);
                return count != 0;
            }
        }

        private bool IsPageAvailable()
        {
            return !AllianceWebUtils.PlayerHasAlliance();
        }

        #endregion Control Events

        #region Messages

        private void SetAllianceCreatedMessage()
        {
            SuccessBoard.AddLocalizedMessage("CreateAllianceSuccess");
        }

        private void SetInvalidName()
        {
            ErrorBoard.AddLocalizedMessage("InvalidName");
        }

        private void SetNoOrions()
        {
            ErrorBoard.AddLocalizedMessage("AllianceCreateNoOrions");
        }

        private void SetAlreadyExistsName()
        {
            ErrorBoard.AddLocalizedMessage("NameAlreadyExists");
        }

        #endregion Messages

        #region Properties

        public int CreateAllianceCost {
            get { return AllianceManager.CreateAllianceCost; }
        }

        #endregion Properties

    };
}
