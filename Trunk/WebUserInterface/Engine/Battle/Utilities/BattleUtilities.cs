using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using OrionsBelt.Engine;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.WebBattle {

	internal static class BattleUtilities {

		#region Public

        /// <summary>
        /// Obtains the battle with the passed id
        /// </summary>
        /// <param name="id">Id of the battle</param>
        /// <returns>IBattleInfo that represents the battle</returns>
		public static IBattleInfo GetBattle( int id ) {
			//string key = string.Format("Battle{0}", id);
			//IBattleInfo battleInfo = HttpContext.Current.Cache[key] as IBattleInfo;
			//if( null == battleInfo ) {
			//    battleInfo = BattleManager.GetBattle(id);
			//    HttpContext.Current.Cache.Add(key, battleInfo, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Normal, null);
			//}

			//return battleInfo;
			return BattleManager.GetBattle(id);
		}

		/// <summary>
		/// Removes the battle from the cache
		/// </summary>
		/// <param name="id">Id of the battle</param>
		/// <returns>IBattleInfo that represents the battle</returns>
		public static void RemoveBattle(int id) {
			string key = string.Format("Battle{0}", id);
			HttpContext.Current.Cache.Remove(key);
		}

		/// <summary>
		/// Gets all The battles for the current Player
		/// </summary>
		/// <returns>
		/// An SimpleBattleInfos object with all the battles of
		/// the current player
		/// </returns>
		public static SimpleBattleInfos GetBattles() {
			SimpleBattleInfos simpleBattleInfos = new SimpleBattleInfos();
			simpleBattleInfos.LoadBattles();
			return simpleBattleInfos;
		}

        /// <summary>
        /// Gets all the battles
        /// </summary>
        /// <returns>The infos</returns>
        public static SimpleBattleInfos GetAllBattles()
        {
            SimpleBattleInfos simpleBattleInfos = new SimpleBattleInfos();
            simpleBattleInfos.LoadAllBattles();
            return simpleBattleInfos;
        }

        /// <summary>
        /// Obtains all the battle messages related with the passed battle id
        /// </summary>
        /// <param name="id">Id of the battle that owns the messages</param>
        /// <returns>List of all messages of the battle</returns>
        public static List<IMessage> GetBattleMessages(int id) {
            string key = string.Format("BattleMessages{0}", id);
            List<IMessage> messages = HttpContext.Current.Cache[key] as List<IMessage>;
           // if (null == messages) {
                messages = Messenger.GetMessages(Category.Battle, id);
                HttpContext.Current.Cache.Add(key, messages, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Normal, null);
            //}

            return messages;
        }

        /// <summary>
        /// Clears the from the cache the messages of the passed battle
        /// </summary>
        /// <param name="id">Id of the battle that owns the messages</param>
        public static void ClearBattleMessagesCache(int id) {
            string key = string.Format("BattleMessages{0}", id);
            HttpContext.Current.Cache.Remove(key);
        }

		/// <summary>
		/// Obtains all the battle messages related with the passed battle id
		/// </summary>
		/// <param name="id">Id of the battle that owns the messages</param>
		/// <returns>List of all messages of the battle</returns>
		public static List<IMessage> GetAllBattleMessages( int id ) {
			string key = string.Format("BattleAllMessages{0}", id);
			List<IMessage> messages = HttpContext.Current.Cache[key] as List<IMessage>;
			if( null == messages ) {
				messages = Messenger.GetAllMessages(Category.Battle, id);
				HttpContext.Current.Cache.Add(key, messages, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Normal, null);
			}

			return messages;
		}

		/// <summary>
		/// Clears the from the cache the messages of the passed battle
		/// </summary>
		/// <param name="id">Id of the battle that owns the messages</param>
		public static void ClearAllBattleMessagesCache( int id ) {
			string key = string.Format("BattleAllMessages{0}", id);
			HttpContext.Current.Cache.Remove(key);
		}

        /// <summary>
        /// Obtains all the battle messages related with the passed battle id
        /// </summary>
        /// <param name="id">Id of the battle that owns the messages</param>
        /// <returns>List of all messages of the battle</returns>
        public static List<IMessage> GetBattleMessagesInverted(int id) {
            string key = string.Format("BattleMessagesInverted{0}", id);
            List<IMessage> messages = HttpContext.Current.Cache[key] as List<IMessage>;
            if (null == messages) {
                messages = Messenger.GetAllMessagesInverted(Category.Battle, id);
                HttpContext.Current.Cache.Add(key, messages, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Normal, null);
            }
            return messages;
        }

        /// <summary>
        /// Clears the from the cache the messages of the passed battle
        /// </summary>
        /// <param name="id">Id of the battle that owns the messages</param>
        public static void ClearBattleMessagesInvertedCache(int id) {
            string key = string.Format("BattleMessagesInverted{0}", id);
            HttpContext.Current.Cache.Remove(key);
        }

		/// <summary>
		/// Gets the owner of the battle
		/// </summary>
		/// <param name="battleInfo">Object that represents the battle</param>
		/// <returns></returns>
		public static IBattleOwner GetCurrentOwner( IBattleInfo battleInfo ) {
			IBattleOwner battleOwner = BattleOwnerWeb.Get(battleInfo);
			if( battleOwner == null ) {
				return battleInfo.CurrentBattlePlayer.Owner;
			}
			IBattlePlayer p = battleInfo.GetPlayer(battleOwner);
			if( p == null ) {
				return battleInfo.CurrentBattlePlayer.Owner;
			}
			return battleOwner;
		}

		#endregion Public
	}
}
