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
	public abstract partial class AllianceStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int score;
		private double karma;
		private int totalMembers;
		private string name;
		private string tag;
		private string description;
		private string language;
		private int orions;
		private bool openToNewMembers;
		private int totalRelics;
		private int totalRelicsIncome;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the AllianceStorage's Score
        /// </summary>
		public virtual int Score {
			set{ this.score = value;}
			get{ return this.score;}
		}

		/// <summary>
        /// Gets the AllianceStorage's Karma
        /// </summary>
		public virtual double Karma {
			set{ this.karma = value;}
			get{ return this.karma;}
		}

		/// <summary>
        /// Gets the AllianceStorage's TotalMembers
        /// </summary>
		public virtual int TotalMembers {
			set{ this.totalMembers = value;}
			get{ return this.totalMembers;}
		}

		/// <summary>
        /// Gets the AllianceStorage's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the AllianceStorage's Tag
        /// </summary>
		public virtual string Tag {
			set{ this.tag = value;}
			get{ return this.tag;}
		}

		/// <summary>
        /// Gets the AllianceStorage's Description
        /// </summary>
		public virtual string Description {
			set{ this.description = value;}
			get{ return this.description;}
		}

		/// <summary>
        /// Gets the AllianceStorage's Language
        /// </summary>
		public virtual string Language {
			set{ this.language = value;}
			get{ return this.language;}
		}

		/// <summary>
        /// Gets the AllianceStorage's Orions
        /// </summary>
		public virtual int Orions {
			set{ this.orions = value;}
			get{ return this.orions;}
		}

		/// <summary>
        /// Gets the AllianceStorage's OpenToNewMembers
        /// </summary>
		public virtual bool OpenToNewMembers {
			set{ this.openToNewMembers = value;}
			get{ return this.openToNewMembers;}
		}

		/// <summary>
        /// Gets the AllianceStorage's TotalRelics
        /// </summary>
		public virtual int TotalRelics {
			set{ this.totalRelics = value;}
			get{ return this.totalRelics;}
		}

		/// <summary>
        /// Gets the AllianceStorage's TotalRelicsIncome
        /// </summary>
		public virtual int TotalRelicsIncome {
			set{ this.totalRelicsIncome = value;}
			get{ return this.totalRelicsIncome;}
		}

		/// <summary>
        /// Gets the AllianceStorage's Players
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlayerStorage> Players {get;set; }

		/// <summary>
        /// Gets the AllianceStorage's DiplomacyA
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<AllianceDiplomacy> DiplomacyA {get;set; }

		/// <summary>
        /// Gets the AllianceStorage's DiplomacyB
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<AllianceDiplomacy> DiplomacyB {get;set; }

		/// <summary>
        /// Gets the AllianceStorage's Sector
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<SectorStorage> Sector {get;set; }

		/// <summary>
        /// Gets the AllianceStorage's Assets
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Asset> Assets {get;set; }

		/// <summary>
        /// Gets the AllianceStorage's Necessities
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Necessity> Necessities {get;set; }

		/// <summary>
        /// Gets the AllianceStorage's Offerings
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Offering> Offerings {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(AllianceStorage) );
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
			str = Score.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Score\" : \"{0}\", ", str);
			str = Karma.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Karma\" : \"{0}\", ", str);
			str = TotalMembers.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TotalMembers\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = Tag.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Tag\" : \"{0}\", ", str);
			str = Description.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Description\" : \"{0}\", ", str);
			str = Language.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Language\" : \"{0}\", ", str);
			str = Orions.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Orions\" : \"{0}\", ", str);
			str = OpenToNewMembers.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"OpenToNewMembers\" : \"{0}\", ", str);
			str = TotalRelics.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TotalRelics\" : \"{0}\", ", str);
			str = TotalRelicsIncome.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TotalRelicsIncome\" : \"{0}\", ", str);
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
			get { return "AllianceStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			AllianceStorage other = obj as AllianceStorage;
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
