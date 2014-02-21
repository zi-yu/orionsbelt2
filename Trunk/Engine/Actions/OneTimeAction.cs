using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Action that executes only one time
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class OneTimeAction : TimedAction {

        #region TimedAction Implementation

        public override Occurrence Occurrence {
            get { return Occurrence.OneTime; }
        }

        #endregion TimedAction Implementation

    };
}
