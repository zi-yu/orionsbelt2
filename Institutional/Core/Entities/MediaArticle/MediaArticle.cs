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
	public abstract partial class MediaArticle : Institutional.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string url;
		private string name;
		private string locale;
		private string exceprt;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the MediaArticle's Url
        /// </summary>
		public virtual string Url {
			set{ this.url = value;}
			get{ return this.url;}
		}

		/// <summary>
        /// Gets the MediaArticle's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the MediaArticle's Locale
        /// </summary>
		public virtual string Locale {
			set{ this.locale = value;}
			get{ return this.locale;}
		}

		/// <summary>
        /// Gets the MediaArticle's Exceprt
        /// </summary>
		public virtual string Exceprt {
			set{ this.exceprt = value;}
			get{ return this.exceprt;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(MediaArticle) );
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
			str = Url.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Url\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = Locale.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Locale\" : \"{0}\", ", str);
			str = Exceprt.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Exceprt\" : \"{0}\", ", str);
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
			get { return "MediaArticle"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			MediaArticle other = obj as MediaArticle;
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
