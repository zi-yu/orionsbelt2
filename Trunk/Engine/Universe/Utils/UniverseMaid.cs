using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
    public class UniverseMaid {

        #region Fields

        private static int ticks = 4500;

        #endregion Fields

        #region Private

        private static SectorCoordinate GetAvailableCoordinate(ISystem system) {
            SectorCoordinate sc = new SectorCoordinate(new Coordinate(0, 0), new Coordinate(0, 0));
            for (int x = 1; x <= 7; ++x ) {
                for (int y = 1; y <= 10; ++y) {
                    sc.Sector.X = x;
                    sc.Sector.Y = y;
                    if (system.Sectors[sc.Sector] is NormalSector) {
                        return sc;
                    }
                }
            }
            return null;
        }

        private static void UpdateFleet(FleetSector fleetSector,SectorCoordinate coordinate) {
            using (IFleetPersistance p = Persistance.Instance.GetFleetPersistance()) {
                IFleetInfo fleet = fleetSector.GetBattleFleet();
                fleet.Location = coordinate;
                fleet.PrepareStorage();
                fleet.UpdateStorage();
                p.Update(fleet.Storage);
            }
        }
        
        #endregion Private

        #region Public

        public static void RemoveInactiveFleets() {
            Universe.LoadUniverse();

            using(ISectorStoragePersistance p = Persistance.Instance.GetSectorStoragePersistance()) {
                int tickToEvaluate = Clock.Instance.Tick - ticks;
                Console.WriteLine("Current Tick: {0}", Clock.Instance.Tick);
                Console.WriteLine("Tick to evaluate: {0}", tickToEvaluate);
                if (tickToEvaluate < 0) {
                    Console.WriteLine("Tick Lower than zero.");
                    return;
                }
                int count = 0;
                p.StartTransaction();
                foreach (FleetSector fleetSector in Universe.AllFleets) {
                    if (fleetSector.Owner.LastProcessedTick < tickToEvaluate) {
                        Console.WriteLine("Fleet: {0}; Owner: {1}; Last Processed Tick: {2}", fleetSector.FleetName, fleetSector.Owner.Name, fleetSector.Owner.LastProcessedTick);
                        SectorCoordinate coordinate = GetAvailableCoordinate(fleetSector.Owner.PrivateSystem);
                        if(coordinate != null) {
                            fleetSector.Coordinate = coordinate;
                            fleetSector.IsMoving = false;
                            fleetSector.PrepareStorage();
                            fleetSector.UpdateStorage();
                            p.Update(fleetSector.Storage);

                            UpdateFleet(fleetSector,coordinate);

                            fleetSector.Owner.PrivateSystem.Sectors[coordinate.Sector] = fleetSector;

                            ++count;
                        }
                    }
                }
                p.CommitTransaction();
                Console.WriteLine("Fleets Moved: {0}", count);
            }
        }

        #endregion Public

    }
}
