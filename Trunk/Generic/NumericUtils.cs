using System.Globalization;
using System;

namespace OrionsBelt.Generic
{
    public static class NumericUtils
    {

        /// <summary>
        /// Gets a double overriding the machine settings
        /// </summary>
        /// <param name="value">Value to be parse to a double</param>
        /// <param name="separator">Type of separator between the int part and the decimal part</param>
        /// <returns>A double value for the string pass as parameter</returns>
        public static double GetDouble(string value, string separator)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = separator;
            return double.Parse(value, nfi);
        }

        /// <summary>
        /// Gets a double overriding the machine settings
        /// </summary>
        /// <param name="value">Value to be parse to a double</param>
        /// <returns>A double value for the string pass as parameter</returns>
        public static double GetDouble(string value)
        {
            return GetDouble(value, ",");
        }

        /// <summary>
        /// Gets an int with the value of a decimal part
        /// </summary>
        /// <param name="value">Value to get the decimal part</param>
        /// <returns>An int representing the decimal part</returns>
        public static int GetDecimalPart(double value)
        {
            int number = (int) value;
            string numbString = number.ToString();
            int stringLength = numbString.Length;

            if (value.ToString().Length < stringLength + 1)
                return 0;

            return Int32.Parse(value.ToString().Substring(stringLength+1));
        }

        /// <summary>
        /// Gets the lower number power of 2 bigger that the parameter
        /// </summary>
        /// <param name="number">Number to be evaluated</param>
        /// <returns>The next number power of 2</returns>
        public static int GetNext2Pow(int number)
        {
            int playerRequired = 2;
            while (playerRequired < number)
            {
                playerRequired *= 2;
            }
            return playerRequired;
        }
        
    }
}
