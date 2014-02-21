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
    /// Specialized Memory class for AllianceDiplomacy
    /// </summary>
	public class SpecializedMemoryAllianceDiplomacy : AllianceDiplomacy {
	
		#region Fields
		
		private AllianceStorage allianceA;
		private AllianceStorage allianceB;

		#endregion Fields
		
		#region AllianceDiplomacy Implementation
	
		/// <summary>
        /// Gets the AllianceDiplomacy's AllianceA
        /// </summary>
		public override AllianceStorage AllianceA {
			get { 
				return this.allianceA;
			}
			set { this.allianceA = value; }
		}

		/// <summary>
        /// Gets the AllianceDiplomacy's AllianceB
        /// </summary>
		public override AllianceStorage AllianceB {
			get { 
				return this.allianceB;
			}
			set { this.allianceB = value; }
		}

		#endregion AllianceDiplomacy Implementation
		
	};
}
