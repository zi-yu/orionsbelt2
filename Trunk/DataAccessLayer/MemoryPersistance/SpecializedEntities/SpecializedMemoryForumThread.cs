using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Loki.Exceptions;
using Loki.Interfaces;
using Loki.Generic;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {

	/// <summary>
    /// Specialized Memory class for ForumThread
    /// </summary>
	public class SpecializedMemoryForumThread : ForumThread {
	
		#region Fields
		
		private System.Collections.Generic.IList<ForumPost> posts;
		private System.Collections.Generic.IList<ForumReadMarking> readMarkings;
		private ForumTopic topic;
		private PlayerStorage owner;

		#endregion Fields
		
		#region ForumThread Implementation
	
		/// <summary>
        /// Gets the ForumThread's Posts
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumPost> Posts {
			get {
				if( this.posts == null ) {
					this.posts = new List<ForumPost>();
				}
				return this.posts;
			} 
			set {
				this.posts = value;
			}
		}

		/// <summary>
        /// Gets the ForumThread's ReadMarkings
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumReadMarking> ReadMarkings {
			get {
				if( this.readMarkings == null ) {
					this.readMarkings = new List<ForumReadMarking>();
				}
				return this.readMarkings;
			} 
			set {
				this.readMarkings = value;
			}
		}

		/// <summary>
        /// Gets the ForumThread's Topic
        /// </summary>
		public override ForumTopic Topic {
			get { 
				return this.topic;
			}
			set { this.topic = value; }
		}

		/// <summary>
        /// Gets the ForumThread's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		#endregion ForumThread Implementation
		
	};
}
