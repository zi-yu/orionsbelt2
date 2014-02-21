using System.Collections;
using System.Collections.Generic;
using System.IO;
using DesignPatterns;
using Loki.DataRepresentation;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System;

namespace OrionsBelt.Engine {
	public static class BattlePersistance {

		#region Fields

		private static readonly FactoryContainer battleInfoFactory = new FactoryContainer(typeof(BattleInfo));			
		
		#endregion

		#region Private

		/// <summary>
		/// Updates the battle action
		/// </summary>
		/// <param name="battle">Current Battle</param>
        /// <param name="player">Current Player</param>
        private static void UpdateAction(Battle battle, IBattlePlayer player ) {
			if( !battle.IsDeployTime && !Server.IsChronos && !Server.IsInTests){
				using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
					if( battle.TimedAction.Count > 0 ) {
						TimedActionStorage action = battle.TimedAction[0];
						if (battle.HasEnded) {
							battle.TimedAction.Clear();
							persistance.Delete(action);
						}else{
							action.StartTick = Clock.Instance.Tick;

							int ticks = Clock.Instance.Tick + Clock.Instance.ConvertToTicks(BattleCreator.DefaultTimespan);
							if( player.Owner.IsOnVacations) {
								action.EndTick = ticks * -1;	
							}else {
								action.EndTick = ticks;	
							}

							//if (action.EndTick > 0) {
							//    action.EndTick = Clock.Instance.Tick + Clock.Instance.ConvertToTicks(BattleCreator.DefaultTimespan);	
							//}else {
							//    action.EndTick = (Clock.Instance.Tick + Clock.Instance.ConvertToTicks(BattleCreator.DefaultTimespan)) * -1;	
							//}
							persistance.Update(action);
						}
					}
				}
			}
		}

		private static void UpdatePlayer(IBattleInfo battleInfo) {
			if( battleInfo.BattleMode == BattleMode.Battle ) {
				foreach (IBattlePlayer player in battleInfo.Players ) {
					PlayerOwner p = (PlayerOwner)player.Owner;
					GameEngine.Persist(p.Player,false,false);
				}
			}
		}

        private static string GetWhere(IList<PlayerBattleInformation> battles){
            using (StringWriter writer = new StringWriter()) {
                writer.Write("where b.Id = {0} ", battles[0].Battle.Id);
                for (int i = 1; i < battles.Count; ++i) {
                    writer.Write("or b.Id = {0} ", battles[i].Battle.Id);
                }
                return writer.ToString();
            }
		}

		#endregion Private

		#region Public

		public static IBattleInfo ConvertToBattleInfo( Battle battle ) {
			return (IBattleInfo) battleInfoFactory.create(battle.BattleType, new BattleWrapper(battle));
		}

