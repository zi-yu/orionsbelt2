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
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls.Tournament
{
    public partial class CreateTeam : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            create.Text = LanguageManager.Instance.Get("Create");
            teamNameValidator.Text = LanguageManager.Instance.Get("TeamNameValidator");
        }

        protected void Create(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            if (null != Utils.Principal.Team)
            {
                ErrorBoard.AddLocalizedMessage("InTeam");
                return;
            }

            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
            {
                TeamStorage team = persistance.Create();
                team.Name = name.Text;
                team.IsComplete = false;
                team.EloRanking = 1000;
                team.IsInBattle = 0;
                team.LadderActive = true;
                team.LadderPosition = (int)persistance.ExecuteScalar("select max(info.LadderPosition) from SpecializedTeamStorage info") + 1;

                int idStats;
                using (IPrincipalStatsPersistance stats = Persistance.Instance.GetPrincipalStatsPersistance(persistance))
                {
                    PrincipalStats newStats = stats.Create();
                    newStats.MaxElo = 1000;
                    newStats.MinElo = 1000;
                    newStats.NumberPlayedBattles = 0;
                    newStats.MaxLadder = team.LadderPosition;
                    newStats.MinLadder = team.LadderPosition;
                    stats.Update(newStats);
                    idStats = newStats.Id;
                }

                team.MyStatsId = idStats;
                persistance.Update(team);

                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                {
                    Utils.Principal.Team = team;
                    persistance2.Update(Utils.Principal);
                }
                persistance.Flush();
                this.Visible = false;
            }

            InformationBoard.AddLocalizedMessage("SucessOperation");
        }
    }
}