using System.Web.UI;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls{
    public class NextTick : ControlBase {

        #region Control Events

        protected override void Render(HtmlTextWriter writer){
            writer.Write("{0} <span id='tickCountdown' start='{1}'></span>", LanguageManager.Instance.Get("NextTickIn"), Clock.Instance.MillisToTick);
        }

		#endregion Control Events

    };
}
