using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Actions;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Converts TimedActionStorage to/from ITimedAction
    /// </summary>
    public static class ActionConversion {

        #region Load/Store Utilities

        public static ITimedAction ConvertStorageToAction(TimedActionStorage storage)
        {
            ITimedAction action = ActionUtils.GetActionByName(storage.Name);

            action.Storage = storage;
            action.Data = storage.Data;
            action.StartTick = storage.StartTick;
            action.EndTick = storage.EndTick;

            return action;
        }

        public static TimedActionStorage ConvertActionToStorage(ITimedAction action)
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance())
            {
                TimedActionStorage storage = persistance.Create();
                SetStorage(storage, action);
                return storage;
            }
        }

        public static void SetStorage(TimedActionStorage storage, ITimedAction action)
        {
            action.Storage = storage;

            storage.Name = action.Name;
            storage.Data = action.Data;
            storage.StartTick = action.StartTick;
            storage.EndTick = action.EndTick;

            action.IsDirty = false;
        }

        public static void SetAction(TimedAction action, TimedActionStorage storage)
        {
            action.Data = storage.Data;
            action.StartTick = storage.StartTick;
            action.EndTick = storage.EndTick;
        }

        #endregion Load/Store Utilities

    };

}
