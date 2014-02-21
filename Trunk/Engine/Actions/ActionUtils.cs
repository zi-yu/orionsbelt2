using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Generic;
using DesignPatterns;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Resources;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Some Action's utility methods
    /// </summary>
    public static class ActionUtils {

        #region Action Factories

        public static TimedAction GetActionByName(string actionName)
        {
            if (!actionFactories.ContainsKey(actionName)) {
                throw new EngineException("No Action with `{0}' key found", actionName);
            }
            return (TimedAction)actionFactories.create(actionName);
        }

        private static readonly FactoryContainer actionFactories = new FactoryContainer(typeof(TimedAction));

        public static IEnumerable<IFactory> GetActionFactories()
        {
            foreach (IFactory factory in actionFactories.Values) {
                yield return factory;
            }
        }

        #endregion Action Factories

        #region Specific Action Registering

		public static BattleTimeout RegisterBattleTimeout( int battleId, int delay )
        {
            BattleTimeout timeout = new BattleTimeout(battleId, delay);
            Register(timeout);
        	return timeout;
        }

		public static FleetMovement RegisterFleetMovement() {
			FleetMovement move = new FleetMovement();
			using( ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance() ) {
				IList<TimedActionStorage> list = persistance.SelectByName("FleetMovement");
				if( list.Count == 0 ) {
					Register(move);
				}
			}
			return move;
		}

        internal static void RegisterResourceConstruction(IPlanetResource resource)
        {
            IPlayer player = ResourceUtils.GetPlayer(resource);
            int duration = ResourceUtils.GetDuration(resource);
            resource.EndTick = player.LastProcessedTick + duration;
        }

        public static void Register(ITimedAction action)
        {
            TimedActionStorage storage = ActionConversion.ConvertActionToStorage(action);
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                persistance.Update(storage);
            }
        }

        public static void Register(IPlayer player, ITimedAction action)
        {
            player.RegisterAction(action);
            if (!action.IsPersistable){
                return;
            }
            TimedActionStorage storage = ActionConversion.ConvertActionToStorage(action);

            storage.Player = player.Storage;
            player.Storage.Actions.Add(storage);

            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                persistance.Update(storage);
            }
        }

        #endregion Specific Action Registering

        #region Action Queries

        internal static IList<TimedActionStorage> GetActionsToRun(Visibility visibility)
        {
            string visQuery = GetVisibilityQueryPart(visibility);
			string hql = string.Format("select action from SpecializedTimedActionStorage action where action.EndTick > 0 and action.EndTick <= {0} and {1}", Clock.Instance.Tick, visQuery);
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                return persistance.TypedQuery(hql);
            }
        }

        private static string GetVisibilityQueryPart(Visibility visibility)
        {
            if (visibility == Visibility.Private) {
                return "action.PlayerNHibernate is not null";
            }

            if (visibility == Visibility.Public) {
                return "action.PlayerNHibernate is null";
            }

            throw new EngineException("Don't know how to handle `{0}'", visibility);
        }

        internal static void DeleteAction(int id)
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                DeleteAction(persistance, id);
            }
        }

        internal static void DeleteAction(ITimedActionStoragePersistance persistance, int id)
        {
            persistance.Delete(id);
        }

        internal static void PersistAction(TimedActionStorage storage)
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                PersistAction(persistance, storage);
            }
        }

        internal static void PersistAction(ITimedActionStoragePersistance persistance, TimedActionStorage storage)
        {
            persistance.Update(storage);
        }

        internal static TimedActionStorage GetActionStorage(string actionName, string actionData)
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                string hql = string.Format("select action from SpecializedTimedActionStorage action where action.ActionName = '{0}' and action.ActionData = {1}", actionName, actionData);
                IList<TimedActionStorage> list = persistance.TypedQuery(hql);
                if (list.Count == 0) {
                    throw new EngineException("No TimedAction `{0}' with data `{0}' found", actionName, actionData);
                }
                return list[0];
            }
        }

        internal static bool IsToRun(ITimedAction action, int tick)
        {
            return tick >= action.EndTick && !action.Ended;
        }

        #endregion Action Queries

    };
}
