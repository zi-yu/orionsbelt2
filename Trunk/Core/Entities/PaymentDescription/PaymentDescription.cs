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
	public abstract partial class PaymentDescription : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string type;
		private int amount;
		private int bonus;
		private double cost;
		private string locale;
		private string data;
		private string currency;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PaymentDescription's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the PaymentDescription's Amount
        /// </summary>
		public virtual int Amount {
			set{ this.amount = value;}
			get{ return this.amount;}
		}

		/// <summary>
        /// Gets the PaymentDescription's Bonus
        /// </summary>
		public virtual int Bonus {
			set{ this.bonus = value;}
			get{ return this.bonus;}
		}

		/// <summary>
        /// Gets the PaymentDescription's Cost
        /// </summary>
		public virtual double Cost {
			set{ this.cost = value;}
			get{ return this.cost;}
		}

		/// <summary>
        /// Gets the PaymentDescription's Locale
        /// </summary>
		public virtual string Locale {
			set{ this.locale = value;}
			get{ return this.locale;}
		}

		/// <summary>
        /// Gets the PaymentDescription's Data
        /// </summary>
		public virtual string Data {
			set{ this.data = value;}
			get{ return this.data;}
		}

		/// <summary>
        /// Gets the PaymentDescription's Currency
        /// </summary>
		public virtual string Currency {
			set{ this.currency = value;}
			get{ return this.currency;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PaymentDescription) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("{0}:{1}", TypeName, Id);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = Amount.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Amount\" : \"{0}\", ", str);
			str = Bonus.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Bonus\" : \"{0}\", ", str);
			str = Cost.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Cost\" : \"{0}\", ", str);
			str = Locale.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Locale\" : \"{0}\", ", str);
			str = Data.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Data\" : \"{0}\", ", str);
			str = Currency.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Currency\" : \"{0}\", ", str);
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
			get { return "PaymentDescription"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PaymentDescription other = obj as PaymentDescription;
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
			return string.Format("{0}:{1}", TypeName, Id);
		}
		
		#endregion Overrided Members
		
	};
}
