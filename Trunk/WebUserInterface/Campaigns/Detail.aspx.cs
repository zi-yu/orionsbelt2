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
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.DataAccessLayer;
using System.Collections.Generic;
using System.IO;
using OrionsBelt.WebComponents;
using Loki.DataRepresentation;

namespace OrionsBelt.WebUserInterface.Campaigns
{
    public class Detail : System.Web.UI.Page {

        #region Fields

        protected Literal title;
        protected CampaignLevelList levelList;

        public int CampaignId {
            get { 
                return int.Parse(HttpContext.Current.Request.QueryString["Id"]);            
            }
        }

        public string CampaignName {
            get { 
                string raw =HttpContext.Current.Request.QueryString["Campaign"];
                if (string.IsNullOrEmpty(raw)) {
                    throw new UIException("No Campaign name given");
                }
                return raw;
            }
        }

        #endregion Fields

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            levelList.Collection = GetCollection();
            State.SetItems("Levels", levelList.Collection);
            title.Text = LanguageManager.Localize(string.Format("{0}Title", CampaignName));
            SetCurrentPlayerLevel(levelList.Collection);
        }

        #endregion Events

        #region Utils

        private IList<CampaignLevel> GetCollection()
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) { 
                string[] hqls = {
                    "select level from SpecializedCampaignLevel level where level.CampaignNHibernate.Id = :campaign order by level.Level asc"
                    ,"select status from SpecializedCampaignStatus status where status.PrincipalNHibernate.Id = :principal and status.CampaignNHibernate.Id = :campaign"
                };
                Dictionary<string, object> args = new Dictionary<string,object>();
                args.Add("campaign", CampaignId);
                args.Add("principal", Utils.Principal.Id);

                IList all = (IList)session.MultiQuery(hqls, args);
                ArrayList rawLevels = (ArrayList)all[0];
                ArrayList statuses = (ArrayList)all[1];

                List<CampaignLevel> levels = new List<CampaignLevel>();
                foreach (CampaignLevel level in rawLevels) {
                    levels.Add(level);
                    level.CampaignStatus = new List<CampaignStatus>();
                    foreach (CampaignStatus status in statuses) {
                        if (status.LevelTemplate.Id == level.Id) {
                            List<CampaignStatus> specificStatus = new List<CampaignStatus>();
                            specificStatus.Add(status);
                            level.CampaignStatus = specificStatus;
                            break;
                        }
                    }
                }
                return levels;
            }
            
        }

        private void SetCurrentPlayerLevel(IList<CampaignLevel> levels)
        {
            foreach (CampaignLevel level in levels) {
                if (level.CampaignStatus == null || level.CampaignStatus.Count == 0) {
                    return;
                }
                State.SetItems("CurrCampaignLevel", level);
                State.SetItems("CurrCampaignStatus", level.CampaignStatus[0]);
                if (!level.CampaignStatus[0].Completed) {
                    return;
                }
            }
            
        }

        #endregion Utils

    };
}
