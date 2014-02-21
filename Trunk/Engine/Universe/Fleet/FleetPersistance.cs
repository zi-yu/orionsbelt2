using System;
using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	public static class FleetPersistance {

		#region Fields

		private static readonly FactoryContainer factoryContainer = new FactoryContainer(typeof (Sector));
		
		#endregion Fields

		#region Fleet Manipulation

		/// <summary>
		/// Gets the fleet with the passed id
		/// </summary>
		/// <param name="fleetId"></param>
		/// <returns></returns>
		public static IFleetInfo GetFleet(int fleetId) {
			IList<Fleet> fleet = Hql.StatelessQuery<Fleet>("select f from SpecializedFleet f inner join fetch f.SectorNHibernate where f.Id = :id", Hql.Param("id", fleetId));
			if (fleet.Count > 0) {
				return new FleetInfo(fleet[0]);
			}
			return null;
		}

		/// <summary>
		/// Get's the passed player moveable fleets
		/// </summary>
		/// <param name="player">Owner of the fleets</param>
		/// <returns>A list of the player's Fleets</returns>
		public static List<IFleetInfo> LoadPlayerMoveableFleets(IPlayer player) {
			IList<Fleet> fleets = Hql.Query<Fleet>("select f from SpecializedFleet f inner join fetch f.SectorNHibernate where f.TournamentFleet = 0 and f.IsMovable = 1 and f.PlayerOwnerNHibernate.Id = :id", Hql.Param("id", player.Id));
			List<IFleetInfo> fleetInfos = new List<IFleetInfo>();
			foreach (Fleet fleet in fleets) {
				fleetInfos.Add(new FleetInfo(fleet, player));
			}
			return fleetInfos;
		}

		/// <summary>
		/// Get's all fleets of the passed player
		/// </summary>
		/// <param name="player">Owner of the fleets</param>
		/// <returns>A list of the player's Fleets</returns>
		public static List<IFleetInfo> LoadPlayerFleets(Resources.Player player) {
			IList<Fleet> fleets;
			List<IFleetInfo> fleetInfos;
			if(Server.IsInTests) {
				using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance()) {
					fleets = persistance.Select();
					fleetInfos = new List<IFleetInfo>();
					foreach (Fleet fleet in fleets) {
						if (fleet.PlayerOwner != null && fleet.PlayerOwner.Id == player.Id) {
							fleetInfos.Add(new FleetInfo(fleet, player));
						}
					}
					return fleetInfos;
				}
			}

			fleets = Hql.Query<Fleet>("select f from SpecializedFleet f inner join fetch f.SectorNHibernate where f.TournamentFleet = 0 and f.PlayerOwnerNHibernate.Id = :id", Hql.Param("id", player.Id));
			fleetInfos = new List<IFleetInfo>();
			foreach (Fleet fleet in fleets) {
				fleetInfos.Add(new FleetInfo(fleet, player));
			}
			return fleetInfos;
		}

		/// <summary>
		/// Get's the passed player moveable fleets
		/// </summary>
		/// <param name="planet">Owner of the fleets</param>
		/// <returns>Alist of the player's Fleets</returns>
		public static List<IFleetInfo> LoadFleetsInPlanet(IPlanet planet) {
			IList<Fleet> fleets = Hql.Query<Fleet>("select f from SpecializedFleet f inner join fetch f.SectorNHibernate where f.TournamentFleet = 0 and f.PlayerOwnerNHibernate.Id = :ownerId and f.CurrentPlanetNHibernate.Id = :planetId", Hql.Param("ownerId", planet.Owner.Id), Hql.Param("planetId", planet.Storage.Id));
			List<IFleetInfo> fleetInfos = new List<IFleetInfo>();
			foreach (Fleet fleet in fleets) {
				fleetInfos.Add(new FleetInfo(fleet, planet.Owner));
			}
			return fleetInfos;
		}

		/// <summary>
		/// Get's the passed player defense fleets 
		/// </summary>
		/// <param name="player">Owner of the fleets</param>
		/// <returns>A list of the player's defense Fleets</returns>
		public static List<IFleetInfo> LoadPlayerPlanetsFleets(IPlayer player) {
			IList<Fleet> fleets = Hql.Query<Fleet>("select f from SpecializedFleet f where f.TournamentFleet = 0 and f.PlayerOwnerNHibernate.Id = :id", Hql.Param("id",player.Id));
			List<IFleetInfo> fleetInfos = new List<IFleetInfo>();
			foreach (Fleet fleet in fleets) {
				fleetInfos.Add(new FleetInfo(fleet, player));
			}
			return fleetInfos;
		}

		/// <summary>
		/// Deletes the selected fleet
		/// </summary>
		/// <param name="fleet">Fleet to erase</param>
		public static void DeleteFleet(IFleetInfo fleet) {
			DeleteFleet(fleet, true);
		}

		/// <summary>
		/// Deletes the selected fleet
		/// </summary>
		/// <param name="fleet">Fleet to erase</param>
		/// <param name="eraseSector">if the sector is to be errased</param>
		public static void DeleteFleet(IFleetInfo fleet, bool eraseSector) {
            if (!fleet.IsPlanetDefenseFleet) {
                using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance()) {
                    persistance.Delete(fleet.Storage);
                    if (eraseSector && fleet.Sector != null && fleet.Sector is FleetSector) {
                        UniversePersistance.RemoveSector(fleet.Sector);
                    }
                }
            }
		}

		#endregion Fleet Manipulation
		
	}
}
