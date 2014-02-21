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
	public abstract partial class Tournament : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private int warningTick;
		private string prize;
		private int costCredits;
		private string tournamentType;
		private int fleetId;
		private bool isPublic;
		private bool isSurvival;
		private int turnTime;
		private int subscriptionTime;
		private int maxPlayers;
		private int minPlayers;
		private int nPlayersToPlayoff;
		private int maxElo;
		private int minElo;
		private DateTime startTime = DateTime.Now;
		private DateTime endDate = DateTime.Now;
		private string token;
		private int tokenNumber;
		private bool isCustom;
		private int paymentsRequired;
		private int numberPassGroup;
		private string descriptionToken;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Tournament's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the Tournament's WarningTick
        /// </summary>
		public virtual int WarningTick {
			set{ this.warningTick = value;}
			get{ return this.warningTick;}
		}

		/// <summary>
        /// Gets the Tournament's Prize
        /// </summary>
		public virtual string Prize {
			set{ this.prize = value;}
			get{ return this.prize;}
		}

		/// <summary>
        /// Gets the Tournament's CostCredits
        /// </summary>
		public virtual int CostCredits {
			set{ this.costCredits = value;}
			get{ return this.costCredits;}
		}

		/// <summary>
        /// Gets the Tournament's TournamentType
        /// </summary>
		public virtual string TournamentType {
			set{ this.tournamentType = value;}
			get{ return this.tournamentType;}
		}

		/// <summary>
        /// Gets the Tournament's FleetId
        /// </summary>
		public virtual int FleetId {
			set{ this.fleetId = value;}
			get{ return this.fleetId;}
		}

		/// <summary>
        /// Gets the Tournament's IsPublic
        /// </summary>
		public virtual bool IsPublic {
			set{ this.isPublic = value;}
			get{ return this.isPublic;}
		}

		/// <summary>
        /// Gets the Tournament's IsSurvival
        /// </summary>
		public virtual bool IsSurvival {
			set{ this.isSurvival = value;}
			get{ return this.isSurvival;}
		}

		/// <summary>
        /// Gets the Tournament's TurnTime
        /// </summary>
		public virtual int TurnTime {
			set{ this.turnTime = value;}
			get{ return this.turnTime;}
		}

		/// <summary>
        /// Gets the Tournament's SubscriptionTime
        /// </summary>
		public virtual int SubscriptionTime {
			set{ this.subscriptionTime = value;}
			get{ return this.subscriptionTime;}
		}

		/// <summary>
        /// Gets the Tournament's MaxPlayers
        /// </summary>
		public virtual int MaxPlayers {
			set{ this.maxPlayers = value;}
			get{ return this.maxPlayers;}
		}

		/// <summary>
        /// Gets the Tournament's MinPlayers
        /// </summary>
		public virtual int MinPlayers {
			set{ this.minPlayers = value;}
			get{ return this.minPlayers;}
		}

		/// <summary>
        /// Gets the Tournament's NPlayersToPlayoff
        /// </summary>
		public virtual int NPlayersToPlayoff {
			set{ this.nPlayersToPlayoff = value;}
			get{ return this.nPlayersToPlayoff;}
		}

		/// <summary>
        /// Gets the Tournament's MaxElo
        /// </summary>
		public virtual int MaxElo {
			set{ this.maxElo = value;}
			get{ return this.maxElo;}
		}

		/// <summary>
        /// Gets the Tournament's MinElo
        /// </summary>
		public virtual int MinElo {
			set{ this.minElo = value;}
			get{ return this.minElo;}
		}

		/// <summary>
        /// Gets the Tournament's StartTime
        /// </summary>
		public virtual DateTime StartTime {
			set{ this.startTime = value;}
			get{ return this.startTime;}
		}

		/// <summary>
        /// Gets the Tournament's EndDate
        /// </summary>
		public virtual DateTime EndDate {
			set{ this.endDate = value;}
			get{ return this.endDate;}
		}

		/// <summary>
        /// Gets the Tournament's Token
        /// </summary>
		public virtual string Token {
			set{ this.token = value;}
			get{ return this.token;}
		}

		/// <summary>
        /// Gets the Tournament's TokenNumber
        /// </summary>
		public virtual int TokenNumber {
			set{ this.tokenNumber = value;}
			get{ return this.tokenNumber;}
		}

		/// <summary>
        /// Gets the Tournament's IsCustom
        /// </summary>
		public virtual bool IsCustom {
			set{ this.isCustom = value;}
			get{ return this.isCustom;}
		}

		/// <summary>
        /// Gets the Tournament's PaymentsRequired
        /// </summary>
		public virtual int PaymentsRequired {
			set{ this.paymentsRequired = value;}
			get{ return this.paymentsRequired;}
		}

		/// <summary>
        /// Gets the Tournament's NumberPassGroup
        /// </summary>
		public virtual int NumberPassGroup {
			set{ this.numberPassGroup = value;}
			get{ return this.numberPassGroup;}
		}

		/// <summary>
        /// Gets the Tournament's DescriptionToken
        /// </summary>
		public virtual string DescriptionToken {
			set{ this.descriptionToken = value;}
			get{ return this.descriptionToken;}
		}

		/// <summary>
        /// Gets the Tournament's Groups
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlayersGroupStorage> Groups {get;set; }

		/// <summary>
        /// Gets the Tournament's Battles
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Battle> Battles {get;set; }

		/// <summary>
        /// Gets the Tournament's Regists
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PrincipalTournament> Regists {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Tournament) );
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
			str = WarningTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"WarningTick\" : \"{0}\", ", str);
			str = Prize.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Prize\" : \"{0}\", ", str);
			str = CostCredits.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CostCredits\" : \"{0}\", ", str);
			str = TournamentType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TournamentType\" : \"{0}\", ", str);
			str = FleetId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"FleetId\" : \"{0}\", ", str);
			str = IsPublic.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsPublic\" : \"{0}\", ", str);
			str = IsSurvival.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsSurvival\" : \"{0}\", ", str);
			str = TurnTime.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TurnTime\" : \"{0}\", ", str);
			str = SubscriptionTime.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SubscriptionTime\" : \"{0}\", ", str);
			str = MaxPlayers.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MaxPlayers\" : \"{0}\", ", str);
			str = MinPlayers.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MinPlayers\" : \"{0}\", ", str);
			str = NPlayersToPlayoff.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NPlayersToPlayoff\" : \"{0}\", ", str);
			str = MaxElo.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MaxElo\" : \"{0}\", ", str);
			str = MinElo.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MinElo\" : \"{0}\", ", str);
			str = StartTime.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"StartTime\" : \"{0}\", ", str);
			str = EndDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EndDate\" : \"{0}\", ", str);
			str = Token.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Token\" : \"{0}\", ", str);
			str = TokenNumber.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TokenNumber\" : \"{0}\", ", str);
			str = IsCustom.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsCustom\" : \"{0}\", ", str);
			str = PaymentsRequired.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PaymentsRequired\" : \"{0}\", ", str);
			str = NumberPassGroup.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberPassGroup\" : \"{0}\", ", str);
			str = DescriptionToken.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"DescriptionToken\" : \"{0}\", ", str);
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
			get { return "Tournament"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Tournament other = obj as Tournament;
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
