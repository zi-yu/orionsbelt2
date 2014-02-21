using System.Collections;
using System.Collections.Generic;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using System.Web;
using OrionsBelt.WebComponents;
using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Engine.Alliances;
using System.IO;
using OrionsBelt.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic.Messages;
using System.Web.Security;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Player related utilities
    /// </summary>
    public static class PlayerUtils {

		#region Private

		private static IPlayer GetPlayer(PlayerStorage player) {
			PlayerBag bag = PlayerBag.Instance;
			IPlayer p;
			if (!bag.HasPlayer(player.Id)) {
				p = new Player(player);
				bag.AddPlayer(p);
			} else {
				p = bag.GetPlayer(player.Id);
				if (!p.Storage.Equals(player)) {
					try {
						Persistance.Evict(player);	
					}catch{}
				}
			}
			return p;
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Gets a player from the Database
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static IPlayer LoadPlayer( Principal p ) {
			IList<PlayerStorage> list = Hql.Query<PlayerStorage>("from SpecializedPlayerStorage e where e.PrincipalNHibernate.Id = :id", new KeyValuePair<string, object>("id", p.Id));
			if( list.Count == 0 ) {
                return null;
			}
			IPlayer player = PlayerConversion.ConvertToPlayer(list[0]);
			State.SetItems(PlayerStateKey,player);
            GameEngine.ProcessPlayer(player);
			return player;
		}

		/// <summary>
		/// Creates a player using the passed player storage. If the player is the current
		/// Player, it returns PlayerUtils.Current
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		public static IPlayer LoadPlayer(PlayerStorage player) {
			if( player == null ) {
				return null;
			}

			if( HasPlayer ) {
				if( Current.Id == player.Id ) {
					return Current;
				}
			}

			return GetPlayer(player);
		}

        public static int MaxFleetNumber {
            get { return 10; }
        }

        public static void UnblockPrincipal(Principal principal)
        {
            if(!principal.Locked)
            {
                return;
            }

            using (IDuplicateDetectionPersistance persistance = Persistance.Instance.GetDuplicateDetectionPersistance())
            {
                persistance.StartTransaction();
                IList<DuplicateDetection> duplicates =
                    persistance.TypedQuery(
                        "select e from SpecializedDuplicateDetection e where e.Verified=false and (e.Cheater={0} or e.Duplicate={0})",
                        principal.Id);

                foreach (DuplicateDetection duplicate in duplicates)
                {
                    duplicate.Verified = true;
                    persistance.Update(duplicate);
                }
                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                {
                    principal.DuplicatedIds = string.Empty;
                    principal.Locked = false;
                    principal.WarningPoints = 0;
                    persistance2.Update(principal);
                }
                persistance.CommitTransaction();
            }
        }

		#endregion

        #region DB Interaction

        public static void Update(IPlayer player)
        {
            player.UpdateStorage();
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
                persistance.Update(player.Storage);
            }
        }

        public static void Refresh(IPlayer player)
        {
            PlayerStorage storage = GetPlayerFromBD(player);
            PlayerConversion.SetPlayer(player, storage);
        }

        public static PlayerStorage GetPlayerFromBD(IPlayer player)
        {
            return GetPlayerFromBD(player.Storage.Id);
        }

        public static PlayerStorage GetPlayerFromBD(int id)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())  {
                return persistance.Select(id);
            }
        }

        public static IPlayer GetPlayerById(int id)
        {
            PlayerStorage storage = GetPlayerFromBD(id);
            return PlayerConversion.ConvertToPlayer(storage);
        }

        #endregion DB Interaction

        #region State

        public static void SetCurrentPlayer(Principal principal)
        {
            if (principal.Player.Count == 0) {
                return;
            }

            IPlayer player = PlayerConversion.ConvertToPlayer(principal.Player[0]);
            //if (principal.Player.Count > 1) {
            //    bool hasActive = false;
            //    foreach (PlayerStorage storage in principal.Player) {
            //        if (storage.Active) {
            //            hasActive = true;
            //        }
            //    }
            //    if (!hasActive) {
            //        player.Active = true;
            //    }
            //}

            State.SetItems(PlayerStateKey, player);
            GameEngine.ProcessPlayer(player);
        }

        private static IPlayer current = null;
        public static IPlayer Current {
            get {
                IPlayer fromContext = GetPlayerFromItems();
                if( fromContext != null ) {
                    return fromContext;
                }
                RedirectIfAppropriate();
                if (current != null) {
                    return current;
                }
				throw new EngineException("Player not set at PlayerUtils.Current");	
            }
            set {
                if (HttpContext.Current != null) {
                    State.SetItems(PlayerStateKey, value);
                }
                current = value;
            }
        }

        private static void RedirectIfAppropriate()
        {
            if (HttpContext.Current != null && !HttpContext.Current.Request.RawUrl.Contains("CreatePlayer")) {
                if (HttpContext.Current.User != null && HttpContext.Current.User.IsInRole("guest")) {
                    HttpContext.Current.Response.Redirect("~/Login.aspx", true);
                } else {
                    HttpContext.Current.Response.Redirect("~/CreatePlayer.aspx", true);
                }
            }
        }

    	public static bool HasPlayer {
            get { return HttpContext.Current != null && GetPlayerFromItems() != null; }
    	}

		public static bool HasAnyPlayer(int id) {
			return PlayerBag.Instance.HasPlayer(id);	
		}

    	public const string PlayerStateKey = "Player";
        private static IPlayer GetPlayerFromItems()
        {
            if (HttpContext.Current != null) {
                if (State.HasItems(PlayerStateKey)) {
                    return (Player) State.GetItems(PlayerStateKey);
                }
				if( HttpContext.Current.User is Principal ) {
                    return LoadPlayer(Utils.Principal);
				}
				
            }
            return null;
        }

		public static IPlayer GetPlayer(int id) {
			return PlayerBag.Instance.GetPlayer(id);
		}
		
        #endregion State

        #region Interactions

        public static IList<Interaction> GetInteractions(IPlayer player)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance()) {

                using (TextWriter writer = new StringWriter()) {

                    writer.Write(" select int from SpecializedInteraction int ");
                    writer.Write(" where (int.Source = {0} and int.SourceType = 'PlayerStorage') ", player.Id);

                    if (AllianceManager.CanManageAlliance(player)) {
                        writer.Write(" where (int.Source = {0} and int.SourceType = 'AllianceStorage') ", player.Alliance.Storage.Id);
                    }

                    writer.Write(" order by int.UpdatedDate desc ");

                    return persistance.TypedQuery(writer.ToString());
                }
            }
        }

        #endregion Interactions

        #region Status

        public static ActivityStatus GetStatus(IPlayer player) 
        {
            return GetStatus(player.Storage);
        }

        public static ActivityStatus GetStatus(PlayerStorage player)
        {
            return GetStatus(player.LastProcessedTick);
        }

        public static ActivityStatus GetStatus(int proceeed)
        {
            if (proceeed >= TickClock.Instance.Tick - 1)
            {
                return ActivityStatus.Online;
            }

            if (proceeed >= TickClock.Instance.Tick - 144)
            {
                return ActivityStatus.Login24Hours;
            }

            if (proceeed >= TickClock.Instance.Tick - (144 * 3))
            {
                return ActivityStatus.Login3Days;
            }

            if (proceeed >= TickClock.Instance.Tick - (144 * 7))
            {
                return ActivityStatus.Login7Days;
            }

            return ActivityStatus.Inactive;
        }

        public static ActivityStatus GetStatus(DateTime date)
        {
            if (date >= DateTime.Now.AddMinutes(-10))
            {
                return ActivityStatus.Online;
            }

            if (date >= DateTime.Now.AddHours(-24))
            {
                return ActivityStatus.Login24Hours;
            }

            if (date >= DateTime.Now.AddDays(-3))
            {
                return ActivityStatus.Login3Days;
            }

            if (date >= DateTime.Now.AddDays(-7))
            {
                return ActivityStatus.Login7Days;
            }

            return ActivityStatus.Inactive;
        }

        public static bool CanRegisterNewPlayers()
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                long count = session.ExecuteScalar("select count(*) from SpecializedPrincipal");
                return count < Server.Properties.MaxPlayers;
            }
        }

        public static bool IsActive(PlayerStorage player)
        {
            if (GetStatus(player.LastProcessedTick) == ActivityStatus.Inactive)
            {
                return false;
            }

            return true;
        }

        #endregion Status

        #region Initialization

        public static void Initialize(IPlayer player)
        {
            ResourceUtils.Initialize(player);
            player.RaceInfo.Initialize(player);

            IPlanet hp = player.GetHomePlanet();
            hp.Info.Initialize(hp);

            player.LastProcessedTick = Clock.Instance.Tick;
        }

        #endregion Initialization

        #region Messages

        public static IList<Message> GetPlayerMessages(IPlayer player)
        {
            return GetPlayerMessages(player, 25);
        }

        public static IList<Message> GetPlayerMessages(IPlayer player, int count) {
            string allianceId = player.Alliance != null ? player.Alliance.Storage.Id.ToString() : "-1";
            IList<Message> messages = Hql.StatelessQuery<Message>(0, count, GetPlayerMessagesQuery(),
                    new KeyValuePair<string, object>[] {
                        Hql.Param("playerId", player.Id),
                        Hql.Param("playerCat", Category.Player.ToString()),
                        Hql.Param("universeCat", Category.Universe.ToString()),
                        Hql.Param("principalId", player.Principal.Id),
                        Hql.Param("principalCat", Category.Principal.ToString()),
                        Hql.Param("allianceId", allianceId),
                        Hql.Param("tick", Clock.Instance.Tick)
                    }
                );
            return messages;
        }

        private static string GetPlayerMessagesQuery() {
            using (TextWriter writer = new StringWriter()) {

                writer.Write(" from SpecializedMessage m ");
                writer.Write(" where ");
                writer.Write(" (m.OwnerId = :playerId and m.Category = :playerCat) ");
                writer.Write(" or ");
                writer.Write(" (m.OwnerId = :playerId and m.Category = :universeCat and m.SubCategory != 'FleetStartMovingMessage') ");
                writer.Write(" or ");
                writer.Write(" (m.OwnerId = :allianceId and m.Category = 'Task' and m.TickDeadline >= :tick) ");
                writer.Write(" or ");
                writer.Write(" (m.OwnerId = :principalId and m.Category = :principalCat) ");
                writer.Write(" order by m.Date desc ");

                return writer.ToString();
            }
        }

        public static string GetSecretCode(IPlayer player)
        {
            string raw = string.Format("{0}-{1}-Assobio", player.Principal.Name, player.Name);
            return FormsAuthentication.HashPasswordForStoringInConfigFile(raw, "sha1");
        }

        #endregion Messages

        #region UI Helper

        public static string ImagesCommonPath {
			get {return "http://resources.orionsbelt.eu/Images/Common";}
		}

        public static string GetAvatar(IPlayer player){
            if (string.IsNullOrEmpty(player.Avatar)){
                return string.Format("{0}/Avatar.png", ImagesCommonPath);
            }
            return player.Avatar;
        }

        internal static string WritePlayerWithAvatar(IPlayer player, bool writeActivityStatus){
            using (TextWriter writer = new StringWriter()) {

                writer.Write("<div class=\"player\">");

                writer.Write("<div><img src=\"{0}\" /></div>", GetAvatar(player));

                writer.Write("<div class=\"nick\">{0}</div>", player.Name);
                if (writeActivityStatus) {
                    ActivityStatus status = GetStatus(player);
                    writer.Write("<div class=\"activityStatus {0}\"></div>", status);
                }

                writer.Write("</div>");

                return writer.ToString();
            }
        }

        #endregion
    };
}
