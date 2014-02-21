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
	public abstract partial class ArenaHistorical : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int championId;
		private int challengerId;
		private int winner;
		private int winningSequence;
		private int battleId;
		private int startTick;
		private int endTick;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the ArenaHistorical's ChampionId
        /// </summary>
		public virtual int ChampionId {
			set{ this.championId = value;}
			get{ return this.championId;}
		}

		/// <summary>
        /// Gets the ArenaHistorical's ChallengerId
        /// </summary>
		public virtual int ChallengerId {
			set{ this.challengerId = value;}
			get{ return this.challengerId;}
		}

		/// <summary>
        /// Gets the ArenaHistorical's Winner
        /// </summary>
		public virtual int Winner {
			set{ this.winner = value;}
			get{ return this.winner;}
		}

		/// <summary>
        /// Gets the ArenaHistorical's WinningSequence
        /// </summary>
		public virtual int WinningSequence {
			set{ this.winningSequence = value;}
			get{ return this.winningSequence;}
		}

		/// <summary>
        /// Gets the ArenaHistorical's BattleId
        /// </summary>
		public virtual int BattleId {
			set{ this.battleId = value;}
			get{ return this.battleId;}
		}

		/// <summary>
        /// Gets the ArenaHistorical's StartTick
        /// </summary>
		public virtual int StartTick {
			set{ this.startTick = value;}
			get{ return this.startTick;}
		}

		/// <summary>
        /// Gets the ArenaHistorical's EndTick
        /// </summary>
		public virtual int EndTick {
			set{ this.endTick = value;}
			get{ return this.endTick;}
		}

		/// <summary>
        /// Gets the ArenaHistorical's Arena
        /// </summary>
		public abstract ArenaStorage Arena {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(ArenaHistorical) );
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
			str = ChampionId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ChampionId\" : \"{0}\", ", str);
			str = ChallengerId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ChallengerId\" : \"{0}\", ", str);
			str = Winner.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Winner\" : \"{0}\", ", str);
			str = WinningSequence.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"WinningSequence\" : \"{0}\", ", str);
			str = BattleId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BattleId\" : \"{0}\", ", str);
			str = StartTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"StartTick\" : \"{0}\", ", str);
			str = EndTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EndTick\" : \"{0}\", ", str);
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
			get { return "ArenaHistorical"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			ArenaHistorical other = obj as ArenaHistorical;
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
