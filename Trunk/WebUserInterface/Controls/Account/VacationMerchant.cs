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
using System;

namespace OrionsBelt.WebUserInterface.Controls {

	public class VacationMerchant : Control {

        #region Events

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            string option = Page.Request.QueryString["BuyDays"];
            if (!string.IsNullOrEmpty(option)) {
                int days = int.Parse(option);
                VacationsManager.BuyVacationDays(Utils.Principal, days, GetOrionsCost());
                Page.Response.Redirect("Vacations.aspx");
            }

            option = Page.Request.QueryString["ToggleAuto"];
            if (!string.IsNullOrEmpty(option)) {
                VacationsManager.ToogleAutoStartVacations(Utils.Principal);
                Page.Response.Redirect("Vacations.aspx");
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("BuyVacations"));

            StringWriter content = new StringWriter();
            content.Write("<p>");
            string toggleAutoStart = string.Format(LanguageManager.Localize("ToggleAutoStart"), VacationsManager.AutoStartVacationsTicks, VacationsManager.AutoStartVacationsCost);
            content.Write("<a href='Vacations.aspx?ToggleAuto=1'>{0}</a>", toggleAutoStart);
            content.Write("</p>");
            
            StringWriter bottom = new StringWriter();
            bottom.Write("<p>");
            string buy1DayVacations = string.Format(LanguageManager.Localize("Buy1DayVacations"),GetOrionsCost());
            bottom.Write("<a href='Vacations.aspx?BuyDays=1'>{0}</a>", buy1DayVacations);
            bottom.Write("</p>");

            writer.Write("<div id='buyVacations'>");
            Border.RenderMedium(writer,title,content.ToString(),bottom.ToString());
            writer.Write("</div>");

        }

        private int GetOrionsCost()
        {
            if (State.HasItems("VacationOrions")) {
                return (int) State.GetItems("VacationOrions");
            }

            int orions = 25;
            int lastMonth = Convert.ToInt32( Hql.ExecuteScalar("select count(t.Id) from SpecializedTransaction as t where t.IdentifierSpend = :principal and t.TransactionContext = 'Vacations' and t.CreatedDate > :date", 
                    Hql.Param("date", DateTime.Now.AddDays(-30)), Hql.Param("principal", Utils.Principal)
                ));

            orions = Convert.ToInt32( 25 * Math.Pow(2, lastMonth) );

            State.SetItems("VacationOrions", orions);

            return orions;
        }

        #endregion Events

    };
}

