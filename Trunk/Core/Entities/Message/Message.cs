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
	public abstract partial class Message : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string parameters;
		private string category;
		private string subCategory;
		private int ownerId;
		private DateTime date = DateTime.Now;
		private string extended;
		private int tickDeadline;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Message's Parameters
        /// </summary>
		public virtual string Parameters {
			set{ this.parameters = value;}
			get{ return this.parameters;}
		}

		/// <summary>
        /// Gets the Message's Category
        /// </summary>
		public virtual string Category {
			set{ this.category = value;}
			get{ return this.category;}
		}

		/// <summary>
        /// Gets the Message's SubCategory
        /// </summary>
		public virtual string SubCategory {
			set{ this.subCategory = value;}
			get{ return this.subCategory;}
		}

		/// <summary>
        /// Gets the Message's OwnerId
        /// </summary>
		public virtual int OwnerId {
			set{ this.ownerId = value;}
			get{ return this.ownerId;}
		}

		/// <summary>
        /// Gets the Message's Date
        /// </summary>
		public virtual DateTime Date {
			set{ this.date = value;}
			get{ return this.date;}
		}

		/// <summary>
        /// Gets the Message's Extended
        /// </summary>
		public virtual string Extended {
			set{ this.extended = value;}
			get{ return this.extended;}
		}

		/// <summary>
        /// Gets the Message's TickDeadline
        /// </summary>
		public virtual int TickDeadline {
			set{ this.tickDeadline = value;}
			get{ return this.tickDeadline;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Message) );
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
			str = Parameters.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Parameters\" : \"{0}\", ", str);
			str = Category.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Category\" : \"{0}\", ", str);
			str = SubCategory.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SubCategory\" : \"{0}\", ", str);
			str = OwnerId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"OwnerId\" : \"{0}\", ", str);
			str = Date.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Date\" : \"{0}\", ", str);
			str = Extended.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Extended\" : \"{0}\", ", str);
			str = TickDeadline.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TickDeadline\" : \"{0}\", ", str);
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
			get { return "Message"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Message other = obj as Message;
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
