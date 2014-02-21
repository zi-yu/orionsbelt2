using System;
using System.Web.UI.WebControls;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class CreateNecessity : System.Web.UI.Page
    {
        protected RegularExpressionValidator validator;
        protected DropDownList resources;
        protected TextBox description;
        protected TextBox coordinates;
        protected Button button;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            validator.ErrorMessage = LanguageManager.Instance.Get("InvalidCoordinate") + " X:X:X:X";

            foreach (TaskType elem in Enum.GetValues(typeof(TaskType)))
            {
                resources.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()),elem.ToString()));
            }
            button.Text = LanguageManager.Instance.Get("Send");

        }

        protected void Send(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                ErrorBoard.AddLocalizedMessage("InvalidRequest");
                return;
            }
            PlayerStorage player = PlayerUtils.Current.Storage;
            if (player.Alliance == null)
            {
                ErrorBoard.AddLocalizedMessage("NoAlliance");
                return;
            }

            using (INecessityPersistance persistance = Persistance.Instance.GetNecessityPersistance())
            {
                Necessity necessity = persistance.Create();
                necessity.Creator = player;
                necessity.Alliance = player.Alliance;
                necessity.Description = description.Text;
                necessity.Type = resources.SelectedValue;
                necessity.Coordinate = coordinates.Text;
                necessity.Status = "NotAssigned";
                persistance.Update(necessity);
                persistance.Flush();
            }

            Messenger.Add(Category.Task, typeof(NecessityCreatedMessage), player.Alliance.Id,
                string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
                    WebUtilities.ApplicationPath, player.Id, player.Name),
                string.Format("{0}Alliance/Tasks.aspx?Id={1}",
                    WebUtilities.ApplicationPath, player.Alliance.Id)
            );

            InformationBoard.AddLocalizedMessage("SucessOperation");
        }
    }
}
