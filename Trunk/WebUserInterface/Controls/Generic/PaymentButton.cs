using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebUserInterface.PaymentSystems;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PaymentButton : Control
    {
        private double quantity = 0;
        private string imgUrl = string.Empty;
        private Principal principal = null;
        private CurrencyEnum currency = CurrencyEnum.Euro;

        #region Properties

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string ImgUrl
        {
            get { return imgUrl; }
            set { imgUrl = value; }
        }

        public Principal AccountPrincipal
        {
            get { return principal; }
            set { principal = value; }
        }

        public CurrencyEnum Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        #endregion Properties

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            if (0 == quantity)
            {
                throw new Exception("Quantity not defined");
            }
            if (null == principal)
            {
                throw new Exception("No Principal defined");
            }
            IPayment payment = new Paypal();
        	PaymentDescription p = Persistance.Create<PaymentDescription>();
        	p.Amount = 1000;
        	p.Cost = quantity;
			p.Bonus = 0;
			writer.Write(payment.Render(principal, currency, p));
        }

        #endregion Events
    } ;
}