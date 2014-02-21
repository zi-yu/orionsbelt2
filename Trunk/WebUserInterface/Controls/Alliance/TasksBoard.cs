using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Text;

namespace OrionsBelt.WebUserInterface.Controls {

    public class TasksBoard : Control {

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            int id = AllianceWebUtils.Current.Storage.Id;
            IList<Task> tasks;
            using (ITaskPersistance persistance = Persistance.Instance.GetTaskPersistance())
            {
                tasks = persistance.TypedQuery("select e from SpecializedTask e inner join fetch e.NecessityNHibernate n where n.AllianceNHibernate.Id={0} and e.Status <> 'Closed' order by e.CreatedDate desc", id);
            }
            writer.Write("<table class='newtable'><tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th></tr>",
                LanguageManager.Instance.Get("Title"),LanguageManager.Instance.Get("Description"),LanguageManager.Instance.Get("Status"),
                LanguageManager.Instance.Get("Priority"),LanguageManager.Instance.Get("AssignedTo"),
                LanguageManager.Instance.Get("Coordinates"), LanguageManager.Instance.Get("CreatedAt"), LanguageManager.Instance.Get("Manage"));

            PlayerStorage player = PlayerUtils.Current.Storage;
            foreach (Task task in tasks)
            {
                writer.Write("<tr class='{7}'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{8}</td></tr>",
                task.Title, task.Necessity.Description, LanguageManager.Instance.Get(task.Status),
                LanguageManager.Instance.Get(task.Priority), AssignedToWriter(task),task.Necessity.Coordinate,
                TimeFormatter.GetFormattedTicksSince(task.CreatedDate), task.Priority.ToLower(), GetEditFunctions(task, player));

            }
            writer.Write("</table>");
        }

        private static string GetEditFunctions(Task task, PlayerStorage player)
        {
            string view = string.Format("<a href='TaskView.aspx?Task={0}'><img src='{1}' alt='edit' title='view'></a>&nbsp;",
                task.Id, ResourcesManager.GetForumImage("View.png"));
            
            if (player.AllianceRank == AllianceRank.Admiral.ToString())
            {
                return string.Format(
                    "{3}<a href='TaskEdit.aspx?Task={2}'><img src='{0}' alt='edit' title='edit'></a>&nbsp;<a href='javascript:DeleteTask({2})'><img src='{1}' alt='delete' title='delete'></a>",
                    ResourcesManager.GetForumImage("Edit.gif"), ResourcesManager.GetForumImage("Delete.gif"), task.Id,view);
            }
            else
            {
                foreach (Asset asset in task.Assets)
                {
                    if (asset.Owner == player)
                    {
                        return string.Format("{2}<a href='TaskEdit.aspx?Task={1}'><img src='{0}' alt='edit' title='edit'></a>",
                                     ResourcesManager.GetForumImage("Edit.gif"), task.Id,view);
                    }
                }
            }
            return view;
        }

        private static string AssignedToWriter(Task task)
        {
            StringBuilder sb = new StringBuilder();
            IList<PlayerStorage> list = new List<PlayerStorage>();

            foreach (Asset asset in task.Assets)
            {
                if(!list.Contains(asset.Owner))
                {
                    list.Add(asset.Owner);
                }

            }
            foreach (PlayerStorage player in list)
            {
                sb.Append(WebUtilities.WritePlayerWithAvatar(player, true, false));

            }
            return sb.ToString();
        }


        #endregion Events

    };

}
