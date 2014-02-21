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
	public abstract partial class DuplicateDetection : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int cheater;
		private int duplicate;
		private string findType;
		private string extraInfo;
		private bool verified;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the DuplicateDetection's Cheater
        /// </summary>
		public virtual int Cheater {
			set{ this.cheater = value;}
			get{ return this.cheater;}
		}

		/// <summary>
        /// Gets the DuplicateDetection's Duplicate
        /// </summary>
		public virtual int Duplicate {
			set{ this.duplicate = value;}
			get{ return this.duplicate;}
		}

		/// <summary>
        /// Gets the DuplicateDetection's FindType
        /// </summary>
		public virtual string FindType {
			set{ this.findType = value;}
			get{ return this.findType;}
		}

		/// <summary>
        /// Gets the DuplicateDetection's ExtraInfo
        /// </summary>
		public virtual string ExtraInfo {
			set{ this.extraInfo = value;}
			get{ return this.extraInfo;}
		}

		/// <summary>
        /// Gets the DuplicateDetection's Verified
        /// </summary>
		public virtual bool Verified {
			set{ this.verified = value;}
			get{ return this.verified;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(DuplicateDetection) );
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
			str = Cheater.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Cheater\" : \"{0}\", ", str);
			str = Duplicate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Duplicate\" : \"{0}\", ", str);
			str = FindType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"FindType\" : \"{0}\", ", str);
			str = ExtraInfo.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ExtraInfo\" : \"{0}\", ", str);
			str = Verified.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Verified\" : \"{0}\", ", str);
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
			get { return "DuplicateDetection"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			DuplicateDetection other = obj as DuplicateDetection;
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
