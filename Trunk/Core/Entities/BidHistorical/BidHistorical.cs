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
	public abstract partial class BidHistorical : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int value;
		private DateTime date = DateTime.Now;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the BidHistorical's Value
        /// </summary>
		public virtual int Value {
			set{ this.value = value;}
			get{ return this.value;}
		}

		/// <summary>
        /// Gets the BidHistorical's Date
        /// </summary>
		public virtual DateTime Date {
			set{ this.date = value;}
			get{ return this.date;}
		}

		/// <summary>
        /// Gets the BidHistorical's Resource
        /// </summary>
		public abstract AuctionHouse Resource {get;set; }

		/// <summary>
        /// Gets the BidHistorical's MadeBy
        /// </summary>
		public abstract PlayerStorage MadeBy {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(BidHistorical) );
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
			str = Value.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Value\" : \"{0}\", ", str);
			str = Date.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Date\" : \"{0}\", ", str);
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
			get { return "BidHistorical"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			BidHistorical other = obj as BidHistorical;
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
