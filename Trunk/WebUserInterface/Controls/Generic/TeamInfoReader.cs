using System.IO;
using System.Text; 
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using System;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {
    public class TeamInfoReader : Control 
    {
	    private TeamStorage team;

        public TeamStorage Team
	    {
            get { return team; }
            set { team = value; }
	    }

	    #region Control Fields

        protected override void Render( HtmlTextWriter writer ) 
        {
            try
            {
                if (team == null) {
                    return;
                }
                string path = HttpContext.Current.Request.PhysicalApplicationPath;
                string dir;
#if DEBUG
                dir = string.Format("{0}Bin/HTMLs/Teams", path);
#else
                dir = string.Format("{0}Jobs/HTMLs/Teams", path);
#endif

                if (!Directory.Exists(dir))
                {
                    return;
                }
                string file = string.Format("{0}/{1}.html", dir, team.Id);
                if (!File.Exists(file))
                {
                    return;
                }
                using (StreamReader sr = new StreamReader(file))
                {
                    string data = string.Format(sr.ReadToEnd(), LanguageManager.Instance.Get("EloRanking"),
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
                                               LanguageManager.Instance.Get("Month12"));

                   
                    writer.Write(data);
                    
                }
            }
            catch (Exception ex) {
                ExceptionLogger.Log(ex);
            }
        }

		#endregion Control Fields
	}
}

