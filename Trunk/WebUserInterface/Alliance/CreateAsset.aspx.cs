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
    public class CreateAsset : System.Web.UI.Page
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
            AllianceMenu.CurrentPage = "Tasks";
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

            using (IAssetPersistance persistance = Persistance.Instance.GetAssetPersistance())
            {
                Asset asset = persistance.Create();
                asset.Owner = player;
                asset.Alliance = player.Alliance;
                asset.Description = description.Text;
                asset.Type = resources.SelectedValue;
                asset.Coordinate = coordinates.Text;
                persistance.Update(asset);
                persistance.Flush();
            }
            Messenger.Add(Category.Task, typeof(AssetCreatedMessage), player.Alliance.Id, 
                string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
                    WebUtilities.ApplicationPath,player.Id,player.Name),
                string.Format("{0}Alliance/Tasks.aspx?Id={1}",
                    WebUtilities.ApplicationPath,player.Alliance.Id)
            );

            InformationBoard.AddLocalizedMessage("SucessOperation");
        }
    }
}
