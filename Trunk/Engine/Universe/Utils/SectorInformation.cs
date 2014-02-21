 using System.Collections.Generic;
 using System.IO;
 using OrionsBelt.Engine.Alliances;
 using OrionsBelt.Engine.Resources;
 using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
 using OrionsBelt.RulesCore.Enum;
 using OrionsBelt.RulesCore.Interfaces;
 using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class SectorInformation {

		#region Fields

		protected SectorCoordinate coordinate;
		protected readonly ISector sector;
		protected UniverseVisibility visibility = Undiscovered.Instance;
		private readonly IResourceQuantity resource = null;
        protected static readonly string trueString = "true";
        protected static readonly string falseString = "false";

		#endregion Fields

		#region Properties

		public SectorCoordinate Coordinate {
			get { return coordinate; }
		}

		public string Type {
			get { return sector.Type; }
		}

		public string ShortType {
			get { return sector.DisplayTypeShort; }
		}

		public IPlayer Owner {
			get { return sector.Owner; }
		}

		public UniverseVisibility Visibility {
			get { return visibility; }
			set { visibility = value; }
		}

		public virtual bool IsFleet {
			get { return false; }
		}

		public virtual bool IsPlanet {
			get { return false; }
		}

		public virtual bool IsFleetBattle {
			get { return false; }
		}

		public virtual bool IsMarket {
			get { return false; }
		}

		public virtual bool IsWormHole {
			get { return false; }
		}

        public virtual bool IsArena {
            get { return false; }
		}

        public virtual bool IsRelic{
            get { return false; }
		}

		public virtual bool IsSpace {
			get { return SectorUtils.IsSpace(sector); }
		}

		public virtual bool IsUltimate {
			get { return false; }
		}

		public virtual int HeightVisibility {
			get { return 1; }
		}

		public virtual int WidthVisibility {
			get { return 1; }
		}		

		public virtual bool HasFogOfWar() {
			return HasFogOfWar(PlayerUtils.Current);
		}

		public virtual bool HasFogOfWar(IPlayer player) {
			bool ownerValid = IsOwner(player);

			if (sector is PlanetSector) {
				IPlanet planet = ((PlanetSector)sector).GetPlanet();
				if (planet != null && planet.Owner != null) {
					return ownerValid && planet.Owner.Id == player.Id;
				}
				return false;
			}

            return ownerValid && (sector is FleetSector || sector is RelicBattleSector || sector is RelicSector || sector is FleetBattleSector || sector is PlanetBattleSector || sector is BeaconSector || sector is BugsWormHoleSector);
		}

		public IResourceQuantity Resource {
			get { return resource; }
		}

		public bool HasResource {
			get { return resource != null; }
		}

		public int Level {
			get { return sector.Level; }
		}

		public virtual string Representer {
			get { return ShortType; }
		}

		public virtual bool CanBeSeen {
			get { return !(Visibility is Undiscovered); }
		}

		public virtual UniverseVisibility VisibleToken {
			get { return FleetVisible.Instance; }
		}

		public virtual string HtmlAttributes {
			get { return string.Empty; }
		}

		#endregion Properties

		#region Private

        protected static string ConvertToString(bool state){
            return state?trueString:falseString;
        }

		protected virtual string CanMove() {
			if (sector.Owner == null) {
                return falseString;
			}
            return ConvertToString(sector.Owner.Equals(PlayerUtils.Current));
		}

		protected string CanAttack() {
			if (sector.Owner == null) {
                return falseString;
			}
		    bool a = !sector.Owner.Equals(PlayerUtils.Current);
		    bool b = PlayerUtils.Current.Alliance == null || sector.Owner.Alliance == null || sector.Owner.Alliance.Storage.Id != PlayerUtils.Current.Alliance.Storage.Id;
    
			return ConvertToString(a && b); //&& não é da mesma aliança;
		}

		protected virtual string GetOwnerName() {
			if (Owner == null) {
				return string.Empty;
			}
            return PlayerUtils.WritePlayerWithAvatar(Owner, true);
		}

        protected virtual string GetOwnerSimpleName() {
			if (Owner == null) {
                return LanguageManager.Instance.Get("None");
			}
            return Owner.Name;
		}

		protected virtual string GetAlliance() {
			if (sector.Owner!= null && sector.Owner.Alliance != null) {
				string name = sector.Owner.Alliance.Storage.Name;
				if (name.Length > 20) {
					name = string.Format("{0}...", name.Substring(0, 17));
				}
				return name;
			}
			return string.Empty;
		}

		protected virtual int GetAllianceId() {
			if (sector.Owner != null && sector.Owner.Alliance != null) {
				return sector.Owner.Alliance.Storage.Id;
			}
			return 0;
		}

		protected virtual string GetState() {
			if (sector.Owner != null && PlayerUtils.Current.Alliance != null && sector.Owner.Alliance != null) {
				return AllianceManager.GetDiplomaticRelationLevelLazy(PlayerUtils.Current.Alliance, sector.Owner.Alliance).ToString().ToLower();
			}
			return string.Empty;
		}



		#endregion

		#region Protected

		protected static string GetAlliance(IPlayer owner) {
			if (owner.Alliance != null) {
				string name = owner.Alliance.Storage.Name;
				if (name.Length > 20) {
					name = string.Format("{0}...", name.Substring(0, 17));
				}
				return name;
			}
			return string.Empty;
		}

		protected static int GetAllianceId(IPlayer owner) {
			if (owner.Alliance != null) {
				return owner.Alliance.Storage.Id;
			}
			return 0;
		}

		protected static string GetState(IPlayer owner) {
			if (PlayerUtils.Current.Alliance != null && owner.Alliance != null) {
                if( owner.Principal.IsBot) {
                    return AllianceDiplomacyLevel.War.ToString().ToLower();
                }
				return AllianceManager.GetDiplomaticRelationLevelLazy(PlayerUtils.Current.Alliance, owner.Alliance).ToString().ToLower();
			}
			return string.Empty;
		}

		protected static string RenderCoordinateArray(SectorCoordinate coordinate) {
			List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(coordinate);
            using (StringWriter writer = new StringWriter()) {
                writer.Write("['{0}_{1}'", coordinates[0].System, coordinates[0].Sector);
                for (int i = 1; i < coordinates.Count; ++i) {
                    writer.Write(",'{0}_{1}'", coordinates[i].System, coordinates[i].Sector);
                }
                writer.Write("]");
                return writer.ToString();
            }
		}

		#endregion

		#region Public

		public string VisibilityToString() {
			return Visibility.ToString();
		}

		public override string ToString() {
			return string.Format("{0} {1}", Coordinate.System, Coordinate.Sector);
		}

		public virtual string ToJson() {
            return string.Format("'{0}_{1}':{{v:'{2}',t:'{3}',ca:false,cm:true}}", Coordinate.System, Coordinate.Sector, visibility, ShortType);
		}

		public bool IsOwner(IPlayer player) {
			return sector.IsOwner(player);
		}

		#endregion Public

		#region Constructor

		public SectorInformation(ISector sector) {
			this.sector = sector;
			coordinate = new SectorCoordinate(sector.SystemCoordinate, sector.SectorCoordinate);
			if( sector.HasResource ) {
				resource = sector.Resource;
			}
		}

		#endregion Constructor

	}
}
