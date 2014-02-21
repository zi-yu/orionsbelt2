using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Humans Silo
    /// </summary>
    public class Silo : BaseHumansFacility {

        #region Properties

        public override string Name {
            get { return "Silo"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        #endregion Properties

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(CommandCenter), 2);
            Dependency.Add(this, 2, typeof(CommandCenter), 2, MaxLevel);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 2, 2, 0, level);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.04, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=(B2/4)*120*POWER(B2,2)-(120/4)-500
            //=(B2/4)*120*POWER(B2,2)
            //=200*POWER(B2,2)
            Cost.Add(this, typeof(Mithril), 4, 4, 120, 2, 500);
            Cost.Add(this, typeof(Serium), 4, 0, 120, 2, 0);
            Cost.Add(this, typeof(Energy), 0, 0, 200, 2, 0);

            //=120*POWER(B2,2)-1000
            Cost.Add(this, typeof(Argon), 0, 0, 120, 2, 1000);
            //=(B2/8)*80*POWER(B2,2)-3000
            Cost.Add(this, typeof(Prismal), 8, 0, 80, 2, 3000);
            //=80*POWER(B2,2)-1300
            Cost.Add(this, typeof(Radon), 0, 0, 80, 2, 1300);
            //=(B2/8)*120*POWER(B2,2)-7000
            Cost.Add(this, typeof(Astatine), 8, 0, 120, 2, 7000);
            //=(B2/8)*100*POWER(B2,2)-9000
            Cost.Add(this, typeof(Cryptium), 8, 0, 100, 2, 9000);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToLimit.Add(this);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(Silo)); }
        }

        #endregion Static Utils

    };

}
