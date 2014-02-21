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
	public abstract partial class Fleet : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private string units;
		private bool tournamentFleet;
		private bool isMovable;
		private string ultimateUnit;
		private bool isInBattle;
		private bool isPlanetDefenseFleet;
		private int systemX;
		private int systemY;
		private int sectorX;
		private int sectorY;
		private string cargo;
		private bool isBot;
		private string wayPoints;
		private int immunityStartTick;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Fleet's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the Fleet's Units
        /// </summary>
		public virtual string Units {
			set{ this.units = value;}
			get{ return this.units;}
		}

		/// <summary>
        /// Gets the Fleet's TournamentFleet
        /// </summary>
		public virtual bool TournamentFleet {
			set{ this.tournamentFleet = value;}
			get{ return this.tournamentFleet;}
		}

		/// <summary>
        /// Gets the Fleet's IsMovable
        /// </summary>
		public virtual bool IsMovable {
			set{ this.isMovable = value;}
			get{ return this.isMovable;}
		}

		/// <summary>
        /// Gets the Fleet's UltimateUnit
        /// </summary>
		public virtual string UltimateUnit {
			set{ this.ultimateUnit = value;}
			get{ return this.ultimateUnit;}
		}

		/// <summary>
        /// Gets the Fleet's IsInBattle
        /// </summary>
		public virtual bool IsInBattle {
			set{ this.isInBattle = value;}
			get{ return this.isInBattle;}
		}

		/// <summary>
        /// Gets the Fleet's IsPlanetDefenseFleet
        /// </summary>
		public virtual bool IsPlanetDefenseFleet {
			set{ this.isPlanetDefenseFleet = value;}
			get{ return this.isPlanetDefenseFleet;}
		}

		/// <summary>
        /// Gets the Fleet's SystemX
        /// </summary>
		public virtual int SystemX {
			set{ this.systemX = value;}
			get{ return this.systemX;}
		}

		/// <summary>
        /// Gets the Fleet's SystemY
        /// </summary>
		public virtual int SystemY {
			set{ this.systemY = value;}
			get{ return this.systemY;}
		}

		/// <summary>
        /// Gets the Fleet's SectorX
        /// </summary>
		public virtual int SectorX {
			set{ this.sectorX = value;}
			get{ return this.sectorX;}
		}

		/// <summary>
        /// Gets the Fleet's SectorY
        /// </summary>
		public virtual int SectorY {
			set{ this.sectorY = value;}
			get{ return this.sectorY;}
		}

		/// <summary>
        /// Gets the Fleet's Cargo
        /// </summary>
		public virtual string Cargo {
			set{ this.cargo = value;}
			get{ return this.cargo;}
		}

		/// <summary>
        /// Gets the Fleet's IsBot
        /// </summary>
		public virtual bool IsBot {
			set{ this.isBot = value;}
			get{ return this.isBot;}
		}

		/// <summary>
        /// Gets the Fleet's WayPoints
        /// </summary>
		public virtual string WayPoints {
			set{ this.wayPoints = value;}
			get{ return this.wayPoints;}
		}

		/// <summary>
        /// Gets the Fleet's ImmunityStartTick
        /// </summary>
		public virtual int ImmunityStartTick {
			set{ this.immunityStartTick = value;}
			get{ return this.immunityStartTick;}
		}

		/// <summary>
        /// Gets the Fleet's Arena
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ArenaStorage> Arena {get;set; }

		/// <summary>
        /// Gets the Fleet's CurrentPlanet
        /// </summary>
		public abstract PlanetStorage CurrentPlanet {get;set; }

		/// <summary>
        /// Gets the Fleet's PrincipalOwner
        /// </summary>
		public abstract Principal PrincipalOwner {get;set; }

		/// <summary>
        /// Gets the Fleet's Sector
        /// </summary>
		public abstract SectorStorage Sector {get;set; }

		/// <summary>
        /// Gets the Fleet's PlayerOwner
        /// </summary>
		public abstract PlayerStorage PlayerOwner {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Fleet) );
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
			str = Units.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Units\" : \"{0}\", ", str);
			str = TournamentFleet.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TournamentFleet\" : \"{0}\", ", str);
			str = IsMovable.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsMovable\" : \"{0}\", ", str);
			str = UltimateUnit.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UltimateUnit\" : \"{0}\", ", str);
			str = IsInBattle.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsInBattle\" : \"{0}\", ", str);
			str = IsPlanetDefenseFleet.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsPlanetDefenseFleet\" : \"{0}\", ", str);
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
			str = Cargo.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Cargo\" : \"{0}\", ", str);
			str = IsBot.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsBot\" : \"{0}\", ", str);
			str = WayPoints.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"WayPoints\" : \"{0}\", ", str);
			str = ImmunityStartTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ImmunityStartTick\" : \"{0}\", ", str);
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
			get { return "Fleet"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Fleet other = obj as Fleet;
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
