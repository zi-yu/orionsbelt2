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
	public abstract partial class SpecialEvent : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int cost;
		private string token;
		private string resorces;
		private DateTime beginDate = DateTime.Now;
		private DateTime endDate = DateTime.Now;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the SpecialEvent's Cost
        /// </summary>
		public virtual int Cost {
			set{ this.cost = value;}
			get{ return this.cost;}
		}

		/// <summary>
        /// Gets the SpecialEvent's Token
        /// </summary>
		public virtual string Token {
			set{ this.token = value;}
			get{ return this.token;}
		}

		/// <summary>
        /// Gets the SpecialEvent's Resorces
        /// </summary>
		public virtual string Resorces {
			set{ this.resorces = value;}
			get{ return this.resorces;}
		}

		/// <summary>
        /// Gets the SpecialEvent's BeginDate
        /// </summary>
		public virtual DateTime BeginDate {
			set{ this.beginDate = value;}
			get{ return this.beginDate;}
		}

		/// <summary>
        /// Gets the SpecialEvent's EndDate
        /// </summary>
		public virtual DateTime EndDate {
			set{ this.endDate = value;}
			get{ return this.endDate;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(SpecialEvent) );
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
			str = Cost.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Cost\" : \"{0}\", ", str);
			str = Token.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Token\" : \"{0}\", ", str);
			str = Resorces.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Resorces\" : \"{0}\", ", str);
			str = BeginDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BeginDate\" : \"{0}\", ", str);
			str = EndDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EndDate\" : \"{0}\", ", str);
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
			get { return "SpecialEvent"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			SpecialEvent other = obj as SpecialEvent;
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
