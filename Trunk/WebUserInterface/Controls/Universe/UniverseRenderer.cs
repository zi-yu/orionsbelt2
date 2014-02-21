using System.Web.UI;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class UniverseRenderer: ControlBase {

		#region Control Events

		protected override void OnInit( System.EventArgs e ) {
			Page.ClientScript.RegisterHiddenField("isPrivateSector","1");
			Page.ClientScript.RegisterHiddenField("playerName", PlayerUtils.Current.Name);
			Page.ClientScript.RegisterHiddenField("ultimateReady", PlayerUtils.Current.IsUltimateWeaponReady?"1":"0" );
		}

		protected override void Render( HtmlTextWriter writer ) {
			UniverseSectorRenderer.Render(writer);
		}

		#endregion Control Events

	}
}
