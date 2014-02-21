using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using DesignPatterns;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.RulesCore.UniverseInfo {

    /// <summary>
    /// Static planet information/configuration
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("ArgonPlanet")]
    public class ArgonPlanet : PlanetInfo {

        #region PlanetInfo Implementation

        public override IRaceInfo RaceInformation {
            get { return null; }
        }

        public override Race RaceType {
            get { return Race.Global; }
        }

        public override bool HotZone {
            get { return true; }
        }

		public override string ShortIdentifier {
			get { return "ap"; }
		}

        public override void Initialize(IPlanet planet)
        { 
        }

        #endregion PlanetInfo Implementation

        #region Methods

        public ArgonPlanet()
        {
            FacilitySlots.Add(new FacilitySlot(this, "Extractor", DarknessHall.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "Defense", DarknessHall.Resource));
        }

        #endregion Methods

    };
}
