using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Facility slot information
    /// </summary>
    public interface IFacilitySlot {

        #region Properties

        /// <summary>
        /// Uniquely identifies a slog
        /// </summary>
        string Identifier { get;}

        /// <summary>
        /// The supported facilities for this slot
        /// </summary>
        IList<IFacilityInfo> SupportedFacilities { get;}

        /// <summary>
        /// The owner planet info
        /// </summary>
        IPlanetInfo PlanetInfo { get;}

		/// <summary>
		/// Gets the ImageToRender
		/// </summary>
		string CanBuildImage { get;}

        /// <summary>
        /// The position choice, if this slot has facilities on left/right sides
        /// </summary>
        string PositionChoice { get;}

        #endregion Properties

    };
}
