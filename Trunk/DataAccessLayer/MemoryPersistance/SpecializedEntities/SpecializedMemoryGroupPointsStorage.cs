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
    /// Specialized Memory class for GroupPointsStorage
    /// </summary>
	public class SpecializedMemoryGroupPointsStorage : GroupPointsStorage {
	
		#region Fields
		
		private PrincipalTournament regist;

		#endregion Fields
		
		#region GroupPointsStorage Implementation
	
		/// <summary>
        /// Gets the GroupPointsStorage's Regist
        /// </summary>
		public override PrincipalTournament Regist {
			get { 
				return this.regist;
			}
			set { this.regist = value; }
		}

		#endregion GroupPointsStorage Implementation
		
	};
}
