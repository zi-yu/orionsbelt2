using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {

    public class PirateBayPage : Page 
    {
        protected PirateBayControl bay;

        protected Literal jobMsg;
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            if(PlayerUtils.Current.MainProfession != Profession.Pirate)
            {
                ErrorBoard.AddLocalizedMessage("BountyBlock");
                bay.Visible = false;
            }

        }
    }
}
