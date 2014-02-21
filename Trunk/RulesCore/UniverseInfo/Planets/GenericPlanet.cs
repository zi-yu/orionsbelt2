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
    [DesignPatterns.Attributes.FactoryKey("GenericPlanet")]
    public class GenericPlanet : PlanetInfo {

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
			get { return "gp"; }
		}

        public override void Initialize(IPlanet planet)
        {
            foreach (IResourceInfo info in RulesUtils.GetIntrinsicNonConceptualResources()) {
                if (info.IsRare) {
                    continue;
                }
                int richness = 100;
                if (!RulesUtils.MatchRace(info.Races, planet)) {
                    richness = 0;
                }
                planet.SetRichness(info, richness);
            }
        }

        #endregion PlanetInfo Implementation

        #region Methods

        public GenericPlanet()
        {
            FacilitySlots.Add(new FacilitySlot(this, "GenericSlot1", "GenericRight", Extractor.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "GenericSlot2", "GenericRight", Extractor.Resource));
        }

        #endregion Methods

    };
}
