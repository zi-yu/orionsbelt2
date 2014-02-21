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
	public abstract partial class ArenaStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private int isInBattle;
		private int conquestTick;
		private string battleType;
		private string coordinate;
		private int payment;
		private int level;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the ArenaStorage's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the ArenaStorage's IsInBattle
        /// </summary>
		public virtual int IsInBattle {
			set{ this.isInBattle = value;}
			get{ return this.isInBattle;}
		}

		/// <summary>
        /// Gets the ArenaStorage's ConquestTick
        /// </summary>
		public virtual int ConquestTick {
			set{ this.conquestTick = value;}
			get{ return this.conquestTick;}
		}

		/// <summary>
        /// Gets the ArenaStorage's BattleType
        /// </summary>
		public virtual string BattleType {
			set{ this.battleType = value;}
			get{ return this.battleType;}
		}

		/// <summary>
        /// Gets the ArenaStorage's Coordinate
        /// </summary>
		public virtual string Coordinate {
			set{ this.coordinate = value;}
			get{ return this.coordinate;}
		}

		/// <summary>
        /// Gets the ArenaStorage's Payment
        /// </summary>
		public virtual int Payment {
			set{ this.payment = value;}
			get{ return this.payment;}
		}

		/// <summary>
        /// Gets the ArenaStorage's Level
        /// </summary>
		public virtual int Level {
			set{ this.level = value;}
			get{ return this.level;}
		}

		/// <summary>
        /// Gets the ArenaStorage's Historical
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ArenaHistorical> Historical {get;set; }

		/// <summary>
        /// Gets the ArenaStorage's Fleet
        /// </summary>
		public abstract Fleet Fleet {get;set; }

		/// <summary>
        /// Gets the ArenaStorage's Owner
        /// </summary>
		public abstract PlayerStorage Owner {get;set; }

		/// <summary>
        /// Gets the ArenaStorage's Sector
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
			XmlSerializer serializer = new XmlSerializer( typeof(ArenaStorage) );
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
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = IsInBattle.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsInBattle\" : \"{0}\", ", str);
			str = ConquestTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ConquestTick\" : \"{0}\", ", str);
			str = BattleType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BattleType\" : \"{0}\", ", str);
			str = Coordinate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Coordinate\" : \"{0}\", ", str);
			str = Payment.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Payment\" : \"{0}\", ", str);
			str = Level.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Level\" : \"{0}\", ", str);
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
			get { return "ArenaStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			ArenaStorage other = obj as ArenaStorage;
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
