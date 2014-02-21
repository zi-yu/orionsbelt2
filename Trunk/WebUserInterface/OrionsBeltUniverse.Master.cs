using System;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface{
    public partial class OrionsBeltUniverse : MasterPage{
        protected override void OnInit(EventArgs e){
            State.SetItems("InsertFullHeader",1);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            if (WebUtilities.HasBattles && WebUtilities.HasUniverseBattles) {
                Page.ClientScript.RegisterHiddenField("hub", "1");
            } else {
                Page.ClientScript.RegisterHiddenField("hub", "0");
            }
        }
    }
}
