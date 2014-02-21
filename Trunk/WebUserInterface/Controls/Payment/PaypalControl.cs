using System;
using System.Collections.Generic;
using System.Web.UI;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.PaymentSystems;

namespace OrionsBelt.WebUserInterface.Controls {
	[FactoryKey("Paypal")]
	public class PaypalControl : PaymentControlBase {

		#region Control Events

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			MainForm master = (MainForm)State.Items["MainForm"];
			master.RenderFormTag = false;
		}

		protected override void Render(HtmlTextWriter writer) {
			
			List<PaymentDescription> paypalDescriptions = PaymentDescriptionLoader.GetPaymentDescriptions(paymentMethod);
            content.Write("<table class='newtable'>");
			foreach (PaymentDescription description in paypalDescriptions) {
                content.Write("<tr><td>");
				Paypal p = new Paypal();
				string render = p.Render(Utils.Principal, CurrencyEnum.Euro, description);
                content.Write(render);
                content.Write("</td></tr>");
			}
            content.Write("</table>");

            base.Render(writer);
		}

		#endregion Control Events

		#region IFactory Members

		public override object create(object args) {
			return new PaypalControl();
		}

		#endregion IFactory Members

		#region Constructor

		public PaypalControl() {
			paymentMethod = "Paypal";
		}

		#endregion Constructor


	}
}

