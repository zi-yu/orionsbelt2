using System;
using System.Collections.Generic;
using System.Web.UI;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.PaymentSystems;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	[FactoryKey("SponsorPay")]
	public class SponsorPayControl : PaymentControlBase {

		#region Control Events

		protected override void Render(HtmlTextWriter writer) {
            content.Write("<div id='sponsorPlay'>");
            SponsorPay p = new SponsorPay();
			string render = p.Render(Utils.Principal, CurrencyEnum.Euro, null);
            content.Write(render);
            content.Write("</div>");

            title = GetTitle();
            bottom = string.Format("<a href='{1}Account/Payment.aspx'>{0}</a>", LanguageManager.Localize("OtherPaymentMethods"), WebUtilities.ApplicationPath);

            Border.RenderBig("paymentType", writer, title, content.ToString(), bottom);

		}

		#endregion Control Events

		#region IFactory Members

		public override object create(object args) {
			return new SponsorPayControl();
		}

		#endregion IFactory Members

		#region Constructor

        public SponsorPayControl()
        {
			paymentMethod = "SponsorPay";
		}

		#endregion Constructor


	}
}

