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

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Default : System.Web.UI.Page {

        #region Fields

        protected InteractionsControl interactions;
        protected MessageList allianceMessages;
        protected Literal message;
        protected Panel allianceMessagesPanel;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (AllianceWebUtils.CurrentPlayerOwnsCurrentAlliance) {
                PrepareInteractionsForAlliance();
            }

            if (!PlayerUtils.Current.HasAlliance) {
                PrepareInteractionsForPlayer();
                DisplayNoAllianceMessage();
            } else {
                PrepareMessages();
            }
        }

        private void DisplayNoAllianceMessage()
        {
            message.Text = MessageBoard.GetSimpleBoardHtml(string.Format(LanguageManager.Instance.Get("NoAllianceMessage"), WebUtilities.ApplicationPath));
        }

        private void PrepareMessages()
        {
            allianceMessagesPanel.Visible = true;
            allianceMessages.MessagesWriter = new GenericMessages(Category.Alliance, AllianceWebUtils.Current);
        }

        private void PrepareInteractionsForAlliance()
        {
            IList<Interaction> interactionList = AllianceManager.GetInteractions(AllianceWebUtils.Current);
            interactions.SetInteractions(interactionList);
            if (AllianceWebUtils.HasCurrent) {
                interactions.State = AllianceWebUtils.Current.Storage;
            }
        }

        private void PrepareInteractionsForPlayer()
        {
            IList<Interaction> interactionList = PlayerUtils.GetInteractions(PlayerUtils.Current);
            interactions.SetInteractions(interactionList);

            if (AllianceWebUtils.HasCurrent) {
                interactions.State = AllianceWebUtils.Current.Storage;
            }
        }

        #endregion Events

    };
}
