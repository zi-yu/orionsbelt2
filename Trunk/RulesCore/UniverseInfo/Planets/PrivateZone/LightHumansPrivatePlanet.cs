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
    [DesignPatterns.Attributes.FactoryKey("LightHumansPrivatePlanet")]
    public class LightHumansPrivatePlanet : PlanetInfo {

        #region PlanetInfo Implementation

        public override Race RaceType {
            get { return Race.LightHumans; }
        }

        public override bool HotZone {
            get { return false; }
        }

		public override string ShortIdentifier {
            get { return "lhpz"; }
		}

        public override void Initialize(IPlanet planet)
        {
            planet.AddFacility("CommandCenter", CommandCenter.Resource);
        }

        public override IFacilityInfo GetUnitBuilderFacility()
        {
            return UnitYard.Resource;
        }

        public override IFacilityInfo GetMainFacility()
        {
            return CommandCenter.Resource;
        }

        #endregion PlanetInfo Implementation

        #region Methods

        public LightHumansPrivatePlanet()
        {
            FacilitySlots.Add(new FacilitySlot(this, "CommandCenter", CommandCenter.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "UnitYard", "GenericLeft", UnitYard.Resource));
			FacilitySlots.Add(new FacilitySlot(this, "BlinkerAssembler", "GenericLeft", BlinkerAssembler.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "DeepSpaceScanner", DeepSpaceScanner.Resource));
			FacilitySlots.Add(new FacilitySlot(this, "Silo", "GenericRight", Silo.Resource));

			FacilitySlots.Add(new FacilitySlot(this, "Resource1", "GenericRight", SeriumExtractor.Resource, MithrilExtractor.Resource, SolarPanel.Resource));
			FacilitySlots.Add(new FacilitySlot(this, "Resource2", "GenericRight", SeriumExtractor.Resource, MithrilExtractor.Resource, SolarPanel.Resource));
			FacilitySlots.Add(new FacilitySlot(this, "Resource3", "GenericRight", SeriumExtractor.Resource, MithrilExtractor.Resource, SolarPanel.Resource));
			FacilitySlots.Add(new FacilitySlot(this, "Resource4", "GenericRight", SeriumExtractor.Resource, MithrilExtractor.Resource, SolarPanel.Resource));
			FacilitySlots.Add(new FacilitySlot(this, "Resource5", "GenericRight", SeriumExtractor.Resource, MithrilExtractor.Resource, SolarPanel.Resource));
        }

        #endregion Methods

    };
}
