using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Does nothing, periodically...
    /// </summary>
    public class AutoRepeatableDoNothing : AutoRepeteAction {

        #region Base Implementation

        private Visibility visibility = Visibility.Public;
        public override Visibility Visibility {
            get { return visibility; }
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Interval += 20;
            Executed = true;
        }

        #endregion Base Implementation

        #region Ctor & Props

        private bool executed = false;
        public bool Executed {
            get { return executed; }
            set { executed = value; }
        }

        public AutoRepeatableDoNothing(int delay, Visibility vis)
        {
            visibility = vis;
            Start(delay);
        }

        public AutoRepeatableDoNothing()
        {
        }

        #endregion Ctor & Props

    };

}


