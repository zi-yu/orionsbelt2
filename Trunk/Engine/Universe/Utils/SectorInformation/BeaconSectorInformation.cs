 using System.IO;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore.Interfaces;
 using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class BeaconSectorInformation : SectorInformation{

		#region Fields

		private readonly int visibilityRange;
		private readonly UniverseVisibility beaconVisibility;

		#endregion Fields

		#region Properties

		public override bool IsUltimate {
			get { return true; }
		}

		public override int HeightVisibility {
			get { return visibilityRange; }
		}

		public override int WidthVisibility {
			get { return visibilityRange; }
		}

		public override bool CanBeSeen {
			get { return !(Visibility is Discovered || Visibility is Undiscovered); }
		}

		public override UniverseVisibility VisibleToken {
			get { return beaconVisibility; }
		}

		public override string HtmlAttributes {
			get { return string.Format(" isPrivate='true' "); }
		}

		#endregion Properties

		#region Public

		public override string ToJson() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", LanguageManager.Instance.Get("Beacon"));
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",t:'{0}'", ShortType);
                writer.Write(",ca:false,cm:true,ty:'w'");
                writer.Write(",o:'{0}'", GetOwnerName());
                writer.Write(",on:'{0}'", GetOwnerSimpleName());
                writer.Write(",a:'{0}'", GetAlliance(Owner));
                writer.Write(",s:'{0}'", GetState(Owner));
                writer.Write(",aid:{0}", GetAllianceId(Owner));
                writer.Write("}");
                return writer.ToString();
            }
		}

		#endregion Public

		#region Constructor

		public BeaconSectorInformation(ISector sector, IPlayer player)
			: base(sector) {
			BeaconSector bs = (BeaconSector)sector;
			visibilityRange = bs.VisibleArea;

			if (player != null && sector.Owner.Id == player.Id) {
				beaconVisibility = new BeaconVisible(bs.UltimateLevel, Owner);
			} else {
				beaconVisibility = new OtherBeaconVisible(bs.UltimateLevel, Owner);
			}
		}

		#endregion Constructor

	}
}
