using System.IO;
using System.Web;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic.Log;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Ajax {

	public class WormHoleMap : BaseHandler {

		#region BattleMoveHandler Implementation

		public override void Init() {
			type = LogType.FleetMovement;
		}

		public override void ProcessRequest(HttpContext cont) {
			context = cont;

			string system = context.Request.QueryString["system"];
			string sector = context.Request.QueryString["sector"];
			string isPrivate = context.Request.QueryString["isPrivate"];
			SectorCoordinate coordinate = new SectorCoordinate(ParseCoordinate(system),ParseCoordinate(sector));

			if( coordinate.System.IsPrivateSystem()) {
				UniversePersistance.AddPrivateWormHole(PlayerUtils.Current);
				Persistance.Flush();
			}else {
				if( isPrivate.Equals("false") ) {
					ISector s = UniversePersistance.GetSector(coordinate.System, coordinate.Sector);
					if( s != null ) {
						UniversePersistance.AddSpecialSector(PlayerUtils.Current, s, SpecialSectorType.Wormhole);
						Persistance.Flush();
					}
				}
			}
			
			UniverseWormHolesRenderer.Instance.Render(writer, coordinate);
			WriteHtml();
		}

		#endregion BattleMoveHandler Implementation
	}
}
