 using System.IO;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore.Interfaces;
 using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class BattlePlanetSectorInformation : SectorInformation{

		#region Fields

		private readonly IPlanet planet;
		private readonly IFleetInfo fleet;
		private readonly int battleId;

		#endregion Fields

		#region Properties

		public override int HeightVisibility {
			get { return 1; }
		}

		public override int WidthVisibility {
			get { return 1; }
		}

		public override string Representer {
			get {
				string terrain = planet.Terrain.Terrain.ToString().ToLower();
				string planetRace = planet.Owner.RaceInfo.Race.ToString();
				string fleetRace = fleet.Owner.RaceInfo.Race.ToString();
				return string.Format("{0}{1}{2}", terrain, planetRace, fleetRace);
			}
		}

		public override bool IsFleetBattle {
			get { return true; }
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

                writer.Write(",p1:'{0}'", planet.Owner.Name);
                writer.Write(",a1:'{0}'", GetAlliance(planet.Owner));
                writer.Write(",s1:'{0}'", GetState(planet.Owner));
                writer.Write(",aid1:{0}", GetAllianceId(planet.Owner));

                writer.Write(",p2:'{0}'", fleet.Owner.Name);
                writer.Write(",a2:'{0}'", GetAlliance(fleet.Owner));
                writer.Write(",s2:'{0}'", GetState(fleet.Owner));
                writer.Write(",aid2:{0}", GetAllianceId(fleet.Owner));

                writer.Write(",bId:{0}", battleId);

                writer.Write("}");

                return writer.ToString();
            }
		}

		#endregion Public

		#region Constructor

		public BattlePlanetSectorInformation(ISector sector)
			: base(sector) {
			PlanetBattleSector pbs = (PlanetBattleSector)sector;
			
			planet = pbs.GetPlanet();
			fleet = pbs.GetEnemyFleet();

			battleId = pbs.BattleId;
		}

		#endregion Constructor

	}
}
