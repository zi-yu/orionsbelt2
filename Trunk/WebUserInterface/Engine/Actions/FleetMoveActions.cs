using System.IO;
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System.Web;

namespace OrionsBelt.WebUserInterface.Engine {
	
	public class FleetMoveActions : ActionBase {

		#region Private

		private void Write(object text) {
            HttpContext.Current.Response.Write(text);
		}

        private void RenderUniverse(SectorCoordinate coordinate) {
            //StringWriter writer = new StringWriter();
            //UniverseSectorRenderer.AjaxRender(writer, coordinate);
			//Write(writer.ToString());
		}

		private SectorCoordinate GetSectorCoordinate(string systemKey, string sectorKey) {
            string systemSrc = HttpContext.Current.Request.QueryString[systemKey];
            string sectorSrc = HttpContext.Current.Request.QueryString[sectorKey];
			Coordinate systemSource = ParseCoordinate(systemSrc);
			Coordinate sectorSource = ParseCoordinate(sectorSrc);
			return new SectorCoordinate(systemSource, sectorSource);
		}

		private static FleetSectorMoveArgs GetSectorMoveArgs(SectorCoordinate source, SectorCoordinate destiny, bool attackWhenArrive, bool conquerWhenArrive, bool pursuit) {
			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = source;
			args.Destiny = destiny;
			args.AttackWhenArrive = attackWhenArrive;
			args.ConquerWhenArrive = conquerWhenArrive;
			args.Pursuit = pursuit;
			return args;
		}

        private static bool HasUnits(ISector sector) {
            return sector.GetBattleFleet().HasUnits;
        }

        private static bool IsSectorValid(ISector sector) {
            return sector != null && sector is FleetSector && sector.Owner.Equals(PlayerUtils.Current) && HasUnits(sector);
        }

	    #endregion Private

		#region Delegates

		private void CoordinateValid() {
			bool buyNoUndiscoveredUniverse = PlayerUtils.Current.HasService(ServiceType.BuyNoUndiscoveredUniverse);
			if( buyNoUndiscoveredUniverse) {
				Write(true);
			}else{
				SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
				bool result = SectorUtils.CoordinateDiscovered(destiny);
				Write(result);
			}
		}

		private void MoveFleet() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

