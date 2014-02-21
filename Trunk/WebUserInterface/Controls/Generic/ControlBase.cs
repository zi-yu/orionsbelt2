using System.Web.UI;

namespace OrionsBelt.WebUserInterface.Controls {
	public class ControlBase : Control  {

		#region Protected

		protected void Write( string value ) {
			Controls.Add(new LiteralControl(value));
		}

		protected void Write( string value, params string[] parameters ) {
			string v = string.Format(value, parameters);
			Controls.Add(new LiteralControl(v));
		}
		
		#endregion
	}
}
