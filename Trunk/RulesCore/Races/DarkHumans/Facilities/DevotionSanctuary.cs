using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("DevotionSanctuary")]
    public class DevotionSanctuary : BaseDarkHumansFacility {

        #region Properties

        public override string Name {
            get { return "DevotionSanctuary"; }
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

        #region RuleSet

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 3, 2, 0, level);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(DarknessHall), 1, MaxLevel);
        }


        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Gold.Resource, 1);
            AddToProductionFactor.Add(this, 1);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.052, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=220*POWER(B2,2)-2000
            Cost.Add(this, typeof(Uranium), 0, 0, 220, 2, 2000);
            //=160*POWER(B2,2)
            Cost.Add(this, typeof(Titanium), 0, 0, 160, 2, 0);
            //=25*POWER(B2,2)
            Cost.Add(this, typeof(Gold), 0, 0, 25, 2, 0);

            //=100*POWER(B2,2)-2000
            Cost.Add(this, typeof(Cryptium), 0, 0, 100, 2, 2000);
            //=(B2/8)*60*POWER(B2,2)-2000
            Cost.Add(this, typeof(Argon), 8, 0, 60, 2, 2000);
            //=90*POWER(B2,2)-2500
            Cost.Add(this, typeof(Radon), 0, 0, 90, 2, 2500);
            //=120*POWER(B2,2)-7500
            Cost.Add(this, typeof(Astatine), 0, 0, 120, 2, 7500);
            //=(B2/12)*120*POWER(B2,2)-7000
            Cost.Add(this, typeof(Prismal), 12, 0, 120, 2, 7000);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(DevotionSanctuary)); }
        }

        public static int GetGoldIncome(IPlanetResource resource)
        {
            return resource.Level;
        }

        #endregion Static Utils

    };

}
