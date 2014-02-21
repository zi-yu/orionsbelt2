using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class RssLink: Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<a href='{0}Feeds/PlayerMessages.ashx?Player={1}&Token={2}'>RSS</a>",
                    WebUtilities.ApplicationPath,
                    PlayerUtils.Current.Id,
                    PlayerUtils.GetSecretCode(PlayerUtils.Current)
                );
        }

        #endregion Rendering

    }
}

