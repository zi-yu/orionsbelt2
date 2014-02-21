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
    /// Specialized Memory class for PlayersGroupStorage
    /// </summary>
	public class SpecializedMemoryPlayersGroupStorage : PlayersGroupStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<Battle> battles;
		private Tournament tournament;

		#endregion Fields
		
		#region PlayersGroupStorage Implementation
	
		/// <summary>
        /// Gets the PlayersGroupStorage's Battles
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Battle> Battles {
			get {
				if( this.battles == null ) {
					this.battles = new List<Battle>();
				}
				return this.battles;
			} 
			set {
				this.battles = value;
			}
		}

		/// <summary>
        /// Gets the PlayersGroupStorage's Tournament
        /// </summary>
		public override Tournament Tournament {
			get { 
				return this.tournament;
			}
			set { this.tournament = value; }
		}

		#endregion PlayersGroupStorage Implementation
		
	};
}
