using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Engine.Quests;
using System.IO;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

	public class ProfessionStatus : Control {

        #region Events

        protected override void Render(HtmlTextWriter mainwriter)
        {
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("ProfessionStatus"));

            StringWriter writer = new StringWriter();

            writer.Write("<table class='newtable'>");
            writer.Write("<tr>");
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Pirate"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("BountyHunter"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Merchant"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Colonizer"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Gladiator"));
            writer.Write("</tr>");
            writer.Write("<tr>");
            writer.Write("<td>{0}</td>", PlayerUtils.Current.PirateRanking);
            writer.Write("<td>{0}</td>", PlayerUtils.Current.BountyRanking);
            writer.Write("<td>{0}</td>", PlayerUtils.Current.MerchantRanking);
            writer.Write("<td>{0}</td>", PlayerUtils.Current.ColonizerRanking);
            writer.Write("<td>{0}</td>", PlayerUtils.Current.GladiatorRanking);
            writer.Write("</tr>");
            writer.Write("</table>");

            string bottom = string.Format("<div class='centerMessage'>{0}</div>", string.Format(LanguageManager.Instance.Get("CurrentProfessionStatus"), LanguageManager.Instance.Get(PlayerUtils.Current.MainProfession.ToString())));

            Border.RenderBig("questProfessionStatus",mainwriter, title, writer.ToString(), bottom);
        }

        #endregion Events

    };
}

