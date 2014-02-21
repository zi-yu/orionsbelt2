using System.Web.UI;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Web;
using System;

namespace OrionsBelt.WebUserInterface.Controls {
	public class Copyright : Control {

		#region Fields

		private static int year = 2009;
		
		#endregion Fields

		#region Private

		private static string ChooseYear() {
			if( State.HasApplication("GameYear")) {
				return (string)State.Application["GameYear"]; 
			}

			int current = DateTime.Now.Year;
			string strYear;
			if( year == current) {
				strYear = "2009";
			}else {
				strYear = string.Format("2009-{0}", current); 
			}
			State.SetApplication("GameYear", strYear);
			return strYear;
		}

		#endregion Private
	
		#region Constrol Fields

		protected override void Render( HtmlTextWriter writer ) {

			writer.Write("<div id='copyright'>© {0} by Orion's Belt, All rights reserved.</div>", ChooseYear());
		}

		#endregion Constrol Fields
	}
}

