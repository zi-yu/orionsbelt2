using System;
using System.Collections.Generic;
using System.Web.UI;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.PaymentSystems;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {
	[FactoryKey("OneBip")]
	public class OneBipControl : PaymentControlBase {

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
                OneBip p = new OneBip();
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
			return new OneBipControl();
		}

		#endregion IFactory Members

		#region Constructor

        public OneBipControl()
        {
			paymentMethod = "OneBip";
		}

		#endregion Constructor


	}
}

