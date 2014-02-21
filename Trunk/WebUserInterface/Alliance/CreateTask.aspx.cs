using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class CreateTask : System.Web.UI.Page
    {
        protected DropDownList priority;
        protected TextBox title;
        protected Button button;

        protected NecessityTypeSort typeN;
        protected NecessityCreatorSort creator;
        protected NecessityCoordinateSort coordinateN;
        protected NecessityCreatedDateSort dateN;
        protected NecessityPagedList necessities;

        protected AssetTypeSort typeA;
        protected AssetOwnerSort owner;
        protected AssetCoordinateSort coordinateA;
        protected AssetCreatedDateSort dateA;
        protected AssetPagedList assets;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            foreach (PriorityEnum elem in Enum.GetValues(typeof(PriorityEnum)))
            {
                priority.Items.Add(new ListItem(LanguageManager.Instance.Get(elem.ToString()), elem.ToString()));
            }
            button.Text = LanguageManager.Instance.Get("Create");

            int id = AllianceWebUtils.Current.Storage.Id;

            typeN.InnerHTML = LanguageManager.Instance.Get("Type");
            coordinateN.InnerHTML = LanguageManager.Instance.Get("Coordinates");
            dateN.InnerHTML = LanguageManager.Instance.Get("CreatedAt");
            creator.InnerHTML = LanguageManager.Instance.Get("Owner");
            necessities.Where = string.Format("e.Status = 'NotAssigned' and e.AllianceNHibernate.Id={0}", id);

            typeA.InnerHTML = LanguageManager.Instance.Get("Type");
            coordinateA.InnerHTML = LanguageManager.Instance.Get("Coordinates");
            dateA.InnerHTML = LanguageManager.Instance.Get("CreatedAt");
            owner.InnerHTML = LanguageManager.Instance.Get("Owner");
            assets.Where = string.Format("e.TaskNHibernate is null and e.AllianceNHibernate.Id={0}", id);
            AllianceMenu.CurrentPage = "Tasks";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (PlayerUtils.Current.AllianceRank != AllianceRank.Admiral)
            {
                ErrorBoard.AddLocalizedMessage("NoAdmiral");
                button.Enabled = false;
            }
        }

        protected void Send(object sender, EventArgs e)
        {
            IList<int> necessitiesL = new List<int>();
            IList<int> assetsL = new List<int>();

            GetChecks(necessitiesL, assetsL);

            if (necessitiesL.Count != 1)
            {
                ErrorBoard.AddLocalizedMessage("SelectANecessity");
                return;
            }

            using (ITaskPersistance persistance = Persistance.Instance.GetTaskPersistance())
            {
                Task task = persistance.Create();
                IList<Asset> res = new List<Asset>();
                if(assetsL.Count == 0)
                {
                    task.Status = StatusEnum.NotAssigned.ToString();
                }
                else
                {
                    task.Status = StatusEnum.Assigned.ToString();
                    IList<Asset> toAnalyse = Hql.StatelessQuery<Asset>(string.Format("{0} where {1}", assets.Select, assets.Where));
                    foreach (Asset asset in toAnalyse)
                    {
                        if(assetsL.Contains(asset.Id))
                        {
                            res.Add(asset);
                        }
                    }
                }
                task.Priority = priority.SelectedValue;
                task.Title = title.Text;
                task.Assets = res;
                task.Necessity =
                    Hql.StatelessQuery<Necessity>("select e from SpecializedNecessity e where e.Id=:id", Hql.Param("id", necessitiesL[0]))[0];
                
                persistance.Update(task);

                PrepareRelations(persistance, task, res);

                persistance.Flush();
            }

            PlayerStorage player = PlayerUtils.Current.Storage;
            Messenger.Add(Category.Task, typeof (TaskCreatedMessage), player.Alliance.Id,
                          string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
                                        WebUtilities.ApplicationPath, player.Id, player.Name),
                          string.Format("{0}Alliance/Tasks.aspx?Id={1}",
                                        WebUtilities.ApplicationPath, player.Alliance.Id));

            InformationBoard.AddLocalizedMessage("SucessOperation");
        }

        private static void PrepareRelations(ITaskPersistance persistance, Task task, IEnumerable<Asset> res)
        {
            using (INecessityPersistance persistance2 = Persistance.Instance.GetNecessityPersistance(persistance))
            {
                task.Necessity.Status = StatusEnum.Assigned.ToString();
                persistance2.Update(task.Necessity);
            }

            using (IAssetPersistance persistance2 = Persistance.Instance.GetAssetPersistance(persistance))
            {
                foreach (Asset re in res)
                {
                    re.Task = task;
                    persistance2.Update(re);
                }                   
            }
        }

        private void GetChecks(IList<int> necessitiesL, IList<int> assetsL)
        {
            foreach (string key in Request.Form.AllKeys)
            {
                if (key.StartsWith("ckN_"))
                {
                    necessitiesL.Add(Convert.ToInt32(key.Substring(4)));
                }

                if (key.StartsWith("ckA_"))
                {
                    assetsL.Add(Convert.ToInt32(key.Substring(4)));
                }
            }
        }
    }
}
