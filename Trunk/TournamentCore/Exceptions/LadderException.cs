using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;

namespace OrionsBelt.TournamentCore.Exceptions
{
    public class LadderException: TournamentException
    {
        /// <summary>
        /// LadderException constructor
        /// </summary>
        /// <param name="info">LadderInfo that is not valid</param>
        public LadderException(Principal info)
            : base(String.Format("Principal with id={0}, is in battle = {1}, is active = {2}", info.Id, info.LadderActive,info.IsInBattle)) { }

        /// <summary>
        /// LadderException constructor
        /// </summary>
        /// <param name="info">LadderInfo that is not valid</param>
        public LadderException(TeamStorage info)
            : base(String.Format("Principal with id={0}, is in battle = {1}, is active = {2}", info.Id, info.LadderActive, info.IsInBattle)) { }


        /// <summary>
        /// LadderException constructor
        /// </summary>
        /// <param name="expected">Max distance</param>
        /// <param name="had">Distance</param>
        public LadderException(int expected, long had)
            : base(String.Format("Max distance between players = {0}; tryed distance = {1}", expected, had)) { }

        /// <summary>
        /// LadderException constructor
        /// </summary>
        /// <param name="info">LadderInfo whit que exception information</param>
        /// <param name="isInFront">True if player is in a better position</param>
        public LadderException(Principal info, bool isInFront)
            : base(String.Format("At the time({3}), principal: {0}, is in front: {4}. Can't be attacked until: {1}, can't attack until: {2}.",info.Id, info.RestUntil, info.StoppedUntil,DateTime.Now, isInFront)) { }

        /// <summary>
        /// LadderException constructor
        /// </summary>
        /// <param name="info">LadderInfo whit que exception information</param>
        /// <param name="isInFront">True if player is in a better position</param>
        public LadderException(TeamStorage info, bool isInFront)
            : base(String.Format("At the time({3}), principal: {0}, is in front: {4}. Can't be attacked until: {1}, can't attack until: {2}.", info.Id, info.RestUntil, info.StoppedUntil, DateTime.Now, isInFront)) { }

    }
}
