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
	public abstract partial class FogOfWarStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int systemX;
		private int systemY;
		private string sectors;
		private bool hasDiscoveredAll;
		private bool hasDiscoveredHalf;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the FogOfWarStorage's SystemX
        /// </summary>
		public virtual int SystemX {
			set{ this.systemX = value;}
			get{ return this.systemX;}
		}

		/// <summary>
        /// Gets the FogOfWarStorage's SystemY
        /// </summary>
		public virtual int SystemY {
			set{ this.systemY = value;}
			get{ return this.systemY;}
		}

		/// <summary>
        /// Gets the FogOfWarStorage's Sectors
        /// </summary>
		public virtual string Sectors {
			set{ this.sectors = value;}
			get{ return this.sectors;}
		}

		/// <summary>
        /// Gets the FogOfWarStorage's HasDiscoveredAll
        /// </summary>
		public virtual bool HasDiscoveredAll {
			set{ this.hasDiscoveredAll = value;}
			get{ return this.hasDiscoveredAll;}
		}

		/// <summary>
        /// Gets the FogOfWarStorage's HasDiscoveredHalf
        /// </summary>
		public virtual bool HasDiscoveredHalf {
			set{ this.hasDiscoveredHalf = value;}
			get{ return this.hasDiscoveredHalf;}
		}

		/// <summary>
        /// Gets the FogOfWarStorage's Owner
        /// </summary>
		public abstract PlayerStorage Owner {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(FogOfWarStorage) );
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
			str = Sectors.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Sectors\" : \"{0}\", ", str);
			str = HasDiscoveredAll.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HasDiscoveredAll\" : \"{0}\", ", str);
			str = HasDiscoveredHalf.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HasDiscoveredHalf\" : \"{0}\", ", str);
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
			get { return "FogOfWarStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			FogOfWarStorage other = obj as FogOfWarStorage;
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
