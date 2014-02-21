using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Web.UI.WebControls;
using System.Text;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {
	public class PlayerStats : Page {

        #region Fields

	    protected Literal graphics;

        #endregion Fields

        #region Events

        protected override void OnInit( EventArgs e ) 
        {
            StringBuilder sb = new StringBuilder();

            using (IGlobalStatsPersistance persistance = Persistance.Instance.GetGlobalStatsPersistance())
            {
                IList<GlobalStats> stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfPrincipals' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfPrincipals"));
                }
                
                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='Actives' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("Actives"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='RegistsLast24h' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("RegistsLast24h"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfPlayers' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfPlayers"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfBugs' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfBugs"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfDarkHumans' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfDarkHumans"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfLightHumans' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfLightHumans"));
                }

                for(int iter = 0 ; iter <= 10; ++iter)
                {
                    stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='InLevel {0}' order by e.Tick desc",iter);
                    if (stats.Count > 0)
                    {
                        stats = GraphicUtilities.RotateElems(stats);
                        GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get(string.Format("InLevel{0}",iter)));
                    }
                }

            }
         
            graphics.Text = sb.ToString();
        }

	    #endregion Events

        

    };
}

