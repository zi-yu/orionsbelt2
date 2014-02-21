using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces
{
    public interface IAuctionItem
    {
        #region Properties

        /// <summary>
        /// Resource identifier
        /// </summary>
        string Identifier { get;}

        /// <summary>
        /// Resource identifier in a short string format
        /// </summary>
        string ShortIdentifier { get;}

        /// <summary>
        /// Resource quantity
        /// </summary>
        int Quantity { get;}

        /// <summary>
        /// The owner planet info
        /// </summary>
        int IsComplexType { get;}

        /// <summary>
        /// Base price for the item
        /// </summary>
        int Bid { get;}

        /// <summary>
        /// Buyout price
        /// </summary>
        int Buyout { get;}

        /// <summary>
        ///Player who owns the resource
        /// </summary>
        PlayerStorage Owner { get;}

        /// <summary>
        ///Turns to be in the auction house
        /// </summary>
        int Time { get;}

        #endregion Properties

    }
}
