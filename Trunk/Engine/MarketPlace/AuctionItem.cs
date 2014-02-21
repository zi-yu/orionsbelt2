using System;
using OrionsBelt.Engine.Exceptions;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.MarketPlace
{
    public class AuctionItem : IAuctionItem
    {
        #region Ctor

        public AuctionItem(IResourceInfo info, int quantity, int price, PlayerStorage owner)
            : this(info, quantity, price, 0, owner, 144)
        {
        }

        public AuctionItem(IResourceInfo info, int quantity, int price, PlayerStorage owner, int time)
            : this(info, quantity, price, 0, owner, time)
        {
        }

        public AuctionItem(IResourceInfo info, int quantity, int price, int buyout, PlayerStorage owner)
            : this(info, quantity, price, buyout, owner, 144)
        {
        }

        public AuctionItem(IResourceInfo info, int quantity, int price, int buyout, PlayerStorage owner, int time)
        {
            identifier = info.Identifier;
            shortIdentifier = info.Name;
            complexIdentifier = Convert.ToInt32(info.AuctionType);
            this.quantity = quantity;
            bid = price;
            this.buyout = buyout;
            this.owner = owner;
            this.time = time;

            if (2 > price)
            {
                throw new AuctionException("The least bid is 2.");
            }

            if(buyout != 0 && buyout < price)
            {
                throw new AuctionException("Buyout can't be lower than the beginning bid.");
            }

            if (time <= 0)
            {
                throw new AuctionException("Time in auction house must be greater than 0.");
            }
        }

        #endregion Ctor

        #region Private Fields

        private readonly string identifier,shortIdentifier;
        private readonly PlayerStorage owner;
        private readonly int quantity, bid, buyout, time, complexIdentifier;

        #endregion Private Fields

        #region IAuctionItem Members

        public string Identifier
        {
            get { return identifier; }
        }

        public string ShortIdentifier
        {
            get { return shortIdentifier; }
        }

        public int Quantity
        {
            get { return quantity; }
        }

        public int IsComplexType
        {
            get { return complexIdentifier; }
        }

        public int Bid
        {
            get {return bid; }
        }

        public int Buyout
        {
            get { return buyout; }
        }

        public PlayerStorage Owner
        {
            get { return owner; }
        }

        public int Time
        {
            get { return time; }
        }

        #endregion
    }
}
