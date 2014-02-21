using System;
using System.Web;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Battles {
	public class Default : System.Web.UI.Page {

        #region Fields

        protected Literal noBattlesMessage;

        #endregion Fields

        #region Private

        private static void UpdateBattle() {
            int nBattles = 0;

	        if (State.HasItems("NumberOfBattles")) {
	            nBattles = State.GetItemsInt("NumberOfBattles");
	        }
	        WebUtilities.HasBattles = nBattles > 0;

            nBattles = 0;
	        if (State.HasItems("NumberUniverseOfBattles")){
	            nBattles = State.GetItemsInt("NumberUniverseOfBattles");
	        }
            WebUtilities.HasUniverseBattles = nBattles > 0;
        }

        #endregion Private

        #region Control Events

        protected override void OnLoad(EventArgs e){
            base.OnLoad(e);
            UpdateBattle();

            int total = 0;
            if (State.HasItems("TotalNumberOfBattles")) {
                total = State.GetItemsInt("TotalNumberOfBattles");
            }

            if (total == 0) {
                noBattlesMessage.Text = MessageBoard.GetSimpleBoardHtml(LanguageManager.Instance.Get("NoBattlesMessage"));
            }
        }
        
        #endregion Control Events

    }
}
