 using System.IO;
 using OrionsBelt.Engine.Alliances;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore.Interfaces;
 using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class PlanetSectorInformation : SectorInformation{

		#region Fields

		private readonly IPlanet planet;

		#endregion Fields

		#region Properties

		public override bool IsPlanet {
			get { return true; }
		}

		public override int HeightVisibility {
			get { return 2; }
		}

		public override int WidthVisibility {
			get { return 2; }
		}

        public bool HasPlanet {
            get { return Planet != null; }
        }

        public bool HasPlanetAndOwner {
            get { return HasPlanet && Planet.Owner != null; }
        }

		private bool IsPlanetVisible {
			get { return !(Visibility is Discovered || Visibility is Undiscovered); }
		}

		public override string Representer {
			get {
                using (StringWriter writer = new StringWriter()) {
                    if (sector.Coordinate.System.IsPrivateSystem()) {
                        writer.Write("p");
                    }
                    writer.Write(((PlanetSector)sector).GetTerrainInfo().Terrain.ToString().ToLower());
                    if (Planet != null && Planet.Owner != null && IsPlanetVisible) {
                        writer.Write(Planet.Owner.RaceInfo.Race);
                        writer.Write(Planet.GetPlanetLevel());
                    }
                    return writer.ToString();
                }
			}
		}

		public override UniverseVisibility VisibleToken {
			get { return PlanetVisible.Instance; }
		}

		public IPlanet Planet {
			get { return planet; }
		}

		#endregion Properties

		#region Private

        private string GetPlanetName() {
            if (HasPlanetAndOwner) {
                return Planet.Name;
            }
            return LanguageManager.Instance.Get("VirginPlanet");
        }

		protected override string CanMove() {
			if (HasPlanet && Planet.Owner != null) {
				return (planet.Owner.Id == PlayerUtils.Current.Id).ToString().ToLowerInvariant();
			}
			
			return falseString;
		}

		protected string CanConquer() {
			if (HasPlanetAndOwner) {
                return falseString;
			}
            return trueString;
		}

        protected string CanWatch(){
            if (HasPlanetAndOwner && Planet.Owner == PlayerUtils.Current){
                return trueString;
            }
            return falseString;
        }

		protected override string GetAlliance() {
			if (HasPlanetAndOwner && Planet.Owner.Alliance != null) {
				string name = Planet.Owner.Alliance.Storage.Name;
				if (name.Length > 20) {
					name = string.Format("{0}...", name.Substring(0, 17));
				}
				return name;
			}
			return string.Empty;
		}

		protected override int GetAllianceId() {
			if (HasPlanetAndOwner && Planet.Owner.Alliance != null) {
				return Planet.Owner.Alliance.Storage.Id;
			}
			return 0;
		}

		protected override string GetState() {
			if (HasPlanetAndOwner && PlayerUtils.Current.Alliance != null && Planet.Owner.Alliance != null) {
				return AllianceManager.GetDiplomaticRelationLevelLazy(PlayerUtils.Current.Alliance, Planet.Owner.Alliance).ToString().ToLower();
			}
			return string.Empty;
		}

        private string GetRace(){
            if (planet != null && planet.Owner != null){
                return planet.Owner.RaceInfo.Race.ToString();
            }
            return string.Empty;
        }

		#endregion Private

		#region Public

		public override string ToJson() {
		    int id = 0;
            if( HasPlanet && Planet.Storage != null ){
                id = Planet.Storage.Id;
            }

            using (StringWriter writer = new StringWriter()) {

                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", GetPlanetName());
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",t:'{0}'", ShortType);
                writer.Write(",cm:{0}", CanMove());
                writer.Write(",ca:{0}", CanAttack());
                writer.Write(",cw:{0}", CanWatch());
                writer.Write(",cc:{0}", CanConquer());
                writer.Write(",o:'{0}'", GetOwnerName());
                writer.Write(",on:'{0}'", GetOwnerSimpleName());
                writer.Write(",id:{0}", id);
                writer.Write(",p:{0}", ConvertToString(Coordinate.System.IsPrivateSystem()));
                writer.Write(",l:{0}", sector.Level);
                writer.Write(",pt:'{0}'", ((PlanetSector)sector).GetTerrainInfo().Terrain);
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",ty:'p'");
                if (Owner != null) {
                    writer.Write(",uty:'p{0}'", Owner.RaceInfo.Race);
                }
                writer.Write(",a:'{0}'", GetAlliance());
                writer.Write(",s:'{0}'", GetState());
                writer.Write(",aid:{0}", GetAllianceId());
                writer.Write(",r:'{0}'", GetRace());
                if (ShowMoreInformation) {
                    writer.Write(BeaconInformation.GetBeaconJson(this));
                }
                writer.Write("}");
                return writer.ToString();
            }
		}

		private bool ShowMoreInformation {
			get {
				if( planet == null || planet.Owner == null ) {
					return false;
				}
					
				if( planet.Owner.Id == PlayerUtils.Current.Id) {
					return true;
				}

				BeaconVisible beaconVisible = Visibility as BeaconVisible;
				if (beaconVisible == null ) {
					return false;
				}

				return beaconVisible.Owner.Id == PlayerUtils.Current.Id;
			}
		}

		#endregion Public

		#region Constructor

		public PlanetSectorInformation(ISector sector)
			: base(sector) {
			planet = sector.GetPlanet();
		}

		#endregion Constructor

	}
}
