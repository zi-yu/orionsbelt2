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
	public abstract partial class BattleStats : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int wins;
		private int defeats;
		private string type;
		private string detail;
		private int giveUps;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the BattleStats's Wins
        /// </summary>
		public virtual int Wins {
			set{ this.wins = value;}
			get{ return this.wins;}
		}

		/// <summary>
        /// Gets the BattleStats's Defeats
        /// </summary>
		public virtual int Defeats {
			set{ this.defeats = value;}
			get{ return this.defeats;}
		}

		/// <summary>
        /// Gets the BattleStats's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the BattleStats's Detail
        /// </summary>
		public virtual string Detail {
			set{ this.detail = value;}
			get{ return this.detail;}
		}

		/// <summary>
        /// Gets the BattleStats's GiveUps
        /// </summary>
		public virtual int GiveUps {
			set{ this.giveUps = value;}
			get{ return this.giveUps;}
		}

		/// <summary>
        /// Gets the BattleStats's Stats
        /// </summary>
		public abstract PrincipalStats Stats {get;set; }

		/// <summary>
        /// Gets the BattleStats's PlayerStats
        /// </summary>
		public abstract PlayerStats PlayerStats {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(BattleStats) );
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
			str = Wins.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Wins\" : \"{0}\", ", str);
			str = Defeats.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Defeats\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = Detail.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Detail\" : \"{0}\", ", str);
			str = GiveUps.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"GiveUps\" : \"{0}\", ", str);
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
			get { return "BattleStats"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			BattleStats other = obj as BattleStats;
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