		/// <summary>
		/// Gets the battle with the specified id
		/// </summary>
		/// <param name="id">Id of the battle</param>
		/// <param name="loadAction">Id of the battle</param>
		/// <returns>Object that represents the information of the battle in the Database</returns>
		public static Battle GetRawBattle( int id, bool loadAction ) {
			using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance()) {
				if( Server.IsInTests) {
					return persistance.SelectById(id)[0];
				}else {
					Dictionary<string, object> param = new Dictionary<string, object>();
					param.Add("battleId", id);

					int lenght = loadAction ? 3 : 2;
					string[] hql = new string[lenght];
					hql[0] = "select b from SpecializedBattle b inner join fetch b.PlayerInformationNHibernate p where b.Id = :battleId";
					hql[1] = "select b from SpecializedBattle b inner join fetch b.BattleExtensionNHibernate p where b.Id = :battleId";
					if (loadAction) {
						hql[2] = "select b from SpecializedBattle b inner join fetch b.TimedActionNHibernate p where b.Id = :battleId";
					}

					IList battle = persistance.MultiQuery(hql, param);
					IList<Battle> results = Hql.Unify(SectorUtils.ConvertToList<Battle>((IEnumerable)battle[0]));
					if (results.Count > 0) {
						return results[0];
					}
				}
			}
			return null;
		}

		public static List<IBattleInfo> GetBotBattles(int botId) {
			using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance()) {
				KeyValuePair<string,object> param = Hql.Param("botId", botId);
                IList<PlayerBattleInformation> battles = Hql.StatelessQuery<PlayerBattleInformation>("select p from SpecializedPlayerBattleInformation p inner join fetch p.BattleNHibernate b where p.BotId = :botId and b.HasEnded = 0 and ( (b.CurrentBot = :botId and b.IsDeployTime = 0 ) or ( b.IsDeployTime = 1 and p.HasPositioned = 0) )", param);
				if( battles.Count > 0 ) {
					string where = GetWhere(battles);

					string[] hql = new string[3];
					hql[0] = string.Format("select b from SpecializedBattle b inner join fetch b.PlayerInformationNHibernate p {0}",where);
					hql[1] = string.Format("select b from SpecializedBattle b inner join fetch b.BattleExtensionNHibernate p {0}", where);
					hql[2] = string.Format("select b from SpecializedBattle b inner join fetch b.TimedActionNHibernate p {0}", where);

					Dictionary<string, object> p = new Dictionary<string, object>();
					p.Add("botId", botId);
					IList battle = persistance.MultiQuery(hql, p);
					IList<Battle> battleObjects =  Hql.Unify(SectorUtils.ConvertToList<Battle>((IEnumerable)battle[0]));
					List<IBattleInfo> battleInfos = new List<IBattleInfo>();
					foreach (Battle o in battleObjects) {
						battleInfos.Add( ConvertToBattleInfo(o) );
					}
					return battleInfos;
				}
			}
			return null;
		}

		/// <summary>
		/// Gets the battle with the specified id
		/// </summary>
		/// <param name="id">Id of the battle</param>
		/// <returns>Object that represents the information of the battle in the Database</returns>
		public static Battle GetRawBattle( int id ) {
			return GetRawBattle(id,true);
		}

		/// <summary>
		/// Gets the battle with the specified id
		/// </summary>
		/// <param name="id">Id of the battle</param>
		/// <returns>Object that represents the information of the battle in the Database</returns>
		public static IBattleInfo GetBattle( int id ) {
			return ConvertToBattleInfo(GetRawBattle(id));
		}

		/// <summary>
		/// Gets the Fleet with the specified id
		/// </summary>
		/// <param name="id">Id of the fleet</param>
		/// <param name="owner">Owner of the fleet</param>
		/// <returns>Object that represents the information of the battle in the Database</returns>
		public static IFleetInfo GetFleet( int id, IBattleOwner owner ) {
			using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance() ) {
				IList<Fleet> fleets;
				if( Server.IsInTests ) {
					fleets = persistance.SelectById(id);
				}else {
					fleets = persistance.TypedQuery("select f from SpecializedFleet f inner join fetch f.SectorNHibernate where f.Id = {0}", id);
				}
			
				
				Fleet fleet = fleets[0];
				if (fleet.Sector == null) {
					return new FleetInfo(fleet, false);
				}

				IFleetInfo fleetInfo = new FleetInfo(fleet, ((PlayerOwner)owner).Player) ;
				fleetInfo.Units.Clear();
				return fleetInfo;
			}
		}

		/// <summary>
		/// Updates the passed battle
		/// </summary>
		/// <param name="battleInfo">Battle to update</param>
		/// <returns>Object that represents the information of the battle in the Database</returns>
		public static void UpdateBattle( IBattleInfo battleInfo ) {
            Battle battle = battleInfo.GetUpdatedBattle();
			
			using( IPlayerBattleInformationPersistance persistance = Persistance.Instance.GetPlayerBattleInformationPersistance() ) {

				foreach( PlayerBattleInformation p in battle.PlayerInformation )   {
					persistance.Update(p);
				}

				foreach (BattleMessage battleMessage in battleInfo.TurnMessages) {
					Messenger.Add(battleMessage);
				}

				using (IBattleExtentionPersistance persistance1 = Persistance.Instance.GetBattleExtentionPersistance(persistance)) {
					persistance1.Update(battle.BattleExtension[0]);
				}

				using (IBattlePersistance persistance2 = Persistance.Instance.GetBattlePersistance(persistance)) {
					persistance2.Update(battle);
				}

				UpdateAction(battle, battleInfo.CurrentBattlePlayer);
				UpdatePlayer(battleInfo);
			}
			
			battleInfo.RemoveAllMessages();
		}


        /// <summary>
		/// Deletes passed battle
		/// </summary>
        /// <param name="battle">Battle to delete</param>
		public static void DeleteBattle( Battle battle ) {
            DeleteBattle(battle, false);
		}

        /// <summary>
		/// Deletes passed battle
		/// </summary>
        /// <param name="battle">Battle to delete</param>
        /// <param name="flush">if flush after delete</param>
		public static void DeleteBattle( Battle battle, bool flush ) {
            using(IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance()) {
                Console.Write("Deleting Battle '{0}'...",battle.Id);
                persistance.Delete("from SpecializedPlayerBattleInformation m where m.BattleNHibernate.Id = {0}", battle.Id);
                persistance.Delete("from SpecializedMessage m where m.OwnerId = {0}", battle.Id);
                persistance.Delete("from SpecializedBattleExtention m where m.BattleNHibernate.Id = {0}", battle.Id);
                persistance.Delete("from SpecializedTimedActionStorage a where a.BattleNHibernate.Id = {0}", battle.Id);
                persistance.Delete("from SpecializedBattle b where b.Id = {0}", battle.Id);
                if( flush ) {
                    Persistance.Flush();
                }
                Console.WriteLine("DONE");
            }
		}

		/// <summary>
		/// Updates the Fleet with the specified id
		/// </summary>
		/// <param name="fleetInfo">Fleet to update</param>
		/// <param name="findSurroundSector">if the fleet has to find a surround available sector</param>
		/// <returns>Object that represents the information of the battle in the Database</returns>
		public static void UpdateFleet( IFleetInfo fleetInfo, bool findSurroundSector ) {
            if ( !fleetInfo.HasUnits ) {
				FleetPersistance.DeleteFleet(fleetInfo,false);
				if (fleetInfo.Owner != null ) {
					Messenger.Add(new FleetDestroyedMessage(fleetInfo.Owner.Id, fleetInfo.Name));
				}
			}else{
                if ( fleetInfo.Sector != null && !fleetInfo.IsPlanetDefenseFleet){
					FleetSector fs;
					if (findSurroundSector) {
						ISector destiny = Universe.Universe.GetSurroundAvailableCoordinateInBattle(fleetInfo.Location, fleetInfo.Owner);
						//ISector destiny = Universe.Universe.GetSurroundAvailableCoordinate(fleetInfo.Location, fleetInfo.Owner);
						fs = SectorUtils.ConvertToFleetSector(destiny, fleetInfo);
					} else {
						fs = SectorUtils.ConvertToFleetSector(fleetInfo.Sector, fleetInfo);
					}
                	fs.IsInBattle = false;
                	fleetInfo.IsInBattle = false;
					fleetInfo.Touch();
					GameEngine.Persist(fs,false,true);
				} else {
					GameEngine.Persist(fleetInfo);
				}
			}
		}

		public static void UpdatePlayerBattleInformation( PlayerBattleInformation playerBattleInformation ) {
			using( IPlayerBattleInformationPersistance persistance = Persistance.Instance.GetPlayerBattleInformationPersistance() ) {
				persistance.Update(playerBattleInformation);
			}
		}

		/// <summary>
		/// UPdates the information of a player of the battle. Only usable if the battle
		/// is NOT a tounament battle
		/// </summary>
		/// <param name="battleInfo">Information of the battle</param>
		public static void UpdateBattlePlayers(IBattleInfo battleInfo) {
			foreach (IBattlePlayer battlePlayer in battleInfo.Players) {
				PlayerOwner owner = (PlayerOwner) battlePlayer.Owner;
				if (battlePlayer.HasLost) {
					owner.Player.Score += battlePlayer.LoseScore;
				}else {
					owner.Player.Score += battlePlayer.WinScore;
				}
			}
		}

		#endregion Public

	}
}
