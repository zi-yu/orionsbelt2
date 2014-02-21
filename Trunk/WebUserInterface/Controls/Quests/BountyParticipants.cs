using System.Web.UI;
using OrionsBelt.WebUserInterface.Quests;

namespace OrionsBelt.WebUserInterface.Controls {

	public class BountyParticipants : Control {

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
			BountyParticipantsRender.Render(writer);
        }

        #endregion Events

    };
}

