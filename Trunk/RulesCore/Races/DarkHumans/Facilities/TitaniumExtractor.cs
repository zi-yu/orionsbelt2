using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("TitaniumExtractor")]
    public class TitaniumExtractor : BaseDarkHumansFacility {

        #region Properties

        public override string Name {
            get { return "TitaniumExtractor"; }
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
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(TitaniumExtractor)); }
        }

        #endregion Static Utils

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(DarknessHall), 1, MaxLevel);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 3, 2, 0, level);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Titanium.Resource, 1);
            AddToProductionFactor.Add(this, 1);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.054, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=(B2/4)*180*POWER(B2,2)-2400
            Cost.Add(this, typeof(Uranium), 4, 0, 180, 2, 2400);
            //=23*POWER(B2,2)
            Cost.Add(this, typeof(Titanium), 0, 0, 23, 2, 0);
            //=(B2/5)*200*POWER(B2,2)
            Cost.Add(this, typeof(Gold), 5, 0, 200, 2, 0);

            //=90*POWER(B2,2)-2000
            Cost.Add(this, typeof(Cryptium), 0, 0, 90, 2, 2000);
            //=(B2/10)*60*POWER(B2,2)-1000
            Cost.Add(this, typeof(Argon), 10, 0, 60, 2, 1000);
            //=90*POWER(B2,2)-5500
            Cost.Add(this, typeof(Radon), 0, 0, 90, 2, 5500);
            //=80*POWER(B2,2)-3800
            Cost.Add(this, typeof(Astatine), 0, 0, 80, 2, 3800);
            //=(B2/15)*100*POWER(B2,2)-4500
            Cost.Add(this, typeof(Prismal), 15, 0, 100, 2, 4500);
        }

        #endregion RuleSet

    };

}
