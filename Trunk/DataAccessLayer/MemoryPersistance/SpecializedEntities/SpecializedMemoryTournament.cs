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
    /// Specialized Memory class for Tournament
    /// </summary>
	public class SpecializedMemoryTournament : Tournament {
	
		#region Fields
		
		private System.Collections.Generic.IList<PlayersGroupStorage> groups;
		private System.Collections.Generic.IList<Battle> battles;
		private System.Collections.Generic.IList<PrincipalTournament> regists;

		#endregion Fields
		
		#region Tournament Implementation
	
		/// <summary>
        /// Gets the Tournament's Groups
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayersGroupStorage> Groups {
			get {
				if( this.groups == null ) {
					this.groups = new List<PlayersGroupStorage>();
				}
				return this.groups;
			} 
			set {
				this.groups = value;
			}
		}

		/// <summary>
        /// Gets the Tournament's Battles
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
        /// Gets the Tournament's Regists
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PrincipalTournament> Regists {
			get {
				if( this.regists == null ) {
					this.regists = new List<PrincipalTournament>();
				}
				return this.regists;
			} 
			set {
				this.regists = value;
			}
		}

		#endregion Tournament Implementation
		
	};
}
