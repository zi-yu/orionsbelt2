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
    public class ShopStats : Page
    {

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
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='BuyQueueSpace' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("BuyQueueSpace"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='BuyIntrinsicDeduction' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("BuyIntrinsicDeduction"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='BuyRareDeduction' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("BuyRareDeduction"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='BuyFastSpeed' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("BuyFastSpeed"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='BuyFullLineOfSight' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("BuyFullLineOfSight"));
                }

                stats = persistance.TypedQuery(0, 20,
                        "SELECT e FROM SpecializedGlobalStats e where e.Text='BuyNoUndiscoveredUniverse' order by e.Tick desc");
                if (stats.Count > 0)
                {
                    stats = GraphicUtilities.RotateElems(stats);
                    GraphicUtilities.GenerateGraphic(sb, stats, LanguageManager.Instance.Get("BuyNoUndiscoveredUniverse"));
                }
            }
         
            graphics.Text = sb.ToString();
        }

	    #endregion Events

        

    };
}

