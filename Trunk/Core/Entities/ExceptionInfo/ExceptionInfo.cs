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
	public abstract partial class ExceptionInfo : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private string message;
		private DateTime date = DateTime.Now;
		private string url;
		private string stackTrace;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the ExceptionInfo's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the ExceptionInfo's Message
        /// </summary>
		public virtual string Message {
			set{ this.message = value;}
			get{ return this.message;}
		}

		/// <summary>
        /// Gets the ExceptionInfo's Date
        /// </summary>
		public virtual DateTime Date {
			set{ this.date = value;}
			get{ return this.date;}
		}

		/// <summary>
        /// Gets the ExceptionInfo's Url
        /// </summary>
		public virtual string Url {
			set{ this.url = value;}
			get{ return this.url;}
		}

		/// <summary>
        /// Gets the ExceptionInfo's StackTrace
        /// </summary>
		public virtual string StackTrace {
			set{ this.stackTrace = value;}
			get{ return this.stackTrace;}
		}

		/// <summary>
        /// Gets the ExceptionInfo's Principal
        /// </summary>
		public abstract Principal Principal {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(ExceptionInfo) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Message);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = Message.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Message\" : \"{0}\", ", str);
			str = Date.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Date\" : \"{0}\", ", str);
			str = Url.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Url\" : \"{0}\", ", str);
			str = StackTrace.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"StackTrace\" : \"{0}\", ", str);
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
			get { return "ExceptionInfo"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			ExceptionInfo other = obj as ExceptionInfo;
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
			if( Message == null ) {
				return string.Empty;
			}
			return Message.ToString();
		}
		
		#endregion Overrided Members
		
	};
}
