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
	public abstract partial class Offering : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int initialValue;
		private int currentValue;
		private string product;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Offering's InitialValue
        /// </summary>
		public virtual int InitialValue {
			set{ this.initialValue = value;}
			get{ return this.initialValue;}
		}

		/// <summary>
        /// Gets the Offering's CurrentValue
        /// </summary>
		public virtual int CurrentValue {
			set{ this.currentValue = value;}
			get{ return this.currentValue;}
		}

		/// <summary>
        /// Gets the Offering's Product
        /// </summary>
		public virtual string Product {
			set{ this.product = value;}
			get{ return this.product;}
		}

		/// <summary>
        /// Gets the Offering's Donor
        /// </summary>
		public abstract PlayerStorage Donor {get;set; }

		/// <summary>
        /// Gets the Offering's Receiver
        /// </summary>
		public abstract PlayerStorage Receiver {get;set; }

		/// <summary>
        /// Gets the Offering's Alliance
        /// </summary>
		public abstract AllianceStorage Alliance {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Offering) );
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
			str = InitialValue.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"InitialValue\" : \"{0}\", ", str);
			str = CurrentValue.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CurrentValue\" : \"{0}\", ", str);
			str = Product.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Product\" : \"{0}\", ", str);
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
			get { return "Offering"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Offering other = obj as Offering;
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