            if ( IsSectorValid(sector) ) {
				FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, false, false, false);
				sector.OnMove(args);
			}
		}

	   

	    private void MoveFleetAndUnload() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

            if ( IsSectorValid(sector) ) {
				FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, false, false, false);
				args.UnloadCargo = true;
				sector.OnMove(args);
			}
		}

		private void MoveFleetToUndiscovered() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

            if (IsSectorValid(sector) ) {
				FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, false, false, false);
				args.TotalTicksToMove = 4;
				args.TicksToMove = 1;
				sector.OnMove(args);
			}
		}
	

		private void AttackFleet() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

            if ( IsSectorValid(sector) ) {
				FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, true, false, false);
				sector.OnMove(args);
			}
		}

		private void AttackPlanet() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

            if ( IsSectorValid(sector) ) {
				FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, true, true, false);
				sector.OnMove(args);
			}
		}

		private void ConquerPlanet() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

			if ( IsSectorValid(sector) ) {
				FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, false, true, false);
				sector.OnMove(args);
			}
		}

		private void RaidPlanet() {
			AttackFleet();
		}

		private void PursuitAndAttackFleet() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

			if (IsSectorValid(sector)) {
				FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, true, false, true);
				args.FleetToPursuitId = ConvertToInt("FleetId");
				sector.OnMove(args);
			}
		}

		private void TransportFleet() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

            string wormHoleSystemSrc = HttpContext.Current.Request.QueryString["wormHoleSystemSrc"];
            Coordinate wormHoleSystemDestiny = ParseCoordinate(wormHoleSystemSrc);
			SectorCoordinate wormHole = UniversePersistance.GetWormHoleCoordinate(PlayerUtils.Current, wormHoleSystemDestiny);
            if (wormHole == null) {
                string wormHoleSectorSrc = HttpContext.Current.Request.QueryString["wormHoleSectorSrc"];
                wormHole = new SectorCoordinate(string.Format("{0}_{1}", wormHoleSystemSrc, wormHoleSectorSrc));
            }

		    if (IsSectorValid(sector)) {
				FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, false, false, false);
				args.Teletransporting = true;
				args.WormHoleCoordinate = wormHole;
				sector.OnMove(args);
			}
		}

		private void CancelMoveFleet() {
			int fleetId = ConvertToInt("fleetId");
			IFleetInfo fleet = FleetPersistance.GetFleet(fleetId);
			FleetSector sector = (FleetSector)fleet.Sector;
		    CheckUltimateWeapon(sector);
			sector.IsMoving = false;
			GameEngine.Persist(sector);

			Messenger.Add(new CancelFleetMovementMessage(PlayerUtils.Current.Id, sector.GetBattleFleet().Name));
		}

        private void CheckUltimateWeapon(FleetSector sector){
			if (sector.FleetSectorMoveArgs != null && sector.FleetSectorMoveArgs.UseUltimateWeapon) {
				IUltimateWeapon weapon = UltimateWeaponChooser.GetUltimateWeapon(PlayerUtils.Current);
				WormHoleCreatorArgs args = new WormHoleCreatorArgs(PlayerUtils.Current, SectorCoordinate.Dummy);
				weapon.RefundUsage(args);
				GameEngine.Persist(PlayerUtils.Current,false,true);
        		Write(PlayerUtils.Current.GetResourcesInJson());
            }
        }

		private void UseUltimateWeapon() {
			SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
			ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);
            IUltimateWeapon weapon = UltimateWeaponChooser.GetUltimateWeapon(PlayerUtils.Current);
            if( weapon == null || !weapon.IsReady(PlayerUtils.Current) ){
                Write("UltimateWeaponNotReady");
                return;
            }

            if (sector != null && sector is FleetSector && sector.Owner.Equals(PlayerUtils.Current)) {
                WormHoleCreatorArgs args = new WormHoleCreatorArgs(PlayerUtils.Current,destiny);
                weapon.ChargeUsage(args);

				FleetSectorMoveArgs fargs = GetSectorMoveArgs(source, destiny, false, false, false);
				fargs.UseUltimateWeapon = true;
				sector.OnMove(fargs);
                GameEngine.Persist(PlayerUtils.Current,false,true);
			}
		}

		private void UseDevastation() {
			SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
		    IPlayer player = PlayerUtils.Current;
			DevastationCreatorBase weapon = UltimateWeaponChooser.GetUltimateWeapon(player) as DevastationCreatorBase;
            if (weapon != null && weapon.IsReady(player) && player.UltimateWeaponCooldown == 0){
                DevastationCreatorArgs args = new DevastationCreatorArgs(player, destiny);
                weapon.ChargeUsage(args);
                weapon.CreateDevastationAction(player, destiny);
                player.UltimateWeaponCooldown = weapon.Cooldown+weapon.Duration;
                GameEngine.Persist(PlayerUtils.Current, false, true);
			}else{
                Write("DevastationCannotBeUsed");
            }
		}

		private void ArenaChallenge() {
            SectorCoordinate source = GetSectorCoordinate("systemSrc", "sectorSrc");
            SectorCoordinate destiny = GetSectorCoordinate("systemDst", "sectorDst");
            ISector sector = UniversePersistance.GetSector(PlayerUtils.Current, source.System, source.Sector);

            if (IsSectorValid(sector)){
                FleetSectorMoveArgs args = GetSectorMoveArgs(source, destiny, false, false, false);
                args.ChallengeWhenArrive = true;
                sector.OnMove(args);
            }
		}

		private void AttackRelic() {
			AttackPlanet();
		}

		private void ConquerRelic() {
			ConquerPlanet();
		}

		#endregion Delegates

		#region Constructor

		public FleetMoveActions() {
			actions["move"] = MoveFleet;
			actions["moveundiscovered"] = MoveFleetToUndiscovered;
			actions["coordValid"] = CoordinateValid;
			actions["attack"] = AttackFleet;
			actions["pursuitandattack"] = PursuitAndAttackFleet;
			actions["cancelmove"] = CancelMoveFleet;
			actions["conquer"] = ConquerPlanet;
			actions["attackPlanet"] = AttackPlanet;
			actions["raidPlanet"] = RaidPlanet;
			actions["transport"] = TransportFleet;
			actions["useUltimate"] = UseUltimateWeapon;
			actions["fireDevastation"] = UseDevastation;
			actions["arenaChallenge"] = ArenaChallenge;
			actions["moveAndUnload"] = MoveFleetAndUnload;
			actions["attackRelic"] = AttackRelic;
			actions["conquerRelic"] = ConquerRelic;
		}


		#endregion Constructor

	
	}
}
