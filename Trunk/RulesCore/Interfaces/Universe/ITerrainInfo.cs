using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Generic Information about a terrain
    /// </summary>
    public interface ITerrainInfo : IResourceRichness {

        #region Properties

        /// <summary>
        /// The terrain
        /// </summary>
        Terrain Terrain { get;}

		/// <summary>
		/// If the Terrain is available
		/// </summary>
		bool AvailableForPlanets {get; }

        #endregion Properties

        #region Methods

        #endregion Methods

    };
}
