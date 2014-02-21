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
	public abstract partial class Necessity : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string type;
		private string description;
		private string coordinate;
		private string status;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Necessity's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the Necessity's Description
        /// </summary>
		public virtual string Description {
			set{ this.description = value;}
			get{ return this.description;}
		}

		/// <summary>
        /// Gets the Necessity's Coordinate
        /// </summary>
		public virtual string Coordinate {
			set{ this.coordinate = value;}
			get{ return this.coordinate;}
		}

		/// <summary>
        /// Gets the Necessity's Status
        /// </summary>
		public virtual string Status {
			set{ this.status = value;}
			get{ return this.status;}
		}

		/// <summary>
        /// Gets the Necessity's Tasks
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Task> Tasks {get;set; }

		/// <summary>
        /// Gets the Necessity's Creator
        /// </summary>
		public abstract PlayerStorage Creator {get;set; }

		/// <summary>
        /// Gets the Necessity's Alliance
        /// </summary>
		public abstract AllianceStorage Alliance {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Necessity) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Description);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = Description.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Description\" : \"{0}\", ", str);
			str = Coordinate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Coordinate\" : \"{0}\", ", str);
			str = Status.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Status\" : \"{0}\", ", str);
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
			get { return "Necessity"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Necessity other = obj as Necessity;
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
			if( Description == null ) {
				return string.Empty;
			}
			return Description.ToString();
		}
		
		#endregion Overrided Members
		
	};
}
