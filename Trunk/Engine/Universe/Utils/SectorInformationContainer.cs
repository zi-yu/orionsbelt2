using System.Collections.Generic;
using System.IO;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class SectorInformationContainer {

		#region Fields

		private readonly List<Coordinate> systemCoordinates = new List<Coordinate>();
        private readonly Dictionary<string, List<SectorInformation>> informationCollection = new Dictionary<string, List<SectorInformation>>();
		private readonly List<SectorInformation> ordered = new List<SectorInformation>();
		private readonly Dictionary<Coordinate,List<SectorInformation>> sectorInformationContainer = new Dictionary<Coordinate, List<SectorInformation>>();
		private static readonly SectorInformationComparer comparer = new SectorInformationComparer();
		private int level = 0;
		private SectorCoordinate startCoordinate = null;

		#endregion Fields

		#region Properties

		public SectorCoordinate StartCoordinate {
			get { return startCoordinate; }
			set { startCoordinate = value; }
		}

		public List<Coordinate> SystemCoordinates {
			get { return systemCoordinates; }
		}

		public List<SectorInformation> OrderedSectors {
			get { return ordered; }
		}

		public int Level {
			get { return level; }
			set { level = value; }
		}

		#endregion Properties

		#region Private

		private static string ToJson(ICollection<SectorInformation> list) {
			return ToJson(list, true);
		}

		private static string ToJson(ICollection<SectorInformation> list, bool useFirst) {
			if( list.Count == 0 ) {
				return string.Empty;
			}

			StringBuilder builder = new StringBuilder();
			bool first = useFirst;
			foreach (SectorInformation sector in list) {
				if ( sector.CanBeSeen ) {
					if( first ) {
						first = false;
						builder.Append(sector.ToJson());
					}else {
						builder.AppendFormat(",{0}",sector.ToJson());
					}
				}
			}
			return builder.ToString();
		}

		private static string ToJsonInvariant(ICollection<SectorInformation> list) {
			return ToJsonInvariant(list, true);
		}

		private static string ToJsonInvariant(ICollection<SectorInformation> list, bool useFirst) {
			if (list.Count == 0) {
				return string.Empty;
			}

			StringBuilder builder = new StringBuilder();
			bool first = useFirst;
			foreach (SectorInformation sector in list) {
				if (sector.Visibility is Undiscovered) {
					continue;
				}
				if (first) {
					first = false;
					builder.Append(sector.ToJson());
				} else {
					builder.AppendFormat(",{0}", sector.ToJson());
				}
			}
			return builder.ToString();
		}

		private void AddInformation(SectorInformation information) {
			if (!informationCollection.ContainsKey(information.Type)) {
				informationCollection.Add(information.Type, new List<SectorInformation>());
			}
			informationCollection[information.Type].Add(information);
		}

        private static string IsUltimateAvailable(IUltimateWeapon weapon) {
            bool available = weapon.IsReady(PlayerUtils.Current) && !PlayerUtils.Current.HasUltimateCooldown;
            return available.ToString().ToLower();
		}

		private static string HasLimits(IUltimateWeapon weapon) {
			return weapon.HasLimits.ToString().ToLower();
		}

		private string AvailableUltimateCoordinates(IUltimateWeapon weapon) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("[");
                foreach (SectorInformation info in OrderedSectors) {
                    if (info.Visibility is PlanetVisible) {
                        writer.Write("'{0}',", info.Coordinate.ToString().Replace(":", "_"));
                    }
                }
                writer.Write("'1']");
                return writer.ToString();
            }
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Adds a new object that represents the information of a sector to render
		/// </summary>
		/// <param name="information">Sector Information to add to the container</param>
		public void Add(SectorInformation information ) {
			if (!sectorInformationContainer.ContainsKey(information.Coordinate.System)) {
				sectorInformationContainer.Add(information.Coordinate.System, new List<SectorInformation>());
				systemCoordinates.Add(information.Coordinate.System);
			}

		    AddInformation(information);
            
			sectorInformationContainer[information.Coordinate.System].Add(information);
			OrderedSectors.Add(information);
		}
		
		internal SectorInformation Get(SectorCoordinate sectorCoordinate) {
			return ordered.Find(delegate(SectorInformation info) { return info.Coordinate.Equals(sectorCoordinate); });
		}

		public void SetAllVisible() {
			foreach (SectorInformation info in OrderedSectors) {
				info.Visibility = FleetVisible.Instance;
			}
		}

		public void SetAllFaded() {
			foreach (SectorInformation info in OrderedSectors) {
				info.Visibility = Discovered.Instance;
			}
		}

		public string CollectionToJson(string name, string type) {
			return CollectionToJson(name, type, false);
		}

		public string CollectionToJson(string name, string type, bool invariant) {
			if (informationCollection.ContainsKey(type)) {
				List<SectorInformation> collection = informationCollection[type];
				string json;
				if (invariant) {
					json = ToJsonInvariant(collection);
				} else {
					json = ToJson(collection);
				}

				if (!string.IsNullOrEmpty(json)) {
					return string.Format("var {0} = {{ {1} }};", name, json);
				}
			}
			return string.Format("var {0};", name);
		}

		public string CollectionToJson(string name, string[] types, bool invariant) {
            using (StringWriter json = new StringWriter()) {
                bool first = true;
                foreach (string type in types) {
                    if (informationCollection.ContainsKey(type)) {
                        List<SectorInformation> collection = informationCollection[type];
                        string s;
                        if (invariant) {
                            s = ToJsonInvariant(collection, first);
                        } else {
                            s = ToJson(collection, first);
                        }
                        if (!string.IsNullOrEmpty(s)) {
                            json.Write(s);
                            first = false;
                        }
                    }
                }

                string jsonStr = json.ToString();
                if (!string.IsNullOrEmpty(jsonStr)) {
                    return string.Format("var {0} = {{ {1} }};", name, jsonStr);
                }

                return string.Format("var {0};", name);
            }
		}

		/// <summary>
		/// Obtains a list of all informations related with the passed system
		/// </summary>
		/// <param name="systemCoordinate">Coordinate of the system</param>
		/// <returns>List of all informations related with the passed system</returns>
		public List<SectorInformation> GetSystemInformation(Coordinate systemCoordinate) {
			if (sectorInformationContainer.ContainsKey(systemCoordinate)) {
				return sectorInformationContainer[systemCoordinate];
			}
			throw new UIException("Coordinate '{0}' not found in SectorInformationContainer", systemCoordinate);
		}

		/// <summary>
		/// Sorts all the coordinates
		/// </summary>
		public void SortAll() {
			foreach (List<SectorInformation> infos in sectorInformationContainer.Values) {
				infos.Sort(comparer);
			}
		}

		public string FleetsToJson() {
            return CollectionToJson("fleets", "FleetSector");
		}

		public string PlanetsToJson() {
            return CollectionToJson("planets", "PlanetSector");
		}

		public string BattlesToJson() {
			return CollectionToJson("battles", new string[] { "FleetBattleSector", "PlanetBattleSector","RelicBattleSector" }, false);
		}

		public string MarketsToJson() {
			return CollectionToJson("markets", "MarketSector",true);
		}

        public string ArenasToJson(){
			return CollectionToJson("arenas", "ArenaSector", true);
        }

        public string WormholesToJson(){
			return CollectionToJson("wormHoles", new string[] { "WormHoleSector", "BugsWormHoleSector" }, false);
        }

		public string PrivateWormholesToJson() {
			return CollectionToJson("wormHoles", "PrivateWormHoleSector");
		}

		public string BeaconsToJson() {
			return CollectionToJson("beacons", "BeaconSector");
		}

		public string AcademiesToJson() {
			return CollectionToJson("academies", "AcademySector");
		}

		public string PirateBaysToJson() {
			return CollectionToJson("piratebays", "PirateBaySector");
		}

		public string RelicsToJson() {
            return CollectionToJson("relics", "RelicSector");
		}

		public string UltimateInfoToJson() {
            IUltimateWeapon weapon = UltimateWeaponChooser.GetUltimateWeapon(PlayerUtils.Current);
            using (StringWriter writer = new StringWriter()) {
                writer.Write("var ultimateInfo = {");
                writer.Write("r:{0}", IsUltimateAvailable(weapon));
                writer.Write(",lm:{0}", HasLimits(weapon));
                if (weapon.LimitedToPlanetsSurroundings) {
                    writer.Write(",uc:{0}", AvailableUltimateCoordinates(weapon));
                }
                writer.Write("};");
                return writer.ToString();
            }
		}

		#endregion Public


		
	}
}
