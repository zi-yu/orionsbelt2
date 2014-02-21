using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Engine.Resources;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Updates the player richeness
    /// </summary>
    public class ResourceConstruction : AutoRepeteAction  {

        #region Ctor & Props
        public ResourceConstruction()
        {
        }

        #endregion Ctor & Props

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Private; }
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            ResourceUtils.CheckCompleted(PlayerUtils.Current);
        }

        #endregion Base Implementation

        #region Static

        private static ITimedAction instance = new ResourceConstruction();
        public static ITimedAction Instance {
            get { return instance;  }
        }

        #endregion Static

    };

}
