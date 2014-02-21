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
    public class VacationTimeout : AutoRepeteAction {

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Console.WriteLine(" - Processing Vacation Timeout...");
            IList<Principal> principals = Hql.Query<Principal>("from SpecializedPrincipal where VacationEndtick <= :currTick and VacationEndtick > 0 and IsOnVacations = 1", Hql.Param("currTick", Clock.Instance.Tick));
            if (principals.Count == 0) {
                Console.WriteLine("\tNo principals to update");
                return;
            }
            VacationsManager.ProcessVacationTimeout(principals);
            
        }

        #endregion Base Implementation

    };

}
