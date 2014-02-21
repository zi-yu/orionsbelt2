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
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Alliance {

    public class ManageMember : System.Web.UI.Page {

        #region Fields

        protected Button kickPlayer;
        protected Button changeRank;
        protected DropDownList ranks;
        protected Literal name;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            bool available = AllianceWebUtils.CurrentPlayerOwnsCurrentAlliance;

            PrepareKickButton(available);
            PrepareRanksDropDown(available);

            name.Text = GetTargetPlayer().Name;

            AllianceMenu.CurrentPage = "Members";
        }

        private void PrepareRanksDropDown(bool available)
        {
            changeRank.Enabled = available;
            changeRank.Text = LanguageManager.Instance.Get("ChangeRankAction");
            changeRank.Click += new EventHandler(changeRank_Click);

            ranks.Enabled = available;

            if (Page.IsPostBack) {
                return;
            }

            string[] names = Enum.GetNames(typeof(AllianceRank));
            foreach( string name in names ) {
                if (name == "None") {
                    continue;
                }
                ListItem item = new ListItem();

                item.Text = LanguageManager.Instance.Get(name);
                item.Value = name;
                item.Selected = GetTargetPlayer().AllianceRank.ToString() == name;

                ranks.Items.Add(item);
            }
        }

        void changeRank_Click(object sender, EventArgs e)
        {
            AllianceRank newRank = (AllianceRank)Enum.Parse(typeof(AllianceRank), ranks.SelectedValue);
            AllianceManager.ChangePlayerRank(GetTargetPlayer(), newRank);
        }

        private void PrepareKickButton(bool available)
        {
            kickPlayer.Enabled = available;
            kickPlayer.Text = LanguageManager.Instance.Get("KickPlayerAction");
            kickPlayer.Click += new EventHandler(kickPlayer_Click);
        }

        private IPlayer GetTargetPlayer()
        {
            if( State.HasItems("ManageMemberTargetPlayer" ) ) {
                return (IPlayer) State.GetItems("ManageMemberTargetPlayer");
            }
            PlayerStorage storage = EntityUtils.GetFromQueryString<PlayerStorage>("Player");
            IPlayer player = new Player(storage, false);
            State.SetItems("ManageMemberTargetPlayer", player);
            return player;
        }

        void kickPlayer_Click(object sender, EventArgs e)
        {
            IPlayer player = GetTargetPlayer();
            IAlliance alliance = AllianceWebUtils.Current;

            AllianceManager.KickPlayer(alliance, player, PlayerUtils.Current);

            Response.Redirect(AllianceWebUtils.GetUrl(alliance, "Members"));
        }

        #endregion Events

    };
}
