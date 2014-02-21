using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {
	public class AllianceInfoReader : Control 
    {
	    private AllianceStorage alliance;
	    private int allianceId;

        public AllianceStorage Alliance
	    {
            get { return alliance; }
            set { alliance = value; }
	    }

	    public int AllianceId
	    {
	        get { return allianceId; }
	        set { allianceId = value; }
	    }

	    #region Control Fields

        protected override void Render( HtmlTextWriter writer ) 
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            string dir = string.Format("{0}Jobs/HTMLs/Alliances", path);
            if (!Directory.Exists(dir))
            {
                return;
            }
            int id = alliance != null ? alliance.Id : allianceId;
            string file = string.Format("{0}/{1}.html", dir, id);
            if(!File.Exists(file))
            {
                return;
            }
            StreamReader sr = new StreamReader(file);
            writer.Write(string.Format(sr.ReadToEnd(),LanguageManager.Instance.Get("Score"),
                LanguageManager.Instance.Get("Month1"),
                LanguageManager.Instance.Get("Month2"),
                LanguageManager.Instance.Get("Month3"),
                LanguageManager.Instance.Get("Month4"),
                LanguageManager.Instance.Get("Month5"),
                LanguageManager.Instance.Get("Month6"),
                LanguageManager.Instance.Get("Month7"),
                LanguageManager.Instance.Get("Month8"),
                LanguageManager.Instance.Get("Month9"),
                LanguageManager.Instance.Get("Month10"),
                LanguageManager.Instance.Get("Month11"),
                LanguageManager.Instance.Get("Month12"),
                LanguageManager.Instance.Get("Classification"),
                LanguageManager.Instance.Get("TotalMembers"),
                LanguageManager.Instance.Get("TotalPlanets")));
		}

		#endregion Control Fields
	}
}

