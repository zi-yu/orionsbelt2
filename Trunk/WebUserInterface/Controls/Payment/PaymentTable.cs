
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class PaymentTable : PaymentListBase {

		#region Private

		private static string WriteTable(HtmlTextWriter htmlwriter) {
			StringWriter writer = new StringWriter();
			writer.Write("<table id='paymentsTable' class='newtable'>");
			WriteTitle(writer);
			WriteDefaultCost(writer);
            writer.Write("</table>");

            writer.Write("<h3 onclick='Utils.showHidePayment();'><div id='plusSign' class='plus'></div>{0}</h3>", LanguageManager.Instance.Get("GivenBonus"));
            writer.Write("<table id='bonusTable' class='newtable hidden'>");
			WritePaymentQuantities(writer);
			writer.Write("</table>");
			return writer.ToString();
		}

		private static void WriteTitle(TextWriter writer) {
			writer.Write("<tr><th></th>");
			foreach (int value in paymentValues) {
				writer.Write("<th>{0}€</th>",value);
			}
			writer.Write("</tr>");
		}

		private static string GetOrionsImage() {
			return string.Format(" <img src='{0}' alt='Orions' title='Orions'/>", ResourcesManager.GetIconsImage("Orions"));
		}

		private static void WriteDefaultCost(TextWriter writer) {
			writer.Write("<tr>");
			writer.Write("<td>{0}</td>",LanguageManager.Localize("BoughtOrions"));
			foreach (int value in paymentValues) {
				writer.Write("<td>{0}{1}</td>", value*200, GetOrionsImage());	
			}
			writer.Write("</tr>");
		}

		private static void WritePaymentQuantities(TextWriter writer) {
            WriteTitle(writer);
			foreach (string payment in paymentTypes) {
				writer.Write("<tr>");
				writer.Write("<td><a href='{2}Account/PaymentType.aspx?Type={3}'><img src='{0}' alt='{1}' title='{1}'/></a/></td>", ResourcesManager.GetPaymentsImage(payment), LanguageManager.Instance.Get(payment + "ToolTip"), WebUtilities.ApplicationPath, payment);
				List<PaymentDescription> paypalDescriptions = PaymentDescriptionLoader.GetPaymentDescriptions(payment);
				foreach (int value in paymentValues) {
					PaymentDescription description = paypalDescriptions.Find(delegate(PaymentDescription p) { return p.Cost == value; });
					if (description == null) {
						writer.Write("<td>{0}</td>", LanguageManager.Instance.Get("NotAvailable"));
					}else {
						writer.Write("<td>{0}{1}</td>", description.Bonus, GetOrionsImage());
					}
				}
				writer.Write("</tr>");
			}
		}

		#endregion Private

		#region Control Events

		protected override void Render(HtmlTextWriter htmlwriter) {
            string title = string.Format("<h2>{0}</h2>",LanguageManager.Instance.Get("PaymentSystem"));
			string content = WriteTable(htmlwriter);
            Border.RenderMediumNoBottom("paymentTable", htmlwriter, title, content);
        }

		#endregion Control Events

	}
}