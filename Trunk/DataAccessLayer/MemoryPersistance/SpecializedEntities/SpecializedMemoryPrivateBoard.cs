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
    /// Specialized Memory class for PrivateBoard
    /// </summary>
	public class SpecializedMemoryPrivateBoard : PrivateBoard {
	
		#region Fields
		
		private PlayerStorage sender;

		#endregion Fields
		
		#region PrivateBoard Implementation
	
		/// <summary>
        /// Gets the PrivateBoard's Sender
        /// </summary>
		public override PlayerStorage Sender {
			get { 
				return this.sender;
			}
			set { this.sender = value; }
		}

		#endregion PrivateBoard Implementation
		
	};
}
