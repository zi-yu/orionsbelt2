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
using OrionsBelt.WebComponents;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Profile
{
    public class PlayerProfileMaster : System.Web.UI.MasterPage {

        #region Fields

        protected PlayerInfoReader reader;
        protected PlayerStorage player;
        protected IPlayer iplayer;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            player = EntityUtils.GetFromQueryString<PlayerStorage>();
            State.SetItems<PlayerStorage>(player);
            iplayer = new Player(player);
            State.SetItems<IPlayer>(iplayer);

            reader.Player = player;
            reader.InfoToShow = ShowInfo.Player;
        }

        #endregion Events
    }
}
