using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {
	public class PaymentList : PaymentListBase {

		#region Private

        private static void WritePaymentTypes(StringWriter writer) {
            writer.Write("<table id='payments'>");
			foreach (string payment in paymentTypes) {
                string localizedPayment = LanguageManager.Instance.Get(payment);
                string localizedPaymentDescription = LanguageManager.Instance.Get(payment + "Description");

                writer.Write("<tr><td>");
                writer.Write("<a href='{0}Account/PaymentType.aspx?Type={1}'>", WebUtilities.ApplicationPath,
                             payment);
                writer.Write("<img src='{0}' alt='{1}' title='{1}'/>", ResourcesManager.GetPaymentsImage(payment),
                             localizedPayment);
                writer.Write("<h3 class='paymentTitle'>{0}</h3>", localizedPayment);
                writer.Write("<p>{0}</p>", localizedPaymentDescription);
                writer.Write("</a>");
                writer.Write("</td></tr>");
			}
            writer.Write("</table>");
		}

		#endregion Private

		#region Control Events

		protected override void Render(HtmlTextWriter writer) {
            string title = string.Format("<h2>{0}</h2>",LanguageManager.Instance.Get("BuyOrions"));

			
            StringWriter content = new StringWriter();
			WritePaymentTypes(content);
            Border.RenderMediumNoBottom("payment", writer, title, content.ToString());
            content.Close();
			
        }

		#endregion Control Events

	}
}

