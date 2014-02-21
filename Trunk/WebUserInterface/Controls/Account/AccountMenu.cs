using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Core;
using System.IO;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

	public class AccountMenu : MenuBase {

        #region Properties

        public static string CurrentPage {
            set {
                State.SetItems(itemsKey, value);
            }
        }

        #endregion
        
        #region Private

         private void ResolveAdmin() {
            if (Utils.Principal.IsInRole("admin")) {
                options[options.Length - 1] = "Account/GivePrize.aspx";
                optionsLabel[options.Length - 1] = "GivePrize";
            }
         }

        #endregion Private

        #region Control Events

        protected override void  Render(HtmlTextWriter writer){
            ResolveAdmin();
 	        base.Render(writer);
        }

        #endregion

        #region Constructor

        public AccountMenu() { 
            options = new string[]{ "PrincipalInfo.aspx?Account=true", "Account/ManagePlayers.aspx", "Account/ChangeMail.aspx", "Account/Shop.aspx", "Account/Payment.aspx",""};
            optionsLabel = new string[]{ "Profile","ManagePlayers","PersonalSettings","Shop","BuyOrions",""};
        }

        #endregion Constructor
    }
}