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
	public abstract partial class PlayerBattleInformation : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string initialContainer;
		private bool hasPositioned;
		private int teamNumber;
		private bool hasLost;
		private int winScore;
		private int fleetId;
		private bool updateFleet;
		private bool hasGaveUp;
		private int loseScore;
		private int victoryPercentage;
		private int dominationPoints;
		private int timeouts;
		private int owner;
		private string name;
		private string teamName;
		private string ultimateUnit;
		private int botId;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PlayerBattleInformation's InitialContainer
        /// </summary>
		public virtual string InitialContainer {
			set{ this.initialContainer = value;}
			get{ return this.initialContainer;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's HasPositioned
        /// </summary>
		public virtual bool HasPositioned {
			set{ this.hasPositioned = value;}
			get{ return this.hasPositioned;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's TeamNumber
        /// </summary>
		public virtual int TeamNumber {
			set{ this.teamNumber = value;}
			get{ return this.teamNumber;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's HasLost
        /// </summary>
		public virtual bool HasLost {
			set{ this.hasLost = value;}
			get{ return this.hasLost;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's WinScore
        /// </summary>
		public virtual int WinScore {
			set{ this.winScore = value;}
			get{ return this.winScore;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's FleetId
        /// </summary>
		public virtual int FleetId {
			set{ this.fleetId = value;}
			get{ return this.fleetId;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's UpdateFleet
        /// </summary>
		public virtual bool UpdateFleet {
			set{ this.updateFleet = value;}
			get{ return this.updateFleet;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's HasGaveUp
        /// </summary>
		public virtual bool HasGaveUp {
			set{ this.hasGaveUp = value;}
			get{ return this.hasGaveUp;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's LoseScore
        /// </summary>
		public virtual int LoseScore {
			set{ this.loseScore = value;}
			get{ return this.loseScore;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's VictoryPercentage
        /// </summary>
		public virtual int VictoryPercentage {
			set{ this.victoryPercentage = value;}
			get{ return this.victoryPercentage;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's DominationPoints
        /// </summary>
		public virtual int DominationPoints {
			set{ this.dominationPoints = value;}
			get{ return this.dominationPoints;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's Timeouts
        /// </summary>
		public virtual int Timeouts {
			set{ this.timeouts = value;}
			get{ return this.timeouts;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's Owner
        /// </summary>
		public virtual int Owner {
			set{ this.owner = value;}
			get{ return this.owner;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's TeamName
        /// </summary>
		public virtual string TeamName {
			set{ this.teamName = value;}
			get{ return this.teamName;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's UltimateUnit
        /// </summary>
		public virtual string UltimateUnit {
			set{ this.ultimateUnit = value;}
			get{ return this.ultimateUnit;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's BotId
        /// </summary>
		public virtual int BotId {
			set{ this.botId = value;}
			get{ return this.botId;}
		}

		/// <summary>
        /// Gets the PlayerBattleInformation's Battle
        /// </summary>
		public abstract Battle Battle {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PlayerBattleInformation) );
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
			str = InitialContainer.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"InitialContainer\" : \"{0}\", ", str);
			str = HasPositioned.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HasPositioned\" : \"{0}\", ", str);
			str = TeamNumber.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TeamNumber\" : \"{0}\", ", str);
			str = HasLost.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HasLost\" : \"{0}\", ", str);
			str = WinScore.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"WinScore\" : \"{0}\", ", str);
			str = FleetId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"FleetId\" : \"{0}\", ", str);
			str = UpdateFleet.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UpdateFleet\" : \"{0}\", ", str);
			str = HasGaveUp.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HasGaveUp\" : \"{0}\", ", str);
			str = LoseScore.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LoseScore\" : \"{0}\", ", str);
			str = VictoryPercentage.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"VictoryPercentage\" : \"{0}\", ", str);
			str = DominationPoints.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"DominationPoints\" : \"{0}\", ", str);
			str = Timeouts.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Timeouts\" : \"{0}\", ", str);
			str = Owner.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Owner\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = TeamName.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TeamName\" : \"{0}\", ", str);
			str = UltimateUnit.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UltimateUnit\" : \"{0}\", ", str);
			str = BotId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BotId\" : \"{0}\", ", str);
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
			get { return "PlayerBattleInformation"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PlayerBattleInformation other = obj as PlayerBattleInformation;
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
