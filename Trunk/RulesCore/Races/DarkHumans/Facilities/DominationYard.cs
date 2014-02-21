using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans Unit Yard
    /// </summary>
    public class DominationYard : BaseDarkHumansFacility {

        #region Properties

        public override string Name {
            get { return "DominationYard"; }
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
            Dependency.Add(this, 1, typeof(DarknessHall), 1, MaxLevel);
        }

        protected override void BuildCostRules()
        {
            //=(B2/4)*240*POWER(B2,2)-2500
            Cost.Add(this, typeof(Uranium), 4, 0, 240, 2, 2500);
            //=380*POWER(B2,2)
            Cost.Add(this, typeof(Titanium), 0, 0, 380, 2, 0);
            //=350*POWER(B2,2)
            Cost.Add(this, typeof(Gold), 0, 0, 350, 2, 0);

            //=260*POWER(B2,2)-2500
            Cost.Add(this, typeof(Cryptium), 0, 0, 260, 2, 2500);
            //=(B2/8)*150*POWER(B2,2)-1500
            Cost.Add(this, typeof(Argon), 8, 0, 150, 2, 1500);
            //=(B2/6)*120*POWER(B2,2)-5000
            Cost.Add(this, typeof(Radon), 6, 0, 120, 2, 5000);
            //=(B2/6)*120*POWER(B2,2)-9000
            Cost.Add(this, typeof(Astatine), 6, 0, 120, 2, 9000);
            //=(B2/8)*120*POWER(B2,2)-10000
            Cost.Add(this, typeof(Prismal), 8, 0, 120, 2, 10000);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(DominationYard)); }
        }

        #endregion Static Utils

    };

}
