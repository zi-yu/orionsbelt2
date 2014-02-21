using System;
using System.Web.UI;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface{
    public partial class OrionsBeltTournament : MasterPage{
        protected override void OnInit(EventArgs e){
            State.SetItems("InsertFullHeader", 1);
        }
    }
}
