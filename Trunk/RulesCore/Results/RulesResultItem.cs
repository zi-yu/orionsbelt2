using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A ResultItem provided by RulesCore
    /// </summary>
    public class RulesResultItem : ResultItem {

        #region Ctor

        public RulesResultItem(string message, params string[] args)
        {
            log = message;
            parameters = args;
        }

        #endregion Ctor

    };
}
