using System;
using OrionsBelt.Core;

namespace OrionsBelt.Generic
{
    public class GroupPlayer : IComparable<GroupPlayer>
    {
        #region Private Fields

        private PrincipalTournament player;
        private int points;
        private int wins;
        private int losses;

        #endregion Private Fields

        #region Properties

        public PrincipalTournament Player
        {
            get { return player; }
        }

        public int Points
        {
            get { return points; }
        }

        public int Wins
        {
            get { return wins; }
            set { wins = value; }
        }

        public int Losses
        {
            get { return losses; }
            set { losses = value; }
        }

        #endregion Properties

        #region Ctor

        public GroupPlayer (PrincipalTournament principal, int stage, int playersInGroup)
        {
            player = principal;
            foreach(GroupPointsStorage point in principal.Points)
            {
                if(point.Stage == stage)
                {
                    points = point.Pontuation / playersInGroup;
                    losses = point.Losses;
                    wins = point.Wins;
                    return;
                }
            }
            throw new Exception(string.Format("The stage {0} is not a valid stage", stage));
        }

        #endregion Ctor


        #region IComparable<GroupPlayer> Members

        int IComparable<GroupPlayer>.CompareTo(GroupPlayer other)
        {
            return -1*(this.points - other.points);
        }

        #endregion
    }
}
