using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Engine.Quests;
using System.IO;
using OrionsBelt.Engine.Resources;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Converts QuestStorage to/from IQuestData
    /// </summary>
    public static class QuestConversion {

        #region Load/Store Utilities

        public static IList<IQuestData> ConvertStorageToQuest(IEnumerable<QuestStorage> storages)
        {
            List<IQuestData> datas = new List<IQuestData>();

            foreach (QuestStorage storage in storages) {
                datas.Add(ConvertStorageToQuest(storage));
            }

            return datas;
        }

        public static IQuestData ConvertStorageToQuest(QuestStorage storage)
        {
            QuestData data = new QuestData();

            SetQuest(storage, data);

            return data;
        }

        public static QuestStorage ConvertQuestToStorage(IQuestData quest)
        {
            using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance())
            {
                QuestStorage storage = persistance.Create();
                SetStorage(storage, quest);
                return storage;
            }
        }

        public static void SetStorage(QuestStorage storage, IQuestData quest)
        {
            quest.Storage = storage;

            storage.DeadlineTick = quest.DeadlineTick;
            storage.StartTick = quest.StartTick;
            storage.IsTemplate = quest.IsTemplate;
            storage.Name = quest.Name;
            storage.IsProgressive = quest.IsProgressive;
            storage.Completed = quest.Completed;
            if (quest.Info != null){
                storage.Type = quest.Info.Name;
            }
            storage.Percentage = quest.Percentage;

            storage.Reward = ConvertRewardToString(quest.Reward);
            storage.QuestIntConfig = ConvertIntDicTostring(quest.QuestIntConfig);
            storage.QuestIntProgress = ConvertIntDicTostring(quest.QuestIntProgress);
            storage.QuestStringConfig = ConvertStringDicTostring(quest.QuestStringConfig);
            storage.QuestStringProgress = ConvertStringDicTostring(quest.QuestStringProgress);

            if (quest.Player != null){
                quest.Player.PrepareStorage();
                storage.Player = quest.Player.Storage;
            } else {
                storage.Player = null;
            }
        }

        public static string ConvertIntDicTostring(Dictionary<string, int> dictionary)
        {
            using (TextWriter writer = new StringWriter()) {
                foreach (KeyValuePair<string, int> pair in dictionary) {
                    writer.Write("{0}:{1};", pair.Key, pair.Value);
                }

                return writer.ToString();
            }
        }

        public static string ConvertStringDicTostring(Dictionary<string, string> dictionary)
        {
            using (TextWriter writer = new StringWriter()) {

                foreach (KeyValuePair<string, string> pair in dictionary) {
                    writer.Write("{0}:{1};", pair.Key, pair.Value);
                }

                return writer.ToString();
            }
        }

        public static string ConvertRewardToString(Dictionary<IResourceInfo, int> dictionary)
        {
            return PlanetConversion.ModifiersRepresentation(dictionary);
        }

        private static void SetQuest(QuestStorage storage, IQuestData quest)
        {
            quest.Storage = storage;

            quest.DeadlineTick = storage.DeadlineTick;
            quest.StartTick = storage.StartTick;
            quest.IsProgressive = storage.IsProgressive;
            quest.IsTemplate = storage.IsTemplate;
            quest.Name = storage.Name;
            if (!string.IsNullOrEmpty(storage.Type)) {
                quest.Info = QuestManager.GetQuestType(storage.Type);
            }
            quest.Percentage = storage.Percentage;

            quest.Reward = ConvertRewardToDic(storage.Reward);
            quest.Completed = storage.Completed;
            quest.QuestIntConfig = ConvertIntDicToDic(storage.QuestIntConfig);
            quest.QuestIntProgress = ConvertIntDicToDic(storage.QuestIntProgress);
            quest.QuestStringConfig = ConvertStringDicToDic(storage.QuestStringConfig);
            quest.QuestStringProgress = ConvertStringDicToDic(storage.QuestStringProgress);
            if (storage.Player != null) {
                quest.Player = PlayerUtils.LoadPlayer(storage.Player);
            }

            quest.IsDirty = false;
        }

        public static Dictionary<IResourceInfo, int> ConvertRewardToDic(string raw)
        {
            return PlanetConversion.ParseModifiers(raw);
        }

        public static Dictionary<string, int> ConvertIntDicToDic(string raw)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            if (string.IsNullOrEmpty(raw)){
                return dic;
            }

            string[] data = raw.Split(PlanetConversion.ResourceSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string rawItem in data) {
                string[] parts = rawItem.Split(PlanetConversion.ModSeparator, StringSplitOptions.RemoveEmptyEntries);
                int value = int.Parse(parts[1]);
                dic[parts[0]] = value;
            }

            return dic;
        }

        public static Dictionary<string, string> ConvertStringDicToDic(string raw)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(raw)){
                return dic;
            }

            string[] data = raw.Split(PlanetConversion.ResourceSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string rawItem in data) {
                string[] parts = rawItem.Split(PlanetConversion.ModSeparator, StringSplitOptions.RemoveEmptyEntries);
                dic[parts[0]] = parts[1];
            }

            return dic;
        }

        #endregion Load/Store Utilities

    };

}
