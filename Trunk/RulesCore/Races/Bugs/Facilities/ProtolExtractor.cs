using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans TitaniumExtractor
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("ProtolExtractor")]
    public class ProtolExtractor : BaseBugsFacility {

        #region Properties

        public override string Name {
            get { return "ProtolExtractor"; }
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
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(ProtolExtractor)); }
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
            AddToModifier.Add(this, Protol.Resource, 1);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.052, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=23*POWER(B2,2)
            Cost.Add(this, typeof(Protol), 0, 0, 40, 2, 0);
            //=(B2/4)*250*POWER(B2,2)
            Cost.Add(this, typeof(Elk), 0, 0, 240, 2, 0);

            //=90*POWER(B2,2)-2000
            Cost.Add(this, typeof(Prismal), 0, 0, 90, 2, 2000);
            //=(B2/10)*60*POWER(B2,2)-1000
            Cost.Add(this, typeof(Radon), 10, 0, 60, 2, 1000);
            //=90*POWER(B2,2)-5500
            Cost.Add(this, typeof(Cryptium), 0, 0, 90, 2, 5500);
            //=80*POWER(B2,2)-3800
            Cost.Add(this, typeof(Astatine), 0, 0, 80, 2, 3800);
            //=(B2/15)*100*POWER(B2,2)-4500
            Cost.Add(this, typeof(Argon), 15, 0, 100, 2, 4500);
        }

        #endregion RuleSet

    };

}
