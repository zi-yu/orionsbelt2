using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using DesignPatterns;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// type of panels on the planet page
    /// </summary>
    public enum PlanetRendererPanel {

        Facilities,
        BuildFacility,
        UpgradeFacility,
        FacilityInConstruction,
        Units,
        UnitInConstruction,
        Queue,
        Fleets,
        Manage,

        ResourceOverview,
        FacilityOverview,
        UnitOverview
        
    };
}

