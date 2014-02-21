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
	public abstract partial class Task : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string status;
		private string priority;
		private string title;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Task's Status
        /// </summary>
		public virtual string Status {
			set{ this.status = value;}
			get{ return this.status;}
		}

		/// <summary>
        /// Gets the Task's Priority
        /// </summary>
		public virtual string Priority {
			set{ this.priority = value;}
			get{ return this.priority;}
		}

		/// <summary>
        /// Gets the Task's Title
        /// </summary>
		public virtual string Title {
			set{ this.title = value;}
			get{ return this.title;}
		}

		/// <summary>
        /// Gets the Task's Assets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Asset> Assets {get;set; }

		/// <summary>
        /// Gets the Task's Necessity
        /// </summary>
		public abstract Necessity Necessity {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Task) );
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
			str = Status.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Status\" : \"{0}\", ", str);
			str = Priority.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Priority\" : \"{0}\", ", str);
			str = Title.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Title\" : \"{0}\", ", str);
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
			get { return "Task"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Task other = obj as Task;
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
