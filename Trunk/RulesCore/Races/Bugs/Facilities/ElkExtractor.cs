using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("ElkExtractor")]
    public class ElkExtractor : BaseBugsFacility {

        #region Properties

        public override string Name {
            get { return "ElkExtractor"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        public override bool CanAcumulate {
            get {
                return false;
            }
        }

        #endregion Properties

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(ElkExtractor)); }
        }

        #endregion Static Utils

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(Nest), 1, MaxLevel);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 6, 2, 0, level);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Elk.Resource, 1);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.054, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=250*POWER(B2,2)
            Cost.Add(this, typeof(Protol), 0, 0, 250, 2, 0);
            //=38*POWER(B2,2)
            Cost.Add(this, typeof(Elk), 0, 0, 38, 2, 0);

            //=100*POWER(B2,2)-2000
            Cost.Add(this, typeof(Prismal), 0, 0, 100, 2, 2000);
            //=(B2/8)*60*POWER(B2,2)-2000
            Cost.Add(this, typeof(Radon), 8, 0, 60, 2, 2000);
            //=90*POWER(B2,2)-2500
            Cost.Add(this, typeof(Cryptium), 0, 0, 90, 2, 2500);
            //=120*POWER(B2,2)-7500
            Cost.Add(this, typeof(Astatine), 0, 0, 120, 2, 7500);
            //=(B2/12)*120*POWER(B2,2)-7000
            Cost.Add(this, typeof(Argon), 12, 0, 120, 2, 7000);
        }

        #endregion RuleSet

    };

}
