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
	public abstract partial class PrincipalTournament : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private bool hasEliminated;
		private string eliminatedInFase;
		private int eliminatedInBattleId;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PrincipalTournament's HasEliminated
        /// </summary>
		public virtual bool HasEliminated {
			set{ this.hasEliminated = value;}
			get{ return this.hasEliminated;}
		}

		/// <summary>
        /// Gets the PrincipalTournament's EliminatedInFase
        /// </summary>
		public virtual string EliminatedInFase {
			set{ this.eliminatedInFase = value;}
			get{ return this.eliminatedInFase;}
		}

		/// <summary>
        /// Gets the PrincipalTournament's EliminatedInBattleId
        /// </summary>
		public virtual int EliminatedInBattleId {
			set{ this.eliminatedInBattleId = value;}
			get{ return this.eliminatedInBattleId;}
		}

		/// <summary>
        /// Gets the PrincipalTournament's Points
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<GroupPointsStorage> Points {get;set; }

		/// <summary>
        /// Gets the PrincipalTournament's Principal
        /// </summary>
		public abstract Principal Principal {get;set; }

		/// <summary>
        /// Gets the PrincipalTournament's Tournament
        /// </summary>
		public abstract Tournament Tournament {get;set; }

		/// <summary>
        /// Gets the PrincipalTournament's Team
        /// </summary>
		public abstract TeamStorage Team {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PrincipalTournament) );
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
			str = HasEliminated.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"HasEliminated\" : \"{0}\", ", str);
			str = EliminatedInFase.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EliminatedInFase\" : \"{0}\", ", str);
			str = EliminatedInBattleId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EliminatedInBattleId\" : \"{0}\", ", str);
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
			get { return "PrincipalTournament"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PrincipalTournament other = obj as PrincipalTournament;
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
