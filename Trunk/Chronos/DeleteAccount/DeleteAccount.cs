
using System;
using System.Collections;
using System.Collections.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Universe;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine;

namespace OrionsBelt.Chronos {
    public static class DeleteAccount {

        #region Private

        private static List<PlayerStorage> GetAllInactiveprincipals(){
            Console.Write("Loading Players...");
            List<PlayerStorage> storage = new List<PlayerStorage>();
            using(IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance() ){

				//string[] hql = new string[13];
				//hql[0] = "select p from SpecializedPlayerStorage p inner join fetch p.PrincipalNHibernate";
				//hql[1] = "select p from SpecializedPlayerStorage p inner join fetch p.PlanetsNHibernate";
				//hql[2] = "select p from SpecializedPlayerStorage p inner join fetch p.PlanetsNHibernate a inner join a.ResourcesNHibernate";
				//hql[3] = "select p from SpecializedPlayerStorage p inner join fetch p.FleetsNHibernate";
				//hql[4] = "select p from SpecializedPlayerStorage p inner join fetch p.SectorNHibernate";
				//hql[5] = "select p from SpecializedPlayerStorage p inner join fetch p.AuctionNHibernate";
				//hql[6] = "select p from SpecializedPlayerStorage p inner join fetch p.SpecialSectoresNHibernate";
				//hql[7] = "select p from SpecializedPlayerStorage p inner join fetch p.DiscoveredUniverseNHibernate";
				//hql[8] = "select p from SpecializedPlayerStorage p inner join fetch p.StatsNHibernate";
				//hql[9] = "select p from SpecializedPlayerStorage p inner join fetch p.MyFriendsNHibernate";
				//hql[10] = "select p from SpecializedPlayerStorage p inner join fetch p.OtherFriendsNHibernate";
				//hql[11] = "select p from SpecializedPlayerStorage p inner join fetch p.MedalsNHibernate";
				//hql[12] = "select p from SpecializedPlayerStorage p inner join fetch p.BidsNHibernate";
				//IList allPlayers = persistance.MultiQuery(hql,new Dictionary<string, object>());
				//IList<PlayerStorage> players = SectorUtils.ConvertToList<PlayerStorage>((IEnumerable)allPlayers[0]);
                IList<PlayerStorage> players = persistance.TypedQuery("select p from SpecializedPlayerStorage p inner join fetch p.PrincipalNHibernate");

				//IList battle = persistance.MultiQuery(hql, param);
				//IList<Battle> results = Hql.Unify(SectorUtils.ConvertToList<Battle>((IEnumerable)battle[0]));

				
                foreach (PlayerStorage player in players){
                    if( player.Principal.IsBot ){
                        continue;
                    }
                    DateTime firstLimit = player.CreatedDate.AddDays(2);
                    if (firstLimit.Day == DateTime.Now.Day){
#if !DEBUG
                        //SendWarningEmail(player);
#endif
                        continue;
                   }

                    DateTime limitDate = player.CreatedDate.AddDays(5);
                    if (player.UpdatedDate < limitDate && limitDate < DateTime.Now){
                        if (player.Planets.Count == 1 && player.Principal.Player.Count == 1 && !CheckFleetInHot(player)){
							storage.Add(player);
                        }
                    }
                }
            }
            Console.WriteLine("DONE");
            Console.WriteLine("{0} Players loaded",storage.Count);
            return storage;
        }

        private static bool CheckFleetInHot(PlayerStorage player){
            foreach( Fleet fleet in player.Fleets ){
                if( fleet.SystemX != 0 || fleet.SystemY != 0 ){
                    return true;
                }
            }
            return false;
        }

        private static void SendWarningEmail(PlayerStorage player) {
            MailSender.Send(player.Principal.Email, "noreply@orionsbelt.eu", LanguageManager.Instance.Get("WarningMail1Title"), LanguageManager.Instance.Get("WarningMail1Body"),player.Principal.Name);
        }

        private static void SendDeletionEmail(PlayerStorage player){
            MailSender.Send(player.Principal.Email, "noreply@orionsbelt.eu", LanguageManager.Instance.Get("DeletionMailTitle"), LanguageManager.Instance.Get("DeletionMailBody"), player.Principal.Name);
        }

