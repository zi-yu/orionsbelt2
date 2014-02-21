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
	public abstract partial class PrincipalStats : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int maxElo;
		private int minElo;
		private int numberPlayedBattles;
		private int maxLadder;
		private int minLadder;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PrincipalStats's MaxElo
        /// </summary>
		public virtual int MaxElo {
			set{ this.maxElo = value;}
			get{ return this.maxElo;}
		}

		/// <summary>
        /// Gets the PrincipalStats's MinElo
        /// </summary>
		public virtual int MinElo {
			set{ this.minElo = value;}
			get{ return this.minElo;}
		}

		/// <summary>
        /// Gets the PrincipalStats's NumberPlayedBattles
        /// </summary>
		public virtual int NumberPlayedBattles {
			set{ this.numberPlayedBattles = value;}
			get{ return this.numberPlayedBattles;}
		}

		/// <summary>
        /// Gets the PrincipalStats's MaxLadder
        /// </summary>
		public virtual int MaxLadder {
			set{ this.maxLadder = value;}
			get{ return this.maxLadder;}
		}

		/// <summary>
        /// Gets the PrincipalStats's MinLadder
        /// </summary>
		public virtual int MinLadder {
			set{ this.minLadder = value;}
			get{ return this.minLadder;}
		}

		/// <summary>
        /// Gets the PrincipalStats's BattleStats
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<BattleStats> BattleStats {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PrincipalStats) );
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
			str = MaxElo.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MaxElo\" : \"{0}\", ", str);
			str = MinElo.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MinElo\" : \"{0}\", ", str);
			str = NumberPlayedBattles.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberPlayedBattles\" : \"{0}\", ", str);
			str = MaxLadder.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MaxLadder\" : \"{0}\", ", str);
			str = MinLadder.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MinLadder\" : \"{0}\", ", str);
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
			get { return "PrincipalStats"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PrincipalStats other = obj as PrincipalStats;
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
