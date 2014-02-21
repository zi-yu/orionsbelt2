using System.Collections;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System;

namespace OrionsBelt.Engine {
	public class BattleOwner {

		#region Fields

		private static readonly Dictionary<string, OwnerListGetter> playerListDelegates = new Dictionary<string, OwnerListGetter>();
		private readonly Dictionary<string, OwnerGetter> playerDelegates = new Dictionary<string, OwnerGetter>();

		private delegate Dictionary<int, object> OwnerListGetter(Core.Battle battle);
		private delegate IBattleOwner OwnerGetter( int id );
		private Dictionary<int, object> container;

		#endregion Fields

		#region Private

		private static string GetWheres( IList<PlayerBattleInformation> players ) {
			StringBuilder builder  = new StringBuilder();
			builder.AppendFormat("p.Id = {0} ", players[0].Owner);
			for( int i = 1; i < players.Count; ++i ) {
				builder.AppendFormat("or p.Id = {0} ", players[i].Owner);
			}
			return builder.ToString();
		}

		#endregion

		#region PlayerGetter Delegates

		/// <summary>
		/// Obtains the battle owner by principal
		/// </summary>
		/// <param name="battle"></param>
		/// <returns>Container to filled with the principals of the battle</returns>
		private static Dictionary<int, object> GetPlayerListByPrincipal( Core.Battle battle ) {
			Dictionary<int, object> principalContainer = new Dictionary<int, object>();
			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				if( Server.IsInTests ) {
					foreach (PlayerBattleInformation p in battle.PlayerInformation) {
						Principal principal = persistance.SelectById(p.Owner)[0];
						principalContainer.Add(principal.Id, principal);
					}
				}else {
					IList list = persistance.Query("select from SpecializedPrincipal as p where {0}", GetWheres(battle.PlayerInformation));
					foreach( Principal p in list ) {
						principalContainer.Add(p.Id, p);
					}
				}
				return principalContainer;
			}
		}

		/// <summary>
		/// Obtains the battle owner by IPlayer
		/// </summary>
		/// <param name="battle"></param>
		/// <returns>Container to filled with the principals of the battle</returns>
		private static Dictionary<int, object> GetPlayerListByIPlayer(Battle battle) {
			Dictionary<int, object> playerContainer = new Dictionary<int, object>();	
			if (Server.IsInTests) {
                using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
				foreach (PlayerBattleInformation p in battle.PlayerInformation) {
					PlayerStorage player = persistance.SelectById(p.Owner)[0];
					playerContainer.Add(player.Id, player);
				}
                }				
            } else {
                string query =string.Format("select p from SpecializedPlayerStorage p inner join fetch p.PrincipalNHibernate where {0}",GetWheres(battle.PlayerInformation));
				IList<PlayerStorage> list = Hql.StatelessQuery<PlayerStorage>(query);
				foreach (PlayerStorage p in list) {
					playerContainer.Add(p.Id, p);
				}
			}
			return playerContainer;
		}

		/// <summary>
		/// Obtains the battle owner by principal
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Reference to the battleOwner</returns>
		private IBattleOwner GetPlayerByPrincipal( int id ) {
			Principal principal = container[id] as Principal;
			return new PrincipalOwner(principal);
		}

		/// <summary>
		/// Obtains the battle owner by IPlayer
		/// </summary>
		/// <returns>Reference to the battleOwner</returns>
		private IBattleOwner GetPlayerByIPlayer( int id ) {
            if (container.ContainsKey(id)) {
                PlayerStorage storage = container[id] as PlayerStorage;
                return new PlayerOwner(PlayerUtils.LoadPlayer(storage));
            } else {
                Console.WriteLine("Player with the id {0} not found", id);
            }
			return new PlayerOwner(PlayerUtils.Current);
		}

		#endregion PlayerGetter Delegates

		#region Static

		/// <summary>
		/// Gets the IBattlePlayer base on a principal
		/// </summary>
		/// <param name="principal">Principal object</param>
		/// <returns>IBattleOwner that represents the principal</returns>
		public static IBattleOwner Get( Principal principal ) {
			return new PrincipalOwner(principal);
		}

		/// <summary>
		/// Gets the IBattlePlayer base on a player
		/// </summary>
		/// <param name="player">Player object</param>
		/// <returns>IBattleOwner that represents the player</returns>
		public static IBattleOwner Get( IPlayer player ) {
			return new PlayerOwner(player);
		}

		/// <summary>
		/// Converts a List of Principal into a list ot IBattleOwners
		/// </summary>
		/// <param name="principals">Principals to convert</param>
		/// <returns>A List with the IBattleOwners</returns>
		public static List<IBattleOwner> Convert( IList<Principal> principals ) {
			List<IBattleOwner> owners = new List<IBattleOwner>();
			foreach( Principal principal in principals ) {
				owners.Add( Get(principal) );		
			}
			return owners;
		}

		/// <summary>
		/// Converts a List of Principal into a list ot IBattleOwners
		/// </summary>
		/// <param name="players">Principals to convert</param>
		/// <returns>A List with the IBattleOwners</returns>
		public static List<IBattleOwner> Convert( IList<IPlayer> players ) {
			List<IBattleOwner> owners = new List<IBattleOwner>();
			foreach( IPlayer player in players ) {
				owners.Add(Get(player));
			}
			return owners;
		}

		#endregion Static

		#region Public

		/// <summary>
		/// Gets the IBattlePlayer base on a player
		/// </summary>
		/// <param name="player">Player object</param>
		/// <returns>IBattleOwner that represents the player</returns>
		public IBattleOwner Get( PlayerBattleInformation player ) {
            try {
                if (container == null) {
                    container = playerListDelegates[player.Battle.BattleMode](player.Battle);
                }
                return playerDelegates[player.Battle.BattleMode](player.Owner);
            }catch(Exception){
                Console.WriteLine("BattleId: {0}",player.Battle.Id);
                throw;
            }
		}

		#endregion

		#region Constructor

		static BattleOwner() {
			playerListDelegates[BattleMode.Battle.ToString()] = GetPlayerListByIPlayer;
			playerListDelegates[BattleMode.Friendly.ToString()] = GetPlayerListByPrincipal;
			playerListDelegates[BattleMode.Tournament.ToString()] = GetPlayerListByPrincipal;
            playerListDelegates[BattleMode.Arena.ToString()] = GetPlayerListByIPlayer;
			playerListDelegates[BattleMode.Campaign.ToString()] = GetPlayerListByPrincipal;
		}

		public BattleOwner() {
			playerDelegates[BattleMode.Battle.ToString()] = GetPlayerByIPlayer;
			playerDelegates[BattleMode.Friendly.ToString()] = GetPlayerByPrincipal;
			playerDelegates[BattleMode.Tournament.ToString()] = GetPlayerByPrincipal;
            playerDelegates[BattleMode.Arena.ToString()] = GetPlayerByIPlayer;
			playerDelegates[BattleMode.Campaign.ToString()] = GetPlayerByPrincipal;
		}

		#endregion Constructor

	}
}
