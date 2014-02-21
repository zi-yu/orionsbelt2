using System.Web.UI;

namespace OrionsBelt.WebUserInterface.Controls {
    public class TournamentMenu : GameMenu
    {
		#region Protected Methods

		protected override void Render( HtmlTextWriter writer ) {
			writer.Write("<div id='gameMenu'><ul>");
			WriteAnchorToBase(writer, "Tournaments.aspx", "Tournaments");
			WriteAnchorToBase(writer, "LadderList.aspx", "Ladder");
            WriteAnchorToBase(writer, "Tournaments/Team.aspx", "Team");
            WriteAnchorToBase(writer, "Arenas/Arena.aspx", "Arena", "inside");
			WritePrimaryMessageBoard(writer);
            WriteAnchorToBase(writer, "Battle/Default.aspx", "Battles", "inside");
            WriteAnchorToBase(writer, "Battle/CreateFriendly.aspx", "CreateFriendly");
            WriteAnchorToBase(writer, "Battle/History.aspx", "History");
            WriteAnchorToBase(writer, "Campaigns/Default.aspx", "Campaigns", "last");
            //WriteAnchorToBase(writer, "Tournaments/CreateTeam.aspx", "CreateTeam", "last");
			writer.Write("</ul></div>");
        }

        #endregion Protected Methods
    }
}

