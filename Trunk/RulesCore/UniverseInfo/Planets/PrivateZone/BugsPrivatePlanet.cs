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
    [DesignPatterns.Attributes.FactoryKey("BugsPrivatePlanet")]
    public class BugsPrivatePlanet : PlanetInfo {

        #region PlanetInfo Implementation

        public override Race RaceType {
            get { return Race.Bugs; }
        }

        public override bool HotZone {
            get { return false; }
        }

		public override string ShortIdentifier {
            get { return "bpz"; }
		}

        public override void Initialize(IPlanet planet)
        {
            planet.AddFacility("Nest", Nest.Resource);
        }

        public override IFacilityInfo GetUnitBuilderFacility()
        {
            return Incubator.Resource;
        }

        public override IFacilityInfo GetMainFacility()
        {
            return Nest.Resource;
        }

        #endregion PlanetInfo Implementation

        #region Methods

        public BugsPrivatePlanet()
        {
            FacilitySlots.Add(new FacilitySlot(this, "Nest", Nest.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "Incubator", Incubator.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "WormHoleCreator", WormHoleCreator.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "QueenHatchery", QueenHatchery.Resource));

            for (int i = 0; i < 4; ++i) {
                string name = string.Format("Resource{0}", i+1);

                FacilitySlot slot = new FacilitySlot(this, name, 
                        ProtolExtractor.Resource, 
                        ElkExtractor.Resource
                    );

                FacilitySlots.Add(slot);
            }
        }

        #endregion Methods

    };
}
