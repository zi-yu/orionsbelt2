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
	public class UniverseStats : Page {

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
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='NumberOfFleets' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("NumberOfFleets"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='PrivatePlanets' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("PrivatePlanets"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='HotPlanets' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("HotPlanets"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='UncolonizedPlanetsInHot' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("UncolonizedPlanetsInHot"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='PlayerWith1Planet' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("PlayerWith1Planet"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='PlayerWithAllPrivatePlanets' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("PlayerWithAllPrivatePlanets"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='PlayerWithAllHotPlanets' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("PlayerWithAllHotPlanets"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='AverageHotPlanetsPerPlayer' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("AverageHotPlanetsPerPlayer"), 0, 8);
                }

            }
         
            graphics.Text = sb.ToString();
        }

	    #endregion Events

        

    };
}

