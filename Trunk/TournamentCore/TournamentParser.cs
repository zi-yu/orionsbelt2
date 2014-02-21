using System;

namespace OrionsBelt.TournamentCore
{
    public class TournamentParser
    {
        #region public methods

        /// <summary>
        /// Creates a new tournament
        /// </summary>
        /// <param name="representation">Type of tournament representation. e.g.:type=Regicide;mode=Survival,TwoVsTwo,Public</param>
        /// <returns>True if is a valid tournament, false if not.</returns>
        public static bool IsValidTournament(string representation)
        {
            try
            {
                if (String.IsNullOrEmpty(representation))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion public methods
    }
}