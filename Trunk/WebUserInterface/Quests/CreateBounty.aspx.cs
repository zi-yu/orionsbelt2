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
using OrionsBelt.Engine.Quests;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.Quests
{
    public class CreateBountyPage : System.Web.UI.Page {

        #region Fields

        protected Literal info;
        protected Button create;
        protected DropDownList pointsToTake;
        protected DropDownList orionsToGive;
        protected ChooseOpponent targetChoice;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            create.Text = LanguageManager.Instance.Get("Create");
            create.Click += new EventHandler(create_Click);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            info.Text = string.Format(LanguageManager.Instance.Get("CreateBountyInfo"), CustomPlayerBounty.AcademyTake);
        }

        void create_Click(object sender, EventArgs e)
        {
            string raw = orionsToGive.SelectedValue;
            if (string.IsNullOrEmpty(raw)) {
                InformationBoard.AddLocalizedMessage("PleaseFillEverything");
                return;
            }

            int reward = int.Parse(raw);

            raw = pointsToTake.SelectedValue;
            if (string.IsNullOrEmpty(raw)) {
                InformationBoard.AddLocalizedMessage("PleaseFillEverything");
                return;
            }

            int points = int.Parse(raw);

            if (reward > Utils.Principal.Credits) {
                InformationBoard.AddLocalizedMessage("NoOrions");
                return;
            }

            IPlayer target = PlayerUtils.GetPlayerById(targetChoice.GetSelectedPlayerId());
            QuestManager.CreateCustomBounty(PlayerUtils.Current, target, points, reward);

            SuccessBoard.AddLocalizedMessage("GenericSuccess");
        }

        #endregion Events
    };
}
