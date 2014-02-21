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
	public abstract partial class PlanetStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private double productionFactor;
		private string modifiers;
		private string richness;
		private string info;
		private string terrain;
		private bool isPrivate;
		private int systemX;
		private int systemY;
		private int sectorX;
		private int sectorY;
		private int score;
		private int level;
		private int lastPillageTick;
		private int lastConquerTick;
		private int facilityLevel;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PlanetStorage's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the PlanetStorage's ProductionFactor
        /// </summary>
		public virtual double ProductionFactor {
			set{ this.productionFactor = value;}
			get{ return this.productionFactor;}
		}

		/// <summary>
        /// Gets the PlanetStorage's Modifiers
        /// </summary>
		public virtual string Modifiers {
			set{ this.modifiers = value;}
			get{ return this.modifiers;}
		}

		/// <summary>
        /// Gets the PlanetStorage's Richness
        /// </summary>
		public virtual string Richness {
			set{ this.richness = value;}
			get{ return this.richness;}
		}

		/// <summary>
        /// Gets the PlanetStorage's Info
        /// </summary>
		public virtual string Info {
			set{ this.info = value;}
			get{ return this.info;}
		}

		/// <summary>
        /// Gets the PlanetStorage's Terrain
        /// </summary>
		public virtual string Terrain {
			set{ this.terrain = value;}
			get{ return this.terrain;}
		}

		/// <summary>
        /// Gets the PlanetStorage's IsPrivate
        /// </summary>
		public virtual bool IsPrivate {
			set{ this.isPrivate = value;}
			get{ return this.isPrivate;}
		}

		/// <summary>
        /// Gets the PlanetStorage's SystemX
        /// </summary>
		public virtual int SystemX {
			set{ this.systemX = value;}
			get{ return this.systemX;}
		}

		/// <summary>
        /// Gets the PlanetStorage's SystemY
        /// </summary>
		public virtual int SystemY {
			set{ this.systemY = value;}
			get{ return this.systemY;}
		}

		/// <summary>
        /// Gets the PlanetStorage's SectorX
        /// </summary>
		public virtual int SectorX {
			set{ this.sectorX = value;}
			get{ return this.sectorX;}
		}

		/// <summary>
        /// Gets the PlanetStorage's SectorY
        /// </summary>
		public virtual int SectorY {
			set{ this.sectorY = value;}
			get{ return this.sectorY;}
		}

		/// <summary>
        /// Gets the PlanetStorage's Score
        /// </summary>
		public virtual int Score {
			set{ this.score = value;}
			get{ return this.score;}
		}

		/// <summary>
        /// Gets the PlanetStorage's Level
        /// </summary>
		public virtual int Level {
			set{ this.level = value;}
			get{ return this.level;}
		}

		/// <summary>
        /// Gets the PlanetStorage's LastPillageTick
        /// </summary>
		public virtual int LastPillageTick {
			set{ this.lastPillageTick = value;}
			get{ return this.lastPillageTick;}
		}

		/// <summary>
        /// Gets the PlanetStorage's LastConquerTick
        /// </summary>
		public virtual int LastConquerTick {
			set{ this.lastConquerTick = value;}
			get{ return this.lastConquerTick;}
		}

		/// <summary>
        /// Gets the PlanetStorage's FacilityLevel
        /// </summary>
		public virtual int FacilityLevel {
			set{ this.facilityLevel = value;}
			get{ return this.facilityLevel;}
		}

		/// <summary>
        /// Gets the PlanetStorage's Fleets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Fleet> Fleets {get;set; }

		/// <summary>
        /// Gets the PlanetStorage's Resources
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlanetResourceStorage> Resources {get;set; }

		/// <summary>
        /// Gets the PlanetStorage's Player
        /// </summary>
		public abstract PlayerStorage Player {get;set; }

		/// <summary>
        /// Gets the PlanetStorage's Sector
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
			XmlSerializer serializer = new XmlSerializer( typeof(PlanetStorage) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Name);
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
			str = ProductionFactor.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ProductionFactor\" : \"{0}\", ", str);
			str = Modifiers.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Modifiers\" : \"{0}\", ", str);
			str = Richness.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Richness\" : \"{0}\", ", str);
			str = Info.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Info\" : \"{0}\", ", str);
			str = Terrain.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Terrain\" : \"{0}\", ", str);
			str = IsPrivate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsPrivate\" : \"{0}\", ", str);
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
			str = Score.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Score\" : \"{0}\", ", str);
			str = Level.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Level\" : \"{0}\", ", str);
			str = LastPillageTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastPillageTick\" : \"{0}\", ", str);
			str = LastConquerTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastConquerTick\" : \"{0}\", ", str);
			str = FacilityLevel.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"FacilityLevel\" : \"{0}\", ", str);
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
			get { return "PlanetStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PlanetStorage other = obj as PlanetStorage;
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
			if( Name == null ) {
				return string.Empty;
			}
			return Name.ToString();
		}
		
		#endregion Overrided Members
		
	};
}
