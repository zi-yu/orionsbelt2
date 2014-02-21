using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using System.Collections.Generic;
using OrionsBelt.Engine.Resources;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Shop Service Timeout
    /// </summary>
    public class ShopTimeout : OneTimeAction {

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Console.WriteLine(" - Removing service {0} from player {1}...", Storage.Data, Storage.Player.Name);
            Shop.ProcessUndoService(new Player(Storage.Player), Storage.Data);
        }

        #endregion Base Implementation

    };

}
