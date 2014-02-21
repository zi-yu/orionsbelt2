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
    /// Specialized Memory class for BonusCard
    /// </summary>
	public class SpecializedMemoryBonusCard : BonusCard {
	
		#region Fields
		
		private Principal usedBy;

		#endregion Fields
		
		#region BonusCard Implementation
	
		/// <summary>
        /// Gets the BonusCard's UsedBy
        /// </summary>
		public override Principal UsedBy {
			get { 
				return this.usedBy;
			}
			set { this.usedBy = value; }
		}

		#endregion BonusCard Implementation
		
	};
}
