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
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine;
using OrionsBelt.Core;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Controls {

    public static class AllianceWebUtils {

        #region Utils

        public static IAlliance Current {
            get {
                if (State.HasItems("Alliance")) { 
                    return (IAlliance)State.GetItems("Alliance");
                }
                if (PlayerUtils.HasPlayer && PlayerUtils.Current.HasAlliance) {
                    IAlliance curr = PlayerUtils.Current.Alliance;
                    State.SetItems("Alliance", curr);
                    return curr;
                }
                throw new UIException("Can't resolve alliance");
            }
        }

        public static bool HasCurrent {
            get 
            {
                if (State.HasItems("Alliance")) {
                    return State.HasItems("Alliance"); 
                }
                return PlayerUtils.HasPlayer && PlayerUtils.Current.HasAlliance;
            }
        }

        public static bool CurrentPlayerOwnsCurrentAlliance {
            get {
                if (PlayerUtils.Current.AllianceRank != AllianceRank.Admiral) {
                    return false;
                }
                if( !HasCurrent ) {
                    return false;
                }
                return AllianceManager.CanManageAlliance(PlayerUtils.Current, Current);
            }
        }

        public static bool CurrentPlayerBelongsToCurrentAlliance {
            get { 
                if( !HasCurrent ) {
                    return false;
                }
                if (PlayerUtils.Current.Alliance == null) {
                    return false;
                }
                return PlayerUtils.Current.Alliance.Storage.Id == Current.Storage.Id;
            }
        }

        public static bool PlayerHasAlliance()
        {
            if (!PlayerUtils.HasPlayer) {
                return false;
            }
            IPlayer player = PlayerUtils.Current;
            if (player != null && player.HasAlliance) {
                return true;
            }

            return false;
        }

        public static string GetUrl()
        {
            return GetUrl("Default");
        }

        public static string GetUrl(string page)
        {
            return string.Format("{0}Alliance/{1}.aspx", WebUtilities.ApplicationPath, page);
        }

        public static string GetUrl(AllianceStorage alliance)
        {
            return GetUrl(alliance, "Info");
        }

        public static string GetUrl(IAlliance alliance, string specificPage)
        {
            return GetUrl(alliance.Storage, specificPage);
        }

        public static string GetUrl(AllianceStorage alliance, string specificPage)
        {
            return string.Format("{0}Alliance/{2}.aspx?Id={1}", WebUtilities.ApplicationPath, alliance.Id, specificPage);
        }

        public static string GetMenuUrl(string page) {
            return string.Format("Alliance/{0}.aspx", page);
        }

        public static string GetMenuUrl(AllianceStorage alliance, string specificPage) {
            return string.Format("Alliance/{1}.aspx?Id={0}", alliance.Id, specificPage);
        }

        #endregion Utils

        #region Asserts

        internal static void AssertCurrentPlayerOwnsCurrentAlliance()
        {
            if (!AllianceWebUtils.CurrentPlayerOwnsCurrentAlliance) {
                throw new UnAuthorizedException();
            }
        }

        internal static void AssertCurrentPlayerBelongsToCurrentAlliance()
        {
            if (!AllianceWebUtils.CurrentPlayerBelongsToCurrentAlliance) {
                throw new UnAuthorizedException();
            }
        }

        #endregion Asserts

    };

}
