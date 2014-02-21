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
	public abstract partial class TeamStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private int eloRanking;
		private int numberPlayedBattles;
		private bool ladderActive;
		private int ladderPosition;
		private int isInBattle;
		private int restUntil;
		private int stoppedUntil;
		private int myStatsId;
		private bool isComplete;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the TeamStorage's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the TeamStorage's EloRanking
        /// </summary>
		public virtual int EloRanking {
			set{ this.eloRanking = value;}
			get{ return this.eloRanking;}
		}

		/// <summary>
        /// Gets the TeamStorage's NumberPlayedBattles
        /// </summary>
		public virtual int NumberPlayedBattles {
			set{ this.numberPlayedBattles = value;}
			get{ return this.numberPlayedBattles;}
		}

		/// <summary>
        /// Gets the TeamStorage's LadderActive
        /// </summary>
		public virtual bool LadderActive {
			set{ this.ladderActive = value;}
			get{ return this.ladderActive;}
		}

		/// <summary>
        /// Gets the TeamStorage's LadderPosition
        /// </summary>
		public virtual int LadderPosition {
			set{ this.ladderPosition = value;}
			get{ return this.ladderPosition;}
		}

		/// <summary>
        /// Gets the TeamStorage's IsInBattle
        /// </summary>
		public virtual int IsInBattle {
			set{ this.isInBattle = value;}
			get{ return this.isInBattle;}
		}

		/// <summary>
        /// Gets the TeamStorage's RestUntil
        /// </summary>
		public virtual int RestUntil {
			set{ this.restUntil = value;}
			get{ return this.restUntil;}
		}

		/// <summary>
        /// Gets the TeamStorage's StoppedUntil
        /// </summary>
		public virtual int StoppedUntil {
			set{ this.stoppedUntil = value;}
			get{ return this.stoppedUntil;}
		}

		/// <summary>
        /// Gets the TeamStorage's MyStatsId
        /// </summary>
		public virtual int MyStatsId {
			set{ this.myStatsId = value;}
			get{ return this.myStatsId;}
		}

		/// <summary>
        /// Gets the TeamStorage's IsComplete
        /// </summary>
		public virtual bool IsComplete {
			set{ this.isComplete = value;}
			get{ return this.isComplete;}
		}

		/// <summary>
        /// Gets the TeamStorage's Principals
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Principal> Principals {get;set; }

		/// <summary>
        /// Gets the TeamStorage's Tournaments
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PrincipalTournament> Tournaments {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(TeamStorage) );
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
			str = EloRanking.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EloRanking\" : \"{0}\", ", str);
			str = NumberPlayedBattles.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberPlayedBattles\" : \"{0}\", ", str);
			str = LadderActive.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LadderActive\" : \"{0}\", ", str);
			str = LadderPosition.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LadderPosition\" : \"{0}\", ", str);
			str = IsInBattle.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsInBattle\" : \"{0}\", ", str);
			str = RestUntil.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RestUntil\" : \"{0}\", ", str);
			str = StoppedUntil.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"StoppedUntil\" : \"{0}\", ", str);
			str = MyStatsId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MyStatsId\" : \"{0}\", ", str);
			str = IsComplete.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsComplete\" : \"{0}\", ", str);
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
			get { return "TeamStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			TeamStorage other = obj as TeamStorage;
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
