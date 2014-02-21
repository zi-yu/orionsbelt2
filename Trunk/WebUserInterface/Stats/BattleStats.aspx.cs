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
	public class BattleStats : Page {

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
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfLadder' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfLadder"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfTournament' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfTournament"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfArena' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfArena"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfBattle' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfBattle"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='StartedInLast24h' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("StartedInLast24h"));
                }

            }
         
            graphics.Text = sb.ToString();
        }

	    #endregion Events

        

    };
}

