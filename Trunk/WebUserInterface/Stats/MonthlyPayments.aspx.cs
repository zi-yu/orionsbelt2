using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using System.Text;
using System.IO;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {

    public class MonthlyPayments : Page 
    {
        protected Literal info;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( State.HasCache("MonthlyPayment") ) {
                info.Text = State.GetCache("MonthlyPayment").ToString();
                return;
            }

            StringWriter sb = new StringWriter();
            sb.Write(
                "<table class='table'><tr><th>{0}</th><th>Paypal</th><th>Paysafe</th><th>Onebip</th><th>SMS</th><th>SponsorPay</th><th>{1}</th></tr>",
                LanguageManager.Instance.Get("Month"),LanguageManager.Instance.Get("Total"));

            IList<Payment> payments = GetPayments();

            int currMonth;
            if(payments.Count > 0)
            {
                currMonth = payments[0].CreatedDate.Month;
            }
            else
            {
                sb.Write("</table>");
                State.SetCache("MonthlyPayment",sb.ToString());
                info.Text = sb.ToString();
                return;
            }

            GenerateRows(sb, payments, currMonth);
            State.SetCache("MonthlyPayment",sb.ToString());
            info.Text = sb.ToString();
        }

        private static IList<Payment> GetPayments()
        {
            IList<Payment> payments;
            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                payments = 
                    persistance.TypedQuery("select p from SpecializedPayment p where p.VerifyState='Verified' or p.Method='SMS' order by p.CreatedDate");
            }
            return payments;
        }

        private static void GenerateRows(TextWriter sb, IEnumerable<Payment> payments, int currMonth)
        {
            double totMonthPaypal = 0;
            double totMonthPaysafe = 0;
            double totMonthOnebip = 0;
            double totMonthSms = 0;
            double totMonthSponsorPay = 0;
            double totPaypal = 0;
            double totPaysafe = 0;
            double totOnebip = 0;
            double totSms = 0;
            double totSponsorPay = 0;
            double total = 0;
            int year = 0;
            foreach (Payment payment in payments)
            {
                if(currMonth != payment.CreatedDate.Month)
                {
                    year = payment.CreatedDate.Month != 1 ? payment.CreatedDate.Year : payment.CreatedDate.Year - 1;
                    sb.Write("<tr><td>{0}/{1}</td><td>{2} €</td><td>{3} €</td><td>{4} €</td><td>{5} €</td><td>{6} €</td><td>{7} €</td>",
                             year, currMonth, totMonthPaypal, totMonthPaysafe, totMonthOnebip, totMonthSms, totMonthSponsorPay,
                             totMonthPaypal + totMonthPaysafe + totMonthOnebip + totMonthSms + totMonthSponsorPay);

                    total += totMonthPaypal + totMonthPaysafe + totMonthOnebip + totMonthSms + totMonthSponsorPay;
                    totPaypal += totMonthPaypal;
                    totPaysafe += totMonthPaysafe;
                    totOnebip += totMonthOnebip;
                    totSms += totMonthSms;
                    totSponsorPay += totMonthSponsorPay;

                    totMonthPaypal = 0;
                    totMonthPaysafe = 0;
                    totMonthOnebip = 0;
                    totMonthSms = 0;
                    totMonthSponsorPay = 0;
                    currMonth = payment.CreatedDate.Month;
                }
                
                double payValue = WebUtilities.GetDouble(payment.Ammount);
                switch(payment.Method)
                {
                    case "PayPal":
                        totMonthPaypal += payValue;
                        break;

                    case "PaySafe":
                        totMonthPaysafe += payValue;
                        break;

                    case "OneBip":
                        totMonthOnebip += payValue;
                        break;

                    case "SMS":
                        totMonthSms += payValue;
                        break;
                    case "SponsorPay":
                        totMonthSponsorPay += payValue;
                        break;
                }
                
            }

            sb.Write("<tr><td>{0}/{1}</td><td>{2} €</td><td>{3} €</td><td>{4} €</td><td>{5} €</td><td>{6} €</td><td>{7} €</td>",
                             year, currMonth, totMonthPaypal, totMonthPaysafe, totMonthOnebip, totMonthSms,totMonthSponsorPay,
                             totMonthPaypal + totMonthPaysafe + totMonthOnebip + totMonthSms + totMonthSponsorPay);

            total += totMonthPaypal + totMonthPaysafe + totMonthOnebip + totMonthSms + totMonthSponsorPay;
            totPaypal += totMonthPaypal;
            totPaysafe += totMonthPaysafe;
            totOnebip += totMonthOnebip;
            totSms += totMonthSms;
            totSponsorPay += totMonthSponsorPay;

            sb.Write("<tr><th/><th>{0} €</th><th>{1} €</th><th>{2} €</th><th>{3} €</th><th>{4} €</th><th>{5} €</th></table>",
                     totPaypal, totPaysafe, totOnebip, totSms, totSponsorPay, total);
        }
    }
}
