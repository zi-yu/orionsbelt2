using System;
using System.Web.UI;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface {
	public class DefaulStats : Page {

        #region Fields

        protected GlobalStatsPagedList paged;

        #endregion Fields

        #region Events

        protected override void OnInit( EventArgs e ) 
        {
            using (IGlobalStatsPersistance persistance = Persistance.Instance.GetGlobalStatsPersistance())
            {
                long max = persistance.ExecuteScalar("SELECT MAX(e.Tick) FROM SpecializedGlobalStats e");
                paged.Where = string.Format("e.Tick={0}", max);
            }
        }

        #endregion Events

    };
}

