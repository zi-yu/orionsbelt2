 using System.IO;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore.Interfaces;
 using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class PirateBaySectorInformation : SectorInformation{

		#region Properties

		public override bool IsWormHole {
			get { return true; }
		}

		public override string HtmlAttributes {
			get { return string.Format(" isPrivate='false' "); }
		}

		#endregion Properties

		#region Public

		public override string ToJson() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", LanguageManager.Instance.Get("PirateBay"));
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",t:'{0}'", ShortType);
                writer.Write(",a:{0}", RenderCoordinateArray(sector.Coordinate));
                writer.Write(",l:{0}", sector.Level);
                writer.Write(",ca:false,cm:true,ty:'pb'}");
                return writer.ToString();
            }
		}

		#endregion Public

		#region Constructor

		public PirateBaySectorInformation(ISector sector)
			: base(sector) {
		}

		#endregion Constructor

	}
}
