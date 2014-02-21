using System.IO;
using System.Web;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic.Log;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax {

	public abstract class BaseUniverseHandler : BaseHandler {

		#region BattleMoveHandler Implementation

		public override void Init() {
			type = LogType.FleetMovement;
		}

		public override void ProcessRequest(HttpContext c) {
			base.ProcessRequest(c);

			string systemSrc = context.Request.QueryString["systemSrc"];
			string sectorSrc = context.Request.QueryString["sectorSrc"];
			string systemDst = context.Request.QueryString["systemDst"];
			string sectorDst = context.Request.QueryString["sectorDst"];
			try {
				Coordinate systemSource = ParseCoordinate(systemSrc);
				Coordinate sectorSource = ParseCoordinate(sectorSrc);
				Coordinate systemDestiny = ParseCoordinate(systemDst);
				Coordinate sectorDestiny = ParseCoordinate(sectorDst);
				SectorCoordinate source = new SectorCoordinate(systemSource, sectorSource);

				ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, systemSource, sectorSource);

				if (sector != null && sector is FleetSector && sector.Owner.Equals(PlayerUtils.Current)) {
					FleetSectorMoveArgs args = new FleetSectorMoveArgs();
					args.Source = source;
					args.Destiny = new SectorCoordinate(systemDestiny, sectorDestiny);
					FillSectorMoveArgs(args);
					sector.OnMove(args);
				}
				
				UniverseSectorRenderer.Render(writer);
				WriteHtml();
			} catch (UIException e) {
				throw e;
			}
		}

		#endregion BattleMoveHandler Implementation

		#region Abstract

		public virtual void FillSectorMoveArgs(FleetSectorMoveArgs args){}

		#endregion Abstract
	}
}
