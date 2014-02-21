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
	public abstract partial class Battle : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int currentTurn;
		private bool hasEnded;
		private string battleType;
		private string battleMode;
		private string unitsDestroyed;
		private string terrain;
		private int currentPlayer;
		private int timeoutsAllowed;
		private string tournamentMode;
		private bool isDeployTime;
		private bool isTeamBattle;
		private double seqNumber;
		private bool isToConquer;
		private bool isInPlanet;
		private int currentBot;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Battle's CurrentTurn
        /// </summary>
		public virtual int CurrentTurn {
			set{ this.currentTurn = value;}
			get{ return this.currentTurn;}
		}

		/// <summary>
        /// Gets the Battle's HasEnded
        /// </summary>
		public virtual bool HasEnded {
			set{ this.hasEnded = value;}
			get{ return this.hasEnded;}
		}

		/// <summary>
        /// Gets the Battle's BattleType
        /// </summary>
		public virtual string BattleType {
			set{ this.battleType = value;}
			get{ return this.battleType;}
		}

		/// <summary>
        /// Gets the Battle's BattleMode
        /// </summary>
		public virtual string BattleMode {
			set{ this.battleMode = value;}
			get{ return this.battleMode;}
		}

		/// <summary>
        /// Gets the Battle's UnitsDestroyed
        /// </summary>
		public virtual string UnitsDestroyed {
			set{ this.unitsDestroyed = value;}
			get{ return this.unitsDestroyed;}
		}

		/// <summary>
        /// Gets the Battle's Terrain
        /// </summary>
		public virtual string Terrain {
			set{ this.terrain = value;}
			get{ return this.terrain;}
		}

		/// <summary>
        /// Gets the Battle's CurrentPlayer
        /// </summary>
		public virtual int CurrentPlayer {
			set{ this.currentPlayer = value;}
			get{ return this.currentPlayer;}
		}

		/// <summary>
        /// Gets the Battle's TimeoutsAllowed
        /// </summary>
		public virtual int TimeoutsAllowed {
			set{ this.timeoutsAllowed = value;}
			get{ return this.timeoutsAllowed;}
		}

		/// <summary>
        /// Gets the Battle's TournamentMode
        /// </summary>
		public virtual string TournamentMode {
			set{ this.tournamentMode = value;}
			get{ return this.tournamentMode;}
		}

		/// <summary>
        /// Gets the Battle's IsDeployTime
        /// </summary>
		public virtual bool IsDeployTime {
			set{ this.isDeployTime = value;}
			get{ return this.isDeployTime;}
		}

		/// <summary>
        /// Gets the Battle's IsTeamBattle
        /// </summary>
		public virtual bool IsTeamBattle {
			set{ this.isTeamBattle = value;}
			get{ return this.isTeamBattle;}
		}

		/// <summary>
        /// Gets the Battle's SeqNumber
        /// </summary>
		public virtual double SeqNumber {
			set{ this.seqNumber = value;}
			get{ return this.seqNumber;}
		}

		/// <summary>
        /// Gets the Battle's IsToConquer
        /// </summary>
		public virtual bool IsToConquer {
			set{ this.isToConquer = value;}
			get{ return this.isToConquer;}
		}

		/// <summary>
        /// Gets the Battle's IsInPlanet
        /// </summary>
		public virtual bool IsInPlanet {
			set{ this.isInPlanet = value;}
			get{ return this.isInPlanet;}
		}

		/// <summary>
        /// Gets the Battle's CurrentBot
        /// </summary>
		public virtual int CurrentBot {
			set{ this.currentBot = value;}
			get{ return this.currentBot;}
		}

		/// <summary>
        /// Gets the Battle's PlayerInformation
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlayerBattleInformation> PlayerInformation {get;set; }

		/// <summary>
        /// Gets the Battle's BattleExtension
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<BattleExtention> BattleExtension {get;set; }

		/// <summary>
        /// Gets the Battle's TimedAction
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<TimedActionStorage> TimedAction {get;set; }

		/// <summary>
        /// Gets the Battle's Campaigns
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<CampaignStatus> Campaigns {get;set; }

		/// <summary>
        /// Gets the Battle's Tournament
        /// </summary>
		public abstract Tournament Tournament {get;set; }

		/// <summary>
        /// Gets the Battle's Group
        /// </summary>
		public abstract PlayersGroupStorage Group {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Battle) );
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
			str = CurrentTurn.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CurrentTurn\" : \"{0}\", ", str);
			str = HasEnded.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HasEnded\" : \"{0}\", ", str);
			str = BattleType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BattleType\" : \"{0}\", ", str);
			str = BattleMode.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BattleMode\" : \"{0}\", ", str);
			str = UnitsDestroyed.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UnitsDestroyed\" : \"{0}\", ", str);
			str = Terrain.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Terrain\" : \"{0}\", ", str);
			str = CurrentPlayer.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CurrentPlayer\" : \"{0}\", ", str);
			str = TimeoutsAllowed.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TimeoutsAllowed\" : \"{0}\", ", str);
			str = TournamentMode.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TournamentMode\" : \"{0}\", ", str);
			str = IsDeployTime.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsDeployTime\" : \"{0}\", ", str);
			str = IsTeamBattle.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsTeamBattle\" : \"{0}\", ", str);
			str = SeqNumber.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SeqNumber\" : \"{0}\", ", str);
			str = IsToConquer.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsToConquer\" : \"{0}\", ", str);
			str = IsInPlanet.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsInPlanet\" : \"{0}\", ", str);
			str = CurrentBot.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CurrentBot\" : \"{0}\", ", str);
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
			get { return "Battle"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Battle other = obj as Battle;
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
