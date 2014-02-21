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
	public class OrionsStats : Page {

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
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='AverageCredits' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("AverageCredits"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='OrionsSpendLast24h' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("OrionsSpendLast24h"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='OrionsGainLast24h' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("OrionsGainLast24h"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='OrionsBuyedLast24h' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("OrionsBuyedLast24h"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='AHSellsNumber' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("AHSellsNumber"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='AHCreditsSpend' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("AHCreditsSpend"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='AHCreditsGain' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("AHCreditsGain"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='VotingPrize' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("VotingPrizeGain"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='PirateBay' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("PirateBaysGain"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='Academy' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("AcademysGain"));
                }

            }
         
            graphics.Text = sb.ToString();
        }

	    #endregion Events

        

    };
}

