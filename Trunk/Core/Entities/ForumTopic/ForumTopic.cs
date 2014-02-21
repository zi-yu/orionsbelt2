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
	public abstract partial class ForumTopic : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string title;
		private DateTime lastPost = DateTime.Now;
		private int totalPosts;
		private int totalThreads;
		private bool isPrivate;
		private string forumRoles;
		private string description;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the ForumTopic's Title
        /// </summary>
		public virtual string Title {
			set{ this.title = value;}
			get{ return this.title;}
		}

		/// <summary>
        /// Gets the ForumTopic's LastPost
        /// </summary>
		public virtual DateTime LastPost {
			set{ this.lastPost = value;}
			get{ return this.lastPost;}
		}

		/// <summary>
        /// Gets the ForumTopic's TotalPosts
        /// </summary>
		public virtual int TotalPosts {
			set{ this.totalPosts = value;}
			get{ return this.totalPosts;}
		}

		/// <summary>
        /// Gets the ForumTopic's TotalThreads
        /// </summary>
		public virtual int TotalThreads {
			set{ this.totalThreads = value;}
			get{ return this.totalThreads;}
		}

		/// <summary>
        /// Gets the ForumTopic's IsPrivate
        /// </summary>
		public virtual bool IsPrivate {
			set{ this.isPrivate = value;}
			get{ return this.isPrivate;}
		}

		/// <summary>
        /// Gets the ForumTopic's ForumRoles
        /// </summary>
		public virtual string ForumRoles {
			set{ this.forumRoles = value;}
			get{ return this.forumRoles;}
		}

		/// <summary>
        /// Gets the ForumTopic's Description
        /// </summary>
		public virtual string Description {
			set{ this.description = value;}
			get{ return this.description;}
		}

		/// <summary>
        /// Gets the ForumTopic's Threads
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ForumThread> Threads {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(ForumTopic) );
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
			str = LastPost.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastPost\" : \"{0}\", ", str);
			str = TotalPosts.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TotalPosts\" : \"{0}\", ", str);
			str = TotalThreads.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TotalThreads\" : \"{0}\", ", str);
			str = IsPrivate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsPrivate\" : \"{0}\", ", str);
			str = ForumRoles.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ForumRoles\" : \"{0}\", ", str);
			str = Description.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Description\" : \"{0}\", ", str);
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
			get { return "ForumTopic"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			ForumTopic other = obj as ForumTopic;
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
