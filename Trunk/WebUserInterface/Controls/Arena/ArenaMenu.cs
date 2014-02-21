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

	public class ArenaMenu : MenuBase {

        #region Private

         private void ResolveAdmin() {
            if (Utils.Principal.IsInRole("admin")) {
                options[options.Length - 1] = "Arenas/CreateArena.aspx";
                optionsLabel[options.Length - 1] = "CreateArena";
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

        public ArenaMenu() { 
            options = new string[]{ "Arenas/Arena.aspx", ""};
            optionsLabel = new string[]{ "Arena",""};
        }

        #endregion Constructor
    }
}