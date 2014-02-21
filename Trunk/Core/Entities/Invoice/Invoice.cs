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
	public abstract partial class Invoice : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string identifier;
		private string name;
		private string nif;
		private double money;
		private string country;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Invoice's Identifier
        /// </summary>
		public virtual string Identifier {
			set{ this.identifier = value;}
			get{ return this.identifier;}
		}

		/// <summary>
        /// Gets the Invoice's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the Invoice's Nif
        /// </summary>
		public virtual string Nif {
			set{ this.nif = value;}
			get{ return this.nif;}
		}

		/// <summary>
        /// Gets the Invoice's Money
        /// </summary>
		public virtual double Money {
			set{ this.money = value;}
			get{ return this.money;}
		}

		/// <summary>
        /// Gets the Invoice's Country
        /// </summary>
		public virtual string Country {
			set{ this.country = value;}
			get{ return this.country;}
		}

		/// <summary>
        /// Gets the Invoice's Transaction
        /// </summary>
		public abstract Transaction Transaction {get;set; }

		/// <summary>
        /// Gets the Invoice's Payment
        /// </summary>
		public abstract Payment Payment {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Invoice) );
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
			str = Identifier.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Identifier\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = Nif.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Nif\" : \"{0}\", ", str);
			str = Money.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Money\" : \"{0}\", ", str);
			str = Country.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Country\" : \"{0}\", ", str);
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
			get { return "Invoice"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Invoice other = obj as Invoice;
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
