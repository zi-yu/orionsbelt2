using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("NuclearFacility")]
    public class NuclearFacility : BaseDarkHumansFacility {

        #region Properties

        public override string Name {
            get { return "NuclearFacility"; }
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
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(NuclearFacility)); }
        }

        #endregion Static Utils

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(DarknessHall), 4);
            Dependency.Add(this, 5, typeof(DarknessHall), 5, MaxLevel);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 3, 2, 0, level);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Uranium.Resource, 1);
            AddToProductionFactor.Add(this, 1);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.048, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=40*POWER(B2,2)-40
            Cost.Add(this, typeof(Uranium), 0, 0, 40, 2, 40);
            //=(B2/4)*200*POWER(B2,2)
            Cost.Add(this, typeof(Titanium), 4, 0, 200, 2, 0);
            //=240*POWER(B2,2)
            Cost.Add(this, typeof(Gold), 0, 0, 240, 2, 0);

            //=100*POWER(B2,2)-200
            Cost.Add(this, typeof(Cryptium), 0, 0, 100, 2, 200);
            //=60*POWER(B2,2)-3000
            Cost.Add(this, typeof(Argon), 0, 0, 60, 2, 3000);
            //=70*POWER(B2,2)-2000
            Cost.Add(this, typeof(Radon), 0, 0, 70, 2, 2000);
            //=80*POWER(B2,2)-1000
            Cost.Add(this, typeof(Astatine), 0, 0, 80, 2, 1000);
            //=(B2/10)*80*POWER(B2,2)-5500
            Cost.Add(this, typeof(Prismal), 10, 0, 80, 2, 5500);
        }

        #endregion RuleSet

    };

}
