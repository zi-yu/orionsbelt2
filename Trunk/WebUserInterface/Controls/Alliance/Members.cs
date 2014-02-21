using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using System.Web.UI;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class MembersControl : BaseFieldControl<Offering>, INamingContainer
    {
        private string browserID;
        private IList<PlayerStorage> players;

        public string BrowserID
        {
            get { return browserID; }
            set { browserID = value; }
        }

        public IList<PlayerStorage> Players
        {
            get { return players; }
            set { players = value; }
        }

        protected override void Render(HtmlTextWriter writer, Offering entity, int renderCount, bool flipFlop)
        {


            writer.Write("<select name='{0}_{1}' id='{0}_{1}' class='styled'>", browserID, entity.Id);
            foreach (PlayerStorage info in players)
            {

                writer.Write("<option value='{0}'>{1}</option>", info.Id.ToString(), info.Name);
                
            }
            writer.Write("</select>");
        }
    }
}
