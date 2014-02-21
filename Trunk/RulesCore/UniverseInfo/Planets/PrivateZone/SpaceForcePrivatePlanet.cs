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
    [DesignPatterns.Attributes.FactoryKey("SpaceForcePrivatePlanet")]
    public class SpaceForcePrivatePlanet : MercsPrivatePlanet {

        #region PlanetInfo Implementation

        public override Race RaceType {
            get { return Race.SpaceForce; }
        }

		public override string ShortIdentifier {
            get { return "sfpz"; }
		}

        #endregion PlanetInfo Implementation

        #region Methods

        public SpaceForcePrivatePlanet() : base() {}

        #endregion Methods

    };
}
