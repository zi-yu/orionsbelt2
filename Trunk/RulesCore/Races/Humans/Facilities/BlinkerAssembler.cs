using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Humans Blinker Assembler
    /// </summary>
    public class BlinkerAssembler : BaseHumansFacility {

        #region Properties

        public override string Name {
            get { return "BlinkerAssembler"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        public override int MaxLevel
        {
            get
            {
                return 2;
            }
        }

        #endregion Properties

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(CommandCenter), 8);
            Dependency.Add(this, 2, typeof(UnitYard), 10);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 30, 2, 0, level, true);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 2500, 2, 0, level,true);
        }

        protected override void BuildCostRules()
        {
            //=B2*28000*POWER(1,2)
            //=B2*25000*POWER(1,2)
            //=B2*30000*POWER(1,2)
            Cost.Add(this, typeof(Mithril), 1, 0, 28000, 2, 0, true);
            Cost.Add(this, typeof(Serium), 1, 0, 25000, 2, 0, true);
            Cost.Add(this, typeof(Energy), 1, 0, 26000, 2, 0, true);
            Cost.Add(this, typeof(Argon), 1, 0, 8000, 2, 0, true);
            Cost.Add(this, typeof(Prismal), 1, 0, 10000, 2, 10000, true);
            Cost.Add(this, typeof(Radon), 1, 0, 7000, 2, 0, true);
            Cost.Add(this, typeof(Astatine), 1, 0, 7000, 2, 0, true);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(BlinkerAssembler)); }
        }

        #endregion Static Utils

    };

}
