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
	public abstract partial class PlayersGroupStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int eliminatoryNumber;
		private string playersIds;
		private int groupNumber;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PlayersGroupStorage's EliminatoryNumber
        /// </summary>
		public virtual int EliminatoryNumber {
			set{ this.eliminatoryNumber = value;}
			get{ return this.eliminatoryNumber;}
		}

		/// <summary>
        /// Gets the PlayersGroupStorage's PlayersIds
        /// </summary>
		public virtual string PlayersIds {
			set{ this.playersIds = value;}
			get{ return this.playersIds;}
		}

		/// <summary>
        /// Gets the PlayersGroupStorage's GroupNumber
        /// </summary>
		public virtual int GroupNumber {
			set{ this.groupNumber = value;}
			get{ return this.groupNumber;}
		}

		/// <summary>
        /// Gets the PlayersGroupStorage's Battles
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Battle> Battles {get;set; }

		/// <summary>
        /// Gets the PlayersGroupStorage's Tournament
        /// </summary>
		public abstract Tournament Tournament {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PlayersGroupStorage) );
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
			str = EliminatoryNumber.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EliminatoryNumber\" : \"{0}\", ", str);
			str = PlayersIds.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PlayersIds\" : \"{0}\", ", str);
			str = GroupNumber.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"GroupNumber\" : \"{0}\", ", str);
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
			get { return "PlayersGroupStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PlayersGroupStorage other = obj as PlayersGroupStorage;
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
