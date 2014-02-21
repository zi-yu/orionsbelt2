using OrionsBelt.Generic;

namespace OrionsBelt.Engine.Results
{

    /// <summary>
    /// A ResultItem provided by RulesCore
    /// </summary>
    public class NotCredits : ResultItem {

        #region Ctor

        public NotCredits(string message, params string[] args)
        {
            log = message;
            parameters = args;
        }

        public NotCredits()
            : this("Player does not have enough credits.")
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
