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
	public abstract partial class ForumThread : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string title;
		private int totalViews;
		private int totalReplies;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the ForumThread's Title
        /// </summary>
		public virtual string Title {
			set{ this.title = value;}
			get{ return this.title;}
		}

		/// <summary>
        /// Gets the ForumThread's TotalViews
        /// </summary>
		public virtual int TotalViews {
			set{ this.totalViews = value;}
			get{ return this.totalViews;}
		}

		/// <summary>
        /// Gets the ForumThread's TotalReplies
        /// </summary>
		public virtual int TotalReplies {
			set{ this.totalReplies = value;}
			get{ return this.totalReplies;}
		}

		/// <summary>
        /// Gets the ForumThread's Posts
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ForumPost> Posts {get;set; }

		/// <summary>
        /// Gets the ForumThread's ReadMarkings
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ForumReadMarking> ReadMarkings {get;set; }

		/// <summary>
        /// Gets the ForumThread's Topic
        /// </summary>
		public abstract ForumTopic Topic {get;set; }

		/// <summary>
        /// Gets the ForumThread's Owner
        /// </summary>
		public abstract PlayerStorage Owner {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(ForumThread) );
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
			str = Title.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Title\" : \"{0}\", ", str);
			str = TotalViews.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TotalViews\" : \"{0}\", ", str);
			str = TotalReplies.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TotalReplies\" : \"{0}\", ", str);
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
			get { return "ForumThread"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			ForumThread other = obj as ForumThread;
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
