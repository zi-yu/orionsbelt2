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
	public abstract partial class GroupPointsStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int stage;
		private int pontuation;
		private int wins;
		private int losses;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the GroupPointsStorage's Stage
        /// </summary>
		public virtual int Stage {
			set{ this.stage = value;}
			get{ return this.stage;}
		}

		/// <summary>
        /// Gets the GroupPointsStorage's Pontuation
        /// </summary>
		public virtual int Pontuation {
			set{ this.pontuation = value;}
			get{ return this.pontuation;}
		}

		/// <summary>
        /// Gets the GroupPointsStorage's Wins
        /// </summary>
		public virtual int Wins {
			set{ this.wins = value;}
			get{ return this.wins;}
		}

		/// <summary>
        /// Gets the GroupPointsStorage's Losses
        /// </summary>
		public virtual int Losses {
			set{ this.losses = value;}
			get{ return this.losses;}
		}

		/// <summary>
        /// Gets the GroupPointsStorage's Regist
        /// </summary>
		public abstract PrincipalTournament Regist {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(GroupPointsStorage) );
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
			str = Stage.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Stage\" : \"{0}\", ", str);
			str = Pontuation.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Pontuation\" : \"{0}\", ", str);
			str = Wins.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Wins\" : \"{0}\", ", str);
			str = Losses.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Losses\" : \"{0}\", ", str);
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
			get { return "GroupPointsStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			GroupPointsStorage other = obj as GroupPointsStorage;
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
