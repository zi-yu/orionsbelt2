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
    /// Specialized Memory class for ForumTopic
    /// </summary>
	public class SpecializedMemoryForumTopic : ForumTopic {
	
		#region Fields
		
		private System.Collections.Generic.IList<ForumThread> threads;

		#endregion Fields
		
		#region ForumTopic Implementation
	
		/// <summary>
        /// Gets the ForumTopic's Threads
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumThread> Threads {
			get {
				if( this.threads == null ) {
					this.threads = new List<ForumThread>();
				}
				return this.threads;
			} 
			set {
				this.threads = value;
			}
		}

		#endregion ForumTopic Implementation
		
	};
}
