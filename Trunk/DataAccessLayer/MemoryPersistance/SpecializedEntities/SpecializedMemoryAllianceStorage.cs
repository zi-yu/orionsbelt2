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
    /// Specialized Memory class for AllianceStorage
    /// </summary>
	public class SpecializedMemoryAllianceStorage : AllianceStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<PlayerStorage> players;
		private System.Collections.Generic.IList<AllianceDiplomacy> diplomacyA;
		private System.Collections.Generic.IList<AllianceDiplomacy> diplomacyB;
		private System.Collections.Generic.IList<SectorStorage> sector;
		private System.Collections.Generic.IList<Asset> assets;
		private System.Collections.Generic.IList<Necessity> necessities;
		private System.Collections.Generic.IList<Offering> offerings;

		#endregion Fields
		
		#region AllianceStorage Implementation
	
		/// <summary>
        /// Gets the AllianceStorage's Players
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayerStorage> Players {
			get {
				if( this.players == null ) {
					this.players = new List<PlayerStorage>();
				}
				return this.players;
			} 
			set {
				this.players = value;
			}
		}

		/// <summary>
        /// Gets the AllianceStorage's DiplomacyA
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<AllianceDiplomacy> DiplomacyA {
			get {
				if( this.diplomacyA == null ) {
					this.diplomacyA = new List<AllianceDiplomacy>();
				}
				return this.diplomacyA;
			} 
			set {
				this.diplomacyA = value;
			}
		}

		/// <summary>
        /// Gets the AllianceStorage's DiplomacyB
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<AllianceDiplomacy> DiplomacyB {
			get {
				if( this.diplomacyB == null ) {
					this.diplomacyB = new List<AllianceDiplomacy>();
				}
				return this.diplomacyB;
			} 
			set {
				this.diplomacyB = value;
			}
		}

		/// <summary>
        /// Gets the AllianceStorage's Sector
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<SectorStorage> Sector {
			get {
				if( this.sector == null ) {
					this.sector = new List<SectorStorage>();
				}
				return this.sector;
			} 
			set {
				this.sector = value;
			}
		}

		/// <summary>
        /// Gets the AllianceStorage's Assets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Asset> Assets {
			get {
				if( this.assets == null ) {
					this.assets = new List<Asset>();
				}
				return this.assets;
			} 
			set {
				this.assets = value;
			}
		}

		/// <summary>
        /// Gets the AllianceStorage's Necessities
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Necessity> Necessities {
			get {
				if( this.necessities == null ) {
					this.necessities = new List<Necessity>();
				}
				return this.necessities;
			} 
			set {
				this.necessities = value;
			}
		}

		/// <summary>
        /// Gets the AllianceStorage's Offerings
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Offering> Offerings {
			get {
				if( this.offerings == null ) {
					this.offerings = new List<Offering>();
				}
				return this.offerings;
			} 
			set {
				this.offerings = value;
			}
		}

		#endregion AllianceStorage Implementation
		
	};
}
