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
	public abstract partial class Testimonial : Institutional.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string locale;
		private string content;
		private string author;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Testimonial's Locale
        /// </summary>
		public virtual string Locale {
			set{ this.locale = value;}
			get{ return this.locale;}
		}

		/// <summary>
        /// Gets the Testimonial's Content
        /// </summary>
		public virtual string Content {
			set{ this.content = value;}
			get{ return this.content;}
		}

		/// <summary>
        /// Gets the Testimonial's Author
        /// </summary>
		public virtual string Author {
			set{ this.author = value;}
			get{ return this.author;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Testimonial) );
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
			str = Locale.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Locale\" : \"{0}\", ", str);
			str = Content.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Content\" : \"{0}\", ", str);
			str = Author.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Author\" : \"{0}\", ", str);
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
			get { return "Testimonial"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Testimonial other = obj as Testimonial;
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
