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

	public class QuestMenu : MenuBase {

        
        #region Constructor

        public QuestMenu() {
            options = new string[] { "Quests/Default.aspx", "Quests/Bounties.aspx", "Quests/CreateBounty.aspx" };
            optionsLabel = new string[] { "Generic", "Bounties", "CreateBounty"};
        }

        #endregion Constructor
    }
}