using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic.Messages;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Game Shop
    /// </summary>
    public static class Shop {

        #region Processing

        private delegate void ProcessPayment(IPlayer player);
        private delegate void ProcessPaymentWithScale(IPlayer player, int scale);
        private static Dictionary<string, ProcessPaymentWithScale> services = new Dictionary<string, ProcessPaymentWithScale>();
        private static Dictionary<string, ProcessPayment> undoServices = new Dictionary<string, ProcessPayment>();
        static Shop()
        {
            services.Add("BuyQueueSpace", BuyQueueSpace);
            undoServices.Add("BuyQueueSpace", UndoBuyQueueSpace);

            services.Add("BuyFastSpeed", BuyFastSpeed);
            undoServices.Add("BuyFastSpeed", UndoBuyFastSpeed);

            services.Add("BuyNoUndiscoveredUniverse", BuyNoUndiscoveredUniverse);
            undoServices.Add("BuyNoUndiscoveredUniverse", UndoBuyNoUndiscoveredUniverse);

            services.Add("BuyFullLineOfSight", BuyFullLineOfSight);
            undoServices.Add("BuyFullLineOfSight", UndoBuyFullLineOfSight);

            services.Add("BuyIntrinsicDeduction", BuyIntrinsicDeduction);
            undoServices.Add("BuyIntrinsicDeduction", UndoBuyIntrinsicDeduction);

            services.Add("BuyRareDeduction", BuyRareDeduction);
            undoServices.Add("BuyRareDeduction", UndoBuyRareDeduction);

			services.Add("BuyFiringSquadGeneral", BuyFiringSquadGeneral);
			undoServices.Add("BuyFiringSquadGeneral", UndoBuyFiringSquadGeneral);

			services.Add("BuyOneStarGeneral", BuyOneStarGeneral);
			undoServices.Add("BuyOneStarGeneral", UndoBuyOneStarGeneral);

            services.Add("BuyChristmasSpecial", BuyChristmasSpecial);
            undoServices.Add("BuyChristmasSpecial", UndoBuyChristmasSpecial);

            services.Add("BuyBirthdaySpecial", BuyBirthdaySpecial);
            undoServices.Add("BuyBirthdaySpecial", UndoBuyBirthdaySpecial);
        }

        public static void ProcessService(IPlayer iPlayer, string data, int scale)
        {
            if (services.ContainsKey(data)) {
                services[data](iPlayer, scale);
            } else {
                throw new EngineException("No service `{0}` at the game shop", data);
            }
        }

        public static void ProcessUndoService(IPlayer iPlayer, string data)
        {
            if (undoServices.ContainsKey(data)) {
                undoServices[data](iPlayer);
            } 
        }

        #endregion Processing

        #region Birthday Special

        public const int BirthdaySpecialScale = -12;
        public const int BirthdaySpecialCost = 1000;

        public static void BuyBirthdaySpecial(IPlayer player, int scale)
        {
            if (DateTime.Now.Month != 1 && DateTime.Now.Day < 14 || DateTime.Now.Day > 31) {
                return;
            }
            if (player.Principal.Credits < BirthdaySpecialCost) {
                return;
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                persistance.StartTransaction();

                GetNonScaledPrincipalOrions(persistance, player.Principal, BirthdaySpecialCost);

                BuyGenericPlayerService(player, BirthdaySpecialCost, ServiceType.BuyBirthdaySpecial, BirthdaySpecialScale, null, null);

                IFleetInfo info = GetBirthdaySpecialFleet();
                IFleetInfo defenseFleet = player.GetHomePlanet().DefenseFleet;
                foreach (IFleetElement elem in info.Units.Values) {
                    defenseFleet.Add(elem.Name, elem.Quantity);
                }
                player.AddQuantity(Argon.Resource, 10000);
                player.AddQuantity(Radon.Resource, 10000);
                player.AddQuantity(Prismal.Resource, 10000);
                player.AddQuantity(Astatine.Resource, 10000);
                player.AddQuantity(Cryptium.Resource, 10000);

                GameEngine.Persist(defenseFleet);
                GameEngine.Persist(player);

                persistance.CommitTransaction();
            }
        }

        public static IFleetInfo GetBirthdaySpecialFleet()
        {
            IFleetInfo fleet = new FleetInfo("BirthdaySpecial");

            fleet.Add("Sentry", 350);
            fleet.Add("Reaper", 200);
            fleet.Add("Scourge", 120);
            fleet.Add("Walker", 120);
            fleet.Add("Titan", 60);

            return fleet;
        }

        public static void UndoBuyChristmasSpecial(IPlayer player)
        {
            UndoGenericPlayerService(player, ServiceType.BuyBirthdaySpecial, null, null);
        }

        #endregion Buy Birthday Special

        #region Christmas Special

        public const int ChristmasSpecialScale = -12;
        public const int ChristmasSpecialCost = 1500;

        public static void BuyChristmasSpecial(IPlayer player, int scale)
        {
            if (DateTime.Now.Month != 12) {
                return;
            }
            if (player.Principal.Credits < ChristmasSpecialCost) {
                return;
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                persistance.StartTransaction();

                GetNonScaledPrincipalOrions(persistance, player.Principal, ChristmasSpecialCost);

                BuyGenericPlayerService(player, ChristmasSpecialCost, ServiceType.BuyChristmasSpecial, ChristmasSpecialScale, null, null);

                PrepareService(player, ServiceType.BuyRareDeduction);
                PrepareService(player, ServiceType.BuyIntrinsicDeduction);
                PrepareService(player, ServiceType.BuyFastSpeed);
                PrepareService(player, ServiceType.BuyFullLineOfSight);
                PrepareService(player, ServiceType.BuyNoUndiscoveredUniverse);
                PrepareService(player, ServiceType.BuyQueueSpace);

                IFleetInfo info = GetChristmasSpecialFleet();
                IFleetInfo defenseFleet = player.GetHomePlanet().DefenseFleet;
                foreach( IFleetElement elem in info.Units.Values ) {
                    defenseFleet.Add(elem.Name, elem.Quantity);
                }

                GameEngine.Persist(defenseFleet);
                GameEngine.Persist(player);

                persistance.CommitTransaction();
            }
        }

        public static IFleetInfo GetChristmasSpecialFleet()
        {
            IFleetInfo fleet = new FleetInfo("ChristmasSpecial");

            fleet.Add("Sentry", 150);
            fleet.Add("Reaper", 100);
            fleet.Add("Scourge", 60);
            fleet.Add("Walker", 60);
            fleet.Add("Titan", 30);

            return fleet;
        }

        private static void PrepareService(IPlayer player, ServiceType type)
        {
            ITimedAction action = GetActionForService(player, type);
            if (action == null) {
                services[type.ToString()](player, ChristmasSpecialScale);
            } else {
                int endTick = GetEndTick(ChristmasSpecialScale);
                int currTick = Clock.Instance.Tick;
                int currDuration = action.EndTick - currTick;
                action.EndTick = endTick + currDuration;
                action.Touch();
                GameEngine.Persist(action);
            }
        }

        private static ITimedAction GetActionForService(IPlayer player, ServiceType serviceType)
        {
            if(!HasActionsFromBD(player) ) {
                using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                    foreach (TimedActionStorage storage in persistance.SelectByPlayer(player.Storage)) {
                        player.Actions.Add(ActionConversion.ConvertStorageToAction(storage));
                    }
                }
            }
            foreach (ITimedAction action in player.Actions) {
                if (action.Data == serviceType.ToString()) {
                    return action;
                }
            }
            return null;
        }

        private static bool HasActionsFromBD(IPlayer player)
        {
            foreach (ITimedAction action in player.Actions) {
                if (action.IsPersistable) {
                    return true;
                }
            }
            return false;
        }

        public static void UndoBuyBirthdaySpecial(IPlayer player)
        {
            UndoGenericPlayerService(player, ServiceType.BuyChristmasSpecial, null, null);
        }

        #endregion Buy Christmas Special

        #region Buy Deduction

        public const int BuyRareDeductionCost = 400;
        public const int BuyIntrinsicDeductionCost = 400;

        public static void BuyRareDeduction(IPlayer player, int scale)
        {
            BuyGenericPlayerService(player, BuyRareDeductionCost, ServiceType.BuyRareDeduction, scale, new BuyRareDeductionSuccessMessage(player.Id), null);
        }

        public static void UndoBuyRareDeduction(IPlayer player)
        {
            UndoGenericPlayerService(player, ServiceType.BuyRareDeduction, new BuyRareDeductionEndMessage(player.Id),null);
        }

        public static void BuyIntrinsicDeduction(IPlayer player, int scale)
        {
            BuyGenericPlayerService(player, BuyIntrinsicDeductionCost, ServiceType.BuyIntrinsicDeduction, scale, new BuyIntrinsicDeductionSuccessMessage(player.Id), null);
        }

        public static void UndoBuyIntrinsicDeduction(IPlayer player)
        {
            UndoGenericPlayerService(player, ServiceType.BuyIntrinsicDeduction, new BuyIntrinsicDeductionEndMessage(player.Id), null);
        }

        #endregion Buy Deduction

        #region BuyQueueSpace

        public const int BuyQueueSpaceCost = 100;
        public const int BuyQueueSpaceQuantity = 3;

        public static void BuyQueueSpace(IPlayer player, int scale)
        {
            if (player.Principal.Credits < GetCost(BuyQueueSpaceCost, scale)) {
                return;
            }
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                persistance.StartTransaction();

                TimedActionStorage storage = persistance.Create();
                storage.Player = player.Storage;
                storage.Name = typeof(ShopTimeout).Name;
                storage.Data = "BuyQueueSpace";
                storage.EndTick = GetEndTick(scale);
                persistance.Update(storage);

                player.AddQuantity(QueueSpace.Resource, BuyQueueSpaceQuantity);
                UpdatePlayer(persistance, player);

                GetPrincipalOrions(persistance, player.Principal, BuyQueueSpaceCost, scale);
                TransactionManager.ServiceTransaction(player, ServiceType.BuyQueueSpace, GetCost(BuyQueueSpaceCost, scale), persistance);
                Messenger.Add(new BuyQueueSpaceSuccessMessage(player.Id), persistance);

                persistance.CommitTransaction();
            }
        }

        public static void UndoBuyQueueSpace(IPlayer player)
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                persistance.StartTransaction();

                player.AddQuantity(QueueSpace.Resource, BuyQueueSpaceQuantity * -1);
                UpdatePlayer(persistance, player);
                Messenger.Add(new BuyQueueSpaceOverMessage(player.Id), persistance);

                persistance.CommitTransaction();
            }
        }

        #endregion BuyQueueSpace

        #region BuyFastSpeed

        public const int BuyFastSpeedCost = 200;

        public static void BuyFastSpeed(IPlayer player, int scale)
        {
            BuyGenericPlayerService(player, BuyFastSpeedCost, ServiceType.BuyFastSpeed, scale, new BuyFastSpeedSuccessMessage(player.Id), null);
        }

        public static void UndoBuyFastSpeed(IPlayer player)
        {
            UndoGenericPlayerService(player, ServiceType.BuyFastSpeed, new BuyFastSpeedEndMessage(player.Id), null);
        }

        #endregion BuyFastSpeed

        #region BuyFullLineOfSight

        public const int BuyFullLineOfSightCost = 300;

        public static void BuyFullLineOfSight(IPlayer player, int scale)
        {
            BuyGenericPlayerService(player, BuyFullLineOfSightCost, ServiceType.BuyFullLineOfSight, scale, new BuyFullLineOfSightSuccessMessage(player.Id), null);
        }

        public static void UndoBuyFullLineOfSight(IPlayer player)
        {
            UndoGenericPlayerService(player, ServiceType.BuyFullLineOfSight, new BuyFullLineOfSightEndMessage(player.Id), null);
        }

        #endregion BuyFullLineOfSight

        #region BuyFullLineOfSight

        public const int BuyNoUndiscoveredUniverseCost = 800;

        public static void BuyNoUndiscoveredUniverse(IPlayer player, int scale)
        {
            BuyGenericPlayerService(player, BuyNoUndiscoveredUniverseCost, ServiceType.BuyNoUndiscoveredUniverse, scale, new BuyNoUndiscoveredUniverseSuccessMessage(player.Id), null);
        }

        public static void UndoBuyNoUndiscoveredUniverse(IPlayer player)
        {
            UndoGenericPlayerService(player, ServiceType.BuyNoUndiscoveredUniverse, new BuyNoUndiscoveredUniverseEndMessage(player.Id), null);
        }

        #endregion BuyFullLineOfSight

		#region BuyFiringSquadGeneral

		public const int BuyFiringSquadGeneralCost = 15;

		public static void BuyFiringSquadGeneral(IPlayer player, int scale) {
			BuyGeneral(player, BuyNoUndiscoveredUniverseCost, ServiceType.BuyFiringSquadGeneral, scale, new BuyFiringSquadGeneralSuccessMessage(player.Id), Generals.FiringSquadGeneral);
		}

		public static void UndoBuyFiringSquadGeneral(IPlayer player) {
			UndoBuyGeneral(player, ServiceType.BuyFiringSquadGeneral, new BuyFiringSquadGeneralEndMessage(player.Id),Generals.FiringSquadGeneral);
		}

		#endregion BuyFiringSquadGeneral

		#region BuyOneStarGeneral

		public const int BuyOneStarGeneralCost = 60;

		public static void BuyOneStarGeneral(IPlayer player, int scale) {
			BuyGeneral(player, BuyOneStarGeneralCost, ServiceType.BuyOneStarGeneral, scale, new BuyOneStarGeneralSuccessMessage(player.Id),Generals.OneStarGeneral);
		}

		public static void UndoBuyOneStarGeneral(IPlayer player) {
			UndoBuyGeneral(player, ServiceType.BuyFiringSquadGeneral, new BuyOneStarGeneralEndMessage(player.Id),Generals.OneStarGeneral);
		}

		#endregion BuyOneStarGeneral

		#region Utils

		private static void BuyGenericPlayerService(IPlayer player, int cost, ServiceType type, int scale, IMessage successMessage, ProcessPayment logic)
        {
            if (player.Principal.Credits < GetCost(cost, scale)) {
                return;
            }
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                persistance.StartTransaction();

                TimedActionStorage storage = persistance.Create();
                storage.Player = player.Storage;
                storage.Name = typeof(ShopTimeout).Name;
                storage.Data = type.ToString();
                storage.EndTick = GetEndTick(scale);
                persistance.Update(storage);

                player.AddService(type);
                if (logic != null) {
                    logic(player);
                }
                UpdatePlayer(persistance, player);

                GetPrincipalOrions(persistance, player.Principal, cost, scale);
                if (type == ServiceType.BuyChristmasSpecial)
                {
                    TransactionManager.ServiceTransaction(player, type, ChristmasSpecialCost, persistance);
                }
                else
                {
                    TransactionManager.ServiceTransaction(player, type, GetCost(cost, scale), persistance);
                }
                    if (successMessage != null) {
                    Messenger.Add(successMessage, persistance);
                }

                persistance.CommitTransaction();
            }
        }

        private static int GetEndTick(int scale)
        {
            int days = 30;
            if (scale == 1) {
                days = 10;
            }
            if (scale == ChristmasSpecialScale) {
                days = 30 * 6;

            }
            return Clock.Instance.Tick + Clock.Instance.ConvertToTicks(TimeSpan.FromDays(days));
        }

        private static void UndoGenericPlayerService(IPlayer player, ServiceType type, IMessage message, ProcessPayment logic)
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance())
            {
                persistance.StartTransaction();

                player.RemoveService(type);
                if (logic != null) {
                    logic(player);
                }
                UpdatePlayer(persistance, player);
                if (message != null) {
                    Messenger.Add(message, persistance);
                }

                persistance.CommitTransaction();
            }
        }

        private static void GetPrincipalOrions(IPersistanceSession session, Principal principal, int cost, int scale)
        {
            cost = GetCost(cost, scale);
            GetNonScaledPrincipalOrions(session, principal, cost);
        }

        private static void GetNonScaledPrincipalOrions(IPersistanceSession session, Principal principal, int cost)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance(session))
            {
                principal.Credits -= cost;
                persistance.Update(principal);
            }
        }

        public static int GetCost(int c, int scale)
        {
            if (scale == ChristmasSpecialScale) {
                return 0;
            }

            if (scale == 3) {
                return c;
            }

            double cost = c;
            cost = Math.Ceiling(cost / 3 + cost / 10);
            cost = Math.Round(cost / 10) * 10;
            return Convert.ToInt32(cost);
        }

        private static void UpdatePlayer(IPersistanceSession session, IPlayer player)
        {
            player.UpdateStorage();
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance(session)) {
                persistance.Update(player.Storage);
            }
        }

		#region Generals Utils

		private static void BuyGeneral(IPlayer player, int cost, ServiceType type, int scale, IMessage successMessage, Principal general) {
			if (player.Principal.Credits < GetCost(BuyQueueSpaceCost, scale)) {
				return;
			}
			using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
				persistance.StartTransaction();

				TimedActionStorage storage = persistance.Create();
				storage.Player = player.Storage;
				storage.Name = typeof(ShopTimeout).Name;
				storage.Data = type.ToString();
				storage.EndTick = GetEndTick(scale);
				persistance.Update(storage);

				player.GeneralId = general.Id;
				player.GeneralName = general.Name;
				player.GeneralFriendlyName = general.Name;

				UpdatePlayer(persistance, player);

				GetPrincipalOrions(persistance, player.Principal, cost, scale);
				TransactionManager.ServiceTransaction(player, type, GetCost(cost, scale), persistance);
				Messenger.Add(successMessage);

				persistance.CommitTransaction();
			}
		}

		private static void UndoBuyGeneral(IPlayer player, ServiceType type, IMessage message, Principal general) {
			using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
				persistance.StartTransaction();

				player.RemoveService(type);

				if (general.Name.Equals(player.GeneralName)){
					player.GeneralId = 0;
					player.GeneralName = string.Empty;
					player.GeneralFriendlyName = string.Empty;
				}
				
				UpdatePlayer(persistance, player);
				Messenger.Add(message, persistance);

				persistance.CommitTransaction();
			}
		}

		#endregion Generals Utils

        #endregion Utils

    };
}
