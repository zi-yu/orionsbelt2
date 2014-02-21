using System.IO;
using OrionsBelt.WebComponents;
using System.Web;

namespace OrionsBelt.WebUserInterface.Engine {
	
	public class PricesActions : ActionBase {

        #region Private

       
        #endregion Private

		#region Delegates

		private void Changes() {
            string changes = HttpContext.Current.Request.QueryString["Language"];
            TextWriter tw = new StringWriter();
			if (!string.IsNullOrEmpty(changes)) {
                PricesRenderer.Render(tw, changes);
                HttpContext.Current.Response.Write(tw.ToString());
            }
            else
			{
                tw.Write("{0}", LanguageManager.Instance.Get("ChooseCountry"));
                HttpContext.Current.Response.Write(tw.ToString());
			}
		}

		#endregion Delegates

		#region Constructor

        public PricesActions()
        {
			actions["Change"] = Changes;
		}

		#endregion Constructor
	
	}
}
