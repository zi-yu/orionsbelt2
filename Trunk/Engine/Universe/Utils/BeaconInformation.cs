
using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	public static class BeaconInformation {

		#region Fields

		private delegate string Json(SectorInformation info);
		private static readonly Dictionary<int, Json> delegates = new Dictionary<int, Json>();
		private static readonly List<UnitCategory> lights = new List<UnitCategory>();
		private static readonly List<UnitCategory> mediums = new List<UnitCategory>();
		private static readonly List<UnitCategory> heavies = new List<UnitCategory>();

		#endregion Fields

		#region Delegates

		private static string Level0(SectorInformation info) {
			return string.Empty;
		}

		private static string Level1(SectorInformation info) {
			return GetUnitQuantity(info, UnitCategory.Light, "lq");
		}

		private static string Level2(SectorInformation info) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write(Level1(info));
                writer.Write(GetUnitQuantity(info, UnitCategory.Medium, "mq"));
                return writer.ToString();
            }
		}

		private static string Level3(SectorInformation info) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write(Level2(info));
                writer.Write(GetUnitQuantity(info, UnitCategory.Heavy, "hq"));
                return writer.ToString();
            }
		}

		private static string Level4(SectorInformation info) {
			IFleetInfo fleet = ((FleetSectorInformation)info).Fleet;

            using (StringWriter writer = new StringWriter()) {
                writer.Write(GetUnitQuantity(info, UnitCategory.Medium, "mq"));
                writer.Write(GetUnitQuantity(info, UnitCategory.Heavy, "hq"));
                writer.Write(GetUnitsJson(fleet, lights));

                return writer.ToString();
            }
		}

		private static string Level5(SectorInformation info) {
			IFleetInfo fleet = ((FleetSectorInformation)info).Fleet;

            using (StringWriter writer = new StringWriter()) {
                writer.Write(GetUnitQuantity(info, UnitCategory.Heavy, "hq"));
                writer.Write(GetUnitsJson(fleet, mediums));

                return writer.ToString();
            }
		}

		private static string Level6(SectorInformation info) {
			IFleetInfo fleet = ((FleetSectorInformation)info).Fleet;

            return GetUnitsJson(fleet, heavies);
		}

		private static string Level7(SectorInformation info) {
			if( info is FleetSectorInformation ) {
				return Level6(info);
			}
			PlanetSectorInformation planetSectorInformation = (PlanetSectorInformation)info;
			IPlanet planet = planetSectorInformation.Planet;
            return GetPlanetFacilities(planet);
		}

		private static string Level8(SectorInformation info) {
			if (info is FleetSectorInformation) {
				return Level6(info);
			}
			PlanetSectorInformation planetSectorInformation = (PlanetSectorInformation)info;
			IPlanet planet = planetSectorInformation.Planet;
            using (StringWriter writer = new StringWriter()) {

                writer.Write(GetPlanetFacilities(planet));
                writer.Write(GetPlanetIncome(planet));

                return writer.ToString();
            }
		}

		private static string Level9(SectorInformation info) {
			if (info is FleetSectorInformation) {
				return Level6(info);
			}

			PlanetSectorInformation planetSectorInformation = (PlanetSectorInformation)info;
			IPlanet planet = planetSectorInformation.Planet;
            using (StringWriter writer = new StringWriter()) {

                writer.Write(GetPlanetFacilities(planet));
                writer.Write(GetPlanetIncome(planet));
                writer.Write(GetUnitsJson(planet.DefenseFleet, heavies));

                return writer.ToString();
            }
		}

		private static string Level10(SectorInformation info) {
			if (info is FleetSectorInformation) {
				return Level6(info);
			}
            return Level9(info);
		}

		#endregion Delegates

		#region Private

		private static string GetBeaconJson(FleetSectorInformation info, BeaconVisible visibility) {
			if( visibility.Level > 6 ) {
				return delegates[6](info);
			}
			return delegates[visibility.Level](info);
		}

		private static string GetBeaconJson(PlanetSectorInformation info, BeaconVisible visibility) {
			if (visibility.Level > 6) {
				return delegates[visibility.Level](info);
			}
			return string.Empty;
		}

		private static string GetUnitQuantity(SectorInformation info, UnitCategory category, string tag) {
			IFleetInfo fleet = ((FleetSectorInformation)info).Fleet;
			int total = GetUnitQuantityByCategory(fleet, category);
			return string.Format(",{0}:{1}", tag, total);
		}

		/// <summary>
		/// number of units by category
		/// </summary>
		private static int GetUnitQuantityByCategory(IFleetInfo fleet, UnitCategory category) {
			int total = 0;
			foreach (IFleetElement unit in fleet.Units.Values) {
				if (unit.UnitInfo.UnitCategory == category) {
					total += unit.Quantity;
				}
			}
			return total;
		}

		/// <summary>
		/// number of units by category
		/// </summary>
		private static string GetUnitsJson(IFleetInfo fleet, List<UnitCategory> categories) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("[");
                foreach (IFleetElement unit in fleet.Units.Values) {
                    if (categories.Contains(unit.UnitInfo.UnitCategory)) {
                        writer.Write("{{ n:'{0}',q:{1} }},", unit.Name, unit.Quantity);
                    }
                }
                writer.Write("{n:'ignore'}]");
                return string.Format(",u:{0}", writer);
            }
		}

		private static string GetPlanetFacilities(IPlanet planet) {
            return string.Format(",f:{0}", planet.FacilityLevel);
		}

		private static string GetPlanetIncome(IPlanet planet) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("[");
                foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(planet.Owner)) {
                    int perTick = planet.GetPerTick(info);
                    if (perTick != 0) {
                        writer.Write("{{ n:'{0}',q:{1} }},", info.Name, perTick);
                    }
                }
                writer.Write("{n:'ignore'}]");
                return string.Format(",i:{0}", writer);
            }
		}

		#endregion Private
		
		#region Public

		public static string GetBeaconJson(FleetSectorInformation info) {
			if( info.Visibility is BeaconVisible ) {
				return GetBeaconJson(info, info.Visibility as BeaconVisible);
			}

			return string.Empty;
		}

		public static string GetBeaconJson(PlanetSectorInformation info) {
			if( info.Owner.Id == PlayerUtils.Current.Id ) {
				return Level9(info);
			}

			if (info.Visibility is BeaconVisible ) {
				return GetBeaconJson(info, info.Visibility as BeaconVisible);
			}

			return string.Empty;
		}

		#endregion Public
		
		#region Constructor

		static BeaconInformation() {
			delegates[0] = Level0;
			delegates[1] = Level1;
			delegates[2] = Level2;
			delegates[3] = Level3;
			delegates[4] = Level4;
			delegates[5] = Level5;
			delegates[6] = Level6;
			delegates[7] = Level7;
			delegates[8] = Level8;
			delegates[9] = Level9;
			delegates[10] = Level10;

			lights.Add(UnitCategory.Light);
			
			mediums.Add(UnitCategory.Light);
			mediums.Add(UnitCategory.Medium);

			heavies.Add(UnitCategory.Light);
			heavies.Add(UnitCategory.Medium);
			heavies.Add(UnitCategory.Heavy);
		}

		#endregion Constructor

	}
}
