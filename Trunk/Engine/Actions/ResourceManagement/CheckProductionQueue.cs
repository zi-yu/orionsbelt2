using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Updates the player richeness
    /// </summary>
    public class CheckProductionQueue : AutoRepeteAction  {

        #region Ctor

        public CheckProductionQueue()
        {
            Interval = 1;
        }

        #endregion Ctor

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Private; }
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            ResourceUtils.CheckProductionQueue(PlayerUtils.Current);
        }

        #endregion Base Implementation

        #region Static

        private static ITimedAction instance = new CheckProductionQueue();
        public static ITimedAction Instance{
            get { return instance; }
        }

        #endregion Static

    };

}
