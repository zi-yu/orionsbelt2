using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Engine;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class AllianceMaster : System.Web.UI.MasterPage {

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            string allianceId = Request.QueryString["Id"];
            if (string.IsNullOrEmpty(allianceId)) {
                allianceId = Request.QueryString["AllianceStorage"];
            }

            if (!string.IsNullOrEmpty(allianceId)) {
                AllianceStorage storage = GetAlliance(allianceId);
                State.SetItems<AllianceStorage>(storage);
                State.SetItems("Alliance", AllianceManager.PrepareAlliance(storage));
            }
        }

        private static AllianceStorage GetAlliance(string allianceId)
        {
            if (PlayerUtils.Current.HasAlliance && PlayerUtils.Current.Alliance.Storage.Id.ToString() == allianceId) {
                return PlayerUtils.Current.Alliance.Storage;
            }

            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance())  {
                return persistance.Select(int.Parse(allianceId));
            }
        }

        #endregion Events
    }
}
