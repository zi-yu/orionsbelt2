
using System.Collections.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System;
using System.Text;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.MarketPlace
{
    public static class InvoiceUtils
    {
        private static readonly IDictionary<int, string> countryMap = new Dictionary<int, string>(10);

        static InvoiceUtils()
        {
            countryMap.Add(0, "EG");
            countryMap.Add(1, "CA");
            countryMap.Add(2, "US");
            countryMap.Add(3, "AU");
            countryMap.Add(4, "BR");
            countryMap.Add(5, "ZA");
            countryMap.Add(6, "VE");
            countryMap.Add(7, "RU");
            countryMap.Add(8, "IN");
            countryMap.Add(9, "CN");
        }
        /// <summary>
        /// Regists a payment invoice. Must be call in a nhibernate transaction context
        /// </summary>
        /// <param name="association">Associated transaction</param>
        /// <param name="payment">Payment regist</param>
        /// <param name="money">Payed money</param>
        /// <param name="persistance">Persistance session</param>
        public static void GenerateInvoice(Transaction association,Payment payment, double money, IPersistanceSession persistance)
        {
            using (IInvoicePersistance persistance2 = Persistance.Instance.GetInvoicePersistance(persistance))
            {
                string mainBlock = string.Format("OB/{0}/", DateTime.Now.Year);
                long invoiceNumber = 
                    persistance2.ExecuteScalar("select count(e) from SpecializedInvoice e where e.Identifier like '{0}%'", 
                    mainBlock)+1;

                Invoice invoice = persistance2.Create();
                invoice.Money = money;
                invoice.Transaction = association;
                invoice.Payment = payment;
                invoice.Identifier = GetIdentifier(mainBlock, invoiceNumber);
                persistance2.Update(invoice);
            }
        }

        public static string GetCountriesHtml(string where, IList<Country> countries, double iva)
        {
            if(string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            StringBuilder sb = new StringBuilder();
            IList<Invoice> data;
            using (IInvoicePersistance persistance = Persistance.Instance.GetInvoicePersistance())
            {
                data =
                    persistance.TypedQuery(
                        "SELECT e FROM SpecializedInvoice e where {0}",
                        where);
            }

            IList<InvoiceItem> info = GetInvoices(data, countries);

            sb.Append(string.Format("<table class='table'><tr><th>{0}</th><th>{3}</th><th>{1}</th><th>{2}</th><th>{1}-{2}</th></tr>",
                                    LanguageManager.Instance.Get("Country"), LanguageManager.Instance.Get("Money"),
                                    LanguageManager.Instance.Get("TaxValue"), LanguageManager.Instance.Get("IsCorporate")));

            double total = 0, euSum = 0, taxTotal = 0;
            foreach (InvoiceItem row in info)
            {
                double value = row.Money;
                
                taxTotal += WriteCountryRow(sb, row, iva, value);
                if (row.Country.IsEU && row.Country.Abbreviation != "PT")
                {
                    euSum += value;
                }
                total += value;
            }
            sb.Append(string.Format("<tr><th colspan='2'>{1} ({2})</th><td>{0} €</td><td>0 €</td><td>{0} €</td></tr>", euSum,
                                LanguageManager.Instance.Get("EuropeanUnion"),LanguageManager.Instance.Get("ExcludePt")));
            sb.Append(string.Format("<tr><th colspan='2'>{1}</th><th>{0} €</th><th>{2} €</th><th>{3} €</th></tr></table>", total,
                                LanguageManager.Instance.Get("Total"),taxTotal, total-taxTotal));
            return sb.ToString();
        }

        public static Country GetCountry(IEnumerable<Country> countries, string code)
        {
            foreach (Country country in countries)
            {
                if(country.Abbreviation == code)
                {
                    return country;
                }
            }
            return null;
        }

        public static Country GetCountry(string code)
        {
            IList<Country> countries;
            if (State.HasCache("CountriesTable"))
            {
                countries = (IList<Country>)State.GetCache("CountriesTable");
            }
            else
            {
                using (ICountryPersistance persistance = Persistance.Instance.GetCountryPersistance())
                {
                    countries = persistance.Select();
                    State.SetCache("CountriesTable", countries);
                }
            }
            return GetCountry(countries, code);
        }

        public static bool IsCorporate(Invoice invoice)
        {
            if (!string.IsNullOrEmpty(invoice.Nif) && invoice.Nif.Length > 0)
            {
                return invoice.Nif[0] == '5';
            }
            return false;
        }

        private static List<InvoiceItem> GetInvoices(IEnumerable<Invoice> data,IEnumerable<Country> countries)
        {
            List<InvoiceItem> toReturn = new List<InvoiceItem>();

            foreach (Invoice invoice in data)
            {
                Country country = GetNewCountryIfNull(invoice, countries);
                InvoiceItem item = new InvoiceItem(country, IsCorporate(invoice), invoice.Money);
                int iter = FindIndex(toReturn, item);
                if(iter < 0)
                {
                    toReturn.Add(item);
                }
                else
                {
                    toReturn[iter].Money += invoice.Money;
                }
            }

            toReturn.Sort();

            return toReturn;
        }

        private static int FindIndex(IList<InvoiceItem> list, InvoiceItem item)
        {
            for (int iter = 0; iter < list.Count; ++iter)
            {
                if(list[iter].Country == item.Country && list[iter].IsCorporate == item.IsCorporate)
                {
                    return iter;
                }
            }
            return -1;
        }

        private static Country GetNewCountryIfNull(Invoice invoice, IEnumerable<Country> countries)
        {
            if(!string.IsNullOrEmpty(invoice.Country))
            {
                return GetCountry(countries, invoice.Country);
            }
            if(invoice.Payment.Method == "SMS")
            {
                return GetCountry(countries, "PT");
            }
            return GetCountry(countries, countryMap[invoice.Id%10]);
        }

        private static double WriteCountryRow(StringBuilder sb, InvoiceItem row, double iva, double value)
        {
            double tax = 0;
            double final = value;
            if (row.Country.Abbreviation == "PT" || (row.IsCorporate && row.Country.IsEU))
            {
                tax = iva*value;
                final = value - tax;
            }
            string trueFalse;
            if (row.IsCorporate)
            {
                trueFalse = "<div class='true'/>";
            }
            else
            {
                trueFalse = "<div class='false'/>";
            }
            sb.Append(string.Format("<tr><td>{1}</td><td>{4}</td><td>{0} €</td><td>{2} €</td><td>{3} €</td></tr>", value,
                                        LanguageManager.Instance.Get(row.Country.Name), tax, final, trueFalse));

            return tax;
        }

        private static string GetIdentifier(string mainBlock, long invoiceNumber)
        {
            return string.Format("{0}{1}",mainBlock ,invoiceNumber.ToString().PadLeft(7, '0'));
        }
    }
}
