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
	public abstract partial class PendingBotRequest : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string botName;
		private string xml;
		private int battleId;
		private int botId;
		private int code;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PendingBotRequest's BotName
        /// </summary>
		public virtual string BotName {
			set{ this.botName = value;}
			get{ return this.botName;}
		}

		/// <summary>
        /// Gets the PendingBotRequest's Xml
        /// </summary>
		public virtual string Xml {
			set{ this.xml = value;}
			get{ return this.xml;}
		}

		/// <summary>
        /// Gets the PendingBotRequest's BattleId
        /// </summary>
		public virtual int BattleId {
			set{ this.battleId = value;}
			get{ return this.battleId;}
		}

		/// <summary>
        /// Gets the PendingBotRequest's BotId
        /// </summary>
		public virtual int BotId {
			set{ this.botId = value;}
			get{ return this.botId;}
		}

		/// <summary>
        /// Gets the PendingBotRequest's Code
        /// </summary>
		public virtual int Code {
			set{ this.code = value;}
			get{ return this.code;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PendingBotRequest) );
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
			str = BotName.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BotName\" : \"{0}\", ", str);
			str = Xml.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Xml\" : \"{0}\", ", str);
			str = BattleId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BattleId\" : \"{0}\", ", str);
			str = BotId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BotId\" : \"{0}\", ", str);
			str = Code.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Code\" : \"{0}\", ", str);
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
			get { return "PendingBotRequest"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PendingBotRequest other = obj as PendingBotRequest;
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
