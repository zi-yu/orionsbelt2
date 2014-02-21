using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Core;
using System.IO;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

	public class VacationManager: Control {

        #region Events

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            string toogle = Page.Request.QueryString["Toggle"];
            if (!string.IsNullOrEmpty(toogle)) {
                VacationsManager.ToogleVacations(Utils.Principal);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string buttonToken;
            
            StringWriter content = new StringWriter();
            content.Write("<dl>");

            content.Write("<dt>{0}</dt><dd>",LanguageManager.Localize("Status"));
            Principal principal = Utils.Principal;
            if (principal.VacationStartTick > 0) {
                content.Write("In Vacations");
                buttonToken = "ExitVacations";
            } else {
                content.Write("Active");
                buttonToken = "EnterVacations";
            }
            content.Write("</dd>");

            content.Write("<dt>{1}</dt><dd>{0}</dd>", principal.AutoStartVacations, LanguageManager.Localize("AutoStart"));
            content.Write("<dt>{1}</dt><dd>{0} Ticks</dd>", principal.AvailableVacationTicks, LanguageManager.Localize("ToSpend"));
            content.Write("<dt>{1}</dt><dd>{0}</dd>", principal.VacationStartTick, LanguageManager.Localize("StartTick"));
            content.Write("<dt>{1}</dt><dd>{0}</dd></dl>", principal.VacationEndtick, LanguageManager.Localize("EndTick"));

            string bottom = string.Format("<div class='button'><a href='Vacations.aspx?Toggle=true'>{0}</a></div>", LanguageManager.Localize(buttonToken));
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("Vacations"));

            writer.Write("<div id='vacations'>");
            Border.RenderSmall(writer, title, content.ToString(), bottom);
            writer.Write("</div>");
        }

        #endregion Events

    };
}

