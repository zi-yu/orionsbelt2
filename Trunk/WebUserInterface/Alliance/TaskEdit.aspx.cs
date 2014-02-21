using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class TaskEdit : System.Web.UI.Page
    {

        protected Button update;
        protected DropDownList priority, status;
        protected TextBox title;
        protected Literal typeNec;

        protected AssetTypeSort typeA;
        protected AssetOwnerSort owner;
        protected AssetCoordinateSort coordinateA;
        protected AssetCreatedDateSort dateA;
        protected AssetPagedList assets;

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Task task = EntityUtils.GetFromQueryString<Task>();
            title.Text = task.Title;
            typeNec.Text = LanguageManager.Instance.Get(task.Necessity.Type);

            PreparePriorityDropDown(task);
            PrepareStatusDropDown(task);

            int id = AllianceWebUtils.Current.Storage.Id;

            typeA.InnerHTML = LanguageManager.Instance.Get("Type");
            coordinateA.InnerHTML = LanguageManager.Instance.Get("Coordinates");
            dateA.InnerHTML = LanguageManager.Instance.Get("CreatedAt");
            owner.InnerHTML = LanguageManager.Instance.Get("Owner");
            assets.Where = string.Format("(e.TaskNHibernate is null or e.TaskNHibernate.Id={1}) and e.AllianceNHibernate.Id={0}", id,task.Id);
        }


        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            update.Text = LanguageManager.Instance.Get("Update");

        }

        protected void Send(object sender, EventArgs e)
        {
            IList<int> assetsL = new List<int>();
            Task task = EntityUtils.GetFromQueryString<Task>();
            GetChecks(assetsL);

            IList<Asset> res = new List<Asset>();

            PrepareAssets(assetsL, task, res);


            using (ITaskPersistance persistance = Persistance.Instance.GetTaskPersistance())
            {
                
                task.Title = title.Text;
                task.Priority = priority.SelectedValue;
                task.Status = status.SelectedValue;
                persistance.Update(task);

                using (IAssetPersistance persistance2 = Persistance.Instance.GetAssetPersistance(persistance))
                {
                    foreach (Asset re in res)
                    {
                        persistance2.Update(re);
                    }
                }

                persistance.Flush();
            }
            Page.Response.Redirect(string.Format("Tasks.aspx?Id={0}", PlayerUtils.Current.Alliance.Storage.Id));
        }

        private void PrepareAssets(IList<int> assetsL, Task task, IList<Asset> res)
        {
            IList<Asset> toAnalyse = Hql.StatelessQuery<Asset>(string.Format("{0} where {1}", assets.Select, assets.Where));
            foreach (Asset asset in toAnalyse)
            {
                if (assetsL.Contains(asset.Id))
                {
                    asset.Task = task;
                    res.Add(asset);
                }
                else
                {
                    if(asset.Task != null)
                    {
                        asset.Task = null;
                        res.Add(asset);
                    }
                }
            }
        }

        private void GetChecks(ICollection<int> assetsL)
        {
            foreach (string key in Request.Form.AllKeys)
            {
                if (key.StartsWith("ckA_"))
                {
                    assetsL.Add(Convert.ToInt32(key.Substring(4)));
                }
            }
        }

        #endregion Events


        private void PrepareStatusDropDown(Task task)
        {
            foreach (StatusEnum elem in Enum.GetValues(typeof(StatusEnum)))
            {
                if (elem.ToString() == "NotAssigned" || elem.ToString() == "Closed")
                {
                    continue;
                }

                if (elem.ToString() == task.Status)
                {
                    status.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString(), true));
                }
                else
                {
                    status.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
                }

            }
        }

        private void PreparePriorityDropDown(Task task)
        {
            foreach (PriorityEnum elem in Enum.GetValues(typeof(PriorityEnum)))
            {
                if (elem.ToString() == task.Priority)
                {
                    priority.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString(), true));
                }
                else
                {
                    priority.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
                }

            }
        }

    };
}
