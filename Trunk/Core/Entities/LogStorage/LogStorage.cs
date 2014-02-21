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
	public abstract partial class LogStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private DateTime date = DateTime.Now;
		private string username1;
		private string level;
		private string url;
		private string content;
		private string exceptionInformation;
		private string ip;
		private string type;
		private string username2;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the LogStorage's Date
        /// </summary>
		public virtual DateTime Date {
			set{ this.date = value;}
			get{ return this.date;}
		}

		/// <summary>
        /// Gets the LogStorage's Username1
        /// </summary>
		public virtual string Username1 {
			set{ this.username1 = value;}
			get{ return this.username1;}
		}

		/// <summary>
        /// Gets the LogStorage's Level
        /// </summary>
		public virtual string Level {
			set{ this.level = value;}
			get{ return this.level;}
		}

		/// <summary>
        /// Gets the LogStorage's Url
        /// </summary>
		public virtual string Url {
			set{ this.url = value;}
			get{ return this.url;}
		}

		/// <summary>
        /// Gets the LogStorage's Content
        /// </summary>
		public virtual string Content {
			set{ this.content = value;}
			get{ return this.content;}
		}

		/// <summary>
        /// Gets the LogStorage's ExceptionInformation
        /// </summary>
		public virtual string ExceptionInformation {
			set{ this.exceptionInformation = value;}
			get{ return this.exceptionInformation;}
		}

		/// <summary>
        /// Gets the LogStorage's Ip
        /// </summary>
		public virtual string Ip {
			set{ this.ip = value;}
			get{ return this.ip;}
		}

		/// <summary>
        /// Gets the LogStorage's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the LogStorage's Username2
        /// </summary>
		public virtual string Username2 {
			set{ this.username2 = value;}
			get{ return this.username2;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(LogStorage) );
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
			str = Date.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Date\" : \"{0}\", ", str);
			str = Username1.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Username1\" : \"{0}\", ", str);
			str = Level.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Level\" : \"{0}\", ", str);
			str = Url.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Url\" : \"{0}\", ", str);
			str = Content.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Content\" : \"{0}\", ", str);
			str = ExceptionInformation.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ExceptionInformation\" : \"{0}\", ", str);
			str = Ip.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Ip\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = Username2.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Username2\" : \"{0}\", ", str);
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
			get { return "LogStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			LogStorage other = obj as LogStorage;
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
