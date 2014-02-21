using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrionsBelt.WebUserInterface.Controls {
	public class OBCreateUserWizard: CreateUserWizard {
		protected override void Render( HtmlTextWriter writer ) {
			StringBuilder sb = new StringBuilder();
			StringWriter sw = new StringWriter(sb);
			HtmlTextWriter hw = new HtmlTextWriter(sw);
			base.RenderContents(hw);

			string str = sb.ToString();
			str = Regex.Replace(str, "</?table[^>]*>|</?tr[^>]*>|</?td[^>]*>|</?thead[^>]*>|</?tbody[^>]*>", string.Empty);

			writer.Write(str);
			
			
		}
	}

}
