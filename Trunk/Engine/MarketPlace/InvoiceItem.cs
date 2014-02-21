using System;
using System.Collections;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.MarketPlace
{
    public class InvoiceItem : IComparable<InvoiceItem>
    {
        #region fields

        private Country country;
        private bool isCorporate=false;
        private double money=0;

        #endregion fields

        #region properties

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }

        public bool IsCorporate
        {
            get { return isCorporate; }
            set { isCorporate = value; }
        }

        public double Money
        {
            get { return money; }
            set { money = value; }
        }

        #endregion properties


        public InvoiceItem(Country country, bool isCorporate, double money)
        {
            Country = country;
            IsCorporate = isCorporate;
            Money = money;
        }

        public int CompareTo(InvoiceItem other)
        {
            int value = string.Compare(Country.Name, other.Country.Name);

            if(value != 0)
            {
                return value;
            }
            return string.Compare(IsCorporate.ToString(), other.IsCorporate.ToString());

        }

    }
}
