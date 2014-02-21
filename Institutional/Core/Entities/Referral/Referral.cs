	// WARNING: Generated File! Do not modify by hand!
	// *************************************************************

using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using Loki.DataRepresentation;
using Loki;

namespace Institutional.Core {
	//[Serializable()]
	public abstract partial class Referral : Institutional.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int code;
		private string name;
		private string sourceUrl;
		private string filters;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Referral's Code
        /// </summary>
		public virtual int Code {
			set{ this.code = value;}
			get{ return this.code;}
		}

		/// <summary>
        /// Gets the Referral's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the Referral's SourceUrl
        /// </summary>
		public virtual string SourceUrl {
			set{ this.sourceUrl = value;}
			get{ return this.sourceUrl;}
		}

		/// <summary>
        /// Gets the Referral's Filters
        /// </summary>
		public virtual string Filters {
			set{ this.filters = value;}
			get{ return this.filters;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Referral) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Name);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = Code.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Code\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = SourceUrl.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SourceUrl\" : \"{0}\", ", str);
			str = Filters.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Filters\" : \"{0}\", ", str);
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
			get { return "Referral"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Referral other = obj as Referral;
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
			if( Name == null ) {
				return string.Empty;
			}
			return Name.ToString();
		}
		
		#endregion Overrided Members
		
	};
}
