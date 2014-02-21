 using System.IO;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore.Interfaces;
 using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class WormHoleSectorInformation : SectorInformation{

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
                writer.Write("n:'{0}'", LanguageManager.Instance.Get("WormHole"));
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",t:'{0}'", ShortType);
                writer.Write(",ca:false");
                writer.Write(",cm:true");
                writer.Write(",ty:'w'");
                writer.Write(",uty:'w'");
                writer.Write("}");
                return writer.ToString();
            }
		}

		#endregion Public

		#region Constructor

		public WormHoleSectorInformation(ISector sector)
			: base(sector) {
		}

		#endregion Constructor

	}
}
