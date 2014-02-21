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
	public abstract partial class CampaignLevel : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string botFleet;
		private string playerFleet;
		private int level;
		private string botName;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the CampaignLevel's BotFleet
        /// </summary>
		public virtual string BotFleet {
			set{ this.botFleet = value;}
			get{ return this.botFleet;}
		}

		/// <summary>
        /// Gets the CampaignLevel's PlayerFleet
        /// </summary>
		public virtual string PlayerFleet {
			set{ this.playerFleet = value;}
			get{ return this.playerFleet;}
		}

		/// <summary>
        /// Gets the CampaignLevel's Level
        /// </summary>
		public virtual int Level {
			set{ this.level = value;}
			get{ return this.level;}
		}

		/// <summary>
        /// Gets the CampaignLevel's BotName
        /// </summary>
		public virtual string BotName {
			set{ this.botName = value;}
			get{ return this.botName;}
		}

		/// <summary>
        /// Gets the CampaignLevel's CampaignStatus
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<CampaignStatus> CampaignStatus {get;set; }

		/// <summary>
        /// Gets the CampaignLevel's Campaign
        /// </summary>
		public abstract Campaign Campaign {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(CampaignLevel) );
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
			str = BotFleet.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BotFleet\" : \"{0}\", ", str);
			str = PlayerFleet.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PlayerFleet\" : \"{0}\", ", str);
			str = Level.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Level\" : \"{0}\", ", str);
			str = BotName.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BotName\" : \"{0}\", ", str);
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
			get { return "CampaignLevel"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			CampaignLevel other = obj as CampaignLevel;
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
