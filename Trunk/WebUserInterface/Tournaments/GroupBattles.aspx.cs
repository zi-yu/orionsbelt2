using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using System.Text;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {

    public class GroupBattles : Page 
    {
        protected Literal containe;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            int groupId = Int32.Parse(HttpContext.Current.Request.QueryString["Group"]);
            IList<Battle> battles;

            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                battles = persistance.TypedQuery("SELECT e FROM SpecializedBattle e inner join fetch e.GroupNHibernate WHERE e.GroupNHibernate.Id={0}", groupId);
            }

            TextWriter sb = new StringWriter();
			sb.Write("<table class='table'><tbody><tr><th>{0}</th><th>{2}</th><th>{3}</th><th>{1}</th></tr>", 
                LanguageManager.Instance.Get("CurrentTurn"), LanguageManager.Instance.Get("Finished"),
                LanguageManager.Instance.Get("Players"), LanguageManager.Instance.Get("Score"));
            foreach (Battle battle in battles)
            {
                sb.Write("<tr><td>{0}</td>", battle.CurrentTurn);
                WriteVs(sb, battle);
                WriteHasEnded(sb, battle);
                sb.Write("</tr>");
            }
			sb.Write("</tbody></table>");
            containe.Text = sb.ToString();
        }

        private static void WriteVs(TextWriter sb, Battle battle)
        {
            StringBuilder vs = new StringBuilder();
            StringBuilder score = new StringBuilder();
            bool isFirst = true;
            bool hasPositioned = true;
            foreach (PlayerBattleInformation information in battle.PlayerInformation)
            {
                if(isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    vs.Append(" - ");
                    score.Append(" - ");
                }
                vs.Append(information.Name);
                score.Append(information.WinScore);
                if(!information.HasPositioned)
                {
                    hasPositioned = false;
                }
            }
            if (hasPositioned)
            {
                sb.Write("<td><a href='{1}Battle/Battle.aspx?Id={2}'>{0}</a></td>", vs, WebUtilities.ApplicationPath,
                         battle.Id);
            }
            else
            {
                sb.Write("<td>{0}</td>", vs);
            }
            sb.Write("<td>{0}</td>", score);
        }

        private static void WriteHasEnded(TextWriter sb, Battle battle)
        {
            if (battle.HasEnded)
            {
                sb.Write("<td><div class='true'/></td>");
            }
            else
            {
                sb.Write("<td><div class='false'/></td>");
            }
        }
    }
}
