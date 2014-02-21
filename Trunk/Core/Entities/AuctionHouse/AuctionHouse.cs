	// WARNING: Generated File! Do not modify by hand!
	// *************************************************************

using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using Loki.DataRepresentation;
using Loki;

namespace OrionsBelt.Core {
	//[Serializable()]
	public abstract partial class AuctionHouse : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int price;
		private int currentBid;
		private int buyout;
		private int begin;
		private int timeout;
		private int quantity;
		private string details;
		private int complexNumber;
		private int higherBidOwner;
		private int buyedInTick;
		private int orionsPaid;
		private bool advertise;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the AuctionHouse's Price
        /// </summary>
		public virtual int Price {
			set{ this.price = value;}
			get{ return this.price;}
		}

		/// <summary>
        /// Gets the AuctionHouse's CurrentBid
        /// </summary>
		public virtual int CurrentBid {
			set{ this.currentBid = value;}
			get{ return this.currentBid;}
		}

		/// <summary>
        /// Gets the AuctionHouse's Buyout
        /// </summary>
		public virtual int Buyout {
			set{ this.buyout = value;}
			get{ return this.buyout;}
		}

		/// <summary>
        /// Gets the AuctionHouse's Begin
        /// </summary>
		public virtual int Begin {
			set{ this.begin = value;}
			get{ return this.begin;}
		}

		/// <summary>
        /// Gets the AuctionHouse's Timeout
        /// </summary>
		public virtual int Timeout {
			set{ this.timeout = value;}
			get{ return this.timeout;}
		}

		/// <summary>
        /// Gets the AuctionHouse's Quantity
        /// </summary>
		public virtual int Quantity {
			set{ this.quantity = value;}
			get{ return this.quantity;}
		}

		/// <summary>
        /// Gets the AuctionHouse's Details
        /// </summary>
		public virtual string Details {
			set{ this.details = value;}
			get{ return this.details;}
		}

		/// <summary>
        /// Gets the AuctionHouse's ComplexNumber
        /// </summary>
		public virtual int ComplexNumber {
			set{ this.complexNumber = value;}
			get{ return this.complexNumber;}
		}

		/// <summary>
        /// Gets the AuctionHouse's HigherBidOwner
        /// </summary>
		public virtual int HigherBidOwner {
			set{ this.higherBidOwner = value;}
			get{ return this.higherBidOwner;}
		}

		/// <summary>
        /// Gets the AuctionHouse's BuyedInTick
        /// </summary>
		public virtual int BuyedInTick {
			set{ this.buyedInTick = value;}
			get{ return this.buyedInTick;}
		}

		/// <summary>
        /// Gets the AuctionHouse's OrionsPaid
        /// </summary>
		public virtual int OrionsPaid {
			set{ this.orionsPaid = value;}
			get{ return this.orionsPaid;}
		}

		/// <summary>
        /// Gets the AuctionHouse's Advertise
        /// </summary>
		public virtual bool Advertise {
			set{ this.advertise = value;}
			get{ return this.advertise;}
		}

		/// <summary>
        /// Gets the AuctionHouse's Bids
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<BidHistorical> Bids {get;set; }

		/// <summary>
        /// Gets the AuctionHouse's Owner
        /// </summary>
		public abstract PlayerStorage Owner {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(AuctionHouse) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Details);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = Price.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Price\" : \"{0}\", ", str);
			str = CurrentBid.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CurrentBid\" : \"{0}\", ", str);
			str = Buyout.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Buyout\" : \"{0}\", ", str);
			str = Begin.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Begin\" : \"{0}\", ", str);
			str = Timeout.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Timeout\" : \"{0}\", ", str);
			str = Quantity.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Quantity\" : \"{0}\", ", str);
			str = Details.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Details\" : \"{0}\", ", str);
			str = ComplexNumber.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ComplexNumber\" : \"{0}\", ", str);
			str = HigherBidOwner.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HigherBidOwner\" : \"{0}\", ", str);
			str = BuyedInTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BuyedInTick\" : \"{0}\", ", str);
			str = OrionsPaid.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"OrionsPaid\" : \"{0}\", ", str);
			str = Advertise.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Advertise\" : \"{0}\", ", str);
			str = CreatedDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CreatedDate\" : \"{0}\", ", str);
			str = UpdatedDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UpdatedDate\" : \"{0}\", ", str);
			str = LastActionUserId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastActionUserId\" : \"{0}\", ", str);
			writer.Write("\"TypeName\" : \"{0}\" ", TypeName);
			writer.Write("}");
			return writer.ToString();
		}

		public override string TypeName { 
			get { return "AuctionHouse"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			AuctionHouse other = obj as AuctionHouse;
			if( other == null ) {
				// we don't know how to compare diferent entities
				return 0;
			}
			
			return other.Id.CompareTo(this.Id);
		}

		#endregion IComparable Implementation

		#region Overrided Members
		
		public override string ToString()
		{
			if( Details == null ) {
				return string.Empty;
			}
			return Details.ToString();
		}
		
		#endregion Overrided Members
		
	};
}
