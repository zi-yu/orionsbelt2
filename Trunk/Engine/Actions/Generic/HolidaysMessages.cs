using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using System.Collections.Generic;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Vacation Timeout
    /// </summary>
    public class HolidaysMessages : AutoRepeteAction {

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        public HolidaysMessages()
        {
            Interval = 144;
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Console.WriteLine(" - Checking Holidays...");
            if (DateTime.Now.Day == 24 && DateTime.Now.Month == 12) {
                Console.WriteLine("\tIt's christmas!");
                Messenger.Add(new MerryChristmasAndHappyNewYear());
            }
            Persistance.Flush();
        }

        #endregion Base Implementation

    };

}
