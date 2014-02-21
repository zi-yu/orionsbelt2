using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using DesignPatterns;
using DesignPatterns.Attributes;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [NoAutoRegister]
	public abstract class UnitInConstructionRenderer : FacilityInConstructionRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.UnitInConstruction; }
        }

        protected override ResourceType CurrentResourceType {
            get {
                return ResourceType.Unit;
            }
        }

        #endregion Rendering

    };
}

