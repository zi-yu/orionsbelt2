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

	public class BuyOrionsMenu : Control {

        #region Events

        protected override void OnInit(System.EventArgs e) {
            base.OnInit(e);
            AccountMenu.CurrentPage = "Payment";
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<ul class='submenu'>");

            writer.Write("<li><a href='{0}Account/Payment.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("BuyOrions"));
            writer.Write("<li><a href='{0}Account/Extract.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("Extract"));
            writer.Write("<li><a href='{0}Account/PaymentHistory.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("PaymentHistory"));
            writer.Write("<li><a href='{0}Account/DiscountBonus.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("DiscountBonus"));
            writer.Write("</ul>");
        }

        #endregion Events

    };
}

