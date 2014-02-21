using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Web.UI.WebControls;
using System.Text;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {
	public class UnitsStats : Page {

        #region Fields

	    protected Literal graphics;

        #endregion Fields

        #region Events

        protected override void OnInit( EventArgs e ) 
        {
            StringBuilder sb = new StringBuilder();

            foreach (IResourceInfo info in RulesUtils.GetResources())
            {
                if (info is IUnitInfo)
                {
                    using (IGlobalStatsPersistance persistance = Persistance.Instance.GetGlobalStatsPersistance())
                    {
                        IList<GlobalStats> stats =
                            persistance.TypedQuery(0, 20,
                                "SELECT e FROM SpecializedGlobalStats e where e.Text='{0}' order by e.Tick desc", info.Name);
                        if (stats.Count > 0)
                        {
                            stats = GraphicUtilities.RotateElems(stats);
                            GraphicUtilities.GenerateGraphic(sb, stats, info.Name);
                        }
                    }
                }
            }

            graphics.Text = sb.ToString();
        }

	    #endregion Events

        

    };
}

