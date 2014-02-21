using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PlayerProfileMenu : MenuBase {

        #region Constructor

        public PlayerProfileMenu() {
            options = new string[] { "PlayerInfo.aspx?PlayerStorage={0}", "Profile/FriendOrFoe.aspx?PlayerStorage={0}", "Profile/Medals.aspx?PlayerStorage={0}","" };
            optionsLabel = new string[] { "Profile", "FriendOrFoe", "Medals","" };
        }

        protected override void Render(HtmlTextWriter writer) {
            IPlayer player = State.GetItems<IPlayer>();
            for (int i = 0; i < 3; ++i) {
                string s = string.Format(options[i], player.Id);
                options[i] = s;
            }
            if (PlayerUtils.Current.Id != player.Id) {
                options[3] = string.Format("PlayerInfo.aspx?PlayerStorage={0}", PlayerUtils.Current.Id);
                optionsLabel[3] = "MyPlayer";
            }

            base.Render(writer);
        }

        #endregion Constructor

    };

}
