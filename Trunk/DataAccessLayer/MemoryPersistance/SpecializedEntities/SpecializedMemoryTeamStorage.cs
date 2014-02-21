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
    /// Specialized Memory class for TeamStorage
    /// </summary>
	public class SpecializedMemoryTeamStorage : TeamStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<Principal> principals;
		private System.Collections.Generic.IList<PrincipalTournament> tournaments;

		#endregion Fields
		
		#region TeamStorage Implementation
	
		/// <summary>
        /// Gets the TeamStorage's Principals
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Principal> Principals {
			get {
				if( this.principals == null ) {
					this.principals = new List<Principal>();
				}
				return this.principals;
			} 
			set {
				this.principals = value;
			}
		}

		/// <summary>
        /// Gets the TeamStorage's Tournaments
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PrincipalTournament> Tournaments {
			get {
				if( this.tournaments == null ) {
					this.tournaments = new List<PrincipalTournament>();
				}
				return this.tournaments;
			} 
			set {
				this.tournaments = value;
			}
		}

		#endregion TeamStorage Implementation
		
	};
}
