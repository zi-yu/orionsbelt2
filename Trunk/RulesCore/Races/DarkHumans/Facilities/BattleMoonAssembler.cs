

using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("BattleMoonAssembler")]
    public class BattleMoonAssembler : BaseDarkHumansFacility {

        #region Properties

        public override string Name {
            get { return "BattleMoonAssembler"; }
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

        public override int MaxLevel
        {
            get
            {
                return 2;
            }
        }
        #endregion Properties

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(BattleMoonAssembler)); }
        }

        #endregion Static Utils

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(DarknessHall), 8);
            Dependency.Add(this, 2, typeof(DominationYard), 10);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 45, 2, 0, level, true);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 2500, 2, 0, level, true);
        }

        protected override void BuildCostRules()
        {
            //=B2*33000*POWER(1,2)
            //=B2*28000*POWER(1,2)
            //=B2*36000*POWER(1,2)
            Cost.Add(this, typeof(Gold), 1, 0, 33000, 2, 0, true);
            Cost.Add(this, typeof(Titanium), 1, 0, 28000, 2, 0, true);
            Cost.Add(this, typeof(Uranium), 1, 0, 36000, 2, 0, true);

            Cost.Add(this, typeof(Cryptium), 1, 0, 8000, 2, 0, true);
            Cost.Add(this, typeof(Argon), 1, 0, 10000, 2, 10000, true);
            Cost.Add(this, typeof(Radon), 1, 0, 7000, 2, 0, true);
            Cost.Add(this, typeof(Astatine), 1, 0, 6500, 2, 0, true);
        }

        #endregion RuleSet

    };

}