        #endregion Private

        #region Deletes

        private static void DeleteFog(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting FoW of player {0}...", player.Principal.Name);
            persistance.Delete("from SpecializedFogOfWarStorage e where e.OwnerNHibernate.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

        private static void DeletePrincipalStats(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting PrincipalStats of player {0}...", player.Principal.Name);
            persistance.Delete("from SpecializedPrincipalStats e where e.Id = {0}", player.Principal.MyStatsId);
            Console.WriteLine("DONE");
        }

        private static void DeleteFleets(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting Fleets of player {0}...", player.Principal.Name);
            persistance.Delete("from SpecializedFleet e where e.PlayerOwnerNHibernate.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

        private static void DeletePlanets(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting Planets Resources of player {0}...", player.Principal.Name);
            PlanetStorage planet = player.Planets[0];
            persistance.Delete("from SpecializedPlanetResourceStorage e where e.PlanetNHibernate.Id = {0}", planet.Id);
            Console.WriteLine("DONE");

            Console.Write(" » Deleting Planets of player {0}...", player.Principal.Name);
            persistance.Delete("from SpecializedPlanetStorage e where e.PlayerNHibernate.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

        private static void DeleteWormHoles(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting WormHoles of player {0}...", player.Principal.Name);
            persistance.Delete("from SpecializedUniverseSpecialSector e where e.OwnerNHibernate.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

        private static void DeleteUniverse(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting Universe of player {0}...", player.Principal.Name);
            persistance.Delete("from SpecializedSectorStorage e where e.OwnerNHibernate.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

        private static void DeletePlayer(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting player {0}...", player.Principal.Name);
            persistance.Delete("from SpecializedPlayerStorage e where e.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

        private static void DeletePlayerFriendOrFoe(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting player {0} Friend or Foe...", player.Principal.Name);
            persistance.Delete("from SpecializedFriendOrFoe e where e.SourceNHibernate.Id = {0} or e.TargetNHibernate.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

        private static void DeletePlayerMedals(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting player {0} Medals...", player.Principal.Name);
            persistance.Delete("from SpecializedMedal e where e.PlayerNHibernate.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

        private static void DeletePlayerBidHistory(PlayerStorage player, IPersistanceSession persistance){
            Console.Write(" » Deleting player {0} BidHistorical...", player.Principal.Name);
			persistance.Delete("from SpecializedBidHistorical e where e.MadeByNHibernate.Id = {0}", player.Id);
            Console.WriteLine("DONE");
        }

		private static void DeletePlayerAuctionHouse(PlayerStorage player, IPersistanceSession persistance) {
			Console.Write(" » Deleting player {0} AuctionHouse...", player.Principal.Name);
			foreach (AuctionHouse a in player.Auction) {
				persistance.Delete("from SpecializedBidHistorical e where e.ResourceNHibernate.Id = {0}", a.Id);
			}

			persistance.Delete("from SpecializedAuctionHouse e where e.OwnerNHibernate.Id = {0}", player.Id);
			Console.WriteLine("DONE");
		}

        #endregion Deletes

        #region Public

        public static void DeleteAllInactiveAccounts(){
            IList<PlayerStorage> players = GetAllInactiveprincipals();
            if( players.Count > 0 ) {
                using(IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance() ){
                    persistance.StartTransaction();
                    Console.WriteLine("####################################");
                    foreach (PlayerStorage player in players){
						Console.WriteLine("Deleting player {0}:", player.Principal.Name);
						DeleteFog(player, persistance);
						DeleteWormHoles(player, persistance);
						DeleteFleets(player, persistance);
						DeletePlanets(player, persistance);
						DeleteUniverse(player, persistance);
						DeletePlayerFriendOrFoe(player, persistance);
						DeletePlayerMedals(player, persistance);
						DeletePlayerBidHistory(player, persistance);
						DeletePlayerAuctionHouse(player, persistance);
						DeletePlayer(player, persistance);
						Console.WriteLine("Player {0} DELETED!", player.Principal.Name);
						Console.WriteLine("####################################");
                    }
                    persistance.CommitTransaction();
                }
            }
            Console.WriteLine("Deletion of {0} Inactive Players Completed", players.Count);
        }

        #endregion Public
    }
}
