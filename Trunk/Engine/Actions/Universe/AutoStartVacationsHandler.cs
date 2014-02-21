using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using System.Collections.Generic;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// AutoStartVacationsHandler
    /// </summary>
    public class AutoStartVacationsHandler : AutoRepeteAction {

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Console.WriteLine(" - Processing Auto Start Vacations...");
            VacationsManager.CheckAutoStartVacations();
            
        }

        #endregion Base Implementation

    };

}
