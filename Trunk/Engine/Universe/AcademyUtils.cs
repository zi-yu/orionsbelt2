using System.Collections;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Player related utilities
    /// </summary>
    public static class AcademyUtils {

        public static IList<SectorCoordinate> GetPiratePlanets(int playerId)
        {
            IList<SectorCoordinate> toReturn = new List<SectorCoordinate>();

            IList<PlanetStorage> planets = Hql.StatelessQuery<PlanetStorage>("select e from SpecializedPlanetStorage e where e.PlayerNHibernate.Id =:id and e.Info='GenericPlanet'", Hql.Param("id", playerId));

            foreach (PlanetStorage planet in planets)
            {
                toReturn.Add(new SectorCoordinate(planet.SystemX, planet.SystemY, planet.SectorX, planet.SectorY));
            }

            Messenger.Add(true,Category.Player, typeof(ScanPlanetMessage), playerId);

            return toReturn;
        }

        public static IList<SectorCoordinate> GetPirateFleets(int playerId)
        {
            IList<SectorCoordinate> toReturn = new List<SectorCoordinate>();

            IList<Fleet> fleets = Hql.StatelessQuery<Fleet>("select e from SpecializedFleet e where e.PlayerOwnerNHibernate.Id =:id and e.IsPlanetDefenseFleet=false", Hql.Param("id", playerId));

            foreach (Fleet fleet in fleets)
            {
                toReturn.Add(new SectorCoordinate(fleet.SystemX, fleet.SystemY, fleet.SectorX, fleet.SectorY));
            }

            Messenger.Add(true, Category.Player, typeof(ScanFleetMessage), playerId);

            return toReturn;
        }

        public static IList GetPirateFleets(SectorCoordinate center)
        {

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                return
                     persistance.Query(
                         "select e.SystemX, e.SystemY, e.SectorX, e.SectorY, p.Name, p.Race, p.PlanetLevel from SpecializedFleet e inner join e.PlayerOwnerNHibernate p where e.SystemX >={0} and e.SystemX <={1} and e.SystemY >={2} and e.SystemY <={3} and p.PirateRanking>p.BountyRanking and p.PirateRanking>p.MerchantRanking and e.IsPlanetDefenseFleet=0 and e.IsInBattle=0",
                         center.System.X - 1, center.System.X + 1, center.System.Y - 1, center.System.Y + 1);
            }


        }

    };
}
