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
    /// Specialized Memory class for ActivatedPromotion
    /// </summary>
	public class SpecializedMemoryActivatedPromotion : ActivatedPromotion {
	
		#region Fields
		
		private Promotion promotion;
		private Principal principal;

		#endregion Fields
		
		#region ActivatedPromotion Implementation
	
		/// <summary>
        /// Gets the ActivatedPromotion's Promotion
        /// </summary>
		public override Promotion Promotion {
			get { 
				return this.promotion;
			}
			set { this.promotion = value; }
		}

		/// <summary>
        /// Gets the ActivatedPromotion's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				return this.principal;
			}
			set { this.principal = value; }
		}

		#endregion ActivatedPromotion Implementation
		
	};
}
