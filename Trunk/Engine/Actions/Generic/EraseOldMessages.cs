using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using System.Collections.Generic;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Vacation Timeout
    /// </summary>
    public class EraseOldMessages : AutoRepeteAction {

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        public EraseOldMessages()
        {
            Interval = 144;
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Console.WriteLine(" - Deleting old messages...");
            using (IMessagePersistance persistance = Persistance.Instance.GetMessagePersistance()) {
                int deleted = persistance.Delete("from SpecializedMessage m where m.CreatedDate < '{0}'", (DateTime.Now.AddDays(-15)).ToString("yyyy-MM-dd hh:mm:ss"));
                persistance.Flush();
                Console.WriteLine("\tDeleted {0} messages", deleted);
            }
            
        }

        #endregion Base Implementation

    };

}
