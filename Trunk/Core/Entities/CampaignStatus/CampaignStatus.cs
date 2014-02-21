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
	public abstract partial class CampaignStatus : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int level;
		private int moves;
		private bool completed;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the CampaignStatus's Level
        /// </summary>
		public virtual int Level {
			set{ this.level = value;}
			get{ return this.level;}
		}

		/// <summary>
        /// Gets the CampaignStatus's Moves
        /// </summary>
		public virtual int Moves {
			set{ this.moves = value;}
			get{ return this.moves;}
		}

		/// <summary>
        /// Gets the CampaignStatus's Completed
        /// </summary>
		public virtual bool Completed {
			set{ this.completed = value;}
			get{ return this.completed;}
		}

		/// <summary>
        /// Gets the CampaignStatus's Campaign
        /// </summary>
		public abstract Campaign Campaign {get;set; }

		/// <summary>
        /// Gets the CampaignStatus's Principal
        /// </summary>
		public abstract Principal Principal {get;set; }

		/// <summary>
        /// Gets the CampaignStatus's Battle
        /// </summary>
		public abstract Battle Battle {get;set; }

		/// <summary>
        /// Gets the CampaignStatus's LevelTemplate
        /// </summary>
		public abstract CampaignLevel LevelTemplate {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(CampaignStatus) );
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
			str = Level.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Level\" : \"{0}\", ", str);
			str = Moves.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Moves\" : \"{0}\", ", str);
			str = Completed.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Completed\" : \"{0}\", ", str);
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
			get { return "CampaignStatus"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			CampaignStatus other = obj as CampaignStatus;
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
