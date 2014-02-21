using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using DesignPatterns;

namespace OrionsBelt.RulesCore.UniverseInfo {

    /// <summary>
    /// Static planet facility slot configuration
    /// </summary>
    public class FacilitySlot : IFacilitySlot {

        #region IFacilitySlot Members

        private string id = null;
        public string Identifier {
            get { return id; }
        }

        private IList<IFacilityInfo> facilities = null;
        public IList<IFacilityInfo> SupportedFacilities{
            get { return facilities; }
        }

        private IPlanetInfo info = null;
        public IPlanetInfo PlanetInfo {
            get { return info; }
        }

		private string canBuildImage = null;
		public string CanBuildImage {
			get {
				if (string.IsNullOrEmpty(canBuildImage)) {
					return this.id;
				}
				return canBuildImage;
			}
		}

        private string positionChoice;

        public string PositionChoice {
            get { return positionChoice; }
            set { positionChoice = value; }
        }

        #endregion

        #region Ctor

        public FacilitySlot(IPlanetInfo info, string identifier, params IFacilityInfo[] facilities)
        {
            this.info = info;
            this.id = identifier;
            this.facilities = new List<IFacilityInfo>(facilities);
        }

		public FacilitySlot(IPlanetInfo info, string identifier, string canBuildImage, params IFacilityInfo[] facilities) {
			this.info = info;
			this.id = identifier;
			this.canBuildImage = canBuildImage;
			this.facilities = new List<IFacilityInfo>(facilities);
		}

        #endregion Ctor

    };
}
