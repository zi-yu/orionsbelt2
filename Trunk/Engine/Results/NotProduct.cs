using OrionsBelt.Generic;

namespace OrionsBelt.Engine.Results
{

    /// <summary>
    /// A ResultItem provided by RulesCore
    /// </summary>
    public class NotProduct : ResultItem {

        #region Ctor

        public NotProduct(string message, params string[] args)
        {
            log = message;
            parameters = args;
        }

        public NotProduct()
            : this("Not enough product quantity.")
        {

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
