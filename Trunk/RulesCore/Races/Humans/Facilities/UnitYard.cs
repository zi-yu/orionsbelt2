using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Humans Unit Yard
    /// </summary>
    public class UnitYard : BaseHumansFacility {

        #region Properties

        public override string Name {
            get { return "UnitYard"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        #endregion Properties

        #region RuleSet

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.072, 2, 0, level);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 7, 2, 0, level);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(CommandCenter), 2);
            Dependency.Add(this, 2, typeof(CommandCenter), 2, MaxLevel);
        }

        protected override void BuildCostRules()
        {
            //=440*POWER(B2,2)-4200
            Cost.Add(this, typeof(Mithril), 0, 0, 440, 2, 4200);
            //=250*POWER(B2,2)
            Cost.Add(this, typeof(Serium), 0, 0, 250, 2, 0);
            //=320*POWER(B2,2)
            Cost.Add(this, typeof(Energy), 0, 0, 320, 2, 0);

            //=260*POWER(B2,2)-2500
            Cost.Add(this, typeof(Argon), 0, 0, 260, 2, 2500);
            //=(B2/8)*150*POWER(B2,2)-1500
            Cost.Add(this, typeof(Prismal), 8, 0, 150, 2, 1500);
            //=(B2/6)*120*POWER(B2,2)-5000
            Cost.Add(this, typeof(Radon), 6, 0, 120, 2, 5000);
            //=(B2/6)*120*POWER(B2,2)-9000
            Cost.Add(this, typeof(Astatine), 6, 0, 120, 2, 9000);
            //=(B2/8)*120*POWER(B2,2)-10000
            Cost.Add(this, typeof(Cryptium), 8, 0, 120, 2, 10000);


        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(UnitYard)); }
        }

        #endregion Static Utils

    };

}
