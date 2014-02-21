using System.IO;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using System.Web;

namespace OrionsBelt.WebUserInterface.Engine {
	
	public class UniverseActions : ActionBase {

		#region Private

		private void RenderUniverse() {
			StringWriter writer = new StringWriter();
			UniverseSectorRenderer.Render(writer);
            HttpContext.Current.Response.Write(writer.ToString());
		}

        private void RenderUniverse(SectorCoordinate coordinate) {
			StringWriter writer = new StringWriter();
            UniverseSectorRenderer.Render(writer, coordinate);
            HttpContext.Current.Response.Write(writer.ToString());
		}

		#endregion Private

		#region Delegates

		private void ZoomMore() {
            int level = int.Parse(HttpContext.Current.Request.QueryString["zoomlevel"]);
			ZoomLevel.Level = level;
			RenderUniverse();
		}

		private void CenterInFleet() {
            string centerFleet = HttpContext.Current.Request.QueryString["fleet"];
            int fleetId;
            if (int.TryParse(centerFleet, out fleetId)){
				if (ZoomLevel.Level == ZoomLevel.MinimumLevel) {
					ZoomLevel.Level = ZoomLevel.MaximumLevel;	
				}
                CenterCoordinate.Current.SetCenterInFleet(fleetId);
                RenderUniverse(CenterCoordinate.Current.Center);
            }
        }

        private void CenterInPlanet(){
            string centerPlanet = HttpContext.Current.Request.QueryString["planet"];
            int planetId;
            if (int.TryParse(centerPlanet, out planetId)){
				if (ZoomLevel.Level == ZoomLevel.MinimumLevel) {
					ZoomLevel.Level = ZoomLevel.MaximumLevel;
				}
                IPlanet planet = PlayerUtils.Current.GetPlanet(planetId);
                CenterCoordinate.Current.SetCenter(planet.Location);
                RenderUniverse(CenterCoordinate.Current.Center);
            }
        }

		private void CenterInCoordinate() {
            string coordinate = HttpContext.Current.Request.QueryString["coordinate"];
			string[] splitted = coordinate.Split('_');

            if (splitted.Length == 4 ){
            	SectorCoordinate sectorCoordinate = new SectorCoordinate(splitted[0], splitted[1], splitted[2], splitted[3]);
				ZoomLevel.Level = ZoomLevel.MaximumLevel;
				CenterCoordinate.Current.SetCenter(sectorCoordinate);
                RenderUniverse(CenterCoordinate.Current.Center);
            }
        }

		private void MoveMap() {
            string coordinateCode = HttpContext.Current.Request.QueryString["code"];
			SectorCoordinate coordinate = CenterCoordinate.Current.Center;
			SectorCoordinate newCoordinate = CoordinateMapping.GetCoordinate(coordinateCode, coordinate);
			if (newCoordinate == null) {
				newCoordinate = coordinate;
			} else {
				CenterCoordinate.Current.SetCenter(newCoordinate);
			}
			RenderUniverse(newCoordinate);
        }

		#endregion Delegates

		#region Constructor

		public UniverseActions() {
			actions["zoom"] = ZoomMore;
            actions["centerfleet"] = CenterInFleet;
            actions["centerplanet"] = CenterInPlanet;
			actions["centercoordinate"] = CenterInCoordinate;
			actions["movemap"] = MoveMap;
		}

		#endregion Constructor

	
	}
}
