using System;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Common;
using OrionsBelt.WebComponents;
using Loki.Generic;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Battle Timeout
    /// </summary>
    public class FleetMovement : AutoRepeteAction {

		#region Fields

		private static Random random = new Random(DateTime.Now.Millisecond);

		#endregion Fields

		#region Ctor

		public FleetMovement()
        {
			Start(1);
		}

        #endregion Ctor 

		#region Private

		/// <summary>
		/// If a coordinate is to far from the other
		/// </summary>
		/// <param name="fleetLocation"></param>
		/// <param name="targetLocation"></param>
		/// <returns></returns>
		private static bool IsFar(SectorCoordinate fleetLocation, SectorCoordinate targetLocation) {
			int x = Math.Abs(fleetLocation.System.X - targetLocation.System.X);
			int y = Math.Abs(fleetLocation.System.Y - targetLocation.System.Y);
			return (x + y) > 2;
		}

		/// <summary>
		/// Sets the pursuit destiny coordinate of the current fleet
		/// </summary>
		/// <param name="pursuitFleet"></param>
		/// <param name="fleets"></param>
		private static SectorCoordinate GetPursuitedFleetLocation(FleetSector pursuitFleet, List<FleetSector> fleets) {
			FleetSector fleet = fleets.Find(
				delegate(FleetSector s) {
					return s.GetBattleFleet().Id == pursuitFleet.FleetSectorMoveArgs.FleetToPursuitId;
			    }
			);
			
			if( fleet != null ) {
				return fleet.Coordinate;
			}

			IFleetInfo fleetInfo = FleetPersistance.GetFleet(pursuitFleet.FleetSectorMoveArgs.FleetToPursuitId);
			if (fleetInfo == null) {
                //throw new EngineException("Fleet with id '{0}' should exist at SetPursuit. Check if Fleet Move Args is correct.", pursuitFleet.FleetSectorMoveArgs.FleetToPursuitId);
                return null;
			}
			return fleetInfo.Location;
		}


		private static void MoveNonPursuitFleets(List<FleetSector> fleets) {
			List<FleetSector> nonPursuitFleets = fleets.FindAll(delegate(FleetSector s) { return s.FleetSectorMoveArgs!= null && !s.FleetSectorMoveArgs.Pursuit; });
            NHibernateUtilities.Statistics.Clear();
			foreach (FleetSector fleet in nonPursuitFleets) {
                try{
                    ISector sector = Universe.Universe.GetSector(fleet.Coordinate);
                    if (fleet.Coordinate.System.IsPrivateSystem() || (!sector.IsInBattle && sector is FleetSector)) {
                        fleet.Turn();
                    }
                    //ShowStats();
                }catch(Exception e) {
                    ExceptionLogger.Log(e);
                    try {
                        SendMail.Send("business@orionsbelt.eu", "business@orionsbelt.eu", "FleetError", e.Message + e.StackTrace);
                    }catch(Exception ex){
                        ExceptionLogger.Log(ex);
                    }
                }
			}
		}

		private static void MovePursuitFleets(List<FleetSector> fleets) {
            List<FleetSector> pursuitFleets = fleets.FindAll(delegate(FleetSector s) { return s.FleetSectorMoveArgs != null && s.FleetSectorMoveArgs.Pursuit; });
            //NHibernateUtilities.Statistics.Clear();
            foreach (FleetSector fleet in pursuitFleets) {
                ISector sector = Universe.Universe.GetSector(fleet.Coordinate);
                if (fleet.Coordinate.System.IsPrivateSystem() || (!sector.IsInBattle && sector is FleetSector)) {
                    SectorCoordinate c = GetPursuitedFleetLocation(fleet, fleets);
                    if (c == null || c.System.IsPrivateSystem() || IsFar(fleet.Coordinate, c)) {
					    fleet.IsMoving = false;
				    }else {
					    fleet.FleetSectorMoveArgs.Destiny = c;
					    fleet.Turn();
				    }
                }
            }
		}

        private static void MoveBotFleets(List<FleetSector> botFleets) {
            foreach (FleetSector sector in botFleets) {
                ISector fleet = Universe.Universe.GetSector(sector.Coordinate);
                if (fleet.Coordinate.System.IsPrivateSystem() || (!fleet.IsInBattle && fleet is FleetSector)) {
                    if (fleet.IsMoving) {
                        continue;
                    }
                    List<SectorCoordinate> coordinates = SectorUtils.GetAllPossibleCoordinates(sector.Coordinate, 3);
                    List<ISector> targets = Universe.Universe.GetSectors(coordinates).FindAll(delegate(ISector s) { return s is FleetSector && s.Storage.Id != sector.Storage.Id && !s.Owner.Principal.IsBot; });
                    if (targets != null && targets.Count > 0) {
                        PursuitTarget(sector, targets);
                    } else {
                        TryToMoveToWayPoint(sector);
                    }
                }
            }
        }

		private static void TryToMoveToWayPoint(FleetSector fleetSector) {
			if (fleetSector.GetBattleFleet().HasWayPoints) {
				Coordinate system = GetNextSystemWayPoint(fleetSector);

				Coordinate sector = new Coordinate(random.Next(1, 8), random.Next(1, 11));
				FleetSectorMoveArgs args = new FleetSectorMoveArgs();
				args.Source = fleetSector.Coordinate;
				args.Destiny = new SectorCoordinate(system, sector);
				args.Flush = false;
				fleetSector.OnMove(args);
			}
		}

    	private static Coordinate GetNextSystemWayPoint(FleetSector sector) {
    		List<Coordinate> wayPoints = sector.GetBattleFleet().WayPoints;
			while(true){
    			int idx = random.Next(0, wayPoints.Count);
				Coordinate c = wayPoints[idx];
				if( !c.Equals(sector.Coordinate.System)) {
					return c;
				}
			}
    	}

    	private static void PursuitTarget(FleetSector sector, List<ISector> targets) {
			foreach (ISector target in targets) {
				if ( CanPursuit(sector, target) ) {
					Console.WriteLine("» Hostile found! Fleet: '{0}'", target.GetBattleFleet().Name);
					FleetSectorMoveArgs args = new FleetSectorMoveArgs();
					args.Source = sector.Coordinate;
					args.Destiny = target.Coordinate;
					args.AttackWhenArrive = true;
					args.Pursuit = true;
					args.FleetToPursuitId = target.GetBattleFleet().Id;
					args.Flush = false;
					sector.OnMove(args);
					return;
				}
			}
		}

    	private static bool CanPursuit(FleetSector sector, ISector target) {
			return target.SystemCoordinate.Equals(sector.SystemCoordinate) && (target.Owner.PlanetLevel >= 5 || (target.Owner.PlanetLevel >= sector.Level - 2 && target.Owner.PlanetLevel <= sector.Level + 2));
    	}



    	private static void ShowStats(){
            Console.WriteLine("======= Stats For the Round ==========");
            Console.WriteLine("FlushCount: {0}", NHibernateUtilities.Statistics.FlushCount);
            Console.WriteLine("Queries: {0}", NHibernateUtilities.Statistics.Queries.Length);
            Console.WriteLine("MaxTime: {0}", NHibernateUtilities.Statistics.QueryExecutionMaxTime);
            Console.WriteLine("Sessions Open: {0}", NHibernateUtilities.Statistics.SessionOpenCount);
            Console.WriteLine("Sessions Close: {0}", NHibernateUtilities.Statistics.SessionCloseCount);
            Console.WriteLine("Insert Count: {0}", NHibernateUtilities.Statistics.EntityInsertCount);
            Console.WriteLine("UpdateCount Count: {0}", NHibernateUtilities.Statistics.EntityUpdateCount);
            Console.WriteLine("Fetch Count: {0}", NHibernateUtilities.Statistics.EntityFetchCount);
            Console.WriteLine("Load Count: {0}", NHibernateUtilities.Statistics.CollectionLoadCount);
            Console.WriteLine("Transaction Count: {0}", NHibernateUtilities.Statistics.TransactionCount);
            Console.WriteLine("Connect Count: {0}", NHibernateUtilities.Statistics.ConnectCount);
            Console.WriteLine("---- Queries Made -----");
            foreach (string q in NHibernateUtilities.Statistics.Queries)
            {
                Console.WriteLine(q);
            }
            NHibernateUtilities.Statistics.Clear();
            Console.WriteLine("======= Stats For the Round End ==========");
        }
		
		#endregion Private

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        protected override void ProcessAction(bool forcedEnd) {
			NHibernateUtilities.Statistics.Clear();
			Universe.Universe.Clear();
			Universe.Universe.LoadUniverse();
				
			List<FleetSector> fleets = Universe.Universe.FleetsInMovement;
			if (fleets.Count > 0 ) {
				MoveNonPursuitFleets(fleets);
				MovePursuitFleets(fleets);
				MoveBotFleets(Universe.Universe.BotFleets);
				GameEngine.PersistUniverse();
			}
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				persistance.StartTransaction();	
				persistance.CommitTransaction();
			}
        }

		#endregion Base Implementation

    };

}
