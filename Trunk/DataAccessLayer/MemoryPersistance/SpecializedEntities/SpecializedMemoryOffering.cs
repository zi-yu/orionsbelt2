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
    /// Specialized Memory class for Offering
    /// </summary>
	public class SpecializedMemoryOffering : Offering {
	
		#region Fields
		
		private PlayerStorage donor;
		private PlayerStorage receiver;
		private AllianceStorage alliance;

		#endregion Fields
		
		#region Offering Implementation
	
		/// <summary>
        /// Gets the Offering's Donor
        /// </summary>
		public override PlayerStorage Donor {
			get { 
				return this.donor;
			}
			set { this.donor = value; }
		}

		/// <summary>
        /// Gets the Offering's Receiver
        /// </summary>
		public override PlayerStorage Receiver {
			get { 
				return this.receiver;
			}
			set { this.receiver = value; }
		}

		/// <summary>
        /// Gets the Offering's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				return this.alliance;
			}
			set { this.alliance = value; }
		}

		#endregion Offering Implementation
		
	};
}
