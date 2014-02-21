using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("WormHoleCreator")]
    public class WormHoleCreator : BaseBugsFacility {

        #region Properties

        public override string Name {
            get { return "WormHoleCreator"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override int MaxLevel
        {
            get
            {
                return 2;
            }
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
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(WormHoleCreator)); }
        }

        #endregion Static Utils

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(Nest), 7);
            Dependency.Add(this, 2, typeof(Incubator), 9);
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
            //=B2*25000*POWER(1,2)
            //=B2*28000*POWER(1,2)
            Cost.Add(this, typeof(Protol), 1, 0, 25000, 2, 0, true);
            Cost.Add(this, typeof(Elk), 1, 0, 28000, 2, 0, true);
            //=B2*22000*POWER(1,2)
            Cost.Add(this, typeof(Prismal), 1, 0, 22000, 2, 0, true);
            //=B2*38000*POWER(1,2)-38000
            Cost.Add(this, typeof(Radon), 1, 0, 38000, 2, 38000, true);
            //=B2*22000*POWER(1,2)
            Cost.Add(this, typeof(Cryptium), 1, 0, 18000, 2, 0, true);
            //=B2*33000*POWER(1,2)-33000
            Cost.Add(this, typeof(Astatine), 1, 0, 33000, 2, 33000, true);
        }

        protected override void BuildOnCompleteRules(){
            UpdateResourceAfterConstruction.Add(this);
            UpdateUltimateAfterConstruction.Add(this);
            UpdateScoreAfterConstruction.Add(this);
        }

        #endregion RuleSet

    };

}
