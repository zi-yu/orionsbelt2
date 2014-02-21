using System;
using System.IO;
using DesignPatterns;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;
using OrionsBelt.Generic;

namespace OrionsBelt.Engine.Metrics {

    /// <summary>
    /// Represents an object that logs generic metrics
    /// </summary>
    public class Generic : Loki.Generic.Metrics.Metrics {

        #region Metrics Implementation

        protected override void WriteMetrics(TextWriter writer)
        {
            WriteValue(writer, "Tick", Clock.Instance.Tick);
            WriteQuests(writer);
        }

        #endregion Metrics Implementation

        #region Quests

        private void WriteQuests(TextWriter writer)
        {
            using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {
                long open = persistance.ExecuteScalar("select count(quest) from SpecializedQuestStorage quest where quest.IsTemplate = true");
                long current = persistance.ExecuteScalar("select count(quest) from SpecializedQuestStorage quest where quest.IsTemplate = false and quest.Completed = false");

                WriteValue(writer, "TemplateQuests", open);
                WriteValue(writer, "RunningQuests", current);
            }
        }

        #endregion Quests

    };

}
