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
	public abstract partial class UniverseSpecialSector : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int systemX;
		private int systemY;
		private int sectorX;
		private int sectorY;
		private string type;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the UniverseSpecialSector's SystemX
        /// </summary>
		public virtual int SystemX {
			set{ this.systemX = value;}
			get{ return this.systemX;}
		}

		/// <summary>
        /// Gets the UniverseSpecialSector's SystemY
        /// </summary>
		public virtual int SystemY {
			set{ this.systemY = value;}
			get{ return this.systemY;}
		}

		/// <summary>
        /// Gets the UniverseSpecialSector's SectorX
        /// </summary>
		public virtual int SectorX {
			set{ this.sectorX = value;}
			get{ return this.sectorX;}
		}

		/// <summary>
        /// Gets the UniverseSpecialSector's SectorY
        /// </summary>
		public virtual int SectorY {
			set{ this.sectorY = value;}
			get{ return this.sectorY;}
		}

		/// <summary>
        /// Gets the UniverseSpecialSector's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the UniverseSpecialSector's Owner
        /// </summary>
		public abstract PlayerStorage Owner {get;set; }

		/// <summary>
        /// Gets the UniverseSpecialSector's Sector
        /// </summary>
		public abstract SectorStorage Sector {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(UniverseSpecialSector) );
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
			str = SystemX.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SystemX\" : \"{0}\", ", str);
			str = SystemY.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SystemY\" : \"{0}\", ", str);
			str = SectorX.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SectorX\" : \"{0}\", ", str);
			str = SectorY.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SectorY\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
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
			get { return "UniverseSpecialSector"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			UniverseSpecialSector other = obj as UniverseSpecialSector;
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
