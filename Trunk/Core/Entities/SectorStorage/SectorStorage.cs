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
	public abstract partial class SectorStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private bool isStatic;
		private string type;
		private string subType;
		private int systemX;
		private int systemY;
		private int sectorX;
		private int sectorY;
		private string additionalInformation;
		private bool isInBattle;
		private bool isConstructing;
		private int level;
		private bool isMoving;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the SectorStorage's IsStatic
        /// </summary>
		public virtual bool IsStatic {
			set{ this.isStatic = value;}
			get{ return this.isStatic;}
		}

		/// <summary>
        /// Gets the SectorStorage's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the SectorStorage's SubType
        /// </summary>
		public virtual string SubType {
			set{ this.subType = value;}
			get{ return this.subType;}
		}

		/// <summary>
        /// Gets the SectorStorage's SystemX
        /// </summary>
		public virtual int SystemX {
			set{ this.systemX = value;}
			get{ return this.systemX;}
		}

		/// <summary>
        /// Gets the SectorStorage's SystemY
        /// </summary>
		public virtual int SystemY {
			set{ this.systemY = value;}
			get{ return this.systemY;}
		}

		/// <summary>
        /// Gets the SectorStorage's SectorX
        /// </summary>
		public virtual int SectorX {
			set{ this.sectorX = value;}
			get{ return this.sectorX;}
		}

		/// <summary>
        /// Gets the SectorStorage's SectorY
        /// </summary>
		public virtual int SectorY {
			set{ this.sectorY = value;}
			get{ return this.sectorY;}
		}

		/// <summary>
        /// Gets the SectorStorage's AdditionalInformation
        /// </summary>
		public virtual string AdditionalInformation {
			set{ this.additionalInformation = value;}
			get{ return this.additionalInformation;}
		}

		/// <summary>
        /// Gets the SectorStorage's IsInBattle
        /// </summary>
		public virtual bool IsInBattle {
			set{ this.isInBattle = value;}
			get{ return this.isInBattle;}
		}

		/// <summary>
        /// Gets the SectorStorage's IsConstructing
        /// </summary>
		public virtual bool IsConstructing {
			set{ this.isConstructing = value;}
			get{ return this.isConstructing;}
		}

		/// <summary>
        /// Gets the SectorStorage's Level
        /// </summary>
		public virtual int Level {
			set{ this.level = value;}
			get{ return this.level;}
		}

		/// <summary>
        /// Gets the SectorStorage's IsMoving
        /// </summary>
		public virtual bool IsMoving {
			set{ this.isMoving = value;}
			get{ return this.isMoving;}
		}

		/// <summary>
        /// Gets the SectorStorage's Fleets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Fleet> Fleets {get;set; }

		/// <summary>
        /// Gets the SectorStorage's Planets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlanetStorage> Planets {get;set; }

		/// <summary>
        /// Gets the SectorStorage's SpecialSectores
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<UniverseSpecialSector> SpecialSectores {get;set; }

		/// <summary>
        /// Gets the SectorStorage's Arenas
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ArenaStorage> Arenas {get;set; }

		/// <summary>
        /// Gets the SectorStorage's Markets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Market> Markets {get;set; }

		/// <summary>
        /// Gets the SectorStorage's Owner
        /// </summary>
		public abstract PlayerStorage Owner {get;set; }

		/// <summary>
        /// Gets the SectorStorage's Alliance
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
			XmlSerializer serializer = new XmlSerializer( typeof(SectorStorage) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Type);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = IsStatic.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsStatic\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = SubType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SubType\" : \"{0}\", ", str);
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
			str = AdditionalInformation.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"AdditionalInformation\" : \"{0}\", ", str);
			str = IsInBattle.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsInBattle\" : \"{0}\", ", str);
			str = IsConstructing.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsConstructing\" : \"{0}\", ", str);
			str = Level.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Level\" : \"{0}\", ", str);
			str = IsMoving.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsMoving\" : \"{0}\", ", str);
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
			get { return "SectorStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			SectorStorage other = obj as SectorStorage;
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
			if( Type == null ) {
				return string.Empty;
			}
			return Type.ToString();
		}
		
		#endregion Overrided Members
		
	};
}
