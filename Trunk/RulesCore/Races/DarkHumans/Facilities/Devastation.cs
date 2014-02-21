using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("Devastation")]
    public class Devastation : BaseDarkHumansFacility {

        #region Properties

        public override string Name {
            get { return "Devastation"; }
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
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(Devastation)); }
        }

        #endregion Static Utils

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(DarknessHall), 7);
            Dependency.Add(this, 2, typeof(DominationYard), 9);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 38, 2, 0, level, true);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 3000, 2, 0, level, true);
        }

        protected override void BuildCostRules()
        {
            //=B2*24000*POWER(1,2)
            //=B2*26000*POWER(1,2)
            //=B2*28000*POWER(1,2)
            Cost.Add(this, typeof(Gold), 1, 0, 24000, 2, 0, true);
            Cost.Add(this, typeof(Titanium), 1, 0, 26000, 2, 0, true);
            Cost.Add(this, typeof(Uranium), 1, 0, 28000, 2, 0, true);

            Cost.Add(this, typeof(Cryptium), 1, 0, 6000, 2, 0, true);
            Cost.Add(this, typeof(Argon), 1, 0, 5000, 2, 0, true);
            Cost.Add(this, typeof(Radon), 1, 0, 9000, 2, 12000, true);
            Cost.Add(this, typeof(Astatine), 1, 0, 6000, 2, 0, true);
        }

        protected override void BuildOnCompleteRules(){
            UpdateResourceAfterConstruction.Add(this);
            UpdateUltimateAfterConstruction.Add(this);
            UpdateScoreAfterConstruction.Add(this);
        }

        #endregion RuleSet

    };

}
