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
    [DesignPatterns.Attributes.FactoryKey("DarkHumansPrivatePlanet")]
    public class DarkHumansPrivatePlanet : PlanetInfo {

        #region PlanetInfo Implementation

        public override Race RaceType {
            get { return Race.DarkHumans; }
        }

        public override bool HotZone {
            get { return false; }
        }

		public override string ShortIdentifier {
            get { return "dhpz"; }
		}

        public override void Initialize(IPlanet planet)
        {
            planet.AddFacility("DarknessHall", DarknessHall.Resource);
        }

        public override IFacilityInfo GetUnitBuilderFacility()
        {
            return DominationYard.Resource;
        }

        public override IFacilityInfo GetMainFacility()
        {
            return DarknessHall.Resource;
        }

        #endregion PlanetInfo Implementation

        #region Methods

        public DarkHumansPrivatePlanet()
        {
            FacilitySlots.Add(new FacilitySlot(this, "DarknessHall", DarknessHall.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "DominationYard", DominationYard.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "BattleMoonAssembler", BattleMoonAssembler.Resource));
            FacilitySlots.Add(new FacilitySlot(this, "Devastation", Devastation.Resource));

            for (int i = 0; i < 8; ++i) {
                string name = string.Format("Generic{0}", i+1);

                FacilitySlot slot = new FacilitySlot(this, name, 
                    DevotionSanctuary.Resource, 
                    TitaniumExtractor.Resource,
                    SlaveWarehouse.Resource,
                    NuclearFacility.Resource);

                if (i < 4) {
                    slot.PositionChoice = "l";
                } else {
                    slot.PositionChoice = "r";
                }

                FacilitySlots.Add(slot);
            }
        }

        #endregion Methods

    };
}
