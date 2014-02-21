using OrionsBelt.Generic;

namespace OrionsBelt.Engine.Results
{

    /// <summary>
    /// A ResultItem provided by RulesCore
    /// </summary>
    public class InvalidProduct : ResultItem {

        #region Ctor

        public InvalidProduct(string message, params string[] args)
        {
            log = message;
            parameters = args;
        }

        #endregion Ctor

        public override bool Ok
        {
            get
            {
                return false;
            }
        }

    };
}
