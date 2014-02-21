using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans Unit Yard
    /// </summary>
    public class Incubator : BaseBugsFacility {

        #region Properties

        public override string Name {
            get { return "Incubator"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        #endregion Properties

        #region RuleSet

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 6, 2, 0, level);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.075, 2, 0, level);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(Nest), 1, MaxLevel);
        }

        protected override void BuildCostRules()
        {
            //=320*POWER(B2,2)
            Cost.Add(this, typeof(Protol), 0, 0, 320, 2, 0);
            //=450*POWER(B2,2)
            Cost.Add(this, typeof(Elk), 0, 0, 450, 2, 0);
            //=(B2/5)*150*POWER(B2,2)-1500
            Cost.Add(this, typeof(Prismal), 5, 0, 150, 2, 1500);
            //=(B2/4)*120*POWER(B2,2)-9000
            Cost.Add(this, typeof(Astatine), 4, 0, 120, 2, 9000);
            //=(B2/4)*80*POWER(B2,2)-4000
            Cost.Add(this, typeof(Cryptium), 4, 0, 80, 2, 4000);
            //=(B2/5)*200*POWER(B2,2)-26000
            Cost.Add(this, typeof(Radon), 5, 0, 200, 2, 26000);
            //=(B2/8)*120*POWER(B2,2)-12000
            Cost.Add(this, typeof(Argon), 8, 0, 120, 2, 12000);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(Incubator)); }
        }

        #endregion Static Utils

    };

}
