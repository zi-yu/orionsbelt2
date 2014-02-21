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
	public abstract partial class PrivateBoard : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int receiver;
		private string type;
		private string message;
		private bool wasRead;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PrivateBoard's Receiver
        /// </summary>
		public virtual int Receiver {
			set{ this.receiver = value;}
			get{ return this.receiver;}
		}

		/// <summary>
        /// Gets the PrivateBoard's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the PrivateBoard's Message
        /// </summary>
		public virtual string Message {
			set{ this.message = value;}
			get{ return this.message;}
		}

		/// <summary>
        /// Gets the PrivateBoard's WasRead
        /// </summary>
		public virtual bool WasRead {
			set{ this.wasRead = value;}
			get{ return this.wasRead;}
		}

		/// <summary>
        /// Gets the PrivateBoard's Sender
        /// </summary>
		public abstract PlayerStorage Sender {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PrivateBoard) );
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
			str = Receiver.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Receiver\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = Message.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Message\" : \"{0}\", ", str);
			str = WasRead.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"WasRead\" : \"{0}\", ", str);
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
			get { return "PrivateBoard"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PrivateBoard other = obj as PrivateBoard;
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
