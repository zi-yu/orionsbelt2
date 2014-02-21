using OrionsBelt.Engine;
using System.Web.UI;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls{
    public class PlayerOrions : ControlBase {

        #region Control Events

        protected override void Render(HtmlTextWriter writer){
			writer.Write("<div id='orions'><span id='currOrions'><a href='{1}Manual.aspx?path=Commerce/Orions.aspx' alt='Orions' title='Orions'>{0}</a></span></div>", PlayerUtils.Current.Storage.Principal.Credits, WebUtilities.ApplicationPath);
        }

		#endregion Control Events

    };
}
