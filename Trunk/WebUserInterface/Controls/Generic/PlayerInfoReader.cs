using System.IO;
using System.Text; 
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class PlayerInfoReader : Control 
    {
	    private PlayerStorage player;
        private ShowInfo infoToShow = ShowInfo.All;
        private string title;
        private string controlId;

	    public PlayerStorage Player
	    {
	        get { return player; }
	        set { player = value; }
	    }

	    public ShowInfo InfoToShow
	    {
	        get { return infoToShow; }
	        set { infoToShow = value; }
	    }

        public string Title {
            get { return title; }
            set {
                title = string.Format("<h2>{0}</h2>",LanguageManager.Localize(value));
            }
        }

        public string ControlId {
            get { return controlId; }
            set { controlId = value; }
        }

	    #region Control Fields

        protected override void Render( HtmlTextWriter mainWriter ) 
        {
            try
            {
                if (player == null) {
                    return;
                }
                string path = HttpContext.Current.Request.PhysicalApplicationPath;
                string dir;
#if DEBUG
                dir = string.Format("{0}Bin/HTMLs/Players", path);
#else
                dir = string.Format("{0}Jobs/HTMLs/Players", path);
#endif

                if (!Directory.Exists(dir))
                {
                    return;
                }
                string file = string.Format("{0}/{1}.html", dir, player.Id);
                if (!File.Exists(file))
                {
                    return;
                }

                StringWriter writer = new StringWriter();
                
                using (StreamReader sr = new StreamReader(file))
                {
                    string data = string.Format(sr.ReadToEnd(), LanguageManager.Instance.Get("Score"),
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
                                               LanguageManager.Instance.Get("EloRanking"),
                                               LanguageManager.Instance.Get("BountyRanking"),
                                               LanguageManager.Instance.Get("ColonizerRanking"),
                                               LanguageManager.Instance.Get("GladiatorRanking"),
                                               LanguageManager.Instance.Get("MerchantRanking"),
                                               LanguageManager.Instance.Get("PirateRanking"),
                                               LanguageManager.Instance.Get("NumberOfPlanets"));

                    

                    if (infoToShow == ShowInfo.All)
                    {
                        writer.Write(data);
                    }
                    else
                    {
                        if (infoToShow == ShowInfo.Principal)
                        {
                            writer.Write(data.Substring(0, data.LastIndexOf("<div>")));
                        }
                        else
                        {
                            writer.Write(data.Substring(data.LastIndexOf("<div>")));
                        }
                    }
                }

                mainWriter.Write("<div id='{0}'>",GetId());
                Border.RenderSmall(mainWriter, Title, writer.ToString());
                mainWriter.Write("</div>");

            }
            catch (Exception ex) {
                ExceptionLogger.Log(ex);
            }
        }

        private string GetId() {
            if (!string.IsNullOrEmpty(controlId)) {
                return controlId;
            }
            return "accountChart";
        }

		#endregion Control Fields
	}
}

