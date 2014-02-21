using System.Collections;
using System.Collections.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Player related utilities
    /// </summary>
    public static class PirateBayUtils {

        public static IList GetNoneDefendedPlanets(SectorCoordinate center, int servicePrice)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                persistance.StartTransaction();
                Utils.Principal.Credits -= servicePrice;
                persistance.Update(Utils.Principal);
                TransactionManager.PirateBayTransaction(PlayerUtils.Current, servicePrice, center.ToString(), persistance);
                persistance.CommitTransaction();
            
               return
                    persistance.Query(
                        "select e.SystemX, e.SystemY, e.SectorX, e.SectorY, p.Name, p.Race, p.PlanetLevel from SpecializedFleet e inner join e.PlayerOwnerNHibernate p inner join e.CurrentPlanetNHibernate c where e.IsPlanetDefenseFleet=1 and e.Units='' and e.SystemX >={0} and e.SystemX <={1} and e.SystemY >={2} and e.SystemY <={3} and c.PlayerNHibernate is not null",
                        center.System.X - 1, center.System.X, center.System.Y, center.System.Y + 1);
            }


            //Messenger.Add(Category.Player, typeof(ScanPlanetMessage), playerId);

        }

        public static IList GetCargoFleets(SectorCoordinate center, int servicePrice)
        {

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                persistance.StartTransaction();
                Utils.Principal.Credits -= servicePrice;
                persistance.Update(Utils.Principal);
                TransactionManager.PirateBayTransaction(PlayerUtils.Current, servicePrice, center.ToString(), persistance);
                persistance.CommitTransaction();
            
                return
                     persistance.Query(
                         "select e.SystemX, e.SystemY, e.SectorX, e.SectorY, p.Name, p.Race,p.PlanetLevel from SpecializedFleet e inner join e.PlayerOwnerNHibernate p where e.SystemX >={0} and e.SystemX <={1} and e.SystemY >={2} and e.SystemY <={3} and e.Cargo <> ''",
                         center.System.X - 1, center.System.X, center.System.Y, center.System.Y + 1);
            }

            
        }

    };
}
