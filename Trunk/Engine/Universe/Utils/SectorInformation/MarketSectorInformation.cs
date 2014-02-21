 using System.IO;
 using OrionsBelt.Engine.MarketPlace;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine.Universe {
	public class MarketSectorInformation : SectorInformation{

		#region Properties

		public override bool IsMarket {
			get { return true; }
		}

		#endregion Properties

		#region Protected

		#endregion Protected

		#region Public

		public override string ToJson() {
			MarketSector market = (MarketSector) sector;

            using (StringWriter writer = new StringWriter()) {
                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", market.Storage.Markets[0].Name);
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",a:{0}", RenderCoordinateArray(sector.Coordinate));
                writer.Write(",id:{0}", market.MarketId);
                writer.Write(",t:'{0}'", ShortType);
                writer.Write(",ty:'m'");
                writer.Write(",uty:'m'");
                writer.Write(",l:'{0}'", sector.Level);

                IIntrinsicInfo info = MarketUtil.GetTradeResource(sector.Coordinate, sector.Level);
                if (info != null) {
                    writer.Write(",r:'{0}'", info.Name);
                }

                writer.Write("}");

                return writer.ToString();
            }
		}

		

		#endregion Public

		#region Constructor

		public MarketSectorInformation(ISector sector)
			: base(sector) {
		}

		#endregion Constructor

	}
}
