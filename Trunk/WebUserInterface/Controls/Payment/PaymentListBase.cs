using System.Web.UI;


namespace OrionsBelt.WebUserInterface.Controls {
	public abstract class PaymentListBase : Control {

		#region Fields

		protected static readonly string[] paymentTypes = new string[]{ "PaySafe", "Paypal", "Sms", "OneBip", "SponsorPay" };
		protected static readonly int[] paymentValues = new int[] { 2,4,5,10,20,40 };

		#endregion Fields

	}
}

