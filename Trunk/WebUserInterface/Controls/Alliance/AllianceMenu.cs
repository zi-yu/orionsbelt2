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
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    public class AllianceMenu : MenuBase {

        #region Fields

        private List<string> op = new List<string>();
        private List<string> opl = new List<string>();

        #endregion Fields

        #region Properties

        public static string CurrentPage {
            set {
                State.SetItems(itemsKey, value);
            }
        }

        #endregion Properties

        #region Private

        private void SetOptions(){
            op.Add("Alliance/Default.aspx");
            opl.Add("AllianceDefaultPage");

            WriteLink("List", "AllianceListPage");
            WriteLink("Gossip", "AllianceGossipPage");

            if( !AllianceWebUtils.PlayerHasAlliance() ){
                WriteLink("Create", "AllianceCreatePage");
            } else {
                if (AllianceWebUtils.CurrentPlayerOwnsCurrentAlliance) {
                    WriteLink(PlayerUtils.Current.Alliance, "Board", "AllianceBoardPage");
                }
                WriteLink(PlayerUtils.Current.Alliance, "Tasks", "Tasks");
                WriteLink(PlayerUtils.Current.Alliance, "Messages", "Messages");
                WriteLink(PlayerUtils.Current.Alliance, "Relics", "Relics");
                WriteLink(PlayerUtils.Current.Alliance, "Storehouse", "Storehouse");
                WriteLink(PlayerUtils.Current.Alliance, "Members", "AllianceMembersPage");
                WriteLink(PlayerUtils.Current.Alliance, "Battles", "AllianceBattlesPage");
                WriteLink(PlayerUtils.Current.Alliance, "Diplomacy", "AllianceDiplomacyPage");
                WriteLink(PlayerUtils.Current.Alliance, "Leave", "AllianceLeaveAlliance");
            }
        }

        private void WriteLink(IAlliance iAlliance, string url, string label){
            if (iAlliance == null) {
                url = AllianceWebUtils.GetMenuUrl(url);
            } else {
                url = AllianceWebUtils.GetMenuUrl(iAlliance.Storage, url);
            }
            op.Add(url);
            opl.Add(label);
        }

        private void WriteLink(string url, string label){
            WriteLink(PlayerUtils.Current.Alliance, url, label);
        }

        #endregion Private

        #region Constructor

        public AllianceMenu() {
            SetOptions();
            options = op.ToArray();
            optionsLabel = opl.ToArray();
        }


        #endregion Constructor

    };

}
