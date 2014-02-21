using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Humans Solar Panel
    /// </summary>
    public class SolarPanel : BaseHumansFacility {

        #region Properties

        public override string Name {
            get { return "SolarPanel"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        #endregion Properties

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(CommandCenter), 1, MaxLevel);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 4, 2, 0, level);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Energy.Resource, 1);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.05, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=(B2/8)*160*POWER(B2,2)-1000
            Cost.Add(this, typeof(Mithril), 8, 0, 160, 2, 1000);
            //=120*POWER(B2,2)
            Cost.Add(this, typeof(Serium), 0, 0, 120, 2, 0);
            //=20*POWER(B2,2)
            Cost.Add(this, typeof(Energy), 0, 0, 20, 2, 0);

            //=100*POWER(B2,2)-2000
            Cost.Add(this, typeof(Argon), 0, 0, 100, 2, 2000);
            //=(B2/8)*60*POWER(B2,2)-2000
            Cost.Add(this, typeof(Prismal), 8, 0, 60, 2, 2000);
            //=90*POWER(B2,2)-2500
            Cost.Add(this, typeof(Radon), 0, 0, 90, 2, 2500);
            //=120*POWER(B2,2)-7500
            Cost.Add(this, typeof(Astatine), 0, 0, 120, 2, 7500);
            //=(B2/12)*120*POWER(B2,2)-7000
            Cost.Add(this, typeof(Cryptium), 12, 0, 120, 2, 7000);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(SolarPanel)); }
        }

        #endregion Static Utils

    };

}
