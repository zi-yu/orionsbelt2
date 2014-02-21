using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Humans Mithril Extractor
    /// </summary>
    public class MithrilExtractor : BaseHumansFacility {

        #region Properties

        public override string Name {
            get { return "MithrilExtractor"; }
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
            return Cost.CalculateDuration(1, 0, 0.055, 2, 0, level);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 4, 2, 0, level);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Mithril.Resource, 1);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(CommandCenter), 4);
            Dependency.Add(this, 5, typeof(CommandCenter), 5, MaxLevel);

        }

        protected override void BuildCostRules()
        {
            //=40*POWER(B2,2)-40
            Cost.Add(this, typeof(Mithril), 0, 0, 40, 2, 40);
            //=200*POWER(B2,2)
            Cost.Add(this, typeof(Serium), 0, 0, 220, 2, 0);
            //=220*POWER(B2,2)
            Cost.Add(this, typeof(Energy), 0, 0, 200, 2, 0);

            //=100*POWER(B2,2)-200
            Cost.Add(this, typeof(Argon), 0, 0, 100, 2, 200);
            //=60*POWER(B2,2)-3000
            Cost.Add(this, typeof(Prismal), 0, 0, 60, 2, 3000);
            //=70*POWER(B2,2)-2000
            Cost.Add(this, typeof(Radon), 0, 0, 70, 2, 2000);
            //=80*POWER(B2,2)-1000
            Cost.Add(this, typeof(Astatine), 0, 0, 80, 2, 1000);
            //=(B2/10)*80*POWER(B2,2)-5500
            Cost.Add(this, typeof(Cryptium), 10, 0, 80, 2, 5500);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(MithrilExtractor)); }
        }

        #endregion Static Utils

    };

}
