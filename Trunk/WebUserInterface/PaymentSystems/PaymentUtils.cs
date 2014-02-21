using System.Collections.Generic;
using System;
namespace OrionsBelt.WebUserInterface.PaymentSystems
{
    public static class PaymentUtils
    {
        private static readonly Dictionary<CurrencyEnum, string> currencyToPaypal = new Dictionary<CurrencyEnum, string>(3);
        private static readonly Dictionary<string, string> numberAmmount = new Dictionary<string, string>(2);

        static PaymentUtils()
        {
            CurrencyToPaypal.Add(CurrencyEnum.Euro, "EUR");
            CurrencyToPaypal.Add(CurrencyEnum.USDollar, "USD");
            CurrencyToPaypal.Add(CurrencyEnum.Pound, "GBP");

            NumberAmmount.Add("68636", "2");
            NumberAmmount.Add("68638", "4");
        }

        public static Dictionary<CurrencyEnum, string> CurrencyToPaypal
        {
            get { return currencyToPaypal; }
        }

        public static Dictionary<string, string> NumberAmmount
        {
            get { return numberAmmount; }
        }

        public static int[] GetSerials(string data)
        {
            string[] values = data.Split(';');
            int[] toReturn = new int[values.Length/2];

            for (int iter = 0; iter*2 < values.Length; ++iter)
            {
                toReturn[iter] = Convert.ToInt32(values[iter*2]);
            }

            return toReturn;
        }
    }
}
