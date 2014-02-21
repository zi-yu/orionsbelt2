using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.Controls {
	public class RenderRelicFleets : ControlBase {

		#region Private

		private static SectorCoordinate GetSectorCoordinate(string systemKey, string sectorKey) {
			string systemSrc = HttpContext.Current.Request.QueryString[systemKey];
			string sectorSrc = HttpContext.Current.Request.QueryString[sectorKey];
			if( !string.IsNullOrEmpty(systemSrc) && !string.IsNullOrEmpty(sectorSrc) ) {
				Coordinate systemSource = new Coordinate(systemSrc);
				Coordinate sectorSource = new Coordinate(sectorSrc);
				return new SectorCoordinate(systemSource, sectorSource);	
			}
			return null;
		}

		#endregion Private

		#region Control Events

		protected override void Render(HtmlTextWriter writer) {
			SectorCoordinate relicCoord = GetSectorCoordinate("systemDst", "sectorDst");
			if( relicCoord == null ) {
				relicCoord = GetSectorCoordinate("systemSrc", "sectorSrc");	
			}

			List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(relicCoord, 2);

			IFleetInfo relicFleet = null;
			List<IFleetInfo> fleets = new List<IFleetInfo>();
			foreach (IFleetInfo fleet in PlayerUtils.Current.AllFleets) {
				if (fleet.Location.Equals(relicCoord)) {
					relicFleet = fleet;
					continue;
				}
				if (!fleet.IsPlanetDefenseFleet && !fleet.IsInBattle && !fleet.IsMoving) {
					if (coordinates.Contains(fleet.Location)) {
						fleets.Add(fleet);
					}
				}
			}
			if (relicFleet != null) {
				FleetsInRelicRenderer.Render(writer, relicFleet, fleets);	
			}
		}

		#endregion Control Events

	}
}
