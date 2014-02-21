using System;

using System.Web.UI;

using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {
	public partial class PopupWindow : MasterPage {
		protected override void OnLoad(EventArgs e) {
			Page.ClientScript.RegisterHiddenField("path", WebUtilities.ApplicationPath);
			Page.ClientScript.RegisterHiddenField("imagePath", ResourcesManager.ImagesCommonPath);
			
		}
	}
}
