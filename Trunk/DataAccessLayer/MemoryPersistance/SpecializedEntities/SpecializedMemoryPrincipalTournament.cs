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
    /// Specialized Memory class for PrincipalTournament
    /// </summary>
	public class SpecializedMemoryPrincipalTournament : PrincipalTournament {
	
		#region Fields
		
		private System.Collections.Generic.IList<GroupPointsStorage> points;
		private Principal principal;
		private Tournament tournament;
		private TeamStorage team;

		#endregion Fields
		
		#region PrincipalTournament Implementation
	
		/// <summary>
        /// Gets the PrincipalTournament's Points
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<GroupPointsStorage> Points {
			get {
				if( this.points == null ) {
					this.points = new List<GroupPointsStorage>();
				}
				return this.points;
			} 
			set {
				this.points = value;
			}
		}

		/// <summary>
        /// Gets the PrincipalTournament's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				return this.principal;
			}
			set { this.principal = value; }
		}

		/// <summary>
        /// Gets the PrincipalTournament's Tournament
        /// </summary>
		public override Tournament Tournament {
			get { 
				return this.tournament;
			}
			set { this.tournament = value; }
		}

		/// <summary>
        /// Gets the PrincipalTournament's Team
        /// </summary>
		public override TeamStorage Team {
			get { 
				return this.team;
			}
			set { this.team = value; }
		}

		#endregion PrincipalTournament Implementation
		
	};
}
