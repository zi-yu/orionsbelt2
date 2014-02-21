using OrionsBelt.Generic;

namespace OrionsBelt.TournamentCore.Results
{

    /// <summary>
    /// A ResultItem provided by RulesCore
    /// </summary>
    public class ArenaConquest : ResultItem {

        #region Ctor

        public ArenaConquest(string message, params string[] args)
        {
            log = message;
            parameters = args;
        }

        #endregion Ctor

        public override bool Ok
        {
            get
            {
                return true;
            }
        }

    };
}
