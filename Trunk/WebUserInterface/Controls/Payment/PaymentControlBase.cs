using System.Web.UI;
using DesignPatterns;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {
	public abstract class PaymentControlBase : Control, IFactory	{

		#region Fields

		protected string paymentMethod;
        protected string title;
        protected string bottom;
        protected StringWriter content = new StringWriter();

		#endregion Fields

        #region Private

        protected string GetTitle() {
            if (paymentMethod == "PaySafe") {
                return string.Format("<h2>{0} (<a href='{1}'>{1}</a>)</h2>", LanguageManager.Localize(paymentMethod), "http://www.paysafecard.com/");
            }
            return string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get(paymentMethod));
        }

        #endregion Private


		#region IFactory Members

		public abstract object create(object args);

		#endregion IFactory Members

		protected override void Render(HtmlTextWriter writer) {
            title = GetTitle();    
            bottom = string.Format("<a href='{1}Account/Payment.aspx'>{0}</a>", LanguageManager.Localize("OtherPaymentMethods"),WebUtilities.ApplicationPath);
            
            Border.RenderNormal("paymentType",writer,title,content.ToString(),bottom);
        }
       
	}
}
