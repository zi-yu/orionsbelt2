 using System.IO;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore.Interfaces;
 using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class BattleRelicSectorInformation : SectorInformation {

		#region Fields

		private IFleetInfo f1;
		private IFleetInfo f2;
		private int battleId;

		#endregion Fields

		#region Properties

		public override bool IsFleetBattle {
			get { return true; }
		}

		public override int HeightVisibility {
			get { return 1; }
		}

		public override int WidthVisibility {
			get { return 1; }
		}

		public override string Representer {
			get {
				return "relicBattle";
			}
		}

		public override bool CanBeSeen {
			get { return !(Visibility is Discovered || Visibility is Undiscovered); }
		}

		#endregion Properties

		#region Public

		public override string ToJson() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", LanguageManager.Instance.Get("Battle"));
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",t:'{0}'", ShortType);

                writer.Write(",p1:'{0}'", f1.Owner.Name);
                writer.Write(",a1:'{0}'", GetAlliance(f1.Owner));
                writer.Write(",s1:'{0}'", GetState(f1.Owner));
                writer.Write(",aid1:{0}", GetAllianceId(f1.Owner));

                writer.Write(",p2:'{0}'", f2.Owner.Name);
                writer.Write(",a2:'{0}'", GetAlliance(f2.Owner));
                writer.Write(",s2:'{0}'", GetState(f2.Owner));
                writer.Write(",aid2:{0}", GetAllianceId(f2.Owner));

                writer.Write(",bId:{0}", battleId);

                writer.Write("}");

                return writer.ToString();
            }
		}

		#endregion Public

		#region Constructor

		public BattleRelicSectorInformation(ISector sector)
			: base(sector) {
			RelicBattleSector rbs = (RelicBattleSector)sector;
			f1 = (IFleetInfo)rbs.CelestialBodies[0];
			f2 = (IFleetInfo)rbs.CelestialBodies[1];
			battleId = rbs.BattleId;
		}

		#endregion Constructor

	}
}
