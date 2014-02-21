 using System.Collections.Generic;
 using System.IO;
 using OrionsBelt.Engine.Alliances;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore;
 using OrionsBelt.RulesCore.Enum;
 using OrionsBelt.RulesCore.Interfaces;

 namespace OrionsBelt.Engine.Universe {
	public class FleetSectorInformation : SectorInformation{

		#region Fields

		private readonly int visibilityRange;
		private readonly IFleetInfo fleet; 

		#endregion Fields

		#region Properties

		public override bool IsFleet {
			get { return true; }
		}

		public override int HeightVisibility {
			get { return visibilityRange; }
		}

		public override int WidthVisibility {
			get { return visibilityRange; }
		}

		public override string Representer {
			get {
				if( Fleet.HasUltimateUnit ) {
					return string.Format("ultimate{0}{1}", Fleet.UltimateUnit.Name, GetAllianceRelation());
				}
				return string.Format("fleet{0}{1}", Fleet.Owner.RaceInfo.Race, GetAllianceRelation());
			}
		}

		public override bool CanBeSeen {
			get { return !(Visibility is Discovered || Visibility is Undiscovered); ; }
		}

		public override UniverseVisibility VisibleToken {
			get { return FleetVisible.Instance; }
		}

		public IFleetInfo Fleet {
			get { return fleet; }
		}

		#endregion Properties

		#region Private

		private string GetAllianceRelation() {
			IPlayer owner = Fleet.Owner;
			if( PlayerUtils.Current.Id == owner.Id ) {
				return "1";
			}

			if (PlayerUtils.Current.Alliance != null && owner.Alliance != null) {
				AllianceDiplomacyLevel level = AllianceManager.GetDiplomaticRelationLevelLazy(PlayerUtils.Current.Alliance, owner.Alliance);
				return MapLevel(level);

			}
			return "5";
		}

		private static string MapLevel(AllianceDiplomacyLevel level) {
			switch(level) {
				case AllianceDiplomacyLevel.SameAlliance:
					return "1";
				case AllianceDiplomacyLevel.Confederation:
					return "2";
				case AllianceDiplomacyLevel.NonAgressionPact:
					return "3";
				case AllianceDiplomacyLevel.War:
					return "4";
				default:
					return "5";
			}
		}

		#endregion private

		#region Protected

		protected override string CanMove() {
			if (!Fleet.HasUnits) {
				return falseString;
			}

			return base.CanMove();
		}

		protected string HasUnits() {
			return Fleet.HasUnits ? trueString : falseString;
		}

        protected string GetUnits() {
            if (Fleet.Owner.Equals(PlayerUtils.Current)){
                using (StringWriter writer = new StringWriter()) {
                    writer.Write("[");
                    foreach (IFleetElement unit in Fleet.Units.Values) {
                        writer.Write("{{ n:'{0}',q:{1} }},", unit.Name, unit.Quantity);
                    }
                    writer.Write("{n:'ignore'}]");
                    return writer.ToString();
                }
            }
            return "[]";
        }

		#endregion Protected

		#region Public

		public override string ToJson() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", Fleet.Name);
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",m:{0}", ConvertToString(sector.IsMoving));
                writer.Write(",t:'{0}'", ShortType);
                writer.Write(",o:'{0}'", GetOwnerName());
                writer.Write(",on:'{0}'", GetOwnerSimpleName());
                writer.Write(",ca:{0}", CanAttack());
                writer.Write(",cm:{0}", CanMove());
                writer.Write(",id:'{0}'", Fleet.Id);
                writer.Write(",hu:{0}", HasUnits());
                writer.Write(",a:'{0}'", GetAlliance(Fleet.Owner));
                writer.Write(",s:'{0}'", GetState(Fleet.Owner));
                writer.Write(",aid:{0}", GetAllianceId(Fleet.Owner));
                writer.Write(",ty:'f'");
                writer.Write(",uty:'f{0}'", Owner.RaceInfo.Race);
                writer.Write(",cpw:{0}", ConvertToString(Fleet.CanPassWormHoles));
                FleetSector fs = (FleetSector)sector;
                if (fs.IsMoving) {
                    writer.Write(",ttm:{0}", fs.FleetSectorMoveArgs.TicksToMove);
                    writer.Write(",tttm:{0}", fs.FleetSectorMoveArgs.TotalTicksToMove);
                    writer.Write(",d:'{0}'", fs.FleetSectorMoveArgs.Destiny);
                } else {
                    writer.Write(",d:''");
                }

                WriteCargo(writer);
                WriteUnitInfo(writer);

                writer.Write("}");

                return writer.ToString();
            }
		}

		private void WriteUnitInfo(StringWriter writer) {
			if (Fleet.Owner.Equals(PlayerUtils.Current)) {
				writer.Write(",u:{0}", GetUnits());	
			}else {
				if( Visibility is BeaconVisible ) {
					writer.Write(BeaconInformation.GetBeaconJson(this));
				}
			}
		}

		private void WriteCargo(StringWriter writer) {
			if (Fleet.Owner.Equals(PlayerUtils.Current)) {
				writer.Write(GetFleetCargo());
			}
		}

		private string GetFleetCargo() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("[");
                if (fleet.Cargo != null) {
                    foreach (KeyValuePair<IResourceInfo, int> pair in fleet.Cargo) {
                        writer.Write("{{ n:'{0}',q:{1} }},", pair.Key.Name, pair.Value);
                    }
                }
                writer.Write("{n:'ignore'}]");
                return string.Format(",i:{0}", writer);
            }
		}
		
        #endregion Public

		#region Constructor

		public FleetSectorInformation(ISector sector)
			: base(sector) {
			FleetSector fs = (FleetSector)sector;
			fleet = fs.GetBattleFleet();
			visibilityRange = Fleet.VisibilityRange;
		}

		#endregion Constructor

	}
}
