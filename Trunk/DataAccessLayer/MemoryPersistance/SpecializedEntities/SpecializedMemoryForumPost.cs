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
    /// Specialized Memory class for ForumPost
    /// </summary>
	public class SpecializedMemoryForumPost : ForumPost {
	
		#region Fields
		
		private ForumThread thread;
		private PlayerStorage owner;

		#endregion Fields
		
		#region ForumPost Implementation
	
		/// <summary>
        /// Gets the ForumPost's Thread
        /// </summary>
		public override ForumThread Thread {
			get { 
				return this.thread;
			}
			set { this.thread = value; }
		}

		/// <summary>
        /// Gets the ForumPost's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		#endregion ForumPost Implementation
		
	};
}
