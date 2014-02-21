using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Does nothing
    /// </summary>
    public class DoNothing : OneTimeAction {

        #region Base Implementation

        private Visibility visibility;
        public override Visibility Visibility {
            get { return visibility; }
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Executed = true;
        }

        #endregion Base Implementation

        #region Ctor & Props

        private bool executed = false;
        public bool Executed {
            get { return executed; }
            set { executed = value; }
        }

        public DoNothing(int delay, Visibility vis)
        {
            visibility = vis;
            Start(delay);
        }

        public DoNothing()
        {
        }

        #endregion Ctor & Props

    };

}


