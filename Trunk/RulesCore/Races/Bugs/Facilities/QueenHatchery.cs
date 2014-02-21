using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("QueenHatchery")]
    public class QueenHatchery : BaseBugsFacility {

        #region Properties

        public override string Name {
            get { return "QueenHatchery"; }
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

        public override int MaxLevel  {
            get {
                return 2;
            }
        }
        #endregion Properties

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(QueenHatchery)); }
        }

        #endregion Static Utils

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(Nest), 8);
            Dependency.Add(this, 2, typeof(Incubator), 10);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 42, 2, 0, level, true);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 3000, 2, 0, level, true);
        }

        protected override void BuildCostRules()
        {
            //=B2*32000*POWER(1,2)
            //=B2*24000*POWER(1,2)
            Cost.Add(this, typeof(Protol), 1, 0, 32000, 2, 0, true);
            Cost.Add(this, typeof(Elk), 1, 0, 24000, 2, 0, true);
            //=B2*21000*POWER(1,2)
            Cost.Add(this, typeof(Prismal), 1, 0, 21000, 2, 0, true);
            //=B2*38000*POWER(1,2)-38000
            Cost.Add(this, typeof(Radon), 1, 0, 38000, 2, 38000, true);
            //=B2*36000*POWER(1,2)-36000
            Cost.Add(this, typeof(Cryptium), 1, 0, 36000, 2, 36000, true);
            //=B2*17000*POWER(1,2)
            Cost.Add(this, typeof(Astatine), 1, 0, 17000, 2, 0, true);
        }

        #endregion RuleSet

    };

}
